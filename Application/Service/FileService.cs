using System;
using System.IO;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Service
{
    public interface IFileService : IGenericRepository<Domain.File>
    {
        Task<string> FileUplaod(IFormFile file);
    }
    public class FileService : GenericRepository<Domain.File>, IFileService
    {
        public FileService(DataContext context) : base(context)
        {
        }
        public async Task<string> FileUplaod(IFormFile file)
        {
            if (file == null) return null;
            var folderName = Path.Combine("wwwroot", "FileUplaod");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var FileGuidName = Guid.NewGuid().ToString();
            var FileName = FileGuidName + Path.GetExtension(file.FileName);
            string fullPath = Path.Combine(pathToSave, FileName);

            await using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return FileName;
        }
    }
}