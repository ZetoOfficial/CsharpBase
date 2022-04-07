using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Article : Section
    {
        string articleName;
        string articleAuthor;
        public string ArticleName
        {
            get { return articleName; }
            set { articleName = value; }
        }
        public string ArticleAuthor
        {
            get { return articleAuthor; }
            set { articleAuthor = value; }
        }
        public Article() : base()
        {
            ArticleName = "Noname Article";
            ArticleAuthor = "Noname Author";
        }
        public Article(string pn, string jn, string sn, string an, string aun) : base(pn, jn, sn)
        {
            ArticleName = an;
            ArticleAuthor = aun;
        }
        public new void Print()
        {
            base.Print();
            Console.WriteLine("Название статьи: {0}", ArticleName);
            Console.WriteLine("Автор: {0}", ArticleAuthor);
        }

        public void Method1()
        {
            Console.WriteLine("Это метод Method1");
        }
        public void Method2()
        {
            ArticleName += "_1";
            Console.WriteLine("Это метод Method2");
        }
    }
}
