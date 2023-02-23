using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class HostButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
    }

    public void OnClickCloseButton()
    {
      using (var ws = new WebSocket("ws://0.0.0.0:1192/Laputa")) {
        ws.OnMessage += (sender, e) =>
            Debug.Log("Laputa says: " + e.Data);

        ws.Connect ();
        ws.Send ("BALUS");
      }
    }
}
