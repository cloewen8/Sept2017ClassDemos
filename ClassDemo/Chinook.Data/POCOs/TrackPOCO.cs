using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.POCOs
{
    public class TrackPOCO
    {
        public string Name { get; set; }

        public int Milliseconds { get; set; }

        public string Length
        {
            get
            {
                int minutes = Milliseconds / 60000;
                int seconds = (Milliseconds % 60000) / 1000;
                return string.Format("{0}:{1:00}",
                    minutes,
                    seconds);
            }
        }
    }
}
