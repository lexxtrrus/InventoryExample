using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Cell> shopCells;
    [SerializeField] private GameObject shopCellPrefab;
    [SerializeField] private RectTransform gridPanel;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Camera camera;
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            shopCells.Add(Instantiate(shopCellPrefab, gridPanel).GetComponent<Cell>());
            var item = shopCells[i].GetComponentInChildren<Item>();
            shopCells[i].SetItem(item.SetReferences(camera, raycaster, eventSystem, GetRandomIcon(), shopCells[i]));
        }
    }

    private Sprite GetRandomIcon()
    {
        return sprites[Random.Range(0, sprites.Count)];
    }
}
