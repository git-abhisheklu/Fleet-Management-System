using System;
using System.Collections.Generic;

namespace Fleet_Management.DTO
{
    public class BookingDTO
    {
        public long BookingId { get; set; }
        public DateOnly BookingDate { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmailId { get; set; } = string.Empty;
        public double? DailyRate { get; set; }
        public double? WeeklyRate { get; set; }
        public double? MonthlyRate { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


        public string PickupHubAddress { get; set; } = string.Empty;
        public string ReturnHubAddress { get; set; } = string.Empty;
        public List<BookingDetailDTO> BookingDetails { get; set; } = new();
        

        public BookingDTO() { }

        public BookingDTO(long bookingId, DateOnly bookingDate, string firstName, string lastName, string emailId,
                          double? dailyRate, double? weeklyRate, double? monthlyRate, DateOnly startDate, DateOnly endDate,
                          string pickupHubAddress, string returnHubAddress, List<BookingDetailDTO> bookingDetails)
        {
            BookingId = bookingId;
            BookingDate = bookingDate;
            FirstName = firstName;
            LastName = lastName;
            EmailId = emailId;
            DailyRate = dailyRate;
            WeeklyRate = weeklyRate;
            MonthlyRate = monthlyRate;
            StartDate = startDate;
            EndDate = endDate;
            PickupHubAddress = pickupHubAddress;
            ReturnHubAddress = returnHubAddress;
            BookingDetails = bookingDetails;
        }
    }
}
