using ReactiveExtensionsXF.View;
using Xamarin.Forms;

namespace ReactiveExtensionsXF
{
    //http://rxwiki.wikidot.com/101samples
    public partial class App : Application
    {
        public App()
        {

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
