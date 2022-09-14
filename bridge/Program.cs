using System;

namespace bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Payment payment = new NetbankingPayment();
            payment.payment = new HDFCpayment();
            payment.Makepayment();
            Console.ReadKey();
        }
    }

    interface IPayment
    {
        void ProcessPayment(string paymentSystem);
    }

    abstract class Payment
    {
        public IPayment payment;
        public abstract void Makepayment();
    }

    class NetbankingPayment : Payment
    {
        public override void Makepayment()
        {
            payment.ProcessPayment("Net banking payment");
        }
    }

    class HDFCpayment : IPayment
    {
        public void ProcessPayment(string paymentSystem)
        {
            System.Console.WriteLine("HDFC payment");
        }
    }

    class IDBIPayment : IPayment
    {
        public void ProcessPayment(string paymentSystem)
        {
            System.Console.WriteLine("IDBI Payment");
        }
    }
}
