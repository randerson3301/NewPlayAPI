using System.Collections.Generic;
using NewPlay.Domain.Models;

namespace NewPlay.Domain.Interfaces.Services
{
    public interface IPublisherService
    {
        bool Add(Publisher publisher);
        bool Update(Publisher publisher);
        bool Disable(int id, string disableUserId);
        List<Publisher> GetPublishers();
        Publisher GetPublisherById(int id);
    }
}