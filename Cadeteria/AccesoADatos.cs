using System.Text.Json;

public abstract class  AccesoADados
{
    public virtual List<Cadeteria> LeerCadeteria(string rutaDeArchivo)
    {
        return new List<Cadeteria>();
    }

    public virtual List<Cadete> LeerCadete(string rutaDeArchivo)
    {
        return new List<Cadete>();
    }

    public virtual void Escribir(string rutaDeArchivo, List<Cadeteria> lista)
    {
        
    }
    public virtual void Escribir(string rutaDeArchivo, List<Cadete> lista)
    {
        
    }
}

public class AccesoCSV:AccesoADados
{
    public override List<Cadeteria> LeerCadeteria(string rutaDeArchivo)
    {
        FileStream MiArchivo = new FileStream(rutaDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);
            string Linea = "";
            List<Cadeteria> cadeterias = new List<Cadeteria>();
            char caracter =',';
            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] fila = Linea.Split(caracter);
                cadeterias.Add(new Cadeteria(fila[0],fila[1]));
            }

            return cadeterias;
    }

    public override List<Cadete> LeerCadete(string rutaDeArchivo)
    {
        FileStream MiArchivo = new FileStream(rutaDeArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);
            string Linea = "";
            List<Cadete> cadetes = new List<Cadete>();
            int contador=1;
            char caracter =',';
            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] fila = Linea.Split(caracter);
                cadetes.Add(new Cadete(contador,fila[0],fila[1],fila[2]));
                contador++;
            }

            return cadetes;
    }

    public override void Escribir(string rutaDeArchivo, List<Cadeteria> lista)
    {
        
    }
    public override void Escribir(string rutaDeArchivo, List<Cadete> lista)
    {
        
    }

}

public class AccesoJSON:AccesoADados
{
    public override List<Cadeteria> LeerCadeteria(string rutaDeArchivo)
    {
        List<Cadeteria> listaCadeterias;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaCadeterias = JsonSerializer.Deserialize<List<Cadeteria>>(documento);
            }
            return listaCadeterias;
    }

    public override List<Cadete> LeerCadete(string rutaDeArchivo)
    {
        List<Cadete> listaCadetes;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(documento);
            }
            return listaCadetes;
    }

    public override void Escribir(string rutaDeArchivo, List<Cadeteria> cadeteria)
    {
        string datos = JsonSerializer.Serialize(cadeteria);
        using (var archivo = new FileStream(rutaDeArchivo, FileMode.Create))
        {
            using (var strWriter = new StreamWriter(archivo))
            {
                strWriter.WriteLine("{0}", datos);
                strWriter.Close();
            }
        }
    }
    public override void Escribir(string rutaDeArchivo, List<Cadete> cadetes)
    {
        string datos = JsonSerializer.Serialize(cadetes);
            using (var archivo = new FileStream(rutaDeArchivo, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(archivo))
                {
                    strWriter.WriteLine("{0}", datos);
                    strWriter.Close();
                }
            }
        
    }

}