using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    private float timeToWait = 0.25f;

    private Slots_UI thisSlot;

    public FoundMushroomTracker tracker;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        thisSlot = this.GetComponent<Slots_UI>();
        //Debug.Log("Set slotID to " + thisSlot.slotID);
        
        int mushNum = 0;
        string mushName = thisSlot.inventory.slots[thisSlot.slotID].itemName;
        mushNum = thisSlot.inventory.slots[thisSlot.slotID].itemNumber;

        if (!string.IsNullOrEmpty(mushName) && tracker.mushroomByItemNumber[mushNum])
        {
            tipToShow = mushName;
        }
        else if (!string.IsNullOrEmpty(mushName) && !tracker.mushroomByItemNumber[mushNum])
        {
            tipToShow = "??? Not yet researched!";
        }
        else
        {
            tipToShow = null;
        }
        

        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
    }

    private void ShowMessage()
    {
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);

        ShowMessage();
    }

    void Update()
    {
        if (!this.gameObject.activeSelf)
        {
            HoverTipManager.OnMouseLoseFocus();
        }
    }

}
