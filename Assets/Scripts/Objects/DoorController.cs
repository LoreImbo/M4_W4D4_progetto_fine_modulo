using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;

    public void Unlock()
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
}

