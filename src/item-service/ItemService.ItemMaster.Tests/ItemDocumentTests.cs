using System;
using ItemService.ItemMaster.Models;
using Newtonsoft.Json;
using Xunit;

namespace ItemService.ItemMaster.Tests
{
    public class ItemDocumentTests
    {
        [Fact]
        public void ItemDocument_ExpireDate_CanBeSet()
        {
            // Arrange
            var expireDate = new DateTime(2024, 12, 31, 23, 59, 59);
            var item = new ItemDocument();

            // Act
            item.ExpireDate = expireDate;

            // Assert
            Assert.Equal(expireDate, item.ExpireDate);
        }

        [Fact]
        public void ItemDocument_ExpireDate_CanBeNull()
        {
            // Arrange
            var item = new ItemDocument();

            // Act & Assert
            Assert.Null(item.ExpireDate);
        }

        [Fact]
        public void ItemDocument_ExpireDate_JsonSerialization()
        {
            // Arrange
            var expireDate = new DateTime(2024, 12, 31, 23, 59, 59);
            var item = new ItemDocument
            {
                Id = "test-id",
                ItemCode = "test-item",
                ExpireDate = expireDate
            };

            // Act
            var json = JsonConvert.SerializeObject(item);
            var deserializedItem = JsonConvert.DeserializeObject<ItemDocument>(json);

            // Assert
            Assert.Equal(expireDate, deserializedItem.ExpireDate);
            Assert.Contains("\"expireDate\":", json);
        }

        [Fact]
        public void ItemDocument_ExpireDate_JsonSerializationWithNull()
        {
            // Arrange
            var item = new ItemDocument
            {
                Id = "test-id",
                ItemCode = "test-item",
                ExpireDate = null
            };

            // Act
            var json = JsonConvert.SerializeObject(item);
            var deserializedItem = JsonConvert.DeserializeObject<ItemDocument>(json);

            // Assert
            Assert.Null(deserializedItem.ExpireDate);
        }
    }
}