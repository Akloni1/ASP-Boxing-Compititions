using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Diploma.ViewModels.BoxingClubs;
using Diploma.ViewModels.Coaches;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Controllers
{
    [Route("api/coach")]
    [ApiController]
    public class CoachesApiController : ControllerBase
    {
        
         private readonly BoxContext _context;
        private readonly IMapper _mapper;

        public CoachesApiController(BoxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] // GET: /api/boxers
        [ProducesResponseType(200, Type = typeof(IEnumerable<CoachViewModel>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<CoachViewModel>> GetCoaches()
        {
            var coaches = _mapper.Map<IEnumerable<Coaches>, IEnumerable<CoachViewModel>>(_context.Coaches.ToList());
            return Ok(coaches);
        }
        
        
        
        [HttpGet("{id}")] // GET: /api/boxers/5
        [ProducesResponseType(200, Type = typeof(CoachViewModel))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var coach = _mapper.Map<CoachViewModel>(_context.Coaches.FirstOrDefault(m => m.CoachId == id));
            if (coach == null) return NotFound();  
            return Ok(coach);
        }
        
        [HttpPost] // POST: api/boxers
        public ActionResult<InputCoachViewModel> PostCoaches(InputCoachViewModel inputModel)
        {
            
            var coach = _context.Add(   _mapper.Map<Coaches>(inputModel)).Entity;
            _context.SaveChanges();
            
            var coaches = _mapper.Map<IEnumerable<Coaches>, IEnumerable<CoachViewModel>>(_context.Coaches.ToList());
            return Ok(coaches);

           // return CreatedAtAction("GetById", new { id = boxingClub.BoxingClubId }, _mapper.Map<InputBoxingClubsViewModel>(inputModel));
        }
        
        [HttpPut("{id}")] // PUT: api/boxers/5
        public IActionResult UpdateCoach(int id, EditCoachViewModel editModel)
        {
            try
            {
                var coach = _mapper.Map<Coaches>(editModel);
                coach.CoachId = id;
                
                _context.Update(coach);
                _context.SaveChanges();
                var coaches = _mapper.Map<IEnumerable<Coaches>, IEnumerable<CoachViewModel>>(_context.Coaches.ToList());
                return Ok(coaches);
                // return Ok(_mapper.Map<EditBoxingClubsViewModel>(boxingClub));
            }
            catch (DbUpdateException)
            {
                if (!CoachesExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }
        }
        
        [HttpDelete("{id}")] // DELETE: api/boxingClubs/5
        public ActionResult<DeleteCoachViewModel> DeleteCoach(int id)
        {
            var coach = _context.Coaches.Find(id);
            if (coach == null) return NotFound();  
            _context.Coaches.Remove(coach);
            _context.SaveChanges();
          
            var coaches = _mapper.Map<IEnumerable<Coaches>, IEnumerable<CoachViewModel>>(_context.Coaches.ToList());
            return Ok(coaches);
           // return Ok(_mapper.Map<DeleteBoxingClubsViewModel>(boxingClub));
        }

        private bool CoachesExists(int id)
        {
            return _context.BoxingClubs.Any(e => e.BoxingClubId == id);
        }
        
    }
}