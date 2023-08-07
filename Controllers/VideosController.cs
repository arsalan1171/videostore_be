using Microsoft.AspNetCore.Mvc;
using videostore_be.Models;
using videostore_be.service;
namespace videostore_be.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideosController : ControllerBase
{
    private readonly VideoService _videoService;

    public VideosController(VideoService videoService)
    {
        _videoService = videoService;
    }

    // GET: api/videos
    [HttpGet]
    public async Task<IActionResult> GetVideos()
    {
        var videos = await _videoService.getAllVideos();
        return Ok(videos);
    }

    // GET: api/videos/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVideoById(int id)
    {
        var video = await _videoService.getVideoById(id);

        if (video == null)
        {
            return NotFound();
        }

        return Ok(video);
    }

    // POST: api/videos
    [HttpPost]
    public async Task<IActionResult> PostVideo([FromBody] Videos video)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _videoService.addVideo(video);
        return CreatedAtAction(nameof(GetVideoById), new { id = video.VideosId }, video);
    }

    // PUT: api/videos/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVideo(int id, [FromBody] Videos video)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Videos updatedVideos;

        try
        {
            updatedVideos = await _videoService.updateVideoAsync(id, video);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex}");
            return StatusCode(500, "An unexpected error occurred.");
        }

        return Ok(updatedVideos);
    }

    // GET: api/videos/search_video?searchTerm=Action
    [HttpGet("search_video")]
    public async Task<IActionResult> GetVideosByTitle(string searchTerm)
    {
        try
        {
            var searchResults = await _videoService.getVideosByTitle(searchTerm);
            return Ok(searchResults);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex}");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}
