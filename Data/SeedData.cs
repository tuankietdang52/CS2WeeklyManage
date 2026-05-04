using System.Text.Json;
using System.Text.Json.Serialization;
using CS2WeeklyManage.Models;
using CS2WeeklyManage.Models.Commons;

namespace CS2WeeklyManage.Data
{
    public class MarketResponse
    {
        [JsonPropertyName("items")]

        public List<RawItem> Items { get; set; } = [];
    }

    public class RawItem
    {
        [JsonPropertyName("nameId")]
        public long NameId { get; set; }

        [JsonPropertyName("marketName")]
        public string MarketName { get; set; } = "";

        [JsonPropertyName("marketHashName")]
        public string MarketHashName { get; set; } = "";

        [JsonPropertyName("prices")]
        public Price? Price { get; set; }
    }

    public class Price
    {
        [JsonPropertyName("all")]
        public All? All { get; set; }
    }

    public class All
    {
        [JsonPropertyName("latest")]
        public double? Latest { get; set; }
    }

    public static class SeedData
    {
        public static void Seeding(ILogger logger, AppDbContext _dbContext)
        {
            long id = 0;
            try
            {
                string path =
                    Environment.GetEnvironmentVariable("INITIAL_DATA_PATH")
                    ?? throw new Exception("Path is empty");

                var json = File.ReadAllText(path);
                var rawItems = JsonSerializer.Deserialize<MarketResponse>(json);
                var items = (rawItems?.Items.Select(i =>
                {
                    id = i.NameId;
                    double price = -1;
                    if (i.Price is not null && i.Price.All is not null)
                    {
                        double? latest = i.Price.All.Latest;
                        price = latest is not null ? (double)latest : -1;
                    }

                    return new Item
                    {
                        Id = id,
                        Name = i.MarketName,
                        HashName = i.MarketHashName,
                        Price = price
                    };
                })) ?? throw new Exception("Items is null");

                _dbContext.Items.AddRange(items);
                _dbContext.SaveChanges();

                logger.LogInformation("Seed Data Success");
                return;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                logger.LogError($"Id: {id}");
                return;
            }
        }
    }
}