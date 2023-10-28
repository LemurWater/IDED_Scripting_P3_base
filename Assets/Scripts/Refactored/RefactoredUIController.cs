using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefactoredUIController : UIControllerBase
{
    [SerializeField] private Text score;
    [SerializeField] private Text ammo;
    public static RefactoredUIController Instance {  get; private set; }

    RefactoredGameController rGameController;

    GameObject systemMessage;
    protected override GameControllerBase GameController => rGameController;



    float messageTimer = 0.0f;
    float messageTimerMax = 5.0f;
    bool showingTimer = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        rGameController = GameObject.FindAnyObjectByType<RefactoredGameController>();
        systemMessage = GameObject.Find("System Message");
        if(systemMessage != null )
        {
            systemMessage.SetActive(false);
        }
    }
    private void Update()
    {
        if (GameController != null)
        {
            if (shotsCountLabel != null)
            {
                shotsCountLabel.text = GameController.RemainingArrows.ToString();
            }

            if (scoreCountLabel != null)
            {
                scoreCountLabel.text = GameController.Score.ToString();
            }

            if (windLabel != null)
            {
                windLabel.text = string.Format("{0:0.00F}", GameController.WindSpeed);
            }

            if (GameController.RemainingArrows < 1)
            {
                gameOverGroup?.SetActive(true);
                enabled = false;
            }

            CheckMessageTimer();
        }
    }

    public void UpdateLabels(string newScore, string newAmmo)
    {
        score.text = newScore;
        ammo.text = newAmmo;
    }

    public void OnGameOver()
    {
        Debug.Log("El juego debe finalizar");
        if (systemMessage != null)
        {
            systemMessage.SetActive(true);
            systemMessage.GetComponent<Text>().text = "Game Ending ...";
            showingTimer = true;
        }
    }
    public void OnArrowShot()
    {
        Debug.Log("El jugador hizo un disparo");
        if(systemMessage != null)
        {
            systemMessage.SetActive(true);
            systemMessage.GetComponent<Text>().text = "Player Shoot!";
            showingTimer = true;
        }
    }

    void CheckMessageTimer()
    {
        if (showingTimer)
        {
            if (messageTimer >= messageTimerMax)
            {
                systemMessage.SetActive(false); 
                showingTimer = false;
                messageTimer = 0.0f;
            }
            else
            {
                messageTimer += Time.deltaTime;
            }
        }
    }
}
