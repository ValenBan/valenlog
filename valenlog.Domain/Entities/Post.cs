using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Domain.Entities
{
    public class Post
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string id { get; set; }
        public string title { get; set; }

        public int totalReactions { get; set; }
    }
}
