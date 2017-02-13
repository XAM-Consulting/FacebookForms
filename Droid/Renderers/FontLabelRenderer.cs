//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using Android.Graphics;
//using Android.Text.Style;
//using Android.Text;
//using FBPlay.Droid;

//[assembly: ExportRenderer(typeof(Label), typeof(FontLabelRenderer))]

//namespace FBPlay.Droid
//{
//    public class FontLabelRenderer : LabelRenderer
//    {
//        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
//        {
//            base.OnElementChanged(e);

//            if (e.OldElement == null)
//            {
//                var customLabel = this.Element as CustomLabel;
//                if (customLabel != null)
//                {
//                    var lineSpacing = customLabel.LineSpacing;
//                    //this.Control.SetLineSpacing(1f, (float)lineSpacing);
//                    this.Control.SetLineSpacing((float)lineSpacing, 1f);
//                }
//            }

//            Label label = e.NewElement;

//            if (label == null)
//                return;

//            if (label.FormattedText != null)
//            {
//                HandleFormattedText(label);
//                return;
//            }

//            Typeface fontTypeface = GetCustomFont(label.FontFamily, label.FontAttributes);

//            if (fontTypeface != null)
//                Control.Typeface = fontTypeface;
//        }

//        StyleSpan GetSpanStyle(Span span)
//        {
//            if (span == null || span.FontAttributes == FontAttributes.None)
//                return null;

//            var style = TypefaceStyle.Normal;

//            if ((span.FontAttributes & FontAttributes.Bold) != 0 && (span.FontAttributes & FontAttributes.Italic) != 0)
//            {
//                style = TypefaceStyle.BoldItalic;
//            }
//            else if ((span.FontAttributes & FontAttributes.Bold) != 0)
//            {
//                style = TypefaceStyle.Bold;
//            }
//            else if ((span.FontAttributes & FontAttributes.Italic) != 0)
//            {
//                style = TypefaceStyle.Italic;
//            }

//            return new StyleSpan(style);
//        }

//        void HandleFormattedText(Label label)
//        {
//            if (label == null || !UsesCustomFonts(label))
//                return;

//            var builder = new SpannableStringBuilder();

//            foreach (var span in label.FormattedText.Spans)
//            {
//                ForegroundColorSpan spanForegroundColor = span.ForegroundColor == Xamarin.Forms.Color.Default ? null : spanForegroundColor = new ForegroundColorSpan(span.ForegroundColor.ToAndroid());
//                BackgroundColorSpan spanBackgroundColor = span.BackgroundColor == Xamarin.Forms.Color.Default ? null : spanBackgroundColor = new BackgroundColorSpan(span.BackgroundColor.ToAndroid());
//                StyleSpan spanStyle = GetSpanStyle(span);
//                AbsoluteSizeSpan spanSize = double.IsNaN(span.FontSize) ? null : spanSize = new AbsoluteSizeSpan((int)span.FontSize, true);
//                Typeface tf = (string.IsNullOrEmpty(span.FontFamily)) ? Typeface.Default : GetCustomFont(span.FontFamily, span.FontAttributes);

//                // we don't cache the spans' spanTypeface. create new (based on the cached font typeface)
//                CustomTypefaceSpan spanTypeface = new CustomTypefaceSpan(span.FontFamily, tf);

//                if (spanTypeface == null)
//                {
//                    continue;
//                }

//                int lastPosition = builder.Length();
//                int len;

//                builder.Append(span.Text);

//                len = builder.Length();

//                if (spanForegroundColor != null)
//                    builder.SetSpan(spanForegroundColor, lastPosition, len, SpanTypes.Composing);

//                if (spanBackgroundColor != null)
//                    builder.SetSpan(spanBackgroundColor, lastPosition, len, SpanTypes.Composing);

//                if (spanTypeface != null)
//                {
//                    builder.SetSpan(spanTypeface, lastPosition, len, SpanTypes.Composing);
//                }


//                if (spanStyle != null)
//                    builder.SetSpan(spanStyle, lastPosition, len, SpanTypes.Composing);

//                if (spanSize != null)
//                    builder.SetSpan(spanSize, lastPosition, len, SpanTypes.Composing);
//            }

//            Control.TextFormatted = builder;
//        }


//        private Typeface GetCustomFont(string fontFamily, FontAttributes attributes)
//        {
//            if (string.IsNullOrEmpty(fontFamily))
//                return null;

//            return FontCache.Instance.GetTypeFaceForFontFamily(fontFamily, attributes, true);
//        }

//        private bool UsesCustomFonts(Label label)
//        {
//            if (label == null || label.FormattedText == null || label.FormattedText.Spans == null)
//                return false;

//            foreach (var span in label.FormattedText.Spans)
//            {
//                if (!string.IsNullOrEmpty(span.FontFamily))
//                    return true;
//            }

//            return false;
//        }


//    }
//}


