using Com.Zebra.Rfid.Api3;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZebraRFIDXamarinDemo.Models
{
    public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public static ReaderModel rfidModel = ReaderModel.readerModel;

		public BaseViewModel()
		{

		}

		public virtual void HHTriggerEvent(bool pressed)
		{

		}

		public virtual void TagReadEvent(TagData[] tags)
		{

		}

		public virtual void StatusEvent(Events.StatusEventData statusEvent)
		{

		}

        public virtual void ReaderConnectionEvent(bool connection)
        {
            isConnected = connection;
        }

        public virtual void ReaderAppearanceEvent(bool appeared)
        {

        }

        internal void UpdateIn()
		{
			rfidModel.TagRead += TagReadEvent;
			rfidModel.TriggerEvent += HHTriggerEvent;
			rfidModel.StatusEvent += StatusEvent;
            rfidModel.ReaderConnectionEvent += ReaderConnectionEvent;
            rfidModel.ReaderAppearanceEvent += ReaderAppearanceEvent;
        }

		internal void UpdateOut()
		{
			rfidModel.TagRead -= TagReadEvent;
			rfidModel.TriggerEvent -= HHTriggerEvent;
			rfidModel.StatusEvent -= StatusEvent;
            rfidModel.ReaderConnectionEvent -= ReaderConnectionEvent;
            rfidModel.ReaderAppearanceEvent -= ReaderAppearanceEvent;
        }

        public bool isConnected { get => rfidModel.isConnected; set => OnPropertyChanged(); }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
