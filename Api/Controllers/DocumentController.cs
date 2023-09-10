using Busiines.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentSupply documentSupply;

        public DocumentController(IDocumentSupply documentSupply)
        {
            this.documentSupply = documentSupply;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var documents = documentSupply.GetAll();
            return Ok(documents);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var document = documentSupply.GetById(id);
            return Ok(document);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Model.Document document)
        {
            documentSupply.Add(document);
            return Ok();
        }
     
       
    }
}
