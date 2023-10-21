namespace ReqManager.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}
