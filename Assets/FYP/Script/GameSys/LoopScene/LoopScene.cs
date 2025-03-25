using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoopScene : MonoBehaviour
{
    //public static Queue<GameObject> sceneCount = new Queue<GameObject>();
    public GameObject[] _allScenePrefab;
    public static int _LevelCount = 1;

    //public static bool _isWin;
    public void NextLevel()
    {

        if(_LevelCount == 1)
        {
            Level_1();
            Debug.Log("_LevelCount: " + _LevelCount);
        }
        else if (_LevelCount == 2)
        {

        }
        else if (_LevelCount == 3)
        {

        }
        else if (_LevelCount == 4)
        {

        }
        else
        {
            Debug.Log("no level");

        }

        
    }

    public void Level_1()
    {
        if (SelectOJPanel._isCleanblood)
        {
            Debug.Log("The blood is cleared to enter the 2 level.");

            _LevelCount++;
            
        }
        Debug.Log("unconditional");
     
    }





}


//foreach (var item in sceneCount)
//{
//    Debug.Log(item); // 输出：Second, Third
//}