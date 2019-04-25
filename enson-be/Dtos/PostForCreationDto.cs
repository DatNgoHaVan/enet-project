namespace enson_be.Dtos
{
    public class PostForCreationDto
    {
        public string Type { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public int? Status { get; set; }

        public long UserId { get; set; }
        
        public long AvailableOptionsId { get; set; }
    }
}