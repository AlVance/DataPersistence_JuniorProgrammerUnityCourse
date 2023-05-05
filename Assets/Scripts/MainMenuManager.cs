using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    private void SetName()
    {
        DataManager.Instance.currentPlayerName = nameText.text;
    }
    public void LoadGameScene()
    {
        SetName();
        Debug.Log(nameText.text.Length);
        if(nameText.text.Length > 1)SceneManager.LoadScene("main");
    }
}
