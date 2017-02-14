using System;
using System.Collections.Generic;
using Android.Content;
using Android.Hardware;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Media;
using FBPlay;
using FBPlay.Droid;

[assembly: ExportRenderer(typeof(CameraView), typeof(CameraViewRenderer))]

namespace FBPlay.Droid
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
            base.OnElementChanged(e);


            if (this.Control == null)
            {
                this.SetNativeControl(new CameraPreview(this.Context) { Tag = "CameraPreView" });
            }

            if (e.NewElement != null && this.Control != null)
            {
                var cameraAndId = CameraHelper.GetFrontFacingCameraWithId();
                this.Control.SetCamera(cameraAndId);
            }
        }


        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CameraView.IsVisibleProperty.PropertyName)
            {
                this.Control.HideCameraPreView(!Element.IsVisible);
            }
        }
    }

    /// <summary>
    /// Class CameraPreview.
    /// </summary>
    public class CameraPreview : ViewGroup, ISurfaceHolderCallback
    {
        const string TAG = "Preview";

        SurfaceView _mSurfaceView;
        ISurfaceHolder _mHolder;
        Camera.Size _mPreviewSize;
        IList<Camera.Size> _mSupportedPreviewSizes;
        Camera _camera;
        public Tuple<int, global::Android.Hardware.Camera> CameraWithId { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="CameraPreview"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CameraPreview(Context context)
            : base(context)
        {
            _mSurfaceView = new SurfaceView(context);
            AddView(_mSurfaceView);

            _mHolder = _mSurfaceView.Holder;
            _mHolder.AddCallback(this);

        }

        /// <summary>
        /// Switches the camera.
        /// </summary>
        /// <param name="camera">The camera.</param>
        public void SetCamera(Tuple<int, global::Android.Hardware.Camera> cameraWithId)
        {
            CameraWithId = cameraWithId;

        }

        /// <summary>
        /// Called when [measure].
        /// </summary>
        /// <param name="widthMeasureSpec">The width measure spec.</param>
        /// <param name="heightMeasureSpec">The height measure spec.</param>
        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            // We purposely disregard child measurements because act as a
            // wrapper to a SurfaceView that centers the camera preview instead
            // of stretching it.
            int width = ResolveSize(SuggestedMinimumWidth, widthMeasureSpec);
            int height = ResolveSize(SuggestedMinimumHeight, heightMeasureSpec);
            SetMeasuredDimension(width, height);
        }

        public void HideCameraPreView(bool hide)
        {
            if (hide)
            {
                _mSurfaceView.Visibility = ViewStates.Gone;
            }
            else {
                _mSurfaceView.Visibility = ViewStates.Visible;
            }
        }

        /// <summary>
        /// Called when [layout].
        /// </summary>
        /// <param name="changed">if set to <c>true</c> [changed].</param>
        /// <param name="l">The l.</param>
        /// <param name="t">The t.</param>
        /// <param name="r">The r.</param>
        /// <param name="b">The b.</param>
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {

            if (changed && ChildCount > 0)
            {
                var child = GetChildAt(0);

                int width = r - l;
                int height = b - t;

                child.Layout(0, 0, width, height);
            }
        }

        /// <summary>
        /// Surfaces the created.
        /// </summary>
        /// <param name="holder">The holder.</param>
        public void SurfaceCreated(ISurfaceHolder holder)
        {
            // The Surface has been created, acquire the camera and tell it where
            // to draw.
            try
            {
                if (CameraWithId.Item2 != null)
                {
                    CameraWithId.Item2.SetPreviewDisplay(holder);
                }
            }
            catch (Java.IO.IOException exception)
            {
                Android.Util.Log.Error(TAG, "IOException caused by setPreviewDisplay()", exception);
            }
        }

        /// <summary>
        /// Surfaces the destroyed.
        /// </summary>
        /// <param name="holder">The holder.</param>
        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            if (CameraWithId.Item2 != null)
            {
                //PreviewCamera.
                CameraWithId.Item2.StopPreview();
            }
        }

        /// <summary>
        /// Surfaces the changed.
        /// </summary>
        /// <param name="holder">The holder.</param>
        /// <param name="format">The format.</param>
        /// <param name="w">The w.</param>
        /// <param name="h">The h.</param>
        public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
        {
            CameraWithId.Item2.StartPreview();
            var postRotation = CameraHelper.GetCameraDisplayOrientation(CameraWithId.Item1);

            CameraWithId.Item2.SetDisplayOrientation(postRotation);

            var parameters = CameraWithId.Item2.GetParameters();
            var profile = CamcorderProfile.Get(CameraWithId.Item1, CamcorderQuality.Q480p);
            parameters.SetPreviewSize(profile.VideoFrameWidth, profile.VideoFrameHeight);
            RequestLayout();

            CameraWithId.Item2.SetParameters(parameters);
        }

        protected override void Dispose(bool disposing)
        {
            CameraWithId.Item2.StopPreview();
            CameraWithId.Item2.Release();
            base.Dispose(disposing);
        }
    }
}
