using IRCore;
using IRCore.Save;

namespace IR
{
    /// <summary>
    /// Use custom saveable for your own save implementation
    /// </summary>
    sealed class OriginDBRepository : IRepository, ICustomSaveable
    {
        public int Value;

        public OriginDBRepository()
        {
            // DB connection
            // Load data/cache
        }

        public void Save()
        {
            // Upload data
            // Close DB connection
        }
    }
}