using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClick : MonoBehaviour
{
    public Vector2 baloonPos = new Vector2();
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        NetworkedClientProcessing.SendMessageToServer(ClientToServerSignifiers.DestroyBaloonInPos.ToString() + '|' + baloonPos.x + '|' + baloonPos.y);
    }
}
