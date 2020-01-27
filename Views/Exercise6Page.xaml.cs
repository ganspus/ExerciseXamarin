using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ExerciseXamarin.Models;
using ExerciseXamarin.Persistence;
using SQLite;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise6Page : ContentPage
    {
        private ObservableCollection<Contacts> _contacts;
        private SQLiteAsyncConnection _connection;
        private bool _isDataLoaded;

        public Exercise6Page()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

		protected override async void OnAppearing()
		{
			if (_isDataLoaded)
				return;

			_isDataLoaded = true;

			await LoadData();

			base.OnAppearing();
		}

		private async Task LoadData()
		{
			await _connection.CreateTableAsync<Contacts>();

			var contacts = await _connection.Table<Contacts>().ToListAsync();

			_contacts = new ObservableCollection<Contacts>(contacts);
			contactsListView.ItemsSource = _contacts;
		}

		async void OnAddContact(object sender, System.EventArgs e)
		{
			var page = new ContactsDetailPage(new Contacts());

			page.ContactAdded += (source, contacts) =>
			{
				_contacts.Add(contacts);
			};

			await Navigation.PushAsync(page);
		}

		async void OnContactSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (contactsListView.SelectedItem == null)
				return;

			var selectedContact = e.SelectedItem as Contacts;

			contactsListView.SelectedItem = null;

			var page = new ContactsDetailPage(selectedContact);
			page.ContactUpdated += (source, contacts) =>
			{
				selectedContact.Id = contacts.Id;
				selectedContact.FirstName = contacts.FirstName;
				selectedContact.LastName = contacts.LastName;
				selectedContact.Phone = contacts.Phone;
				selectedContact.Email = contacts.Email;
				selectedContact.IsBlocked = contacts.IsBlocked;
			};

			await Navigation.PushAsync(page);
		}

		async void OnDeleteContact(object sender, System.EventArgs e)
		{
			var contacts = (sender as MenuItem).CommandParameter as Contacts;

			if (await DisplayAlert("Warning", $"Are you sure you want to delete {contacts.FullName}?", "Yes", "No"))
			{
				_contacts.Remove(contacts);

				await _connection.DeleteAsync(contacts);
			}
		}
	}
}
