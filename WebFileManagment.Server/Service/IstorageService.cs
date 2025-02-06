using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFileManagment.Server.Service
{
    public interface IstorageService
    {
        Task CreateFolder(string folderPath);
        Task DeleteFolder(string folderPath);
        Task UploadFile(string fileName, Stream stream);
        Task DownloadFolderAsZip(string folderPath);
        Task DownloadFile(string FilePath);
        Task UploadFileWithChunks(string? folderPath, string FileName);
        Task DeleteFile(string filePath);

        Task<List<string>> GetFolderAndFiles(string folderPath);
        Task<Stream> GetContextOfTxtFile();
        Task<bool> UpdateContextOfTxtFile(string filePath, string newContext);





    }
}
