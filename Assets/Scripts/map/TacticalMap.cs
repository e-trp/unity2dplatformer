using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TacticalMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    GameObject gameObj, prevGameObj;
    Image image;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            gameObj = raycastResults[0].gameObject;

            if (gameObj.tag == "GridBox")
            {
                if (prevGameObj != null && gameObj != prevGameObj)
                {
                    image = prevGameObj.gameObject.GetComponent<Image>();
                    image.color = new Color32(255, 255, 255, 87);
                    
                }

                    Debug.Log(gameObj.transform.name);
                    image = gameObj.gameObject.GetComponent<Image>();
                    image.color = new Color32(255, 255, 255, 0);
                    prevGameObj = gameObj;

            }
        }
        
    }

    public void OnMouseOver(PointerEventData eventData)
    {
       if (eventData.pointerEnter.tag == "GridBox")
       {
            Debug.Log("Mouse enter " + eventData.pointerEnter.gameObject.name);
           Image image = eventData.pointerEnter.gameObject.GetComponent<Image>();
           image.color = new Color32(255, 255, 255, 0);
       }

    }

    public void OnMouseExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == "GridBox")
        {
            Debug.Log("Mouse exit " + eventData.pointerEnter.gameObject.name);
            Image image = eventData.pointerEnter.gameObject.GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 78);
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {

       /* if (eventData.pointerEnter.tag == "GridBox")
        { Debug.Log("Mouse enter " + eventData.pointerEnter.gameObject.name);
            Image image = eventData.pointerEnter.gameObject.GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 0);
        }*/
    }

    public void OnPointerExit(PointerEventData eventData)
    {


        /*if (eventData.pointerEnter.tag == "GridBox")
        {
            Debug.Log("Mouse exit " + eventData.pointerEnter.gameObject.name);
            Image image = eventData.pointerEnter.gameObject.GetComponent<Image>();
            image.color = new Color32(255, 255, 255, 78);
        }*/

    }

}
