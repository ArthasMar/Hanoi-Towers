using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hanoi_Towers
{
    public partial class Form1 : Form
    {
        private int step = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int n))
            {
                step = 0;
                listBox1.Items.Clear();
                Hanoi(new Tower("A", n), new Tower("B", 0), new Tower("C", 0), n);
            }
            else
                MessageBox.Show("Неверный ввод!");
        }
        private void Hanoi(Tower A, Tower B, Tower C, int n)
        {
            if (n == 1)
            {
                A.Count--;
                C.Count++;
                step++;
                listBox1.Items.Add($"{step}: Move {A.Name} -> {C.Name}");
            }
            else
            {
                Hanoi(A, C, B, n - 1);

                A.Count--;
                C.Count++;
                step++;
                listBox1.Items.Add($"{step}: Move {A.Name} -> {C.Name}");

                Hanoi(B, A, C, n - 1);
            }
        } 
    }
    public class Tower
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public Tower(string name, int count)
        {
            Count = count;
            Name = name;
        }
    }
        
}
