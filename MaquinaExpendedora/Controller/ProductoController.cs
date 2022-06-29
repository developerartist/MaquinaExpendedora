using AutoMapper;
using MaquinaExpendedora.DTO;
using MaquinaExpendedora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaquinaExpendedora.Controller
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDBContext context;
        private readonly IMapper _mapper;
        public ProductoController(AppDBContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            try
            {
                return Ok(context.Productos.Include(x => x.Piezas).ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "GetProducto")]
        public ActionResult<Producto> Get(int id)
        {
            try
            {
                var producto = context.Productos.Include(x => x.Piezas).FirstOrDefault(p => p.Id_producto == id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        // GET api/<ProductoController>/5
        [HttpGet("{nombre:string}")]
        public ActionResult<Producto> Get(string nombre)
        {
            try
            {
                var producto = context.Productos.Include(x => x.Piezas).FirstOrDefault(p => p.nombre_producto.Contains(nombre));
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductoDTO prodto)
        {
            try
            {
                var last = Convert.ToInt32(context.Productos.ToList());
                Producto prod = _mapper.Map<Producto>(prodto);
                if(last == 5)
                {
                    return BadRequest("El numero de productos esta completo");
                }
                else
                {
                    context.Productos.Add(prod);
                    context.SaveChanges();
                    return Ok();
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (producto.Id_producto == id)
                {
                    context.Entry(producto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProducto", new { id = producto.Id_producto }, producto);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try {
                var producto = context.Productos.FirstOrDefault(x => x.Id_producto == id);
                if (producto != null)
                {
                    context.Productos.Remove(producto);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
