using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public Button pg;
    public Button qg;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        HealthManager.Instance.ResetHealth();
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        EditorApplication.ExitPlaymode();
    }
}
