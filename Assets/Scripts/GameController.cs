using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//sahne metodu
public class GameController : MonoBehaviour
{
    public float currentAsteroidSpeed = -2f; // Senin başlangıç hızın -2 olduğu için böyle başlattık
    public float speedIncrease = -2f;     // Hızlanması için (eksi yönde artış)


    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoretext;
    public Text gameovertext;
    public Text restarttext;
    public Text quittext;
    public int score;

    private bool gameover;
    private bool restart;

    void Update()
    {
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }
    }
    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            
            for (int i=0; i < spawnCount; i++)
            {
                Vector3 spawnposition = new Vector3(Random.Range(-3, 3), 0, 10);
                Quaternion spawnrotation = Quaternion.identity;//yani rotasyonu eski şeyinde kalsın
                                                               //rotasyon ayarları için ama önceden astreidte belirtmiştik zaten
                GameObject geçicisim = Instantiate(hazard, spawnposition, spawnrotation);
                laser asteroidScript = geçicisim.GetComponent<laser>();//direkt erişim
                if (asteroidScript != null)
                {
                    asteroidScript.speed = currentAsteroidSpeed;
                    // HIZI BURADA ELİNLE TEKRAR SET ET:
                    geçicisim.GetComponent<Rigidbody>().velocity = geçicisim.transform.forward * asteroidScript.speed;
                }

                //coroutine denir bu yapıların tamamı metot gibi bilgidiğin ama void değil ıenumerator döndürür
                //en az 1 adet yield ifadesi bulunmak zorunda ve çağrılırken startCoroutine ile çağrılır
                yield return new WaitForSeconds(spawnWait);//bekleme için süre belirttiğin yapı
                                                           //bu yapı varsa fonksiyonun void değil IEnumerator olmalı

            }
            currentAsteroidSpeed += speedIncrease;
            spawnCount += 15;
            yield return new WaitForSeconds(waveWait);
            if (gameover == true)
            {
                restarttext.text = "Tekrar başlamak için 'R' ye bas";
                quittext.text = "Çıkış yapmak için Q ya bas";
                restart = true;
                break;
            }

        }
    }


    public void UpdateScore()
    {
        score += 10;
        scoretext.text = "Skor: " + score;
    }

    public void Gameover()
    {
        gameovertext.text = "Oyun Bitti Tekrar Deneyin";
        gameover = true;
    }
    void Start()
    {
        gameovertext.text = "";
        restarttext.text = "";
        quittext.text = "";
        gameover = false;
        restart = false;

        StartCoroutine(SpawnValues());//bunlar normal fonk gibi değil böyle çağrılır
        
    }


}
