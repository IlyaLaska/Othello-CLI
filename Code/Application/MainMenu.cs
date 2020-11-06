//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class MainMenu : MonoBehaviour
//{
//    public GameObject blackScoreO;
//    public GameObject whiteScoreO;

//    private void Start()
//    {
//        if (GameProperties.whiteScore >= 0)
//        {
//            whiteScoreO.GetComponent<TextMeshProUGUI>().text = GameProperties.whiteScore.ToString();
//        }
//        if (GameProperties.blackScore >= 0)
//        {
//            blackScoreO.GetComponent<TextMeshProUGUI>().text = GameProperties.blackScore.ToString();
//        }
//    }
//    public void quit()
//    {
//        Application.Quit();
//    }

//    public void SPonClick()
//    {
//        GameProperties.playerBlackIsHuman = true;
//        GameProperties.playerWhiteIsHuman = false;
//        SceneManager.LoadScene("Board", LoadSceneMode.Single);
//    }

//    public void MPonClick()
//    {
//        GameProperties.playerBlackIsHuman = true;
//        GameProperties.playerWhiteIsHuman = true;
//        SceneManager.LoadScene("Board", LoadSceneMode.Single);
//    }
//}
