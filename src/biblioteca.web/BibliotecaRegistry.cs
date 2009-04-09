namespace biblioteca.web
{
    using domain.searching;
    using domain.searching.lucene;
    using StructureMap.Configuration.DSL;

    public class BibliotecaRegistry : Registry
    {
        public BibliotecaRegistry()
        {
            this.ForRequestedType<Search>().TheDefaultIsConcreteType<LuceneSearch>().AsSingletons();
        }
    }
}