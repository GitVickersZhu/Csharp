using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8En_tutorial
{
    class Program
    {
        struct BasicStruct
        {
            public int Property { get; set; }
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        //without Generic method, we would have to 
        //write the same code for every type we want to swap
        public static void SwapInt(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        public static void SwapDouble(ref double a, ref double b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        public static void SwapString(ref string a, ref string b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }

        static void Main(string[] args)
        {
            #region tutorial
            //Generics first example
            int a = 5;
            int b = 10;
            Console.WriteLine("Before swapping: a = {0}, b = {1}", a, b);
            Swap(ref a, ref b);
            Console.WriteLine("After swapping: a = {0}, b = {1}", a, b);

            //Generics second example
            GenericClassExampleA<int> example1 = new GenericClassExampleA<int>(10);
            example1.genericMethod(90);

            GenericClassExampleA<Car> example2 = new GenericClassExampleA<Car>(new Car { MaxSpeed = 150, Brand = "Opel" });
            example2.genericMethod(new Car { MaxSpeed = 200, Brand = "Ford" });

            MyDerivedClassA myDerivedClassA = new MyDerivedClassA("value");
            myDerivedClassA.genericMethod("argument");
            //Collections

            //this one is okay because Car is class
            GenericClassExampleB<Car> genericClassExampleB = new GenericClassExampleB<Car>();

            //next line will give compile error because BasicStruct is not a reference type
            //GenericClassExampleB<BasicStruct> error = new GenericClassExampleB<BasicStruct>();

            //Collections
            //List<T>
            List<Car> carList = new List<Car>();
            carList.Add(new Car { Brand = "Opel", MaxSpeed = 170 });
            carList.Add(new Car { Brand = "Ford", MaxSpeed = 190 });
            carList.Add(new Car { Brand = "Nissan", MaxSpeed = 180 });
            carList.Add(new Car { Brand = "BMW", MaxSpeed = 250 });
            carList.Add(new Car { Brand = "Mercedes", MaxSpeed = 210 });
            carList.Add(new Car { Brand = "Mazda", MaxSpeed = 200 });

            Car c = carList[0];
            Car c1 = carList[1];
            Swap(ref c, ref c1);

            Console.WriteLine(carList[2].ToString());
            carList.Insert(2, new Car { Brand = "Porsche", MaxSpeed = 300 });
            carList.RemoveAt(0);

            //Queue<T>
            Queue<Car> queue = new Queue<Car>();
            foreach (var car in carList)
                queue.Enqueue(car);
            var peek = queue.Peek();
            Console.WriteLine(peek.ToString());
            var removedCar = queue.Dequeue();
            Console.WriteLine("Removed from queue: " + removedCar.ToString());
            Console.WriteLine(queue.Count);

            //Stack<T>
            Stack<Car> stack = new Stack<Car>();
            foreach (var car in carList)
                stack.Push(car);
            peek = stack.Peek();
            Console.WriteLine(peek.ToString());
            removedCar = stack.Pop();
            Console.WriteLine("Removed from stack: " + removedCar.ToString());
            Console.WriteLine(stack.Count);

            Dictionary<Driver, Car> dictionary = new Dictionary<Driver, Car>();
            Driver first = new Driver { Name = "John", LastName = "Smith", Age = 30 };
            Driver second = new Driver { Name = "George", LastName = "Bool", Age = 50 };
            Driver third = new Driver { Name = "Ricky", LastName = "Martin", Age = 55 };

            dictionary.Add(first, carList[0]);
            //next line would throw exception because there already exists given key
            //dictionary.Add(first, carList[1]);
            dictionary.Add(second, carList[1]);
            dictionary.Add(third, carList[3]);

            foreach (var key in dictionary.Keys)
                Console.WriteLine(key.ToString() + " drives: " + dictionary[key].ToString());

            Console.WriteLine();

            if (dictionary.ContainsKey(first))
                dictionary[first] = carList[4];
            Console.WriteLine(first + " drives: " + dictionary[first] + "\n");

            //Extension methods
            string str = "Advanced programming";
            Console.WriteLine(str);
            str = str.DuplicateCharacters();
            Console.WriteLine(str);
            int k = 100;
            Console.WriteLine(k.IsGreaterThan(10));
            Console.WriteLine(k.IsGreaterThan(110));

            //Delegates and lambda expressions

            //In C# a lambda is a function that uses clear and short syntax.
            //An example. A common place to use lambdas is with List. Here we use FindIndex, which receives a Predicate method. We specify this as a lambda expression.
            //we want to find cars which max speed is greater or equal 200km/h
            var fastCars = carList.Find(x => x.MaxSpeed >= 200);

            //The => operator can be read as "goes to." It is always used when declaring a lambda expression.

            //Some examples:

            // Use implicitly-typed lambda expression. Assign it to a Func instance.
            Func<int, int> func1 = x => x + 1;

            // Use lambda expression with statement body.
            Func<int, int> func2 = x => { return x + 1; };

            // Use formal parameters with expression body.
            Func<int, int> func3 = (int x) => x + 1;

            // Use parameters with a statement body.
            Func<int, int> func4 = (int x) => { return x + 1; };

            // Use multiple parameters.
            Func<int, int, int> func5 = (x, y) => x * y;

            // Use no parameters in a lambda expression.
            Action<string> func6 = x => Console.WriteLine(x);

            // Use delegate method expression.
            Func<int, int> func7 = delegate (int x) { return x + 1; };

            // Use delegate expression with no parameter list.
            Func<int> func8 = delegate { return 1 + 1; };

            // Invoke each of the lambda expressions and delegates we created.
            // The methods above are executed.
            // we can call any of those methods in two ways:
            int ret = func1(1);
            //or 
            ret = func1.Invoke(1);

            Console.WriteLine(func1.Invoke(1));
            Console.WriteLine(func2.Invoke(1));
            Console.WriteLine(func3.Invoke(1));
            Console.WriteLine(func4.Invoke(1));
            Console.WriteLine(func5.Invoke(2, 2));
            func6.Invoke("hello world");
            Console.WriteLine(func7.Invoke(1));
            Console.WriteLine(func8.Invoke());
            #endregion 

            //1.Generics
            ExpandingArray<int> arr = new ExpandingArray<int>();
            for (int i = 0; i < 4; i++)
                arr[i] = i;
            Console.WriteLine(arr.ToString());
            Console.WriteLine(arr.GetMaxElement());
            arr[15] = 90;
            Console.WriteLine(arr.GetMaxElement());
            Console.WriteLine(arr.ToString());

            //2.Extension Methods
            for (int i = 0; i < arr.Length; i++)
                arr[i] = 100;
            arr[7] = 2;
            Console.WriteLine(arr.GetMinValue());
            ExpandingArray<string> expandingArray = new ExpandingArray<string>();
            expandingArray[0] = "AAAAA";
            expandingArray[1] = "BBBBB";
            expandingArray[2] = "CCCCC";
            expandingArray[3] = "DDDDD";
            Console.WriteLine(expandingArray.ConcatenateArrat());

            //3.
            //here create list of strings and dictionary to obtain occurences of letters in strings
            //use words: determine,hope,deck,feel,radio,relation,misplace,gene,custody,star,executrix,psychology,news




            //4.

            List <string> words = new List<string>();
            words.Add("House");
            words.Add("Car");
            words.Add("Driver");
            words.Add("This");
            words.Add("Is");
            words.Add("Awesome");
            words.Add("Iword");
            words.Add("Iphone");

            while (true) { }
        }

    }
}
