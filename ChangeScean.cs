using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScean : MonoBehaviour
{
    public void lodeSimpleMath ()
    {
        Application.LoadLevel("SimpleMath");
    }

    public void lodeMemory ()
    {
        Application.LoadLevel("Memory");
    }

    public void loadVocabs ()
    {
        Application.LoadLevel("Vocabulary");
    }

    public void LoadMenu ()
    {
        Application.LoadLevel("Menu");
    }

    public void Auschalten ()
    {
            Application.Quit();
    }
	
}
