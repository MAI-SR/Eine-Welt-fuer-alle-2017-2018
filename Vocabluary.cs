using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Vocabluary : MonoBehaviour
{
    public Image picture;
    public Button[] buttons;
    public Sprite[] vocabPictures;

    private string[] vocabs;
    private int rightButton;
	
	void Start ()
    {
        vocabs = new string[vocabPictures.Length];

		for (int i = 0; i < vocabPictures.Length; i++)
        {
            vocabs[i] = vocabPictures[i].name;
        }
        GenerateVocabs();
    }

    public void TestAnswer(int i)
    {
        if (i == rightButton)
        {
            buttons[rightButton].GetComponent<Image>().color = Color.green;
            StartCoroutine(Waite());
        }
        else
        {
            buttons[i].GetComponent<Image>().color = Color.red;
            buttons[rightButton].GetComponent<Image>().color = Color.green;
            StartCoroutine(Waite());
        }
    }

    void GenerateVocabs()
    {
        // right
        int v = Random.Range(0, vocabPictures.Length);
        picture.GetComponent<Image>().sprite = vocabPictures[v];

        int b1 = Random.Range(0, buttons.Length);
        rightButton = b1;
        buttons[b1].GetComponentInChildren<Text>().text = vocabs[v];
        print(buttons[b1]);
        print(vocabs[v]);

        // false
        if(b1 == 2)
        {
            buttons[0].GetComponentInChildren<Text>().text = vocabs[randomIntExcept(0, vocabs.Length, v)];
            buttons[1].GetComponentInChildren<Text>().text = vocabs[randomIntExcept(0, vocabs.Length, v)];
        }
        
        if (b1 == 0)
        {
            buttons[1].GetComponentInChildren<Text>().text = vocabs[randomIntExcept(0, vocabs.Length, v)];
            buttons[2].GetComponentInChildren<Text>().text = vocabs[randomIntExcept(0, vocabs.Length, v)];
        }

        if (b1 == 1)
        {
            buttons[0].GetComponentInChildren<Text>().text = vocabs[randomIntExcept(0, vocabs.Length, v)];
            buttons[2].GetComponentInChildren<Text>().text = vocabs[randomIntExcept(0, vocabs.Length, v)];
        }
    }

    IEnumerator Waite()
    {
        yield return new WaitForSeconds(2f);
        GenerateVocabs();
        for(int i = 0;i< buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().color = Color.grey;
        }
    }

    public int randomIntExcept(int min, int max, int except)
    {
        int result = Random.Range(min, max - 1);
        if (result >= except) result += 1;
        return result;
    }
}
