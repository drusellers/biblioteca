namespace biblioteca.web
{
    using FubuMVC.Core.View;

    public interface IBibliotecaPage : IFubuViewWithModel
    {
        object Model { get; }
    }
}