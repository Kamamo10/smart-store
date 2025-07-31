using System;

using Newtonsoft.Json;

namespace ItemService.ItemMaster.Models
{
    public class ItemDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("companyCode")]
        public string CompanyCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("descriptionLong")]
        public string DescriptionLong { get; set; }
        
        [JsonProperty("descriptionShort")]
        public string DescriptionShort { get; set; }
        
        [JsonProperty("entryDate")]
        public DateTime EntryDate { get; set; }
        
        [JsonProperty("imageUrls")]
        public string[] ImageUrls { get; set; }
        
        [JsonProperty("itemCode")]
        public string ItemCode { get; set; }
        
        [JsonProperty("itemDetails")]
        public string ItemDetails { get; set; }
        
        [JsonProperty("lastUpdateDate")]
        public DateTime LastUpdateDate { get; set; }
        
        [JsonProperty("manufacturerCode")]
        public string ManufacturerCode { get; set; }
        
        [JsonProperty("mdHierarchies")]
        public MdHierarchy[] MdHierarchies { get; set; }
        
        [JsonProperty("storeCode")]
        public string StoreCode { get; set; }
        
        [JsonProperty("tax")]
        public Tax Tax { get; set; }
        
        [JsonProperty("unitCost")]
        public int UnitCost { get; set; }
        
        [JsonProperty("unitPrice")]
        public int UnitPrice { get; set; }
        
        [JsonProperty("expireDate")]
        public DateTime? ExpireDate { get; set; }
    }
}