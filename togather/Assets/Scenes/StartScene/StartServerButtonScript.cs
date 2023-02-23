using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class StartServerButtonScript : MonoBehaviour
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

    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var msg = e.Data == "BALUS"
                        ? "Are you kidding?"
                        : "I'm not available now.";
            Debug.Log(msg);
            Send (msg);
        }
    }

    public void OnClickCloseButton()
    {
      var wssv = new WebSocketServer("ws://localhost:1192");
      wssv.AddWebSocketService<Laputa> ("/Laputa");
      wssv.Start();
    if (wssv.IsListening) {

                 Debug.Log(wssv.Port);

        foreach (var path in wssv.WebSocketServices.Paths)
                           Debug.Log(path);
      }

            using (var ws = new WebSocket("ws://localhost:1192/Laputa")) {
        ws.OnMessage += (sender, e) =>
            Debug.Log("Laputa says: " + e.Data);

        ws.Connect ();
        ws.Send ("BALUS");
      }
    //   wssv.Stop();
    }
}
