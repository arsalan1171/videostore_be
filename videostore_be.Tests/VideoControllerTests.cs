namespace videostore_be.Tests;
using videostore_be.Controllers;
using videostore_be.Models;
using videostore_be.service;
using videostore_be.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetVideoById_WhenVideoExists_ReturnsOkResult()
    {
        // Arrange
        int videoId = 1;
        var expectedVideo = new Videos { VideosId = videoId, Title = "Sample Video" };

        // Mock the repository
        var mockVideoRepository = new Mock<VideoService>();
        mockVideoRepository.Setup(repo => repo.getVideoById(videoId))
                           .ReturnsAsync(expectedVideo);

        // Create the VideosController with the mocked repository
        var controller = new VideosController(mockVideoRepository.Object);

        // Act
        var result = await controller.GetVideoById(videoId);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.AreEqual(expectedVideo, okResult.Value);
    }

    [Test]
    public async Task GetVideoById_WhenVideoNotExists_ReturnsNotFoundResult()
    {
        // Arrange
        int nonExistentVideoId = 999;

        // Mock the VideoRepository to return null (video not found)
        var mockVideoRepository = new Mock<VideoService>();
        mockVideoRepository.Setup(repo => repo.getVideoById(nonExistentVideoId))
                           .Returns(Task.FromResult<Videos>(null));

        // Create the VideoController with the mocked repository
        var controller = new VideosController(mockVideoRepository.Object);

        // Act
        var result = await controller.GetVideoById(nonExistentVideoId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
}
