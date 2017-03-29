using ReactiveExtensionsXF.Model;
using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ReactiveExtensionsXF.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private MainModel _mainModel = new MainModel();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            LabelText = "Hello";

            Track();
        }

        private void Track()
        {

            var eventAsObservable = Observable.FromEventPattern(ev => _mainModel.UpdatedData += ev,
                                                                      ev => _mainModel.UpdatedData -= ev);

            eventAsObservable.Subscribe(args =>
            {
                LabelText = ((DataEventArgs)args.EventArgs).Text;
            }
            );

        }

        private string _labelText;
        public string LabelText
        {
            get
            {
                return _labelText;
            }
            set
            {
                _labelText = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
