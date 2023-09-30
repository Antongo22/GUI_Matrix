using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI_Matrix
{
    public partial class Form1 : Form
    {
        private List<TextBox> generatedTextBoxes = new List<TextBox>();
        int rows;
        int columns;
        double[,] matrix;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void InitializeMatrix()
        {
            if (String.IsNullOrEmpty(textBoxMatrixStart.Text) || String.IsNullOrEmpty(textBoxMatrixEnd.Text))
            {
                return;
            }

            // Получаем значения из textbox1 и textbox2 и преобразуем их в целые числа
            if (int.TryParse(textBoxMatrixStart.Text, out int rows) && int.TryParse(textBoxMatrixEnd.Text, out int columns))
            {
                if(rows > 10 || columns > 10)
                {
                    MessageBox.Show("Пожалуйста, введите корректные числа для заполнения (максимальная матрица - 10 на 10)!");
                    return;
                }
                this.rows = rows;
                this.columns = columns;

                // Очищаем предыдущие созданные текстбоксы
                ClearTextBoxes();

                // Создаем новые текстбоксы
                CreateTextBoxes(rows, columns);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа для заполнения!");
            }
        }

        private void CreateTextBoxes(int rows, int columns)
        {
            // Определяем размеры и расположение контейнера для текстбоксов (Panel)
            int startX = 15;
            int startY = 40;
            int textBoxWidth = 40;
            int textBoxHeight = 25;
            int spacing = 5;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // Создаем новый текстбокс
                    TextBox newTextBox = new TextBox();
                    newTextBox.Width = textBoxWidth;
                    newTextBox.Height = textBoxHeight;
                    newTextBox.Left = startX + col * (textBoxWidth + spacing);
                    newTextBox.Top = startY + row * (textBoxHeight + spacing);

                    // Добавляем новый текстбокс на форму и в список
                    this.Controls.Add(newTextBox);
                    generatedTextBoxes.Add(newTextBox);
                }
            }
        }

        private void ClearTextBoxes()
        {
            // Удаляем все текстбоксы из списка и с формы
            foreach (TextBox textBox in generatedTextBoxes)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }

            // Очищаем список
            generatedTextBoxes.Clear();
        }

        private void textBoxMatrixStart_TextChanged(object sender, EventArgs e)
        {
            InitializeMatrix();
        }

        private void textBoxMatrixEnd_TextChanged(object sender, EventArgs e)
        {
            InitializeMatrix();
        }

        private bool TransferDataToMatrix()
        {
            matrix = new double[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // Получаем значение из соответствующего текстбокса
                    TextBox textBox = generatedTextBoxes[row * columns + col];
                    if (double.TryParse(textBox.Text, out double value))
                    {
                        matrix[row, col] = value;
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, введите корректное числовое значение во все текстбоксы.");
                        return false;
                    }
                }
            }
            return true;
        }

        private void buttonCulc_Click(object sender, EventArgs e)
        {
            if (!TransferDataToMatrix()) return;

            Matrix fmatrix = new Matrix(matrix);
            MessageBox.Show(fmatrix.CulcDeterminant().ToString());

        }
    }
}
