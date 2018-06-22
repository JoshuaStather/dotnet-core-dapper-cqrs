﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Dapper.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Dapper.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ICommandsProcessor _commandProcessor;

        public ValuesController(ICommandsProcessor commandProcessor)
        {
            _commandProcessor = commandProcessor;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _commandProcessor.Process(new AddBook("Name", "Title"));
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}