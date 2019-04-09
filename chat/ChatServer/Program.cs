using System;
using Akka.Actor;
using Akka.Configuration;

namespace ChatServer
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
            port = 8081
            hostname = 0.0.0.0
            public-hostname = localhost
        }
    }
}
");
            
            using (var system = ActorSystem.Create("ChatSystem", config))
            {    
                system.ActorOf<ChatServerActor>("server");
                
                AppDomain.CurrentDomain.ProcessExit += async (sender, eventArgs) => await system?.Terminate();
                Console.ReadLine();
            }            
        }
    }
}