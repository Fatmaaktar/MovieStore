using MovieStore.Models.Domain;
using MovieStore.Models.DTO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);

        bool Update(Movie model);

        Movie GetById(int Id);

        bool Delete(int Id);

        MovieListVm List();
    }
}
