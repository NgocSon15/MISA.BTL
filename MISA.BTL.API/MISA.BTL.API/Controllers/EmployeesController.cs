using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BTL.Business;
using MISA.BTL.Business.Interfaces;
using MISA.BTL.Common;
using MySql.Data.MySqlClient;

namespace MISA.BTL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeBusiness _employeeBusiness;
        public EmployeesController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeBusiness.GetEmployees());
        }

        [HttpGet("search")]
        public IActionResult GetByCode([FromQuery] string code)
        {
            return Ok(_employeeBusiness.GetEmployeeByCode(code));
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_employeeBusiness.GetEmployeeById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            var res = _employeeBusiness.Insert(employee);
            switch (res.MISACode)
            {
                case MISAEnum.BadRequest:
                    return BadRequest(res);
                case MISAEnum.Success:
                    return Ok(res);
                case MISAEnum.Exception:
                    return StatusCode(500);
                default:
                    return NoContent();
            }
        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            var res = _employeeBusiness.Update(employee);
            switch (res.MISACode)
            {
                case MISAEnum.BadRequest:
                    return BadRequest(res);
                case MISAEnum.Success:
                    return Ok(res);
                case MISAEnum.Exception:
                    return StatusCode(500);
                default:
                    return NoContent();
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Employee employee)
        {
            return Ok(_employeeBusiness.Delete(employee));
        }
    }
}
