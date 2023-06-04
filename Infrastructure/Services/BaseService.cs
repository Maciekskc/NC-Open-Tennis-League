using Infrastructure.mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistance;
using Persistance.Models;

namespace Infrastructure.Services
{
    public class BaseService
    {
        protected ApplicationDbContext DbContext { get; }
        //protected UserManager<ApplicationUser> UserManager { get; }
        protected CustomMaperlyMapper Mapper { get; }

        public BaseService(IServiceProvider serviceProvider)
        {
            DbContext = serviceProvider.GetService<ApplicationDbContext>() ?? throw new Exception("Cannot get DB context from IServiceProvider.");
            //UserManager = serviceProvider.GetService<UserManager<ApplicationUser>>() ?? throw new Exception("Cannot get UserManager from IServiceProvider.");
            Mapper = new CustomMaperlyMapper();
        }
    }
}
