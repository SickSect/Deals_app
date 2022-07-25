using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deals_app.data
{
    class todo_model : INotifyPropertyChanged
    {
        //нужно реализовать интерфейс для отслеживания событий
        public DateTime Creation_date { get; set; } = DateTime.Now;
        private bool IsDone;
        private string Event_Info;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Is_Done
        {
            get { return IsDone; }
            set 
            {
                if (IsDone == value)
                    return;
                IsDone = value;
                OnPropertyChanged("Is Done");
            }
        }

        public string event_info
        {
            get { return Event_Info; }
            set
            {
                if (Event_Info == value)
                    return;
                Event_Info = value;
                OnPropertyChanged("Event info");
            }
        }
        
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            /*
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            */
            // можно короче
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
