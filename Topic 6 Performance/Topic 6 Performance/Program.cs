using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

//Topic 6 week 10

// loop from 0 to this number looking for the value with the most divisors
int upperLimit = 1_000_000;

// create a list to hold all our objects
var data = new List<TaskData>();

// fill our list with objects with their input values set
for (int i = 0; i < upperLimit; i++) data.Add(new TaskData { input = i });

// start a timer so we can check the speed of calculating divisors
var timer = Stopwatch.StartNew();

/////////////////////////////////////////////////////////////////////////
// TODO: this is the main calculation which runs on multiple processors //
//  Parallel.ForEach vs AsParallel.ForAll                               //

Parallel.ForEach(data, td =>                                          //
{                                                                     //
    td.CountDivisors();                                               //
});                      //Parallel Foreach is faster by itself 3325 ms //
                                                                        // 
data.AsParallel().ForAll(td => td.CountDivisors());                     // AsParallel is a little bit slower by itself.
                                                                        //
//when ran together its slower
                                                                       //
/////////////////////////////////////////////////////////////////////////


// stop the timer after the section we are trying to speed up
timer.Stop();

// Find the maximium divisor calculated
int maximumDivisors = data.Max(td => td.numberOfDivisors);

// Use that maximum divisor to find the corresponding object
TaskData maximumObject = data.First(td => td.numberOfDivisors == maximumDivisors);

// Output the input value and the number of divisors it has
Console.WriteLine("From 0 to " + upperLimit + " the number with the most divisors is:");
Console.WriteLine(maximumObject.input + " which has " + maximumObject.numberOfDivisors + " divisors");
Console.WriteLine("Calculated in " + timer.ElapsedMilliseconds + "ms");

// this is the class we will use to store our data for each value
class TaskData
{
    public int input;
    public int numberOfDivisors;

    // this function is the one that we run for each number
    public void CountDivisors()
    {
        numberOfDivisors = 0;
        for (int i = 1; i <= Math.Sqrt(input); i++)
        {
            if (input % i == 0)
            {
                numberOfDivisors += 2;
            }
        }
    }
}
