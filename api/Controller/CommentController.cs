using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using api.mapper;
using api.model;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/commnet")]
    [ApiController]
    public class CommentController(ICommentRepo commentRepo) : ControllerBase
    {
        private readonly ICommentRepo _commnetRepo = commentRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Commnets = await _commnetRepo.GetAll();
            var commnetsDto = Commnets.Select(e => e.ToCommentDto());
            return Ok(Commnets);

        }
    }
}