using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Widget;
using Android.Graphics;
using Android.Text.Style;
using Android.Text;
using System.Linq;
using System.Collections.Generic;

namespace FBPlay.Droid
{
    /// <summary>
    /// FontCache : 160320 future use
    /// </summary>
    public class FontCache
    {
        static FontCache _instance = null;

        List<FontTypefaceCacheItem> _items = new List<FontTypefaceCacheItem>();

        public static FontCache Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FontCache();

                return _instance;
            }
        }

        protected FontCache()
        {

        }

        public List<FontTypefaceCacheItem> Items
        {
            get { return _items; }
        }

        public FontTypefaceCacheItem this[string fontFamily]
        {
            get
            {
                return string.IsNullOrEmpty(fontFamily) ? null : _items.FirstOrDefault(i => i.FontFamily == fontFamily);
            }
        }

        public FontTypefaceCacheItem AddItem(FontTypefaceCacheItem item, FontAttributes attribute)
        {
            if (item == null || string.IsNullOrEmpty(item.FontFamily))
                return item;

            string fontFamily = item.FontFamily;

            FontTypefaceCacheItem existent = this[fontFamily];

            if (existent == null)
            {
                try
                {
                    Typeface typeface = Typeface.CreateFromAsset(Forms.Context.Assets, fontFamily + ".ttf");

                    item.SetAttributeTypeface(attribute, typeface);
                    _items.Add(item);
                }
                catch
                {
                    // Font not found
                    System.Diagnostics.Debug.WriteLine("Font not found(Add Item): " + fontFamily);
                }
            }

            return existent == null ? item : existent;
        }


        public FontTypefaceCacheItem AddItem(string fontFamily, FontAttributes attribute)
        {
            if (string.IsNullOrEmpty(fontFamily))
            {
                return null;
            }
            else if (!fontFamily.Contains("-"))
            {
                fontFamily += "-Regular";
            }

            FontTypefaceCacheItem newItem = this.AddItem(new FontTypefaceCacheItem(fontFamily), attribute);

            if (newItem != null)
            {
                Typeface typeface = newItem.GetTypeface(attribute);

                try
                {
                    if (typeface == null)
                        newItem.SetAttributeTypeface(attribute, Typeface.CreateFromAsset(Forms.Context.Assets, fontFamily + ".ttf"));
                }
                catch
                {
                    //Font not found
                    System.Diagnostics.Debug.WriteLine("Font not found(Add Family): " + fontFamily);
                }
            }

            return newItem;
        }

        public bool RemoveItem(FontTypefaceCacheItem item)
        {
            return _items.Remove(item);
        }


        public Typeface GetTypeFaceForFontFamily(string fontFamily, FontAttributes attribute, bool addNewIfNotFound)
        {
            FontTypefaceCacheItem item = this[fontFamily];

            if (item == null)
            {
                if (addNewIfNotFound)
                    item = this.AddItem(fontFamily, attribute);
            }

            if (item == null)
                return null;

            return item.GetTypeface(attribute);
        }
    }


    public class FontFaceInfo
    {
        FontAttributes _attribute = FontAttributes.None;
        Typeface _typeFace = null;
        FontTypefaceCacheItem _parentItem = null;

        public FontFaceInfo()
        {

        }

        public FontFaceInfo(FontTypefaceCacheItem parentItem, Typeface typeFace)
        {
            _parentItem = parentItem;
            _typeFace = typeFace;
        }

        public FontTypefaceCacheItem ParentItem
        {
            get { return _parentItem; }
            set { _parentItem = value; }
        }

        public FontAttributes Attribute
        {
            get { return _attribute; }
            set { _attribute = value; }
        }

        public Typeface TypeFace
        {
            get { return _typeFace; }
            set { _typeFace = value; }
        }
        public CustomTypefaceSpan SpanTypeFace
        {
            get { return _typeFace == null || _parentItem == null ? null : new CustomTypefaceSpan(_parentItem.FontFamily, _typeFace); }
        }
    }

    // http://stackoverflow.com/questions/6612316/how-set-spannable-object-font-with-custom-font
    public class CustomTypefaceSpan : TypefaceSpan
    {
        private readonly Typeface _typeFace;

        public CustomTypefaceSpan(string fontFamily, Typeface typeFace) : base(fontFamily)
        {
            _typeFace = typeFace;
        }

        public override void UpdateDrawState(TextPaint ds)
        {
            ApplyCustomTypeFace(ds, _typeFace);
        }

        public override void UpdateMeasureState(TextPaint paint)
        {
            ApplyCustomTypeFace(paint, _typeFace);
        }

        private static void ApplyCustomTypeFace(TextPaint paint, Typeface typeFace)
        {
            TypefaceStyle oldStyle;
            Typeface old = paint.Typeface;

            if (old == null)
            {
                oldStyle = TypefaceStyle.Normal;
            }
            else
            {
                oldStyle = old.Style;
            }

            // TODO: Ver si tenemos que setear el fake bold, italic

            paint.SetTypeface(typeFace);
        }
    }

    public class FontTypefaceCacheItem
    {
        string _fontFamily;
        List<FontFaceInfo> _fontFaceList = new List<FontFaceInfo>();

        public FontTypefaceCacheItem(string fontFamilyName)
        {
            _fontFamily = fontFamilyName;
        }

        public string FontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }

        public FontFaceInfo this[FontAttributes attribute]
        {
            get { return _fontFaceList.FirstOrDefault(i => i.Attribute == attribute); }
        }


        public void SetAttributeTypeface(FontAttributes attribute, Typeface typeface)
        {
            FontFaceInfo item = this[attribute];

            if (item == null)
            {
                item = new FontFaceInfo(this, typeface);
                _fontFaceList.Add(item);
            }

            if (item.TypeFace == null)
                item.TypeFace = typeface;
        }


        public Typeface GetTypeface(FontAttributes attribute)
        {
            FontFaceInfo item = this[attribute];

            return item == null ? null : item.TypeFace;
        }

        public CustomTypefaceSpan GetSpanTypeface(FontAttributes attribute)
        {
            FontFaceInfo item = this[attribute];

            return item == null ? null : item.SpanTypeFace;
        }

        internal void CopyOther(FontTypefaceCacheItem other)
        {
            if (other == null || other == this)
                return;

            this._fontFamily = other._fontFamily;
            this._fontFaceList.AddRange(other._fontFaceList);

            // update parent
            foreach (FontFaceInfo item in _fontFaceList)
                item.ParentItem = this;
        }
    }

}