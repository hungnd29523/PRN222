using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class CustomerFormModel : PageModel
    {
        public string Message { set; get; }
        [BindProperty]
        public Customer customerInfo { set; get; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();
            }
            else
            {
                Message = "Error on input data.";
            }
        }
    }

}
