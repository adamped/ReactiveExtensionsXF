using ReactiveExtensionsXF.Repository;
using System;
using Xamarin.Forms;

namespace ReactiveExtensionsXF.Model
{
    public class MainModel
    {
        public event EventHandler UpdatedData;
        private int _count = 0;
        public MainModel()
        {

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                UpdatedData?.Invoke(this, new DataEventArgs() { Count = _count });
                _count++;
                return true;
            });
        }
    }

    public class DataEventArgs : EventArgs
    {
        public int Count { get; set; }
    }

}
