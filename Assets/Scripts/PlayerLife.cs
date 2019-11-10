using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    Rigidbody2D rigidbody;
    CircleCollider2D collider2D;
    BallController ballController;

    [SerializeField]
    List<string> destroyObjectTags;

    [SerializeField]
    List<string> destinationObjectTags;

    [SerializeField]
    float slowmotionTime;

    [SerializeField] GameObject slider;
    [SerializeField] List<string> dangerObjects;

    [SerializeField]
    Rect gameBounds;

    [SerializeField]
    bool dieOnTimeEnds;

    float currentTime;

    public int coins { get; private set; }

    public void addCoins(int value=1)
    {
        coins += value;
        uIManager.coinsChanged(coins);
    }

    public UIManager uIManager;

    void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<CircleCollider2D>();
        ballController = this.GetComponent<BallController>();
        slider.GetComponent<SliderController>().setInitValue(slowmotionTime);

        if (dieOnTimeEnds)
        {
            currentTime = slowmotionTime;
        }

        uIManager.coinsChanged(coins);
    }

    void Update()
    {
        if (dieOnTimeEnds)
        {
            if (ballController.slowmotionOn)
            {
                changeTimeLeft(-Time.deltaTime);
            }

            if ( currentTime <= 0)
            {
                destroy();
                reloadLevel();
            }
        }

        // if (!gameBounds.Contains(this.transform.position))
        // {
        //     reloadLevel();
        // }
    }

    void changeTimeLeft(float delta)
    {
        currentTime += delta;
        slider.GetComponent<SliderController>().setValue(currentTime);
        // timeSlider.value = currentTime;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var tag = other.gameObject.tag;

        if (dangerObjects.Contains(tag))
        {
            destroy();
            reloadLevel();
        }
        else if (tag == "Finish")
        {
            reloadLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Coin")
        {   
            Destroy(other.gameObject);
            addCoins();
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
