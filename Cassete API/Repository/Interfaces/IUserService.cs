using Cassete_API.Models;
using System.Collections.Generic;

namespace Cassete_API.Repository.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAll();

        UserModel Get(int id);

        void Add(UserModel user);

        void Update(UserModel user);

        void Delete(int id);

        UserModel Search(string subString);
    }
}
