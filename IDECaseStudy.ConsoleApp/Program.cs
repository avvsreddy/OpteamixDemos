namespace IDECaseStudy.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            LangC c = new LangC();
            LangCSharp cs = new LangCSharp();
            LangJava java = new LangJava();
            SomeLang sl = new SomeLang();

            ide.Languages.Add(c);
            ide.Languages.Add(cs);
            ide.Languages.Add(java);
            ide.Languages.Add(sl);

            //ILanguage il = new LangCSharp();
            //il = new LangJava();

            //ide.Java = java;
            //ide.CS = cs;
            //ide.C = c;

            ide.Work();
        }
    }

    class IDE
    {

        //public List<ILanguage> languages = new List<ILanguage>();
        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();
        //public ILanguage C { get; set; }
        //public ILanguage CS { get; set; }
        //public ILanguage Java { get; set; }
        //public SomeLang SL { get; set; }

        public void Work() 
        {
            foreach (ILanguage lang in Languages)
            {
                Console.WriteLine(lang.GetName());
                Console.WriteLine(lang.GetParadigm());
                Console.WriteLine(lang.GetUnit());
                Console.WriteLine("-------------");
            }
            //Console.WriteLine(CS.GetName());
            //Console.WriteLine(CS.GetParadigm());
            //Console.WriteLine(CS.GetUnit());
            //Console.WriteLine("-------------");
            //Console.WriteLine(Java.GetName());
            //Console.WriteLine(Java.GetParadigm());
            //Console.WriteLine(Java.GetUnit());
            //Console.WriteLine("-------------");

        }

    }


    public interface ILanguage
    {
        string GetParadigm();
        string GetUnit();
        string GetName();
    }


    abstract public class OOLanguage : ILanguage
    {
        abstract public string GetName();
        //{
        //    throw new NotImplementedException();
        //}

        public string GetParadigm()
        {
            return "OO Language ";
        }

        public string GetUnit()
        {
            return "Class";
        }
    }

    class SomeLang : ILanguage
    {
        public string GetName()
        {
            return "Some Language";
        }

        public string GetParadigm()
        {
            return "Some Paradigm";
        }

        public string GetUnit()
        {
            return "Some Unit";
        }
    }

    class LangCSharp : OOLanguage   // IS-A - Realization
    {
        //public string GetParadigm()
        //{
        //    return "Object Oriented";
        //}
        //public string GetUnit()
        //{
        //    return "Class";
        //}
        public override string GetName()
        {
            return "C Sharp";
        }
    }
    class LangJava :OOLanguage
    {
        //public string GetParadigm()
        //{
        //    return "Object Oriented";
        //}
        //public string GetUnit()
        //{
        //    return "Class";
        //}
        public override string GetName()
        {
            return "Java";
        }
    }
    class LangC : ILanguage
    {
        public string GetParadigm()
        {
            return "Procedural";
        }
        public string GetUnit()
        {
            return "Function";
        }
        public string GetName()
        {
            return "C";
        }
    }
}
