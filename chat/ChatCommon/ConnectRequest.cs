namespace ChatCommon
{
    public class ConnectRequest
    {
        public ChatUser User { get; }

        public ConnectRequest(ChatUser user)
        {
            User = user;
        }
    }
}