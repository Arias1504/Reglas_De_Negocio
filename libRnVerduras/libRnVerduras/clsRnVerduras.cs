using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace libRnVerduras
{
    public class clsRnVerduras
    {
        #region "Atributos"
        private int intCodigo;
        private float fltDescuento;
        private float fltMinKg;
        private string strError;
        #endregion

        #region "Constructor"
        public clsRnVerduras()
        {
            intCodigo = 0;
            fltDescuento = 0;
            fltMinKg = 0;
            strError = string.Empty;
        }
        #endregion

        #region "Propiedades"
        //Entrada
        public int Codigo
        {
            set { intCodigo = value; }
        }

        //Salida
        public float Descuento
        {
            get { return fltDescuento; }
        }
        public float CantidadMin
        {
            get { return fltMinKg; }
        }
        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos privados"
        private bool leerArchivo()
        {
            try
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory + @"ListaDescuentos.txt";
                int intCant = 0;  // Para la cantidad de líneas que tiene el archivo
                string strLinea;  // Para la línea leída del archivo
                string[] vectorLinea;  // Vector para almacenar la línea del archivo
                string strCodigo;
                intCant = File.ReadAllLines(strPath).Length;  // Lee la cantidad de líneas que tiene el archivo
                if (intCant <= 0)
                {
                    strError = "Sin registros";
                    return false;
                }
                StreamReader Archivo = new StreamReader(@strPath); // Crear objeto para leer el archivo 
                while ((strLinea = Archivo.ReadLine()) != null)   // Leer línea * línea el archivo 
                {
                    vectorLinea = strLinea.Split('#');
                    strCodigo = vectorLinea[0]; //Nombre Dato 
                    if (strCodigo == intCodigo.ToString())
                    {
                        fltDescuento = Convert.ToSingle(vectorLinea[1]); // Vr. Descuento
                        fltMinKg = Convert.ToSingle(vectorLinea[2]); // Cantidad minima para descuento  
                        break;
                    }
                }
                Archivo.Close();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        #endregion

        #region "Metodos publicos"
        public bool Consultar()
        {
            return leerArchivo();
        }
        #endregion
    }
}
