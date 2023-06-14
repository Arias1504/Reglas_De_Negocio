using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libRnVerduras;

namespace libOpeVerduras
{
    public class clsOpeVerduras
    {
        #region "Atributos"
        private int intCod;
        private float fltvrDolar, fltCantidad;
        private float fltVrDescuento;
        private float fltVrAPagar;
        private string strError;
        #endregion

        #region "Constructor"
        public clsOpeVerduras()
        {
            intCod = 0;
            fltvrDolar = 0;
            fltCantidad = 0;
            fltVrDescuento = 0;
            fltVrAPagar = 0;
            strError = string.Empty;
        }
        #endregion

        #region "Propiedades"
        //Entrada y salida
        public int Codigo
        {
            set { intCod = value; }
            get { return intCod; }
        }

        //Entrada
        public float vrDolar
        {
            set { fltvrDolar = value; }
        }
        public float cantidad
        {
            set { fltCantidad = value; }
        }

        //Salida
        public float vrDescuento
        {
            get { return fltVrDescuento; }
        }
        public float Total
        {
            get { return fltVrAPagar; }
        }
        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region "Metodos privados"
        private bool Validar()
        {
            if (intCod < 0 || intCod > 6)
            {
                strError = "Codigo no valido";
                return false;
            }
            if (fltvrDolar < 0)
            {
                strError = "Valor del Dollar no valido";
                return false;
            }
            if (fltCantidad < 0)
            {
                strError = "Cantidad no valida";
                return false;
            }
            return true;
        }

        private bool Procesar()
        {
            if (!Validar())
                return false;

            try
            {
                //Crear un objeto
                clsRnVerduras Vr = new clsRnVerduras();

                //Enviar info
                Vr.Codigo = intCod;

                //Invocacion del metodo y tratamiento del error 
                if (!Vr.Consultar())
                {
                    strError = Vr.Error;
                    Vr = null;
                    return false;
                }

                switch (intCod)
                {
                    case 1:
                        if (fltCantidad >= Vr.CantidadMin)
                        {
                            fltVrDescuento = ((fltvrDolar * 1.85f) * fltCantidad) * Vr.Descuento / 100;
                            fltVrAPagar = ((fltvrDolar * 1.85f) * fltCantidad) - fltVrDescuento;
                        }
                        else
                        {
                            fltVrDescuento = 0;
                            fltVrAPagar = ((fltvrDolar * 1.85f) * fltCantidad);
                        }
                        break;
                    case 2:
                        if (fltCantidad >= Vr.CantidadMin)
                        {
                            fltVrDescuento = ((fltvrDolar * 1.20f) * fltCantidad) * Vr.Descuento / 100;
                            fltVrAPagar = ((fltvrDolar * 1.20f) * fltCantidad) - fltVrDescuento;
                        }
                        else
                        {
                            fltVrDescuento = 0;
                            fltVrAPagar = ((fltvrDolar * 1.20f) * fltCantidad);
                        }
                        break;
                    case 3:
                        if (fltCantidad >= Vr.CantidadMin)
                        {
                            fltVrDescuento = ((fltvrDolar * 1.75f) * fltCantidad) * Vr.Descuento / 100;
                            fltVrAPagar = ((fltvrDolar * 1.75f) * fltCantidad) - fltVrDescuento;
                        }
                        else
                        {
                            fltVrDescuento = 0;
                            fltVrAPagar = ((fltvrDolar * 1.75f) * fltCantidad);
                        }
                        break;
                    case 4:
                        if (fltCantidad >= Vr.CantidadMin)
                        {
                            fltVrDescuento = ((fltvrDolar * 0.98f) * fltCantidad) * Vr.Descuento / 100;
                            fltVrAPagar = ((fltvrDolar * 0.98f) * fltCantidad) - fltVrDescuento;
                        }
                        else
                        {
                            fltVrDescuento = 0;
                            fltVrAPagar = ((fltvrDolar * 0.98f) * fltCantidad);
                        }
                        break;
                    case 5:
                        if (fltCantidad >= Vr.CantidadMin)
                        {
                            fltVrDescuento = ((fltvrDolar * 1.15f) * fltCantidad) * Vr.Descuento / 100;
                            fltVrAPagar = ((fltvrDolar * 1.15f) * fltCantidad) - fltVrDescuento;
                        }
                        else
                        {
                            fltVrDescuento = 0;
                            fltVrAPagar = ((fltvrDolar * 1.15f) * fltCantidad);
                        }
                        break;
                    default:
                        if (fltCantidad >= Vr.CantidadMin)
                        {
                            fltVrDescuento = ((fltvrDolar * 2.00f) * fltCantidad) * Vr.Descuento / 100;
                            fltVrAPagar = ((fltvrDolar * 2.00f) * fltCantidad) - fltVrDescuento;
                        }
                        else
                        {
                            fltVrDescuento = 0;
                            fltVrAPagar = ((fltvrDolar * 2.00f) * fltCantidad);
                        }
                        break;
                }
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
        public bool Calcular()
        {
            return Procesar();
        }
        #endregion
    }
}
