using DevRoom.Application.Contracts.Persistence;
using DevRoom.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevRoom.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DevRoomDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DevRoomConnectionStringSqlServerLin")));

            //services.AddEntityFrameworkNpgsql().AddDbContext<DevRoomDbContext>(options =>
            //    options.UseNpgsql(configuration.GetConnectionString("DevRoomConnectionStringPostgre")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITipRepository, TipRepository>();
            
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
