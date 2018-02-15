using System.Windows.Media.Imaging;
using Emgu.CV;
using WpfVideoPlayer.Model;

namespace WpfVideoPlayer.Models
{
    /// <summary>
    /// Contains a string with the file path of the video source as well as a Emgu VideoCapture class
    /// to contain the video.
    /// </summary>
    public class Video
    {
        #region Private Properties

        private VideoCapture _capture;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor simply calls the VideoSource property setter which instantiates a new video capture.
        /// </summary>
        /// <param name="videoPath"></param>
        public Video(string videoPath = null)
        {
            if (videoPath == null) return;
            
            _capture = new VideoCapture(videoPath);
        }

        #endregion

        /// <summary>
        /// Queries the first image of the video and returns it as a BitmapSource which can be displayed
        /// in the View.
        /// </summary>
        /// <returns></returns>
        public BitmapSource GetFrame()
        {
            Mat frame = _capture.QueryFrame();
            return BitMapConverter.ToBitmapSource(frame);
        }
    }
}
