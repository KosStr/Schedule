using Schedule.Database.Repository.Interfaces;
using System;

namespace Schedule.Business.Managers.Base
{
    internal abstract class ServiceBase : IDisposable
    {
        #region Properties

        protected IUnitOfWork UnitOfWork { get; }

        #endregion

        #region Constructor

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        #region Interface Members

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }

        #endregion
    }
}
