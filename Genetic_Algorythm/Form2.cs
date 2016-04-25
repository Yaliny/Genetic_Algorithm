using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Genetic_Algorythm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        public static int capacity = new int();
        public static int numberOfItems = new int();
        public static int populationSize = new int();
        public static int numberOfGenerations = new int();
        public static int crossoverProbability = new int();
        public static int mutationProbability = new int();
        public static int currentGeneration = new int();
        public static int currentChromosome = new int();
        public static int bestFitnessIndex = new int();
        public static int bestFitnessValue = new int();
        public static int bestFitnessQuantity = new int();
        public static int bestFitnessWeight = new int();
        public static int bestSolutionIndex = new int();
        public static int bestSolutionValue = new int();
        public static int bestSolutionQuantity = new int();
        public static int bestSolutionWeight = new int();
        public static int parentIndex1 = new int();
        public static int parentIndex2 = new int();
        public static int[] weightsTemplate = new int[20] {4, 8, 1, 3, 2, 2, 3, 9, 1, 6, 7, 10, 5, 7, 6, 8, 4, 9, 3, 5};
        public static int[] valuesTemplate = new int[20] { 5, 3, 9, 4, 8, 6, 7, 5, 10, 7, 6, 1, 9, 3, 2, 2, 3, 1, 4, 8 };
        public static int[] capacityTemplate = new int[4] { 9, 18, 27, 36 };
        public static int[] weights;
        public static int[] values;
        public static int[] fitness;
        public static int[] sumOfWeights;
        public static int[] quantityOfItems;
        public static int[] selectionProbability;
        public static int[,] probabilityDiapason;
        public static bool[,] population;
        public static bool[,] newPopulation;

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void maskedTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "")
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Initialization of the input variables
            numberOfItems = Convert.ToInt32(comboBox1.Text);
            capacity = capacityTemplate[comboBox1.SelectedIndex];
            label16.Text = capacity.ToString();
            populationSize = Convert.ToInt32(maskedTextBox1.Text);
            numberOfGenerations = Convert.ToInt32(maskedTextBox2.Text);
            crossoverProbability = Convert.ToInt32(maskedTextBox3.Text);
            mutationProbability = Convert.ToInt32(maskedTextBox4.Text);
            currentGeneration = 0;
            label17.Text = currentGeneration.ToString();
            
            //Initialization of arrays
            population = new bool[numberOfItems, populationSize];
            fitness = new int[populationSize];
            sumOfWeights = new int[populationSize];
            quantityOfItems = new int[populationSize];
            selectionProbability = new int[populationSize];
            weights = new int[numberOfItems];
            values = new int[numberOfItems];
            newPopulation = new bool[numberOfItems, populationSize];
            probabilityDiapason = new int[populationSize, 2];
            for (int i = 0; i < numberOfItems; i++)
            {
                weights[i] = weightsTemplate[i];
                values[i] = valuesTemplate[i];
            }               

            //Creating the initial population
            Random rnd = new Random();
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    if (rnd.NextDouble() > 0.5)
                    population[i, j] = true;
                    else
                    population[i, j] = false;
                }
            }

            //Displaying the population in the data grid
            dataGridView1.ColumnCount = numberOfItems;
            dataGridView1.RowCount = populationSize;
            int rowNumber = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                row.HeaderCell.Value = "Chromosome " + rowNumber;
                rowNumber = rowNumber + 1;
            }
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    if (!population[i,j])
                    {dataGridView1[i, j].Value = 0;}
                    else
                    { dataGridView1[i, j].Value = 1; }
                }
            }

            //Displaying the item set in the data grid
            dataGridView2.ColumnCount = numberOfItems;
            dataGridView2.RowCount = 2;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {

                column.HeaderText = String.Concat("Item ",
                    (column.Index + 1).ToString());
            }
            dataGridView2.Rows[0].HeaderCell.Value = " Value";
            dataGridView2.Rows[1].HeaderCell.Value = "Weight";
            for (int i = 0; i < numberOfItems; i++)
            {
                dataGridView2[i, 0].Value = values[i];
                dataGridView2[i, 1].Value = weights[i];
            }

            //Calculation of initial fitness function and best chromosomes
            calculateFitness();
            label15.Text = "Chromosome "+ (bestSolutionIndex+1) + ", value: " + bestSolutionValue + ", weight: " + bestSolutionWeight + ", " + bestSolutionQuantity + " items taken.";
            label14.Text = "Chromosome " + (bestFitnessIndex + 1) + ", value: " + bestFitnessValue + ", weight: " + bestFitnessWeight + ", " + bestFitnessQuantity + " items taken.";
            currentGeneration++;

            //Switching the controls' visibility
            dataGridView1.Visible = !dataGridView1.Visible;
            dataGridView2.Visible = !dataGridView2.Visible;
            label1.Visible = !label1.Visible;
            label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label4.Visible = !label4.Visible;
            label5.Visible = !label5.Visible;
            label6.Visible = !label6.Visible;
            label7.Visible = !label7.Visible;
            label8.Visible = !label8.Visible;
            label9.Visible = !label9.Visible;
            label10.Visible = !label10.Visible;
            label11.Visible = !label11.Visible;
            label12.Visible = !label12.Visible;
            label13.Visible = !label13.Visible;
            label14.Visible = !label14.Visible;
            label15.Visible = !label15.Visible;
            label16.Visible = !label16.Visible;
            label17.Visible = !label17.Visible;
            label18.Visible = !label18.Visible;
            label19.Visible = !label18.Visible;
            comboBox1.Visible = !comboBox1.Visible;
            maskedTextBox1.Visible = !maskedTextBox1.Visible;
            maskedTextBox2.Visible = !maskedTextBox2.Visible;
            maskedTextBox3.Visible = !maskedTextBox3.Visible;
            maskedTextBox4.Visible = !maskedTextBox4.Visible;
            button1.Visible = !button1.Visible;
            button2.Visible = !button2.Visible;
            button3.Visible = !button3.Visible;
        }

        void calculateFitness()
        {
            for (int i = 0; i < populationSize; i++)
            {
                fitness[i] = 0;
                sumOfWeights[i] = 0;
                quantityOfItems[i] = 0;
            }
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberOfItems; j++)
                {
                    if (population[j, i])
                    {
                        fitness[i] = fitness[i] + values[j];
                        sumOfWeights[i] = sumOfWeights[i] + weights[j];
                        quantityOfItems[i]++;
                    } 
                }
            }
            bestFitnessValue = fitness.Max();
            bestFitnessIndex = fitness.ToList().IndexOf(bestFitnessValue);
            bestFitnessWeight = sumOfWeights[bestFitnessIndex];
            bestFitnessQuantity = quantityOfItems[bestFitnessIndex];
            bestSolutionValue = 0;
            for (int i = 0; i < populationSize; i++)
            {
                if (fitness[i] > bestSolutionValue && sumOfWeights[i] <= capacity)
                {
                    bestSolutionValue = fitness[i];
                    bestSolutionIndex = i;
                    bestSolutionWeight = sumOfWeights[i];
                    bestSolutionQuantity = quantityOfItems[i];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label17.Text = currentGeneration.ToString();
            label10.Text = "Current generation:";
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    newPopulation[i, j] = false;
                }
            }
            currentChromosome = 0;

            //Elitism - copy of the best chromosome of the previous generation
            for (int i = 0; i < numberOfItems; i++)
            {
                newPopulation[i, currentChromosome] = population[i, bestSolutionIndex];
            }
            currentChromosome++;
            probabilityCalculation();
            Random rnd = new Random();
            while (currentChromosome < populationSize)
            {
                parentsSeletion();
                int breed = rnd.Next(0, 100);
                if (breed <= crossoverProbability)
                    crossover();
                else
                {
                    for (int i = 0; i < numberOfItems; i++)
                    {
                        newPopulation[i, currentChromosome] = population[i, parentIndex1];
                    }
                    currentChromosome++;
                    if (currentChromosome < populationSize)
                    {
                        for (int i = 0; i < numberOfItems; i++)
                        {
                            newPopulation[i, currentChromosome] = population[i, parentIndex2];
                        }
                        currentChromosome++;
                    }
                }
            }
            mutation();
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    population[i,j] = newPopulation[i, j];
                }
            }
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    if (!population[i, j])
                    { dataGridView1[i, j].Value = 0; }
                    else
                    { dataGridView1[i, j].Value = 1; }
                }
            }
            calculateFitness();
            label15.Text = "Chromosome " + (bestSolutionIndex + 1) + ", value: " + bestSolutionValue + ", weight: " + bestSolutionWeight + ", " + bestSolutionQuantity + " items taken.";
            label14.Text = "Chromosome " + (bestFitnessIndex + 1) + ", value: " + bestFitnessValue + ", weight: " + bestFitnessWeight + ", " + bestFitnessQuantity + " items taken.";
            currentGeneration++;
            if (currentGeneration > numberOfGenerations)
            {
                label10.Text = "Final population:";
                button2.Visible = !button2.Visible;
                button3.Visible = !button3.Visible;
                button4.Visible = !button4.Visible;
            }
        }

        void probabilityCalculation()
        {
            for (int i = 0; i < populationSize; i++)
            {
                selectionProbability[i] = 0;
                for (int j = 0; j < 2; j++)
                {
                    probabilityDiapason[i, j] = 0;
                }
            }
            double percent = 0.00;
            int sumFitness = 0;
            for (int i = 0; i < populationSize; i++)
            {
                if (sumOfWeights[i] <= capacity)
                    sumFitness = sumFitness + fitness[i];
            }
            for (int i = 0; i < populationSize; i++)
            {
                if (sumOfWeights[i] <= capacity)
                {
                    selectionProbability[i] = 100 * fitness[i] / sumFitness;
                }
                else
                    selectionProbability[i] = 0;
            }
            probabilityDiapason[0, 0] = 0;
            probabilityDiapason[0, 1] = selectionProbability[0];
            for (int i = 1; i < populationSize; i++)
            {
                probabilityDiapason[i, 0] = probabilityDiapason[i - 1, 1] + 1;
                probabilityDiapason[i, 1] = probabilityDiapason[i, 0] + selectionProbability[i];
            }
        }

        void parentsSeletion()
        {
            parentIndex1 = 0;
            parentIndex2 = 0;
            Random rnd = new Random();
            int roulette = rnd.Next(0, 100);
            for (int i = 1; i < populationSize; i++)
            {
                if (roulette >= probabilityDiapason[i, 0] && roulette < probabilityDiapason[i, 1])
                {
                    parentIndex1 = i;
                    break;
                }
            }
            roulette = 0;
            bool rouletteValid = false;
            while (!rouletteValid)
            {
                roulette = rnd.Next(0, 100);
                if (roulette < probabilityDiapason[parentIndex1, 0] || roulette >= probabilityDiapason[parentIndex1, 1])
                    rouletteValid = true;
            }
            for (int i = 1; i < populationSize; i++)
            {
                if (roulette >= probabilityDiapason[i, 0] && roulette < probabilityDiapason[i, 1])
                {
                    parentIndex2 = i;
                    break;
                }
            }
        }

        void crossover()
        {
            Random rnd = new Random();
            int division = rnd.Next(1, numberOfItems - 2);
            bool firstParent = new bool();
            if (rnd.NextDouble() > 0.5)
                firstParent = true;
            else
                firstParent = false;
            for (int i = 0; i < division; i++)
            {
                if (firstParent)
                    newPopulation[i, currentChromosome] = population[i, parentIndex1];
                else
                    newPopulation[i, currentChromosome] = population[i, parentIndex2];
            }
            for (int i = division; i < numberOfItems; i++)
            {
                if (!firstParent)
                    newPopulation[i, currentChromosome] = population[i, parentIndex1];
                else
                    newPopulation[i, currentChromosome] = population[i, parentIndex2];
            }
            currentChromosome++;
        }

        void mutation()
        {
            Random rnd = new Random();
            int mutate = new int();
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    mutate = rnd.Next(0, 100);
                    if (mutate <= mutationProbability)
                        newPopulation[i, j] = !newPopulation[i, j];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (currentGeneration != numberOfGenerations + 1)
            {
                for (int i = 0; i < numberOfItems; i++)
                {
                    for (int j = 0; j < populationSize; j++)
                    {
                        newPopulation[i, j] = false;
                    }
                }
                currentChromosome = 0;

                //Elitism - copy of the best chromosome of the previous generation
                for (int i = 0; i < numberOfItems; i++)
                {
                    newPopulation[i, currentChromosome] = population[i, bestSolutionIndex];
                }
                currentChromosome++;
                probabilityCalculation();
                Random rnd = new Random();
                while (currentChromosome < populationSize)
                {
                    parentsSeletion();
                    int breed = rnd.Next(0, 100);
                    if (breed <= crossoverProbability)
                        crossover();
                    else
                    {
                        for (int i = 0; i < numberOfItems; i++)
                        {
                            newPopulation[i, currentChromosome] = population[i, parentIndex1];
                        }
                        currentChromosome++;
                        if (currentChromosome < populationSize)
                        {
                            for (int i = 0; i < numberOfItems; i++)
                            {
                                newPopulation[i, currentChromosome] = population[i, parentIndex2];
                            }
                            currentChromosome++;
                        }
                    }
                }
                mutation();
                for (int i = 0; i < numberOfItems; i++)
                {
                    for (int j = 0; j < populationSize; j++)
                    {
                        population[i, j] = newPopulation[i, j];
                    }
                }

                calculateFitness();
                currentGeneration++;
            }
            label17.Text = (currentGeneration - 1).ToString();
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = 0; j < populationSize; j++)
                {
                    if (!population[i, j])
                    { dataGridView1[i, j].Value = 0; }
                    else
                    { dataGridView1[i, j].Value = 1; }
                }
            }
            label15.Text = "Chromosome " + (bestSolutionIndex + 1) + ", value: " + bestSolutionValue + ", weight: " + bestSolutionWeight + ", " + bestSolutionQuantity + " items taken.";
            label14.Text = "Chromosome " + (bestFitnessIndex + 1) + ", value: " + bestFitnessValue + ", weight: " + bestFitnessWeight + ", " + bestFitnessQuantity + " items taken.";
            button2.Visible = !button2.Visible;
            button3.Visible = !button3.Visible;
            button4.Visible = !button4.Visible;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clearing of the variables
            capacity = 0;
            numberOfItems = 0;
        populationSize = 0;
        numberOfGenerations = 0;
        crossoverProbability = 0;
        mutationProbability = 0;
        currentGeneration = 0;
        currentChromosome = 0;
        bestFitnessIndex = 0;
        bestFitnessValue = 0;
        bestFitnessQuantity = 0;
        bestFitnessWeight = 0;
        bestSolutionIndex = 0;
        bestSolutionValue = 0;
        bestSolutionQuantity = 0;
        bestSolutionWeight = 0;
        parentIndex1 = 0;
        parentIndex2 = 0;
            for (int i = 0; i < numberOfItems; i++)
            {
        weights[i] = 0;
        values[i] = 0;
            }
            for (int i = 0; i < populationSize; i++)
            {
        fitness[i] = 0;
        sumOfWeights[i] = 0;
        quantityOfItems[i] = 0;
        selectionProbability[i] = 0;
        probabilityDiapason[i,0] = 0;
        probabilityDiapason[i, 1] = 0;
            }
           for (int i = 0; i < numberOfItems; i++)
           {
               for (int j = 0; j < populationSize; j++)
               {

       population[i,j] = false;
       newPopulation[i,j] = false;
    }
}
           maskedTextBox1.Clear();
           maskedTextBox2.Clear();
           maskedTextBox3.Clear();
           maskedTextBox4.Clear();
            //Switching the controls' visibility
            dataGridView1.Visible = !dataGridView1.Visible;
            dataGridView2.Visible = !dataGridView2.Visible;
            label1.Visible = !label1.Visible;
            label2.Visible = !label2.Visible;
            label3.Visible = !label3.Visible;
            label4.Visible = !label4.Visible;
            label5.Visible = !label5.Visible;
            label6.Visible = !label6.Visible;
            label7.Visible = !label7.Visible;
            label8.Visible = !label8.Visible;
            label9.Visible = !label9.Visible;
            label10.Visible = !label10.Visible;
            label11.Visible = !label11.Visible;
            label12.Visible = !label12.Visible;
            label13.Visible = !label13.Visible;
            label14.Visible = !label14.Visible;
            label15.Visible = !label15.Visible;
            label16.Visible = !label16.Visible;
            label17.Visible = !label17.Visible;
            label18.Visible = !label18.Visible;
            label19.Visible = !label18.Visible;
            comboBox1.Visible = !comboBox1.Visible;
            maskedTextBox1.Visible = !maskedTextBox1.Visible;
            maskedTextBox2.Visible = !maskedTextBox2.Visible;
            maskedTextBox3.Visible = !maskedTextBox3.Visible;
            maskedTextBox4.Visible = !maskedTextBox4.Visible;
            button1.Visible = !button1.Visible;
            button4.Visible = !button4.Visible;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "")
            {
                button1.Enabled = true;
            }
        }
    }
}
