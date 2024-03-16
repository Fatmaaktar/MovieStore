using MovieStore.Models.Domain;
using MovieStore.Models.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);

        bool Update(Genre model);

        Genre GetById(int Id);

        Genre Delete(int Id);

        IQueryable<Genre> List();
    }
}
