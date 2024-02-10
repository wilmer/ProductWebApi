using Application.Abstractions;
using DataAccess.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _ctx;

    public ProductRepository(ProductDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<ICollection<Product>> GetAllProducts()
    {
        return await _ctx.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int productId)
    {
        return await _ctx.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task<Product> CreateProduct(Product toCreate)
    {
        toCreate.DateCreated = DateTime.Now;
        toCreate.LastModified = DateTime.Now;

        _ctx.Products.Add(toCreate);
        await _ctx.SaveChangesAsync();

        return toCreate;
    }

    public async Task<Product> UpdateProduct(Product toUpdate, int productId)
    {
        var product = await _ctx.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

        if (product is null) return product;

        product.LastModified = DateTime.Now;
        product.Name = toUpdate.Name;
        product.StatusName = toUpdate.StatusName;
        product.Descripcion = toUpdate.Descripcion;
        product.Price = toUpdate.Price;
        product.Discount = toUpdate.Discount;
        product.FinalPrice = toUpdate.FinalPrice;

        _ctx.Products.Update(product);
        await _ctx.SaveChangesAsync();

        return product;
    }

    public async Task DeleteProduct(int productId)
    {
        var product = await _ctx.Products.FirstOrDefaultAsync(p => p.ProductId == productId);

        if (product is null) return;

        _ctx.Products.Remove(product);
        await _ctx.SaveChangesAsync();
    }
}