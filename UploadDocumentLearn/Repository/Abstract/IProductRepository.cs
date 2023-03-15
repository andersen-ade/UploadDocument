using UploadDocumentLearn.Models;
using UploadDocumentLearn.Models.Domain;
using UploadDocumentLearn.Models.DTO;

namespace UploadDocumentLearn.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(ProductUploadDto model);
    }
}
