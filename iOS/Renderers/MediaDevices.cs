using System.Linq;
using AVFoundation;

namespace MediaCapture
{
    public static class MediaDevices
    {
        private static AVCaptureDevice _frontCamera = null;
        private static AVCaptureDevice _backCamera = null;
        private static AVCaptureDevice _microphone = null;


        public static AVCaptureDevice FrontCamera
        {
            get
            {
                if (_frontCamera == null)
                {
                    _frontCamera = GetCamera("Front Camera");
                }
                return _frontCamera;
            }
        }

        public static AVCaptureDevice BackCamera
        {
            get
            {
                if (_backCamera == null)
                {
                    _backCamera = GetCamera("Back Camera");
                }
                return _backCamera;
            }
        }

        public static AVCaptureDevice Microphone
        {
            get
            {
                if (_microphone == null)
                {
                    _microphone = GetMicrophone();
                }
                return _microphone;
            }
        }

        private static AVCaptureDevice GetCamera(string localizedDeviceName)
        {
            var devices = AVCaptureDevice.DevicesWithMediaType(AVMediaType.Video);
            foreach (AVCaptureDevice device in devices)
            {
                if (string.Compare(device.LocalizedName, localizedDeviceName, true) == 0)
                {
                    return device;
                }
            }
            return null;
        }

        private static AVCaptureDevice GetMicrophone()
        {
            var devices = AVCaptureDevice.DevicesWithMediaType(AVMediaType.Audio);
            return devices.ToList().FirstOrDefault();
        }

    }
}
