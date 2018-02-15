using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WpfVideoPlayer.Models;
using WpfVideoPlayer.ViewModels.Base;

namespace WpfVideoPlayer.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        #region Private Properties

        private Video _video;

        private string _videoPath;

        private BitmapSource _image;

        #endregion

        #region Public Properties

        /// <summary>
        /// If the video path is changed, the video is freshly instantiated to hold the source path as well.
        /// </summary>
        public string VideoPath
        {
            get => _videoPath;
            set
            {
                ChangeAndNotify(value, ref _videoPath);
                _video = new Video(value);
            }
        }

        public BitmapSource Image
        {
            get => _image;
            set => ChangeAndNotify(value, ref _image);
        }

        #endregion

        #region Constructor

        public VideoViewModel()
        {
            _video = new Video();
        }

        #endregion

        public ICommand LoadCommand => new RelayCommand(LoadVideo, true);

        private void LoadVideo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                VideoPath = openFileDialog.FileName;
                Image = _video.GetFrame();
            }
        }
    }
}
