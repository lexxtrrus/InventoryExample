using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image icon;
    private Item item;

    public void SetEmptySlot()
    {
        item = null;
        icon.sprite = null;
        icon.DOFade(0f, 0f);
    }

    public void SetItem(Item item)
    {
        this.item = item;
        icon.sprite = item.Icon;
        icon.DOFade(1f, 0f);
    }
}
