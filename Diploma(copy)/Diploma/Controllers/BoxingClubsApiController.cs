using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Diploma.ViewModels.Boxers;
using Diploma.ViewModels.BoxingClubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Controllers
{
    [Route("api/boxingClubs")]
    [ApiController]
    public class BoxingClubsApiController:ControllerBase
    {
        
        
        private readonly BoxContext _context;
        private readonly IMapper _mapper;

        public BoxingClubsApiController(BoxContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] // GET: /api/boxers
        [ProducesResponseType(200, Type = typeof(IEnumerable<BoxingClubsViewModel>))]  
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<BoxingClubsViewModel>> GetBoxingClubs()
        {
            var boxingClubs = _mapper.Map<IEnumerable<BoxingClubs>, IEnumerable<BoxingClubsViewModel>>(_context.BoxingClubs.ToList());
            return Ok(boxingClubs);
        }
        
        
        
        [HttpGet("{id}")] // GET: /api/boxers/5
        [ProducesResponseType(200, Type = typeof(BoxingClubsViewModel))]  
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var boxingClub = _mapper.Map<BoxingClubsViewModel>(_context.BoxingClubs.FirstOrDefault(m => m.BoxingClubId == id));
            if (boxingClub == null) return NotFound();  
            return Ok(boxingClub);
        }
        
        [HttpPost] // POST: api/boxers
        public ActionResult<InputBoxingClubsViewModel> PostBoxingClubs(InputBoxingClubsViewModel inputModel)
        {
            
            var boxingClub = _context.Add(  _mapper.Map<BoxingClubs>(inputModel)).Entity;
            _context.SaveChanges();
            var boxingClubs = _mapper.Map<IEnumerable<BoxingClubs>, IEnumerable<BoxingClubsViewModel>>(_context.BoxingClubs.ToList());
            return Ok(boxingClubs);

           // return CreatedAtAction("GetById", new { id = boxingClub.BoxingClubId }, _mapper.Map<InputBoxingClubsViewModel>(inputModel));
        }
        
        [HttpPut("{id}")] // PUT: api/boxers/5
        public IActionResult UpdateBoxingClub(int id, EditBoxingClubsViewModel editModel)
        {
            try
            {
                var boxingClub = _mapper.Map<BoxingClubs>(editModel);
                boxingClub.BoxingClubId = id;
                
                _context.Update(boxingClub);
                _context.SaveChanges();
                var boxingClubs = _mapper.Map<IEnumerable<BoxingClubs>, IEnumerable<BoxingClubsViewModel>>(_context.BoxingClubs.ToList());
                return Ok(boxingClubs);
                // return Ok(_mapper.Map<EditBoxingClubsViewModel>(boxingClub));
            }
            catch (DbUpdateException)
            {
                if (!BoxingClubsExists(id))
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
        public ActionResult<DeleteBoxingClubsViewModel> DeleteBoxingClubs(int id)
        {
            var boxingClub = _context.BoxingClubs.Find(id);
            if (boxingClub == null) return NotFound();  
            _context.BoxingClubs.Remove(boxingClub);
            _context.SaveChanges();
          
            var boxingClubs = _mapper.Map<IEnumerable<BoxingClubs>, IEnumerable<BoxingClubsViewModel>>(_context.BoxingClubs.ToList());
            return Ok(boxingClubs);
           // return Ok(_mapper.Map<DeleteBoxingClubsViewModel>(boxingClub));
        }

        private bool BoxingClubsExists(int id)
        {
            return _context.BoxingClubs.Any(e => e.BoxingClubId == id);
        }
        
    }
}