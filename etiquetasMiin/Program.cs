using System;
using etiquetasMiin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace etiquetasMiin
{
    class Program
    {
        static async Task Main(string[] args)
        {
            VSageEtiquetasAlbarane etiquetaAlb = new VSageEtiquetasAlbarane();

            await Task.Run(() =>
            {
                etiquetaAlb = datosEtiquetas(short.Parse(args[0]), short.Parse(args[1]), args[2], int.Parse(args[3]));

                if (args[4] == "0")//Evaluamos argumento, en caso de 0, generamos archivo para GLS
                {
                    string strSeperator = "|";
                    //string filePathGLS = "C:\\Users\\juan.gomez\\Desktop\\GLS\\etiquetaMiinGLS.csv";
                    string filePathGLS = datosPath("GLS");

                    string[] etiquetaMinnGLS = new string[] { etiquetaAlb.NumeroPedido.ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", etiquetaAlb.Nombre, etiquetaAlb.Domicilio, etiquetaAlb.Municipio,
                    "", etiquetaAlb.SiglaNacion, etiquetaAlb.CodigoPostal, etiquetaAlb.Telefono, "", "", etiquetaAlb.ObservacionesAlbaran, "", "", etiquetaAlb.Bultos.ToString(), etiquetaAlb.PesoBruto.ToString(), args[5], "", "", "", "", "", "", "", "", "", "", "", "", "", "", etiquetaAlb.NumeroAlbaran.ToString(),
                    "", "", "", "", "", "", "", "", etiquetaAlb.Nombre, etiquetaAlb.Telefono, etiquetaAlb.Email1, "", "", "" };

                    StringBuilder sbOutput = new StringBuilder();

                    sbOutput.AppendLine(string.Join(strSeperator, etiquetaMinnGLS));

                    File.WriteAllText(filePathGLS, sbOutput.ToString());
                }
                else if (args[4] == "1")//Evaluamos argumento, en caso de 1, generamos archivos BtoC y BtoB para UPS
                {
                    string strSeperator = ";";
                    //string filePathUPS = "C:\\Users\\juan.gomez\\Desktop\\UPS\\etiquetaMiinUPS.csv";
                    string filePathUPS = datosPath("UPS");
                    if(etiquetaAlb.ObservacionesAlbaran == "")
                    {
                        etiquetaAlb.ObservacionesAlbaran = ".";
                    }

                    string[] etiquetaMiinUPS = new string[] { etiquetaAlb.Nombre, etiquetaAlb.Nombre, etiquetaAlb.Domicilio, "", "", etiquetaAlb.Municipio, etiquetaAlb.SiglaNacion, "", etiquetaAlb.CodigoPostal, etiquetaAlb.Telefono, etiquetaAlb.Email1, "ST", "CP", etiquetaAlb.Bultos.ToString(), Math.Round(etiquetaAlb.PesoBruto,2).ToString(), etiquetaAlb.ObservacionesAlbaran, etiquetaAlb.NumeroPedido.ToString(), etiquetaAlb.NumeroAlbaran.ToString(), "SHP", "REC", "N", "", "", "", "", "N", "0X6741" };

                    StringBuilder sbOutput = new StringBuilder();
                    sbOutput.AppendLine(string.Join(strSeperator, etiquetaMiinUPS));

                    File.WriteAllText(filePathUPS, sbOutput.ToString());
                }
            });
        }

        public static string datosPath(string pathTransp)
        {
            WfPath path = new WfPath();
            using (appDBContext dBContext = new appDBContext())
            {
                path = dBContext.WfPaths.Where(x => x.Path == pathTransp).FirstOrDefault();
            }
            return path.RutaAbsoluta;
        }

        public static VSageEtiquetasAlbarane datosEtiquetas(short codEmp, short ejercicio, string serie, int numAlb)//Obtnemos datos de tabla CabeceraPedidoCliente
        {
            VSageEtiquetasAlbarane cabPedCli = new VSageEtiquetasAlbarane();
            using (appDBContext dBContext = new appDBContext())
            {
                cabPedCli = dBContext.VSageEtiquetasAlbaranes.Where(x => x.CodigoEmpresa == codEmp && x.EjercicioAlbaran == ejercicio && x.SerieAlbaran == serie && x.NumeroAlbaran == numAlb).FirstOrDefault();
            }
            return cabPedCli;
        }
    }
}
