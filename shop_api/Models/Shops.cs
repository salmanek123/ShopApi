using EntityFrameworkExtras.EFCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace shop_api.Models
{
    public class Shops
    {
        public class AddItemRequest
        {
            [Required]

            public string ItemCode { get; set; }
            [Required]
            public long  CurrentStock { get; set; }   

            public double? Cost { get; set; }  

            public string? Notes { get; set; }

            public double? TaxPerc { get; set; }
        }

        public class AltUnitRequest
        {
            [Required]
            public int ItemId { get; set; }
            [Required]
            public string Unit { get; set; }
            public string? ItemName { get; set; }
            [Required]
            public double Conversion { get; set; }
            [Required]
            public double RetailRate { get; set; }
            public string? Barcode { get; set; }
            [Required]
            public bool IsBasic { get; set; }



        }

        public class ItemResponse
        {
            public int? ItemId { get; set; }
            public string? ItemCode { get; set; }

            public double? CurrentStock { get; set; }   

            public double? Cost { get; set; }   

            public string? Notes { get; set; }

            public double? TaxPerc { get; set; }
        }


        public class ItemAlterRequest
        {
            public string ItemCode { get; set; }
            public long CurrentStock { get; set; }
            public float Cost { get; set; }
            public string Notes { get; set; }
            public float TaxPerc { get; set; }
            public List<AltUnitRequests> ?AltUnits { get; set; }
        }
        public class AltUnitRequests
        {
            //public int? AltUnitId { get; set; }
            public string Unit { get; set; }
            public string ItemName { get; set; }
            public double Conversion { get; set; }
            public double RetailRate { get; set; }
            public string Barcode { get; set; }
            public bool IsBasic { get; set; }



        }

        public class ItemUpdateRequest
        {
           // public int? ItemId { get; set; }
            public string? ItemCode { get; set; }

            public long? CurrentStock { get; set; }  

            public double? Cost { get; set; }   

            public string? Notes { get; set; }

            public double? TaxPerc { get; set; }
        }


        public class UpdateAlternateUnit
        {
            public int? ItemId { get; set; }
            public string? Unit { get; set; }
            public string? ItemName { get; set; }
            public double? Conversion { get; set; }
            public double? RetailRate { get; set; }
            public string? Barcode { get; set; }
            public bool? IsBasic { get; set; }



        }



        public class ItemResponses
        {
            public int? ItemId { get; set; }
            public string? ItemCode { get; set; }
            public double? CurrentStock { get; set; }
            public double? Cost { get; set; }  
            public string? Notes { get; set; }
            public double? TaxPerc { get; set; }  
            public List<AltUnitResponse>? AltUnits { get; set; }
        }

        public class AltUnitResponse
        {
            public int? AltUnitId { get; set; }
            public string? Unit { get; set; }
            public string? ItemName { get; set; }
            public double? Conversion { get; set; }  
            public double? RetailRate { get; set; }  
            public string? Barcode { get; set; }
            public bool IsBasic { get; set; }
            public int? AltItemId { get; set; }
        }
     
        public class CombinedItemResponse
        {
            public int? ItemId { get; set; }
            public string? ItemCode { get; set; }
            public double? CurrentStock { get; set; }
            public double? Cost { get; set; }
            public string? Notes { get; set; }
            public double? TaxPerc { get; set; }
            public int? AltUnitId { get; set; }
            public string? Unit { get; set; }
            public string? ItemName { get; set; }
            public double? Conversion { get; set; }
            public double? RetailRate { get; set; }
            public string? Barcode { get; set; }
            public bool IsBasic { get; set; }
            public int? AltItemId { get; set; }
        }


        public class ItemAndAlterRequest
        {
            public int? ItemId { get; set; }
            public string? ItemCode { get; set; }
            public long? CurrentStock { get; set; }
            public float? Cost { get; set; }
            public string? Notes { get; set; }
            public float? TaxPerc { get; set; }
            public List<AlterUnitRequests>? AltUnits { get; set; }
        }
        public class AlterUnitRequests
        {
            //public int AltUnitId { get; set; }
            public string? Unit { get; set; }
            public string? ItemName { get; set; }
            public double? Conversion { get; set; }
            public double? RetailRate { get; set; }
            public string? Barcode { get; set; }
            public bool? IsBasic { get; set; }



        }

    }
}
