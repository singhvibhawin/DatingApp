using CloudinaryDotNet.Actions;

namespace API.Interfaces
{
    public class IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
} 