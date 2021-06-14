using Entidades;
using Files;
using Maquinery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creacion de materiales.
            Materiales listaMateriales = new Materiales();
            listaMateriales.Items.Add(new Material(Tipo.Acero, 50, 50, 50, 7850));
            listaMateriales.Items.Add(new Material(Tipo.Aluminio, 50, 50, 50, 2700));
            //Serializo la lista de materiales.
            Serializer.SerializeToFile<Materiales>(listaMateriales, "listMaterials.xml");

            //Lista para Recibir los objetos deserealizados.
            Materiales ListDeserialize = new Materiales();

            // Recibo la lista y trabajo con los objetos.
            ListDeserialize = Serializer.DeserializeFromFile<Materiales>("listMaterials.xml");
            foreach (Material item in ListDeserialize.Items)
            {
                Console.WriteLine(item.Show());
            }

            //Creacion de pieza para añadir
            Piece newPiece;

            //Creo la lista de piezas.
            Pieces listPieces = new Pieces();

            double alto = 4;
            double largo = 4;

            try
            {
                // Recorro la lista de materiales.
                foreach (Material item in ListDeserialize.Items)
                {
                    //Mientras exista material.
                    while (Material.ThereIsEnoughMaterial2(item, alto, largo))
                    {
                        //Creando piezas de tipo Acero.
                        if (item.Type.Equals(Tipo.Acero))
                        {
                            //Realizando corte
                            newPiece = CuttingMachine.ToBeCut2(item, typeOfPartToCreate.Panel, Tipo.Acero, alto, largo);
                            //Moldeando
                            newPiece = MoldingMachine.ToBeMolding(newPiece);
                            //Agujereando
                            newPiece = DrillingMachine.ToBePierce(newPiece);
                            //Soldando
                            newPiece = WeldingMachine.ToBeWelding(newPiece);
                            //Pintando.
                            newPiece = PaintingMachine.ToBePainting(newPiece);

                            Console.WriteLine(newPiece.ToString());
                            // Pieza añadida a la lista de piezas.
                            listPieces.Items.Add(newPiece);
                        }
                    }
                }
            }
            catch (Exception e) // Es posible obtener una exception por no tenes material disponible.

            {
                Console.WriteLine(e.Message);
            }

            //serializo la lista.
            Serializer.SerializeToFile<Pieces>(listPieces, "listPieces.xml");

            //Preparo lista para obtener los objetos deserealizados.
            Pieces ListPiecesDeserialize = new Pieces();
            ListPiecesDeserialize = Serializer.DeserializeFromFile<Pieces>("listPieces.xml"); 
            foreach (Piece item in ListPiecesDeserialize.Items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }
}
