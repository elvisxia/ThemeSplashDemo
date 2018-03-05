using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ThemeSplashDemo
{
    [Activity(Label = "ThemeSplashDemo")]
    public class MainActivity : Activity
    {
        Button btnSave;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            ISharedPreferences preference=GetSharedPreferences("SplashTheme", Android.Content.FileCreationMode.Private);
            ISharedPreferencesEditor editor= preference.Edit();
            editor.PutString("themeName", "AppTheme2");
            editor.Commit();
        }
    }
}

