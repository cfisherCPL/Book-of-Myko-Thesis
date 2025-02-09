using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    private float timeToWait = 0.25f;

    private Slots_UI thisSlot;


    public void Start()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        thisSlot = this.GetComponent<Slots_UI>();
        Debug.Log("Set slotID to " + thisSlot.slotID);
        tipToShow = thisSlot.inventory.slots[thisSlot.slotID].itemName;
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
}
