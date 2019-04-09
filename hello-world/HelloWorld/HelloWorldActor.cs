using System;
using Akka.Actor;

namespace HelloWorld
{
    public class HelloWorldActor : ReceiveActor
    {
        public HelloWorldActor()
        {
            Receive<HelloWorldMessage>(message =>
            {
                Console.WriteLine($"Hello World, {message.Message}");
            });
        }

        #region To check the lifecycle.
        protected override void PreStart()
        {
            Console.WriteLine(nameof(PreStart));
        }

        protected override void PostStop()
        {
            Console.WriteLine(nameof(PostStop));
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine(nameof(PreRestart));
        }

        protected override void PostRestart(Exception reason)
        {
            Console.WriteLine(nameof(PostRestart));
        }

        public override void AroundPostStop()
        {
            Console.WriteLine(nameof(AroundPostStop));
        }

        public override void AroundPreStart()
        {
            Console.WriteLine(nameof(AroundPreStart));
        }
        #endregion
    }
}