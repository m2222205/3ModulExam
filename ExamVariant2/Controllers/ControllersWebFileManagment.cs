using Microsoft.AspNetCore.Mvc;
using WebFileManagment.Server.Service;

namespace ExamVariant2.Controllers
{

    [ApiController]
    [Route("[controller/ File Managment]")]


    public class ControllersWebFileManagment : ControllerBase
    {
        private readonly IstorageService? _storageService;
        public ControllersWebFileManagment(IstorageService storageService)
        {
            _storageService = storageService;
        }



        [HttpPost("Create Folder")]
        public async Task CreateFolder(string folderPath)
        {
            folderPath = Path.GetDirectoryName(folderPath);
            await _storageService.CreateFolder(folderPath);

        }

        [HttpGet("Upload File")]
        public async Task UploadFile(string FileName, Stream stream)
        {
            await _storageService.UploadFile(FileName, stream);

        }

        [HttpPost("Delete Folder")]
        public async Task DeleteFolder(string folderPath)
        {

        }








    }
}
