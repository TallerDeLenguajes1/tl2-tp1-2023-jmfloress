public enum EstadoPedido
{
    Pendiente,
    EnCamino,
    Enviado,
    Rechazado
}
public class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private string estado;
    private Cadete unCadete;

    public Pedido(int nro, string obs, string estado, string nombre, string direccion, string telefono, string datosReferenciaDireccion)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        this.estado = estado;
        this.UnCadete = new Cadete();
        unCadete = null;
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }
    public Cadete UnCadete { get => unCadete; set => unCadete = value; }

    public override string ToString()
    {
        string obj = $"{this.Obs}, {this.Cliente.ToString()}";
        if(this.UnCadete != null){
            obj = obj + $", {this.UnCadete.ToString()}";
        }
        return obj;
    }

}