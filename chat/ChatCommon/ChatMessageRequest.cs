namespace ChatCommon
{
    public class ChatMessageRequest
    {
        public ChatUser User { get; }
        public string Message { get; }

        public ChatMessageRequest(ChatUser user, string message)
        {
            User = user;
            Message = message;
        }
    }
}