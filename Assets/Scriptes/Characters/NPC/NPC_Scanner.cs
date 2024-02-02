using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Scanner : CharacterScanner
{
   // [SerializeField] private float _searchingRadius = 0.5f;
    [SerializeField] private float _searchingDistance = 20f;
    [SerializeField] private LayerMask layerMask;

    public Player FindPlayer()
    {
        var searchingDir = transform.forward;
        var searchCenterPoint = transform.position + searchingDir * _searchingDistance *0.5f;
        var detectObjects = Physics.SphereCastAll(searchCenterPoint, _searchingDistance*0.5f, searchingDir, 0, layerMask);
       // Debug.Log("Scanning");
        foreach (var detectObject in detectObjects)
        {
            var player = detectObject.collider.GetComponent<Player>();

            if (player != null)
            {
                return player;
            }
        }

        return null;
    }
}
