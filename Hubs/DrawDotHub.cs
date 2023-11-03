using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class DrawDotHub : Hub
    {
        private static Dictionary<string, string> userColors = new Dictionary<string, string>();

        public async Task UpdateCanvas(int x, int y)
        {
            string connectionId = Context.ConnectionId;

            // Check if the user already has a color, and if not, assign a random color
            if (!userColors.ContainsKey(connectionId))
            {
                string randomColor = GetRandomColor();
                userColors[connectionId] = randomColor;
            }

            string color = userColors[connectionId];

            await Clients.All.SendAsync("updateDot", x, y, color);
        }

        public async Task ClearCanvas()
        {
            await Clients.All.SendAsync("clearCanvas");
        }

        private string GetRandomColor()
        {
            Random rand = new Random();
            int r = rand.Next(256);
            int g = rand.Next(256);
            int b = rand.Next(256);

            return $"rgb({r},{g},{b})";
        }
    }
}

// using System;
// using Microsoft.AspNetCore.SignalR;

// namespace SignalRChat.Hubs
// {
//     public class DrawDotHub : Hub
//     {
//         // public async Task UpdateCanvas(int x, int y, string color)
//         // {
//         //     await Clients.All.SendAsync("ReceiveDot", x, y, color);
//         // }
//         public async Task UpdateCanvas(int x, int y)
//         {
//             await Clients.All.SendAsync("updateDot", x, y);
//         }

//         public async Task ClearCanvas()
//         {
//             await Clients.All.SendAsync("clearCanvas");
//         }
//     }
// }