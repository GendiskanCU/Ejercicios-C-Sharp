using System;

public class TresEnRayaRed
{
    //El tablero de juego de las tres en raya
    int[,] tableroJuego;

    public TresEnRayaRed()
    {
        //El tablero tendrá un tamaño fijo de 3x3
        tableroJuego = new int[3, 3];

        BorraTablero();
    }


    private void BorraTablero()
    {
        //Se dejan todas las casillas en el estado "vacía" (0)
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                tableroJuego[i, j] = 0;
        }
    }
}