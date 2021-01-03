using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.BTL.Common;
using MISA.BTL.Database;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.BTL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        DbConnector dbConnector;
        public PositionsController()
        {
            dbConnector = new DbConnector();
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dbConnector.GetAllData<Position>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(dbConnector.GetDataById<Position>(id));
        }

        [HttpPost]
        public IActionResult Post(Position position)
        {
            return Ok(dbConnector.Insert<Position>(position));
        }


    }
}
