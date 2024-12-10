using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Subscriptions;
using Prueba.Models;

namespace Prueba.Types
{

    [MutationType]
    public class Mutation
    {
  
         public async Task<bool> DeleteUser( [GraphQLName("Usuario")]   int y,[Service] DbventaBlazorContext db)
        {
            db.Usuarios.Remove(db.Usuarios.Where(x=>x.IdUsuario== y).First());
            return db.SaveChanges() >= 1 ? true : false;
        }       

            public async Task<Producto> CreateProducto( [Service] DbventaBlazorContext db,  [Service] ITopicEventSender eventSender )
        {

            Producto p = new Producto();

            p.Nombre = "holaa";
            p.Stock = 1000;
            p.FechaRegistro = DateTime.Now;
            db.Productos.Add(p);
            
            db.SaveChanges();

            await eventSender.SendAsync(nameof(Subscription.productoAdded), p);



            return p;


            
        }       



    }
}

