using System;
using System.Collections.Generic;
using ExerciseXamarin.Models;
using ExerciseXamarin.ViewModel;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

            BindingContext = new MenuViewModel();
        }

        async private void listView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var selectitem = e.Item as Exercise;

            switch(selectitem.Id)
            {
                case 1:
                    await Navigation.PushAsync(new Exercise1Page());
                    break;
                case 2:
                    await Navigation.PushAsync(new Exercise2Page());
                    break;
                case 3:
                    await Navigation.PushAsync(new Exercise3Page());
                    break;
                case 4:
                    await Navigation.PushAsync(new Exercise4Page());
                    break;
                case 5:
                    await Navigation.PushAsync(new Exercise5Page());
                    break;
                case 6:
                    await Navigation.PushAsync(new Exercise6Page());
                    break;
                case 7:
                    await Navigation.PushAsync(new Exercise7Page());
                    break;
                case 8:
                    await Navigation.PushAsync(new Exercise8Page());
                    break;
            }
            ((ListView)sender).SelectedItem = null; 
        }
    }
}
