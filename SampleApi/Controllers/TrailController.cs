using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi.Mapper;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrailController : ControllerBase
    {
        private readonly ITrailRepository _trailRepo;
        private readonly IMapper _mapper;
        public TrailController(ITrailRepository trailRepo, IMapper mapper)
        {
            _trailRepo = trailRepo;
            _mapper = mapper;
        } 
        [HttpGet]
        public IActionResult GetTrail([FromQuery]PagingParameter paging)
        {

            var objList = _trailRepo.GetTrail(paging);
            var objDto = new List<TrialDTO>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<TrialDTO>(obj));


            }
            return Ok(objDto);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetTrailById(int id)
        {
            var obj = _trailRepo.GetTrailById(id);
            if (obj==null)
            {
                return NotFound();
            }
            var objDTO = _mapper.Map<TrialDTO>(obj);
            return Ok(objDTO);


        }
        [HttpPost]
        public IActionResult CreateTrial([FromBody] TrailRequestDTO trialDTO)
        {
            if (trialDTO==null)
            {
                return BadRequest(ModelState);

            }
            if (_trailRepo.TrailExists(trialDTO.Name!))
            {
                ModelState.AddModelError("", "National Park Exsits");
                return StatusCode(404, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objDTO = _mapper.Map<Trail>(trialDTO);
            if (!_trailRepo.CreateTrail(objDTO))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);

            }
            return Ok(objDTO);
        }
        [HttpPut("id", Name = "UpdateTrail")]
        public IActionResult Update(int id, [FromBody] TrailUpdateDTO trailDTO)
        {
            if (trailDTO==null||trailDTO.Id!=id)
            {
                return BadRequest(ModelState);
            }
            var objDto = _mapper.Map<Trail>(trailDTO);
           
            if (!_trailRepo.UpdateTrail(objDto))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);

            }
            return Ok(objDto);
        }

        [HttpDelete("id", Name = "DeleteTrail")]
        public IActionResult Delete(int id)
        {
            var obj = _trailRepo.GetTrailById(id);
            if (!_trailRepo.DeleteTrail(obj))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);

            }
            return Ok("ObjectDeleted");
        }

    }

}
