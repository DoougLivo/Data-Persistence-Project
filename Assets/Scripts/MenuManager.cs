using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI nameScoreText;
    public TMP_InputField inputField;
    private string name;

    private void Awake()
    {
        name = inputField.GetComponent<TMP_InputField>().text;
    }

    private void Update()
    {
        
    }

    public void InputName()
    {
        name = inputField.text;
        GameManager.Instance.playerName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadInfo();
        nameScoreText.text = $"{GameManager.Instance.name} : {GameManager.Instance.score}";
    }

    public void StartMain()
    {
        InputName();
        SceneManager.LoadScene(1);
    }


    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
