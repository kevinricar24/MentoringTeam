﻿using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> heroes = new List<SuperHero>()
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Ironman",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Long Island"
            }
        };

        [HttpGet]
        public ActionResult<List<SuperHero>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public ActionResult<SuperHero> Get(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public ActionResult<List<SuperHero>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public ActionResult<List<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(x => x.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<SuperHero>> Delete(int id)
        {
            var hero = heroes.Find(x => x.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
