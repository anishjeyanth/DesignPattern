using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public interface State
    {
        void Pause();
        void Play();
        void Stop();
    }

    public class StatePlaying : State
    {
        private BoomBox boomBox;
        public StatePlaying(BoomBox boomBox)
        {
            this.boomBox = boomBox;
        }
        public void Pause()
        {
            boomBox.setState(boomBox.getStatePaused());
            Console.WriteLine("Pausing");
        }

        public void Play()
        {
            Console.WriteLine("Already playing");
        }

        public void Stop()
        {
            boomBox.setState(boomBox.getStateStopped());
            Console.WriteLine("Stopping");
        }

        public override string ToString()
        {
            return "PLAYING";
        }
    }

    public class StatePaused : State
    {
        private BoomBox boomBox;
        public StatePaused(BoomBox boomBox)
        {
            this.boomBox = boomBox;
        }
        public void Pause()
        {
            Console.WriteLine("Already paused");
        }

        public void Play()
        {
            boomBox.setState(boomBox.getStatePlaying());
            Console.WriteLine("Start playing");
        }

        public void Stop()
        {
            boomBox.setState(boomBox.getStateStopped());
            Console.WriteLine("Stopping");
        }

        public override string ToString()
        {
            return "PAUSED";
        }
    }

    public class StateStopped : State
    {
        private BoomBox boomBox;
        public StateStopped(BoomBox boomBox)
        {
            this.boomBox = boomBox;
        }
        public void Pause()
        {
            Console.WriteLine("Can't pause in stopped state");
        }

        public void Play()
        {
            boomBox.setState(boomBox.getStatePlaying());
            Console.WriteLine("Start playing");
        }

        public void Stop()
        {
            Console.WriteLine("Already stopped");
        }

        public override string ToString()
        {
            return "STOPPED";
        }
    }

    public class BoomBox
    {
        private State state;

        private State statePlaying;
        private State statePaused;
        private State stateStopped;
        public void setState(State state)
        {
            this.state = state;
        }

        public State getStatePlaying()
        {
            return statePlaying;
        }

        public State getStatePaused()
        {
            return statePaused;
        }

        public State getStateStopped()
        {
            return stateStopped;
        }

        public BoomBox()
        {
            statePlaying = new StatePlaying(this);
            statePaused = new StatePaused(this);
            stateStopped = new StateStopped(this);
            state = stateStopped;
        }

        public void play()
        {
            state.Play();
        }

        public void pause()
        {
            state.Pause();
        }

        public void stop()
        {
            state.Stop();
        }

        public override string ToString()
        {
            return state.ToString();
        }
    }
    internal class States
    {
        public States()
        {
            BoomBox boombox = new BoomBox();
            Console.WriteLine(boombox);
            boombox.play();
            Console.WriteLine(boombox);
            boombox.pause();
            Console.WriteLine(boombox);
            boombox.pause();
            Console.WriteLine(boombox);
            boombox.play();
            Console.WriteLine(boombox);
            boombox.stop();
            Console.WriteLine(boombox);
        }
    }
}
