using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class PositionRepository : IPositionRepository
    {
        private readonly AppDbContext context;

        public PositionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Position Add(Position position)
        {
            context.Positions.Add(position);
            context.SaveChanges();
            return position;
        }

        public Position Delete(int id)
        {
            Position position = context.Positions.Find(id);
            if (position != null)
            {
                context.Positions.Remove(position);
                context.SaveChanges();
            }
            return position;
        }

        public IEnumerable<Position> GetAllPosition()
        {
            return context.Positions;
        }

        public Position GetPosition(int id)
        {
            return context.Positions.Find(id);
        }

        public Position Update(Position positionChange)
        {
            var position = context.Positions.Attach(positionChange);
            position.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return positionChange;
        }
    }
}
