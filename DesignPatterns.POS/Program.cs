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
            KATaxCalculator taxCalculator = new KATaxCalculator();
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


}
