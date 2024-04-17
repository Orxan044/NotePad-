using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace NotePad_;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void GetFilePath_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "(*.txt)|*.txt|(*.*)|*.*";
        if (openFileDialog.ShowDialog() == true)
        {
            string path = openFileDialog.FileName;
            try
            {
                string fileRead = File.ReadAllText(path);
                txtBox.Text = fileRead;
                txtBoxFileName.Text = path;
            }
            catch (IOException) { MessageBox.Show("File Not Read"); }
            
        }
    }

    private void SaveFile_Click(object sender, RoutedEventArgs e)
    {
        if (txtBoxFileName is not null)
        {
            File.WriteAllText($"{txtBoxFileName}.txt",txtBox.Text);
            MessageBox.Show("File Save");

        }
        else
            MessageBox.Show("File Name Not Null");


    }

}
