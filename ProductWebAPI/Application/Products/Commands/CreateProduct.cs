using Domain.Models;
using MediatR;

namespace Application.Products.Commands;

public class CreateProduct : IRequest<Product>
{
    public string? Name { get; set; }

    public string? StatusName { get; set; }

    public string? Stock { get; set; }
    public string? Descripcion { get; set; }
    public string? Price { get; set; }
    public string? Discount { get; set; }
    public string? FinalPrice { get; set; }
}