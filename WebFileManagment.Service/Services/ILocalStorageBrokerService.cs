namespace WebFileManagment.Service.Services
{
    public interface ILocalStorageBrokerService
    {
        Task CreateFolder(string folderPath);
        Task DeleteFolder(string folderPath);
        Task UploadFile(string fileName, Stream stream);
        Task<Stream> DownloadFolderAsZip(string folderPath);
        Task<Stream> DownloadFile(string FilePath);
        Task<Stream> UploadFileWithChunks(string? folderPath, string FileName);
        Task DeleteFile(string filePath);
        List<string> GetFolderAndFiles(string folderPath);
        Task<Stream> GetContextOfTxtFile();
        Task<bool> UpdateContextOfTxtFile(string filePath, string newContext);




    }
}
