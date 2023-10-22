using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_5___PA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Agregra controladores de eventos TextChanged a los campos
            tbEdad.TextChanged += ValidarEdad;
            tbEstatura.TextChanged += ValidarEstatura;
            tbTelefono.TextChanged += ValidarTelefono;
            tbNombres.TextChanged += ValidarNombres;
            tbApellidos.TextChanged += ValidarApellidos;
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

            //Validar que los campos tengan el formato correcto
            if (EsEnteroValido(edad) && EsDecimalValido(estatura) && EsEnteroValidoDe10Digitos(telefono) &&
                EsTextoValido(nombres) && EsTextoValido(apellidos))
            {
                //Crear una cadena con los datos
                string datos = $"Nombres: {nombres}\r\nApellido: {apellidos}\r\nTelefono: {telefono}\r\nEstatura: {estatura} cm\r\nEdad {edad} años\r\nGenero: {genero}\r\n";

                //Guardar los datos en un archivo de texto 
                string rutaArchivo = "C:/Users/Frein/OneDrive/Documentos/UNACH/Programacion Avanzada/Datos.txt";
                bool archivoExiste = File.Exists(rutaArchivo);
                if (archivoExiste == false)
                {
                    File.WriteAllText(rutaArchivo, datos);
                }
                else
                {
                    // Verificar si el archivo ya existe
                    using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                    {
                        if (archivoExiste)
                        {
                            //Si el archivo existe, añadir un separador antes del nuevo registro
                            writer.WriteLine(datos);
                        }

                        writer.WriteLine(datos);
                    }
                }

                //Mostrar un mensaje con los datos capturados
                MessageBox.Show("Datos guardados con exito:\n\n" + datos, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese datos validos en los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsEnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }

        private bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }

        private bool EsEnteroValidoDe10Digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado) && valor.Length == 10;
        }

        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$"); //Solo letras y espacios
        }

        private void ValidarEdad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsEnteroValido(textBox.Text))
            {
                MessageBox.Show("Por favor, ingrese una edad valida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }

        private void ValidarEstatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsDecimalValido(textBox.Text))
            {
                MessageBox.Show("Por favor, ingrese una estatura valida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }

        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text;
            // Eliminar espacios en blanco y guiones si es necesario
            // input = input.Replace(" ", "").Replace("-", "");
            if (input.Length < 10)
            {
                return;
            }
            if (!EsEnteroValidoDe10Digitos(input))
            {
                MessageBox.Show("Por favor, ingrese un numero de telefono valido de 10 digitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarNombres(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsTextoValido(textBox.Text))
            {
                MessageBox.Show("Por favor, ingrese nombres validos (solo letras y espacios).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
        }

        private void ValidarApellidos(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (!EsTextoValido(textBox.Text))
            {
                MessageBox.Show("Por favor, ingrese apellidos validos (solo letras y espacios).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Clear();
            }
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
