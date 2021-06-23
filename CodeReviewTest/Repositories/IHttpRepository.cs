using System.Threading.Tasks;

namespace CodeReviewTest.Repositories
{
    public interface IHttpRepository
    {
        public Task<bool> SendPerson(Person person, string url);
    }
}
