namespace biblioteca.web.views
{
    using display_models;
    using web.controllers;
    using web_forms;

    //master
    public class SiteMasterView : BibliotecaMasterPage { }

    //pages
    public class HomeIndexView : BibliotecaPage<PackageViewModel> { }

    //user controllers
    public class PackageInfo : BibliotecaUserControl<SoftwarePackageDisplay> { }
}