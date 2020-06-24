using ClassRoom.Models.Db;

namespace ClassRoom.Repositories
{
    public class RepositoryBase
    {
        protected ClassRoomContext _context;
        public RepositoryBase(ClassRoomContext context)
        {
            _context = context;
        }
    }
}
