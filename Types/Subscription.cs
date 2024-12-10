using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prueba.Models;

namespace Prueba.Types
{
    [SubscriptionType]
    public class Subscription
    {
        [UseProjection]
        public Categorium CategoriaAdded([EventMessage] Categorium c) => c;

        [Subscribe]
        [Topic]
        public Producto productoAdded([EventMessage] Producto p ) => p;
    }
}