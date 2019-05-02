using System.ComponentModel;


namespace WorkTimer.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                var propertyChangedEventArgs = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, propertyChangedEventArgs);
            }
        }
    }
}
