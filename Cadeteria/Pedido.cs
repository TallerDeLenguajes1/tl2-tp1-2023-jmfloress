public class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private string estado;

    public Pedido(int nro, string obs, Cliente cliente, string estado)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = estado;
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public string Estado { get => estado; set => estado = value; }

    public override string ToString()
    {
        string obj = $"{this.Nro}, {this.Obs}, {this.Cliente.ToString()}";
        return obj;
    }

}