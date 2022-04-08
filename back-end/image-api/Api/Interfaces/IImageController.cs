using Microsoft.AspNetCore.Mvc;

namespace ImageApi.Interfaces
{
    public interface IImageController
    {
        public IActionResult Upload();

        public IActionResult GetImages();
    }
}
