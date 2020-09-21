using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Model;
using ProAgil.Repository.Context;
using ProAgil.Repository.Interface;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);    
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);  
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);  
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


#region Eventos
        public async Task<Evento[]> GetAllEventoAsync(bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lote)
                .Include(c => c.RedeSociais);

            if(incluirPalestrantes)
            {
                query = query
                 .Include(pe => pe.PalestrantesEventos)
                 .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoAsyncById(int eventoId, bool incluirPalestrantes = false)
        {
             IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lote)
                .Include(c => c.RedeSociais);

            if(incluirPalestrantes)
            {
                query = query
                 .Include(pe => pe.PalestrantesEventos)
                 .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento)
                       .Where(c => c.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool incluirPalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lote)
                .Include(c => c.RedeSociais);

            if(incluirPalestrantes)
            {
                query = query
                 .Include(pe => pe.PalestrantesEventos)
                 .ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento)
                       .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

#endregion

#region Palestrante
        public async Task<Palestrante> GetAllPalestrantesAsyncById(int palestranteId, bool incluirEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedeSociais);

            if(incluirEvento)
            {
                query = query
                 .Include(pe => pe.PalestrantesEventos)
                 .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(c => c.Nome)
                .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool incluirEvento = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedeSociais);

            if(incluirEvento)
            {
                query = query
                 .Include(pe => pe.PalestrantesEventos)
                 .ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(c => c.Nome)
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

#endregion

    }
}