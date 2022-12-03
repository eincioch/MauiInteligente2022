using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiInteligente2022.AppBase.Objects {
    public abstract class ObservableObject : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new(propertyName));

        protected bool SetProperty<T>(ref T backing, T value, [CallerMemberName]string propertyName = "",
            Action onChanged = null) {
            if (EqualityComparer<T>.Default.Equals(backing, value))
                return false;

            backing = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}