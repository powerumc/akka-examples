using System;
using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using Akka.Util.Internal;
using ChatCommon;

namespace ChatServer
{
    public class ChatServerActor : ReceiveActor, ILogReceive
    {
        private readonly IList<IActorRef> _clients = new List<IActorRef>();
        
        public ChatServerActor()
        {
            Receive<ConnectRequest>(request =>
            {
                _clients.Add(Sender);
                
                var response = new ConnectResponse(request.User);
                foreach (var client in _clients)
                {
                    client.Tell(response, Self);
                }
            });

            Receive<ChatMessageRequest>(request =>
            {
                var response = new ChatMessageResponse(request.User, request.Message);
                foreach (var client in _clients)
                {
                    if (!client.Equals(Sender))
                        client.Tell(response, Self);
                }
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