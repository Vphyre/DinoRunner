using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text lifeText;
    [SerializeField]
    public static Text gameOverText;
    [SerializeField]
    public static GameObject gameOverScreen;
    // Start is called before the first frame update
    void Awake()
    {
       gameOverScreen = gameObject.transform.GetChild(0).gameObject;
       gameOverText = gameOverScreen.transform.GetChild(2).gameObject.GetComponent<Text>();
       gameOverScreen.SetActive(false);
       Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ShowLife();
    }
    void ShowLife()
    {
        lifeText.text = DinoController.life.ToString();
    }
    public static void GameOver(string text)
    {
        gameOverScreen.SetActive(true);
        gameOverText.text = text;
        Time.timeScale = 0;
    }
}
