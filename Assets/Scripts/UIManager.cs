using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text coinsText;
    
    private PlayerLife playerLife;

    void Start()
    {

    }



    public void coinsChanged(int value)
    {
        coinsText.text = value.ToString();
    }
}
