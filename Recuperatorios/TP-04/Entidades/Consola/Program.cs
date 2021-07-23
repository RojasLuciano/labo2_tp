using Entidades;
using Entidades.Entidades.Files;
using Entidades.Entidades.Herencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Fabrica miFabrica = new Fabrica("eee");
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Acero, 50, 50, 5, 7850));
            miFabrica.Materiales.Add(new Material(ETipoDeMaterial.Aluminio, 50, 50, 5, 7850));

            double largoParte = 2;
            double AltoParte = 2;

            try
            {

                for (int i = 0; i < 5; i++)
                {
                    if (Fabrica.HayMaterialSuficiente(miFabrica.DoyMaterial(ETipoDeMaterial.Acero), largoParte, AltoParte) && Fabrica.HayMaterialSuficiente(miFabrica.DoyMaterial(ETipoDeMaterial.Aluminio), largoParte, AltoParte))
                    {

                        Chasis chasis = new Chasis(ETipoDeMaterial.Acero, largoParte, AltoParte, "Compacto");
                        Chasis chasis1 = new Chasis(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Monocausico");

                        Puerta puerta = new Puerta(ETipoDeMaterial.Acero, largoParte, AltoParte, "Delantera derecha");
                        Puerta puerta1 = new Puerta(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Delantera izquierda");

                        Panel panel = new Panel(ETipoDeMaterial.Acero, largoParte, AltoParte, "Delantero derecho");
                        Panel panel1 = new Panel(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Delantero izquierdo");

                        Carroceria carroceria = new Carroceria(ETipoDeMaterial.Acero, largoParte, AltoParte, "SUV");
                        Carroceria carroceria1 = new Carroceria(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Coupe");

                        Capot capot = new Capot(ETipoDeMaterial.Acero, largoParte, AltoParte, "Apertura trasera");
                        Capot capot1 = new Capot(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "Apertura delantera");

                        Baul baul = new Baul(ETipoDeMaterial.Acero, largoParte, AltoParte, "101 litros");
                        Baul baul1 = new Baul(ETipoDeMaterial.Aluminio, largoParte, AltoParte, "500 litros");

                        if (miFabrica + chasis)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + chasis1)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + puerta)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + puerta1)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + carroceria)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + carroceria1)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + capot)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + capot1)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + baul)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + baul1)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }

                        if (miFabrica + panel)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }
                        if (miFabrica + panel1)
                        {
                            Console.WriteLine("Añadida a la fabrica");
                        }

                         if (miFabrica + chasis1) { }

                        Console.WriteLine(miFabrica);
                    }
                }
            }
            catch (AutoPartesException ex)
            {
               Console.WriteLine(ex.Message);
            }

            try
            {
                if (Fabrica.Save(miFabrica, "datosDePrueba.xml"))
                {
                    Console.WriteLine($"Se guardaron los datos en XML...");
                }

               Console.WriteLine("Leo archivo  .xml");

                Fabrica fabrica2;

                fabrica2 = Fabrica.Read("datosDePrueba.xml");

                Console.WriteLine(fabrica2);
            }
            catch (FileException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}