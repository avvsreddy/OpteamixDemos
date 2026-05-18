using System.Configuration;

namespace DesignPatterns.POS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessBill processBill = new ProcessBill();
            processBill.Process();

        }
    }

    class TaxCalculatorFactory // make this class a singleton to ensure that only one instance of the factory is created and used throughout the application
    {
        public static readonly TaxCalculatorFactory Instance = new TaxCalculatorFactory();
        //public static TaxCalculatorFactory GetInstance()
        //{
        //    lock (new object())
        //    {
        //        if (instance == null)
        //        {
        //            instance = new TaxCalculatorFactory();
        //        }
        //    }
        //    return instance;
        //}


        private TaxCalculatorFactory()
        {

        }
        public virtual ITaxCalculator GetTaxCalculator()
        {
            // using reflection/RTTI to get the tax calculator based on the configuration or the location of the store
            // Read the configuration file to get the calculator type
            string calcType = ConfigurationManager.AppSettings["TaxCalculator"];
            // create the tax calculator based on the type dynamically
            Type theType = Type.GetType(calcType);
            // create an instance of the tax calculator
            return (ITaxCalculator)Activator.CreateInstance(theType);

            //return new TNTaxCalculator();
        }
    }

    class ProcessBill
    {
        public void Process()
        {
            // Process the bill
            // Read the barcode,
            // calculate the total,
            // apply discounts, etc.
            double total = 14500.00;
            // Calculate the Tax
            //TaxCalculator taxCalculator = new TaxCalculator();
            //TaxCalculatorFactory taxCalculatorFactory = new TaxCalculatorFactory();
            //Console.WriteLine(taxCalculatorFactory.GetHashCode());
            //TaxCalculatorFactory taxCalculatorFactory2 = new TaxCalculatorFactory();
            //Console.WriteLine(taxCalculatorFactory2.GetHashCode());

            TaxCalculatorFactory f1 = TaxCalculatorFactory.Instance;
            TaxCalculatorFactory f2 = TaxCalculatorFactory.Instance;
            Console.WriteLine($"Factory 1 Hash Code: {f1.GetHashCode()}");
            Console.WriteLine($"Factory 2 Hash Code: {f2.GetHashCode()}");

            ITaxCalculator taxCalculator = TaxCalculatorFactory.Instance.GetTaxCalculator();
            double tax = taxCalculator.CalculateTax(total);
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Tax: {tax}");
        }
    }

    interface ITaxCalculator
    {
        double CalculateTax(double total);
    }


    class KATaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double total)
        {
            Console.WriteLine("Using KA Tax Calculator");
            // Calculate the tax based on the total
            int es = 100;
            int bs = 10;
            int nd = 10;
            int cgst = 50;
            int sgst = 50;
            double tax = es + bs + nd + cgst + sgst;
            return tax;
        }
    }

    class TNTaxCalculator : ITaxCalculator
    {
        public double CalculateTax(double total)
        {
            Console.WriteLine("Using TN Tax Calculator");
            // Calculate the tax based on the total
            int es = 200;
            //int bs = 20;
            int nd = 20;
            int cgst = 100;
            int sgst = 100;
            double tax = es + nd + cgst + sgst;
            return tax;
        }
    }

    class USTaxCalculator
    {
       public float ComputeTax(float total)
        {
            Console.WriteLine("Using US Tax Calculator");
            // Calculate the tax based on the total
            float tax = total * 0.07f; // Assuming a flat 7% tax rate
            return tax;
        }
    }

    class USTaxCalculatorAdaptor : ITaxCalculator
    {
        public double CalculateTax(double total)
        {
            USTaxCalculator usTaxCalculator = new USTaxCalculator();
            float tax = usTaxCalculator.ComputeTax((float)total);
            return tax;
        }
    }
}
