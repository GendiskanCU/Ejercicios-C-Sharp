/*(11.2.4) La "notación polaca inversa" es una forma de expresar operaciones que 
consiste en indicar los operandos antes del correspondiente operador. Por 
ejemplo, en vez de "3+4" se escribiría "3 4 +". Es una notación que no necesita 
paréntesis y que se puede resolver usando una pila: si se recibe un dato numérico, 
éste se guarda en la pila; si se recibe un operador, se obtienen los dos operandos 
que hay en la cima de la pila, se realiza la operación y se apila su resultado. El 
proceso termina cuando sólo hay un dato en la pila. Por ejemplo, "3 4 +" se 
convierte en: apilar 3, apilar 4, sacar dos datos y sumarlos, guardar 7, terminado. 
Impleméntalo y comprueba si el resultado de "3 4 6 5 - + * 6 +" es 21.*/
using System;
using System.Collections;

public class NotacionPolaca
{
    public static void Main()
    {

    }
}