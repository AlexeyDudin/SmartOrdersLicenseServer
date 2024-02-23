using Domain.Foundation;
using Domain.Models;

namespace Infrastrucrure.Foundation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext _dbContext;
        private IRepository<License> licenseRepository;
        public IRepository<License> LicenseRepository { get => licenseRepository; }

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            licenseRepository = new Repository<License>(dbContext);
        }
        

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
