using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<Book> books = new List<Book>();
        String[] ss = new String[100];


        public Form1()
        {
            InitializeComponent();
        }

        // Добавление
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                books.Add(new Book(textBox2.Text, textBox3.Text, textBox4.Text));
                foreach (var book in books)
                {
                    listBox1.Items.Add(book);
                }
                label4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            else
            {
                label4.Text = "Все поля дожны быть заполнены";
            }
        }
        private void addListItem(string value)
        {
            this.listBox1.Items.Add(value);
        }
        // Удаление
        private void button2_Click(object sender, EventArgs e)
        {
            var index = listBox1.SelectedIndex;
            if (index == -1) return;
            var name = books[index].Name;
            books.RemoveAt(index);
            MessageBox.Show(string.Format("Удалено {0}", name), "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBox1.Items.Clear();
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var book in books)
            {
                listBox1.Items.Add(book);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String path = @"J:\1.txt";
            using (StreamReader sr = new StreamReader(path))
                ss = File.ReadAllLines(path);
            for (int i = 0; i < ss.Length; i++)
            {
                string[] temp = ss[i].Split(' ');
                Book book = new Book(temp[0], temp[1], temp[2]);
                books.Add(book);
            }
        }
    }
    public class Book
    {
        public Book() { }

        public Book(
            string author,
            string name,
            string publisher)
        {
            Author = author;
            Name = name;
            Publisher = publisher;
        }

        public string Author { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }

        public override string ToString()
        {
            return string.Format("Название: {0}, Автор: {1}, Издательство: {2}", Name, Author, Publisher);
        }
    }
}
