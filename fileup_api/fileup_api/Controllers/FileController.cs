using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileup_api.Controllers
{
    [Route("[controller]")]
    public class FileController : Controller
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { sucess = true });
        }

        [HttpPost]
        [Route("/do")]
        public IActionResult Do([FromBody] string data)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile arquivo)
        {
            InternalData<IFormFile>.Add(arquivo);

            return Ok();
        }

        [HttpPost]
        public IActionResult Download()
        {
            return BadRequest();
        }
    }

    public static class InternalData<T>
    {
        private static readonly ConcurrentQueue<T> _internalData;

        static InternalData()
        {
            _internalData = new ConcurrentQueue<T>();
        }

        public static void Add(T item)
        {
            _internalData.Enqueue(item);
        }
    }
}
