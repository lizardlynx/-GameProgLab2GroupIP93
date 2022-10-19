using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scored : MonoBehaviour
{
    public GameObject score;
        // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Toggle() 
    {
        gameObject.SetActive(true);
        Score scoreScript = score.GetComponent<Score>();
        scoreScript.AddPoint();
        StartCoroutine("Timeout");
    }

    IEnumerator Timeout() 
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);

    }
}
