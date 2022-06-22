using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    private void Update() {
        Vector2 targetPos = new Vector2(target.position.x, target.position.y);
        transform.position = targetPos;
    }
}
