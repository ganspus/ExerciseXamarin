using System;
using System.Collections.Generic;
using System.Linq;
using ExerciseXamarin.Models;

namespace ExerciseXamarin.Services
{
	public class SearchService 
	{
		private List<Search> _searches = new List<Search>
		{
			new Search
			{
				Id = 1,
				Location = "Jakarta, Kalisari",
				CheckIn = new DateTime(2020, 1, 1),
				CheckOut = new DateTime(2020, 1, 31)
			},
			new Search
			{
				Id = 2,
				Location = "Jakarta, Ciracas",
				CheckIn = new DateTime(2020, 1, 1),
				CheckOut = new DateTime(2020, 1, 31)
			}
		};

		public IEnumerable<Search> GetRecentSearches(string filter = null)
		{
			if (String.IsNullOrWhiteSpace(filter))
				return _searches;

			return _searches.Where(s => s.Location.StartsWith(filter, StringComparison.CurrentCultureIgnoreCase));
		}

		public void DeleteSearch(int searchId)
		{
			_searches.Remove(_searches.Single(s => s.Id == searchId));
		}
	}
}
