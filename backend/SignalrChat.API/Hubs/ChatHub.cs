using Microsoft.AspNetCore.SignalR;
using SignalrChat.API.Models;

namespace SignalrChat.API.Hubs
{
    /// <summary>
    /// Интерфейс возможностей чата.
    /// </summary>
    public interface IChatClient
    {
        /// <summary>
        /// Получение входящего сообщения.
        /// </summary>
        /// <param name="userName">Автор сообщения.</param>
        /// <param name="message">сообщение.</param>
        /// <returns></returns>
        public Task ReceiveMessage(string userName, string message);


    }


    /// <summary>
    /// Хаб для отправки и получения сообщений.
    /// </summary>
    public class ChatHub : Hub<IChatClient>
    {
        public async Task Join(UserConnection connection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName: connection.ChatRoom);

            await Clients
                .Group(connection.ChatRoom)
                .ReceiveMessage("Admin", $"{connection.UserName} присоединился к чату");
        }

    }
}


