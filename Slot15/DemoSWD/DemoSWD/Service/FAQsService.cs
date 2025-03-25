using DemoSWD.Models;
using DemoSWD.Repository;

namespace DemoSWD.Service
{
    public class FAQsService : IFAQsService
    {
        private readonly IFAQsRepository _faqsRepository;

        public FAQsService(IFAQsRepository faqsRepository)
        {
            _faqsRepository = faqsRepository;
        }

        public List<Faq> GetQuestionFAQs()
        {
            return _faqsRepository.GetQuestionFAQs();
        }

        public Faq GetQuestionById(int id)
        {
            return _faqsRepository.GetQuestionById(id);
        }

        public void AddQuestion(string question)
        {
            _faqsRepository.AddQuestion(question);
        }
    }

}
