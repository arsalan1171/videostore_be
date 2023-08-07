using videostore_be.Models;
using videostore_be.Repository.Interface;
namespace videostore_be.service;

public class VideoService
{
    private readonly IRepository<Videos> _videoRepository;

    public VideoService(IRepository<Videos> videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public VideoService()
    {

    }

    public async Task<IEnumerable<Videos>> getAllVideos() => await _videoRepository.GetAllAsync();

    public async Task<IEnumerable<Videos>> getVideosByTitle(string searchTerm) => await _videoRepository.GetByNameAsync(searchTerm);

    public async Task addVideo(Videos video) => await _videoRepository.AddAsync(video);

    public async Task<Videos> updateVideoAsync(int id, Videos video) => await _videoRepository.UpdateAsync(id, video);

    public virtual Task<Videos> getVideoById(int id) => _videoRepository.GetByIdAsync(id);

    // Implement other video-related business logic methods here if needed.
}
