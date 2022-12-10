using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkedClientProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromServer(string msg)
    {
        Debug.Log("msg received = " + msg + ".");

        string[] csv = msg.Split('|');
        int signifier = int.Parse(csv[0]);

       switch (signifier)
        {
            case ServerToClientSignifiers.PutNewBaloonToPos:
                gameLogic.SpawnNewBalloon(float.Parse(csv[1]), float.Parse(csv[2]));
                break;
            case ServerToClientSignifiers.DestroyBaloonByPos:
                gameLogic.DestroyBaloonAt(float.Parse(csv[1]), float.Parse(csv[2]));
                break;
            default:
                break;
        }

        //gameLogic.DoSomething();

    }

    static public void SendMessageToServer(string msg)
    {
        networkedClient.SendMessageToServer(msg);
    }

    #endregion

    #region Connection Related Functions and Events
    static public void ConnectionEvent()
    {
        Debug.Log("Network Connection Event!");
    }
    static public void DisconnectionEvent()
    {
        Debug.Log("Network Disconnection Event!");
    }
    static public bool IsConnectedToServer()
    {
        return networkedClient.IsConnected();
    }
    static public void ConnectToServer()
    {
        networkedClient.Connect();
    }
    static public void DisconnectFromServer()
    {
        networkedClient.Disconnect();
    }

    #endregion

    #region Setup
    static NetworkedClient networkedClient;
    static GameLogic gameLogic;

    static public void SetNetworkedClient(NetworkedClient NetworkedClient)
    {
        networkedClient = NetworkedClient;
    }
    static public NetworkedClient GetNetworkedClient()
    {
        return networkedClient;
    }
    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }

    #endregion

}

#region Protocol Signifiers
static public class ClientToServerSignifiers
{

    public const int DestroyBaloonInPos = 1;
    public const int Disconnect = 2;
}

static public class ServerToClientSignifiers
{
    public const int PutNewBaloonToPos = 1;
    public const int DestroyBaloonByPos = 2;
}
#endregion

