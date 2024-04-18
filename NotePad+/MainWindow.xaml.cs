using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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
        string? fileName = txtBoxFileName.Text;
        string? regexFileName = @"(\.json|\.txt)$";
        if (Regex.IsMatch(fileName, regexFileName))
        {
            File.WriteAllText(fileName, txtBox.Text);
            MessageBox.Show("File Saveing");
        }
        else
            MessageBox.Show("File Name is not correct");
    }


    private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (checkBox.IsChecked == true)
        {
            string? fileName = txtBoxFileName.Text;
            string? regexFileName = @"(\.json|\.txt)$";
            if (Regex.IsMatch(fileName, regexFileName))
            {
                File.WriteAllText(fileName, txtBox.Text);
            }
        }
    }

    private void TxtBox_CanToClick(object sender, RoutedEventArgs e)
    {
        Button btn = (Button)sender;

        if (btn.Name == "Cut") txtBox.Cut();
        if (btn.Name == "Copy") txtBox.Copy();
        if (btn.Name == "Paste") txtBox.Paste();
        if (btn.Name == "Select_All") txtBox.SelectAll();
        

    }
}


