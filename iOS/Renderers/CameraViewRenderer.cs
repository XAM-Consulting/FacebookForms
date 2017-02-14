using AVFoundation;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreMedia;
using System.Diagnostics;
using FBPlay;
using FBPlay.iOS;
using MediaCapture;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]

namespace FBPlay.iOS
{
    /// <summary>
    /// Class CameraViewRenderer.
    /// </summary>
    public class CameraViewRenderer : ViewRenderer<CameraView, CameraPreview>
    {
        /// <summary>
        /// Called when [element changed].
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<CameraView> e)
        {
            System.Diagnostics.Debug.WriteLine("Testing CameraView");
            base.OnElementChanged(e);

            if (Control == null)
            {
                var cameraPreview = new CameraPreview();
                Element.Errors = cameraPreview.LoadErrors;
                SetNativeControl(cameraPreview);
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case "Camera":
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Class CameraPreview.
    /// </summary>
    //[Register("CameraPreview")]
    public class CameraPreview : UIView
    {
        /// <summary>
        /// The _preview layer
        /// </summary>
        private AVCaptureVideoPreviewLayer _previewLayer;

        public string LoadErrors { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraPreview"/> class.
        /// </summary>
        public CameraPreview()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraPreview"/> class.
        /// </summary>
        /// <param name="bounds">The bounds.</param>
        public CameraPreview(CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }

        /// <summary>
        /// Draws the specified rect.
        /// </summary>
        /// <param name="rect">The rect.</param>
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            _previewLayer.Frame = rect;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            var captureSession = new AVCaptureSession();
            _previewLayer = new AVCaptureVideoPreviewLayer(captureSession)
            {
                VideoGravity = AVLayerVideoGravity.ResizeAspectFill,

                Frame = Bounds
            };
            // create a device input and attach it to the session
            AVCaptureDevice frontCameraDevice = MediaDevices.FrontCamera;
            if (frontCameraDevice == null)
            {
                LoadErrors = "Cannot load camera";
                return;
            }

            try
            {
                NSError error = null;
                frontCameraDevice.LockForConfiguration(out error);
                if (error != null)
                {
                    Debug.WriteLine(error);
                    //throw new BusinessLogicException (ErrorCode.EC_UNDEFINED_ERROR, error.ToString());
                    //TODO: show error to user
                }
                frontCameraDevice.ActiveVideoMinFrameDuration = new CMTime(1, 15); // Configure for 15 FPS
            }
            finally
            {
                frontCameraDevice.UnlockForConfiguration();
            }

            AVCaptureDeviceInput inputDevice = AVCaptureDeviceInput.FromDevice(frontCameraDevice);

            if (inputDevice == null)
            {
                LoadErrors = "Cannot access front camera";
                return;
            }

            captureSession.AddInput(inputDevice);

            NSError errorOut;

            Layer.AddSublayer(_previewLayer);

            captureSession.StartRunning();
        }
    }
}