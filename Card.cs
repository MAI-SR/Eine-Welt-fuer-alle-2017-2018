using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    public static bool DO_NOT = false;

    [SerializeField]
    private int state;
    [SerializeField]
    private int cardType;
    [SerializeField]
    private bool initialized = false;
    [SerializeField]
    private GameObject manager;

    private Sprite cardBack;
    private Sprite cardFront;

    public int cardValue
    {
        get { return cardType; }
        set { cardType = value; }
    }

    public int cardState
    {
        get { return state; }
        set { state = value; }
    }

    public bool cardInitialized
    {
        get { return initialized; }
        set { initialized = value; }
    }

    private void Start()
    {
        state = 0;
    }

    public void setupGraphics()
    {
        cardBack = manager.GetComponent<GameManager>().getCardBack();
        cardFront = manager.GetComponent<GameManager>().getCardFace(cardType);
        
        GetComponent<Image>().sprite = cardBack;
    }

    public void flip()
    {
        if (state == 1)
        {
            state = 0;
        } else
        {
            state = 1;
        }

        if (state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = cardBack;
        }
        else if (state == 1 && !DO_NOT)
        {
            GetComponent<Image>().sprite = cardFront;
        }
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {

        yield return new WaitForSeconds(1);
        if (state == 0)
        {
            GetComponent<Image>().sprite = cardBack;
        } else if (state == 1) {
            GetComponent<Image>().sprite = cardFront;
        }

        DO_NOT = false;
    }
}
