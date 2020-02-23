using HwInfoReader.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HwInfoReader.AspNetCore
{
    public static class HwInfoReaderCollectionExtensions
    {
        public static IServiceCollection AddHwInfoReader(this IServiceCollection services)
        {
            services.AddTransient<IHwInfoReader, HwInfoReader>();

            return services;
        }
    }
}
