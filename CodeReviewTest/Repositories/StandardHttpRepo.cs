using System;
using System.Threading.Tasks;

namespace CodeReviewTest.Repositories
{
    public class StandardHttpRepo : IHttpRepository
    {
        public StandardHttpRepo()
        {
        }

        public Task<bool> SendPerson(Person person, string url)
        {
            throw new NotImplementedException();
        }
    }
}
