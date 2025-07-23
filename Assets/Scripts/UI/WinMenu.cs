using UnityEngine.SceneManagement;
using UnityEngine;

public class WinMenu : MonoBehaviour
{
    public void GoToNextLevel()
    {
        Time.timeScale = 1f; // Assicura che il gioco riprenda con il tempo normale
        Debug.Log("Livello completato! Proseguendo al prossimo livello...");
        //SceneManager.LoadScene("NextLevel"); // Sostituisci con il nome esatto della tua scena successiva
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Sostituisci con il nome esatto della tua scena principale
    }
}
