using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.IO;
using System;
using System.Threading;

public class TwitchIntegration : MonoBehaviour
{
    
    public string twitchChannel;
    public string userName;
    public string twitchOauth;
    public GameObject enemy;
    public Transform respawn;

    private static TcpClient tcpClient;
    private static StreamReader reader;
    private static StreamWriter writer;
    private static string message;


    private void Connect()
    {
        tcpClient = new TcpClient("irc.twitch.tv", 6667);
        reader = new StreamReader(tcpClient.GetStream());
        writer = new StreamWriter(tcpClient.GetStream());
        writer.WriteLine("PASS " + twitchOauth);
        writer.WriteLine("NICK " + userName);
        writer.WriteLine("USER " + userName + " 8 * :" + userName);
        writer.WriteLine("JOIN #" + twitchChannel);
        writer.Flush();

    }

    // Start is called before the first frame update 
    void Start()
    {


        Connect();

    }

    // Update is called once per frame
    void Update()
    {
        if (!tcpClient.Connected)
        {
            Connect();
        }
 
        readChat();


    }
    void OnApplicationQuit()
    {

        tcpClient.Close();


    }
    void readChat()
    {
            if (tcpClient.Available > 0)
            {

                    message = reader.ReadLine();

                    if (message.Length != 0)
                    {
                        if (message == "PING :tmi.twitch.tv")
                        {
                            writer.WriteLine("PONG irc.twitch.tv");
                       
                        }
                        else if (message.Contains("PRIVMSG"))
                        {
                            Debug.Log("raw message: " + message);
                            string[] splitMsg = message.Split(':');
                            message = splitMsg[2].Trim();
                            string nickname = splitMsg[1].Substring(splitMsg[1].IndexOf('#')+1).Trim();
                            Debug.Log("name: " + nickname + ", message:" + message);
                            string[] splitCom = message.Split(' ');
                            if (splitCom[0] == "!add")
                            {
                                Debug.Log("spawn enemy ");
                                GameObject papuas = Instantiate(enemy, respawn.position, Quaternion.identity);
                                papuas.transform.position = new Vector3(papuas.transform.position.x, papuas.transform.position.y, 0);
                            }
                                
                        
            
                          

                        }   


                    }


            }
    }
}
