using Application.Abstractions;
using Application.Products.Commands;
using Domain.Models;
using MediatR;

namespace Application.Products.CommandHandlers;

public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
    {
        var updatedProduct = new Product
        {
            Name = request.Name,
            StatusName = request.StatusName,
            Stock = request.Stock,
            Descripcion = request.Descripcion,
            Price= request.Price,
            Discount= request.Discount,
            FinalPrice= request.FinalPrice,
        };

        await _productRepository.UpdateProduct(updatedProduct, request.ProductId);

        return updatedProduct;
    }
}