using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using AutoMapper;
using DevRoom.Application.Contracts.Persistence;
using DevRoom.Domain.Entities;
using DevRoom.Application.UnitTests.Mocks;
using DevRoom.Application.Profiles;
using DevRoom.Application.Features.Contents.Commands.Create;

namespace DevRoom.Application.UnitTests.Contents.Commands
{
    public class CreateContentTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Content>> _mockContentRepository;
        public CreateContentTests()
        {
            _mockContentRepository = RepositoryMocks.GetContentRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidContent_AddedToCategoriesRepo()
        {
            var handler = new CreateContentCommandHandler(_mapper, _mockContentRepository.Object);

            await handler.Handle(new CreateContentCommand() {  }, CancellationToken.None);

            var allCategories = await _mockContentRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
        }
    }
}