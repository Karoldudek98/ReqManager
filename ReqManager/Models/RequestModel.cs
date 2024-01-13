using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReqManager.Models

{
    public class RequestModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ShortDescription { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string Comment { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public RequestStatus Status { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        public string UserId { get; set; }
    }
}
