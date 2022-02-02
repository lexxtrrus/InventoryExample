using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Item : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Camera camera;
    [SerializeField]private GraphicRaycaster raycaster;
    [SerializeField]private EventSystem eventSystem;
    [SerializeField]private Sprite icon;
    [SerializeField]private Cell parent;

    private bool isDrag = false;
    private Cell target;
    private PointerEventData pointerEventData;
    public Sprite Icon => icon;

    public Item SetReferences(Camera camera, GraphicRaycaster raycaster, EventSystem eventSystem, Sprite icon, Cell parent)
    {
        this.camera = camera;
        this.raycaster = raycaster;
        this.eventSystem = eventSystem;
        this.icon = icon;
        this.parent = parent;

        return this;
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one * 1.1f, 0.3f);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        transform.DOScale(Vector3.one, 0.3f);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
    }
    
    private void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Mouse0))
        {
            return;
        }

        pointerEventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };
        
        var result = new List<RaycastResult>();
        raycaster.Raycast(pointerEventData, result);
        
        Debug.Log(result.Count);
        
        foreach (var raycastResult in result)
        {
            var cell = raycastResult.gameObject.GetComponent<Cell>();

            if (cell != null)
            {
                cell.SetItem(this);
                parent.SetEmptySlot();
                transform.localPosition = Vector3.zero;
                return;
            }
        }

        transform.localPosition = Vector3.zero;
    }
}
