using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagManager.GROUNDTAG) || other.CompareTag(TagManager.TREE1TAG)
                                                   || other.CompareTag(TagManager.TREE2TAG))
        {
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag(TagManager.OBSTACLETAG) || other.CompareTag(TagManager.ENEMYTAG)||
            other.CompareTag(TagManager.HEALTHTAG))
        {
           Destroy(other.gameObject);
        }
    }
}
