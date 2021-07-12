using Entidades.Entidades.Database;
using Entidades.Entidades.Files;
using Entidades.Entidades.Herencia;
using Entidades.Extension;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabrica
    {
        MaterialesDAO dao = new MaterialesDAO();
        AutoPartesDAO dao2 = new AutoPartesDAO();

        private List<AutoParte> autoPartes;
        private List<Material> materiales;
        private static double pesoAutoParte;
        private string nombreFabrica;

        /// <summary>
        /// Constructor que inicializa la lista de piezas y materiales.
        /// </summary>
        private Fabrica()
        {
            autoPartes = new List<AutoParte>();
            materiales = new List<Material>();
        }

        /// <summary>
        /// Consturctor con 1 paramtro.
        /// </summary>
        /// <param name="nombreFabrica"></param>
        public Fabrica(string nombreFabrica) : this()
        {
            this.NombreFabrica = nombreFabrica;
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable autoPartes.
        /// </summary>
        public List<AutoParte> AutoPartes
        {
            get
            {
                return this.autoPartes;
            }
            set
            {
                this.autoPartes = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable materiales.
        /// </summary>
        public List<Material> Materiales
        {
            get
            {
                return this.materiales;
            }
            set 
            {
                this.materiales = value;
            }

        }

        /// <summary>
        /// Propiedad de lectura y escritura para la variable nombreFabrica.
        /// </summary>
        public string NombreFabrica
        {
            get => nombreFabrica;
            set => nombreFabrica = value;
        }

        /// <summary>
        /// MEtodo para serializar la informacion de la fabrica.
        /// </summary>
        /// <param name="fabrica">Valor a serializar</param>
        /// <param name="path"> Valor para la ruta.</param>
        /// <returns></returns>
        public static bool Save(Fabrica fabrica, string path)
        {
            Xml<Fabrica> guardaFabrica = new Xml<Fabrica>();
            return guardaFabrica.Save(path, fabrica);
        }

        /// <summary>
        /// Metodo para leer un archivo serializado.
        /// </summary>
        /// <param name="path">Ubicacion del archivo a leer.</param>
        /// <returns></returns>
        public static Fabrica Read(string path)
        {
            Xml<Fabrica> leeFabrica = new Xml<Fabrica>();
            return leeFabrica.Read(path);
        }

        /// <summary>
        /// Metodo para mostrar la informacion de la fabrica.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"");
            sb.AppendLine($"Fábrica de AutoPartes {this.NombreFabrica} ");
            sb.AppendLine($"Total de autopartes fabricadas : {this.autoPartes.Count}");
            sb.AppendLine($"");
            sb.AppendLine($"Listado de autopartes fabricados:");
            sb.AppendLine($"");
            sb.AppendLine(this.AutoParte());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que convierte a string la informacion de las auto partes creadas.
        /// </summary>
        /// <returns></returns>
        public string AutoParte()
        {
            StringBuilder sb = new StringBuilder();

            foreach (AutoParte item in this.AutoPartes)
            {

                sb.AppendLine(item.ToString()); //GetLast
                
            }
            return sb.ToString();
        }

        /// <summary>
        /// Metodo para que convierte en string la informacion de los materiales pertenecientes a la fabrica.
        /// </summary>
        /// <returns></returns>
        public string MaterialesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Material item in this.Materiales)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecargar del operador == que indicara si la pieza recibida existe en la fabrica.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="autoParte"></param>
        /// <returns></returns>
        public static bool operator ==(Fabrica fabrica, AutoParte autoParte)
        {
            bool output = false;

            foreach (AutoParte item in fabrica.AutoPartes)
            {
                if (item == autoParte)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }

        /// <summary>
        /// Sobrecarga de operador 
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="autoParte"></param>
        /// <returns></returns>
        public static bool operator !=(Fabrica fabrica, AutoParte autoParte)
        {
            return !(fabrica == autoParte);
        }


        /// <summary>
        /// Sobrecarga del operador ´+ que agregara a una autoparte a la fabrica.
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="autoParte"></param>
        /// <returns></returns>
        public static bool operator +(Fabrica fabrica, AutoParte autoParte)
        {
            bool output = false;
            try
            {
                if (fabrica != autoParte)
                {
                    fabrica.AutoPartes.Add(autoParte);
                    output = true;
                }
                else
                {
                    throw new AutoPartesException();
                }
            }
            catch (Exception ex)
            {
                throw new AutoPartesException("La pieza ya se encuentra creada con un mismo numero de serie", ex);
            }
            return output;
        }

        /// <summary>
        /// Sobrecarga del operador - que eliminara una autoparte 
        /// </summary>
        /// <param name="fabrica"></param>
        /// <param name="autoParte"></param>
        /// <returns></returns>
        public static bool operator -(Fabrica fabrica, AutoParte autoParte)
        {
            bool output = false;

            try
            {
                if (fabrica.AutoPartes.Contains(autoParte) && autoParte.EstaDefectuoso == true)
                {
                    fabrica.AutoPartes.Remove(autoParte);
                    output = true;
                }
            }
            catch (Exception ex)
            {
                throw new AutoPartesException("Hubo un error el eliminar la autoparte", ex);
            }
            return output;
        }

        /// <summary>
        /// Metodo que devolvera un tipo de material.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public Material DoyMaterial(ETipoDeMaterial tipo)
        {
            bool flag = false;
            try
            {
                foreach (Material item in materiales)
                {
                    if (item.TipoDeMaterial.Equals(tipo))
                    {
                        flag = true;
                        return item;
                    }
                }

                if(flag==false)
                    throw new ArgumentException();
            }
            catch (Exception e)
            {
                throw new Exception("No hay material de ese tipo.", e);
            }
            return default;
        }

        /// <summary>
        /// Metodo stattico que indicara si hay material para la medida solicitada.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="alturaAutoParte"></param>
        /// <param name="largoAutoParte"></param>
        /// <returns></returns>
        public static bool HayMaterialSuficiente(Material item, double alturaAutoParte, double largoAutoParte)
        {
            bool output = false;
            try
            {
                if (item.Alto > alturaAutoParte && item.Largo > largoAutoParte)
                {
                    item.Alto = item.Alto - alturaAutoParte;
                    item.Largo = item.Largo - largoAutoParte;
                    pesoAutoParte = Math.Round((alturaAutoParte * largoAutoParte * item.Ancho * item.Densidad / 1000000), 2);
                    output = true;
                }
                else
                {
                    throw new MaterialException();
                }
            }
            catch (Exception e)
            {
                throw new MaterialException("No hay material suficiente para la pieza.", e);
            }
            return output;
        }
        /// <summary>
        /// Metodo que aparte de verificar que exista material, asignara el peso calculado a la autoparte.
        /// </summary>
        /// <param name="parte"></param>
        /// <returns></returns>
        public bool MaterialSuficiente(AutoParte parte)
        {
            bool output = false;
            if (HayMaterialSuficiente(this.DoyMaterial(parte.TipoDeMaterial), parte.Alto, parte.Alto))
            {
                parte.Peso = pesoAutoParte;
                output = true;
            }
            return output;
        }

        /// <summary>
        /// Metodo que obtiene una lista de materiales desde la base.
        /// </summary>
        public void GetMaterialsFromDB() 
        {
            Materiales = dao.GetAll();
        }

        /// <summary>
        /// Metodo que obtiene una lista de autopartes desde la base.
        /// </summary>
        public void GetAutoPartesFromDB()
        {
            AutoPartes = dao2.GetAll();
        }

        /// <summary>
        /// Metodo para exportar las autopartes hacia la DB.
        /// </summary>
        public void ExportAutoPartsToDB() 
        {
            foreach (AutoParte item in AutoPartes)
            {
                dao2.Update(item);
            }
        }

        /// <summary>
        /// Metodo para exportar la lista de materiales hacia la DB
        /// </summary>
        public void ExportMaterialsToDB()
        {
            foreach (Material item in Materiales)
            {
                dao.Update(item);
            }
        }


        /// <summary>
        /// Metodo para eliminar una autoparte de la base, segun su numero de serie,.
        /// </summary>
        /// <param name="nroDeSerie"></param>
        /// <returns></returns>
        public bool DeletePartFromDB(string nroDeSerie) 
        {
            try
            {
                return dao2.Delete(nroDeSerie);
            }
            catch (Exception ex)
            {
                throw new FileException("No se pudo eliminar de la base.", ex);
            }
        }


        /// <summary>
        /// Metodo para generar un reporte en formato pdf.
        /// </summary>
        /// <returns></returns>
        public string GenerarReporte()
        {
            Font titleFont = FontFactory.GetFont("Arial", 32);
            Font regularFont = FontFactory.GetFont("Arial", 9);
            Paragraph saltoDeLinea = new Paragraph("\n");

            Font standarFont = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

            Paragraph title;
            Paragraph text;

           
                string fileName = string.Empty;
                DateTime fileCreationDatetime = DateTime.Now;
                fileName = string.Format("Report{0}", fileCreationDatetime.ToString(@"_dd_MM_yyyy") + "_" + fileCreationDatetime.ToString(@"HH_mm"));

                FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName + ".pdf", FileMode.Create);
                Document doc = new Document(PageSize.LETTER, 10, 10, 10, 10);
                PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            

            try
            {
                doc.Open();
                text = new Paragraph(fileCreationDatetime.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 10));
                text.IndentationLeft = 485;
                text.SpacingAfter = 5;
                doc.Add(text);

                title = new Paragraph("Reporte", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 5;
                doc.Add(title);

                text = new Paragraph("Lista de material sobrante\n", regularFont);
                text.IndentationLeft = 58;
                text.SpacingAfter = 5;
                doc.Add(text);

                PdfPTable tableMateriales = crearTablaMateriales(Materiales, standarFont);
                doc.Add(tableMateriales);

                doc.Add(saltoDeLinea);

                text = new Paragraph(string.Format("Se ha fabricado un total de: {0} piezas.",AutoPartes.Count), regularFont);
                text.IndentationLeft = 58;
                text.SpacingAfter = 5;
                doc.Add(text);

                text = new Paragraph("Lista de piezas creadas", regularFont);
                text.IndentationLeft = 58;
                text.SpacingAfter = 5;
                doc.Add(text);

                PdfPTable tableAutoPartes = crearTablaAutoPartes(AutoPartes, standarFont);
                float[] widths = new float[] {5f,5f,5f,5f,5f,5f,5f,5f};
                tableAutoPartes.SetWidths(widths);

                doc.Add(tableAutoPartes);

                doc.Close();

            }
            catch (Exception e)
            {
                throw new FileException("Hubo un error creando el archivo", e);
            }
            return fs.Name;
        }

        /// <summary>
        /// Metodo para crear una tabla para los materiales.
        /// </summary>
        /// <param name="listaMateriales"></param>
        /// <param name="standarFont"></param>
        /// <returns></returns>
        private PdfPTable crearTablaMateriales(List<Material> listaMateriales, Font standarFont)
        {
            PdfPTable tablaMataeriales;

            try
            {

                tablaMataeriales = new PdfPTable(5);

                PdfPCell tipo = new PdfPCell(new Phrase("Tipo", standarFont));
                tipo.BorderWidth = 0;
                tipo.BorderWidth = 0.75f;

                PdfPCell largo = new PdfPCell(new Phrase("Largo", standarFont));
                largo.BorderWidth = 0;
                largo.BorderWidth = 0.75f;

                PdfPCell ancho = new PdfPCell(new Phrase("Ancho", standarFont));
                ancho.BorderWidth = 0;
                ancho.BorderWidth = 0.75f;

                PdfPCell alto = new PdfPCell(new Phrase("Alto", standarFont));
                alto.BorderWidth = 0;
                alto.BorderWidth = 0.75f;

                PdfPCell densidad = new PdfPCell(new Phrase("Densidad", standarFont));
                densidad.BorderWidth = 0;
                densidad.BorderWidth = 0.75f;

                tablaMataeriales.AddCell(tipo);
                tablaMataeriales.AddCell(largo);
                tablaMataeriales.AddCell(ancho);
                tablaMataeriales.AddCell(alto);
                tablaMataeriales.AddCell(densidad);

                foreach (Material item in listaMateriales)
                {
                    tablaMataeriales.AddCell(new PdfPCell(new Phrase(item.TipoDeMaterial.ToString(), standarFont)));
                    tablaMataeriales.AddCell(new PdfPCell(new Phrase(item.Largo.ToString(), standarFont)));
                    tablaMataeriales.AddCell(new PdfPCell(new Phrase(item.Ancho.ToString(), standarFont)));
                    tablaMataeriales.AddCell(new PdfPCell(new Phrase(item.Alto.ToString(), standarFont)));
                    tablaMataeriales.AddCell(new PdfPCell(new Phrase(item.Densidad.ToString(), standarFont)));
                }

            }
            catch (Exception e)
            {
                throw new FileException("Hubo un error creando la tabla", e);
            }

            return tablaMataeriales;
        }

        /// <summary>
        /// Metodo para crear una tabla para las auto partes.
        /// </summary>
        /// <param name="listaAutoParte"></param>
        /// <param name="standarFont"></param>
        /// <returns></returns>
        private PdfPTable crearTablaAutoPartes(List<AutoParte> listaAutoParte, Font standarFont)
        {
            PdfPTable tablaAutoPartes;

            try
            {

                tablaAutoPartes = new PdfPTable(8);

                PdfPCell tipo = new PdfPCell(new Phrase("Tipo", standarFont));
                tipo.BorderWidth = 0;
                tipo.BorderWidth = 0.75f;

                PdfPCell material = new PdfPCell(new Phrase("Material", standarFont));
                material.BorderWidth = 0;
                material.BorderWidth = 0.75f;

                PdfPCell nroDeSerie = new PdfPCell(new Phrase("N° de serie", standarFont));
                nroDeSerie.BorderWidth = 0;
                nroDeSerie.BorderWidth = 0.75f;

                PdfPCell alto = new PdfPCell(new Phrase("Alto", standarFont));
                alto.BorderWidth = 0;
                alto.BorderWidth = 0.75f;

                PdfPCell largo = new PdfPCell(new Phrase("Largo", standarFont));
                largo.BorderWidth = 0;
                largo.BorderWidth = 0.75f;

                PdfPCell peso = new PdfPCell(new Phrase("Peso", standarFont));
                peso.BorderWidth = 0;
                peso.BorderWidth = 0.75f;

                PdfPCell defectuoso = new PdfPCell(new Phrase("Defectuoso", standarFont));
                defectuoso.BorderWidth = 0;
                defectuoso.BorderWidth = 0.75f;

                PdfPCell descripcion = new PdfPCell(new Phrase("Descripcion", standarFont));
                descripcion.BorderWidth = 0;
                descripcion.BorderWidth = 0.75f;

                tablaAutoPartes.AddCell(tipo);
                tablaAutoPartes.AddCell(material);
                tablaAutoPartes.AddCell(nroDeSerie);
                tablaAutoPartes.AddCell(alto);
                tablaAutoPartes.AddCell(largo);
                tablaAutoPartes.AddCell(peso);
                tablaAutoPartes.AddCell(defectuoso);
                tablaAutoPartes.AddCell(descripcion);

                foreach (AutoParte item in listaAutoParte)
                {
                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(item.Tipo.ToString(), standarFont)));
                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(item.TipoDeMaterial.ToString(), standarFont)));
                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(item.NumeroDeSerie.ToString(), standarFont)));
                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(item.Alto.ToString(), standarFont)));
                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(item.Largo.ToString(), standarFont)));
                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(item.Peso.ToString(), standarFont)));

                    string aux = "No";
                    if (item.EstaDefectuoso) 
                            aux = "Si";

                    tablaAutoPartes.AddCell(new PdfPCell(new Phrase(aux, standarFont)));

                    switch (item.GetType().Name)
                    {
                        case "Puerta":
                            tablaAutoPartes.AddCell(new PdfPCell(new Phrase(((Puerta)item).ladoPuerta, standarFont)));
                            break;
                        case "Panel":
                            tablaAutoPartes.AddCell(new PdfPCell(new Phrase(((Panel)item).Lado, standarFont)));
                            break;
                        case "Chasis":
                            tablaAutoPartes.AddCell(new PdfPCell(new Phrase(((Chasis)item).TipoDeChasis, standarFont)));
                            break;
                        case "Carroceria":
                            tablaAutoPartes.AddCell(new PdfPCell(new Phrase(((Carroceria)item).TipoCarroceria, standarFont)));
                            break;
                        case "Capot":
                            tablaAutoPartes.AddCell(new PdfPCell(new Phrase(((Capot)item).AperturaDesde, standarFont)));
                            break;
                        case "Baul":
                            tablaAutoPartes.AddCell(new PdfPCell(new Phrase(((Baul)item).Capacidad, standarFont)));
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                throw new FileException("Hubo un error creando la tabla", e);
            }

            return tablaAutoPartes;
        }
    }
}