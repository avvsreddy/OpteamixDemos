using System.Xml.Linq;

namespace LinqToXMLDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 
            // load xml doc
            XDocument xml = XDocument.Load("XMLFile1.xml");

            // Linq to XML Query: to get all titles from xml then display

            var bookTitles = from dsfsdfdf in xml.Descendants("title")
                             select dsfsdfdf.Value;

            // Get all computer book titles

            var bookTitles2 = from bk in xml.Descendants("book")
                              where bk?.Element("genre")?.Value == "Fantasy"
                              select bk?.Element("title")?.Value;

            //foreach (var item in bookTitles2)
            //{
            //    Console.WriteLine(item);
            //}

            // get total worth of all books
            var totalAmount = (from price in xml.Descendants("price")
                              select double.Parse(price.Value)).Sum();

            Console.WriteLine(totalAmount);

            //string data = "sdfsdfsdf";
            //if(data != null)
            //    Console.WriteLine(data.Length);

            //Console.WriteLine(data?.Length);


            // Extract all title and author into new xml document

        }
    }
}
