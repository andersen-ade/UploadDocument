namespace UploadDocumentLearn.Repository.Abstract
{
    public interface IFileService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public Tuple<int, string> SaveProductImage(IFormFile itemImageFile);
        public bool DeleteImage(string imageFileName);
    }
}
