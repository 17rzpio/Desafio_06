using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;



namespace Desafio_06
{
    
    public partial class Form1 : Form
    {
        List<Aluno> alunos = new List<Aluno>();
        double somaNotas = 0;
        public class Aluno
        {
            public string nome { get; set; }
            public int idade { get; set; }
            public double nota { get; set; }
        }
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            alunos.Add(new Aluno() { nome = txtNome.Text, idade = int.Parse(txtIdade.Text), nota = double.Parse(txtNota.Text) });
            MessageBox.Show("Cadastrado realizado com Sucesso","Cadastro",MessageBoxButtons.OK,MessageBoxIcon.Information);
            somaNotas += double.Parse(txtIdade.Text);

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "Nome";
            xlWorkSheet.Cells[1, 2] = "Idade";
            xlWorkSheet.Cells[1, 3] = "Nota";
            xlWorkSheet.Cells[1, 4] = "A soma de Notas";
            xlWorkSheet.Cells[2, 1] = txtNome.Text;
            xlWorkSheet.Cells[2, 2] = txtIdade.Text;
            xlWorkSheet.Cells[2, 3] = txtNota.Text;
            xlWorkSheet.Cells[2, 4] = somaNotas;

            xlWorkBook.SaveAs2("alunos.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            MessageBox.Show("Concluido","Atenção",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);







        }
    }
}
