using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PropertyRental.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyRental.API
{
    [ApiController]
    [Route("api/bids")]
    public class BidController : ControllerBase
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        private readonly IBidService _bidService;

        public BidController(
            ICurrentUser currentUser,
            IMapper mapper,
            IBidService bidService)
        {
            _currentUser = currentUser;
            _mapper = mapper;
            _bidService = bidService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BidGetAllResponse>>> GetAll()
        {
            List<BidWithPropertyAndHighestBid> bids = await _bidService.GetByUser(_currentUser.UserId);

            List<BidGetAllResponse> response = _mapper.Map<List<BidGetAllResponse>>(bids);

            return response;
        }

        [HttpGet("{bidId}")]
        public async Task<ActionResult<BidGetByIdResponse>> GetById([ObjectId] string bidId)
        {
            BidWithProperty bid = await _bidService.GetById(bidId);

            if(bid == null)
            {
                return NotFound();
            }

            BidGetByIdResponse response = _mapper.Map<BidGetByIdResponse>(bid);

            return response;
        }

        [HttpGet("total")]
        public async Task<ActionResult<BidGetTotalResponse>> GetTotal()
        {
            List<BidWithPropertyAndHighestBid> bids = await _bidService.GetByUser(_currentUser.UserId);

            BidGetTotalResponse bidsResponse = new(bids);

            return bidsResponse;
        }
    }
}