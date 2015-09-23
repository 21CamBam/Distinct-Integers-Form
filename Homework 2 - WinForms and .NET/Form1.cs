using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Homework_2___WinForms_and.NET
{
    public partial class Form1 : Form
    {
        private int ENTRIES = 10000;
        private int BOUND = 20000;
        List<int> random_list;
        public Form1()
        {
            random_list = new List<int>();
            InitializeComponent();
            populate_list();

            textBox1.AppendText("1. HashSet method: " + hash_set_distincts() + " unique numbers\n");
            textBox1.AppendText("       The HashSet Add function defaults to an AddIfNotPresent function that first gets the hashcode \n");
            textBox1.AppendText("   with an internal hash function at O(1). The function then checks if there is already a value at \n");
            textBox1.AppendText("   the hashcode index. If there is not, then the new value is inserted at that index. The Add function \n");
            textBox1.AppendText("   is called for all of the elements in the random list. This makes the whole algorithm O(n).\n");
            textBox1.AppendText("2. O(1) storage method: " + space_constraint_distincts() + " unique numbers\n");
            textBox1.AppendText("3. Sorted method: " + time_and_space_constraints_distincts() + " unique numbers\n");

        }

        private void populate_list() // Generate list of random integers
        {
            Random rand = new Random();

            for (int i = 0; i < ENTRIES; i++)
            {
                random_list.Add(rand.Next(BOUND));
            }
        }

        private int hash_set_distincts()
        {
            HashSet<int> hash = new HashSet<int>(); // Distincts

            foreach (int num in random_list)
            {
                hash.Add(num);
            }
            return hash.Count;
        }

        private int space_constraint_distincts() // SUPER SLOW
        {
            int num_distincts = ENTRIES;

            for (int k = 0; k < random_list.Count; k++) // count occurances
            {
                for (int i = 0; i < k; i++)
                {
                    if (i == k) // don't compare to itself
                        continue;

                    if (random_list[k] == random_list[i]) // if duplicate found
                    {
                        num_distincts--; // decrement
                        break;
                    }
                }
            }

            return num_distincts;
        }

        private int time_and_space_constraints_distincts()
        {
            int num_distincts = ENTRIES, current = random_list[0];

            random_list.Sort();

            foreach (int num in random_list)
            {
                if (num == current) // if num is non-distinct
                {
                    num_distincts--; // just remove num
                }
                else
                {
                    current = num; // next num
                }
            }
            
            return num_distincts;
        }
    }
}
