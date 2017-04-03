using ReactiveExtensionsXF.Model;
using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;

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
            IObservable<long> mainSequence = Observable.Interval(TimeSpan.FromSeconds(1));

            var eventAsObservable = Observable.FromEventPattern(ev => _mainModel.UpdatedData += ev,
                                                                      ev => _mainModel.UpdatedData -= ev)
                                              .Where(x=>((DataEventArgs)x.EventArgs).Count > 5);

            eventAsObservable.Subscribe(x => { LabelText = $"Count: {((DataEventArgs)x.EventArgs).Count.ToString("N0")}"; });

            // Call Dispose when finished, to unsubsribe to events
            //updateData.Dispose();
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
