using System.ComponentModel.DataAnnotations.Schema;

namespace UploadDocumentLearn.Models.DTO
{
    public class ProductUploadDto
    {
        public string? ProductName { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public IFormFile? ItemImageFile { get; set; }
    }
}
