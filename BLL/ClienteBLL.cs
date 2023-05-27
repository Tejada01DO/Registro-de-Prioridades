using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; 

public class ClienteBLL{

    private Context _context;
    
    public ClienteBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int ClienteId)
    {
        return _context.Clientes.Any(c => c.ClienteId == ClienteId);
    }

    public bool Insertar(Clientes cliente)
    {
        _context.Clientes.Add(cliente);
        int guardado = _context.SaveChanges();
        _context.Entry(cliente).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Clientes cliente)
    {
        _context.Update(cliente);
        int modificado = _context.SaveChanges();
        _context.Entry(cliente).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Clientes cliente)
    {
        if(!Existe(cliente.ClienteId))
        {
            return Insertar(cliente);
        }
        else
        {
            return Modificar(cliente);
        }
    }

    public bool Eliminar(Clientes cliente)
    {
        _context.Clientes.Remove(cliente);
        int eliminado = _context.SaveChanges();
        _context.Entry(cliente).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Clientes? Buscar(int ClienteId)
    {
        return _context.Clientes.AsNoTracking().SingleOrDefault(c => c.ClienteId == ClienteId);
    }

    public List<Clientes> Listar(Expression<Func<Clientes, bool>> Criterio){
        return _context.Clientes.Where(Criterio).AsNoTracking().ToList();
    }
}