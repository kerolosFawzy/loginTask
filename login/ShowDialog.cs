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
	class ShowDialog
	{
		Context context;
		String message; 
		String title;
		public ShowDialog(Context context, String title, String message  )
		{
			this.context = context; 
			this.message = message; 
			this.title = title; 
		}

		public void showAlertDialogButtonClicked()
		{

			// setup the alert builder
			AlertDialog.Builder builder = new AlertDialog.Builder(context);
			builder.SetTitle(title);
			builder.SetMessage(message);

			// add the buttons
			builder.SetNeutralButton("Continue", (senderAlert, args) => {
				Intent intent = new Intent(context, typeof(WebViewer));
				context.StartActivity(intent);
			});

			// create and show the alert dialog
			AlertDialog dialog = builder.Create();
			dialog.Show();
		}

	}
}