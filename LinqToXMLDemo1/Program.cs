using System.Xml.Linq;

namespace LinqToXMLDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };
            
            // Get all short words (<=3)

            // load xml doc into memory
            XDocument xml = XDocument.Load("XMLFile1.xml");

            // Linq to Objects
            //var shortWords = from word in words
            //                 where word.Length <= 3
            //                 select word;

            // Linq to XML
            var shortWords = from word in xml.Descendants("word")
                             where word.Value.Length <= 3
                             select word.Value;

            // Display
            foreach (var word in shortWords) { Console.WriteLine(word); }


        }
    }
}
