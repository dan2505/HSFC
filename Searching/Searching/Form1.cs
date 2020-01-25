﻿using System;
using System.Windows.Forms;

namespace Searching
{
    public partial class Form1 : Form
    {
        private Searching searching = new Searching();

        private enum Type { Serial, Binary }
        private Type type = Type.Serial;

        private String[] theListToSearch;
        private int numOfItems;

        public Form1()
        {
            InitializeComponent();
            theListToSearch = new String[10];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int result;
            if (type == Type.Binary)
            {
                result = searching.binarySearch(theListToSearch, searchText.Text, numOfItems);
            } else
            {
                result = searching.serialSearch(theListToSearch, searchText.Text);
            }

            if (result != -1)
            {
                resultsLabel1.Text = "String found at: ";
                resultsLabel2.Text = result.ToString();
                return;
            }
            resultsLabel1.Text = "String not found";

        }

        private void stringList_TextChanged(object sender, EventArgs e)
        {
            for (int lineNum = 0; lineNum < stringList.Lines.Length; lineNum++)
            {
                // transfer each line into my array for searching
                theListToSearch[lineNum] = stringList.Lines[lineNum];
                numOfItems++;
            }
        }

        private void typeButton_Click(object sender, EventArgs e)
        {
            if (type == Type.Serial)
            {
                typeButton.Text = "Binary";
                type = Type.Binary;

                return;
            }

            typeButton.Text = "Serial";
            type = Type.Serial; 
        }
    }
}