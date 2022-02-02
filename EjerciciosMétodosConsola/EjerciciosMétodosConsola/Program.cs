/*(12.2.1) Crea un programa que muestre una "pelota" (la letra "O") rebotando en 
los bordes de la pantalla. Para que no se mueva demasiado rápido, haz una pausa 
de 50 milisegundos entre un "fotograma" y otro.*/

using System;
using System.Threading;

public enum EstadoMovimiento
{
    mueveDerecha,
    mueveIzquierda,
    mueveArriba,
    mueveAbajo,
    mueveDerechaArriba,
    mueveDerechaAbajo,
    mueveIzquierdaArriba,
    mueveIzquierdaAbajo,
    mueveArribaDerecha,
    mueveArribaIzquierda,
    mueveAbajoDerecha,
    mueveAbajoIzquierda    
}

public class Pelota
{
    char caracterPelota;//Carácter que representa la pelota
    int tiempoEspera;//Tiempo de espera entre cada movimiento

    int limiteX, limiteY;//Límites en los ejes X e Y

    int posX, posY;//Posición en cada eje de la pelota

    EstadoMovimiento movimiento;
    public Pelota(char formaPelota = 'O')
    {
        caracterPelota = formaPelota;
        tiempoEspera = 50;

        limiteX = Console.WindowWidth - 70;
        limiteY = Console.WindowHeight - 10;
    }

    public void ComienzaPartida()
    {
        DibujaTablero();
        IniciaMovimiento();
    }

    private void DibujaTablero()
    {
        for(int i = 0; i <= limiteX; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("=");
            Console.SetCursorPosition(i, limiteY);
            Console.Write("=");
        }
        for(int j = 0; j <= limiteY; j++)
        {
            Console.SetCursorPosition(0, j);
            Console.Write("[");
            Console.SetCursorPosition(limiteX, j);
            Console.Write("]");            
        }

        posX = limiteX / 2;
        posY = limiteY / 2;
        Console.SetCursorPosition(posX, posY);
        Console.Write(caracterPelota);
        Console.SetCursorPosition(0, limiteY + 2);
        Console.Write("Presiona una de las flechas del cursor para iniciar el movimiento...");
    }

    private void IniciaMovimiento()
    {
        bool salir = false;
        do
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.RightArrow:
                        movimiento = EstadoMovimiento.mueveDerecha;
                        salir = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        movimiento = EstadoMovimiento.mueveIzquierda;
                        salir = true;
                        break;
                    case ConsoleKey.UpArrow:
                        movimiento = EstadoMovimiento.mueveArriba;
                        salir = true;
                        break;
                    case ConsoleKey.DownArrow:
                        movimiento = EstadoMovimiento.mueveAbajo;
                        salir = true;
                        break;
                    default:
                        break;
                }
            }
        } while (!salir);
        Mover();
    }

    private void Mover()
    {
        bool finalizaMovimiento = false;
        do
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
            EstableceProximaPosicion();
            Console.SetCursorPosition(posX, posY);
            Console.Write(caracterPelota);



            Thread.Sleep(tiempoEspera);

            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if(tecla.Key == ConsoleKey.Escape)
                    finalizaMovimiento = true;
            }

        } while (!finalizaMovimiento);
    }

    private void EstableceProximaPosicion()
    {
        switch(movimiento)
        {
            case (EstadoMovimiento.mueveDerecha):
                Console.ForegroundColor = ConsoleColor.Red;
                posX += 1;
                break;
            case (EstadoMovimiento.mueveDerechaArriba):
                Console.ForegroundColor = ConsoleColor.Yellow;
                posX += 1;
                posY -= 1;
                break;
            case (EstadoMovimiento.mueveDerechaAbajo):
                Console.ForegroundColor = ConsoleColor.Blue;
                posX += 1;
                posY += 1;
                break;
            case (EstadoMovimiento.mueveIzquierda):
                Console.ForegroundColor = ConsoleColor.Green;
                posX -= 1;
                break;
            case (EstadoMovimiento.mueveIzquierdaArriba):
                Console.ForegroundColor = ConsoleColor.White;
                posX -= 1;
                posY -= 1;
                break;
            case (EstadoMovimiento.mueveIzquierdaAbajo):
                Console.ForegroundColor = ConsoleColor.Magenta;
                posX -= 1;
                posY += 1;
                break;
            case (EstadoMovimiento.mueveArriba):
                posY -= 1;
                break;
            case (EstadoMovimiento.mueveArribaDerecha):
                posY -= 1;
                posX += 1;
                break;
            case (EstadoMovimiento.mueveArribaIzquierda):
                posY -= 1;
                posX -= 1;
                break;
            case (EstadoMovimiento.mueveAbajo):
                posY += 1;
                break;
            case (EstadoMovimiento.mueveAbajoDerecha):
                posY += 1;
                posX += 1;
                break;
            case (EstadoMovimiento.mueveAbajoIzquierda):
                posY += 1;
                posX -= 1;
                break;
            default:
                break;
        }

        CompruebaRebote();
    }

    private void CompruebaRebote()
    {
        if (posX >= limiteX)
        {
            posX = limiteX - 1;
            Random randomY = new Random();

            switch (randomY.Next(0, 3))
            {
                case 0:
                    movimiento = EstadoMovimiento.mueveIzquierda;
                    break;
                case 1:
                    movimiento = EstadoMovimiento.mueveIzquierdaArriba;
                    //posY -= 1;
                    break;
                case 2:
                    movimiento = EstadoMovimiento.mueveIzquierdaAbajo;
                    //posY += 1;
                    break;
                default:
                    break;
            }
        }
        if (posX <= limiteX)
        {
            posX = limiteX + 1;
            Random randomY = new Random();

            switch (randomY.Next(0, 3))
            {
                case 0:
                    movimiento = EstadoMovimiento.mueveDerecha;
                    break;
                case 1:
                    movimiento = EstadoMovimiento.mueveDerechaArriba;
                    //posY -= 1;
                    break;
                case 2:
                    movimiento = EstadoMovimiento.mueveDerechaAbajo;
                    //posY += 1;
                    break;
                default:
                    break;
            }
        }
        if (posY >= limiteY)
        {
            posY = limiteY - 1;
            Random randomY = new Random();

            switch (randomY.Next(0, 3))
            {
                case 0:
                    movimiento = EstadoMovimiento.mueveArriba;
                    break;
                case 1:
                    movimiento = EstadoMovimiento.mueveArribaDerecha;
                    //posX += 1;
                    break;
                case 2:
                    movimiento = EstadoMovimiento.mueveArribaIzquierda;
                    //posX -= 1;
                    break;
                default:
                    break;
            }
        }
        if (posY <= limiteY)
        {
            posY = limiteY + 1;
            Random randomY = new Random();

            switch (randomY.Next(0, 3))
            {
                case 0:
                    movimiento = EstadoMovimiento.mueveAbajo;
                    break;
                case 1:
                    movimiento = EstadoMovimiento.mueveAbajoDerecha;
                    //posX += 1;
                    break;
                case 2:
                    movimiento = EstadoMovimiento.mueveAbajoIzquierda;
                    //posX -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}



public class Prueba
{
    public static void Main()
    {
        Pelota pelota = new Pelota();
        pelota.ComienzaPartida();


        Console.ReadKey();
    }    
}