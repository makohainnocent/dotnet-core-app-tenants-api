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

 public interface ITenantsRepository
    {
        //get all Tenant
        List<TenantsRooms>  GetAll();

        //get  Tenant by id 
        List<TenantsRooms>  GetById(int id);


        //get Tenant
        //List<dynamic>  GetTenant(int id);
    }