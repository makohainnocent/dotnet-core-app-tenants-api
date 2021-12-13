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

 public interface IPayementsRepository
    {
        //get all Payements
        List<PayementsRoomsTenants>  GetAll();

        //get  payement by id 
        List<PayementsRoomsTenants>  GetById(int id);


    }