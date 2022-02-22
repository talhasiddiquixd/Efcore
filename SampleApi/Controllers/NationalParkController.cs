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
    [AllowAnonymous]
    public class NationalParkController : ControllerBase
    {
        private INationalParkRepository _nrepo;
        private readonly IMapper _mapper;

        public NationalParkController(INationalParkRepository nrepo, IMapper mapper)
        {
            _nrepo = nrepo;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        //[FromQuery] PagingParameter pagingParameter
        {
            var objList=  _nrepo.GetNationalPark();
            //pagingParameter
            var objDto =new List<NationalParkDTO>();
            foreach(var obj in objList)
            {
                objDto.Add(_mapper.Map<NationalParkDTO>(obj));


            }
            return  Ok(objDto);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetNationalParks(int id)
        {
            var obj=_nrepo.GetNationalPark(id);
            if(obj==null)
            {
                return NotFound();
            }
            var objDTO = _mapper.Map<NationalParkDTO>(obj);
            return Ok(objDTO);


        }
        [HttpPost]
        public IActionResult CreateNationalPark([FromBody] NationalParkDTO parkDTO)
        {
            if(parkDTO==null)
            {
                return BadRequest(ModelState);

            }
            if(_nrepo.NationalParkExists(parkDTO.Name!))
            {
                ModelState.AddModelError("", "National Park Exsits");
                return StatusCode(404, ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var nationalParkDTOobj= _mapper.Map<NationalPark>(parkDTO);
            if(!_nrepo.CreateNationalPark(nationalParkDTOobj))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);

            }
            return Ok(nationalParkDTOobj);
        }
        [HttpPut("id", Name = "Update") ]
        public IActionResult Update(int id, [FromBody] NationalParkDTO parkDTO)
        {
            if (parkDTO==null||parkDTO.Id!=id)
            {
                return BadRequest(ModelState);
            }
            var nationalParkDTOobj = _mapper.Map<NationalPark>(parkDTO);
            nationalParkDTOobj.CreatedAt=null;
            if (!_nrepo.UpdateNationalPark(nationalParkDTOobj))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);

            }
                return Ok(nationalParkDTOobj);
        }

        [HttpDelete("id", Name = "Delete")]
        public IActionResult Delete(int id )
        {
            var obj=_nrepo.GetNationalPark(id);
            if (!_nrepo.DeleteNationalPark(obj))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);

            }
            return Ok("ObjectDeleted");
        }

    }
}
