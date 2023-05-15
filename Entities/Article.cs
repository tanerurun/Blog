using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Article")]
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        public string CategoryName { get; set; }
        public string ArticleDate { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int ReadingCount { get; set; }
        public string ArticleUrl { get; set; }
        public string Tags { get; set; }
    }
}
