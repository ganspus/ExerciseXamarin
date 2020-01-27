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
                new Exercise { Id = 1, NameExercise = "Exercise 1"},
                new Exercise { Id = 2, NameExercise = "Exercise 2"},
                new Exercise { Id = 3, NameExercise = "Exercise 3"},
                new Exercise { Id = 4, NameExercise = "Exercise 4"},
                new Exercise { Id = 5, NameExercise = "Exercise 5"},
                new Exercise { Id = 6, NameExercise = "Exercise 6"},
                new Exercise { Id = 7, NameExercise = "Exercise 7"},
                new Exercise { Id = 8, NameExercise = "Exercise 8"}
            };
        }
    }
}
