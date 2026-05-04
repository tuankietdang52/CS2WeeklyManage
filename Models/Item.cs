using CS2WeeklyManage.Models.Commons;

namespace CS2WeeklyManage.Models
{
    public class Item : BaseModel
    {
        public double Price { get; set; }
        public string Name { get; set; } = "";
        public string HashName { get; set; } = "";
    }
}