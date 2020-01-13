using System;
using System.Windows.Forms;

namespace Searching
{
    public partial class Form1 : Form
    {
        private Searching mySearching = new Searching();

        private enum Type { Serial, Binary }

        private String[] theListToSearch;
        private const int numOfItems = 100;
        private Type type = Type.Serial;

        public Form1()
        {
            InitializeComponent();
            theListToSearch = new String[numOfItems];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            resultsLabel1.Text = " ";
            resultsLabel2.Text = " ";

            int result;
            if (type == Type.Binary)
            {
                result = mySearching.binarySearch(theListToSearch, searchText.Text);
            } else
            {
                result = mySearching.serialSearch(theListToSearch, searchText.Text);
            }

            if (result == -1)
            {
                resultsLabel1.Text = "String not found";
            }
            else
            {
                resultsLabel1.Text = "String found at: ";
                resultsLabel2.Text = result.ToString();
            }

        }

        private void stringList_TextChanged(object sender, EventArgs e)
        {
            for (int lineNum = 0; lineNum < stringList.Lines.Length; lineNum++)
            {
                // transfer each line into my array for searching
                theListToSearch[lineNum] = stringList.Lines[lineNum];
            }
        }

        private void typeButton_Click(object sender, EventArgs e)
        {
            if (typeButton.Text == "Serial")
            {
                typeButton.Text = "Binary";
                type = Type.Binary;
            } else
            {
                typeButton.Text = "Serial";
                type = Type.Serial;
            }
        }
    }
}
