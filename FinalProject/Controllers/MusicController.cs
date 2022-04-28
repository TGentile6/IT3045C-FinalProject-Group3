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
    public class MusicController : ControllerBase
    {
        private FinalDBContext _dbContext;
        public MusicController(FinalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetMusic")]
        public IActionResult Get()
        {
            try
            {
                var info = _dbContext.MusicTable.ToList();
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

        [HttpPost("CreateMusic")]
        public IActionResult Create([FromBody] MusicRequest request)
        {
            MusicRequest newInfo = new MusicRequest();
            newInfo.FirstName = request.FirstName;
            newInfo.FavGenre = request.FavGenre;
            newInfo.Num_Concerts_Attended = request.Num_Concerts_Attended;
            newInfo.Last_Concert = request.Last_Concert;
            newInfo.Music_Platform = request.Music_Platform;

            try
            {
                _dbContext.MusicTable.Add(newInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.MusicTable.ToList();
            return Ok(allInfo);
        }

        [HttpPut("UpdateMusic")]
        public IActionResult Update([FromBody] MusicRequest request)
        {
            try
            {
                var newInfo = _dbContext.MusicTable.FirstOrDefault(x => x.FirstName == request.FirstName);
                if (newInfo == null)
                {
                    return NotFound();
                }
                newInfo.FirstName = request.FirstName;
                newInfo.FavGenre = request.FavGenre;
                newInfo.Num_Concerts_Attended = request.Num_Concerts_Attended;
                newInfo.Last_Concert = request.Last_Concert;
                newInfo.Music_Platform = request.Music_Platform;

                _dbContext.Entry(newInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.MusicTable.ToList();
            return Ok(allInfo);
        }

        [HttpDelete("DeleteMusic/{FirstName}")]
        public IActionResult Delete([FromRoute] string FirstName)
        {
            try
            {
                var newInfo = _dbContext.MusicTable.FirstOrDefault(x => x.FirstName == FirstName);
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

            var allInfo = _dbContext.MusicTable.ToList();
            return Ok(allInfo);
        }
    }
}
