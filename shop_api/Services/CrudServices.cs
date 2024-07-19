using Azure;
using EntityFrameworkExtras.EFCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using shop_api.Data;
using shop_api.Helper;
using shop_api.Interface;
using shop_api.Models;
using static shop_api.Entities.StoreProcedures.Shop.Shop;
using static shop_api.Models.Request;
using static shop_api.Models.Response;
using static shop_api.Models.Shops;

namespace shop_api.Services
{
    public class CrudServices:ICrud
    {
        
        private readonly DataContext _context;
        public CrudServices(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<dynamic>AddItems(AddItemRequest request)
        {
            ControllerResponse response= new ControllerResponse();

            try
            {

                var proc = new AddItemsp()
                {
                    ItemCode = request.ItemCode,
                    CurrentStock = request.CurrentStock,
                    Cost = request.Cost,
                    Notes = request.Notes,
                    TaxPerc = request.TaxPerc,
                    ResultID = 0


                };
                var SpResponse = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int Result = proc.ResultID;
                if(Result == -1) 
                {
                    response.status = false;
                    response.data = "Error occurred while adding the item.";
                    return response;
                }
                else
                {
                    response.status = true;
                    response.data = "Inserted successfully";
                    return response;
                }





            }
            catch (Exception ex)
            {
                response.status=false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }

        public async Task<dynamic>AddAlternateItem(AltUnitRequest request)
        {
         ControllerResponse response = new ControllerResponse();
            try
            {
                var proc = new AddAlterUnits()
                {
                    ItemId = request.ItemId,
                    Unit = request.Unit,
                    ItemName = request.ItemName,
                    Conversion = request.Conversion,
                    RetailRate = request.RetailRate,
                    Barcode = request.Barcode,
                    IsBasic = request.IsBasic,
                    ResulID = 0
                };

                var SpResponse = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int result = proc.ResulID;
                if(result == -1)
                {
                    response.status = false;
                    response.data = "Error occurred while adding the item.";
                    return response;
                }else if (result == -2)
                {
                    response.status = false;
                    response.data = "An item can only have one basic unit";
                    return response;
                }
                else
                {
                    response.status = true;
                    response.data = "Inserted successfully";
                    return response;
                }

            }
            catch(Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }

        
        }

        public async Task<dynamic> GetItems(int? itemId ,PaginationRequest request)
        {
            ControllerResponse response = new ControllerResponse();

            try
            {
               
                var proc = new GetItems()
                {
                    ItemId = itemId,
                    Page = request.pageNo,
                    Limit = request.limit,
                    TotalCount = 0,
                    ResultID = 0,
                };

                var spResponse = await _context.Database.ExecuteStoredProcedureAsync<ItemResponse>(proc);
                int result = proc.ResultID;
                if(result == -1)
                {
                    response.status = false;
                    response.data = "Something went wrong :fecth sp";
                }
                if (spResponse.GetType() == typeof(List<ItemResponse>))
                {

                    var dataResponse = new DataResponse(spResponse);
                    var paginatioResponse = new PaginatioResponse(
                    
                        request.pageNo,
                        request.limit,
                        proc.TotalCount,
                        dataResponse.data
                    );

                    response.data = paginatioResponse;
                    response.status = true;
                    return response;
                }
                else
                {
                    response.data = "ERROR: Data not exists";
                    response.status = false;
                    return response;
                }


                
            }
            catch(Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }

        }
      

        public async Task<dynamic>UpdateItems(int ItemId,ItemUpdateRequest request)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                var proc = new UpdateItems()
                {
                    ItemId = ItemId,
                    ItemCode = request.ItemCode,
                    CurrentStock = request.CurrentStock,
                    Cost = request.Cost,
                    Notes = request.Notes,
                    TaxPerc = request.TaxPerc,
                    ResultID = 0
                };

                var SpRespons = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int result = proc.ResultID;
                if (result == -1)
                {
                    response.status = false;
                    response.data = "Error occurred while Updating the item.";
                    return response;
                }
               
                response.status = true;
                response.data = "Updated Successfully";
                return response;
                


            }
            catch (Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }


        public async Task<dynamic> DeleteItems(int ItemId)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                var proc = new DeleteItems()
                {
                    ItemId = ItemId,
                    ResultID = 0
                };

                var SpRespons = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int result = proc.ResultID;
                if (result == -1)
                {
                    response.status = false;
                    response.data = "Error occurred while Updating the item.";
                    return response;
                }

                response.status = true;
                response.data = "Deleted Successfully";
                return response;



            }
            catch (Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }

        public async Task<dynamic>UpdateAlternateUnit(int AltunitId, UpdateAlternateUnit request)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                var proc = new UpdateAlternateData()
                {
                    AltUnitId=AltunitId,
                    ItemId = request.ItemId,
                    Unit=request.Unit,
                    ItemName=request.ItemName,
                    Conversion=request.Conversion,
                    RetailRate=request.RetailRate,
                    Barcode=request.Barcode,
                    IsBasic=request.IsBasic,
                    ResultID = 0
                };

                var SpRespons = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int result = proc.ResultID;
                if (result == -1)
                {
                    response.status = false;
                    response.data = "Error occurred while Updating the item.";
                    return response;
                }
                else if (result == -2)
                {
                    response.status = false;
                    response.data = "An item can only have one basic unit";
                    return response;
                }
                else if (result == -3)
                {
                    response.status = false;
                    response.data = "AlterUnitId does not exist";
                    return response;
                }

                response.status = true;
                response.data = "Updated Successfully";
                return response;



            }
            catch (Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }

