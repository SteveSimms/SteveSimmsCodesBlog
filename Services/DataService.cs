using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SteveSimmsCodesBlog.Data;
namespace SteveSimmsCodesBlog;

public class DataService 
{
    //private(property)instance of the db context so we can use it in the service can not be queried outside of the class
    private readonly ApplicationDbContext _dbContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    // constructor injection so the context is ready to go when the service is created concept: inversion of control/ dependency injection    
    public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
    {
        _dbContext = dbContext; 
        _roleManager = roleManager;
    }
//wrapper method 
    public async Task ManageDataAsync()
    {
        //Task 1: Seed a few roles into the system to the system
        await SeedRolesAsync();

         //Task 2: Seed a user into the system - programatically add a user to the system
        await SeedUsersAsync();
    }

    private async Task SeedRolesAsync()
    {
        //if there are already roles in the system do nothing
        if(_dbContext.Roles.Any())
        {
            
            return;
        }

        //Otherwise create a few roles
        foreach(var role in Enum.GetNames(typeof(BlogRole)))
        {
            //I need to use the role manager to create roles
           await _roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    private async Task SeedUsersAsync()
    {

    }

}
  
   
    

