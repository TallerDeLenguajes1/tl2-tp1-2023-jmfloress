using System.Xml.Schema;

public class DatosCadete
{
    private int id;
    private string nombre;
    private int cantPedidos;
    private float montoGanado;

    public DatosCadete(int id, string nombre, int cantPedidos, float montoGanado)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.CantPedidos = cantPedidos;
        this.MontoGanado = montoGanado;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public int CantPedidos { get => cantPedidos; set => cantPedidos = value; }
    public float MontoGanado { get => montoGanado; set => montoGanado = value; }

    public override string ToString(){
        string obj = $"id:{Id}\nNombre: {Nombre}\nCantidad de pedidos: {CantPedidos}\nMonto total Ganado: {MontoGanado}";
        return obj;
    }


}

public class Informe
{
    private List<DatosCadete> listadoCadetes;
    private int pedidosEnviados;
    private int promedioPedidosEnviados;

    public Informe(Cadeteria unaCadeteria)
    {
        this.pedidosEnviados = unaCadeteria.ListadoPedido.Where(pedido => pedido.Estado == EstadoPedido.Enviado.ToString()).Count();
        this.promedioPedidosEnviados = pedidosEnviados / unaCadeteria.ListadoCadete.Count();
        this.listadoCadetes =  new List<DatosCadete>();
        foreach (Cadete item in unaCadeteria.ListadoCadete)
        {
            int cantPedidos = unaCadeteria.ListarPedidoPorCadete(item.Id).Count();
            float montoGanado = unaCadeteria.JornalACobrar(item.Id);
            DatosCadete datosCadete = new DatosCadete(item.Id, item.Nombre, cantPedidos, montoGanado);
            ListadoCadetes.Add(datosCadete);
        }
    }

    public List<DatosCadete> ListadoCadetes { get => listadoCadetes; }
    public int PedidosEnviados { get => pedidosEnviados; }
    public int PromedioPedidosEnviados { get => promedioPedidosEnviados; }

    public override string ToString()
    {
        string datos = "\n";
        foreach (DatosCadete item in ListadoCadetes)
        {
            datos = datos + $"{item.ToString()}\n";
        }

        datos = datos + $"Total de pedidos enviados: {this.PedidosEnviados}\nPromedio de pedidos enviados por cadete: {this.PromedioPedidosEnviados}";
        return datos;
    }
}