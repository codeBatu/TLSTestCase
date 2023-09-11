using Busiines.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTO;

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

        [HttpGet("getAllById")]
        public IActionResult GetAllById(int id)
        {
            var documents = documentSupply.GetAllById(id);
            return Ok(documents);
        }

        private readonly string uploadPath = @"D:\TestCase"; // Dosyaların kaydedileceği yol

        [HttpPost ("document/api")]
        public async Task<IActionResult> UploadDocument(IFormFile file, string title, string description, int userID)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya yüklenmedi.");

            try
            {
             
                var filePath = Path.Combine(uploadPath, "adsiz"+ userID);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

       
                var document = new DocumentDTO
                {
                    FileName = file.FileName,
                    FileType = Path.GetExtension(file.FileName).Substring(1), 
                    Title = title,
                    Description = description,
                    FilePath = filePath,
                    UserID = userID
                };
                documentSupply.Add(document);
             

                return Ok("Dosya başarıyla yüklendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Dosya yüklenirken bir hata oluştu.");
            }
        }

    [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var document = documentSupply.GetById(id);
            return Ok(document);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Model.DTO.DocumentDTO document)
        {
            documentSupply.Add(document);
            return Ok();
        }
     
       
    }
}
