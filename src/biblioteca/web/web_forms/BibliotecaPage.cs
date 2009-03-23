namespace biblioteca.web.web_forms
{
    using System.Web.UI;
    using FubuMVC.Core.View;

    public class BibliotecaPage<MODEL> : 
        Page, IBibliotecaPage, IFubuView<MODEL> where MODEL : ViewModel
    {
        public void SetModel(object model)
        {
            Model = (MODEL)model;
        }

        public ViewModel GetModel()
        {
            return Model;
        }

        public MODEL Model { get; set; }

        object IBibliotecaPage.Model { get { return Model; } }
    }
}