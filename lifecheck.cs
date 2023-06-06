using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCheck : MonoBehaviour
{
    [SerializeField] AudioSource deadSound;
    bool dead = false;
    // Start is called before the first frame update
    private void Update()
    {
        if (transform.position.y < -1f && !dead)
            Die();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }
    void Die()
    {
        
        Invoke(nameof(RestartLev), 1.3f);//this statement is used to delay the start of the current level.
        dead = true;
        deadSound.Play();
    }
    void RestartLev()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
