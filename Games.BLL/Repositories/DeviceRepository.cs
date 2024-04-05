using Games.BLL.Interfaces;
using Games.DAL.Data.Contexts;
using Games.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOn.BLL.Repositories
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
