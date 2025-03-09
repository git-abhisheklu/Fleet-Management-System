using System;

namespace Fleet_Management.DTO
{
    public class BookingDetailDTO
    {
        public long BookingDetailId { get; set; }
        public long AddonId { get; set; }
        public double AddonRate { get; set; }

        public BookingDetailDTO() { }

        public BookingDetailDTO(long bookingDetailId, long addonId, double addonRate)
        {
            BookingDetailId = bookingDetailId;
            AddonId = addonId;
            AddonRate = addonRate;
        }
    }
}
