using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public interface IPositionRepository
    {
        Position GetPosition(int id);
        IEnumerable<Position> GetAllPosition();
        Position Add(Position position);
        Position Update(Position positionChange);
        Position Delete(int id);
    }
}
