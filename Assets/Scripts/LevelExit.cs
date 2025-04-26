using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public string nextLevel;
    public float waitToEndLevel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //StartCoroutine(EndLevelCo());
            SceneManager.LoadScene("ExitScene");
        }
    }

    private IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToEndLevel);
        SceneManager.LoadScene(nextLevel);
    }

}
