using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public List<itemType> inventoryList;
    public int selectedItem;
    public int playerReach;
    [SerializeField] GameObject throwItem_gameobject;

    [Space(20)]
    [Header("Keys")]
    [SerializeField] KeyCode throwItemKey;
    [SerializeField] KeyCode pickUpItemKey;

    [Space(20)]
    [Header("Item gameobjects")]
    [SerializeField] GameObject mop_item;
    [SerializeField] GameObject hit_item;

    [Space(20)]
    [Header("Item prefabs")]
    [SerializeField] GameObject mop_prefab;
    [SerializeField] GameObject hit_prefab;

    [Space(20)]
    [Header("UI")]
    [SerializeField] Image[] inventorySlotImage = new Image[6];
    [SerializeField] Image[] inventoryBackgroundImage = new Image[6];
    [SerializeField] Sprite prazdnySlotImage;


    [SerializeField] Camera cam;
    [SerializeField] GameObject pressToPickup_gameobject;


    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>() { };
    private Dictionary<itemType, GameObject> itemInstantiate = new Dictionary<itemType, GameObject>() { };


    void Start()
    {
        itemSetActive.Add(itemType.Mop, mop_item);
        itemSetActive.Add(itemType.Hit, hit_item);

        itemInstantiate.Add(itemType.Mop, mop_prefab);
        itemInstantiate.Add(itemType.Hit, hit_prefab);

        NewItemSelected();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, playerReach))
        {
            IPickable item = hitInfo.collider.GetComponent<IPickable>();
            if (item != null)
            {
                pressToPickup_gameobject.SetActive(true);
                if (Input.GetKey(pickUpItemKey))
                {
                    inventoryList.Add(hitInfo.collider.GetComponent<ItemPickable>().itemScriprableObject.item_type);
                    item.PickItem();
                }
            }
            else
            {
                pressToPickup_gameobject.SetActive(false);
            }
        }
        else
        {
            pressToPickup_gameobject.SetActive(false);
        }

        if (Input.GetKeyDown(throwItemKey) && inventoryList.Count > 1) //&& !animationIsPlaying)
        {
            Instantiate(itemInstantiate[inventoryList[selectedItem]], position: throwItem_gameobject.transform.position, new Quaternion());
            inventoryList.RemoveAt(selectedItem);

            if (selectedItem != 0)
            {
                selectedItem -= 1;
            }
            NewItemSelected();
        }

        for (int i = 0; i < 6; i++)
        {
            if (i < inventoryList.Count)
            {
                inventorySlotImage[i].sprite = itemSetActive[inventoryList[i]].GetComponent<Item>().itemScriptableObject.item_sprite;
            }  
            else
            {
                inventorySlotImage[i].sprite = prazdnySlotImage;
            }
        }

        int a = 0;
        foreach(Image image in inventoryBackgroundImage)
        {
            if (a == selectedItem)
            {
                image.color = new Color32(145, 255, 126, 255);
            }
            else
            {
                image.color = new Color32(219, 219, 219, 255);
            }
            a++;
        }




        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0) //&& !animationIsPlaying)
        {
            selectedItem = 0;
            NewItemSelected();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1) //&& !animationIsPlaying)
        {
            selectedItem = 1;
            NewItemSelected();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 0) //&& !animationIsPlaying)
        {
            selectedItem = 0;
            NewItemSelected();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && inventoryList.Count > 1) //&& !animationIsPlaying)
        {
            selectedItem = 1;
            NewItemSelected();
        }
    }

    private void NewItemSelected()
    {
        mop_item.SetActive(false);
        hit_item.SetActive(false);

        GameObject selectedItemGameobject = itemSetActive[inventoryList[selectedItem]];
        selectedItemGameobject.SetActive(true);
    }
}

public interface IPickable
{
    void PickItem();
}
