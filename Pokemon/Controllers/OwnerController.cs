using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Dto;
using Pokemon.Interfaces;
using Pokemon.Models;

namespace Pokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepositroy _ownerRepositroy;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepositroy ownerRepositroy, ICountryRepository countryRepository, IMapper mapper)
        {
            _ownerRepositroy = ownerRepositroy;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int countryId, [FromBody] OwnerDto ownerDto)
        {
            if (ownerDto == null)
                return BadRequest(ModelState);

            var owners = _ownerRepositroy.GetOwners()
                .Where(c => c.LastName.Trim().ToUpper() == ownerDto.LastName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (owners != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(442, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ownerMap = _mapper.Map<Owner>(ownerDto);
            ownerMap.Country = _countryRepository.GetCountry(countryId);

            if (!_ownerRepositroy.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "something went wrong in saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Created");
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _ownerRepositroy.GetOwners();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepositroy.OwnerExists(ownerId))
                return NotFound();
            var owner = _mapper.Map<OwnerDto>(_ownerRepositroy.GetOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(owner);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200,Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if (!_ownerRepositroy.OwnerExists(ownerId))
                return NotFound();
            var owner = _mapper.Map<List<PokemonDto>>(_ownerRepositroy.GetPokemonsFormAOwner(ownerId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(owner);
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOwner(int ownerId, [FromBody]OwnerDto ownerDto)
        {
            if (ownerDto == null)
                return BadRequest(ModelState);
            if(ownerId != ownerDto.Id)
                return BadRequest(ModelState);
            if(!_ownerRepositroy.OwnerExists(ownerId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var ownerMap = _mapper.Map<Owner>(ownerDto);
            if(!_ownerRepositroy.UpdateOwner(ownerMap))
            {
                ModelState.AddModelError("", "something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOwner(int ownerId)
        {
            if(!_ownerRepositroy.OwnerExists(ownerId))
            {
                return NotFound();
            }

            var ownerToDelete = _ownerRepositroy.GetOwner(ownerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_ownerRepositroy.DeleteOwner(ownerToDelete))
                ModelState.AddModelError("", "something went wrong while deleting the owner");

            return NoContent();
        }

    }
}
