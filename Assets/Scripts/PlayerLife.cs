using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    BallController ballController;

    [SerializeField] List<string> destroyObjectTags;

    [SerializeField] List<string> destinationObjectTags;

    [SerializeField]
    float slowmotionTime;

    [SerializeField] GameObject slider;
    [SerializeField] List<string> dangerObjects;

    [SerializeField] bool dieOnTimeEnds;

    [SerializeField] float onGoalTakeBoost;

    float currentTime;

    public int coins { get; private set; }
    public int goals { get; private set; }

    // public void addCoins(int value=1)
    // {
    //     coins += value;
    //     uIManager.coinsChanged(coins);
    // }

    public UIManager uIManager;

    void Awake()
    {
        ballController = this.GetComponent<BallController>();
        slider.GetComponent<SliderController>().setInitValue(slowmotionTime);

        if (dieOnTimeEnds)
        {
            currentTime = slowmotionTime;
        }

        // uIManager.coinsChanged(coins);
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
    }

    void changeTimeLeft(float delta)
    {
        currentTime += delta;
        slider.GetComponent<SliderController>().setValue(currentTime);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var tag = other.gameObject.tag;

        if (dangerObjects.Contains(tag))
        {
            destroy();
            reloadLevel();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Coin")
        {   
            Destroy(other.gameObject);
            
            // addCoins();
        }
        else if (tag == "Finish")
        {
            Destroy(other.gameObject);
            currentTime += onGoalTakeBoost;
            slider.GetComponent<SliderController>().setValue(currentTime);
            
            goals++;

            uIManager.goalsChanged(goals);
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
}
