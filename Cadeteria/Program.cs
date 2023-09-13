using System.Data;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        string rutaDeArchivo = "cadeterias.json";
        List<Cadeteria> listadoCadeterias = CargarCadeterias(rutaDeArchivo);
        rutaDeArchivo = "cadetes.json";
        List<Cadete> listadoCadetes = CargarCadetes(rutaDeArchivo);
        // buscamos la cadeteria con la que vamos a trabajar
        Cadeteria unicaCadeteriaXD;
        bool salir = false;
        
        Console.WriteLine("====================CADETERIAS");
        Console.WriteLine("Seleccione una cadeteria:");
        for (int i = 0; i < listadoCadeterias.Count(); i++)
        {
            Console.WriteLine($"{i+1} - {listadoCadeterias[i]}");
        }
        unicaCadeteriaXD = listadoCadeterias[Convert.ToInt32(Console.ReadLine())-1];
        CargarCadetesACadeteria(unicaCadeteriaXD,listadoCadetes);
        string nombre = unicaCadeteriaXD.Nombre;
        int nroPedido = 0; 
        do
        {
            Console.Clear();
            Console.WriteLine($"===================={nombre}");
            Console.WriteLine("Ingrese una opcion:");
            Console.WriteLine(" a - Dar alta pedido\n b - Asignar pedido\n c - Reasignar pedido\n d - Ver Informe\n e - Salir\n");
            string? op = Console.ReadLine();
            switch (op)
            {
                case "a":
                    DarAltaPedido(unicaCadeteriaXD, nroPedido);
                    nroPedido++;
                    break;
                case "b":
                    AsignarPedido(unicaCadeteriaXD);
                    break;
                case "c":
                    ReasignarPedido(unicaCadeteriaXD);
                    break;
                case "d":
                    VerInforme(unicaCadeteriaXD);
                    Thread.Sleep(2000);
                    break;
                case "e":
                    salir = true;
                    break;           
                default:
                    Console.WriteLine("\nElija una opcion correcta");
                    Thread.Sleep(2000);
                    break;
            }
            Console.Clear();
        } while (!salir);
        Console.WriteLine("BYE uwu");
    }

    private static void DarAltaPedido(Cadeteria unicaCadeteriaXD, int nroPedido)
    {
        Console.Clear();
        Console.WriteLine("=======Datos del Cliente:");
        Console.WriteLine("Ingrese nombre:");
        string? nombreCliente = Console.ReadLine();
        Console.WriteLine("Ingrese Direccion:");
        string? direccionCliente = Console.ReadLine();
        Console.WriteLine("Ingrese Telefono:");
        string? telefonoCliente = Console.ReadLine();
        Console.WriteLine("Ingrese datos de referencia:");
        string? datosRefCliente = Console.ReadLine();
        Console.WriteLine("\n=======Datos del Pedido:");
        Console.WriteLine("Describa el pedido que quiere realizar: ");
        string? obsPedido = Console.ReadLine();

        unicaCadeteriaXD.AltaPedido(new Pedido(nroPedido, obsPedido, EstadoPedido.Pendiente.ToString() , nombreCliente, direccionCliente, telefonoCliente, datosRefCliente));
        Console.Clear();
        Console.WriteLine("El pedido se guardo correctamente!! :D");
        Thread.Sleep(2000);
    }
    public static void AsignarPedido(Cadeteria unicaCadeteriaXD)
    {
        Console.Clear();
        Console.WriteLine("=======Pedidos sin asignar:");
        bool pedidos = false;
        int nro;
        int id;
        foreach (Pedido item in unicaCadeteriaXD.ListadoPedido)
        {
            if(item.Estado == EstadoPedido.Pendiente.ToString()){
                Console.WriteLine($"{item.Nro + 1} - {item.ToString()}");
                pedidos = true;
            }
        }
        if (!pedidos)
        {
            Console.WriteLine("\nNO HAY PEDIDO PARA MOSTRAR");
            Thread.Sleep(2000);
        }else{
            Console.WriteLine("seleccione un pedido:");
            nro = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("=======Cadetes disponibles:");
            if (unicaCadeteriaXD.ListadoCadete.Count() == 0)
            {
                Console.WriteLine("\nNO HAY CADETES PARA MOSTRAR");
                Thread.Sleep(2000);
            }else{
                foreach (Cadete item in unicaCadeteriaXD.ListadoCadete)
                {
                    Console.WriteLine($"{item.Id + 1} - {item.ToString()}");
                }
                Console.WriteLine("Seleccione el cadete: ");
                id = Convert.ToInt32(Console.ReadLine())-1;
                unicaCadeteriaXD.AsignarCadeteAPedido(nro, id);
                Console.Clear();
                Console.WriteLine("La operacion se realizo con exito! :D");
                Thread.Sleep(2000);
            }
        }
    }
    public static void ReasignarPedido(Cadeteria unicaCadeteriaXD){
        Console.Clear();
        Console.WriteLine("=======Pedidos Enviados:");
        bool pedidos = false;
        int nro;
        int id;
        foreach (Pedido item in unicaCadeteriaXD.ListadoPedido)
        {
            if(item.Estado == EstadoPedido.Enviado.ToString()){
                Console.WriteLine($"{item.Nro + 1} - {item.ToString()}");
                pedidos = true;
            }
        }
        if (!pedidos)
        {
            Console.WriteLine("\nNO HAY PEDIDO PARA MOSTRAR");
            Thread.Sleep(2000);
        }else{
            Console.WriteLine("seleccione un pedido:");
            nro = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("=======Cadetes disponibles:");
            if (unicaCadeteriaXD.ListadoCadete.Count() == 0)
            {
                Console.WriteLine("\nNO HAY CADETES PARA MOSTRAR");
                Thread.Sleep(2000);
            }else{
                foreach (Cadete item in unicaCadeteriaXD.ListadoCadete)
                {
                    Console.WriteLine($"{item.Id + 1} - {item.ToString()}");
                }
                Console.WriteLine("Seleccione un cadete para reasignar el pedido: ");
                id = Convert.ToInt32(Console.ReadLine()) - 1;
                unicaCadeteriaXD.AsignarCadeteAPedido(nro, id);
                Console.Clear();
                Console.WriteLine("La operacion se realizo con exito! :D");
                Thread.Sleep(2000); 
            }
        }
    }
    public static void VerInforme(Cadeteria unicaCadeteriaXD){
        
        Console.WriteLine("=============INFORME");
        if (unicaCadeteriaXD.ListadoPedido.Count() != 0)
        {
            Informe info = new Informe(unicaCadeteriaXD);
            Console.WriteLine(info.ToString());

            Console.WriteLine("presione cualquier tecla para salir");
            Console.ReadLine();
        }else
        {
            Console.WriteLine("NO HAY PEDIDOS REALIZADOS");
        }
    }

    public static List<Cadeteria> CargarCadeterias(string rutaDeArchivo)
    {
        List<Cadeteria> listadoCadeterias;
        string ex = @"\.json";
        Regex miRegex = new Regex(ex);

        AccesoADados datosMuchos;
        //string formato = "json";//falta filtrar!
        if (miRegex.Matches(rutaDeArchivo).Count > 0)
        {
            datosMuchos = new AccesoJSON();        
        }
        else
        {
            datosMuchos = new AccesoCSV();
        }
        listadoCadeterias = datosMuchos.LeerCadeteria(rutaDeArchivo);        
        return listadoCadeterias;
    }

    public static List<Cadete> CargarCadetes(string rutaDeArchivo){
        List<Cadete> listadoCadetes;
        AccesoADados datosMuchos;
        string ex = @"\.json";
        Regex miRegex = new Regex(ex);
        if(miRegex.Matches(rutaDeArchivo).Count > 0)
        {
            datosMuchos = new AccesoJSON();
        }else
        {
            datosMuchos = new AccesoCSV();
        }
        listadoCadetes = datosMuchos.LeerCadete(rutaDeArchivo);
        return listadoCadetes;
    }
    public static void CargarCadetesACadeteria(Cadeteria unicaCadeteriaXD,List<Cadete> listadoCadetes)
    {
        foreach (Cadete item in listadoCadetes)
        {
            unicaCadeteriaXD.AltaCadete(item);
        }
    }
}