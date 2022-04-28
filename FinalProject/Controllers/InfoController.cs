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
    public class InfoController : ControllerBase
    {
        private FinalDBContext _dbContext;
        public InfoController(FinalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetInfo")]
        public IActionResult Get()
        {
            try
            {
                var info = _dbContext.InfoTable.ToList();
                if(info.Count == 0)
                {
                    return NotFound();
                }
                return Ok(info); 
            }
            catch(Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPost("CreateInfo")]
        public IActionResult Create([FromBody] InfoRequest request)
        {
            InfoRequest newInfo = new InfoRequest();
            newInfo.FirstName = request.FirstName;
            newInfo.LastName = request.LastName;
            newInfo.Birthdate = request.Birthdate;
            newInfo.College_Program = request.College_Program;
            newInfo.Program_Year = request.Program_Year;

            try
            {
                _dbContext.InfoTable.Add(newInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.InfoTable.ToList();
            return Ok(allInfo);
        }

        [HttpPut("UpdateInfo")]
        public IActionResult Update([FromBody] InfoRequest request)
        {
            try
            {
                var newInfo = _dbContext.InfoTable.FirstOrDefault(x => x.FirstName == request.FirstName);
                if(newInfo == null)
                {
                    return NotFound();
                }
                newInfo.FirstName = request.FirstName;
                newInfo.LastName = request.LastName;
                newInfo.Birthdate = request.Birthdate;
                newInfo.College_Program = request.College_Program;
                newInfo.Program_Year = request.Program_Year;

                _dbContext.Entry(newInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.InfoTable.ToList();
            return Ok(allInfo);
        }

        [HttpDelete("DeleteInfo/{FirstName}")]
        public IActionResult Delete([FromRoute] string FirstName)
        {
            try
            {
                var newInfo = _dbContext.InfoTable.FirstOrDefault(x => x.FirstName == FirstName);
                if (newInfo == null)
                {
                    return NotFound();
                }

                _dbContext.Entry(newInfo).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
            catch(Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.InfoTable.ToList();
            return Ok(allInfo);
        }
    }
}
