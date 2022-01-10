using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern
{
    public abstract class Message
    {
        public abstract string GetContent();
        public void Encrypt()
        {
            Console.WriteLine("encrypt");
        }
    }

    public class JSONMessage : Message
    {
        public override string GetContent()
        {
            return "JSON";
        }
    }

    public class TextMessage : Message
    {
        public override string GetContent()
        {
            return "Text";
        }
    }


    public abstract class MessageCreator
    {
        public Message GetMessage()
        {
            Message message = CreateMessage();
            message.Encrypt();
            return message;
        }

        //This is the factory method
        public abstract Message CreateMessage();
    }

    public class JSONMessageCreator : MessageCreator
    {
        public override Message CreateMessage()
        {
            return new JSONMessage();
        }
    }

    public class TextMessageCreator : MessageCreator
    {
        public override Message CreateMessage()
        {
            return new TextMessage();
        }
    }

    internal class FactoryMethod
    {
        public FactoryMethod()
        {
            Print(new JSONMessageCreator());
            Print(new TextMessageCreator());
        }

        public void Print(MessageCreator messageCreator)
        {
            Message msg = messageCreator.GetMessage();
            Console.WriteLine(msg.GetContent());
        }
    }
}
