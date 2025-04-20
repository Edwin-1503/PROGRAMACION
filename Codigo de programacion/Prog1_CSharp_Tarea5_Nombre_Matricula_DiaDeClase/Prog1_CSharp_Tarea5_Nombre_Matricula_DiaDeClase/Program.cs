using System;

class Fraccion
{
    public int Numerador;
    public int Denominador;

    public Fraccion(int numerador, int denominador)
    {
        if (denominador == 0)
        {
            throw new ArgumentException("El denominador no puede ser cero.");
        }
        Numerador = numerador;
        Denominador = denominador;
    }

    public Fraccion Sumar(Fraccion otra)
    {
        int nuevoNumerador = (Numerador * otra.Denominador) + (otra.Numerador * Denominador);
        int nuevoDenominador = Denominador * otra.Denominador;
        return new Fraccion(nuevoNumerador, nuevoDenominador);
    }

    public Fraccion Restar(Fraccion otra)
    {
        int nuevoNumerador = (Numerador * otra.Denominador) - (otra.Numerador * Denominador);
        int nuevoDenominador = Denominador * otra.Denominador;
        return new Fraccion(nuevoNumerador, nuevoDenominador);
    }

    public Fraccion Multiplicar(Fraccion otra)
    {
        int nuevoNumerador = Numerador * otra.Numerador;
        int nuevoDenominador = Denominador * otra.Denominador;
        return new Fraccion(nuevoNumerador, nuevoDenominador);
    }

    public Fraccion Dividir(Fraccion otra)
    {
        if (otra.Numerador == 0)
        {
            throw new ArgumentException("No se puede dividir por una fracción con numerador 0.");
        }
        int nuevoNumerador = Numerador * otra.Denominador;
        int nuevoDenominador = Denominador * otra.Numerador;
        return new Fraccion(nuevoNumerador, nuevoDenominador);
    }

    public override string ToString()
    {
        return Numerador + "/" + Denominador;
    }
}

class Program
{
    static void Main()
    {
        Fraccion f1 = new Fraccion(1, 2);
        Fraccion f2 = new Fraccion(3, 4);

        Console.WriteLine("Suma: " + f1.Sumar(f2));
        Console.WriteLine("Resta: " + f1.Restar(f2));
        Console.WriteLine("Multiplicación: " + f1.Multiplicar(f2));
        Console.WriteLine("División: " + f1.Dividir(f2));
    }
}

