using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Mvc;

using System.Dynamic;

public class TenantsRepository : ITenantsRepository
{   

    private readonly IApplicationDbContext _context;
    
    public TenantsRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    

    
    public  List<TenantsRooms> GetAll()
    {   

        
    
        var ap =  (from T in _context.Tenants
                 join R in _context.Rooms on T.roomId equals  R.roomId
                 select new TenantsRooms{ 
                    firstName=T.firstName, 
                    lastName=T.lastName,
                    phone=T.phone,
                    id=T.tenantId,
                    room=R.room 
                });
                
                return  ap.ToList();


    }


    public  List<TenantsRooms> GetById(int id)
    {   

        
    
        var ap =  (from T in _context.Tenants
                 join R in _context.Rooms on T.roomId equals  R.roomId
                 where T.tenantId==id
                 select new TenantsRooms{ 
                    firstName=T.firstName, 
                    lastName=T.lastName,
                    phone=T.phone,
                    id=T.tenantId,
                    room=R.room 
                });
                
                return  ap.ToList();


    }


}



