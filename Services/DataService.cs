using SteveSimmsCodesBlog.Data;
namespace SteveSimmsCodesBlog;

public class DataService 
{
    //private(property)instance of the db context so we can use it in the service can not be queried outside of the class
    private readonly ApplicationDbContext _dbContext;
    
    // constructor injection so the context is ready to go when the service is created concept: inversion of control/ dependency injection    
    public DataService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
}
    //Task 1: Seed a few roles into the system to the system
    //Task 2: Seed a user into the system - programatically add a user to the system
    

