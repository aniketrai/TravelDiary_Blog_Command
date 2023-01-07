using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TravelDiaries.Blog.Command.Business.Interface;
using TravelDiaries.Blog.Command.Core.DTOs;
using TravelDiary.Blog.Command.Core.Extensions;

namespace Travel.Blog.Command.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogsController : ControllerBase
    {
        private readonly IValidator<BlogRequest> _validator;
        private readonly IBlogsManager _blogManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="manager"></param>
        public BlogsController(IValidator<BlogRequest> validator, IBlogsManager manager)
        {
            _validator = validator;
            _blogManager = manager;
        }


        /// <summary>
        /// Method: GET blog API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAsync")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {

            var result = await _blogManager.GetById(id, cancellationToken);

            if (result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);

            return Ok(result);
        }


        /// <summary>
        /// Method: Create blog API
        /// </summary>
        /// <param name="blogRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///     POST /Blogs
        ///     {
        ///        "title": "Test",
        ///        "htmlTemplate": "<html><body>Hi</body></html>"
        ///     }
        /// </remarks>
        /// <response code="201">Returns the newly submitted blog</response>
        /// <response code="400">If the request body is invalid</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] BlogRequest blogRequest, CancellationToken cancellationToken)
        {
            var model = await _validator.ValidateAsync(blogRequest);

            if (!model.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                model.AddToModelState(this.ModelState);

                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _blogManager.CreateBlog(blogRequest, cancellationToken);

            if (result.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);
            return CreatedAtRoute("GetAsync", new { id = result?.Result?.Id }, result?.Result);
        }


        /// <summary>
        /// Method: Update blog API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blogRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] BlogRequest blogRequest, CancellationToken cancellationToken)
        {
            var model = await _validator.ValidateAsync(blogRequest);

            if (!model.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                model.AddToModelState(this.ModelState);

                // re-render the view when validation failed.
                return BadRequest(ModelState);
            }

            var result = await _blogManager.UpdateBlog(id, blogRequest, cancellationToken);

            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return BadRequest(result);

            return NoContent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

    }
}
