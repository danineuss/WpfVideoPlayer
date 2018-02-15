using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfVideoPlayer.ViewModels.Base
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void ChangeAndNotify<T>(T value, ref T property, [CallerMemberName] string propertyName = null)
        {
            OnPropertyChanging(propertyName);
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
