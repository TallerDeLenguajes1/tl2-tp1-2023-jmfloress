// See https://aka.ms/new-console-template for more information

    Pedido p1 = new Pedido(1, "mila con papas", "PENDIENTE", "Malena", "Alla", "123", "NN");
    Pedido p2 = new Pedido(2, "sushi", "PENDIENTE", "Esteban", "Cerca", "456", "NN");
    Pedido p3 = new Pedido(4, "las empanadas", "PENDIENTE", "Maria", "Aqui", "123", "NN");

    Cadete d1 = new Cadete(1, "Mateo", "alsina 1334", "1321");
    Cadete d2 = new Cadete(3, "Melo", "alsina 1334", "33333");
    Cadete d3 = new Cadete(6, "Chopper", "La isla de drum", "0000");

    Cadeteria unicaCadeteriaXD = new Cadeteria("Sumo", "3234");


    Console.WriteLine("///// Metodos Cadeteria ////////");
    unicaCadeteriaXD.AltaCadete(d1);
    unicaCadeteriaXD.AltaCadete(d2);
    unicaCadeteriaXD.AltaCadete(d3);

    Console.WriteLine("------Listar cadetes");
    unicaCadeteriaXD.ListarCadetes();

    Console.WriteLine("------Eliminar un cadete");
    unicaCadeteriaXD.BorrarCadete(1);

    //Console.WriteLine("------Listar cadetes");
    unicaCadeteriaXD.ListarCadetes();


    unicaCadeteriaXD.AltaPedido(p1);
    unicaCadeteriaXD.AltaPedido(p2);
    unicaCadeteriaXD.AltaPedido(p3);

    Console.WriteLine("------Listar Pedidos");
    unicaCadeteriaXD.ListarPedido();

    Console.WriteLine("------Eliminar un pedido");
    unicaCadeteriaXD.BorrarPedido(4);
    unicaCadeteriaXD.ListarPedido();

    Console.WriteLine("------Asignar un pedido");
    unicaCadeteriaXD.AsignarPedido(2,6);


    Console.WriteLine("\n////////Verificar que chopper recibio el pedido///////");

    d3.ListarPedido();

    Console.WriteLine("------ReasignarPedido");
    unicaCadeteriaXD.ReasignarPedido(2,6,3);

    Console.WriteLine("Pedidos de chopper");
    d3.ListarPedido();

    Console.WriteLine("Pedidos de Melo");
    d2.ListarPedido();







    




Console.WriteLine("BYE, World!");
