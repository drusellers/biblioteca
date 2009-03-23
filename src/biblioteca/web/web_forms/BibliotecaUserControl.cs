namespace biblioteca.web.web_forms
{
    using System.Web.UI;
    using FubuMVC.Core.View;

    public class BibliotecaUserControl<MODEL> : UserControl, IBibliotecaPage, IFubuView<MODEL>
           where MODEL : class
        {
            public void SetModel(object model)
            {
                Model = (MODEL)model;
            }

            public object GetModel()
            {
                return Model;
            }

            public MODEL Model { get; set; }

            object IBibliotecaPage.Model { get { return Model; } }
               
    }
}