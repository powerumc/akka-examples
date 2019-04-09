namespace ChatCommon
{
    public class ChatMessageResponse
    {
        public ChatUser User { get; }
        public string Message { get; }

        public ChatMessageResponse(ChatUser user, string message)
        {
            User = user;
            Message = message;
        }
    }
}