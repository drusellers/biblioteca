namespace biblioteca.web.controllers
{
    using System;
    using System.Collections.Generic;
    using display_models;
    using domain;

    public class PackageController
    {
        public PackageViewModel Index(PackageSetupViewModel inModel)
        {
            var list = new List<SoftwarePackageDisplay>();

            var model = new PackageViewModel();

            list.Add(new SoftwarePackageDisplay(new SoftwarePackage(){Name = "baretail", Description = "tail tool"}));
            list.Add(new SoftwarePackageDisplay(new SoftwarePackage(){Name = "baregrep", Description = "grep tool"}));
            list.Add(new SoftwarePackageDisplay(new SoftwarePackage(){Name = "notepad++", Description = "notepad replacement"}));

            model.Packages = list;

            return model;
        }
    }


    public class PackageSetupViewModel : ViewModel
    {
    }

    [Serializable]
    public class PackageViewModel : ViewModel
    {
        public IList<SoftwarePackageDisplay> Packages { get; set; }
    }
}