using Microsoft.AspNetCore.Identity;

namespace OutFitShop.Models
{
    public class ApplicationUser : IdentityUser { 
        
        List<Order> Orders { get; set; } 
    
    }
    
}
