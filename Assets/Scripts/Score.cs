using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int score;
    private TMP_Text text;
    private Scene current;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        current = SceneManager.GetActiveScene();
        score = 0;
    }

    public void AddPoint()
    {
        score += 1;
        text.SetText(score.ToString()+"/3");
        if (score == 3) 
        {
            score = 0;
 
            string sceneName = current.name;
            if (sceneName == "SecondScene")
            {
                SceneManager.LoadScene("VictoryScene");
            }
            else 
            {
                SceneManager.LoadScene("SecondScene");
            }
            
        }
    }
}
