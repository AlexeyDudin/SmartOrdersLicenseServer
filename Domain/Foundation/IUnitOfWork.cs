using Domain.Models;

namespace Domain.Foundation
{
    public interface IUnitOfWork
    {
        IRepository<License> LicenseRepository { get; }
        public void Commit();
    }
}
