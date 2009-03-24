namespace biblioteca.web.controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using display_models;
    using domain;

    public class PackageController
    {
        public PackageViewModel Index(PackageSetupViewModel inModel)
        {
            var model = new PackageViewModel();

            var packages = Repository.List().Select((package, result)=> new SoftwarePackageDisplay(package));

            model.Packages = packages;

            return model;
        }
    }


    public class PackageSetupViewModel : ViewModel
    {
    }

    [Serializable]
    public class PackageViewModel : ViewModel
    {
        public IEnumerable<SoftwarePackageDisplay> Packages { get; set; }
    }
}