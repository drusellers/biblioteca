namespace biblioteca.web.display_models
{
    using domain;

    public class SoftwarePackageDisplay
    {
        public SoftwarePackageDisplay(SoftwarePackage package)
        {
            Name = package.Name;
            Description = package.Description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}