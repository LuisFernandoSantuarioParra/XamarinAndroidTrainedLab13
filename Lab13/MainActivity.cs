using Android.App;
using Android.Widget;
using Android.OS;

namespace Lab13
{
    [Activity(Label = "Lab13", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var ImageButton = FindViewById<ImageButton>(Resource.Id.imageButton1);

            ImageButton.Click += (object sender,System.EventArgs e) => {

                Validate();
            };
        }

        private async void Validate()
        {
            var Client = new SALLab13.ServiceClient();

            string StudentEmail = "santuarioparral@hotmail.com";
            string Password = "santuario1";
            var Result = await Client.ValidateAsync(this, StudentEmail, Password);

            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resultado de la verificación");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.FullName}\n{Result.Token}");
            Alert.SetButton("Ok", (s, ev) => { });
            Alert.Show();
        }
    }
}

