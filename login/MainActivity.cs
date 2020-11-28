using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace login
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{
		

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);


			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			SetContentView(Resource.Layout.activity_main);
			this.Window.SetFlags(WindowManagerFlags.Secure, WindowManagerFlags.Secure);

			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);
			

			Button login = FindViewById<Button>(Resource.Id.LoginButton);
			login.Click += LoginOnClick;

			Button SignUp = FindViewById<Button>(Resource.Id.NavigateSignUp);
			SignUp.Click += SignUpOnClick;
		}

		private void SignUpOnClick(object sender, EventArgs e)
		{
			Intent intent = new Intent(this, typeof(SignUpActivity));
			StartActivity(intent);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			int id = item.ItemId;
			if (id == Resource.Id.action_settings)
			{
				return true;
			}

			return base.OnOptionsItemSelected(item);
		}

		private async void LoginOnClick(object sender, EventArgs eventArgs)
		{
			ProgressDialog loading = ProgressDialog.Show(this, "",
					"Loading. Please wait...", true);
			ApiCall api = new ApiCall();
			var response =await api.GetRequrestAsync();
			loading.Hide(); 
			ShowDialog dialog = new ShowDialog(this, "hi Login", response.ToString());
			dialog.showAlertDialogButtonClicked();
		}


		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}

