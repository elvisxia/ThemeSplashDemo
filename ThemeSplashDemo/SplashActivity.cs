using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ThemeSplashDemo
{
    [Activity(Label = "SplashActivity",MainLauncher =true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ISharedPreferences preferences=GetSharedPreferences("SplashThemeId", FileCreationMode.Private);
            var themeName=preferences.GetString("themeName","AppTheme");
            int themeId = Resource.Style.AppTheme ;
            switch (themeName)
            {
                case "AppTheme":
                    themeId = Resource.Style.AppTheme;
                    break;
                case "AppTheme2":
                    themeId = Resource.Style.AppTheme2;
                    break;
            }
            SetTheme(themeId);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Splash);

            ScheduleSplashScreen();
            
            // Create your application here
        }

        private void ScheduleSplashScreen()
        {
            var splashScreenDuration = 2000;
            Handler handler = new Handler();
            handler.PostDelayed(() =>
            {
                RouteToAppropriatePage();
                Finish();
            }, splashScreenDuration);

        }

        public void RouteToAppropriatePage()
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}