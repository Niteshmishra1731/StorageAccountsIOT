using StorageAccounts.DTO_s;
using Azure.Data.Tables;

namespace StorageAccounts.Repsitory
{
    public class TableStorage
    {
        static string connectionstring = "DefaultEndpointsProtocol=https;AccountName=iotstorage301;AccountKey=Rw0WJwYEjR86sf2I3vP3k2rjJBZ0chikTHsPXupfu2Bafx7am2dlUQhN1GDyPdO2qUhgMzBwBhxH+ASt2YgGEw==;EndpointSuffix=core.windows.net";
        public static async Task AddTable(string tableName)
        {
            var data = new TableServiceClient(connectionstring);
            var client = data.GetTableClient(tableName);
            await client.CreateIfNotExistsAsync();

        }
        public static async Task<Details> UpdateTable(Details employee,string tableName)
        {
            var data = new TableServiceClient(connectionstring);
            var client = data.GetTableClient(tableName);
            await client.UpsertEntityAsync(employee);
            return null;
        }
        public static async Task<Details> GetTableData(string tableName,string partitionKey,string rowKey)
        {
            var data = new TableServiceClient(connectionstring);
            var client = data.GetTableClient(tableName);
            var tableData = await client.GetEntityAsync<Details>(partitionKey, rowKey);
            return tableData;
        }
        public static async Task<TableClient> GetTable(string tableName)
        {
            var data = new TableServiceClient(connectionstring);
            var client = data.GetTableClient(tableName);
            return client;
        }
        public static async Task DeleteTableData(string tableName,string department,string id)
        {
            var data = new TableServiceClient(connectionstring);
            var client=data.GetTableClient(tableName);
            await client.DeleteEntityAsync(department, id);
            return; 
        }
    }
}
