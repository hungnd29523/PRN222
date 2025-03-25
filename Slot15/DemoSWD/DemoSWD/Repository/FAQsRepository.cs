using DemoSWD.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSWD.Repository
{
    public class FAQsRepository : IFAQsRepository
    {
        private readonly DemoSwdContext _context;

        public FAQsRepository(DemoSwdContext context)
        {
            _context = context;
        }

        public List<Faq> GetQuestionFAQs()
        {
            return _context.Faqs
              .Where(f => f.Answer != null && EF.Functions.Like(f.Answer, "_%"))
              .ToList();


        }

        public Faq GetQuestionById(int id)
        {
            return _context.Faqs.Find(id);
        }

        public void AddQuestion(string question)
        {
            var faq = new Faq { Question = question };
            _context.Faqs.Add(faq);
            _context.SaveChanges();
        }
    }
}
