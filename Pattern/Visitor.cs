using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface ICrediCard
    {
        string GetName();
        void Accept(IOfferVisitor visitor);
    }

    public interface IOfferVisitor
    {
        void Visit(BronzeCreditCard bronze);
        void Visit(SilverCreditCard silver);
        void Visit(GoldCreditCard gold);
    }

    public class BronzeCreditCard : ICrediCard
    {
        public int Price { get; set; }
        public BronzeCreditCard(int price)
        {
            this.Price = price;
        }

        public void Accept(IOfferVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetPrice()
        {
            return Price;
        }

        public string GetName()
        {
            return "Bronze";
        }
    }

    public class SilverCreditCard : ICrediCard
    {
        public int Price { get; set; }
        public SilverCreditCard(int price)
        {
            this.Price = price;
        }

        public void Accept(IOfferVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetPrice()
        {
            return Price;
        }

        public string GetName()
        {
            return "Silver";
        }
    }

    public class GoldCreditCard : ICrediCard
    {
        public int Price { get; set; }
        public GoldCreditCard(int price)
        {
            this.Price = price;
        }

        public void Accept(IOfferVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int GetPrice()
        {
            return Price;
        }

        public string GetName()
        {
            return "Gold";
        }
    }

    public class HotelOfferVisitor : IOfferVisitor
    {
        public void Visit(BronzeCreditCard bronze)
        {
            Console.WriteLine("HotelOffer Bronze - "+ Convert.ToInt32(bronze.GetPrice() + 100));
        }

        public void Visit(GoldCreditCard gold)
        {
            Console.WriteLine("HotelOffer Gold - "+ Convert.ToInt32(gold.GetPrice() + 101));
        }

        public void Visit(SilverCreditCard silver)
        {
            Console.WriteLine("HotelOffer Silver - "+ Convert.ToInt32(silver.GetPrice() + 102));
        }
    }

    public class StayOfferVisitor : IOfferVisitor
    {
        public void Visit(BronzeCreditCard bronze)
        {
            Console.WriteLine("StayOffer Bronze - " + Convert.ToInt32(bronze.GetPrice() + 200));
        }

        public void Visit(GoldCreditCard gold)
        {
            Console.WriteLine("StayOffer Gold - " + Convert.ToInt32(gold.GetPrice() + 201));
        }

        public void Visit(SilverCreditCard silver)
        {
            Console.WriteLine("StayOffer Silver - " + Convert.ToInt32(silver.GetPrice() + 202));
        }
    }

    internal class Visitor
    {
        public Visitor()
        {
            HotelOfferVisitor hotelOfferVisitor = new HotelOfferVisitor();
            StayOfferVisitor stayOfferVisitor = new StayOfferVisitor();

            ICrediCard bronze = new BronzeCreditCard(1);
            ICrediCard silver = new SilverCreditCard(2);
            ICrediCard gold = new GoldCreditCard(3);

            bronze.Accept(hotelOfferVisitor);
            silver.Accept(hotelOfferVisitor);
            gold.Accept(hotelOfferVisitor);

            bronze.Accept(stayOfferVisitor);
            silver.Accept(stayOfferVisitor);
            gold.Accept(stayOfferVisitor);
        }
    }
}
