using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private bool done = false;
    private bool invoked = false;
    private GameObject currentGear;
    public GameObject gear1;
    public GameObject gear2;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");
        if(eventData.pointerDrag != null)
        {
            currentGear = eventData.pointerDrag.gameObject;
            eventData.pointerDrag.GetComponent<RectTransform>()
                .anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            done = true;
            Image myImage = GetComponent<Image>();
            myImage.color = new Color(myImage.color.r, 
                myImage.color.g, 
                myImage.color.b, 
                0);
        }
    }

    private void Update()
    {
        if(done)
        {
            currentGear.transform.Rotate(Vector3.forward*.3f);
            gear1.transform.Rotate(Vector3.forward*.3f);
            gear2.transform.Rotate(Vector3.forward*.3f);
            if(!invoked)
            {
                invoked = true;
                Invoke("nextLevel",2f);
            }
        }
    }

    private void nextLevel()
    {
        GameObject puzzle = transform.parent.gameObject;
        TimelineManager.Instance.TriggerInput();
        TimelineManager.Instance.canSkip = true;
        puzzle.SetActive(false);
    }

}
