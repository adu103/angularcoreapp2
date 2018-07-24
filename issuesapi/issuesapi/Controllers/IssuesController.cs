using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using issuesapi.Models;
using Microsoft.Extensions.Logging;

namespace issuesapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly IssueContext _context;
        private readonly ILogger<IssuesController> _logger;

        public IssuesController(IssueContext context, ILogger<IssuesController> logger)
        {
            _context = context;
            _logger = logger;

            if (_context.Issues.Count() == 0)
            {
                _context.Issues.Add(new Issues { title = "title1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Issues>> GetAll()
        {
            _logger.LogInformation("This is a test of the GetAll method", null);
            _logger.LogDebug("This is a debug of the GetAll method", null);
            return _context.Issues.ToList();
        }

        [HttpGet("{id}", Name = "GetIssue")]
        public ActionResult<Issues> GetById(long id)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                return NotFound();
            }
            return issue;
        }

        [HttpPost]
        public IActionResult Create(Issues issue)
        {
            _context.Issues.Add(issue);
            _context.SaveChanges();

            return CreatedAtRoute("GetIssue", new { id = issue.Id }, issue);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Issues item)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                return NotFound();
            }

            issue.title = item.title;
            issue.responsible = item.responsible;
            issue.description = item.description;
            issue.severity = item.severity;
            issue.status = item.status;

            _context.Issues.Update(issue);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                return NotFound();
            }

            _context.Issues.Remove(issue);
            _context.SaveChanges();
            return NoContent();
        }
    }


}
