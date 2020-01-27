﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ExerciseXamarin.Models;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise5Page : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public Exercise5Page()
        {
            InitializeComponent();

            _contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = 1, FirstName = "Ganis", LastName = "Puspita", Email = "gasnpuss@gmail.com", Phone = "087887XXXXXX" }
            };

            contacts.ItemsSource = _contacts;
        }

		async void OnAddContact(object sender, System.EventArgs e)
		{
			var page = new ContactDetailPage(new Contact());

			page.ContactAdded += (source, contact) =>
			{
				_contacts.Add(contact);
			};

			await Navigation.PushAsync(page);
		}

		async void OnContactSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (contacts.SelectedItem == null)
				return;

			var selectedContact = e.SelectedItem as Contact;

			contacts.SelectedItem = null;

			var page = new ContactDetailPage(selectedContact);
			page.ContactUpdated += (source, contact) =>
			{
				selectedContact.Id = contact.Id;
				selectedContact.FirstName = contact.FirstName;
				selectedContact.LastName = contact.LastName;
				selectedContact.Phone = contact.Phone;
				selectedContact.Email = contact.Email;
				selectedContact.IsBlocked = contact.IsBlocked;
			};

			await Navigation.PushAsync(page);
		}

		async void OnDeleteContact(object sender, System.EventArgs e)
		{
			var contact = (sender as MenuItem).CommandParameter as Contact;

			if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
				_contacts.Remove(contact);
		}
	}
}
