using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;

    public void UnlockDoor()
    {
        Debug.Log("Porta sbloccata!");
        //SceneManager.LoadScene("NomeProssimoLivello");
        // Variante A: attiva animazione
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        else
        {
            //gameObject.SetActive(false);
            gameObject.SetActive(true);

        }

        // Variante B: disattiva il collider/blocco
        // GetComponent<Collider>().enabled = false;
        // oppure gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Giocatore ha raggiunto la porta!");
            SceneManager.LoadScene("WinMenu"); // Carica la scena del menu di vittoria
            Time.timeScale = 0f; // Ferma il gioco

        }
    }
}

