namespace Business.Models
{
    public class PaginationResultModel<T> where T : class
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public T? Data { get; set; }
    }
}
