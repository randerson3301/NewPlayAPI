using SimpleInjector;

namespace NewPlay.Infrastructure.IoC
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices(){
            var container = new Container();

            container.Verify();
            return container;
        } 

        public static object GetInstance<TEntity>() where TEntity : class {
            var container = new Container();

            container.Options.DefaultLifestyle = new SimpleInjector.Lifestyles.AsyncScopedLifestyle();

            BootStrapper.Register(container);

            SimpleInjector.Lifestyles.AsyncScopedLifestyle.BeginScope(container);

            var instance = container.GetInstance<TEntity>();

            container.Verify();

            return instance;
        } 
    }
}