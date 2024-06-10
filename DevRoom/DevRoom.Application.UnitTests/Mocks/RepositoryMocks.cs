using DevRoom.Application.Contracts.Persistence;
using DevRoom.Application.Enums;
using DevRoom.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace DevRoom.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Content>> GetContentRepository()
        {
            var contents = new List<Content>
            {
                new Content
                {
                    Id = Guid.NewGuid(),
                    Title = "Lifecycle hooks",
                    SubHeading = "test",
                    Tags = "Angular, Front, Dev, TypeScript, JavaScript",
                    
                  
                },
                new Content
                {
                    Id = Guid.NewGuid(),
                    Title = "Identity",
                    Tags = "Net, NetCore, C#, back, ORM",
                    
                   
                }
            };

            var mockContentRepository = new Mock<IAsyncRepository<Content>>();
            mockContentRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(contents);

            mockContentRepository.Setup(repo => repo.AddAsync(It.IsAny<Content>())).ReturnsAsync(
                (Content content) =>
                {
                    contents.Add(content);
                    return content;
                });

            return mockContentRepository;
        }

       
        public static Mock<IAsyncRepository<Tag>> GetTagRepository()
        {

            var tags = new List<Tag>{
                new Tag{
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Belmonte",
                    Status = (int)Status.Created,
                    Name = "dev",
                },
                new Tag{
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Belmonte",
                    Status = (int)Status.Created,
                    Name = "frontend",
                },
                new Tag{
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Belmonte",
                    Status = (int)Status.Created,
                    Name = "backend",
                },
                new Tag{
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Belmonte",
                    Status = (int)Status.Created,
                    Name = "development",
                },
                new Tag{
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Belmonte",
                    Status = (int)Status.Created,
                    Name = "programação",
                },
            };
             var mockTagRepository = new Mock<IAsyncRepository<Tag>>();
            mockTagRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(tags);

            mockTagRepository.Setup(repo => repo.AddAsync(It.IsAny<Tag>())).ReturnsAsync(
                (Tag tag) =>
                {
                    tags.Add(tag);
                    return tag;
                });

            return mockTagRepository;
        }

    }
}