namespace Fleet_Management.Models.DTO
{
    public class AddOnMasterDTO
    {
        public long AddonId { get; set; }
        public string AddonName { get; set; }
        public double? AddonDailyRate { get; set; }
        public DateOnly? RateValidUpto { get; set; }
    }
}
