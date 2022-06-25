using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static int _level = 1;
    public static int Level => _level;
    public static void NextLevel()
    {
        _level++;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync($"SampleScene");
        Debug.Log($"Уровень {Level}");
    }
}
