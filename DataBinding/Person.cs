using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    public class Person : INotifyPropertyChanged
    {
        private int alter;

        public string Name { get; set; }
        public int Alter 
        { 
            get => alter;
            set
            {
                alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public List<DateTime> WichtigeTage { get; set; } = new List<DateTime>()
        {
            DateTime.Now,
            new DateTime(2002, 2, 1),
            new DateTime(2023, 5, 12)
        };

        public DateTime LastObject
        {
            get { return WichtigeTage.Last(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void UpdateGUI()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastObject)));
        }


        public override string ToString()
        {
            return this.Name + " (" + this.Alter + ")";
        }
    }
}
