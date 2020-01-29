using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseXamarin.Models;
using ExerciseXamarin.Services;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise7Page : ContentPage
    {
		private MovieService _service = new MovieService();

		private BindableProperty IsSearchingProperty =
			BindableProperty.Create("IsSearching", typeof(bool), typeof(Exercise7Page), false);
		public bool IsSearching
		{
			get { return (bool)GetValue(IsSearchingProperty); }
			set { SetValue(IsSearchingProperty, value); }
		}

		public Exercise7Page()
        {
			BindingContext = this;

			InitializeComponent();
        }

		async void OnTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			if (e.NewTextValue == null || e.NewTextValue.Length < MovieService.MinSearchLength)
				return;

			await FindMovies(actor: e.NewTextValue);
		}

		async Task FindMovies(string actor)
		{
			try
			{
				IsSearching = true;

				var movies = await _service.FindMoviesByActor(actor);
				moviesListView.ItemsSource = movies;
				moviesListView.IsVisible = movies.Any();
				notFound.IsVisible = !moviesListView.IsVisible;
			}
			catch (Exception)
			{
				await DisplayAlert("Error", "Could not retrieve the list of movies.", "OK");
			}
			finally
			{
				IsSearching = false;
			}
		}

		async void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
				return;

			var movie = e.SelectedItem as Movie;

			moviesListView.SelectedItem = null;

			await Navigation.PushAsync(new MovieDetailsPage(movie));
		}
	}
}
