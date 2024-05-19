using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto.comment
{
    public class CreateCommentDto
    {
        [Required]
        [MaxLength(289, ErrorMessage = "Max Length is 280 charactor")]
        [MinLength(5, ErrorMessage = "Min Length is 5 charactor")]
        public string Title { get; set; } = "";
        [Required]
        [MaxLength(289, ErrorMessage = "Max Length is 280 charactor")]
        [MinLength(5, ErrorMessage = "Min Length is 5 charactor")]
        public string Content { get; set; } = "";

    }
}