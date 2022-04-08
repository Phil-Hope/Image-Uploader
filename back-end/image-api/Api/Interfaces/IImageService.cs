using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageApi.Models;

namespace ImageApi.Interfaces
{
    public interface IImageService
    {
        List<Image> GetAllImages();

        void AddImage(Image newImage);
    }
}
