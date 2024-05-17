using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.dto.comment
{
    public class CreateCommentDto
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

    }
}