using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using ExerciseXamarin.Models;
using ExerciseXamarin.Persistence;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
    public partial class Exercise6Page : ContentPage
    {
        public Exercise6Page()
        {
            InitializeComponent();

            GetProducts();
        }

        private async void GetProducts()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://productsdemoapp.azurewebsites.net/api/Products");

            var products = JsonConvert.DeserializeObject<List<Product>>(response);

            ProductsListView.ItemsSource = products;
        }
    }
}
