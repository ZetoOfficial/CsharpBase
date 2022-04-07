using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Journal: PublishingOffice
    {
        string journalName;
        public string JournalName
        {
            get { return journalName; }
            set { journalName = value; }
        }
        public Journal():base()
        {
            JournalName = "Noname Journal";
        }
        public Journal(string pn, string jn): base(pn)
        {
            JournalName = jn;
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Название журнала: {0}",JournalName);
        }
    }
}
