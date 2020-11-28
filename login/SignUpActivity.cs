using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace login
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.sign_up);
            this.Window.SetFlags(WindowManagerFlags.Secure, WindowManagerFlags.Secure);



            Button Login = FindViewById<Button>(Resource.Id.NavigateLogin);
            Login.Click += LoginOnClick;

            Button SignUp = FindViewById<Button>(Resource.Id.SignUpButton);
            SignUp.Click += SignUpOnClick;
        }

        private async void SignUpOnClick(object sender, EventArgs e)
        {
            ProgressDialog loading = ProgressDialog.Show(this, "",
                     "Loading. Please wait...", true);
            ApiCall api = new ApiCall();
            var response = await api.GetRequrestAsync();
            loading.Hide();
            ShowDialog dialog = new ShowDialog(this, "hi SignUp", response.ToString());
            dialog.showAlertDialogButtonClicked();
        }

        private void LoginOnClick(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}