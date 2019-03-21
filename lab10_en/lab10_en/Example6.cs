using System;
using System.Collections.Generic;
using System.Threading;
namespace lab10_en
{
    class MoveEventArgs : EventArgs
    {
        public readonly int move;
        public MoveEventArgs(int m) { move = m; }
    }
    class Race
    {
        private int distance;
        private int place = 0;
        private Dictionary<string, int> position = new Dictionary<string, int>();
        private WaitHandle[] wh;
        private EventHandler run = null;

        public event EventHandler Run
        {
            add
            {
                run += value;
                var d = value.Target as Dog;
                position[d.Name] = 0;
                d.Move += Move;
            }
            remove
            {
                run -= value;
            }
        }

        public Race(int dist) { distance = dist; }

        public void Move(object sender, MoveEventArgs e)
        {
            var d = sender as Dog;
            position[d.Name] += e.move;
            if (position[d.Name] < distance)
                Console.WriteLine($" Dog {d.Name} ran {position[d.Name]} meters");
            else
            {
                Console.WriteLine($" Dog {d.Name} finished race on {++place} place");
                d.Stop();
            }
        }

        public void Start()
        {
            Console.WriteLine("\n*** The race has begun ***\n");
            wh = new WaitHandle[run.GetInvocationList().Length];
            int i = 0;
            foreach (EventHandler eh in run.GetInvocationList())
                wh[i++] = eh.BeginInvoke(this, EventArgs.Empty, null, null).AsyncWaitHandle;
            WaitHandle.WaitAll(wh);
            Console.WriteLine("\n***The race has ended ***\n");
        }
    }

    class Dog
    {
        private static Random random = new Random();

        private bool isRunning;

        public readonly string Name;

        public event EventHandler<MoveEventArgs> Move;

        public Dog(string n) { Name = n; }

        public void Run(object sender, EventArgs e)
        {
            isRunning = true;
            Console.WriteLine($" Dog {Name} has started");
            while (isRunning)
            {
                Thread.Sleep(random.Next(2000));
                Move(this, new MoveEventArgs(random.Next(1, 9)));
            }
        }
        public void Stop()
        {
            isRunning = false;
        }
    }

    class Example6
    {
        public static void Main()
        {
            Race race = new Race(20);
            Dog d1 = new Dog("Azor");
            Dog d2 = new Dog("Burek");
            Dog d3 = new Dog("Reksio");
            Dog d4 = new Dog("Szarik");
            race.Run += d1.Run;
            race.Run += d2.Run;
            race.Run += d3.Run;
            race.Run += d4.Run;
            race.Start();
        }
    }
}