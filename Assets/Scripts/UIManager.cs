using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinsText;
    public Text goalsText;

    private PlayerLife playerLife;

    void Start()
    {

    }

    public void coinsChanged(int value)
    {
        coinsText.text = value.ToString();
    }

    public void goalsChanged(int value)
    {
        goalsText.text = value.ToString();
    }   
}
