using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float lifetime = 3f;

    private void OnEnable()
    {
        Invoke("Die", lifetime);
    }

    void Die()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
          
            Debug.Log("Touch Enemy");
        }
       
        if (other.CompareTag("Kill"))
        {
                Destroy(other.gameObject);
                GameManager.Instance.UpdateKillCount();
        }
    }
}
