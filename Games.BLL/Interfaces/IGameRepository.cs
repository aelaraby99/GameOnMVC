using Games.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.BLL.Interfaces
{
	public interface IGameRepository : IGenericRepository<Game> 
	{
        void DetachEntity(Game entity);
    }
}
