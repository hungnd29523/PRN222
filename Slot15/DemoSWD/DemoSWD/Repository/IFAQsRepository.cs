using DemoSWD.Models;

namespace DemoSWD.Repository
{
    public interface IFAQsRepository
    {
        List<Faq> GetQuestionFAQs();
        Faq GetQuestionById(int id);
        void AddQuestion(string question);
    }
}
