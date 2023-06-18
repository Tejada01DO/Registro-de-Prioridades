using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions; 

public class TicketBLL
{
    private Context _context;
    
    public TicketBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int TicketId)
    {
        return _context.Tickets.Any(t => t.TicketId == TicketId);
    }

    public bool Insertar(Tickets tickets)
    {
        _context.Tickets.Add(tickets);
        int guardado = _context.SaveChanges();
        _context.Entry(tickets).State = EntityState.Detached;
        return guardado > 0;
    }

    public bool Modificar(Tickets tickets)
    {
        _context.Update(tickets);
        int modificado = _context.SaveChanges();
        _context.Entry(tickets).State = EntityState.Detached;
        return modificado > 0;
    }

    public bool Guardar(Tickets tickets)
    {
        if(!Existe(tickets.TicketId))
        {
            return Insertar(tickets);
        }
        else
        {
            return Modificar(tickets);
        }
    }

    public bool Eliminar(Tickets tickets)
    {
        _context.Tickets.Remove(tickets);
        int eliminado = _context.SaveChanges();
        _context.Entry(tickets).State = EntityState.Detached;
        return eliminado > 0;
    }

    public Tickets? Buscar(int TicketId)
    {
        return _context.Tickets.Include(detalle => detalle.TicketDetalle).Where(Ticket => Ticket.TicketId == TicketId).AsNoTracking().SingleOrDefault();
    }

    public List<Tickets> Listar(Expression<Func<Tickets, bool>> Criterio){
        return _context.Tickets.Include(detalle => detalle.TicketDetalle).AsNoTracking().Where(Criterio).ToList();
    }
}