using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Array aller Collectible Items
    [SerializeField]
    private GameObject[] collectibleItems;

    private Vector3[] initialPositions;

    void Start()
    {
        initialPositions = new Vector3[collectibleItems.Length];
        for (int i = 0; i < collectibleItems.Length; i++)
        {
            initialPositions[i] = collectibleItems[i].transform.position;
        }
    }

    // Setzt alle Collectible Items auf ihre ursprünglichen Positionen zurück
    public void ResetCollectibles()
    {
        for (int i = 0; i < collectibleItems.Length; i++)
        {
            collectibleItems[i].transform.position = initialPositions[i];
            collectibleItems[i].SetActive(true);
            Earth.count = 0;
        }
    }
}