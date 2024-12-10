using Prueba.Models;

namespace Prueba.Types;

[QueryType]

public  class Query
{

    [UseProjection]
        
    public IQueryable<Categorium> categorias ([Service] DbventaBlazorContext db)
        => db.Categoria;

    [UseProjection]
     public IQueryable<Usuario> usuarios ([Service] DbventaBlazorContext db)
        => db.Usuarios;
    
    [UsePaging(MaxPageSize = 4)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Producto> productos ([Service] DbventaBlazorContext db)
        => db.Productos;


     [UseProjection]
    public IQueryable<Rol> roles ([Service] DbventaBlazorContext db)
        => db.Rols;

    [UseProjection]
    public IQueryable<Ventum> ventas ([Service] DbventaBlazorContext db)
        => db.Venta;

    
     [UseProjection]
    public IQueryable<DetalleVentum> detalleVenta([Service] DbventaBlazorContext db)
        => db.DetalleVenta;

   
   
    [UseProjection]
    public Usuario? usuario([GraphQLName("name")] string username,[Service] DbventaBlazorContext db)=>db.Usuarios.Where(x=>x.Correo == username).FirstOrDefault();

     
     
     
     [UseProjection]
     [GraphQLName("usuarioID")]
    public Usuario? usuario([GraphQLName("id")]int id,[Service] DbventaBlazorContext db)=>db.Usuarios.Where(x=>x.IdUsuario == id).FirstOrDefault();
    
}
