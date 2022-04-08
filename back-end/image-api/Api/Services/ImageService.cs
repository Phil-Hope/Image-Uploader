using ImageApi.Models;
using System;
using System.Collections.Generic;
using ImageApi.Interfaces;
namespace ImageApi.Services
{

    public class ImageService : IImageService
    {

        // Create database object
        Database Database = new Database(); 

        // Add image meta-data to MySQL database
        public void AddImage(Image newImage)
        {
            try
            {
                var cmd = Database.Connection.CreateCommand();
                cmd.CommandText = "INSERT INTO images (Id, fileName, imageSize, filePath, fileType) VALUES (@Id, @FileName, @ImageSize, @FilePath, @FileType)";
              // bind parameters for added security
                cmd.Parameters.AddWithValue("@Id", newImage.Id);
                cmd.Parameters.AddWithValue("@FileName", newImage.FileName);
                cmd.Parameters.AddWithValue("@ImageSize", newImage.ImageSize);
                cmd.Parameters.AddWithValue("@FilePath", newImage.FilePath);
                cmd.Parameters.AddWithValue("@FileType", newImage.FileType);
                var reader = cmd.ExecuteReader();
                Database.Dispose();
            } catch (Exception e)
            {
                throw new Exception("Database Create Error: " + e.Message);
            }
        }

        // Get all image meta-data to MySQL database
        public List<Image> GetAllImages()
        {
            // Create Image Object
            List<Image> list = new List<Image>();
            try
            {
                var cmd = Database.Connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM images;";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    // Add database rows in to list of image objects
                    list.Add(new Image
                    {
                        Id = (Guid)reader["Id"],
                        FileName = (string)reader["fileName"],
                        TimeStamp = (DateTime)(reader["timestamp"]),
                        ImageSize = (double)(reader["imageSize"]),
                        FilePath = (string)reader["filePath"],
                        FileType = (string)reader["fileType"],
                    });
                Database.Dispose();
                return list;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Database Read All Error: " + e.Message);
            }
        }
    }
}
