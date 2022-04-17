using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization; // нужно для сериализации объектов и сохранения в файлы

namespace Lab2
{
    [XmlInclude(typeof(Journal)), XmlInclude(typeof(Section)), XmlInclude(typeof(Article))]
    // указываются все дочерние классы, которые будут сериализовываться и десериализовываться
    public class PublishingOffice
    {
        string publishingName;
        public string PublishingName
        {
            get { return publishingName; }
            set { publishingName = value; }
        }
        public PublishingOffice()
        {
            PublishingName = "Noname Publishing Office";
        }
        public PublishingOffice(string pn)
        {
            PublishingName = pn;
        }
        public void Print()
        {
            Console.WriteLine("Название издательства: {0}", PublishingName);
        }
    }
}
