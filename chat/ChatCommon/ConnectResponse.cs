namespace ChatCommon
{
    public class ConnectResponse
    {
        public ChatUser User { get; }

        public ConnectResponse(ChatUser user)
        {
            User = user;
        }
    }
}