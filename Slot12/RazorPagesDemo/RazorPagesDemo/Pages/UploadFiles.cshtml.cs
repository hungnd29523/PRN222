using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class UploadFilesModel : PageModel
    {
        private IWebHostEnvironment _environment;

        public UploadFilesModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [Required(ErrorMessage = "Please choose at least one file.")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }

        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach (var fileUpload in FileUploads)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "Images", fileUpload.FileName);

                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await fileUpload.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }

}
