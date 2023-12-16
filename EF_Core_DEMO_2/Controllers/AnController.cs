using EF_Core_DEMO_2.Data;
using EF_Core_DEMO_2.DTOs;
using EF_Core_DEMO_2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_DEMO_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AnController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
        {
            var newCharacter = new Character
            {
                Name = request.Name,
            };

            Backpack backpack = new Backpack
            {
                Description = request.Backpack.Description
            };

            var weapons = request.Weapons.Select(w => new Weapon
            {
                Name = w.Name,
                Character = newCharacter
            }).ToList();

            var factions = request.Factions.Select(f => new Faction
            {
                Name = f.Name,
                Characters = new List<Character> { newCharacter },
            }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _dataContext.Characters.Add(newCharacter);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Characters
                                        .Include(c => c.Backpack)
                                        .Include(c => c.Weapons)
                                        .ToListAsync());
        } 
    }
}
