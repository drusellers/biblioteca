namespace biblioteca.web.controllers
{
    using System;

    public class PackageController
    {
        public AboutViewModel Index(AboutSetupViewModel inModel)
        {
            return new AboutViewModel();
        }
    }


    public class AboutSetupViewModel : ViewModel
    {
    }

    [Serializable]
    public class AboutViewModel : ViewModel
    {
    }
}