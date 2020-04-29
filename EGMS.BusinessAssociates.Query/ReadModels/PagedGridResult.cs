namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class PagedGridResult<DataType>
    {
        // TODO might should just make this IEnumerable<DataType>?
        // to make places that use it shorter.  Going with the more
        // flexible option for now.
        public DataType Data { get; set; }

        // 20200417 Ben asked that this be changed from TotalCount to Total.
        public int Total { get; set; }
        public string Errors { get; set; }
        public string AggregateResult { get; set; }
    }
}

