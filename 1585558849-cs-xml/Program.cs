using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SLAM4TRUC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> biblio = new List<Book>();

            Publisher eyrolles = new Publisher() { name = "Eyrolles", place = "Paris" };
            Publisher microsoft = new Publisher() { name = "Microsoft Press", place = "Paris" };

            Person bernadac = new Person() { firstname = "Jean-Christophe", lastname = "Bernadac" };
            Person knab = new Person() { firstname = "François", lastname = "Knab" };
            Person michard = new Person() { firstname = "Alain", lastname = "Michard" };
            Person pardi = new Person() { firstname = "William J.", lastname = "Pardi" };

            Person guerin = new Person()
            {
                firstname = "James",
                lastname = "Guérin",
                prefix = "adapté de l'anglais par"
            };

            Book book1 = new Book()
            {
                isbn = "9782212090819",
                lang = "fr",
                subject = "applications",
                authors = new List<Person> { bernadac, knab },
                title = "Construire une application XML",
                publisher = eyrolles,
                datepub = 1999
            };
            biblio.Add(book1);

            Book book2 = new Book()
            {
                isbn = "9782212090529",
                lang = "fr",
                subject = "général",
                authors = new List<Person> { michard },
                title = "XML, Langage et Applications",
                publisher = eyrolles,
                datepub = 1998
            };
            biblio.Add(book2);

            Book book3 = new Book()
            {
                isbn = "9782840825685",
                lang = "fr",
                subject = "applications",
                authors = new List<Person> { pardi },
                translator = guerin,
                title = "XML en Action",
                publisher = microsoft,
                datepub = 1999
            };
            biblio.Add(book3);

            XmlSerializer xs = new XmlSerializer(typeof(List<Book>), new XmlRootAttribute("Biblio"));
            using (StreamWriter wr = new StreamWriter("truc.xml"))
            {
                xs.Serialize(wr, biblio);
            }
        }
    }

    public class Book
    {
        [XmlAttribute("ISBN")]
        public String isbn;

        [XmlAttribute("LANG")]
        public String lang;

        [XmlAttribute("SUBJECT")]
        public String subject;

        [XmlElement("AUTHOR")]
        public List<Person> authors;

        [XmlElement("TRANSLATOR")]
        public Person translator;

        [XmlElement("TITLE")]
        public String title;

        [XmlElement("PUBLISHER")]
        public Publisher publisher;

        [XmlElement("DATEPUB")]
        public int datepub;

        public Book() { }
    }

    public class Person
    {
        [XmlElement("FIRSTNAME")]
        public String firstname;

        [XmlElement("LASTNAME")]
        public String lastname;

        [XmlAttribute("PREFIX")]
        public String prefix;

        public Person() { }
    }

    public class Publisher
    {
        [XmlElement("NAME")]
        public String name;

        [XmlElement("PLACE")]
        public String place;

        public Publisher() { }
    }
}
