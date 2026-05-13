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

            ide.Java = java;
            ide.CS = cs;
            ide.C = c;

            ide.Work();
        }
    }

    class IDE
    {
        public LangC C { get; set; }
        public LangCSharp CS { get; set; }
        public LangJava Java { get; set; }
        public SomeLang SL { get; set; }

        public void Work() 
        {
            Console.WriteLine(C.GetName());
            Console.WriteLine(C.GetParadigm());
            Console.WriteLine(C.GetUnit());
            Console.WriteLine("-------------");
            Console.WriteLine(CS.GetName());
            Console.WriteLine(CS.GetParadigm());
            Console.WriteLine(CS.GetUnit());
            Console.WriteLine("-------------");
            Console.WriteLine(Java.GetName());
            Console.WriteLine(Java.GetParadigm());
            Console.WriteLine(Java.GetUnit());
            Console.WriteLine("-------------");

        }

    }


    class SomeLang
    {
        public void SomeMethod() { }
    }

    class LangCSharp
    {
        public string GetParadigm()
        {
            return "Object Oriented";
        }
        public string GetUnit()
        {
            return "Class";
        }
        public string GetName()
        {
            return "C Sharp";
        }
    }
    class LangJava
    {
        public string GetParadigm()
        {
            return "Object Oriented";
        }
        public string GetUnit()
        {
            return "Class";
        }
        public string GetName()
        {
            return "Java";
        }
    }
    class LangC
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
