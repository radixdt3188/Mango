using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponAPIController(ApplicationDBContext db, IMapper mapper)
        { 
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<Coupon>>(objList);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSucess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public Object Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(x => x.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSucess = false;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public Object GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSucess = false;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponData)
        {
            try
            {
                var obj = _mapper.Map<Coupon>(couponData);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSucess = false;
            }
            return _response;
        }


        [HttpPut]
        public ResponseDto UpdateCoupon([FromBody] CouponDto couponData)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponData);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSucess = false;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDto DeleteCoupon([FromBody] int couponId)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponId == couponId);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.Message = ex.Message;
                _response.IsSucess = false;
            }
            return _response;
        }
    }
}
