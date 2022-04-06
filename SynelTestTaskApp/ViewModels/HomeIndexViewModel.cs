using Microsoft.AspNetCore.Http;

namespace SynelTestTaskApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IFormFile File { get; set; }
        public int? CountOfInsertedRecords { get; set; }
    }
}
