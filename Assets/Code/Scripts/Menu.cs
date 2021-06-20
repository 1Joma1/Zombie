using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image levelMenu;
    [SerializeField] private Sprite star;

    private void Start()
    {
        PlayerData data = SaveSystem.Load();
        transform.Find("Play").GetComponent<Button>().onClick.AddListener(() => OpenScene(data.level));
        transform.Find("Level").gameObject.GetComponent<Button>().onClick.AddListener(OpenLevelMenu);
        levelMenu.transform.Find("Back").GetComponent<Button>().onClick.AddListener(CloseLevelMenu);
        for (var i = 1; i <= data.level; i++)
        {
            var level = i;
            var button = levelMenu.transform.Find(level.ToString());
            button.GetComponent<Button>().interactable = true;
            button.GetComponent<Button>().onClick.AddListener(() => OpenScene(level));
            switch (data.star[i])
            {
                case 1:
                    button.transform.Find("1").GetComponent<Image>().sprite = star;
                    break;
                case 2:
                    button.transform.Find("1").GetComponent<Image>().sprite = star;
                    button.transform.Find("2").GetComponent<Image>().sprite = star;
                    break;
                case 3:
                    button.transform.Find("1").GetComponent<Image>().sprite = star;
                    button.transform.Find("2").GetComponent<Image>().sprite = star;
                    button.transform.Find("3").GetComponent<Image>().sprite = star;
                    break;
            }
        }
    }

    private void OpenLevelMenu()
    {
        levelMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void CloseLevelMenu()
    {
        levelMenu.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private void OpenScene(int level)
    {
        SceneManager.LoadScene(level.ToString());
    }
}