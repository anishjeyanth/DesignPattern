using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public abstract class Game
    {
        public abstract void Warmup();
        public abstract void PlayGame();
        public abstract void Drinks();

        public void Play()
        {
            Warmup();
            PlayGame();
            Drinks();
            //we can add condition, and based on that methods will be executed
            //if(IsEven()) { PrintNo(); }
        }

        public virtual void Event()
        {
            Console.WriteLine("Event");
        }
    }

    public class Tennis : Game
    {
        public override void Drinks()
        {
            Console.WriteLine("Tennis Drinks");
        }

        public override void PlayGame()
        {
            Console.WriteLine("Tennis PlayGame");
        }

        public override void Warmup()
        {
            Console.WriteLine("Tennis Warmup");
        }

        public override void Event()
        {
            Console.WriteLine("US Open");
        }
    }

    public class Football : Game
    {
        public override void Drinks()
        {
            Console.WriteLine("Football Drinks");
        }

        public override void PlayGame()
        {
            Console.WriteLine("Football PlayGame");
        }

        public override void Warmup()
        {
            Console.WriteLine("Football Warmup");
        }
    }

    internal class Template
    {
        public Template()
        {
            Game game = new Tennis();
            game.Play();
            game.Event();
            game = new Football();
            game.Play();
            game.Event();
        }
    }
}
