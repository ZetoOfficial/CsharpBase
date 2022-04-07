using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Section : Journal
    {
        string sectionName;
        public string SectionName
        {
            get { return sectionName; }
            set { sectionName = value; }
        }
        public Section() : base()
        {
            SectionName = "Noname Section";
        }
        public Section(string pn, string jn, string sn) : base(pn, jn)
        {
            SectionName = sn;
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Название раздела: {0}", SectionName);
        }
    }
}
