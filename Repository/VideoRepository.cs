using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using videostore_be.Models;

public class VideosRepository : IRepository<Videos>
{
    private readonly VideoStoreContext _context;

    public VideosRepository(VideoStoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Videos>> GetAllAsync()
    {
        return await _context.Videos.ToListAsync();
    }

    public async Task<Videos> GetByIdAsync(int id)
    {
        return await _context.Videos.FindAsync(id);
    }

    public async Task<IEnumerable<Videos>> FindAsync(Expression<Func<Videos, bool>> predicate)
    {
        return await _context.Videos.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Videos video)
    {
        _context.Videos.Add(video);
        await _context.SaveChangesAsync();
    }

    public async Task<Videos> UpdateAsync(int id, Videos video)
    {
        var existingVideo = await _context.Videos.FindAsync(id);

        if (existingVideo == null)
        {
            throw new ArgumentException("Videos not found.");
        }

        existingVideo.Title = video.Title;
        existingVideo.Description = video.Description;
        existingVideo.RentalPrice = video.RentalPrice;

        await _context.SaveChangesAsync();

        return existingVideo;
    }

    public async Task<IEnumerable<Videos>> GetByNameAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return Enumerable.Empty<Videos>();
        }

        return await _context.Videos
            .Where(v => EF.Functions.Like(v.Title, $"%{searchTerm}%"))
            .ToListAsync();
    }
}
