using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int score;

    private void OnEnable()
    {
        Collectible.OnCollected += UpdateScore;
    }
    
    private void OnDisable()
    {
        Collectible.OnCollected -= UpdateScore;
    }
    
    private void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
