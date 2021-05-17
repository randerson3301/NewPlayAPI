using SimpleInjector;
using NewPlay.Domain.Interfaces;
using NewPlay.Infrastructure.Repositories;

namespace NewPlay.Infrastructure.IoC
{
    public static class BootStrapper
    {
        public static void Register(Container container, bool serviceQuartz = false){
            container.Register(typeof(IDeveloperRepository), typeof(DeveloperRepository));
            container.Register(typeof(IGameGenreRepository), typeof(GameGenreRepository));
            container.Register(typeof(IGamePlatformRepository), typeof(GamePlatformRepository));
            container.Register(typeof(IGameRepository), typeof(GameRepository));
            container.Register(typeof(IGenreRepository), typeof(GenreRepository));
            container.Register(typeof(IPlatformRepository), typeof(PlatformRepository));
            container.Register(typeof(IPublisherRepository), typeof(PublisherRepository));
            container.Register(typeof(IRepository<>), typeof(RepositoryBase<>));
            container.Register(typeof(IUserGameRepository), typeof(UserGameRepository));
            container.Register(typeof(IUserGenreRepository), typeof(UserGenreRepository));
            container.Register(typeof(IUserPlatformRepository), typeof(UserPlatformRepository));
            container.Register(typeof(IUserRepository), typeof(UserRepository));
        }

        public static void Initialize(){
            
        }
    }
}