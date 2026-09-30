using System;
using System.Collections.Generic;
using System.Text;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Repositories
{
    public class CancionRepository : GenericRepository<Cancion>

{
    public List<Cancion> ObtenerMasLargas()
        {
            if (!_context.Set<Cancion>().Any())
                return new List<Cancion>();

            int duracionMaxima = _context.Set<Cancion>().Max(c => c.DuracionSegundos);

            return _context.Set<Cancion>()
                           .Include(c => c.Artista)
                           .Where(c => c.DuracionSegundos == duracionMaxima)
                           .AsNoTracking()
                           .ToList();
        }

        public int ObtenerCantidadTotal()
        {
            return _context.Set<Cancion>().Count();
        }

        public List<Cancion> ObtenerOrdenadasPorTitulo()
        {
            return _context.Set<Cancion>()
                           .Include(c => c.Artista)
                           .OrderBy(c => c.Titulo)
                           .AsNoTracking()
                           .ToList();
        }

        public bool ExistenCanciones()
        {
            return _context.Set<Cancion>().Any();
        }
    }
}