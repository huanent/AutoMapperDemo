using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapperDemo.Model;
using AutoMapperDemo.Data;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace AutoMapperDemo.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        AppDbContext _context;
        public ValuesController(AppDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _context.Persons.AddRange(new Person[] {
                new Person{Age=25,Name="张三" },
                new Person{Age=26,Name="李四" },
                new Person{Age=27,Name="王五" },
            });
            _context.SaveChanges();
            var projectTo = _context.Persons.ProjectTo<PersonDtos>();
            var result = projectTo.ToArray();
            return new string[] { "value1", "value2" };
        }
    }
}
