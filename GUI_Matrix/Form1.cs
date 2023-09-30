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
        private List<TextBox> generatedKramers = new List<TextBox>();
        private List<TextBox> generatedMultMatrix = new List<TextBox>();
        int rows;
        int columns;
        double[,] matrix;
        double[,] multMatrix;

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
                    buttonCulc.Visible = false;
                    ClearTextBoxes();
                    return;
                }
                this.rows = rows;
                this.columns = columns;

                // Очищаем предыдущие созданные текстбоксы
                ClearTextBoxes();

                if (comboBox1.Text == "Крамер")
                {
                    ClearKramers();
                    ShowKramer();
                }
                else if (comboBox1.Text == "Умножение на матриуц")
                {
                    ClearMult();
                    CreateMultTextBoxes();
                }
                else if (comboBox1.Text == "Умножение на матрицу")
                {
                    ClearMult();
                    CreateMultTextBoxes();
                }

                // Создаем новые текстбоксы
                CreateTextBoxes(rows, columns);

                buttonCulc.Visible = true;

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

                    // Доба вляем новый текстбокс на форму и в список
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
            foreach (TextBox textBox in generatedKramers)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }
            foreach (TextBox textBox in generatedMultMatrix)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }

            // Очищаем список
            generatedTextBoxes.Clear();
            generatedKramers.Clear();
            generatedMultMatrix.Clear();
        }

        private void ClearKramers()
        {
            foreach (TextBox textBox in generatedKramers)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }

            generatedKramers.Clear();
        }

        private void ClearMult()
        {
            foreach (TextBox textBox in generatedMultMatrix)
            {
                this.Controls.Remove(textBox);
                textBox.Dispose();
            }

            generatedMultMatrix.Clear();
        }

        private void textBoxMatrixStart_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxMatrixStart.Text) || String.IsNullOrEmpty(textBoxMatrixEnd.Text))
            {
                comboBox1.Visible = false;
            }
            else
            {
                comboBox1.Visible = true;
            }
            if (int.TryParse(textBoxMatrixStart.Text, out int rows) && int.TryParse(textBoxMatrixEnd.Text, out int columns))
            {
                if (rows == 0 || columns == 0)
                {
                    buttonCulc.Visible = false;
                    return;
                }
            }
            else
            {
                buttonCulc.Visible = false;
            }

            InitializeMatrix();
        }

        private void textBoxMatrixEnd_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxMatrixStart.Text) || String.IsNullOrEmpty(textBoxMatrixEnd.Text))
            {
                comboBox1.Visible = false;
            }
            else
            {
                comboBox1.Visible = true;
            }
            if (int.TryParse(textBoxMatrixStart.Text, out int rows) && int.TryParse(textBoxMatrixEnd.Text, out int columns))
            {
                if (rows == 0 || columns == 0)
                {
                    buttonCulc.Visible = false;
                    return;
                }
            }
           

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

        private bool TransferDataToMultMatrix()
        {
            multMatrix = new double[columns, rows];

            for (int row = 0; row < columns; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    // Получаем значение из соответствующего текстбокса
                    TextBox textBox = generatedMultMatrix[row * rows + col];
                    if (double.TryParse(textBox.Text, out double value))
                    {
                        multMatrix[row, col] = value;
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


        void ShowKramer()
        {
            // Определяем размеры и расположение контейнера для текстбоксов (Panel)
            int startX = 920;
            int startY = 40;
            int textBoxWidth = 40;
            int textBoxHeight = 25;
            int spacing = 5;

            for (int row = 0; row < rows; row++)
            {
                // Создаем новый текстбокс
                TextBox newTextBox = new TextBox();
                newTextBox.Width = textBoxWidth;
                newTextBox.Height = textBoxHeight;
                newTextBox.Left = startX;
                newTextBox.Top = startY + row * (textBoxHeight + spacing);

                // Добавляем новый текстбокс на форму и в список
                this.Controls.Add(newTextBox);
                generatedKramers.Add(newTextBox);
            }
        }

        private void buttonCulc_Click(object sender, EventArgs e)
        {

            if (!TransferDataToMatrix()) return;
            Matrix fmatrix = new Matrix(matrix);
            switch (comboBox1.Text)
            {
                case "Определитель":                   
                    MessageBox.Show(fmatrix.CulcDeterminant().ToString());
                    break;
                case "Обратная матрица":
                    try
                    {
                        string invmat = fmatrix.InverseMatrix().ToString();
                        MessageBox.Show(invmat);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                    break;
                case "Крамер":
                    try
                    {
                        double[] kramers = GetKramers();
                        double[] kram_res = fmatrix.Kramer(kramers);

                        string finalRes = "";
                        for(int i = 0; i < kram_res.Length; i++)
                        {
                            finalRes += kram_res[i] + "  ";
                        }
                        MessageBox.Show(finalRes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "Умножение на число":
                    if(!double.TryParse(textBoxMult.Text, out double result))
                    {
                        MessageBox.Show("Неверные данные! Заполните ещё раз!");
                        return; 
                    }

                    string ans = (fmatrix * result).ToString();
                    MessageBox.Show(ans);
                    break;

                case "Умножение на матрицу":
                    if (!TransferDataToMultMatrix()) return;

                    Matrix multMatrx = new Matrix(multMatrix);

                    string newMutMatrix = (fmatrix * multMatrx).ToString();
                    MessageBox.Show(newMutMatrix);
                    break;


            }
            

        }

        double[] GetKramers()
        {
            double[] kr = new double[generatedKramers.Count()];

            for(int i = 0; i < generatedKramers.Count; i++)
            {
                if(double.TryParse(generatedKramers[i].Text, out double num))
                {
                    kr[i] = num;
                }
                else
                {
                    throw new Exception("Заполните все поля коректно!");
                }
            }
            return kr;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearMult();
            ClearKramers();
            textBoxMult.Visible = false;
            if (comboBox1.Text == "Крамер")
            {               
                ShowKramer();
            }
            else if (comboBox1.Text == "Умножение на матрицу")
            {
                CreateMultTextBoxes();
            }
            else if (comboBox1.Text == "Умножение на число")
            {
                textBoxMult.Visible = true;
            }
        }

        private void CreateMultTextBoxes()
        {
            // Определяем размеры и расположение контейнера для текстбоксов (Panel)
            int startX = 500;
            int startY = 40;
            int textBoxWidth = 40;
            int textBoxHeight = 25;
            int spacing = 5;

            for (int row = 0; row < columns; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    // Создаем новый текстбокс
                    TextBox newTextBox = new TextBox();
                    newTextBox.Width = textBoxWidth;
                    newTextBox.Height = textBoxHeight;
                    newTextBox.Left = startX + col * (textBoxWidth + spacing);
                    newTextBox.Top = startY + row * (textBoxHeight + spacing);

                    // Доба вляем новый текстбокс на форму и в список
                    this.Controls.Add(newTextBox);
                    generatedMultMatrix.Add(newTextBox);
                }
            }
        }

        private void buttonCl_Click(object sender, EventArgs e)
        {
            ClearKramers();
            ClearMult();
            ClearTextBoxes();
            textBoxMult.Visible = false;
            textBoxMatrixStart.Text = string.Empty;
            textBoxMatrixEnd.Text = string.Empty;
        }
    }
}
