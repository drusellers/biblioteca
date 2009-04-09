namespace biblioteca.domain.searching.lucene
{
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.QueryParsers;
    using Lucene.Net.Search;
    using Lucene.Net.Store;

    public class LuceneSearch :
        Search
    {
        private readonly Analyzer _analyzer = new StandardAnalyzer();

        public SearchResults Find(string terms)
        {
            Directory directory = FSDirectory.GetDirectory("./index",false);
            // Now search the index:
            var isearcher = new IndexSearcher(directory);
            // Parse a simple query that searches for "text":
            //Query query = QueryParser.Parse("text", "fieldname", analyzer);
            var qp = new QueryParser("description", _analyzer);
            Query query = qp.Parse(terms);

            Hits hits = isearcher.Search(query);

            var sr = new SearchResults();

            // Iterate through the results:
            for (int i = 0; i < hits.Length(); i++)
            {
                Document hitDoc = hits.Doc(i);

                sr.Add(new Result() { Name = hitDoc.Get("name"), Description = hitDoc.Get("description") });
            }
            isearcher.Close();
            directory.Close();

            return sr;           
        }
        
        public void Index()
        {
            Directory directory = FSDirectory.GetDirectory("./index", true);
            var iwriter = new IndexWriter(directory, _analyzer, true);
            iwriter.SetMaxFieldLength(25000);

            var x = Repository.List();
            foreach (var package in x)
            {
                var doc = new Document();
                doc.Add(new Field("name", package.Name, Field.Store.YES, Field.Index.TOKENIZED));
                doc.Add(new Field("description", package.Description, Field.Store.YES, Field.Index.TOKENIZED));
                iwriter.AddDocument(doc);
            }

            iwriter.Close();
        }
    }
}