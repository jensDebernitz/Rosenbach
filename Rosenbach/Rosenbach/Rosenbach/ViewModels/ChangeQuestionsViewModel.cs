using System;
using System.Collections.Generic;
using System.Windows.Input;
using Rosenbach.Models;

namespace Rosenbach.ViewModels
{
    public class ChangeQuestionsViewModel : BaseViewModel
    {
        private ReviewSection[] _ReviewSections = new ReviewSection[5];
        public ICommand CommandSave { get; set; }

        public ReviewSection[] ReviewSections
        {
            get => _ReviewSections;
            set => SetProperty(ref _ReviewSections, value);
        }

        public ChangeQuestionsViewModel()
        {
            Title = "Fragen ändern";
            CommandSave = new RelayCommand(new Action<object>(ClickSave));
            LoadData();

            
        }

        private void ClickSave(object obj)
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();

            foreach (ReviewSection section in ReviewSections)
            {
                reviewSectionDataBase.Update(section);
            }

            MainScreenPageViewModel.getInstace().LoadData();
        }

        private void LoadData()
        {
            ReviewSectionDataBase reviewSectionDataBase = new ReviewSectionDataBase();
            List<ReviewSection> list = reviewSectionDataBase.GetAll();

            foreach (ReviewSection section in list)
            {
                int id = section.Id;
                ReviewSections[id - 1] = section;
            }
        }
    }
}
