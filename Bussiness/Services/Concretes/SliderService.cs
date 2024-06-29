using Bussiness.Exceptions;
using Bussiness.Extensions;
using Bussiness.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Concretes
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;

        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
                _sliderRepository= sliderRepository;
                _env= env;
        }
        public async Task AddSlider(Slider slider)
        {
            if (slider.ImageFile == null)
                throw new Exceptions.FileNotFoundException("The file cannot be empty!");

            slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\movies", slider.ImageFile);

            await _sliderRepository.AddAsync(slider);
            await _sliderRepository.CommitAsync();
        }

        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);
            if (existSlider == null)
                throw new EntityNotFoundException("File not found!");

            Helper.DeleteFIle(_env.WebRootPath, @"uploads\movies", existSlider.ImageUrl);

            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit();
        }

        public List<Slider> GetAllSliders(Func<Slider, bool>? predicate = null)
        {
            return _sliderRepository.GetAll(predicate);
        }

        public Slider GetSlider(Func<Slider, bool>? predicate = null)
        {
            return _sliderRepository.Get(predicate);
        }

        public void UpdateSlider(Slider newSlider, int id)
        {
            var oldSlider = _sliderRepository.Get(x => x.Id == id);

            if (oldSlider == null)
                throw new EntityNotFoundException("File not found!");

            if (newSlider.ImageFile != null)
            {
                Helper.DeleteFIle(_env.WebRootPath, @"uploads\movies", oldSlider.ImageUrl);
                oldSlider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\movies", newSlider.ImageFile);
            }

            _sliderRepository.Commit();
        }
    }
}
