using ClassRoom.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace ClassRoom.Repositories
{
    public class RepositoryBase<TDbEntity> where TDbEntity: class
    {
        protected DbSet<TDbEntity> set;
        public RepositoryBase(ClassRoomContext context)
        {
            set = context.Set<TDbEntity>();
        }
    }
}
