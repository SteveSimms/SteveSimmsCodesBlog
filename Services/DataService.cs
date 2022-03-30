using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SteveSimmsCodesBlog.Data;
using SteveSimmsCodesBlog.Models;

namespace SteveSimmsCodesBlog;

public class DataService 
{
    //private(property)instance of the db context so we can use it in the service can not be queried outside of the class
    private readonly ApplicationDbContext _dbContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<BlogUser> _userManager;
    // constructor injection so the context is ready to go when the service is created concept: inversion of control/ dependency injection    
    public DataService(ApplicationDbContext dbContext, 
                        RoleManager<IdentityRole> roleManager,
                        UserManager<BlogUser> userManager)
    {
        _dbContext = dbContext; 
        _roleManager = roleManager;
        _userManager = userManager;
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
              //if there are already users in the system do nothing
              if(_dbContext.Users.Any())
              {
                  
                  return;
              }

              //Step 1: Creates a new instance of BlogUser
              var adminUser = new BlogUser()
              {
                  Email = "simmsstev@gmail.com",
                  UserName = "simmsstev@gmail.com",
                  FirstName = "Steve",
                  LastName = "Simms",
                  PhoneNumber = "555-555-5555",
                  EmailConfirmed = true
              };

              //Step 2 Use the UserManager to create a new user that is defined by the admin user variable
              await _userManager.CreateAsync(adminUser,"Abc&123!");

              //Step 3. Add this new user to the administrator role
             await  _userManager.AddToRoleAsync(adminUser,BlogRole.Administrator.ToString());

             //Step1 repeat for the other roles moderator
            //creating a new local instance of bloguser to describe a moderator 
            var modUser = new BlogUser()
              {
                  Email = "malik@asianca.com",
                  UserName = "malik@asianca.com",
                  FirstName = "Malik",
                  LastName = "Simms",
                  PhoneNumber = "555-555-1234",
                  EmailConfirmed = true
              };


                await _userManager.CreateAsync(modUser,"Abc&123!");

                await _userManager.AddToRoleAsync(modUser,BlogRole.Moderator.ToString());
    }

}
  
   
    

