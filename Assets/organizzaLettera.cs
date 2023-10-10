using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class organizzaLettera : MonoBehaviour
{
    public List<string> testi, testi1;
    public List<Text> pezzi, titoli;
    public AudioClip clipSuc, clipTras;
    public int completi, scena;
    float tempo, posX;
    public RuntimeAnimatorController animazione;
    public List<RectTransform> posY;

    void Awake()
    {
        int i = Screen.currentResolution.width;
        Screen.SetResolution(i, i * 1080 / 1920, FullScreenMode.Windowed, 60);
    }

    void Start()
    {
        posX = pezzi[0].transform.position.x;
        int j = Random.Range(3, 8);
        pezzi[2].rectTransform.position = new Vector2(posX, posY[j].position.y);
        pezzi[2].GetComponent<lettera>().pos = pezzi[2].transform.position;
        for (int i = 3; i >= -3; i--)
        {
            posY.RemoveAt(j + i);
        }

        pezzi.RemoveAt(2);
        for (int i = 0; i < pezzi.Count; i++)
        {
            int o = Random.Range(0, posY.Count);
            pezzi[i].transform.position = new Vector2(posX, posY[o].position.y);
            pezzi[i].GetComponent<lettera>().pos = pezzi[i].transform.position;
            posY.RemoveAt(o);
        }
        completi = -1;
    }

    void Update()
    {
        if (completi == 5)
        {
            transform.GetChild(0).position = new Vector2(Mathf.Lerp(transform.GetChild(0).position.x, Screen.width/2, Time.deltaTime * 3), transform.GetChild(0).position.y);
            if (tempo == 0)
            {
                transform.GetChild(4).gameObject.SetActive(false);
                transform.GetChild(5).gameObject.SetActive(false);
            }
            tempo += Time.deltaTime;
            if (tempo >= 2)
            {
                transform.GetChild(8).gameObject.SetActive(true);
                GetComponent<Animator>().runtimeAnimatorController = animazione;
                completi = 6;
                tempo = 1;
            }
        }

        if (completi >= 7)
        {
            tempo += Time.deltaTime;
            if (tempo >= 3.1f)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }

        if (completi == -1)
        {
            tempo += Time.deltaTime;
            if (tempo > 2)
            {
                tempo = 0;
                completi = 0;
                GetComponent<Animator>().runtimeAnimatorController = null;
            }
        }
    }

    public void Avanti()
    {
        completi++;
        GetComponent<Animator>().SetTrigger("vai");
    }
}