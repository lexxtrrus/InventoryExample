using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Inventory: MonoBehaviour
    {
        [SerializeField] private List<Cell> inventoryPanel;

        private void Awake()
        {
            foreach (var cell in inventoryPanel)
            {
                cell.SetEmptySlot();
            }
        }
        
        
        
    }
}