using System;
using System.Collections.Generic;
using System.Windows.Input;
using Rosenbach.Models;

namespace Rosenbach.ViewModels
{

    public class MainScreenPageViewModel : BaseViewModel
    {

        static MainScreenPageViewModel Instance;
        private double _Slider1 = 50;
        private double _Slider2 = 50;
        private double _Slider3 = 50;
        private double _Slider4 = 50;
        private double _Slider5 = 50;
        private ReviewSection _ReviewSection1;
        private ReviewSection _ReviewSection2;
        private ReviewSection _ReviewSection3;
        private ReviewSection _ReviewSection4;
        private ReviewSection _ReviewSection5;

        public ReviewSection ReviewSection1 { get => _ReviewSection1; set => SetProperty(ref _ReviewSection1, value); }
        public ReviewSection ReviewSection2 { get => _ReviewSection2; set => SetProperty(ref _ReviewSection2, value); }
        public ReviewSection ReviewSection3 { get => _ReviewSection3; set => SetProperty(ref _ReviewSection3, value); }
        public ReviewSection ReviewSection4 { get => _ReviewSection4; set => SetProperty(ref _ReviewSection4, value); }
        public ReviewSection ReviewSection5 { get => _ReviewSection5; set => SetProperty(ref _ReviewSection5, value); }



        public ICommand CommandEvalute { get; set; }

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

            CommandEvalute = new RelayCommand(new Action<object>(EvaluteClick));
            LoadData();
            Instance = this;
        }

        private void EvaluteClick(object sender)
        {
            Rating rating = new Rating
            {
                Rating1 = Slider1,
                Rating2 = Slider2,
                Rating3 = Slider3,
                Rating4 = Slider4,
                Rating5 = Slider5,
                dateTime = DateTime.Now
            };

            RatingDataBase ratingDataBase = new RatingDataBase();
            ratingDataBase.Upsert(rating);

            ResultPageViewModel.Instance?.LoadData();
        }

        public static MainScreenPageViewModel getInstace()
        {
            return Instance;
        }
        public void LoadData()
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();
            List<ReviewSection> list = reviewSectionDataBase.GetAll();

            if(list.Count < 5)
            {
                InitDataBAseReviewSections();
            }

            //load from database and show it in the main screen
            ReviewSection1 = list[0];
            ReviewSection2 = list[1];
            ReviewSection3 = list[2];
            ReviewSection4 = list[3];
            ReviewSection5 = list[4];
        }

        private void InitDataBAseReviewSections()
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();

            //delete all
            foreach(ReviewSection reviewSection in reviewSectionDataBase.GetAll())
            {
                reviewSectionDataBase.Delete(reviewSection.Id);
            }

            //set initial the default....
            for(int i = 0; i < 5; i++)
            {
                ReviewSection reviewSection = new ReviewSection();
                reviewSection.Question = "Frage " + i;
                reviewSection.TendenzMinimum = "Tendenz- " + i;
                reviewSection.TendenzMiddle = "Tendenz " + i;
                reviewSection.TendenzMaximum = "Tendenz+ " + i;

                reviewSectionDataBase.Upsert(reviewSection);
            }
        }
    }
}
