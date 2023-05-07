using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   public void LoadSinglePlayerGame(){
    
    SceneManager.LoadScene("SampleScene 1");
   }

   public void LoadCoOpMode(){
    SceneManager.LoadScene("Co-op Mode");
   }
}
