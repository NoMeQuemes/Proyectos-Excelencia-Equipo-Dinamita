using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net;
using TodoList_API.Data;
using TodoList_API.Models;
using TodoList_API.Models.Dto;

namespace TodoList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TareasController : ControllerBase
    {
        private readonly ILogger<TareasController> _logger;
        private readonly ApplicationDbContext _db;
        protected ApiResponse _response;

        public TareasController(ILogger<TareasController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _response = new();
        }

        //------------------- EndPoint que trae la lista completa de tareas -------------------
        [HttpGet]
        [Route("ListarTareas")]
        public async Task<ActionResult<ApiResponse>> GetTareas()
        {
            try
            {
                _logger.LogInformation("Obtener las tareas");

                _response.Resultado = await _db.Tareas.ToListAsync();
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        //------------- EndPoint que trae un dato de la lista a través de la id --------------
        [HttpGet]
        [Route("ListarPorId/{id}")]

        public async Task<ActionResult<TareasDto>> GetTarea(int id)
        {
            try
            {
                var tarea = await _db.Tareas.FirstOrDefaultAsync(e => e.Id == id);

                if (id == 0)
                {
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (tarea == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Resultado = tarea;
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);
        }

        //------------------------ EndPoint que crea nuevas tareas -------------------------
        [HttpPost]
        [Route("CrearTarea")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CrearTarea([FromBody] TareasDto tareaDto)
        {
            try
            {
                if (tareaDto == null)
                {
                    return BadRequest(tareaDto);
                }
                else if (tareaDto.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                Tarea modelo = new()
                {
                    Titulo = tareaDto.Titulo,
                    Detalle = tareaDto.Detalle,
                    UsuarioCreador = tareaDto.UsuarioCreador,
                    FechaCreacion = tareaDto.FechaCreacion,
                    FechaActualizacion = tareaDto.FechaActualizacion,
                    FechaEliminacion = tareaDto.FechaEliminacion
                };

                await _db.Tareas.AddAsync(modelo);
                await _db.SaveChangesAsync();
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;

                return (_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        //---------------- EndPoint que elimina registros de la base de datos -------------------
        [HttpDelete]
        [Route("EliminarTarea/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> EliminarTarea(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var DataTarea = await _db.Tareas.FirstOrDefaultAsync(e => e.Id == id);
                if (DataTarea == null)
                {
                    _response.IsExitoso=false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _db.Tareas.Remove(DataTarea);
                await _db.SaveChangesAsync();

                _response.statusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);

        }

        //--------------- EndPoint que actualiza un registro en la base de datos ------------
        [HttpPut]
        [Route("ActualizarTarea/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> ActualizaTarea(int id, [FromBody] TareasDto tareaDto)
        {
            if (tareaDto == null)
            {
                _response.IsExitoso = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            Tarea modelo = new()
            {
                Id = tareaDto.Id,
                Titulo = tareaDto.Titulo,
                Detalle = tareaDto.Detalle,
                UsuarioCreador = tareaDto.UsuarioCreador,
                FechaCreacion = tareaDto.FechaCreacion,
                FechaActualizacion = tareaDto.FechaActualizacion,
                FechaEliminacion = tareaDto.FechaEliminacion,

            };

            _db.Tareas.Update(modelo);
            await _db.SaveChangesAsync();
            _response.statusCode = HttpStatusCode.NoContent;
            return Ok(_response);

        }
    }
}
