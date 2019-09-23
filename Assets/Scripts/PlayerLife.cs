using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rigidbody;
    CircleCollider2D collider2D;

    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var tag = other.gameObject.tag;

        if (tag == "DestroyFloor")
        {
            destroy();    
        }
        else if (tag == "Destination")
        {
            reloadLevel();
        }
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }

    void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void levelSuccess()
    {   

        // Application.LoadLevel(Application.loadedLevel);
    }

}
