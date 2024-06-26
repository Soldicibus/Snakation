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
    public int totalExamples;
    int stopwatchTime = 0;
    protected bool isExample;
    private SnakeController snakeBackup;
    private GameController controllerBackup;
    public GameController Controller
    {
        get { return controller; }
        private set { controller = value; }
    }

    public SnakeController Snake
    {
        get { return snake; }
        private set { snake = value; }
    }

    void Start()
    {
        isThirdBtnCorrect = false; isSecondBtnCorrect = false; isThirdBtnCorrect = false;
        Snake = snake;
        Controller = controller;

        CheckAndBackupReferences();
        firstBtn.onClick.AddListener(FirstBtnState);
        secondBtn.onClick.AddListener(SecondBtnState);
        thirdBtn.onClick.AddListener(ThirdBtnState);
    }
    void CheckAndBackupReferences()
    {
        if (Snake != null && Controller != null)
        {
            Debug.Log("Assigned both SnakeController and GameController");
            snakeBackup = Snake;
            controllerBackup = Controller;
        }
        else
        {
            if (Snake == null) Debug.LogError("SnakeController is not assigned!");
            if (Controller == null) Debug.LogError("GameController is not assigned!");
        }
        LogReferences("Starting value:");
    }
    void CheckAndReassignReferences()
    {
        if (snake == null) snake = snakeBackup;
        if (controller == null) controller = controllerBackup;
    }

    void LogReferences(string context)
    {
        Debug.Log($"{context} - snake: {(snake != null ? snake.name : "null")}, controller: {(controller != null ? controller.name : "null")}, snakeBackup: {(snakeBackup != null ? snakeBackup.name : "null")}, controllerBackup: {(controllerBackup != null ? controllerBackup.name : "null")}");
    }

    public void FirstLevel()
    {
        if(controller.resolvedExamples < 3)
        {
            AddFirstLVL();
        }
        else if(controller.resolvedExamples == 3)
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
        if (controller.resolvedExamples < 11)
        {
            DivAddTenthLevel();
        }
        else if (controller.resolvedExamples == 11)
        {
            DivMulTenthEX();
        }
    }

    public void EleventhLevel()
    {
        if (controller.resolvedExamples < 3)
        {
            MixedOperationsLevelEleventh();
        }
        else if (controller.resolvedExamples == 3)
        {
            MixedOperationsLevelEleventhEX();
        }
    }

    public void TwelfthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            MixedOperationsLevelTwelfth();
        }
        else if (controller.resolvedExamples == 9)
        {
            MixedOperationsLevelTwelfthEX();
        }
    }
    public void ThirteenthLevel()
    {
        if (controller.resolvedExamples < 9)
        {
            MulSubLevelThirteenth();
        }
        else if (controller.resolvedExamples == 9)
        {
            MulSubLevelThirteenthEX();
        }
    }
    public void SpecialLevel14()
    {
        if (controller.resolvedExamples < 3)
        {
            FinalLevelWithExponents();
        }
        else if (controller.resolvedExamples == 3)
        {
            FinalLevelWithExponentsEX();
        }
    }
    public void SpecialLevel15()
    {
        if (controller.resolvedExamples < 14)
        {
            FinalLevelWithExponents();
        }
        else if (controller.resolvedExamples == 14)
        {
            FinalLevelWithExponentsEX();
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

    void MixedOperationsLevelEleventh()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        int intermediateResult1 = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        int intermediateResult2 = Math.randomGeneration(1, 10);
        correctAnswer = (intermediateResult1 - intermediateResult2) * thirdNumber;
        do
        {
            errorOne = correctAnswer + 10 + Math.randomGeneration(1, 3);
            errorTwo = correctAnswer - 10 - Math.randomGeneration(1, 2);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"({firstNumber} / {secondNumber} - {intermediateResult2}) * {thirdNumber}");
    }

    void MixedOperationsLevelEleventhEX()
    {
        thirdNumber = 100;
        int intermediateResult1 = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        int intermediateResult2 = Math.randomGeneration(1, 10);
        correctAnswer = (intermediateResult1 - intermediateResult2) * thirdNumber;
        do
        {
            errorOne = correctAnswer + Math.randomGeneration(1, 3) - 10;
            errorTwo = correctAnswer - Math.randomGeneration(1, 2) + 10;
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"({firstNumber} / {secondNumber} - {intermediateResult2}) * {thirdNumber}");
    }

    void MixedOperationsLevelTwelfth()
    {
        thirdNumber = Math.randomGeneration(1, 10);
        int intermediateResult1 = Math.Div(2, 20, 2, 5, out firstNumber, out secondNumber);
        int intermediateResult2 = Math.randomGeneration(1, 10);
        correctAnswer = (intermediateResult1 - intermediateResult2) * thirdNumber;
        do
        {
            errorOne = correctAnswer + 10 + Math.randomGeneration(1, 3);
            errorTwo = correctAnswer - 10 - Math.randomGeneration(1, 2);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"({firstNumber} / {secondNumber} - {intermediateResult2}) * {thirdNumber}");
    }

    void MixedOperationsLevelTwelfthEX()
    {
        thirdNumber = 100;
        int intermediateResult1 = Math.Div(10, 100, 10, 20, out firstNumber, out secondNumber);
        int intermediateResult2 = Math.randomGeneration(1, 10);
        correctAnswer = (intermediateResult1 - intermediateResult2) * thirdNumber;
        do
        {
            errorOne = correctAnswer + Math.randomGeneration(1, 3) - 10;
            errorTwo = correctAnswer - Math.randomGeneration(1, 2) + 10;
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"({firstNumber} / {secondNumber} - {intermediateResult2}) * {thirdNumber}");
    }

    void MulSubLevelThirteenth()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        int intermediateResult1 = Math.Mul(2, 10);
        int intermediateResult2 = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        correctAnswer = intermediateResult1 - (intermediateResult2 + thirdNumber);
        do
        {
            errorOne = correctAnswer + Math.randomGeneration(1, 20);
            errorTwo = correctAnswer - Math.randomGeneration(1, 20);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{intermediateResult1} - ({firstNumber} / {secondNumber} + {thirdNumber})");
    }
    void MulSubLevelThirteenthEX()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        int intermediateResult1 = Math.Mul(2, 10);
        int intermediateResult2 = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        correctAnswer = intermediateResult1 - (intermediateResult2 + thirdNumber);
        do
        {
            errorOne = correctAnswer + Math.randomGeneration(1, 20);
            errorTwo = correctAnswer - Math.randomGeneration(1, 20);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{intermediateResult1} - ({firstNumber} / {secondNumber} + {thirdNumber})");
    }
    void FinalLevelWithExponents()
    {
        thirdNumber = Math.randomGeneration(1, 10);
        int baseNumber = Math.randomGeneration(2, 5);
        int exponent = Math.randomGeneration(2, 4);
        int intermediateResult1 = (int)Math.Pow(baseNumber, exponent);
        int intermediateResult2 = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        correctAnswer = intermediateResult1 + intermediateResult2 + thirdNumber;
        do
        {
            errorOne = correctAnswer + Math.randomGeneration(1, 20);
            errorTwo = correctAnswer - Math.randomGeneration(1, 20);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{baseNumber}^{exponent} + {firstNumber} / {secondNumber} + {thirdNumber}");
    }
    void FinalLevelWithExponentsEX()
    {
        thirdNumber = Math.randomGeneration(10, 100);
        int baseNumber = Math.randomGeneration(5, 12);
        int exponent = Math.randomGeneration(2, 3);
        int intermediateResult1 = (int)Math.Pow(baseNumber, exponent);
        int intermediateResult2 = Math.Div(2, 100, 2, 10, out firstNumber, out secondNumber);
        correctAnswer = intermediateResult1 + intermediateResult2 + thirdNumber;
        do
        {
            errorOne = correctAnswer + Math.randomGeneration(1, 20);
            errorTwo = correctAnswer - Math.randomGeneration(1, 20);
        } while (errorOne == correctAnswer || errorTwo == correctAnswer || errorTwo == errorOne);
        ButtonControl(correctAnswer, errorOne, errorTwo, $"{baseNumber}^{exponent} + {firstNumber} / {secondNumber} + {thirdNumber}");
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
                if (isFirstBtnCorrect != true) { isFirstBtnCorrect = true; }
                break;
            case 2:
                firstTMP.text = errorOne.ToString();
                secondTMP.text = correctAnswer.ToString();
                thirdTMP.text = errorTwo.ToString();
                isSecondBtnCorrect = true;
                if (isSecondBtnCorrect != true) { isSecondBtnCorrect = true; }
                break;
            case 3:
                firstTMP.text = errorOne.ToString();
                secondTMP.text = errorTwo.ToString();
                thirdTMP.text = correctAnswer.ToString();
                isThirdBtnCorrect = true;
                if (isThirdBtnCorrect != true) { isThirdBtnCorrect = true; }
                break;
        }
    }

    IEnumerator Stopwatch()
    {
        stopwatchTMP.text = "Time: 0 sec.";
        while (isExample)
        {
            yield return new WaitForSecondsRealtime(1);
            stopwatchTime++;
            stopwatchTMP.text = "Time: " + stopwatchTime + " sec.";
        }

        stopwatchTime = 0;
    }

    public void FirstBtnState()
    {
        Debug.Log("FirstBtnState called");
        //CheckAndReassignReferences();
        //LogReferences("Before FirstBtnState Logic");
        if (isFirstBtnCorrect)
        {
            CorrectAnswer();
            
        }
        else
        {
            WrongAnswer();
        }
        //LogReferences("After FirstBtnState Logic");
    }

    public void SecondBtnState()
    {
        Debug.Log("SecondBtnState called");
        //CheckAndReassignReferences();
        //LogReferences("Before SecondBtnState Logic");
        if (isSecondBtnCorrect)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
        //LogReferences("After SecondBtnState Logic");
    }

    public void ThirdBtnState() 
    {
        Debug.Log("ThirdBtnState called");
        //CheckAndReassignReferences();
        //LogReferences("Before ThirdBtnState Logic");
        if (isThirdBtnCorrect)
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
        //LogReferences("After ThirdBtnState Logic");
    }

    void CorrectAnswer()
    {
        Debug.Log("CorrectAnswer called");
        //LogReferences("Before CorrectAnswer Logic");
        controller.resolvedExamples++;
        if (controller.resolvedExamples < totalExamples / 2)
            controller.score += 300;
        else if (controller.resolvedExamples < totalExamples)
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

        StopCoroutine(Stopwatch());
        isExample = false;
        if (controller.resolvedExamples == totalExamples)
            snake.Victory();
        //LogReferences("After CorrectAnswer Logic");
    }

    void WrongAnswer()
    {
        Debug.Log("WrongAnswer called");
        LogReferences("Before WrongAnswer Logic");
        if (snake == null)
        {
            Debug.LogError("SnakeController is lost! Trying to recover...");
            snake = snakeBackup;
        }
        if (controller == null)
        {
            Debug.LogError("GameController is lost! Trying to recover...");
            controller = controllerBackup;
        }
        snake.SpawnFood();
        controller.score -= 200;
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        isExample = false;
        if (controller.resolvedExamples == totalExamples - 1)
        {
            snake.Restart();
        }
        LogReferences("After WrongAnswer Logic");
        canvas.gameObject.SetActive(false);
        StopCoroutine(Stopwatch());
    }
}