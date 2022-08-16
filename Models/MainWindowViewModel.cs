using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace  GenericHostWPF;
public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
        string _message { get; set; }= string.Empty;
        public string Message
        {
            get { return _message; }
            set 
            { 
                if (value == _message) return;
                _message = value;
                RaisePropertyChanged();
            }
        }
        string _log { get; set; }= string.Empty;
        public string Log
        {
            get { return _log; }
            set 
            { 
                if (value == _log) return;
                _log = value;
                RaisePropertyChanged();
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}