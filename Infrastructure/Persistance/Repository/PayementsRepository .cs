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

public class PayementsRepository : IPayementsRepository
{   

    private readonly IApplicationDbContext _context;
    
    public PayementsRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    

    
    public  List<PayementsRoomsTenants> GetAll()
    {   

        
    
        var ap =  (from T in _context.Tenants
                 join R in _context.Rooms on T.roomId equals  R.roomId
                 join P in _context.Payements on R.roomId equals P.roomId
                 select new PayementsRoomsTenants{ 
                    firstName=T.firstName, 
                    lastName=T.lastName,
                    phone=T.phone,
                    id=P.payementId,
                    room=R.room,
                    price=R.price,
                    paid=P.Paid
                });
                
                return  ap.ToList();


    }


    public  List<PayementsRoomsTenants> GetById(int id)
    {   

        var ap =  (from T in _context.Tenants
                 join R in _context.Rooms on T.roomId equals  R.roomId
                 join P in _context.Payements on R.roomId equals P.roomId
                 where P.payementId==id
                 select new PayementsRoomsTenants{ 
                    firstName=T.firstName, 
                    lastName=T.lastName,
                    phone=T.phone,
                    id=P.payementId,
                    room=R.room,
                    price=R.price,
                    paid=P.Paid
                });
                
                return  ap.ToList();

    
    }


}



