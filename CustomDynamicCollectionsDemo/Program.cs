namespace CustomDynamicCollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // need to store many int numbers, then display them
            // client dev
            var numbers = new DynamicCollection<int>();
            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);
            numbers.Add(50);
            numbers.Add(60); // this should trigger resizing of the internal array  
            numbers.Add(70);
            numbers.Add(80);
            numbers.Add(90);
            numbers.Add(100);
            numbers.Add(110);

            for (int i = 0; i < numbers.Size; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }

            // store many names, then display them
            var names = new DynamicCollection<string>();
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Charlie");
            names.Add("David");
            names.Add("Eve");
            names.Add("Frank"); // this should trigger resizing of the internal array

            for (int i = 0; i < names.Size; i++)
            {
                Console.WriteLine(names.Get(i));
            }

        }
    }

    class DynamicCollection<T>
    {
        private T[] data = new T[5];
        private int index = 0;
        public void Add(T input)
        {
            // add number to collection
            if (index < data.Length) // have space
            {
                data[index++] = input;
            }
            else // need to resize array
            {
                Console.WriteLine("Resizing...");
                T[] newData = new T[data.Length * 2];
                //Array.Copy(_numbers, newNumbers, _numbers.Length);
                //_numbers = newNumbers;
                Array.Resize(ref data, data.Length * 2);

                data[index++] = input;
            }
        }

        public T Get(int index)
        {
            // return number at index
            return data[index];
        }

        public int Size
        {
            get { return index; }
        }
    }

    class DynamicStringCollection
    {
        private string[] _strings = new string[5];
        private int index = 0;
        public void Add(string data)
        {
            // add number to collection
            if (index < _strings.Length) // have space
            {
                _strings[index++] = data;
            }
            else // need to resize array
            {
                Console.WriteLine("Resizing...");
                string[] newStrings = new string[_strings.Length * 2];
                //Array.Copy(_numbers, newNumbers, _numbers.Length);
                //_numbers = newNumbers;
                Array.Resize(ref _strings, _strings.Length * 2);

                _strings[index++] = data;
            }
        }

        public string Get(int index)
        {
            // return number at index
            return _strings[index];
        }

        public int Size
        {
            get { return index; }
        }
    }
}
