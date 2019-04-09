using System;
using Akka.Actor;
using ChatCommon;

namespace ChatClient
{
    public class ChatClientActor : ReceiveActor, ILogReceive
    {
        private readonly ActorSelection _server = Context.ActorSelection("akka.tcp://ChatSystem@localhost:8081/user/server");
        
        public ChatClientActor()
        {
            Receive<ConnectRequest>(request =>
            {
                Console.WriteLine("connecting...");
                _server.Tell(request);
            });

            Receive<ConnectResponse>(response =>
            {
                Console.WriteLine($"Connected {response.User.Name}");
            });

            Receive<ChatMessageRequest>(request =>
            {
                _server.Tell(request);
            });

            Receive<ChatMessageResponse>(response =>
            {
                Console.WriteLine($"{response.User.Name}: {response.Message}");
            });
        }
    }
}