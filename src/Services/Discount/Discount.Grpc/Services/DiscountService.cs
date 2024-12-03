using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

// To get these classes "DiscountProtoService.DiscountProtoServiceBase", first build the solution after
// creating the discount.proto file and updating the properties of the discount.proto file
//Set Build Action = Protobuf compiler
//gRPC Stub Classes = Server only
public class DiscountService (DiscountContext dbContext, ILogger<DiscountService> logger) 
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon is null)
        {
            coupon = new Coupon { ProductName = request.ProductName, Description = "No Discount", Amount = 0 };
        }

        logger.LogInformation($"Discount is retrieved for ProductName: {request.ProductName}, Amount : {coupon.Amount}");

        var couponModel = coupon.Adapt<CouponModel>();

        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();
        if(coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation($"Discount is created for ProductName: {coupon.ProductName}, Amount: {coupon.Amount}");

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var updatedCoupon = request.Coupon.Adapt<Coupon>();
        if(updatedCoupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));
        }

        dbContext.Coupons.Update(updatedCoupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation($"Discount is updated for ProductName: {updatedCoupon.ProductName}");

        var couponModel = updatedCoupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if(coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, $"No coupon exists for product : {request.ProductName}"));
        }

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();
        logger.LogInformation($"Discount is deleted for ProductName: {coupon.ProductName}");
        return new DeleteDiscountResponse { Success = true};
    }
}
