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
        balloon.tag = "Baloon";
        balloon.GetComponent<CircleClick>().baloonPos = new Vector2(posX, posY);
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(posX * (float)Screen.width, posY * (float)Screen.height, 0));
        pos.z = 0;
        balloon.transform.position = pos;
    }
    public void DestroyBaloonAt(float posX, float posY)
    {
        GameObject[] baloons = GameObject.FindGameObjectsWithTag("Baloon");
        foreach(GameObject baloon in baloons)
        {
            if (baloon.GetComponent<CircleClick>().baloonPos == new Vector2(posX,posY))
            {
                Destroy(baloon);
                break;
            }
        }
       
    }
   /* private void OnDestroy()
    {
        NetworkedClientProcessing.SendMessageToServer(ClientToServerSignifiers.Disconnect.ToString());
    }*/
    private void OnApplicationQuit()
    {
        NetworkedClientProcessing.SendMessageToServer(ClientToServerSignifiers.Disconnect.ToString());
    }
}

