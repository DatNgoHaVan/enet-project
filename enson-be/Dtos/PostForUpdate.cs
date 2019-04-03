namespace enson_be.Dtos
{
    public class PostForUpdate
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public string Content { get; set; }
        public int? Status { get; set; }
        public long AvailableOptionsId { get; set; }
    }
}