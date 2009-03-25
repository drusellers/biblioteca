namespace biblioteca.web.controllers
{
    using System;

    public class SearchController
    {
        public SearchViewModel Index(SearchSetupViewModel inModel)
        {
            return new SearchViewModel(){TermsUsedInSearch = inModel.Terms};
        }

        public ReindexViewModel Reindex(ReindexSetupViewModel inModel)
        {
            return new ReindexViewModel();
        }
    }



    public class SearchSetupViewModel : ViewModel
    {
        public string Terms { get; set; }
    }
    [Serializable]
    public class SearchViewModel : ViewModel
    {
        public string TermsUsedInSearch { get; set; }
    }
    



    public class ReindexSetupViewModel : ViewModel {}

    [Serializable]
    public class ReindexViewModel : ViewModel {}
}