namespace CustomDynamicCollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // need to store many int numbers, then display them
            // client dev
            var numbers = new DynamicIntCollection();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);
            numbers.Add(50);
            numbers.Add(60); // this should trigger resizing of the internal array  

            for (int i = 0; i < numbers.Size; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }


        }
    }

    class DynamicIntCollection
    {
        private int[] _numbers = new int[5];
        private int index = 0;
        public void Add(int number)
        {
            // add number to collection
            if (index < _numbers.Length) // have space
            {
                _numbers[index++] = number;
            }
            else // need to resize array
            {
                Console.WriteLine("Resizing...");
                int[] newNumbers = new int[_numbers.Length * 2];
                Array.Copy(_numbers, newNumbers, _numbers.Length);
                _numbers = newNumbers;
                _numbers[index++] = number;
            }
        }

        public int Get(int index)
        {
            // return number at index
            return _numbers[index];
        }

        public int Size
        {
            get { return index; }
        }
    }
}
