using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scored : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject score;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
