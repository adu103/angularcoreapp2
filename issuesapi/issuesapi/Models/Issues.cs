namespace issuesapi.Models
{
    public class Issues
    {
        public long Id { get; set; }
        public string title { get; set; }
        public string responsible { get; set; }
        public string description { get; set; }
        public string severity { get; set; }
        public string status { get; set; }

    }
}
