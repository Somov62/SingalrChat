namespace SignalrChat.API.Models
{
    /// <summary>
    /// Модель данных для подключения к чату.
    /// </summary>
    public record UserConnection(string UserName, string ChatRoom);
}
