using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : Singleton<ItemCollector>
{
    private int points = 0;
    
    [SerializeField] private Text pointsText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void Start()
    {
        points = Int32.Parse(FileHandler.Instance.readProcess());
        pointsText.text = "Points: " + points;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            collectionSoundEffect.Play();
            collision.gameObject.GetComponentInParent<Fruit>().OnDestroy();
            points += collision.gameObject.GetComponentInParent<Fruit>().point;
            pointsText.text = "Points: " + points;
            Debug.Log(points);
        }
    }
    public int getPoint()
    {
        return points;
    }
   
}

