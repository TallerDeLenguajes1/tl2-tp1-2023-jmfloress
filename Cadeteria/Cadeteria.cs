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
    public List<Pedido> ListadoPedido { get => listadoPedido; set => listadoPedido = value; }

    public void AltaCadete(Cadete cadete1){
        this.ListadoCadete.Add(cadete1);
    }

    public void BorrarCadete(int id){
        // ListadoCadete.Remove(ListadoCadete[id]);
        foreach (Cadete item in this.ListadoCadete)
        {
            if (item.Id == id)
            {
                ListadoCadete.Remove(item);   
                break;             
            }
        }
    }

    public void ListarCadetes()
    {
        foreach (Cadete item in ListadoCadete)
        {
            Console.WriteLine(item);
        }
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
    
    public void CambiarEstadoPedido(int nro, string estado)
    {
        foreach (Pedido item in ListadoPedido)
        {
            if (item.Nro == nro)
            {
                item.Estado = estado;
            }
            
        }
    }

    public void AsignarPedido(int nroPedido, int idCadete) // x.x 
    {
        if (ListadoCadete.Count !=0 && ListadoPedido.Count != 0)
        {
            Pedido auxPedido = ListadoPedido.FirstOrDefault(pedido => pedido.Nro == nroPedido);
            if (auxPedido != null)
            {
                Cadete auxCadete = ListadoCadete.FirstOrDefault(cadete => cadete.Id == idCadete);
                if (auxCadete != null)
                {
                    CambiarEstadoPedido(nroPedido, "ENVIADO");
                    auxCadete.AgregarPedido(auxPedido);
                }
            }    
        }
    }



    public void ReasignarPedido(int nroPedido, int idCadete, int idCadeteNuevo)
    {
        if (ListadoCadete.Count !=0 && ListadoPedido.Count != 0)
        {
            Pedido auxPedido = ListadoPedido.FirstOrDefault(pedido => pedido.Nro == nroPedido);
            if (auxPedido != null)
            {
                Cadete auxCadete = ListadoCadete.FirstOrDefault(cadete => cadete.Id == idCadete);
                if (auxCadete != null)
                {
                    Cadete auxCadeteNuevo = ListadoCadete.FirstOrDefault(cadete => cadete.Id == idCadeteNuevo);
                    if (auxCadeteNuevo != null)
                        {
                            if(auxCadete.BorrarPedido(nroPedido))
                            {
                                auxCadeteNuevo.AgregarPedido(auxPedido);
                            }
                        }
                }
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

}