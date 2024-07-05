namespace Pokemon.Models
{
    public class ResponseAuthorDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public AuthorDto? author { get; set; }
        public List<AuthorDto>? authors { get; set; }
    }
}
