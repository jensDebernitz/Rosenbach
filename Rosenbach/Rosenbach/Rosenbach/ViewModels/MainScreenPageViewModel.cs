using System;
using System.Collections.Generic;
using System.Text;
using Rosenbach.Models;

namespace Rosenbach.ViewModels
{
    public class MainScreenPageViewModel : BaseViewModel
    {
        private double _Slider1 = 50;
        private double _Slider2 = 50;
        private double _Slider3 = 50;
        private double _Slider4 = 50;
        private double _Slider5 = 50;

        public double Slider1
        {
            get => _Slider1;
            set => SetProperty(ref _Slider1, value);
        }

        public double Slider2
        {
            get => _Slider2;
            set => SetProperty(ref _Slider2, value);
        }

        public double Slider3
        {
            get => _Slider3;
            set => SetProperty(ref _Slider3, value);
        }

        public double Slider4
        {
            get => _Slider4;
            set => SetProperty(ref _Slider4, value);
        }

        public double Slider5
        {
            get => _Slider5;
            set => SetProperty(ref _Slider5, value);
        }

        public MainScreenPageViewModel()
        {
            Title = "Sporthopädie Rosenbach";

            LoadData();
        }

        private void LoadData()
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();

            List<ReviewSection> list = reviewSectionDataBase.GetAll();
            if(list.Count < 4)
            {
                InitDataBAseReviewSections();
            }

            foreach(ReviewSection section in list)
            {

            }
        }

        private void InitDataBAseReviewSections()
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();

            
        }
    }
}
