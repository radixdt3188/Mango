using Mango.Services.CouponAPI.Models.Dto;
using Mango.Web.Models;

namespace Mango.Services.CouponAPI.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
