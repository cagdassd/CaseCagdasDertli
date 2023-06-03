using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;


		}





		public ApiResponse<List<ProductDto>> GetAll()
		{
			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data = _productDal.GetProductDetails();

			if (!response.Data.IsNullOrEmpty())
			{
				response.ResultMessage = "Ürünler Başarıyla Listelendi";
				response.Status = Status.Success;
				response.ErrorCode = "200";
				return response;
			}
			else
			{
				response.ResultMessage = "Ürünler Listelenirken Hata Oluştu";
				response.Status = Status.Failed;
				response.ErrorCode = "500";
				return response;
			}
		}

		public ApiResponse<List<ProductDto>> GetAllByCategory(string categoryName)
		{
			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data = _productDal.GetProductDetails();

			if (!response.Data.IsNullOrEmpty())
			{
				response.ResultMessage = "Ürünler Kategoriye Göre Başarıyla Listelendi";
				response.Status = Status.Success;
				response.ErrorCode = "200";
				return response;
			}
			else
			{
				response.ResultMessage = "Ürünler Listelenirken Hata Oluştu";
				response.Status = Status.Failed;
				response.ErrorCode = "500";
				return response;
			}
		}


	}
}
