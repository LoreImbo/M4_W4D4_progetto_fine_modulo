using UnityEngine;

public class StairsController : MonoBehaviour
{
    public void UnlockStairs()
    {
        Debug.Log("Scale sbloccata!");
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Il giocatore {other.name} ha raggiunto la scala!");
        }
    }
}
