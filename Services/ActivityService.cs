using System.Collections.Generic;
using ExerciseXamarin.Models;

namespace ExerciseXamarin.Services
{
	public class ActivityService
	{
		public IEnumerable<Activity> GetActivities()
		{
			return new List<Activity>
			{
				new Activity { UserId = 1, Description = "Your Facebook friend Catur is on Instagram." },
				new Activity { UserId = 2, Description = "Ghina started following you" },
				new Activity { UserId = 3, Description = "Eni liked your photo." },
				new Activity { UserId = 4, Description = "Your Facebook friend Imam is on Instagram." },
				new Activity { UserId = 5, Description = "Wahyu sent a photo posted by @brookeisep." },
				new Activity { UserId = 6, Description = "Amar started following you." },
				new Activity { UserId = 7, Description = "Your Facebook friend Tri is on Instagram." },
				new Activity { UserId = 8, Description = "Your Facebook friend Desi Chang is on Instagram." },
				new Activity { UserId = 9, Description = "Your Facebook friend Abi is on Instagram." },
			};
		}
	}
}
