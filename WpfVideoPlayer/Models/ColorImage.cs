using System;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using WpfVideoPlayer.Model;

namespace WpfVideoPlayer.Models
{
    /// <summary>
    /// A basic image container class with images.
    /// </summary>
    public abstract class ColorImage    
    {
        #region Public Properties

        public virtual Mat Image { get; set; }

        #endregion

        #region Public Members

        /// <summary>
        /// Loads an image from a file path.
        /// </summary>
        /// <param name="filePath">The entire file path.</param>
        public void LoadImage(string filePath)
        {
            Image = new Mat(filePath);
        }

        /// <summary>
        /// Converts the image into a WPF-usable BitmapSource.
        /// </summary>
        /// <returns></returns>
        public BitmapSource ConvertImage()
        {
            BitmapSource bitmapSource = BitMapConverter.ToBitmapSource(Image);
            return bitmapSource;
        }

        #endregion
    }
}
