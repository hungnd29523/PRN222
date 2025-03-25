using DemoSWD.Models;

namespace DemoSWD.Service
{
    public interface IFAQsService
    {
        List<Faq> GetQuestionFAQs();
        Faq GetQuestionById(int id);
        void AddQuestion(string question);
    }

}
