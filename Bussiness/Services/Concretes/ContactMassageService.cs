using Bussiness.Services.Abstracts;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concretes
{
    public class ContactMassageService : IContactMassageService
    {
        public void SendContactMessage(ContactMessage contactMessage)
        {
            Console.WriteLine($"Name: {contactMessage.Name}");
            Console.WriteLine($"Email: {contactMessage.Email}");
            Console.WriteLine($"Message: {contactMessage.Message}");
        }
    }
}
