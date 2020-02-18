using System;
using System.Windows.Forms;

namespace Searching
{
    public partial class Form1 : Form
    {
        private readonly Searching _searching = new Searching();

        private enum Type { Serial, Binary }
        private Type _type = Type.Serial;

        private readonly String[] _theListToSearch;
        private int _max;

        public Form1()
        {
            InitializeComponent();
            _theListToSearch = new String[10];
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int result;
            if (_type == Type.Binary)
            {
                result = _searching.binarySearch(_theListToSearch, searchText.Text, _max);
            } else
            {
                result = _searching.serialSearch(_theListToSearch, searchText.Text);
            }

            if (result != -1)
            {
                resultsLabel1.Text = "String found at: ";
                resultsLabel2.Text = result.ToString();
                return;
            }
            resultsLabel1.Text = "String not found";
            resultsLabel2.Text = "";

        }

        private void stringList_TextChanged(object sender, EventArgs e)
        {
            for (int lineNum = 0; lineNum < stringList.Lines.Length; lineNum++)
            {
                // transfer each line into my array for searching
                _theListToSearch[lineNum] = stringList.Lines[lineNum];

                if (lineNum > _max) _max = lineNum;
            }
        }

        private void typeButton_Click(object sender, EventArgs e)
        {
            if (_type == Type.Serial)
            {
                typeButton.Text = "Binary";
                _type = Type.Binary;

                return;
            }

            typeButton.Text = "Serial";
            _type = Type.Serial; 
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _max; i++)
            {
                bool changed = false;
                for (int j = 0; j < _max - i; j++)
                {
                    if (string.CompareOrdinal(_theListToSearch[j], _theListToSearch[j + 1]) > 0)
                    {
                        string temp = _theListToSearch[j];

                        _theListToSearch[j] = _theListToSearch[j + 1];
                        _theListToSearch[j + 1] = temp;

                        changed = true;
                    }
                }

                if (!changed)
                {
                    break;
                }
            }
        }
    }
}