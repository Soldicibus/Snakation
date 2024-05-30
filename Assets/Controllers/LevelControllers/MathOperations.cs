using TMPro;
using UnityEngine;

public class MathOperations : MonoBehaviour
{
    
    System.Random random = new System.Random();

    
    public int randomGeneration(int min, int max) => random.Next(min, max);

    public int Add(int min, int max) => randomGeneration(min, max) + randomGeneration(min, max);

    public int Add(int min, int max, out int firstNumber, out int secondNumber)
    {
        firstNumber = randomGeneration(min, max);
        secondNumber = randomGeneration(min, max);
        return firstNumber + secondNumber;
    }

    public int Add(int min1, int max1, int min2, int max2, out int firstNumber, out int secondNumber)
    {
        firstNumber = randomGeneration(min2, max2);
        secondNumber = randomGeneration(min1, max1);
        return firstNumber + secondNumber;
    }


    public int Sub(int min, int max)
    {
        int firstNumber = randomGeneration(min, max);
        int secondNumber = randomGeneration(min, max);
        if (firstNumber > secondNumber) 
            return firstNumber - secondNumber;
        else 
            return secondNumber - firstNumber;
    }

    public int Sub(int min, int max, out int firstNumber, out int secondNumber)
    {
        int a = randomGeneration(min, max);
        int b = randomGeneration(min, max);
        if(a > b)
        {
            firstNumber = a;
            secondNumber = b;
            return a - b;
        }
        else
        {
            firstNumber = b;
            secondNumber = a;
            return b - a;
        }
    }

    public int Sub(int min1, int max1, int min2, int max2, out int firstNumber, out int secondNumber)
    {
        firstNumber = randomGeneration(min1, max1);
        secondNumber = randomGeneration(min2, max2);

        return firstNumber - secondNumber;
    }


    public int Mul(int min, int max) => randomGeneration(min, max) * randomGeneration(min, max);

    public int Mul(int min, int max, out int firstNumber, out int secondNumber)
    {
        firstNumber = randomGeneration(min, max);
        secondNumber = randomGeneration(min, max);
        return firstNumber * secondNumber;
    }

    public int Div(int min1, int max1, int min2, int max2)
    {
        int a, b;
        do
        {
            a = randomGeneration(min1, max1);
            b = randomGeneration(min2, max2);
        } while (a % b != 0 || a < b);
        return a / b;
    }

    public int Div(int min1, int max1, int min2, int max2, out int firstNumber, out int secondNumber)
    {
        int a, b;
        do
        {
            a = randomGeneration(min1, max1);
            b = randomGeneration(min2, max2);
        } while (a % b != 0 || a < b || a / b > 9);
        firstNumber = a;
        secondNumber = b;
        return firstNumber / secondNumber;
    }

    public int Pow(int firstNumber, int secondNumber)
    {
        int a = firstNumber;
        for (int i = 0; i < secondNumber - 1; i++)
            a = a * firstNumber;
        return a;
    }
}