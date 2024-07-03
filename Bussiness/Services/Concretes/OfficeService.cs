using Bussiness.Exceptions;
using Bussiness.Extensions;
using Bussiness.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concretes
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IWebHostEnvironment _env;
        public OfficeService(IOfficeRepository officeRepository, IWebHostEnvironment env)
        {
            _officeRepository = officeRepository;
            _env = env;
        }
        public async Task AddOffice(Office office)
        {
            if (office.ImageFile == null)
                throw new Exceptions.FileNotFoundException("The file cannot be empty!");

            office.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\movies", office.ImageFile);

            await _officeRepository.AddAsync(office);
            await _officeRepository.CommitAsync();
        }

        public void DeleteOffice(int id)
        {
            var existOffice = _officeRepository.Get(x => x.Id == id);
            if (existOffice == null)
                throw new EntityNotFoundException("File not found!");

            Helper.DeleteFIle(_env.WebRootPath, @"uploads\movies", existOffice.ImageUrl);

            _officeRepository.Delete(existOffice);
            _officeRepository.Commit();
        }

        public List<Office> GetAllOffices(Func<Office, bool>? predicate = null)
        {
            return _officeRepository.GetAll(predicate);
        }

        public Office GetOffice(Func<Office, bool>? predicate = null)
        {
            return _officeRepository.Get(predicate);
        }

        public void UpdateOffice(Office newOffice, int id)
        {
            var oldOffice = _officeRepository.Get(x => x.Id == id);

            if (oldOffice == null)
                throw new EntityNotFoundException("File not found!");

            if (newOffice.ImageFile != null)
            {
                Helper.DeleteFIle(_env.WebRootPath, @"uploads\movies", oldOffice.ImageUrl);
                oldOffice.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\movies", newOffice.ImageFile);
            }

            _officeRepository.Commit();
        }
    }
}