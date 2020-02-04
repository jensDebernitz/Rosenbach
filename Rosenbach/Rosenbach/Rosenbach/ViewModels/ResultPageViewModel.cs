using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Rosenbach.Models;

namespace Rosenbach.ViewModels
{
    public class ResultPageViewModel : BaseViewModel
    {
        public static ResultPageViewModel Instance;

        public ICommand CommandSend { get; set; }
        public ICommand CommandReset { get; set; }

        private ReviewSection _ReviewSection1;
        private ReviewSection _ReviewSection2;
        private ReviewSection _ReviewSection3;
        private ReviewSection _ReviewSection4;
        private ReviewSection _ReviewSection5;

        private double _Result1;
        private double _Result2;
        private double _Result3;
        private double _Result4;
        private double _Result5;
        private int _ResultCount;
        private string _ReviewTime;
        private int _ReviewAM;
        private int _ReviewPM;


        public ReviewSection ReviewSection1 { get => _ReviewSection1; set => SetProperty(ref _ReviewSection1, value); }
        public ReviewSection ReviewSection2 { get => _ReviewSection2; set => SetProperty(ref _ReviewSection2, value); }
        public ReviewSection ReviewSection3 { get => _ReviewSection3; set => SetProperty(ref _ReviewSection3, value); }
        public ReviewSection ReviewSection4 { get => _ReviewSection4; set => SetProperty(ref _ReviewSection4, value); }
        public ReviewSection ReviewSection5 { get => _ReviewSection5; set => SetProperty(ref _ReviewSection5, value); }
        public double Result1 { get => _Result1; set => SetProperty(ref _Result1, value); }
        public double Result2 { get => _Result2; set => SetProperty(ref _Result2, value); }
        public double Result3 { get => _Result3; set => SetProperty(ref _Result3, value); }
        public double Result4 { get => _Result4; set => SetProperty(ref _Result4, value); }
        public double Result5 { get => _Result5; set => SetProperty(ref _Result5, value); }
        public int ResultCount { get => _ResultCount; set => SetProperty(ref _ResultCount, value); }
        public string ReviewTime { get => _ReviewTime; set => SetProperty(ref _ReviewTime, value); }
        public int ReviewAM { get => _ReviewAM; set => SetProperty(ref _ReviewAM, value); }
        public int ReviewPM { get => _ReviewPM; set => SetProperty(ref _ReviewPM, value); }

        public ResultPageViewModel()
        {
            Title = "Auswertung";
            CommandSend = new RelayCommand(new Action<object>(ClickSend));
            CommandReset = new RelayCommand(new Action<object>(ClickReset));
            Instance = this;
            LoadData();
        }

        private void ClickReset(object obj)
        {
            RatingDataBase ratingDataBase = new RatingDataBase();
            List<Rating> list = ratingDataBase.GetAll();

            //delete all
            foreach (Rating reviewSection in ratingDataBase.GetAll())
            {
                bool result = ratingDataBase.Delete(reviewSection.Id);
            }

            LoadData();
        }

        private void ClickSend(object obj)
        {
            //TODO send a email
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            LoadReviewSections();

            LoadRatings();
        }

        private void LoadRatings()
        {
            RatingDataBase ratingDataBase = new RatingDataBase();
            List<Rating> list = ratingDataBase.GetAll();

            DateTime dateTimeMin = DateTime.MaxValue;
            DateTime dateTimeMax = DateTime.MinValue;

            foreach (Rating rating in list)
            {
                Result1 += rating.Rating1;
                Result2 += rating.Rating2;
                Result3 += rating.Rating3;
                Result4 += rating.Rating4;
                Result5 += rating.Rating5;

                RatingDateMinMax(ref dateTimeMin, ref dateTimeMax, rating);

                if (rating.dateTime.Hour >= 8 && rating.dateTime.Hour <= 12)
                {
                    ReviewAM++;
                }
                else if (rating.dateTime.Hour >= 13 && rating.dateTime.Hour <= 18)
                {
                    ReviewPM++;
                }
            }

            Result1 /= list.Count;
            Result2 /= list.Count;
            Result3 /= list.Count;
            Result4 /= list.Count;
            Result5 /= list.Count;

            ResultCount = list.Count;

            ReviewTime = dateTimeMin.ToShortDateString() + " - " + dateTimeMax.ToShortDateString();
        }

        private static void RatingDateMinMax(ref DateTime dateTimeMin, ref DateTime dateTimeMax, Rating rating)
        {
            if (rating.dateTime < dateTimeMin)
            {
                dateTimeMin = rating.dateTime;
            }

            if (rating.dateTime > dateTimeMax)
            {
                dateTimeMax = rating.dateTime;
            }
        }

        private void LoadReviewSections()
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();
            List<ReviewSection> list = reviewSectionDataBase.GetAll();

            //load from database and show it in the main screen
            ReviewSection1 = list[0];
            ReviewSection2 = list[1];
            ReviewSection3 = list[2];
            ReviewSection4 = list[3];
            ReviewSection5 = list[4];
        }
    }
}
