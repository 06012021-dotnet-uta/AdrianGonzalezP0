using EcommerceDbContext;

namespace DbContext
{
    public static class DbConextProject
    {
        private static Project0Context _context = new();
        public static Project0Context DbContext => _context;
    }
}
