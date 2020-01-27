using System;
using System.Collections.Generic;
using System.Linq;
using ExerciseXamarin.Models;

namespace ExerciseXamarin.Services
{
	public class UserService
	{
		private List<User> _users = new List<User>
		{
			new User { Id = 1, Description = "My name is Catur", Name = "Catur" },
			new User { Id = 2, Description = "My name is Ghina", Name = "Ghina" },
			new User { Id = 3, Description = "My name is Eni", Name = "Eni" },
			new User { Id = 4, Description = "My name is Imam", Name = "Imam" },
			new User { Id = 5, Description = "My name is Wahyu", Name = "Wahyu" },
			new User { Id = 6, Description = "My name is Amar", Name = "Amar" },
			new User { Id = 7, Description = "My name is Tri", Name = "Tri" },
			new User { Id = 8, Description = "My name is Desi", Name = "Desi" },
			new User { Id = 9, Description = "My name is Abi", Name = "Abi" },
		};

		public User GetUser(int userId)
		{
			return _users.SingleOrDefault(u => u.Id == userId);
		}
	}
}
