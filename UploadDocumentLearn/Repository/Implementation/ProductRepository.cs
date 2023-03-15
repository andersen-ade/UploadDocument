using Microsoft.AspNetCore.Authentication;
using UploadDocumentLearn.Models;
using UploadDocumentLearn.Models.Domain;
using UploadDocumentLearn.Models.DTO;
using UploadDocumentLearn.Repository.Abstract;

namespace SuperHeroAPI.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;   
        }
        public bool Add(ProductUploadDto model)
        {
            try
            {
                Product product = new Product()
                {
                    ProductName = model.ProductName,
                    ImageFile = model.ImageFile,
                    ItemImageFile = model.ItemImageFile,
                };

                _context.Product.Add(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
