using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PGTA_Third_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",  // Filtro para solo archivos CSV
                Title = "Seleccionar archivo CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Llamar al método para leer solo los tres primeros valores de la primera columna
                List<string> firstColumnData = ReadFirstThreeValues(filePath);

                // Mostrar los tres primeros datos de la primera columna en un MessageBox
                string message = string.Join(Environment.NewLine, firstColumnData);
                MessageBox.Show($"Primeros tres valores de la primera columna:\n{message}", "Contenido del archivo CSV");
            }
        }

        private List<string> ReadFirstThreeValues(string filePath)
        {
            List<string> columnData = new List<string>();
            int count = 0;

            // Abrir y leer el archivo CSV
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Leer la primera línea (cabecera) y omitirla
                reader.ReadLine();

                // Leer cada línea restante del archivo
                string line;
                while ((line = reader.ReadLine()) != null && count < 20) // Limitar a los tres primeros valores
                {
                    // Dividir la línea en columnas usando ';' como separador
                    string[] columns = line.Split(';');

                    // Verificar que haya al menos una columna antes de agregar
                    if (columns.Length > 0)
                    {
                        columnData.Add(columns[0]); // Agregar el valor de la primera columna
                        count++; // Incrementar el contador
                    }
                }
            }

            return columnData;
        }
    }
}
