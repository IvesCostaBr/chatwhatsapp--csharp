using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chatbot.Models;


namespace chatbot.Controllers
{
    
    [ApiController]
    [Route("/")]
    public class WebHookController : ControllerBase
    {
        [HttpPost]
        public Task<string> Post(Answer data)
        {
            foreach (var message in data.Messages)
            {
                if (message.FromMe)
                    Console.WriteLine(message.Body);
            }
            return new Task<string>(()=> "");      
        }
    }
    
}
