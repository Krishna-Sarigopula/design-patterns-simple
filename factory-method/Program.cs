using System;

namespace factory_method
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditCard creditCard = new PlatinumFactory().MakeProduct();
            Console.WriteLine("Card Type : " + creditCard.GetCardType());
            Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());

            creditCard = new TitaniumFactory().MakeProduct();
            Console.WriteLine("Card Type : " + creditCard.GetCardType());
            Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
        }
    }

    interface ICreditCard
    {
        string GetCardType();
        int GetCreditLimit();
    }
    class Platinum : ICreditCard
    {
        public string GetCardType()
        {
            return "Platinum Plus";
        }
        public int GetCreditLimit()
        {
            return 35000;
        }
    }
    class Titanium : ICreditCard
    {
        public string GetCardType()
        {
            return "Titanium Edge";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
    }

    abstract class CreditCardFactory
    {
        public abstract ICreditCard MakeProduct();
    }

    class PlatinumFactory : CreditCardFactory
    {
        public override ICreditCard MakeProduct()
        {
            ICreditCard product = new Platinum();
            return product;
        }
    }
    class TitaniumFactory : CreditCardFactory
    {
        public override ICreditCard MakeProduct()
        {
            ICreditCard product = new Titanium();
            return product;
        }
    }
}
