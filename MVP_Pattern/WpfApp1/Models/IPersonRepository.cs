using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPPattern.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person>? GetAll();
        bool SaveOne(Person person);
        bool DeleteOne(int id);
        bool Exist(int id);
    }
}
