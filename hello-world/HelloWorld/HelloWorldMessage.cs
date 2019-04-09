namespace HelloWorld
{
    public class HelloWorldMessage
    {
        public string Message { get; }

        public HelloWorldMessage(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}