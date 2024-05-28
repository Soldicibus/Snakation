using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExampleController : MonoBehaviour
{
    int correctAnswer, errorOne, errorTwo, firstNumber, secondNumber, thirdNumber;
    public GameController controller;
    MathOperations Math = new MathOperations();
    public Button firstBtn, secondBtn, thirdBtn;

    public GameObject canvas;
    protected bool isFirstBtnCorrect, isSecondBtnCorrect, isThirdBtnCorrect;
    public TextMeshProUGUI firstTMP, secondTMP, thirdTMP, exTMP, stopwatchTMP;
    public SnakeController snake;
    int stopwatchTime = 0;
    protected bool isExample;

    void Start()
    {
        isThirdBtnCorrect = false; isSecondBtnCorrect = false; isThirdBtnCorrect = false;
    }

    public void FirstLevel()
    {
        if(controller.resolvedExamples < 9)
        {
            AddFirstLVL();
        }
        else if(controller.resolvedExamples == 9)
        {
            AddFirstFinalEX();
        }
    }


    public void SecondLevel()
    { 
        if(controller.resolvedExamples < 9)
        {
            SubSecondLVL();
        }
        else if(controller.resolvedExamples == 9)
        {
            SubSecondFinalEX();
        }
    }

    public void ThirdLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            AddThirdLVL();
        }
        else if (controller.resolvedExamples == 9)
        {
            AddThirdFinalEX();
        }
    }

    public void FourthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            SubFourthLVL();
        }
        else if (controller.resolvedExamples == 9)
        {
            SubFourthFinalEX();
        }
    }

    public void FifthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            AddSubFfithLevel();
        }
        else if (controller.resolvedExamples == 9)
        {
            AddSubFifthFinalEX();
        }
    }

    public void SixthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            SubAddSixthLevel();
        }
        else if (controller.resolvedExamples == 9)
        {
            SubAddSixthFinalEX();
        }
    }

    public void SeventhLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            MulSeventhLVL();
        }
        else if (controller.resolvedExamples == 9)
        {
            MulSeventhFinalEX();
        }
    }

    public void EihgthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            DivEighthLevel();
        }
        else if (controller.resolvedExamples == 9)
        {
            DivEighthFinalEX();
        }
    }

    public void NinthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            MulAddNinthLevel();
        }
        else if (controller.resolvedExamples == 9)
        {
            MulSubNinthEX();
        }
    }

    public void TenthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            DivAddTenthLevel();
        }
        else if (controller.resolvedExamples == 9)
        {
            DivMulTenthEX();
        }
    }
    void AddFirstLVL()
    {
        correctAnswer = Math.Add(1, 10, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Add(1, 10);
            errorTwo = Math.Add(1, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber}");
    }

    void AddFirstFinalEX()
    {
        correctAnswer = Math.Add(1, 10, 10, 100, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Add(10, 100);
            errorTwo = Math.Add(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber}");
    }



    void SubSecondLVL()
    {
        correctAnswer = Math.Sub(1, 10, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Sub(1, 10);
            errorTwo = Math.Sub(1, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} - {secondNumber}");
    }

    

    void SubSecondFinalEX()
    {
        correctAnswer = Math.Sub(10, 100, 1, 10, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Sub(10, 100);
            errorTwo = Math.Sub(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} - {secondNumber}");
    }

    void AddThirdLVL()
    {
        correctAnswer = Math.Add(10, 100, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Add(10, 100);
            errorTwo = Math.Add(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber}");
    }

    void AddThirdFinalEX()
    {
        correctAnswer = Math.Add(100, 1000, 10, 100, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Add(110, 1000);
            errorTwo = Math.Add(110, 1000);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber}");
    }

    void SubFourthLVL()
    {
        correctAnswer = Math.Sub(10, 100, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Sub(10, 100);
            errorTwo = Math.Sub(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} - {secondNumber}");
    }



    void SubFourthFinalEX()
    {
        correctAnswer = Math.Sub(100, 1000, 10, 100, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Sub(100, 950);
            errorTwo = Math.Sub(100, 950);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} - {secondNumber}");
    }


    void AddSubFfithLevel()
    {
        thirdNumber = Math.randomGeneration(1, 10);
        correctAnswer = Math.Add(10, 100, out firstNumber, out secondNumber) - thirdNumber;
        do
        {
            errorOne = Math.randomGeneration(10, 198);
            errorTwo = Math.randomGeneration(10, 198);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber} - {thirdNumber}");
    }

    void AddSubFifthFinalEX()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        correctAnswer = Math.Add(10, 100, out firstNumber, out secondNumber) - thirdNumber;
        do
        {
            errorOne = Math.randomGeneration(10, 198);
            errorTwo = Math.randomGeneration(10, 198);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber} - {thirdNumber}");
    }

    void SubAddSixthLevel()
    {
        thirdNumber = Math.randomGeneration(1, 10);
        correctAnswer = Math.Sub(10, 100, out firstNumber, out secondNumber) + thirdNumber;
        do
        {
            errorOne = Math.randomGeneration(10, 198);
            errorTwo = Math.randomGeneration(10, 198);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} - {secondNumber} + {thirdNumber}");
    }

    void SubAddSixthFinalEX()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        correctAnswer = Math.Sub(10, 100, out firstNumber, out secondNumber) + thirdNumber;
        do
        {
            errorOne = Math.randomGeneration(10, 198);
            errorTwo = Math.randomGeneration(10, 198);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} - {secondNumber} + {thirdNumber}");
    }


    void MulSeventhLVL()
    {
        correctAnswer = Math.Mul(1, 10, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Mul(1, 10);
            errorTwo = Math.Mul(1, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} * {secondNumber}");
    }

    void MulSeventhFinalEX()
    {
        firstNumber = Math.randomGeneration(1, 10);
        correctAnswer = firstNumber + Math.Mul(1, 10, out secondNumber, out thirdNumber);
        do
        {
            errorOne = Math.Mul(1, 10);
            errorTwo = Math.Mul(1, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} + {secondNumber} * {thirdNumber}");
    }

    void DivEighthLevel()
    {
        correctAnswer = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        do
        {
            errorOne = Math.Div(2, 100, 2, 10);
            errorTwo = Math.Div(2, 100, 2, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} / {secondNumber}");
    }

    void DivEighthFinalEX()
    {
        thirdNumber = Math.randomGeneration(1, 10);
        correctAnswer = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber) + thirdNumber; 
        do
        {
            errorOne = Math.Div(2, 100, 2, 10);
            errorTwo = Math.Div(2, 100, 2, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);

        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} / {secondNumber} + {thirdNumber}");
    }

    void MulAddNinthLevel()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        correctAnswer = Math.Mul(1, 10, out firstNumber, out secondNumber) + thirdNumber;

        do
        {
            errorOne = Math.randomGeneration(10, 100);
            errorTwo = Math.randomGeneration(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);

        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} * {secondNumber} + {thirdNumber}"); 
    }

    void MulSubNinthEX()
    {
        int tempMul;
        do
        {
            thirdNumber = Math.randomGeneration(10, 70);
            tempMul = Math.Mul(6, 10, out firstNumber, out secondNumber);
        } while (tempMul < thirdNumber);

        do
        {
            errorOne = Math.randomGeneration(10, 100);
            errorTwo = Math.randomGeneration(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);

        correctAnswer = tempMul - thirdNumber;
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} * {secondNumber} - {thirdNumber}");
    }

    void DivAddTenthLevel()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        correctAnswer = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber) + thirdNumber;
        do
        {
            errorOne = Math.randomGeneration(10, 100);
            errorTwo = Math.randomGeneration(10, 100);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} / {secondNumber} + {thirdNumber}");
    }
    
    void DivMulTenthEX()
    {
        thirdNumber = Math.randomGeneration(1, 10);
        correctAnswer = Math.Div(1, 100, 2, 10, out firstNumber, out secondNumber) * thirdNumber;
        do
        {
            errorOne = Math.Mul(1, 10);
            errorTwo = Math.Mul(1, 10);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{firstNumber} / {secondNumber} * {thirdNumber}");
    }


    void ButtonControl(int correctAnswer, int errorOne, int errorTwo, string text)
    {
        firstTMP.text = correctAnswer.ToString();
        secondTMP.text = errorOne.ToString();
        thirdTMP.text = errorTwo.ToString();
        exTMP.text = text;

        isExample = true;
        StartCoroutine(Stopwatch());
        


        int correctPos = Math.randomGeneration(1, 4);
        switch (correctPos)
        {
            case 1:
                firstTMP.text = correctAnswer.ToString();
                secondTMP.text = errorOne.ToString();
                thirdTMP.text = errorTwo.ToString();
                isFirstBtnCorrect = true;
                break;
            case 2:
                firstTMP.text = errorOne.ToString();
                secondTMP.text = correctAnswer.ToString();
                thirdTMP.text = errorTwo.ToString();
                isSecondBtnCorrect = true;
                break;
            case 3:
                firstTMP.text = errorOne.ToString();
                secondTMP.text = errorTwo.ToString();
                thirdTMP.text = correctAnswer.ToString();
                isThirdBtnCorrect = true;
                break;
        }
    }

    IEnumerator Stopwatch()
    {
        stopwatchTMP.text = "Пройшло часу: 0 с";
        while (isExample)
        {
            yield return new WaitForSecondsRealtime(1);
            stopwatchTime++;
            stopwatchTMP.text = "Пройшло часу: " + stopwatchTime + " с";
        }

        stopwatchTime = 0;
        
        
    }

    public void FirstBtnState()
    {

        if (isFirstBtnCorrect)
        {
            CorrectAnswer();
            
        }
        else
        {
            WrongAnswer();
        }
    }

    public void SecondBtnState()
    {
        if (isSecondBtnCorrect)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }

    public void ThirdBtnState() 
    {
        if (isThirdBtnCorrect)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }

    void CorrectAnswer()
    {

        controller.resolvedExamples++;
        if (controller.resolvedExamples < 5)
            controller.score += 300;
        else if (controller.resolvedExamples < 10)
            controller.score += 600;


        snake.isFoodEaten = true;
        snake.Movement();
        snake.isFoodEaten = true;

        snake.SpawnFood();

        StopCoroutine(Stopwatch());
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;



        if (stopwatchTime <= 2)
        {
            controller.score += 80;
        }
        else
        {
            switch(stopwatchTime)
            {
                case 3:
                    controller.score += 70;
                    break;
                case 4:
                    controller.score += 60;
                    break;
                case 5:
                    controller.score += 50;
                    break;
            }
        }

        isExample = false;
        StopCoroutine(Stopwatch());
        if (controller.resolvedExamples == 10)
            snake.Victory();
    }

    void WrongAnswer()
    {
        snake.SpawnFood();
        controller.score -= 200;
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        isExample = false;
        StopCoroutine(Stopwatch());
        if (controller.resolvedExamples == 9)
        {
            snake.GetComponent<SnakeController>().Restart();
        }
            
    }
}