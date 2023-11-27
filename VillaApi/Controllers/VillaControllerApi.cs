using Microsoft.AspNetCore.Mvc;
using VillaApi.DataStore;
using VillaApi.Models;
using VillaApi.Models.Dto;

namespace VillaApi.Controllers
{
    [Route("api/[controller]")]
    public class VillaControllerApi : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()    
        {
            
            return Ok(VillaStore.GetVillas());
        }

        [HttpGet ("id")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(VillaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            var villa= VillaStore.GetVillas().FirstOrDefault(v => v.Id == id);
            if(id == 0)
            {
                return BadRequest();
            }
            if(villa == null)
               return NotFound();
            return villa;

        }
        [HttpPost]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaDto villa) 
        { 
            if(villa == null)
                return BadRequest();
            if(villa.Id == 0)
            {
                villa.Id = VillaStore.GetVillas().LastOrDefault().Id + 1;
                VillaStore.villaList.Add(villa);
                return Ok(villa.Name + " added"); 
            }
            return StatusCode(StatusCodes.Status505HttpVersionNotsupported);
        }


    }
}
