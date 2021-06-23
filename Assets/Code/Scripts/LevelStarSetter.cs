using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelStarSetter : MonoBehaviour
{
    [SerializeField] private Button Back;
    [SerializeField] private Button Star1;
    [SerializeField] private Button Star2;
    [SerializeField] private Button Star3;

    private void Start()
    {
        Back.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        Star1.onClick.AddListener(() => LevelComplete(1));
        Star2.onClick.AddListener(() => LevelComplete(2));
        Star3.onClick.AddListener(() => LevelComplete(3));
    }

    private void LevelComplete(int star)
    {
        var level = int.Parse(SceneManager.GetActiveScene().name);
        var data = SaveSystem.LoadPlayer();

        if (data.star.Count < level)
        {
            data.star.Add(star);
        }
        else
        {
            var j = level - 1;
            data.star[j] = star;
        }

        level++;
        if (Application.CanStreamedLevelBeLoaded(level.ToString()) && Energy.UseEnergy())
        {
            SceneManager.LoadScene(level.ToString());
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }

        if (level < data.level)
        {
            level = data.level;
        }

        SaveSystem.SavePlayer(new PlayerData(level, data.star, data.energy, DateTime.Now));
    }
}