using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PfitBlogApplication.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Заголовок поста: ")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Ваш псевдоним: ")]
        public string AuthorName { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}