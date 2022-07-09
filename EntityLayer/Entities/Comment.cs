using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Content { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
