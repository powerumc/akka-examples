using System;
using Akka.Actor;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("HelloWorldSystem");
            var actorRef = system.ActorOf<HelloWorldActor>();
            
            actorRef.Tell(new HelloWorldMessage("akka.net"));

            Console.ReadLine();
        }
    }
}