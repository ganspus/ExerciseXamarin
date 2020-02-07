using System;
using System.Collections.ObjectModel;
using ExerciseXamarin.Models;

namespace ExerciseXamarin.ViewModel
{
    public class MenuViewModel
    {
        public ObservableCollection<Exercise> MenuCollection { get; set; }

        public MenuViewModel()
        {
            MenuCollection = new ObservableCollection<Exercise>()
            {
                new Exercise { Id = 1, NameExercise = "Exercise 1 - Slider"},
                new Exercise { Id = 2, NameExercise = "Exercise 2 - Gallery"},
                new Exercise { Id = 3, NameExercise = "Exercise 3 - Searching"},
                new Exercise { Id = 4, NameExercise = "Exercise 4 - Instagram"},
                new Exercise { Id = 5, NameExercise = "Exercise 5 - Contacts"},
                new Exercise { Id = 6, NameExercise = "Exercise 6 - Contacts DB"},
                new Exercise { Id = 7, NameExercise = "Exercise 7 - Netflix API"},
                new Exercise { Id = 8, NameExercise = "Exercise 8 - Calculator"}
            };
        }
    }
}
