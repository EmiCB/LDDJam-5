using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TMP_Dropdown levelSelector;
    private List<TMP_Dropdown.OptionData> optionData;
    private List<string> levelNames = new List<string>();

    private void Awake() {
        optionData = levelSelector.options;
        for (int i = 0; i < optionData.Count; i++) {
            levelNames.Add(optionData[i].text);
        }
    }

    public void Play() {
        SceneManager.LoadScene(levelNames[levelSelector.value]);
    }

    public void Quit() {
        Application.Quit();
    }
}
