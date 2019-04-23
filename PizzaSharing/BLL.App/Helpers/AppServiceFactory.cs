using System;
using BLL.App.Services;
using BLL.Base.Helpers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;

namespace BLL.App.Helpers
{
    public class AppServiceFactory : BaseServiceFactory<IAppUnitOfWork>
    {
        public AppServiceFactory()
        {
            Add<IAppService>(uow => new AppService(uow));
            Add<ILoanService>(uow => new LoanService(uow));
            Add<IReceiptsService>(uow => new ReceiptsService(uow));
            Add<IAppUserService>(uow => new AppUserService(uow));
            Add<IOrganizationsService>(uow => new OrganizationsService(uow));
        }
    }
}