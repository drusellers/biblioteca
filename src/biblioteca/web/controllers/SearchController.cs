namespace biblioteca.web.controllers
{
    using System;
    using System.Collections.Generic;
    using display_models;
    using domain;
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.QueryParsers;
    using Lucene.Net.Search;
    using Lucene.Net.Store;

    public class SearchController
    {
        public SearchViewModel Index(SearchSetupViewModel inModel)
        {
            Analyzer analyzer = new StandardAnalyzer();
            Directory directory = FSDirectory.GetDirectory("./index", true);
            // Now search the index:
            var isearcher = new IndexSearcher(directory);
            // Parse a simple query that searches for "text":
            //Query query = QueryParser.Parse("text", "fieldname", analyzer);
            var qp = new QueryParser("description", analyzer);
            Query query = qp.Parse(inModel.Terms);

            Hits hits = isearcher.Search(query);

            var view = new SearchViewModel()
                           {
                               NumberOfHits = hits.Length(),
                               TermsUsedInSearch = inModel.Terms
                           };
            // Iterate through the results:
            for (int i = 0; i < hits.Length(); i++)
            {
                Document hitDoc = hits.Doc(i);

                view.Results.Add(new SearchResultDisplay(){Name=hitDoc.Get("name"), Description = hitDoc.Get("description")});
            }
            isearcher.Close();
            directory.Close();

            return view;
        }

        public ReindexViewModel Reindex(ReindexSetupViewModel inModel)
        {
            Analyzer analyzer = new StandardAnalyzer();
            Directory directory = FSDirectory.GetDirectory("./index", true);
            var iwriter = new IndexWriter(directory, analyzer, true);
            iwriter.SetMaxFieldLength(25000);

            var x = Repository.List();
            foreach (var package in x)
            {
                var doc = new Document();
                doc.Add(new Field("name", package.Name, Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("description", package.Description, Field.Store.YES, Field.Index.TOKENIZED));
                iwriter.AddDocument(doc);
            }

            var view = new ReindexViewModel()
                           {
                               NumberOfDocumentsIndexed = iwriter.DocCount()
                           };

            iwriter.Close();
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
    



    public class ReindexSetupViewModel : ViewModel {}

    [Serializable]
    public class ReindexViewModel : ViewModel
    {
        public int NumberOfDocumentsIndexed { get; set; }
    }
}