namespace biblioteca.web.web_forms
{
    using System.Web.UI;

    public class BibliotecaMasterPage :
        MasterPage, IBibliotecaPage
        {
            object IBibliotecaPage.Model { get { return ((IBibliotecaPage)Page).Model; } }

            public ViewModel Model { get { return ((IBibliotecaPage)Page).Model as ViewModel; } }

            public void SetModel(object model)
            {
                throw new System.NotImplementedException();
            }
        
    }
}