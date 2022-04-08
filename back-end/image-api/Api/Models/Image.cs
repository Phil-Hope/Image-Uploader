using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Image Model
 */
namespace ImageApi.Models
{
    public class Image
    {
        [Key]
        [Column(TypeName = "char(36)")]
        [MaxLength(36)]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public string FileName { get; set; }

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        public double ImageSize { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string FileType { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string FilePath { get; set; }

    }
}
