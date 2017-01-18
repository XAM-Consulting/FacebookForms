using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(FBPlay.iOS.NoBorderEntryEffectiOS), "NoBorderEntryEffect")]

namespace FBPlay.iOS
{
    public class NoBorderEntryEffectiOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            var textField = (UITextField)Control;

            textField.BorderStyle = UITextBorderStyle.None;
            textField.BackgroundColor = Color.Transparent.ToUIColor();
        }

        protected override void OnDetached()
        {

        }
    }
}
