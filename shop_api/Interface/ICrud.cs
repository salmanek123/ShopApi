using static shop_api.Models.Request;
using static shop_api.Models.Shops;

namespace shop_api.Interface
{
    public interface  ICrud
    {
        Task<dynamic> AddItems(AddItemRequest request);
        Task<dynamic> AddAlternateItem(AltUnitRequest request);
        Task<dynamic> GetItems(int? itemId ,PaginationRequest request);
       
        Task<dynamic> UpdateItems(int ItemId, ItemUpdateRequest request);
        Task<dynamic> UpdateAlternateUnit(int AltunitId, UpdateAlternateUnit request);
        Task<dynamic> DeleteItems(int ItemId);
        Task<dynamic> GetAllItems(int? item, PaginationRequest request);

    }
}
