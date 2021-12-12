using System;
using System.Collections;
using System.IO;
using UnityEngine;


namespace ArtomStatsenko
{
    public sealed class PhotoController
    {
        private bool _isProcessed;
        private readonly string _path;
        private int _layers = 5;
        private int _resolution = 5;
        private Camera _camera;

        public PhotoController()
        {
            _path = Application.dataPath;
            _camera = Camera.main;
        }

        public IEnumerator DoTapExampleAsync()
        {
            _isProcessed = true;
            _camera.cullingMask = ~(1 << _layers);
            var width = Screen.width;
            var height = Screen.height;
            yield return new WaitForEndOfFrame();

            var screen = new Texture2D(width, height, TextureFormat.RGB24, true);
            screen.ReadPixels(new Rect(0, 0, width, height), 0, 0);

            var bytes = screen.EncodeToPNG();
            var filename = string.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);

            File.WriteAllBytes(Path.Combine(_path, filename), bytes);
            yield return new WaitForSeconds(2.3f);

            _camera.cullingMask |= 1 << _layers;
            _isProcessed = false;
        }

        public void CreateScreenShot()
        {
            var filename = string.Format("{0:ddMMyyyy_HHmmssfff}.png", DateTime.Now);
            ScreenCapture.CaptureScreenshot(Path.Combine(_path, filename), _resolution);
        }
    }
}