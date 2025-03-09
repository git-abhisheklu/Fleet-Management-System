namespace Fleet_Management.Models.DTO
{
    public class CarTypeMasterDTO
    {
        public long CartypeId { get; set; }
        public string? CarTypeName { get; set; }
        public double? DailyRate { get; set; }
        public double? WeeklyRate { get; set; }
        public double? MonthlyRate { get; set; }
        public string? ImagePath { get; set; }
    }
}
