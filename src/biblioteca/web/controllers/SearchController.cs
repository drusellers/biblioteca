namespace biblioteca.web.controllers
{
    using System;
    using System.Collections.Generic;
    using display_models;
    using domain.searching;

    public class SearchController
    {
        private readonly Search _searcher;

        public SearchController(Search searcher)
        {
            _searcher = searcher;
        }

        public SearchViewModel Index(SearchSetupViewModel inModel)
        {
            SearchResults result = _searcher.Find(inModel.Terms);

            var view = new SearchViewModel
                       {
                           NumberOfHits = result.HitCount,
                           TermsUsedInSearch = inModel.Terms
                       };

            foreach (Result searchResult in result)
            {
                view.Results.Add(new SearchResultDisplay {Name = searchResult.Name, Description = searchResult.Description});
            }

            return view;
        }

        public ReindexViewModel Reindex(ReindexSetupViewModel inModel)
        {
            _searcher.Index();

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
        public SearchViewModel()
        {
            Results = new List<SearchResultDisplay>();
        }

        public int NumberOfHits { get; set; }
        public IList<SearchResultDisplay> Results { get; set; }
        public string TermsUsedInSearch { get; set; }
    }


    public class ReindexSetupViewModel : ViewModel
    {
    }

    [Serializable]
    public class ReindexViewModel : ViewModel
    {
        public int NumberOfDocumentsIndexed { get; set; }
    }
}