using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText; 
    private int score = 0; 


    void Start()
    {
    UpdateScoreDisplay();
    }

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points; 
        UpdateScoreDisplay(); 
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("¡No se ha asignado el campo 'scoreText' en el Inspector!");
        }
    }
}
