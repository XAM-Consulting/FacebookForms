using System;
using Android.Hardware;
using Android.App;
using Xamarin.Forms;
using Android.Views;

namespace FBPlay.Droid
{
    public class CameraHelper
    {
        public static Tuple<int, Camera> GetFrontFacingCameraWithId()
        {
            Tuple<int, Camera> cameraKeyValue = null;
            //if (_cameraKeyValue != null)
            //    return _cameraKeyValue;
            var numberOfCameras = Camera.NumberOfCameras;
            var cameraInfo = new Camera.CameraInfo();
            for (int i = 0; i < numberOfCameras; ++i)
            {
                Camera.GetCameraInfo(i, cameraInfo);
                if (cameraInfo.Facing == CameraFacing.Front)
                {
                    cameraKeyValue = new Tuple<int, Camera>(i, Camera.Open(i));
                    break;
                }
            }
            return cameraKeyValue;
        }

        // In Android we used fixOrientation 
        public static int GetCameraDisplayOrientation()
        {
            return 270;
        }

        public static int GetCameraDisplayOrientation(int cameraID)
        {
            //return 270;
            var info = new Camera.CameraInfo();
            Camera.GetCameraInfo(cameraID, info);
            var rotation = ((Activity)Forms.Context).WindowManager.DefaultDisplay.Rotation;
            int degrees = 0;
            switch (rotation)
            {
                case SurfaceOrientation.Rotation0:
                    degrees = 0;
                    break;
                case SurfaceOrientation.Rotation90:
                    degrees = 90;
                    break;
                case SurfaceOrientation.Rotation180:
                    degrees = 180;
                    break;
                case SurfaceOrientation.Rotation270:
                    degrees = 270;
                    break;
            }

            int result;
            if (info.Facing == CameraFacing.Front)
            {
                result = (info.Orientation + degrees) % 360;
                result = (360 - result) % 360;  // compensate the mirror
            }
            else
            {  // back-facing
                result = (info.Orientation - degrees + 360) % 360;
            }
            return result;
        }
    }
}

