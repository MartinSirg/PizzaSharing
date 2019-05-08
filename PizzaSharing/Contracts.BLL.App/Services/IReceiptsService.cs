using System.Threading.Tasks;
using BLL.App.DTO;
using Contracts.BLL.Base.Services;
using PublicApi.DTO;

namespace Contracts.BLL.App.Services
{
    public interface IReceiptsService : IBaseService
    {
        Task<BLLReceiptDTO> GetReceiptAndRelatedData(int receiptId, int currentUserId);
        
        Task<int> NewReceipt(int userId);

        Task<bool> RemoveReceipt(int receiptId, int currentUserId);

        Task<BLLReceiptRowDTO> AddRow(BLLReceiptRowDTO receiptRowDTO, int currentUserId);

        Task<BLLReceiptRowDTO> UpdateRowAmount(BLLReceiptRowDTO dto, int userId);

        Task<bool> RemoveRow(int rowId, int userId);

        ReceiptRowAllDTO AddRowChange();

        ReceiptRowAllDTO AddRowParticipant();

        ReceiptRowAllDTO RemoveRowChange();

        ReceiptRowAllDTO RemoveRowParticipant();

        ReceiptRowAllDTO EditRowParticipantInvolvement();

        bool SetReceiptFinalized();

        ReceiptRowAllDTO AddRowDiscount();

        ReceiptRowAllDTO RemoveRowDiscount();
    }
}