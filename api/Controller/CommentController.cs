using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.dto.comment;
using api.interfaces;
using api.mapper;
using api.model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/commnet")]
    [ApiController]
    public class CommentController(ICommentRepo commentRepo, IStockRepo stockRepo) : ControllerBase
    {
        private readonly ICommentRepo _commnetRepo = commentRepo;
        private readonly IStockRepo _stockRepo = stockRepo;


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Commnets = await _commnetRepo.GetAll();
            var commnetsDto = Commnets.Select(e => e.ToCommentDto());
            return Ok(Commnets);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            Comment? comment = await _commnetRepo.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(comment.ToCommentDto());
            }
        }

        [HttpPost("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentDto createComment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _stockRepo.IsStockExits(stockId))
            {
                return BadRequest("Stock is not found");
            }
            else
            {
                var commentModel = createComment.ToCommentFromCreate(stockId);
                await _commnetRepo.Create(commentModel);
                return CreatedAtAction(nameof(GetById), new { id = commentModel }, commentModel.ToCommentDto());
            }
        }

        [HttpPut]
        [Route("{commentId:int}")]
        public async Task<IActionResult> Update([FromRoute] int commentId, UpdateCommentDto updateCommentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _commnetRepo.IsCommentExits(commentId))
            {
                return BadRequest("Comment is not found");
            }
            else
            {
                var commentModel = updateCommentDto.ToCommentFromUpdate();
                await _commnetRepo.Update(commentId, updateCommentDto);
                return Ok(commentModel.ToCommentDto());
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var commnet = await _commnetRepo.Delete(id);

            if (commnet == null)
            {
                return NotFound("Comment is not found");
            }
            else
            {
                return NoContent();
            }
        }

    }
}