using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SimpleMath : MonoBehaviour
{
    // Menu und Spiel
    public GameObject play;
    public GameObject home;

    // UI Spiel
    public Slider zeitAnzeige;
    public Text rechnung;
    public Text ergebniss;
    public Text scoreText;

    // UI Home
    public Text highScoreText;

    // Optionen
    public float zeit;
    public float zahlengrösse;

    // Variablen
    private int edukt1;
    private int edukt2;
    private int produkt;
    private int vergleichswert;
    private float timer;
    private int richtigerButtton;
    private int score;
    private int highScore;
    private bool playModus;


    private void Start()
    {
        // Sleider groesse setzen
        zeitAnzeige.maxValue = zeit;
        zeitAnzeige.value = 0;
        timer = zeit;
        highScore = PlayerPrefs.GetInt("SimpleMath High Score");
        highScoreText.text = highScore.ToString();
        playModus = false;
    }

    private void Update ()
    {
        if (playModus)
        {
            Timer();
        }
	}

    private void Rechnung ()
    {
        // eine zufällige Zahl berechnen
        edukt1 = Random.Range(0, 10);
        edukt2 = Random.Range(0, 10);
        produkt = edukt1 + edukt2;
        scoreText.text = score.ToString();

        // UI Rechnung 
        rechnung.text = edukt1.ToString () + " + " + edukt2.ToString ();

        // eine zufällige Abweichung des Ergebnisses berechnen
        vergleichswert = produkt + Random.Range(-2, 2);

        // UI "Ergebniss"
        ergebniss.text = "= " + vergleichswert.ToString ();

        // Überprüfung welcher Button gedrückt werden muss
        if (vergleichswert == produkt)
        {
            richtigerButtton = 0;
        }
        else
        {
            richtigerButtton = 1;
        }
    }

    public void Button (int vergleich)
    {
        // input von Button (0 für richtig / 1 für falsch)
        if (richtigerButtton == vergleich)
        {
            // neue Rechnnung
            Rechnung();
            // +1 für den Score
            score = score + 1;
            scoreText.text = score.ToString ();
            // rest für Timer
            timer = zeit;
        }
        else
        {
            GameOver();
        }
    }

    private void Timer ()
    {
        // Timer

        timer -= Time.deltaTime;
        zeitAnzeige.value = timer;
        
        if (timer <= 0)
        {
            playModus = false;
            GameOver();
        }
    }

    private void GameOver ()
    {
        play.SetActive(false);
        home.SetActive(true);
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString ();
        }
    }

    public void lodeMenu ()
    {
        PlayerPrefs.SetInt("SimpleMath High Score", highScore);
        Application.LoadLevel("Menu");
    }

    public void PlayAgian ()
    {
        score = 0;
        Rechnung();
        timer = zeit;
        scoreText.text = score.ToString();
        play.SetActive(true);
        home.SetActive(false);
        playModus = true;

    }
}
