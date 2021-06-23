using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Image levelMenu;
    [SerializeField] private Image energyMenu;
    [SerializeField] private Sprite star;

    private void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        transform.Find("Play").GetComponent<Button>().onClick.AddListener(() => OpenScene(data.level));
        transform.Find("Level").gameObject.GetComponent<Button>().onClick.AddListener(OpenLevelMenu);
        transform.Find("Clear").gameObject.GetComponent<Button>().onClick.AddListener(Clear);
        levelMenu.transform.Find("Back").GetComponent<Button>().onClick.AddListener(CloseLevelMenu);
        energyMenu.transform.Find("Back").GetComponent<Button>().onClick.AddListener(CloseEnergyMenu);
        transform.Find("Energy").GetComponent<Button>().onClick.AddListener(OpenEnergyMenu);
        for (var i = 1; i <= data.level; i++)
        {
            var level = i;
            var button = levelMenu.transform.Find(level.ToString());
            button.GetComponent<Button>().interactable = true;
            button.GetComponent<Button>().onClick.AddListener(() => OpenScene(level));
            if (!data.star.Any() || data.star.Count < level) return;
            var j = level - 1;
            switch (data.star[j])
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

    private void OpenEnergyMenu()
    {
        energyMenu.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Clear()
    {
        SaveSystem.Clear();
        SceneManager.LoadScene("Menu");
    }

    private void CloseLevelMenu()
    {
        levelMenu.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private void CloseEnergyMenu()
    {
        energyMenu.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    private void OpenScene(int level)
    {
        if (Energy.UseEnergy())
        {
            SceneManager.LoadScene(level.ToString());
        }
    }

    private void Update()
    {
        
    }
}