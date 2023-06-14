using Infrastructure.mappers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance;

namespace Infrastructure.Services
{
    public class BaseService<T>
    {
        protected readonly ILogger<T> Logger;

        protected ApplicationDbContext DbContext { get; }
        //protected UserManager<ApplicationUser> UserManager { get; }
        protected CustomMaperlyMapper Mapper { get; }

        public BaseService(IServiceProvider serviceProvider, ILogger<T> logger)
        {
            DbContext = serviceProvider.GetService<ApplicationDbContext>() ?? throw new Exception("Cannot get DB context from IServiceProvider.");
            //UserManager = serviceProvider.GetService<UserManager<ApplicationUser>>() ?? throw new Exception("Cannot get UserManager from IServiceProvider.");
            Mapper = new CustomMaperlyMapper();
            Logger = logger;
        }
    }
}
