using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Sprite[] cardFaces;
    public Sprite cardBack;
    public GameObject[] cards;

    private bool init = false;
    private int matches = 6;

    private void Start()
    {
        initCards();
    }

    public void Interaction()
    {
        checkCards();
    }

    void initCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 6; i++)
            {
                bool test = false;
                int choice = 0;
                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().cardInitialized);
                }
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().cardInitialized = true;
            }
        }

        foreach (GameObject item in cards)
        {
            item.GetComponent<Card>().setupGraphics();
        }

        if (!init)
            init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int cardType)
    {
        return cardFaces[cardType];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().cardState == 1)
            {
                c.Add(i);
            }
        }

        if (c.Count == 2)
            cardCompare(c);
    }

    void cardCompare(List<int> c)
    {
        Card.DO_NOT = true;
        int x = 0;

        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            matches--;
            
            if (matches == 0)
            {
                Application.LoadLevel("Memory");
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().cardState = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }
}
