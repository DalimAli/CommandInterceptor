namespace CommandInterceptor.Models
{
    public class Author: Audit
    {
        public long Id{ get; set; } 
        public string Name { get; set; }
    }
}
