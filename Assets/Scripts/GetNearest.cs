using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNearest : MonoBehaviour
{
    public static GameObject nearest(Vector2 currentPosition, string tag)
    {
        GameObject[] itemsArr = GameObject.FindGameObjectsWithTag(tag);
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach(GameObject potentialTarget in itemsArr){
            // Ignore inactive targets
            if(!potentialTarget.activeInHierarchy){
                continue;
            }
            Vector2 potentialPos = potentialTarget.transform.position;
            Vector2 directionToTarget = potentialPos - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr){
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }
}