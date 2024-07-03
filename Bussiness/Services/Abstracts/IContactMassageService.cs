using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstracts
{
    public interface IContactMassageService
    {
        void SendContactMessage(ContactMessage contactMessage);
    }
}
