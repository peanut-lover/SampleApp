using Domain.Models;
using Domain.Requests.Item;
using Domain.Responses.Item;

namespace Domain.Mappers;

public class ItemMapper : IItemMapper
{
    private readonly IGenreMapper _genreMapper;
    private readonly IArtistMapper _artistMapper;

    public ItemMapper(IGenreMapper genreMapper, IArtistMapper artistMapper)
    {
        _genreMapper = genreMapper;
        _artistMapper = artistMapper;
    }

    public Item? Map(AddItemRequest request)
    {
        if (request is null)
        {
            return null;
        }
        var item = new Item
        {
            Name = request.Name,
            Description = request.Description,
            LabelName = request.LabelName,
            PictureUri = request.PictureUri,
            ReleaseDate = request.ReleaseDate,
            Format = request.Format,
            AvailableStock = request.AvailableStock,
            GenreId = request.GenreId,
            ArtistId = request.ArtistId,
        };

        if (request.Price != null)
        {
            item.Price = new Price
            {
                Currency = request.Price.Currency,
                Amount = request.Price.Amount
            };
        }
        return item;
    }

    public Item? Map(EditItemRequest request)
    {
        if (request is null)
        {
            return null;
        }
        var item = new Item
        {
            Name = request.Name,
            Description = request.Description,
            LabelName = request.LabelName,
            PictureUri = request.PictureUri,
            ReleaseDate = request.ReleaseDate,
            Format = request.Format,
            AvailableStock = request.AvailableStock,
            GenreId = request.GenreId,
            ArtistId = request.ArtistId,
        };

        if (request.Price != null)
        {
            item.Price = new Price
            {
                Currency = request.Price.Currency,
                Amount = request.Price.Amount
            };
        }
        return item;
    }

    public ItemResponse Map(Item item)
    {
        var response = new ItemResponse()
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            LabelName = item.LabelName,
            PictureUri = item.PictureUri,
            Price = new PriceResponse
            {
                Currency = item.Price.Currency,
                Amount = item.Price.Amount
            },
            ReleaseDate = item.ReleaseDate,
            Format = item.Format,
            AvailableStock = item.AvailableStock,
            GenreId = item.GenreId,
            Genre = _genreMapper.Map(item.Genre),
            ArtistId = item.ArtistId,
            Artist = _artistMapper.Map(item.Artist)
        };
        return response;
    }
}