using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Make sure GameManager is initiated first
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        // Should be just after LoadGame();
        UpdateScoreText();

        string playerName = GameManager.Instance.playerName;
        if (playerName != "")
            inputField.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreText()
    {
        // In case there is back button from main to menu
        bestScoreText.text = "Best Score: " + GameManager.Instance.bestScore;
    }

    public void StartGame()
    {
        if (inputField.text != "")
        {
            GameManager.Instance.playerName = inputField.text;
            SceneManager.LoadScene("main");
            // either make MainManager accessible, or Main onStart to get the score and name after load scene
        }
    }

    public void EndGame()
    {
        GameManager.Instance.SaveGame();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
