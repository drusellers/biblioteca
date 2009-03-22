namespace biblioteca.web
{
    using System.Security.Principal;

    public class ViewModel
    {
        public IIdentity CurrentUser { get; set; }
    }
}