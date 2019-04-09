using System;
using Akka.Actor;
using Akka.Configuration;
using ChatCommon;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
akka {  
    actor {
        provider = remote
    }
    remote {
        dot-netty.tcp {
		    port = 0
		    hostname = localhost
        }
    }
}
");

            using (var system = ActorSystem.Create("ChatClientSystem", config))
            {
                Console.Write("Your name? ");
                var username = Console.ReadLine();
                var user = new ChatUser(username);

                var actorRef = system.ActorOf<ChatClientActor>();
                actorRef.Tell(new ConnectRequest(user));

                while (true)
                {
                    Console.Write("Chat: ");
                    var message = Console.ReadLine();
                    
                    actorRef.Tell(new ChatMessageRequest(user, message));
                }
            }
        }
    }
}