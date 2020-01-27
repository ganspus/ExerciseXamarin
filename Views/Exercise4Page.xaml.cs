using System;
using System.Collections.Generic;
using ExerciseXamarin.Models;
using ExerciseXamarin.Services;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise4Page : ContentPage
    {
        private ActivityService _service = new ActivityService();

        public Exercise4Page()
        {
            InitializeComponent();

            activityFeed.ItemsSource = _service.GetActivities();
        }

        void OnActivitySelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var activity = e.SelectedItem as Activity;

            activityFeed.SelectedItem = null;

            Navigation.PushAsync(new UserProfilePage(activity.UserId));
        }
    }
}
