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
    public class FavoriteController : ControllerBase
    {
        private FinalDBContext _dbContext;
        public FavoriteController(FinalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetFavorites")]
        public IActionResult Get()
        {
            try
            {
                var info = _dbContext.FavoritesTable.ToList();
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

        [HttpPost("CreateFavorites")]
        public IActionResult Create([FromBody] FavoritesRequest request)
        {
            FavoritesRequest newInfo = new FavoritesRequest();
            newInfo.FirstName = request.FirstName;
            newInfo.FavFood = request.FavFood;
            newInfo.FavFruit = request.FavFruit;
            newInfo.FavColor = request.FavColor;
            newInfo.FavIceCream = request.FavIceCream;

            try
            {
                _dbContext.FavoritesTable.Add(newInfo);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.FavoritesTable.ToList();
            return Ok(allInfo);
        }

        [HttpPut("UpdateFavorites")]
        public IActionResult Update([FromBody] FavoritesRequest request)
        {
            try
            {
                var newInfo = _dbContext.FavoritesTable.FirstOrDefault(x => x.FirstName == request.FirstName);
                if (newInfo == null)
                {
                    return NotFound();
                }
                newInfo.FirstName = request.FirstName;
                newInfo.FavFood = request.FavFood;
                newInfo.FavFruit = request.FavFruit;
                newInfo.FavColor = request.FavColor;
                newInfo.FavIceCream = request.FavIceCream;

                _dbContext.Entry(newInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }

            var allInfo = _dbContext.FavoritesTable.ToList();
            return Ok(allInfo);
        }

        [HttpDelete("DeleteFavorites/{FirstName}")]
        public IActionResult Delete([FromRoute] string FirstName)
        {
            try
            {
                var newInfo = _dbContext.FavoritesTable.FirstOrDefault(x => x.FirstName == FirstName);
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

            var allInfo = _dbContext.FavoritesTable.ToList();
            return Ok(allInfo);
        }
    }
}
