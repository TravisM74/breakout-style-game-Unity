using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIControler : MonoBehaviour
{


    public TextMeshProUGUI nameField;
    private string Name;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClicked(){
        GameManager.Instance.LoadSavedData();
        GameManager.Instance.SetName(nameField.text);
        SceneManager.LoadScene(1);
    }

    public void QuitGameClicked(){
        GameManager.Instance.SaveGameData();
        Application.Quit();
    }
}
