

using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection services);
    }
}
