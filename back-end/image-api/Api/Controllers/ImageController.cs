using Microsoft.AspNetCore.Mvc;
using ImageApi.Models;
using ImageApi.Interfaces;
using System.IO;
using System.Net.Http.Headers;
using System;

namespace ImageApi.Services
{
    [Route("/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase, IImageController
    {
        private IImageService _service;

        public ImageController(IImageService service)
        {
            _service = service;
        }

        // Create/ Add a new Image
        [HttpPost]
        [Route("upload")]
        public IActionResult Upload()
        {
            try
            {
                // Get file from the request object
                var file = Request.Form.Files[0];
                // Set to save to /Resources/Images folder
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    //Split the file name in to an array to get the file extension
                    var split = fileName.Split(".");
                    string format = split[1];
                    // Check to ensure that file is the correct format
                    Validator Validate = new Validator(format, file.Length);
                    if (Validate.CorrectFormat() == true && Validate.CorrectSize() == true)
                    {
                        // Get the filepath for the newly saved image.
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        // Upload file to the relevant destination
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // Create a new Uuid for the database record
                        var Id = Guid.NewGuid();

                        // Instantiate new Image object with the new data
                        Image image = new Image()
                        {
                            Id = Id,
                            FileName = fileName,
                            FilePath = dbPath,
                            ImageSize = file.Length,
                            FileType = split[1],
                        };
                        // Inserts image information in to MySql Database
                        _service.AddImage(image);
                        HttpContext.Response.Headers.Add("Allow-Access-Control-Origin", "http://localhost:4200/Image/upload");
                        HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "*");
                        HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "OPTIONS, POST");
                        return Ok(image);
                    }
                    else
                    {
                        return BadRequest("Incorrect File Format: " + format);
                    }
                }
                else
                {
                    return BadRequest();
                }
            } catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e}");
            }
        }

        // Get All Images
        [HttpGet]
        [Route("/getAll")]
        public IActionResult GetImages()
        {
            var allImages = _service.GetAllImages();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200/getAll");
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "*");
            HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "OPTIONS, GET");
            HttpContext.Response.Headers.Add("Content-Type", "application/json");
            return allImages is null ? NotFound() : Ok(allImages);

        }
    }
}
