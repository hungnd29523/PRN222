using DemoSWD.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoSWD.Controllers
{

    public class FAQsController : Controller
    {
        private readonly IFAQsService _faqsService;

        public FAQsController(IFAQsService faqsService)
        {
            _faqsService = faqsService;
        }


        public IActionResult GetQuestionFAQs()
        {
            try
            {
                var faqs = _faqsService.GetQuestionFAQs();
                return View("FAQsView", faqs);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi tải danh sách câu hỏi. Vui lòng thử lại!";
                return RedirectToAction("GetQuestionFAQs");
            }
        }



        public IActionResult GetQuestionById(int id)
        {
            var faq = _faqsService.GetQuestionById(id);
            if (faq == null)
                return NotFound();

            return View("FAQsDetailView", faq);
        }

        [HttpPost]
        public IActionResult AddQuestion(string question)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                TempData["ErrorMessage"] = "Câu hỏi không được để trống.";
                return RedirectToAction("GetQuestionFAQs");
            }

            _faqsService.AddQuestion(question);
            TempData["SuccessMessage"] = "Câu hỏi đã được thêm thành công!";
            return RedirectToAction("GetQuestionFAQs");
        }

    }

}
