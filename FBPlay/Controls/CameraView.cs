using System;
using Xamarin.Forms;

namespace FBPlay
{
    public enum CameraDevice
    {
        Rear,
        Front
    }

    /// <summary>
    /// Class CameraView.
    /// </summary>
    public class CameraView : View
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraView"/> class.
        /// </summary>
        public CameraView()
        {
        }

        /// <summary>
        /// The camera device to use.
        /// </summary>
        public static readonly BindableProperty CameraProperty =
            BindableProperty.Create<CameraView, CameraDevice>(
                p => p.Camera, CameraDevice.Rear);

        /// <summary>
        /// Gets or sets the camera device to use.
        /// </summary>
        public CameraDevice Camera
        {
            get { return (CameraDevice)this.GetValue(CameraProperty); }
            set { this.SetValue(CameraProperty, value); }
        }

        public static readonly BindableProperty ErrorsProperty = BindableProperty.Create(nameof(Errors), typeof(string), typeof(CameraView), default(string));
        public string Errors
        {
            get { return (string)GetValue(ErrorsProperty); }
            set { SetValue(ErrorsProperty, value); }
        }
    }
}
