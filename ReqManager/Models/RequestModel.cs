using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReqManager.Models

{
    public class RequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
        [Required]
        public RequestStatus Status { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
