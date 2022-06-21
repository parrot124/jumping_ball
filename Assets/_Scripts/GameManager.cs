using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    private static int _levelNumber = 1;
    public static int LevelNumber => _levelNumber;
    public static void NextLevel()
    {
        _levelNumber++;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync($"SampleScene");
        Debug.Log(_levelNumber);
    }
}
