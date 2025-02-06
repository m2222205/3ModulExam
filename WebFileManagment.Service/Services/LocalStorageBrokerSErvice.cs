using System.IO.Compression;

namespace WebFileManagment.Service.Services
{
    public class LocalStorageBrokerSErvice : ILocalStorageBrokerService
    {
        private string _DataPath;

        public LocalStorageBrokerSErvice()
        {
            if (!Directory.Exists(_DataPath))
            {
                Directory.CreateDirectory(_DataPath);
            }


            _DataPath = Path.Combine(Directory.GetCurrentDirectory(_DataPath, "Data"));
        }

        public async Task CreateFolder(string folderPath)
        {
            folderPath = Path.Combine(folderPath, folderPath);
            if (Directory.Exists(folderPath))
            {
                throw new Exception("This file is exests");
            }

            Directory.CreateDirectory(folderPath);
        }

        public async Task DeleteFile(string filePath)
        {
            filePath = Path.Combine(_DataPath, filePath);
            if (!File.Exists(filePath))
            {
                throw new Exception($"{filePath} does not exist");
            }

            File.Delete(filePath);

        }

        public async Task DeleteFolder(string folderPath)
        {
            if (Path.GetExtension(folderPath) != string.Empty)
            {
                throw new Exception("Folder is not Folder");
            }

            folderPath = Path.Combine(_DataPath, folderPath);
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Folder bot Exists");

            }

            Directory.Delete(folderPath);
        }

        public async Task<Stream> DownloadFile(string FilePath)
        {
            FilePath = Path.Combine(_DataPath, FilePath);
            if (!File.Exists(FilePath))
            {
                throw new Exception("File is not Exists");
            }

            var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);

            return stream;

        }

        public async Task<Stream> DownloadFolderAsZip(string folderPath)
        {
            if (Path.GetExtension(folderPath) != string.Empty)
            {
                throw new Exception("Is not Folder");
            }

            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Not Exists");
            }

            string FileName = folderPath + ".zip";
            ZipFile.CreateFromDirectory(folderPath, FileName);
            var stream = new FileStream(folderPath, FileMode.Open, FileAccess.Read);
            return stream;

        }

        public Task<Stream> GetContextOfTxtFile()
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetFolderAndFiles(string folderPath)
        {
            folderPath = Path.Combine(_DataPath, folderPath);
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Folder not exists");
            }

            var Parent = Directory.GetParent(folderPath);
            if (Parent.FullName == string.Empty)
            {
                throw new Exception("Folder not in base Data");
            }

            var All = Directory.GetFileSystemEntries(folderPath);
            return All;
        }

        public Task<bool> UpdateContextOfTxtFile(string filePath, string newContext)
        {
            if (Path.GetExtension(filePath) != ".txt")
            {
                throw new Exception("File is Not Txt");
            }
            if (Directory.Exists(filePath))
            {
                throw new Exception("There is no such file");
            }

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Write)
            {
               stream.WriteEnd(newContext);
        
        }

        public async Task UploadFile(string fileName, Stream stream)
        {
            fileName = Path.Combine(_DataPath, fileName);
            if (!File.Exists(fileName))
            {
                throw new Exception("File not exists");
            }

            var copy = new FileStream(fileName, FileMode.Open, FileAccess.Write)
            {
                fileName.CopyTo(copy)
            }

            return copy;



        }


        public Task<Stream> UploadFileWithChunks(string? filePath, string FileName, Task<Stream> fileDestination)
        {
            var Extension = Path.GetExtension(filePath);
            var destination = Path.Combine(Directory.GetCurrentDirectory(), FileName + Extension);
            var fileInfo = new FileInfo(filePath);

            var Length = fileInfo.Length;

            var bytes = 1024 * 1024 * 500;
            byte[] buffer = new byte[bytes];
            int bytesRead;

            var bytesPercent = bytes * 100d / Length;
            var percent = bytesPercent;



            using (FileStream fileStreamPath = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream fileDestination = new FileStream(destination, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        Console.WriteLine($"{(int)percent} %");
                        percent += bytesPercent;
                        bytesRead = fileStreamPath.Read(buffer, 0, buffer.Length);
                        if (bytesRead <= 0) break;
                        fileDestination.Write(buffer, 0, bytesRead);
                        return fileDestination;

                    }
                }
            }

        }

      

        List<string> ILocalStorageBrokerService.GetFolderAndFiles(string folderPath)
        {
            throw new NotImplementedException();
        }
    }
}



















   