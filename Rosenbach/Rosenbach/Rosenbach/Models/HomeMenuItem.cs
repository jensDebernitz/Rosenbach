﻿namespace Rosenbach.Models
{
    public enum MenuItemType
    {
        MainScreen,
        ChangeQuestions,
        Result,
        Settings,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
