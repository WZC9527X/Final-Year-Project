using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickable : MonoBehaviour, IPickable
{
    public ItemSO itemScriprableObject;
    AudioSystem _AudioSystem;
    private void Start()
    {
        _AudioSystem = GameObject.FindGameObjectWithTag("AudioSystem").GetComponent<AudioSystem>();
        
    }

    public void PickItem()
    {

        Debug.Log(itemScriprableObject.item_type);
        if (itemScriprableObject.item_type == itemType.Key)
        {
            //_AudioSystem.AudioLib(1);
            AudioSystem.Instance.PlaySound("KeyPickup");
        }  
        Destroy(gameObject);
    }

}
