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
        var oldStar = SaveSystem.Load().star;

        
        if (oldStar.Count < level)
        {
            oldStar.Add(star);
        }
        else
        {
            var j = level - 1;
            oldStar[j] = star;
        }
        level++;
        SaveSystem.Save(new PlayerData(level, oldStar));
        if (Application.CanStreamedLevelBeLoaded(level.ToString()))
        {
            SceneManager.LoadScene(level.ToString());
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}