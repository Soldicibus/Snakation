using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class SnakeController : MonoBehaviour
{
    private Vector2 tapPos, swipeDelta;
    public bool IsSwiping, IsSpedUp, IsCreatedVase;
    [SerializeField]
    private GameObject foodPref, vasePref, secondfoodPref, bodyPrefab, examplePrefab, finalExamplePrefab, scoreCanvas, deathCanvas, victoryCanvas, resultCanvas;
    [SerializeField]
    private TextMeshProUGUI finalScore, finalExamplesScore, losingReason;
    private GameObject food, vase;
    private float stepRate, currentAngleZ;
    private Vector2 move;
    List<Transform> body = new List<Transform>();
    [HideInInspector]
    public bool isFoodEaten, canTurn;
    private float turnTime;
    private Vector2 lBoarderPos, rBoarderPos, uBoarderPos, dBoarderPos;
    public GameController controller;
    public ExampleController example;
    public Sprite spriteOnRotation, spriteBody, spriteBodyTail, spriteBreakVase;
    [HideInInspector]
    public Scene scene;
    public int totalExamples;
    private int randomval;
    public AudioClip foodEatenSound;
    public AudioClip vaseDestroyedSound, snakeCrashSound;
    private AudioSource audioSource;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        turnTime = Time.time;
        currentAngleZ = 0.0f;
        stepRate = 0.2f;
        isFoodEaten = false;
        IsSpedUp = false;
        IsCreatedVase = false;
        lBoarderPos = GameObject.Find("WallLEFT").transform.position;
        rBoarderPos = GameObject.Find("WallRIGHT").transform.position;
        uBoarderPos = GameObject.Find("WallUP").transform.position;
        dBoarderPos = GameObject.Find("WallDOWN").transform.position;
        InvokeRepeating("Movement", 0.1f, stepRate);
        StartCoroutine(LevelText());
        SpawnFood();
    }


    void Update()
    {
        SnakeBehaviour(currentAngleZ);
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
        {
            move = Vector2.up;
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                IsSwiping = true;
                tapPos = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ResetSwipe();
            }
            SwipeDetection();
        }
    }

    protected bool isXpositive;
    protected bool isYpositive;
    protected bool isAxisX;
    void SwipeDetection()
    {
        swipeDelta = Vector2.zero;
        if (IsSwiping && canTurn)
        {
            if (Input.touchCount > 0)
            {
                swipeDelta = (Vector2)Input.GetTouch(0).position - tapPos;
            }
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if (swipeDelta.x > 0)
                {
                    if (currentAngleZ != 90f)
                    {
                        currentAngleZ = 270f;
                        isXpositive = true;
                        isAxisX = true;
                    }

                }
                if (swipeDelta.x < 0)
                {
                    if (currentAngleZ != 270f)
                    {
                        currentAngleZ = 90f;
                        isXpositive = false;
                        isAxisX = true;
                    }

                }

            }
            else
            {
                if (swipeDelta.y > 0)
                {
                    if (currentAngleZ != 180f)
                    {
                        currentAngleZ = 0f;
                        isYpositive = true;
                        isAxisX = false;
                    }
                }
                if (swipeDelta.y < 0)
                {
                    if (currentAngleZ != 0f)
                    {
                        currentAngleZ = 180f;
                        isYpositive = false;
                        isAxisX = false;
                    }

                }
            }
        }
    }
    void ResetSwipe()
    {
        IsSwiping = false;
        tapPos = Vector2.zero;
        swipeDelta = Vector2.zero;
    }

    void SnakeBehaviour(float prevAngleZ)
    {
        SwipeDetection();
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, currentAngleZ);
        if (Time.time > turnTime + 0.2f)
        {
            canTurn = true;
        }
        if (prevAngleZ != currentAngleZ)
        {
            turnTime = Time.time;
            canTurn = false;
        }
    }

    public void SpawnFood()
    {
        float x = (int)Random.Range(lBoarderPos.x + 2f, rBoarderPos.x - 2f);
        float y = (int)Random.Range(dBoarderPos.y + 2f, uBoarderPos.y - 2f);

        if (controller.resolvedExamples < totalExamples - 1)
        {
            int foodType = Random.Range(1, 4);
            if (foodType == 1)
            {
                food = Instantiate(foodPref, new Vector3(x, y, 5f), Quaternion.identity);
            }
            if (foodType == 2)
            {
                food = Instantiate(secondfoodPref, new Vector3(x, y, 5f), Quaternion.identity);
            }
            if (foodType == 3)
            {
                food = Instantiate(examplePrefab, new Vector3(x, y, 5f), Quaternion.identity);
            }
        }
        else if (controller.resolvedExamples == totalExamples - 1)
        {
            food = Instantiate(finalExamplePrefab, new Vector3(x, y, 5f), Quaternion.identity);
        }

    }

    public void Movement()
    {
        Vector2 v = transform.position;
        if (IsSpedUp == false && IsCreatedVase == false) randomval = (int)Random.Range(1, 36);
        else randomval = 0;
        if (randomval == 10)
        {
            float x = (int)Random.Range(lBoarderPos.x + 2f, rBoarderPos.x - 2f);
            float y = (int)Random.Range(dBoarderPos.y + 2f, uBoarderPos.y - 2f);
            vase = Instantiate(vasePref, new Vector3(x, y, 5f), Quaternion.identity);
            IsCreatedVase = true;
        }
        if (IsSpedUp && scene.name.Equals("LevelFifteen")) transform.Translate(move * 2f);
        else if (IsSpedUp) transform.Translate(move * 1.5f);
        else if (scene.name.Equals("LevelFifteen")) transform.Translate(move * 1.25f);
        else transform.Translate(move);
        if (isFoodEaten)
        {
            GameObject g = Instantiate(bodyPrefab, v, Quaternion.identity);
            g.GetComponent<Renderer>().material.color = this.GetComponent<Renderer>().material.color;
            g.transform.localEulerAngles = new Vector3(0.0f, 0.0f, currentAngleZ);
            body.Insert(0, g.transform);
            isFoodEaten = false;
        }
        else if (body.Count > 0)
        {
            body.Last().position = v;
            body.Last().transform.eulerAngles = new Vector3(0.0f, 0.0f, currentAngleZ);
            body.Insert(0, body.Last());
            body.RemoveAt(body.Count - 1);

            if (body.Count > 1)
            {
                for (int i = 0; i < body.Count - 1; i++)
                {
                    body[i].GetComponent<SpriteRenderer>().sprite = spriteBody;
                    body[i].GetComponent<SpriteRenderer>().flipX = false;
                }

                body.Last().GetComponent<SpriteRenderer>().sprite = spriteBodyTail;
                body.Last().GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                body.Last().GetComponent<SpriteRenderer>().sprite = spriteBody;
                body.Last().GetComponent<SpriteRenderer>().flipX = false;
            }
            for (int i = 0; i < body.Count - 1; i++)
            {
                if (body[i].transform.eulerAngles.z != body[i + 1].transform.eulerAngles.z)
                    body[i].GetComponent<SpriteRenderer>().sprite = spriteOnRotation;

                if ((isAxisX && isXpositive && isYpositive) || (!isAxisX && !isXpositive && isYpositive) || (!isAxisX && isXpositive && !isYpositive) || (isAxisX && !isXpositive && !isYpositive))
                    body[i].GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    public IEnumerator SpeedUp()
    {
        int stopwatchTime = 10;
        controller.speedTMP.text = "Speed: " + stopwatchTime + " sec.";
        while (stopwatchTime > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            stopwatchTime--;
            controller.speedTMP.text = "Speed: " + stopwatchTime + " sec.";
        }

        controller.speedTMP.text = "";

        IsSpedUp = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Apple" || col.gameObject.tag == "Pear")
        {
            if (audioSource == null) { audioSource = gameObject.AddComponent<AudioSource>(); audioSource.playOnAwake = false; }
            controller.score += 100;
            Destroy(col.gameObject);
            isFoodEaten = true;
            SpawnFood();
            audioSource.PlayOneShot(foodEatenSound);
        }

        if (col.gameObject.tag == "Vase")
        {
            if (audioSource == null) { audioSource = gameObject.AddComponent<AudioSource>(); audioSource.playOnAwake = false; }
            controller.score += 10;
            Destroy(col.gameObject);
            IsCreatedVase = false;
            IsSpedUp = true;
            StartCoroutine(SpeedUp());
            audioSource.PlayOneShot(vaseDestroyedSound);
        }

        if (col.gameObject.tag == "Example")
        {

            Destroy(col.gameObject);
            Time.timeScale = 0;
            if (scene.name.Equals("LevelOne"))
            {
                example.canvas.gameObject.SetActive(true);
                example.FirstLevel();
            }

            if (scene.name.Equals("LevelTwo"))
            {
                example.canvas.gameObject.SetActive(true);
                example.SecondLevel();
            }

            if (scene.name.Equals("LevelThree"))
            {
                example.canvas.gameObject.SetActive(true);
                example.ThirdLevel();
            }

            if (scene.name.Equals("LevelFour"))
            {
                example.canvas.gameObject.SetActive(true);
                example.FourthLevel();
            }

            if (scene.name.Equals("LevelFive"))
            {
                example.canvas.gameObject.SetActive(true);
                example.FifthLevel();
            }

            if (scene.name.Equals("LevelSix"))
            {
                example.canvas.gameObject.SetActive(true);
                example.SixthLevel();
            }

            if (scene.name.Equals("LevelSeven"))
            {
                example.canvas.gameObject.SetActive(true);
                example.SeventhLevel();
            }

            if (scene.name.Equals("LevelEight"))
            {
                example.canvas.gameObject.SetActive(true);
                example.EihgthLevel();
            }

            if (scene.name.Equals("LevelNine"))
            {
                example.canvas.gameObject.SetActive(true);
                example.NinthLevel();
            }

            if (scene.name.Equals("LevelTen"))
            {
                example.canvas.gameObject.SetActive(true);
                example.TenthLevel();
            }
            if (scene.name.Equals("LevelEleven"))
            {
                example.canvas.gameObject.SetActive(true);
                example.EleventhLevel();
            }
            if (scene.name.Equals("LevelTwelve"))
            {
                example.canvas.gameObject.SetActive(true);
                example.TwelfthLevel();
            }
            if (scene.name.Equals("LevelThirteen"))
            {
                example.canvas.gameObject.SetActive(true);
                example.ThirteenthLevel();
            }
            if (scene.name.Equals("LevelFourteen"))
            {
                example.canvas.gameObject.SetActive(true);
                example.SpecialLevel14();
            }
            if (scene.name.Equals("LevelFifteen"))
            {
                example.canvas.gameObject.SetActive(true);
                example.SpecialLevel15();
            }
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            turnTime = Time.time;
            canTurn = false;
        }


        if (col.gameObject.CompareTag("Tail"))
        {
            audioSource.PlayOneShot(snakeCrashSound);
            Restart();
        }

        if (col.gameObject.name == "WallRIGHT" && currentAngleZ == 270.0f)
        {
            transform.position = new Vector2(lBoarderPos.x, transform.position.y);
        }
        else if (col.gameObject.name == "WallLEFT" && currentAngleZ == 90.0f)
        {
            transform.position = new Vector2(rBoarderPos.x, transform.position.y);
        }
        else if (col.gameObject.name == "WallUP" && currentAngleZ == 0.0f)
        {
            transform.position = new Vector2(transform.position.x, dBoarderPos.y);
        }
        else if (col.gameObject.name == "WallDOWN" && currentAngleZ == 180.0f)
        {
            transform.position = new Vector2(transform.position.x, uBoarderPos.y);
        }


    }

    IEnumerator LevelText()
    {
        if (scene.name.Equals("LevelOne"))
        {
            controller.gameOverTMP.text = "First Level (Tutorial)";
        }
        else if (scene.name.Equals("LevelTwo"))
        {
            controller.gameOverTMP.text = "Second Level";
        }
        else if (scene.name.Equals("LevelThree"))
        {
            controller.gameOverTMP.text = "Third Level";
        }
        else if (scene.name.Equals("LevelFour"))
        {
            controller.gameOverTMP.text = "Fourth Level";
        }
        else if (scene.name.Equals("LevelFive"))
        {
            controller.gameOverTMP.text = "Fifth Level";
        }
        else if (scene.name.Equals("LevelSix"))
        {
            controller.gameOverTMP.text = "Sixth Level";
        }
        else if (scene.name.Equals("LevelSeven"))
        {
            controller.gameOverTMP.text = "Seventh Level";
        }
        else if (scene.name.Equals("LevelEight"))
        {
            controller.gameOverTMP.text = "Eigth Level";
        }
        else if (scene.name.Equals("LevelNine"))
        {
            controller.gameOverTMP.text = "Ninth Level";
        }
        else if (scene.name.Equals("LevelTen"))
        {
            controller.gameOverTMP.text = "Tenth level";
        }
        else if (scene.name.Equals("LevelEleven"))
        {
            controller.gameOverTMP.text = "Eleventh level (new area)";
        }
        else if (scene.name.Equals("LevelTwelve"))
        {
            controller.gameOverTMP.text = "Twelfth level";
        }
        else if (scene.name.Equals("LevelThirteen"))
        {
            controller.gameOverTMP.text = "Thirteenth level";
        }
        else
        {
            controller.gameOverTMP.text = "Special Levels";
        }

        yield return new WaitForSeconds(3);
        controller.gameOverTMP.text = "";
    }
    public void Restart()
    {
        scoreCanvas.SetActive(false);
        resultCanvas.SetActive(true);
        deathCanvas.SetActive(true);
        finalScore.text = $"Your result: {controller.score}";
        finalExamplesScore.text = $"Correctly answered: {controller.resolvedExamples}";
        if (controller.resolvedExamples == totalExamples - 1)
            losingReason.text = "You didn't answear the final example correctly";
        else
            losingReason.text = "You ate yourself";
        Time.timeScale = 0;
    }
    public void Victory()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("unlockedLVLs") && currentLevel != 15)
        {
            PlayerPrefs.SetInt("unlockedLVLs", currentLevel + 1);
        }

        Debug.Log("Level " + currentLevel++ + " unlocked");
        victoryCanvas.SetActive(true);
        resultCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        finalScore.text = $"Your result: {controller.score}";
        finalExamplesScore.text = $"Correctly answered: {controller.resolvedExamples}";

        Time.timeScale = 0;
    }
}
