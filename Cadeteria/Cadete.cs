using System.ComponentModel;
using System.Reflection;

public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedido;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listadoPedido = new List<Pedido>(); 
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedido { get => listadoPedido; set => listadoPedido = value; }

    public void AgregarPedido(Pedido pedido1){
        this.ListadoPedido.Add(pedido1);
    }

    public bool BorrarPedido(int nro)
    {
        Pedido aux = ListadoPedido.FirstOrDefault(pedido => pedido.Nro == nro);
        if (aux != null)
        {
            return ListadoPedido.Remove(aux);
        }
        return false;
    }

    public float JornalACobrar(){
        return ListadoPedido.Count() * 500;
    }

    public void ListarPedido()
    {
        foreach (Pedido item in ListadoPedido)
        {
            System.Console.WriteLine(item);
        }
    }

    public override string ToString()
    {
        string obj = $"{this.Nombre}, {this.Direccion}";
        return obj;
    }


}