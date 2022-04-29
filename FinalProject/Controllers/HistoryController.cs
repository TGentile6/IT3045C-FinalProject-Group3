using System;
using System.Linq;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private FinalDBContext _dbContext;
        public HistoryController(FinalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetHistory")]
        public IActionResult Get()
        {
            try
            {
                var info = _dbContext.HistoryTable.ToList();
                if (info.Count == 0)
                {
                    return NotFound();
                }
                return Ok(info);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPost("CreateHistory")]
        public IActionResult Create([FromBody] HistoryRequest request)
        {
            HistoryRequest newInfo = new HistoryRequest();
            newInfo.FirstName = request.FirstName;
            newInfo.Hometown = request.Hometown;
            newInfo.State = request.State;
            newInfo.HS = request.HS;
            newInfo.HSGradYear = request.HSGradYear;

            try
            {
                Console.WriteLine(request);
                _dbContext.HistoryTable.Add(request);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.HistoryTable.ToList();
            return Ok(allInfo);
        }

        [HttpPut("UpdateHistory")]
        public IActionResult Update([FromBody] HistoryRequest request)
        {
            try
            {
                var newInfo = _dbContext.HistoryTable.FirstOrDefault(x => x.FirstName == request.FirstName);
                if (newInfo == null)
                {
                    return NotFound();
                }
                newInfo.FirstName = request.FirstName;
                newInfo.Hometown = request.Hometown;
                newInfo.State = request.State;
                newInfo.HS = request.HS;
                newInfo.HSGradYear = request.HSGradYear;

                _dbContext.Entry(newInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.HistoryTable.ToList();
            return Ok(allInfo);
        }

        [HttpDelete("DeleteHistory/{FirstName}")]
        public IActionResult Delete([FromRoute] string FirstName)
        {
            try
            {
                var newInfo = _dbContext.HistoryTable.FirstOrDefault(x => x.FirstName == FirstName);
                if (newInfo == null)
                {
                    return NotFound();
                }

                _dbContext.Entry(newInfo).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.HistoryTable.ToList();
            return Ok(allInfo);
        }
    }
}
