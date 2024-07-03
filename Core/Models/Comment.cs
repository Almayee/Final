using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Comment : BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MovieId { get; set; }
    }
}
