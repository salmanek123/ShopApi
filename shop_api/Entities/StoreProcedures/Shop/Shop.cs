using System.Data;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExtras.EFCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shop_api.Entities.StoreProcedures.Shop
{
    public class Shop
    {

        [StoredProcedure("proc_AddItem")]
        public class AddItemsp

        {
        
            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string ItemCode { get; set; }

            [StoredProcedureParameter(SqlDbType.BigInt)]
            public long CurrentStock { get; set; }   

            [StoredProcedureParameter(SqlDbType.Float)]
            public double? Cost { get; set; }   

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string? Notes { get; set; }

            [StoredProcedureParameter(SqlDbType.Float)]
            public double? TaxPerc { get; set; }
            [StoredProcedureParameter(SqlDbType.Int,Direction =ParameterDirection.Output)]
            public int ResultID { get; set; }

        }

        [StoredProcedure("proc_AddAlternateUnits")]
        public class AddAlterUnits
        {
            [StoredProcedureParameter(SqlDbType.Int)]
            public int ItemId { get; set; }
            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string Unit { get; set; }
            [StoredProcedureParameter(SqlDbType.NVarChar)]

            public string? ItemName { get; set; }
            [StoredProcedureParameter(SqlDbType.Float)]

            public double Conversion { get; set; }
            [StoredProcedureParameter(SqlDbType.Float)]

            public double RetailRate { get; set; }
            [StoredProcedureParameter(SqlDbType.NVarChar)]

            public string? Barcode { get; set; }
            [StoredProcedureParameter(SqlDbType.Bit)]

            public bool IsBasic { get; set; }

            [StoredProcedureParameter(SqlDbType.Int,Direction =ParameterDirection.Output)]
            public int ResulID { get; set; }
        }


        [StoredProcedure("proc_GetAllItems")]
        public class GetItems
        {

            [StoredProcedureParameter(SqlDbType.Int)]
            public int ? ItemId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int)]
            public int Page { get; set; }
            [StoredProcedureParameter(SqlDbType.Int)]
            public int Limit { get; set; }
            [StoredProcedureParameter(SqlDbType.Int,Direction =ParameterDirection.Output)]
            public int TotalCount { get; set; }
            [StoredProcedureParameter(SqlDbType.Int,Direction =ParameterDirection.Output)]
            public int ResultID { get; set; }

        }

        [StoredProcedure("proc_UpdateItems")]

        public class UpdateItems
        {
            [StoredProcedureParameter(SqlDbType.Int)]

            public int ItemId { get; set; }
            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string? ItemCode { get; set; }

            [StoredProcedureParameter(SqlDbType.BigInt)]
            public long? CurrentStock { get; set; }   

            [StoredProcedureParameter(SqlDbType.Float)]
            public double? Cost { get; set; }   

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string? Notes { get; set; }

            [StoredProcedureParameter(SqlDbType.Float)]
            public double? TaxPerc { get; set; }

            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
            public int ResultID { get; set; }
        }


        [StoredProcedure("proc_DeleteItems")]

        public class DeleteItems
        {
            [StoredProcedureParameter(SqlDbType.Int)]

            public int ItemId { get; set; }

            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
            public int ResultID { get; set; }

        }

        [StoredProcedure("proc_UpdateAlternateUnit")]
        public class UpdateAlternateData
        {
            [StoredProcedureParameter(SqlDbType.Int)]
            public int AltUnitId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int)]
            public int ?ItemId { get; set; }

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string? Unit { get; set; }   

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string? ItemName { get; set; }  

            [StoredProcedureParameter(SqlDbType.Float)]
            public double? Conversion { get; set; }

            [StoredProcedureParameter(SqlDbType.Float)]
            public double? RetailRate { get; set; }

            [StoredProcedureParameter(SqlDbType.NVarChar)]
            public string? Barcode { get; set; }

            [StoredProcedureParameter(SqlDbType.Bit)]
            public bool? IsBasic { get; set; }

            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
            public int ResultID { get; set; }
        }


        [StoredProcedure("proc_GetItem_Alternateunit")]
        public class GetAllItems
        {
            [StoredProcedureParameter(SqlDbType.Int)]
            public int? ItemId { get; set; }
            [StoredProcedureParameter(SqlDbType.Int)]
            public int Page { get; set; }
            [StoredProcedureParameter(SqlDbType.Int)]
            public int Limit { get; set; }
            [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
            public int TotalCount { get; set; }
            // [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
            // public int ResultID { get; set; }

        }
        //[StoredProcedure("proc_UpdateItem")]
        //public class UpdateAlternateUnitAndItems
        //{
        //    [StoredProcedureParameter(SqlDbType.Int)]
        //    public int ItemId { get; set; }

        //    [StoredProcedureParameter(SqlDbType.NVarChar)]
        //    public string? ItemCode { get; set; }

        //    [StoredProcedureParameter(SqlDbType.BigInt)]
        //    public long? CurrentStock { get; set; }   

        //    [StoredProcedureParameter(SqlDbType.Float)]
        //    public double? Cost { get; set; }  

        //    [StoredProcedureParameter(SqlDbType.NVarChar)]
        //    public string? Notes { get; set; }

        //    [StoredProcedureParameter(SqlDbType.Float)]
        //    public double? TaxPerc { get; set; }

        //    [StoredProcedureParameter(SqlDbType.Udt)]
        //    public List<AddAlternateUnitType>? AltUnits { get; set; }

        //    [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
        //    public int ResultID { get; set; }
        //}





        //[StoredProcedure("proc_Additemalternate")]
        //public class AddAlternateunittable
        //{
        //    [StoredProcedureParameter(SqlDbType.NVarChar)]
        //    public string ItemCode { get; set; }

        //    [StoredProcedureParameter(SqlDbType.BigInt)]
        //    public long CurrentStock { get; set; }   

        //    [StoredProcedureParameter(SqlDbType.Float)]
        //    public double Cost { get; set; }   

        //    [StoredProcedureParameter(SqlDbType.NVarChar)]
        //    public string Notes { get; set; }

        //    [StoredProcedureParameter(SqlDbType.Float)]
        //    public double TaxPerc { get; set; }

        //    [StoredProcedureParameter(SqlDbType.Udt)]
        //    public List<AddAlternateUnitType> AltUnits { get; set; }

        //    [StoredProcedureParameter(SqlDbType.Int, Direction = ParameterDirection.Output)]
        //    public int ResultID { get; set; }
        //}




        //[UserDefinedTableType("AlternateUnitTypes")]
        //public class AddAlternateUnitType
        //{
        //    [UserDefinedTableTypeColumn(1)]
        //    public int? AltUnitId { get; set; }
        //    [UserDefinedTableTypeColumn(2)]
        //    public string Unit { get; set; }

        //    [UserDefinedTableTypeColumn(3)]
        //    public string ItemName { get; set; }

        //    [UserDefinedTableTypeColumn(4)]
        //    public double Conversion { get; set; }

        //    [UserDefinedTableTypeColumn(5)]
        //    public double RetailRate { get; set; }

        //    [UserDefinedTableTypeColumn(6)]
        //    public string Barcode { get; set; }

        //    [UserDefinedTableTypeColumn(7)]
        //    public bool IsBasic { get; set; }


        //}




    }
}
