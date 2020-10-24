using System.Threading.Tasks;
using ProAgil.Domain.Model;

namespace ProAgil.Repository.Interface
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool incluirPalestrantes);
         Task<Evento[]> GetAllEventoAsync(bool incluirPalestrantes = false);
         Task<Evento> GetAllEventoAsyncById(int eventoId, bool incluirPalestrantes);

         Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool incluirEvento);
         Task<Palestrante> GetAllPalestrantesAsyncById(int palestranteId, bool incluirEvento);

         Task<int> CountControle();

         
    }
}