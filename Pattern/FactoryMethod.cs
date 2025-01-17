﻿namespace DesignPattern.Pattern
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


    public abstract class MessageFactory
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

    public class JSONMessageCreator : MessageFactory
    {
        public override Message CreateMessage()
        {
            return new JSONMessage();
        }
    }

    public class TextMessageCreator : MessageFactory
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
            //We can use swtich case also 
            Print(new JSONMessageCreator());
            Print(new TextMessageCreator());
        }

        public void Print(MessageFactory messageCreator)
        {
            Message msg = messageCreator.GetMessage();
            Console.WriteLine(msg.GetContent());
        }
    }
}
