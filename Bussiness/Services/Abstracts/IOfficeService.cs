using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstracts
{
    public interface IOfficeService
    {
        Task AddOffice(Office office);
        void UpdateOffice(Office newOffice, int id);
        void DeleteOffice(int id);
        Office GetOffice(Func<Office, bool>? predicate = null);
        List<Office> GetAllOffices(Func<Office, bool>? predicate = null);
    }
}
