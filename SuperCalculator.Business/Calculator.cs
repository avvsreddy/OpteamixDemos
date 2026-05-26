namespace SuperCalculator.Business
{
    public class Calculator
    {
        public int Add(int a, int b)
        {

            // Rule 1: only +ve integers are allowed
            if(a < 0 || b < 0) 
                throw new NegativeInputException("Negative integers are not allowed");
            // Rule 2: only non-zero integers are allowed
            if(a == 0 || b == 0)
                throw new ZeroInputException("Zero is not allowed");
            // Rule 3: only even numbered integers are allowed
            if(a % 2 != 0 || b % 2 != 0)
                throw new OddInputException("Only even integers are allowed");
            // Rule 4: anything else is not allowed. throw an exception

            return a + b;
        }

        //public int Subtract(int a, int b)
        //{
        //    return a + b;
        //}
    }
}
