
namespace cs16
{
    internal class Program
    {
        //public delegate double MyDelegate(double a, double b);
        public delegate bool Predicate<in T>(T x);

        public delegate void Message(string str);

        public delegate double Operation(double a, double b);
        static void Main()
        {
            while (true)
            {
                Console.Write("Choose number of task(1-3): ");
                int.TryParse(Console.ReadLine(), out int task);
                if (task == 0) break;

                switch (task)
                {
                    case 1:
                        Message message;
                        message = delegate (string a)
                        {
                            Console.WriteLine(a);
                        };
                        message("result");
                        message = (str) => Console.WriteLine(str);
                        message("New line");

                        break;
                    case 2:
                        var operat = new Task2();

                        Operation del = operat.Add;
                        Console.WriteLine("Add: " + del(7.5, 7.1).ToString());
                        del = operat.Multi;
                        Console.WriteLine("Multi: " + del(7.5, 7.1).ToString());
                        del = operat.Subtrac;
                        Console.WriteLine("Sub: " + del(7.5, 7.1).ToString());
                        break;
                    case 3:
                        Predicate<int> isPair = (x => x % 2 == 0);
                        Console.WriteLine("Pair: " + isPair(4));
                        Console.WriteLine("Pair: " + isPair(3));


                        Predicate<int> isUnPair = (x => x % 2 != 0);
                        Console.WriteLine("Unpair: " + isUnPair(4));
                        Console.WriteLine("Unpair: " + isUnPair(3));


                        Predicate<int> isPrime = delegate (int x)
                        {
                            bool result = true;
                            if (x > 1)
                            {
                                for (int i = 2; i < x; i++)
                                {
                                    if (x % i == 0)
                                    {
                                        result = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                result = false;
                            }
                            return result;
                        };
                        Console.WriteLine("Prime: " + isPrime(4));
                        Console.WriteLine("Prime: " + isPrime(3));


                        Predicate<int> isFibonacci = (x => 
                            Math.Sqrt(5 * Math.Pow(x, 2) - 4) % 1 == 0 || Math.Sqrt(5 * Math.Pow(x, 2) + 4) % 1 == 0);
                        Console.WriteLine("Fibonacci: " + isFibonacci(4));
                        Console.WriteLine("Fibonacci: " + isFibonacci(3));

                        break;
                }
            }
        }
        public static void Show(string message)
        {
            Console.WriteLine("Console Message: " + message);
        }

        //static int Add(int a, int b) =>
        //    a + b;

        //static double Add(double a, double b) =>
        //    a + b;

        //static string Add(string a, string b) =>
        //    a + b;

        //static double Multi(double a, double b) =>
        //    a * b;

        //static void Show(MyDelegate del, string operation) =>
        //    Console.WriteLine(operation + del(2.5, 3.1).ToString());

    }
}
 //Predicate<int> isPositive = (x => x > 0);
            //Console.WriteLine(isPositive(4));
            //Console.WriteLine(isPositive(-3));

            //MyDelegate del = Add;
            //Show(del, "Add: ");
            //del = Multi;
            //Show(del, "Multi: ");

            //del = delegate (double a, double b)
            //{
            //    return a - b;
            //};
            //Show(del, "Sub: ");

            //del = (x, y) => x / y;
            //Show(del, "Divin: ");
            //Console.WriteLine(Add(5, 6));
            //Console.WriteLine(del(7.5, 7.5));
            //Console.WriteLine(Add("res", "ult"));