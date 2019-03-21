using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Events
    {
        public class CustomEventArgs: EventArgs
        {
            public CustomEventArgs(string s)
            {
                message = s;
            }
            private string message;
            public string Message
            {
                get { return message; }
                set { message = value; }
            }
        }
        class Publisher
        {
            public event EventHandler<CustomEventArgs> RaiseCutomEvent;
            public void DoSth()
            {
                OnRaiseCustomEvent(new CustomEventArgs("Did sth"));
            }

            protected void OnRaiseCustomEvent(CustomEventArgs e)
            {
                EventHandler<CustomEventArgs> handler = RaiseCutomEvent;
                if(handler != null)
                {
                    e.Message += String.Format(" at {0}", DateTime.Now.ToString());
                    handler(this, e);
                }
            }
        }
        class Subscriber
        {
            private string id;
            public Subscriber(string ID, Publisher pub)
            {
                id = ID;
                pub.RaiseCutomEvent += HandlerCustomEvent;
            }

            void HandlerCustomEvent(object sender, CustomEventArgs e)
            {
                Console.WriteLine(id + " Received this message {0}", e.Message);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Publisher pub = new Publisher();
                Subscriber sub1 = new Subscriber("sub1", pub);
                Subscriber sub2 = new Subscriber("sub2", pub);

                // Call the method that raises the event.
                pub.DoSth();

                // Keep the console window open
                Console.WriteLine("Press Enter to close this window.");
                Console.ReadLine();

            }
        }


    }
}
