using DbContextLib;

namespace DbDataManager;

public class DbManager
{
    protected LibraryContext _context;
    public DbManager()
    {
        _context = new LibraryContext();
    }
}