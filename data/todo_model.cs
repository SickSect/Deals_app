using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deals_app.data
{
    class todo_model
    {
        public DateTime Creation_date { get; set; } = DateTime.Now;
        private bool IsDone;

        public bool Is_Done
        {
            get { return IsDone; }
            set { IsDone = value; }
        }


        private string Event_Info;

        public string event_info
        {
            get { return Event_Info; }
            set { Event_Info = value; }
        }

    }
}
