using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScanner : MonoBehaviour
{
    public T[] ScanObjectOfType<T>(Vector3 origin, float distance, T type) where T : MonoBehaviour
    {

        var findingObjects = new List<T>();
        var detectObjects = Physics.CapsuleCastAll(origin, origin + transform.forward * distance, 0.5f, transform.forward);

        foreach (var detectObject in detectObjects)
        {
            T needObject = null;
            if (detectObject.collider.TryGetComponent<T>(out needObject))
            {
                findingObjects.Add(needObject);
            }
        }

        return findingObjects.ToArray();
    }

    public Character[] ScanOtherCharacters()
    {
        Character character = null;
        var f = ScanObjectOfType(transform.position, 5f, character);

        return f;
    }

    public virtual Vector3 ThrowBeam()
    {
        return Vector3.zero;
    }
}
