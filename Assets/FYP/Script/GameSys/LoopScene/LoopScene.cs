using UnityEngine;

public class LoopScene : MonoBehaviour
{
    //public static Queue<GameObject> sceneCount = new Queue<GameObject>();
    public GameObject[] _allScenePrefab;
    //public static GameObject[] allScenePrefab;
    public static int _LevelCount = 1;

    private void Start()
    {
        //allScenePrefab = _allScenePrefab;
    }
    public void NextLevel()
    {
        if (_LevelCount == 1)
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

    public void LevelCount()
    {
        _LevelCount++;
        
    }

    public void Level_1()
    {
        if (SelectOJPanel.cleanBlood >= 3)
        {
            Debug.Log("The blood is cleared to enter the 2 level.");

            LevelCount();

        }
        //Debug.Log("unconditional");
     
    }

    public void Level_2()
    {

    }

    public void Level_3()
    {

    }




}


//foreach (var item in sceneCount)
//{
//    Debug.Log(item); // 输出：Second, Third
//}