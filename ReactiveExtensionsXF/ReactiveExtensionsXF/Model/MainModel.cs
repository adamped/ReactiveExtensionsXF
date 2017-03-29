using ReactiveExtensionsXF.Repository;
using System;
using Xamarin.Forms;

namespace ReactiveExtensionsXF.Model
{
    public class MainModel
    {
        private readonly DataRepository _repository = new DataRepository();
        public event EventHandler UpdatedData;
        private int _count = 0;
        public MainModel()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                UpdatedData?.Invoke(this, new DataEventArgs() { Text = _count.ToString("N0") });
                _count++;
                return true;
            });
        }

    }

    public class DataEventArgs : EventArgs
    {
        public string Text { get; set; }
    }

}
