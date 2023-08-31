**Relaciones entre clases:**
- Pedido - Cliente COMPOSICION
     Un pedido esta fuertemente ligado a un pedido, ya que volviendo a la realidad, no tiene sentido crear un pedido que nadie solicito.

- Cadeteria - Cadete AGREGACION
    Si bien una cadeteria contiene cadetes, en este contexto se hace mas útil tomarlo como una relación de agregación. De esta forma se puede manipular mejor la clase cadete con las operaciones dar de alta, dar de baja, borrar, etc.
    
- Cadete - Pedido AGREGACION
    Un pedido es independiente del cadete, ya que este existe porque el cliente lo solicito, ademas un pedido se puede pasar de un cadete a otro.

**Metodos de la clase Cadeteria**
- AltaCadete()
- BorrarCadete()
- ListarCadetes()

- AltaPedido()
- BorrarPedido()
- CambiarEstadoPedido()
- AsignarPedido()
- ReasignarPedido()
- ListarPedido()

**Metodos de la clase Cadete**
- AgregarPedido()
- EliminarPedido()
- JornalACobrar()

