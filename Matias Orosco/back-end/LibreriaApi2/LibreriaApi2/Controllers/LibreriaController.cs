
using LibreriaApi.Datos;
using LibreriaApi.Modelos;
using LibreriaApi.Modelos.Dto;
using LibreriaApi2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibreriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibreriaController : ControllerBase
    {
        private readonly ILogger<LibreriaController> _logger;
        private readonly AplicationDbContext _db;
        protected Apiresponse _response;



        public LibreriaController(ILogger<LibreriaController> logger, AplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _response = new();

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Apiresponse>> GetLibrerias()
        {

            _logger.LogInformation("Obtener las librerias");

            _response.Resultado = await _db.librerias.ToListAsync();
            _response.statusCode = HttpStatusCode.OK;
            return Ok(_response);



        }


        [HttpGet("Id:int", Name = "GetLibreria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: 404)]
        public async Task< ActionResult<Apiresponse>> GetLibreria(int Id)
        {

            if (Id == 0)
            {
                _logger.LogError("Error al traer la Libreria con Id" + Id);
                return BadRequest();
            }

            // var libreria = LibreriaStore.libreriaList.FirstOrDefault(v => v.Id == Id);
            var libreria = await _db.librerias.FirstOrDefaultAsync(v => v.Id == Id); 

            if (libreria == null)
            {
                return NotFound();
            }

            _response.Resultado = libreria;
            return Ok(_response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task< ActionResult<Apiresponse>> LibreriaCrear([FromBody] LibreriaCreateDto CreateDto)
        {          
               if(!ModelState.IsValid)
               {
                return BadRequest(ModelState);
                
               }

            if (await _db.librerias.FirstOrDefaultAsync(v => v.Nombre.ToLower() == CreateDto.Nombre.ToLower()) != null)
                {
                ModelState.AddModelError("NOmbreExiste", "La libreria ya existe!");
                return BadRequest(ModelState);
               }

               if(CreateDto == null)
               {

                return BadRequest(CreateDto);
            }


            Libreria modelo = new()
            {

                Nombre = CreateDto.Nombre,
                Detalles = CreateDto.Detalles,
                Paginas = CreateDto.Paginas,
                Totales = CreateDto.Totales,
                Creador = CreateDto.Creador



            };
    


       
            
            await _db.librerias.AddAsync(modelo);
            _db.SaveChanges();
             return CreatedAtRoute("GetLibreria", new {id= modelo.Id}, modelo);
        }






        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <IActionResult> DeleteLibreria(int id) 
        {
            if(id==0)
            {
                return BadRequest();
            }
            var libreria=await _db.librerias.FirstOrDefaultAsync(v=>v.Id == id);
            if(libreria==null)
            {

                return NotFound();
            }
            _db.librerias.Remove(libreria);
           await _db.SaveChangesAsync();

                return NoContent();
        
        }


        [HttpPut("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLibreria(int Id, [FromBody] LibreriaUpdateDto libreriaDto)
        {
            if (libreriaDto == null || Id != libreriaDto.Id)
            {
                return BadRequest();
            }

            var libreria = await _db.librerias.FirstOrDefaultAsync(v => v.Id == Id);
            if (libreria == null)
            {
                return NotFound();
            }

            
            libreria.Nombre = libreriaDto.Nombre;
            libreria.Detalles = libreriaDto.Detalles;
            libreria.Paginas = libreriaDto.Paginas;
            libreria.Totales = libreriaDto.Totales;
            libreria.Creador = libreriaDto.Creador;

            await _db.SaveChangesAsync();

            return NoContent();
        }




        [HttpPatch("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartiaLibreria(int Id, JsonPatchDocument<LibreriaUpdateDto> patchDto)
        {
            if (patchDto == null || Id == 0)
            {
                return BadRequest();
            }

            var libreria = await _db.librerias.FirstOrDefaultAsync(v => v.Id == Id);
            if (libreria == null)
            {
                return BadRequest();
            }

            LibreriaUpdateDto libreriaDto = new()
            {
                Nombre = libreria.Nombre,
                Detalles = libreria.Detalles,
                Paginas = libreria.Paginas,
                Totales = libreria.Totales,
                Creador = libreria.Creador,
            };

            patchDto.ApplyTo(libreriaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Libreria modelo = new()
            {
                Nombre = libreriaDto.Nombre,
                Detalles = libreriaDto.Detalles,
                Paginas = libreriaDto.Paginas,
                Totales = libreriaDto.Totales,
                Creador = libreriaDto.Creador
            };

            _db.librerias.Update(modelo);
            await _db.SaveChangesAsync();

            return NoContent();
        }







    }
}