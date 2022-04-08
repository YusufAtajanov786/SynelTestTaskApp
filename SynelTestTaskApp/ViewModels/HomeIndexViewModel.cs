using Microsoft.AspNetCore.Http;
using SynelTestTaskApp.Attributes;

namespace SynelTestTaskApp.ViewModels
{
    public class HomeIndexViewModel
    {
        [AllowedExtensions(new string[] { ".csv" })]
        public IFormFile File { get; set; }
        public int? CountOfInsertedRecords { get; set; }
    }
}
