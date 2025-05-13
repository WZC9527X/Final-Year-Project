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
        }
        else if (_LevelCount == 2)
        {
            Level_2();
        }
        else if (_LevelCount == 3)
        {
            Level_3();
        }
        else if (_LevelCount == 4)
        {

        }
        else
        {
            Debug.Log("no level");

        }

        Debug.Log("next Level: " + _LevelCount);

    }

    public void LevelCount()
    {
        _LevelCount++;
        
    }

    public void Level_1()
    {
        Debug.Log("cleanBlood: " + SelectOJPanel.cleanBlood);
        if (SelectOJPanel.cleanBlood >= 1)
        {
            Debug.Log("Go to 2 levels");

            LevelCount();
            SelectOJPanel.cleanBlood = 0;
        }
        //Debug.Log("unconditional");
     
    }

    public void Level_2()
    {
        Debug.Log("cleanBlood: " + SelectOJPanel.cleanBlood);
        if (SelectOJPanel.cleanBlood >= 3)
        {
            Debug.Log("Go to 3 levels");

            LevelCount();
            SelectOJPanel.cleanBlood = 0;
        }
    }

    public void Level_3()
    {
        if (LoopS.sceneP.transform.Find("Rubbish") != null)
        {
            Debug.Log("Rubbish Count: " + LoopS.sceneP.transform.Find("Rubbish").childCount);

            if (LoopS.sceneP.transform.Find("Rubbish").childCount <= 0)
            {
                Debug.Log("Go to 4 levels");

                LevelCount();
            }
        }
    }




}


//foreach (var item in sceneCount)
//{
//    Debug.Log(item); // 输出：Second, Third
//}