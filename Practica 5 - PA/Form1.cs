using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_5___PA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Obtener los datos de los TextBox
            string nombres = tbNombres.Text;
            string apellidos = tbApellidos.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;
            string telefono = tbTelefono.Text;

            //Obtener el genero seleccionado
            string genero = "";
            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }

            //Crear una cadena con los datos
            string datos = $"Nombres: {nombres}\r\nApellido: {apellidos}\r\nTelefono: {telefono}\r\nEstatura: {estatura} cm\r\nEdad {edad} años\r\nGenero: {genero}\r\n";

            //Guardar los datos en un archivo de texto 
            string rutaArchivo = "C:/Users/Frein/OneDrive/Documentos/UNACH/Programacion Avanzada/Datos.txt";
            bool archivoExiste = File.Exists(rutaArchivo);

            // Verificar si el archivo ya existe
            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                if (archivoExiste)
                {
                    //Si el archivo existe, añadir un separador antes del nuevo registro
                    writer.WriteLine(datos);

                }
            }

            //Mostrar un mensaje con los datos capturados
            MessageBox.Show("Datos guardados con exito:\n\n" + datos, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //Limpiar los controles despues de guardar
            tbNombres.Clear();
            tbApellidos.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            tbEdad.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }
    }
}
