using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Schedule.Controllers.Base
{
    public abstract class BaseController : Controller, IDisposable
    {
        #region Properties

        protected ILifetimeScope Scope { get; set; }

        protected T Service<T>()
        {
            return Scope.Resolve<T>();
        }

        #endregion

        #region Constructor

        public BaseController(ILifetimeScope scope)
        {
            Scope = scope;
        }

        #endregion

        #region InterfaceMembers

        public void Dispose()
        {
            Scope?.Dispose();
        }

        #endregion
    }
}
