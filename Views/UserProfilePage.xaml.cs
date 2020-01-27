
using ExerciseXamarin.Services;
using Xamarin.Forms;

namespace ExerciseXamarin.Views
{
	public partial class UserProfilePage : ContentPage
	{
		private UserService _service = new UserService();

		public UserProfilePage(int userId)
		{
			BindingContext = _service.GetUser(userId);

			InitializeComponent();
		}
	}
}
