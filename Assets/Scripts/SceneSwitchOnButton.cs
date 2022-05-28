using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitchOnButton : MonoBehaviour
{
    public static int currentLevel = 0;

    public void LoadNextScene()
    {
        currentLevel++;
        SceneManager.LoadScene($"Level{(currentLevel)}");
    }
    public void RepeatScene()
    {
        SceneManager.LoadScene($"Level{currentLevel}");
    }

    //----------------------------------------------------------------------------------

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        currentLevel = 0;
    }
    public void SectionSelect()
    {
        SceneManager.LoadScene("SectionSelect");
    }
    public void Quit()
    {
        Application.Quit();
    }
    //----------------------------------------------------------------------------------

    public void SectionOneLevels()
    {
        SceneManager.LoadScene("SectionOneLevels");
    }
    public void SectionTwoLevels()
    {
        SceneManager.LoadScene("SectionTwoLevels");
    }
    public void SectionThreeLevels()
    {
        SceneManager.LoadScene("SectionThreeLevels");
    }
    public void SectionFourLevels()
    {
        SceneManager.LoadScene("SectionFourLevels");
    }
    public void SectionFiveLevels()
    {
        SceneManager.LoadScene("SectionFiveLevels");
    }

    //----------------------------------------------------------------------------------

    public void SectionOneLevel1()
    {
        SceneManager.LoadScene("Level0");
        currentLevel = 0;
    }
    public void SectionOneLevel2()
    {
        SceneManager.LoadScene("Level1");
        currentLevel = 1;
    }
    public void SectionOneLevel3()
    {
        SceneManager.LoadScene("Level2");
        currentLevel = 2;
    }
    public void SectionOneLevel4()
    {
        SceneManager.LoadScene("Level3");
        currentLevel = 3;
    }

}
