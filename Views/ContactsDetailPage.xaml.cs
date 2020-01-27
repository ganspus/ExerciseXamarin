using System;
using System.Collections.Generic;
using ExerciseXamarin.Models;
using ExerciseXamarin.Persistence;
using SQLite;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class ContactsDetailPage : ContentPage
    {
        public event EventHandler<Contacts> ContactAdded;
        public event EventHandler<Contacts> ContactUpdated;

        private SQLiteAsyncConnection _connection;

        public ContactsDetailPage(Contacts contacts)
        {
            if (contacts == null)
                throw new ArgumentNullException(nameof(contacts));

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            BindingContext = new Contact
            {
                Id = contacts.Id,
                FirstName = contacts.FirstName,
                LastName = contacts.LastName,
                Phone = contacts.Phone,
                Email = contacts.Email,
                IsBlocked = contacts.IsBlocked
            };
        }

        async void OnSave(object sender, System.EventArgs e)
        {
            var contacts = BindingContext as Contacts;

            if (String.IsNullOrWhiteSpace(contacts.FullName))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            if (contacts.Id == 0)
            {
                await _connection.InsertAsync(contacts);

                ContactAdded?.Invoke(this, contacts);
            }
            else
            {
                await _connection.UpdateAsync(contacts);

                ContactUpdated?.Invoke(this, contacts);
            }

            await Navigation.PopAsync();
        }
    }
}
