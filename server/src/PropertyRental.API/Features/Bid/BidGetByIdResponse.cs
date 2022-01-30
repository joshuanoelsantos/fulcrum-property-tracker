using AutoMapper;
using PropertyRental.Core;

namespace PropertyRental.API
{
    public record BidGetByIdResponse
    {
        public string BidId { get; init; }
        public string Address1 { get; init; }
        public string Address2 { get; init; }
        public decimal MarketValue { get; init; }
        public decimal CurrentBid { get; init; }
    }

    public class BidGetByIdResponseProfile : Profile
    {
        public BidGetByIdResponseProfile()
        {
            CreateMap<BidWithProperty, BidGetByIdResponse>()
                .ForMember(
                    dest => dest.BidId,
                    opt => opt.MapFrom(src => src.CurrentBid.Id))
                .ForMember(
                    dest => dest.Address1,
                    opt => opt.MapFrom(src => src.Property.Address1))
                .ForMember(
                    dest => dest.Address2,
                    opt => opt.MapFrom(src => src.Property.Address2))
                .ForMember(
                    dest => dest.CurrentBid,
                    opt => opt.MapFrom(src => src.CurrentBid.Amount))
                .ForMember(
                    dest => dest.MarketValue,
                    opt => opt.MapFrom(src => src.Property.MarketValue))
                ;
        }
    }
}