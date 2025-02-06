
namespace WebFileManagment.Server.Service
{
    public class StorageService : IstorageService
    {
        private readonly IstorageService _storageService;

        public StorageService(IstorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task CreateFolder(string folderPath)
        {
            await _storageService.CreateFolder(folderPath);
        }

        public async Task DeleteFile(string filePath)
        {
            await _storageService.DeleteFile(filePath);
        }

        public async Task DeleteFolder(string folderPath)
        {
            await _storageService.DeleteFolder(folderPath);
        }

        public async Task DownloadFile(string FilePath)
        {
            await _storageService.DownloadFile(FilePath);
        }

        public async Task DownloadFolderAsZip(string folderPath)
        {
           await _storageService.DownloadFolderAsZip(folderPath);
        }

        public async Task<Stream> GetContextOfTxtFile()
        {
            return await _storageService.GetContextOfTxtFile();
        }

        public async Task<List<string>> GetFolderAndFiles(string folderPath)
        {
            return await _storageService.GetFolderAndFiles(folderPath);
        }

        public async Task<bool> UpdateContextOfTxtFile(string filePath, string newContext)
        {
            return await _storageService.UpdateContextOfTxtFile(filePath, newContext);
        }

        public async Task UploadFile(string fileName, Stream stream)
        {
           await _storageService.UploadFile(fileName, stream);
        }

        public async Task UploadFileWithChunks(string? folderPath, string FileName)
        {
            await _storageService.UploadFileWithChunks(folderPath, FileName);
        }
    }
}
