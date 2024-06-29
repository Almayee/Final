using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstracts
{
    public interface ISliderService
    {
        Task AddSlider(Slider slider);
        void UpdateSlider(Slider newSlider, int id);
        void DeleteSlider(int id);
        Slider GetSlider(Func<Slider, bool>? predicate = null);
        List<Slider> GetAllSliders(Func<Slider, bool>? predicate = null);
    }
}
