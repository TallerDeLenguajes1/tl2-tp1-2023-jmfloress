using System.Security.Cryptography.X509Certificates;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadete;
    private List<Pedido> listadoPedido;

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadete = new List<Cadete>();
        this.listadoPedido = new List<Pedido>();
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadete { get => listadoCadete; set => listadoCadete = value; }
    public List<Pedido> ListadoPedido { get => listadoPedido; }

    public override string ToString()
    {
        string obj = $"{this.Nombre} - Telefono: {this.Telefono}";
        return obj;
    }

    public void AltaCadete(Cadete cadete1){
        this.ListadoCadete.Add(cadete1);
    }

    public bool BorrarCadete(int id){
        bool ok = false;
        foreach (Cadete item in this.ListadoCadete)
        {
            if (item.Id == id)
            {
                ListadoCadete.Remove(item);   
                ok = true;
                break;           
            }
        }
        return ok;
    }


    public void AltaPedido(Pedido pedido1)
    {
        this.ListadoPedido.Add(pedido1);
    }

    public void BorrarPedido(int nro)
    {
        foreach (Pedido item in this.ListadoPedido)
        {
            if (item.Nro == nro)
            {
                listadoPedido.Remove(item);
                break;
            }
        }
    }

    public void ListarPedido()
    {
        foreach (Pedido item in ListadoPedido)
        {
            System.Console.WriteLine(item);
        }
    }

    public List<Pedido>? ListarPedidoPorCadete(int idCadete)
    {
        // var lista =  (List<Pedido>)listadoPedido.Where(pedido => pedido.UnCadete.Id == idCadete);
        List<Pedido> lista = new List<Pedido>();
        
        foreach (Pedido item in listadoPedido)
        {
            if (item.UnCadete.Id == idCadete)
            {
                lista.Add(item);
            }
        }
        return lista;
    }

    public float JornalACobrar(int idCadete){
        float numPedido = 0;
        foreach (Pedido item in listadoPedido)
        {
            if (item.UnCadete.Id == idCadete)
            {
                numPedido++;
            }
            
        }
        return numPedido * 500;
    }

    public bool AsignarCadeteAPedido(int nroPedido, int idCadete)
    {
        bool ok = false;
        foreach (Pedido item in listadoPedido)
        {
            if(item.Nro == nroPedido)
            {
                foreach (Cadete unCadete in listadoCadete)
                {
                    if (unCadete.Id == idCadete)
                    {
                        item.UnCadete = unCadete;
                        ok = true;
                        item.Estado = EstadoPedido.Enviado.ToString();
                        break;
                    }
                }
            }
        }
        return ok;
    }

    // public bool ReasignarCadeteAPedido(int nroPedido, int idCadete, int idCadeteNuevo)
    // {
    //     bool ok = false;
    //     foreach (Pedido item in listadoPedido)
    //     {
    //         if (item.Nro == nroPedido)
    //         {
    //             if (item.UnCadete.Id == idCadete)
    //             {
    //                 foreach (Cadete unCadete in listadoCadete)
    //                 {
    //                     if (unCadete.Id == idCadeteNuevo)
    //                     {
    //                          item.UnCadete = unCadete;
    //                          ok = true;
    //                          break;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //     return ok;
    // }

}