using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;

namespace BlogApp.Models
{
    public class PostCreateViewModel
    {
        public int PostId { get; set; }
        [Required]
        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string? Content { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string? Url { get; set; }
        public bool IsActive { get; set; }
        public List<Tag> Tags { get; set; } = new();
    }
}