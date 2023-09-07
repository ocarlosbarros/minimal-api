using Microsoft.EntityFrameworkCore;

public static class CustomerRoutes {
  
  public static IApplicationBuilder UseCustomerRoutes(this IApplicationBuilder builder)
  {
    return builder.UseEndpoints(endpoints => 
    {
      endpoints.MapGet("/Customers", async (AppDbContext dbContext) => 
      await dbContext.Customer.ToListAsync());

      endpoints.MapGet("/Customers/{id}", async (int id, AppDbContext dbContext) => 
    await dbContext.Customer.FirstOrDefaultAsync(customer => customer.Id == id));

    endpoints.MapPost("/Customers", async (Customer customer, AppDbContext dbContext) => 
    {
      dbContext.Customer.Add(customer);
      await dbContext.SaveChangesAsync();

      return customer;
    });

    endpoints.MapPut("/Customers/{id}", async (int id, Customer customer, AppDbContext dbContext) => 
    {
      dbContext.Entry(customer).State = EntityState.Modified;
      await dbContext.SaveChangesAsync();
      
      return customer;
    });

    endpoints.MapDelete("/Customers/{id}", async (int id, AppDbContext dbContext) => 
    {
      var customer = await dbContext.Customer.FirstOrDefaultAsync(customer => customer.Id == id);

      if (customer != null) {
        dbContext.Customer.Remove(customer);
        await dbContext.SaveChangesAsync();
      }
      return;
    });
  });
}

  

  

  

  

  
}