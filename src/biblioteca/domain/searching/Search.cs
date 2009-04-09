namespace biblioteca.domain.searching
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface Search
    {
        SearchResults Find(string terms);
        void Index();
    }
    public class SearchResults :
        IEnumerable<Result>
    {

        public int HitCount { get { return _results.Count; } }
        private readonly IList<Result> _results = new List<Result>();

        public void Add(Result result)
        {
            _results.Add(result);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Result> GetEnumerator()
        {
            return _results.GetEnumerator();
        }
    }
    public class Result
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}