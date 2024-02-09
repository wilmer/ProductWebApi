using Application.Abstractions;
using Application.Products.Commands;
using Domain.Models;
using MediatR;

namespace Application.Products.CommandHandlers;

public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
    {
        var newProduct = new Product
        {
            Name = request.Name,
            StatusName = request.StatusName,
            Stock = request.Stock,
            Descripcion = request.Descripcion,
            Price = request.Price,
            Discount = request.Discount,
            FinalPrice = request.FinalPrice,

        };

        return await _productRepository.CreateProduct(newProduct);
    }
}