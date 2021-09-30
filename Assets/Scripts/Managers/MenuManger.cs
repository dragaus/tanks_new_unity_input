using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManger : MonoBehaviour
{
    [SerializeField]
    Button playButton; 
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() => GoToNewScene("Level 1"));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
