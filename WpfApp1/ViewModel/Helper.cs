
namespace WpfApp1
{
    public class Helper
    {
        private static ApplicationContext _context;
        public static ApplicationContext GetContext()
        {
            if (_context == null)
                _context = new ApplicationContext();
            return _context;
        }
    }
}