using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeKarakter : MonoBehaviour
{
    private GameObject[] karakterList;
    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("ganti");

        karakterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            karakterList[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in karakterList)
            go.SetActive(false);

        if (karakterList[index])
            karakterList[index].SetActive(true);
    }

    public void ToggleLeft()
    {
        karakterList[index].SetActive(false);
        index--;
        if (index < 0)
            index = karakterList.Length - 1;

        karakterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        karakterList[index].SetActive(false);
        index++;
        if (index == karakterList.Length)
            index = 0;

        karakterList[index].SetActive(true);
    }

    public void ConfrimButton()
    {
        PlayerPrefs.SetInt("ganti", index);
        SceneManager.LoadScene(1);
    }
}
