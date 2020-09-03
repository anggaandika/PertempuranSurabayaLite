using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
   public GameObject changeKrakter;
    public GameObject selft;
   public void ButtonStart()
   {
        changeKrakter.SetActive(true);
        selft.SetActive(false);
   		//SceneManager.LoadScene(1);
   }
   public void ButtonCredit()
   {
   		SceneManager.LoadScene(3);
   }
   public void ButtonQuit()
   {
   		Application.Quit();
   }
}
