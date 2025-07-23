using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // per ricaricare la scena o passare a "Game Over"

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 60f; // in secondi
    private float currentTime;

    public TextMeshProUGUI timerText; // UI Text da assegnare nel Canvas

    public LifeController playerHealth; // riferimento per farlo morire

    //public GameObject gameOverPanel; // riferimento al pannello Game Over da assegnare nel Canvas

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        // Aggiorna UI
        if (timerText != null)
        {
            timerText.text = "Timer: " + Mathf.Ceil(currentTime).ToString();
        }

        // Controlla se è finito il tempo
        if (currentTime <= 0f)
        {
            TimeUp();
        }
    }

    void TimeUp()
    {
        Debug.Log("Tempo scaduto!");

        // Metodo 1: far morire il player
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(playerHealth.GetMaxHp()); // Imposta HP a 0
            Time.timeScale = 0f; // Ferma il gioco
        }
        
        //Time.timeScale = 0f;
        //gameOverPanel.SetActive(true);

        // Metodo 2 (alternativa): caricare scena Game Over
        //SceneManager.LoadScene("GameOver");
    }
}
