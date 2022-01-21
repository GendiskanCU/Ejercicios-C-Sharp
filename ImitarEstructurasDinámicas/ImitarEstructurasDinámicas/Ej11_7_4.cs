/*(11.7.4) Crea una cola que almacene un bloque de datos
 * (struct, con los campos que tú elijas) usando un ArrayLis*/
using System;
using System.Collections;

public struct clientesEmpresa
{
    public string nombre;
    public int edad;
}

//============================================

public class ColaClientes
{
    ArrayList clientes;    

    public ColaClientes()
    {
        clientes = new ArrayList();        
    }

    public void Enqueue(clientesEmpresa cliente)
    {        
        clientes.Add(cliente);
    }

    public clientesEmpresa Dequeue()
    {
        clientesEmpresa cliente;
        cliente.nombre = "";
        cliente.edad = 0;

        if (clientes.Count <= 0 )
        {
            Console.WriteLine("La cola está vacía");                        
        }
        else
        {
            cliente = (clientesEmpresa)clientes[0];
            clientes.RemoveAt(0);            
        }
        return cliente;
    }

    public int Count()
    {
        return clientes.Count;
    }

    public void Clear()
    {
        clientes.Clear();
    }

    public void MuestraCola()
    {
        if (clientes.Count <= 0)
        {
            Console.WriteLine("La cola está vacía");
        }
        else
        {
            clientesEmpresa cliente;
            Console.WriteLine("\nCola actual:");
            for (int i = 0; i < clientes.Count; i++)
            {
                cliente = (clientesEmpresa)clientes[i];
                Console.WriteLine("{2}.-Cliente: {0}, edad {1}", cliente.nombre, cliente.edad, i+1);
            }
        }
    }
}

public class Prueba
{
    public static void Main()
    {
        Console.WriteLine("Gestión de la cola de clientes:");
        clientesEmpresa ultimoCliente, siguienteCliente;
        ColaClientes colaClientes = new ColaClientes();

        //Añadimos unos cuantos clientes a la cola
        ultimoCliente.nombre = "Juan";
        ultimoCliente.edad = 14;

        colaClientes.Enqueue(ultimoCliente);

        ultimoCliente.nombre = "María";
        ultimoCliente.edad = 16;

        colaClientes.Enqueue(ultimoCliente);

        ultimoCliente.nombre = "Lucía";
        ultimoCliente.edad = 13;

        colaClientes.Enqueue(ultimoCliente);

        //Mostramos la cola actual
        colaClientes.MuestraCola();

        //Sacamos al primer cliente de la cola
        siguienteCliente = colaClientes.Dequeue();
        Console.WriteLine("\nEl cliente {0} sale de la cola", siguienteCliente.nombre);

        //Mostramos la cola actual
        colaClientes.MuestraCola();

        //Sacamos al siguiente cliente en la cola
        siguienteCliente = colaClientes.Dequeue();
        Console.WriteLine("\nEl cliente {0} sale de la cola", siguienteCliente.nombre);

        //Mostramos la cola actual
        colaClientes.MuestraCola();

        //Limpiamos la cola
        Console.WriteLine("Vaciamos la cola");
        colaClientes.Clear();

        //Mostramos la cola actual
        colaClientes.MuestraCola();

        Console.ReadLine();
    }
}