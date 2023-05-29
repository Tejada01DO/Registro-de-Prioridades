using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; 

public class SistemaBLL
{
    private Context _context;
    
    public SistemaBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int SistemaId)
    {
        return _context.Tickets.Any(s => s.SistemaId == SistemaId);
    }

    public bool Insertar(Sistemas sistemas)
    {
        _context.Sistemas.Add(sistemas);
        int guardado = _context.SaveChanges();
        _context.Entry(sistemas).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Sistemas sistemas)
    {
        _context.Update(sistemas);
        int modificado = _context.SaveChanges();
        _context.Entry(sistemas).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Sistemas sistemas)
    {
        if(!Existe(sistemas.SistemaId))
        {
            return Insertar(sistemas);
        }
        else
        {
            return Modificar(sistemas);
        }
    }

    public bool Eliminar(Sistemas sistemas)
    {
        _context.Sistemas.Remove(sistemas);
        int eliminado = _context.SaveChanges();
        _context.Entry(sistemas).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Sistemas? Buscar(int SistemaId)
    {
        return _context.Sistemas.AsNoTracking().SingleOrDefault(s => s.SistemaId == SistemaId);
    }

    public List<Sistemas> Listar(Expression<Func<Sistemas, bool>> Criterio){
        return _context.Sistemas.Where(Criterio).AsNoTracking().ToList();
    }
}