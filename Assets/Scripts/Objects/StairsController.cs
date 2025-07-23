using UnityEngine;
using UnityEngine.SceneManagement;

public class StairsController : MonoBehaviour
{
    public Animator stairsAnimator;

    public void UnlockStairs()
    {
        Debug.Log("Scale sbloccata!");
        //SceneManager.LoadScene("NomeProssimoLivello");
        // Variante A: attiva animazione
        if (stairsAnimator != null)
        {
            stairsAnimator.SetTrigger("Open");
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
            Debug.Log("Giocatore ha raggiunto la scala!");

        }
    }
}
