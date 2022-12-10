using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    
    Sprite circleTexture;

    void Start()
    {
        NetworkedClientProcessing.SetGameLogic(this);
    }

    public void SpawnNewBalloon(float posX, float posY)
    {
        if(circleTexture == null)
            circleTexture = Resources.Load<Sprite>("Circle");

        GameObject balloon = new GameObject("Balloon");

        balloon.AddComponent<SpriteRenderer>();
        balloon.GetComponent<SpriteRenderer>().sprite = circleTexture;
        balloon.AddComponent<CircleClick>();
        balloon.AddComponent<CircleCollider2D>();
       
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(posX * (float)Screen.width, posY * (float)Screen.height, 0));
        pos.z = 0;
        balloon.transform.position = pos;

    }

}

