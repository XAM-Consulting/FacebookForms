using System;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("XamConsulting")]
[assembly: ExportEffect(typeof(FBPlay.iOS.CustomSearchBarEffectsiOS), "CustomSearchBarEffects")]
namespace FBPlay.iOS
{
    public class CustomSearchBarEffectsiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            var effect = (CustomSearchBarEffects)Element.Effects.FirstOrDefault(i => i is CustomSearchBarEffects);

            var searchBar = (UISearchBar)Control;
            searchBar.TintColor = UIColor.White;

            UITextField text = (UITextField)searchBar.ValueForKey(new NSString("_searchField"));
            text.BackgroundColor = effect.PlaceHolderBackgroundColor.ToUIColor();
        }

        protected override void OnDetached()
        {

        }
    }
}
