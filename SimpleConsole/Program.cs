// See https://aka.ms/new-console-template for more information

// create a method to calculate standard deviation. This method will be used in the next step

using System;
using System.Collections.Generic;
using System.Linq;

double StandardDeviation(IEnumerable<double> values)
{
    double ret = 0;
    if (!values.Any()) return ret;
    //Compute the Average
    double avg = values.Average();
    //Perform the Sum of (value-avg)_2_2
    double sum = values.Sum(d => Math.Pow(d - avg, 2));
    //Put it all together
    ret = Math.Sqrt((sum) / (values.Count() - 1));
    return ret;
}

bool TryParseInput(in string[] input, out double[] values, out List<(int, string)> invalidInput)
{
    values = new double[input.Length];
    invalidInput = new List<(int, string)>();
    
    bool success = true;
    values = new double[input.Length];
    for (int i = 0; i < input.Length; i++)
    {
        if (!double.TryParse(input[i], out values[i]))
        {
            invalidInput.Add((i, input[i]));
            success = false;
        }
    }
    return success;
}

string? input;
do
{
    Console.WriteLine("Enter a sequence of numbers separated by space, then press Enter. To quit, press Enter without entering anything.");
    input = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("No input");
        continue;
    }
    string[] numbers = input.Split(' ');
    double[] numbersAsDouble;
    List<(int, string)> invalidInput;
    if (!TryParseInput(numbers, out numbersAsDouble, out invalidInput))
    {
        // wow - Co-Pilot figured out the right string format for invalid input from a tuple. :O
        Console.Error.WriteLine( $"Invalid input: {string.Join(", ", invalidInput.Select(x => $"\"{x.Item2}\" at position {x.Item1}"))}");
    }
    else
    {
        Console.WriteLine($"Standard deviation: {StandardDeviation(numbersAsDouble)}");
    }
    
} while (!string.IsNullOrWhiteSpace(input));
