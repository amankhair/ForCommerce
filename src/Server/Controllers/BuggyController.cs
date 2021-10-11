using System;
using Core.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            Guid id = new Guid("c8d10180-3eae-4226-9af4-bddf58182f72");
            var thing = _context.Products.Find(id);

            if (thing == null)
                return NotFound(new ApiResponse(404));

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            Guid id = new Guid("c8d10180-3eae-4226-9af4-bddf58182f72");
            var thing = _context.Products.Find(id);
            var thingDto = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(Guid id)
        {
            return Ok();
        }
    }
}