        public async Task<dynamic>GetAllItems(int? item ,PaginationRequest request)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {
                var proc = new GetAllItems()
                {
                    ItemId = item,
                    Page = request.pageNo,
                    Limit = request.limit,
                    TotalCount = 0
                };
                var spResponse = await _context.Database.ExecuteStoredProcedureAsync<CombinedItemResponse>(proc);
                if (spResponse.GetType() == typeof(List<CombinedItemResponse>))
                {
                    List<ItemResponses> items = new List<ItemResponses>();

                    foreach (CombinedItemResponse itemData in spResponse)
                    {
                        var existingItem = items.FirstOrDefault(i => i.ItemId == itemData.ItemId);
                        if (existingItem == null)
                        {
                            existingItem = new ItemResponses
                            {
                                ItemId = itemData.ItemId,
                                ItemCode = itemData.ItemCode,
                                CurrentStock = itemData.CurrentStock,
                                Cost = itemData.Cost,
                                Notes = itemData.Notes,
                                TaxPerc = itemData.TaxPerc,
                                AltUnits = new List<AltUnitResponse>()
                            };
                            items.Add(existingItem);
                        }

                        if (itemData.AltUnitId.HasValue)
                        {
                            var altUnitResponse = new AltUnitResponse
                            {
                                AltUnitId = itemData.AltUnitId,
                                AltItemId = itemData.AltItemId,
                                Unit = itemData.Unit,
                                ItemName = itemData.ItemName,
                                Conversion = itemData.Conversion,
                                RetailRate = itemData.RetailRate,
                                Barcode = itemData.Barcode,
                                IsBasic = itemData.IsBasic
                            };
                            existingItem?.AltUnits?.Add(altUnitResponse);
                        }
                    }


                    var dataResponse = new DataResponse(items);
                    var paginatioResponse = new PaginatioResponse(

                    request.pageNo,
                    request.limit,
                    proc.TotalCount,
                    dataResponse.data
                    );

                    response.data = paginatioResponse;
                    response.status = true;
                    return response;
                }
                else
                {
                    response.data = "ERROR: Data not exists";
                    response.status = false;
                    return response;
                }
            }
            catch(Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }



        public async Task<dynamic> AddalterItems(ItemAlterRequest request)
        {
            ControllerResponse response = new ControllerResponse();

            try
            {
                List<AddAlternateUnitType> addAlternateUnitTypes = new List<AddAlternateUnitType>();

                if (request.AltUnits.Count > 0)
                {
                    foreach (var data in request.AltUnits)
                    {
                        var obj = new AddAlternateUnitType()
                        {
                            Unit = data.Unit,
                            ItemName = data.ItemName,
                            Conversion = data.Conversion,
                            RetailRate = data.RetailRate,
                            Barcode = data.Barcode,
                            IsBasic = data.IsBasic

                        };
                        addAlternateUnitTypes.Add(obj);
                    }
                }

                var proc = new AddAlternateunittable()
                {
                    ItemCode = request.ItemCode,
                    CurrentStock = request.CurrentStock,
                    Cost = request.Cost,
                    Notes = request.Notes,
                    TaxPerc = request.TaxPerc,
                    AltUnits = addAlternateUnitTypes,
                    ResultID = 0

                };
                var SpResponse = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int result = proc.ResultID;
                if (result == -1)
                {
                    response.status = false;
                    response.data = "Error occurred while adding the item chk Sp.";
                    return response;

                }
                else if (result == -2)
                {
                    response.status = false;
                    response.data = "An item can only have one basic unit";
                    return response;
                }
                else
                {
                    response.status = true;
                    response.data = "Redcord Successfully inserted";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }


        public async Task<dynamic> UpdateAlternateUnitAndItems(int AlternatId, ItemAndAlterRequest request)
        {
            ControllerResponse response = new ControllerResponse();
            try
            {

                List<AddAlternateUnitType> addAlternateUnitTypes = new List<AddAlternateUnitType>();

                if (request.AltUnits.Count > 0)
                {
                    foreach (var data in request.AltUnits)
                    {
                        var obj = new AddAlternateUnitType()
                        {
                            AltUnitId = AlternatId,
                            Unit = data.Unit,
                            ItemName = data.ItemName,
                            Conversion = data.Conversion,
                            RetailRate = data.RetailRate,
                            Barcode = data.Barcode,
                            IsBasic = data.IsBasic

                        };
                        addAlternateUnitTypes.Add(obj);
                    }
                }
                var proc = new UpdateAlternateUnitAndItems()
                {
                    ItemId = request.ItemId,
                    ItemCode = request.ItemCode,
                    CurrentStock = request.CurrentStock,
                    Cost = request.Cost,
                    Notes = request.Notes,
                    TaxPerc = request.TaxPerc,
                    AltUnits = addAlternateUnitTypes,
                    ResultID = 0
                };

                var SpRespons = await _context.Database.ExecuteStoredProcedureAsync<dynamic>(proc);
                int result = proc.ResultID;
                if (result == -1)
                {
                    response.status = false;
                    response.data = "Error occurred while Updating record.";
                    return response;
                }
                else if (result == -2)
                {
                    response.status = false;
                    response.data = "An item can only have one basic unit";
                    return response;
                }
                else if (result == -3)
                {
                    response.status = false;
                    response.data = "AlternatId not found ";
                    return response;
                }
                else if (result == -4)
                {
                    response.status = false;
                    response.data = "ItemId not found ";
                    return response;
                }

                response.status = true;
                response.data = "Updated Successfully";
                return response;



            }
            catch (Exception ex)
            {
                response.status = false;
                response.data = $"Something went wrong:{ex.Message}";
                return response;
            }
        }







    }
}
