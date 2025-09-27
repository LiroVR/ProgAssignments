using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifficultySelector : MonoBehaviour
{

    public EDifficultySelector difficultySelector;
    Button btn;


    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate{LoadDifficultySelector(difficultySelector);});
    }
    public enum EDifficultySelector
    {
        Easy = 1,
        Normal = 2,
        Hard = 3
    }

    public void LoadDifficultySelector(EDifficultySelector diff)
    {
        SceneManager.LoadScene((int)diff);
    }
}
