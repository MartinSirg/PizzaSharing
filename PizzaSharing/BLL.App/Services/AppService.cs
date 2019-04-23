using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Base.Services;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using PublicApi.DTO;

namespace BLL.App.Services
{
    public class AppService : BaseService<IAppUnitOfWork>, IAppService
    {
        public AppService(IAppUnitOfWork uow) : base(uow)
        {
        }

        public async Task<UserDashboardDTO> GetUserDashboard(int userId)
        {
            return new UserDashboardDTO
            {
                Loans = await Uow.Loans.AllUserGivenLoans(userId),
                Debts = await Uow.Loans.AllUserTakenLoans(userId),
                OpenReceipts = await Uow.Receipts.AllUserReceipts(userId, false),
                ClosedReceipts = await Uow.Receipts.AllUserReceipts(userId, true)
            };
        }

        public async Task<List<OrganizationDTO>> GetOrganizationsCategoriesAndProductsAsync(int receiptId)
        {
            var receipt = await Uow.Receipts.FindAsync(receiptId);
            if (receipt == null) return null;
            var time = receipt.IsFinalized == false ? DateTime.Now : receipt.CreatedTime;
            
            return await Uow.Organizations.AllDtoAsync(time);
        }

        public List<ChangeDTO> GetValidProductsChanges()
        {
            throw new System.NotImplementedException();
        }

        public List<AppUserDTO> GetValidParticipants()
        {
            throw new System.NotImplementedException();
        }
    }
}