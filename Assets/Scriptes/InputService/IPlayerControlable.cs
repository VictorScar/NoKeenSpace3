using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerControlable
{
    public void Move(Vector2 inputDir);
    public void Rotate(Vector2 rotateDir);
    public void Jump();

    public void DoAction();
}
