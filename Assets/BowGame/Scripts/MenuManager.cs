using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void ChangeToLevel1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ChangeToLevel2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void ChangeToLevel3()
    {
        SceneManager.LoadScene("Level_3");
    }
}
