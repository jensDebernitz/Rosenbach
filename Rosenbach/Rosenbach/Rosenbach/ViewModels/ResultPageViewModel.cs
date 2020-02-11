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

        private string _Result1;
        private string _Result2;
        private string _Result3;
        private string _Result4;
        private string _Result5;
        private int _ResultCount;
        private string _ReviewTime;
        private int _ReviewAM;
        private int _ReviewPM;


        public ReviewSection ReviewSection1 { get => _ReviewSection1; set => SetProperty(ref _ReviewSection1, value); }
        public ReviewSection ReviewSection2 { get => _ReviewSection2; set => SetProperty(ref _ReviewSection2, value); }
        public ReviewSection ReviewSection3 { get => _ReviewSection3; set => SetProperty(ref _ReviewSection3, value); }
        public ReviewSection ReviewSection4 { get => _ReviewSection4; set => SetProperty(ref _ReviewSection4, value); }
        public ReviewSection ReviewSection5 { get => _ReviewSection5; set => SetProperty(ref _ReviewSection5, value); }
        public string Result1 { get => _Result1; set => SetProperty(ref _Result1, value); }
        public string Result2 { get => _Result2; set => SetProperty(ref _Result2, value); }
        public string Result3 { get => _Result3; set => SetProperty(ref _Result3, value); }
        public string Result4 { get => _Result4; set => SetProperty(ref _Result4, value); }
        public string Result5 { get => _Result5; set => SetProperty(ref _Result5, value); }
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
            double tempRating1 = 0;
            double tempRating2 = 0;
            double tempRating3 = 0;
            double tempRating4 = 0;
            double tempRating5 = 0;

            foreach (Rating rating in list)
            {
                tempRating1 += rating.Rating1;
                tempRating2 += rating.Rating2;
                tempRating3 += rating.Rating3;
                tempRating4 += rating.Rating4;
                tempRating5 += rating.Rating5;

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

            tempRating1 /= list.Count;
            tempRating2 /= list.Count;
            tempRating3 /= list.Count;
            tempRating4 /= list.Count;
            tempRating5 /= list.Count;

            Result1 = (tempRating1 / 100).ToString("P");
            Result2 = (tempRating2 / 100).ToString("P");
            Result3 = (tempRating3 / 100).ToString("P");
            Result4 = (tempRating4 / 100).ToString("P");
            Result5 = (tempRating5 / 100).ToString("P");

            ResultCount = list.Count;

            ReviewTime = dateTimeMin.ToString("dd.MM.yyyy") + " - " + dateTimeMax.ToString("dd.MM.yyyy");
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
