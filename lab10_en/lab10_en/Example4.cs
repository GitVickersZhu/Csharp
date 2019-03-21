//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace lab10_en
//{
//    //From MSDN:
//    //An event in C# is a way for a class to provide notifications to clients of that class when some interesting thing happens to an object.
//    class Example4
//    {
//        public class TransactionEventArgs : EventArgs//继承自EventArgs的.net标准事件
//        {
//            public int TranactionAmount { get; set; }
//            public string TranactionType { get; set; }

//            public TransactionEventArgs(int amt, string type)
//            {
//                TranactionAmount = amt;
//                TranactionType = type;
//            }
//        }
//        public delegate void TransactionHandler(object sender, TransactionEventArgs e); // Delegate Definition 委托的定义
//        class Account
//        {
//            public event TransactionHandler TransactionMade; // Event Definition 事件的定义

//            public int BalanceAmount;

//            public Account(int amount)
//            {
//                BalanceAmount = amount;
//            }

//            public void Debit(int debitAmount)
//            {
//                if (debitAmount < BalanceAmount)
//                {
//                    BalanceAmount = BalanceAmount - debitAmount;
//                    TransactionEventArgs e = new TransactionEventArgs(debitAmount, "Debited");
//                    OnTransactionMade(e); // Debit transaction made
//                }
//            }

//            public void Credit(int creditAmount)
//            {
//                BalanceAmount = BalanceAmount + creditAmount;
//                TransactionEventArgs e = new TransactionEventArgs(creditAmount, "Credited");
//                OnTransactionMade(e); // Credit transaction made
//            }

//            protected virtual void OnTransactionMade(TransactionEventArgs e)
//            {
//                TransactionMade?.Invoke(this, e); // Raise the event 
//            }
//        }

//        private static void SendNotification(object sender, TransactionEventArgs e)
//        {
//            Console.WriteLine("Your Account is {0} for {1} ", e.TranactionType, e.TranactionAmount);
//        }

//        private static void Main()
//        {
//            Account MyAccount = new Account(10000);
//            MyAccount.TransactionMade += new TransactionHandler(SendNotification);
//            MyAccount.Credit(500);
//            Console.WriteLine("Your Current Balance is : " + MyAccount.BalanceAmount);
//            MyAccount.Debit(1500);
//            Console.WriteLine("Your Current Balance is : " + MyAccount.BalanceAmount);
//            Console.ReadKey();
//        }
//    }
//}
