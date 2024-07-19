using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_api.Interface;
using shop_api.Models;
using static shop_api.Models.Request;
using static shop_api.Models.Shops;

namespace shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ICrud _crud;
        public ShopController(ICrud crud) 
        {
            _crud = crud;
        }
        [HttpPost("v1/add-item")]
        public async Task<ActionResult>AddItem(AddItemRequest request)
        {

             ControllerResponse response=await _crud.AddItems(request);

            if (response.status !=true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception= new ExceptionResponse(300,appDataError,response.data);
                return BadRequest(exception);
            }
            return Ok(response);

            
        }

        [HttpGet("v1/get/items")]
        public async Task<ActionResult> GetItems(int? itemId, [FromQuery]PaginationRequest request)
        {
            ControllerResponse response = await _crud.GetItems(itemId, request);
            if(response.status !=true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response.data);

        }

        [HttpPost("v1/add-alternateunit")]
        public async Task<ActionResult>AddAlternateItem(AltUnitRequest request)
        {
            ControllerResponse response = await _crud.AddAlternateItem(request);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);

        }

       
        [HttpPut("v1/edit-items/{itemId}")]
        public async Task<ActionResult>UpdateItems(int itemId,[FromBody] ItemUpdateRequest request)
        {
            ControllerResponse  response= await _crud.UpdateItems(itemId, request);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);
        }


        [HttpDelete("v1/delete-items/{itemId}")]
        public async Task<ActionResult> UpdateItems(int itemId)
        {
            ControllerResponse response = await _crud.DeleteItems(itemId);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);
        }
       
        [HttpPut("v1/edit-alternate-unit/{alternateId}")]
        public async Task<ActionResult> UpdateAlternate(int alternateId, UpdateAlternateUnit request)
        {
            ControllerResponse response = await _crud.UpdateAlternateUnit(alternateId, request);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);
        }



        [HttpGet("v1/get-all-items")]
        public async Task<ActionResult> GetAllitems(int? itemId,[FromQuery] PaginationRequest request)
        {
            ControllerResponse response = await _crud.GetAllItems(itemId , request);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);
        }


        [HttpPost("v1/add-item-alternate")]
        public async Task<ActionResult> AddItemAndAlternateUnit(ItemAlterRequest request)
        {
            ControllerResponse response = await _crud.AddalterItems(request);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);
        }

        [HttpPut("v1/edit-alternate-and-items/{AlternatId}")]
        public async Task<ActionResult> UpdateAlternate(int AlternatId, ItemAndAlterRequest request)
        {
            ControllerResponse response = await _crud.UpdateAlternateUnitAndItems(AlternatId, request);
            if (response.status != true)
            {
                string appDataError = "Something went wrong,please try again";
                var exception = new ExceptionResponse(300, appDataError, response.data);
                return BadRequest(exception);
            }
            return Ok(response);
        }



    }
}
