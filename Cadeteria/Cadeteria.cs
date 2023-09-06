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
    public List<Cadete> ListadoCadete { get => listadoCadete; }
    public List<Pedido> ListadoPedido { get => listadoPedido; }

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

    public void ListarPedido()
    {
        foreach (Pedido item in ListadoPedido)
        {
            System.Console.WriteLine(item);
        }
    }

    public void ListarPedidoPorCadete(int idCadete)
    {
        foreach (Pedido item in listadoPedido)
        {
            if (item.UnCadete.Id == idCadete)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public float JornalACobrar(int idCadete){
        float numPedido =0;
        foreach (Pedido item in listadoPedido)
        {
            if (item.UnCadete.Id == idCadete)
            {
                numPedido++;
            }
            
        }
        return numPedido * 500;
    }

    public void AsignarCadeteAPedido(int nroPedido, int idCadete)
    {
        foreach (Pedido item in listadoPedido)
        {
            if(item.Nro == nroPedido)
            {
                foreach (Cadete unCadete in listadoCadete)
                {
                    if (unCadete.Id == idCadete)
                    {
                        item.UnCadete = unCadete;
                        //item.UnCadete.Id = unCadete.Id;
                        //item.UnCadete.Nombre = unCadete.Nombre;
                        //item.UnCadete.Direccion = unCadete.Direccion;
                        //item.UnCadete.Telefono = unCadete.Direccion;
                        //item.Estado = "ENVIADO";
                        break;
                    }
                }
            }
        }
    }

    public void ReasignarCadeteAPedido(int nroPedido, int idCadete, int idCadeteNuevo)
    {
        foreach (Pedido item in listadoPedido)
        {
            if (item.Nro == nroPedido)
            {
                if (item.UnCadete.Id == idCadete)
                {
                    foreach (Cadete unCadete in listadoCadete)
                    {
                        if (unCadete.Id == idCadeteNuevo)
                        {
                            // item.UnCadete = unCadete;
                            item.UnCadete.Id = unCadete.Id;
                            item.UnCadete.Nombre = unCadete.Nombre;
                            item.UnCadete.Direccion = unCadete.Direccion;
                            item.UnCadete.Telefono = unCadete.Direccion;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No se realizo la asignacion");
                }
            }
        }
    }

}