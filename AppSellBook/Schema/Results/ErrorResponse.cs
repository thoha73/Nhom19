namespace AppSellBook.Schema.Results
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
