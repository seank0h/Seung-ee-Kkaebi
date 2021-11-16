using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class client : MonoBehaviour{
	#region private members 	

    public string clientID = "c1";

    public static client tcp;
    private String msg = "";

	private TcpClient socketConnection; 	
	private Thread clientReceiveThread; 	
	#endregion  	

	// Use this for initialization 	
	void Start () {
        if(tcp && tcp != this)
            Destroy(this);
        else
            tcp = this;

		ConnectToTcpServer();    
	}

	public void reconnectServer(){
		ConnectToTcpServer();
	}


    public void sendMsg(String message){
        SendMessage(clientID + "/" + message + "/#");
    }


    public string[][] receiveMsg(){
        string[] msgQueue = msg.Split('#');
        RemoveAt(ref msgQueue, msgQueue.Length-1);
        string[][] res = new string[msgQueue.Length][];

        for(int i=0; i < msgQueue.Length; i++){
            res[i] = msgQueue[i].Split('/');
            RemoveAt(ref res[i], res[i].Length-1);
        }

        return res;
    }


    private void printMessage(string[][] message){
        for(int i=0; i<message.Length; i++){
            for(int j = 0; j < message[i].Length; j++){
                Debug.Log(message[i][j]);
            }
        }
    }


    private static void RemoveAt<T>(ref T[] arr, int index){
        for (int a = index; a < arr.Length - 1; a++){
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }


	private void ConnectToTcpServer () { 		
		try {  			
			clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();  		
		}catch (Exception e) { 			
			Debug.Log("On client connect exception " + e); 		
		}
	} 


	private void ListenForData() { 		
		try { 			
			socketConnection = new TcpClient("143.248.2.25", 9000);  			
			Byte[] bytes = new Byte[1024];             
			while (true) { 				
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream()) { 					
					int length; 					
					// Read incomming stream into byte arrary. 					
					while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) { 						
						var incommingData = new byte[length]; 						
						Array.Copy(bytes, 0, incommingData, 0, length); 						
						// Convert byte array to string message. 						
						string serverMessage = Encoding.ASCII.GetString(incommingData); 

                        if(checkMsg(serverMessage)){
                            msg = serverMessage;
							//Debug.Log(serverMessage);
                        }else if(serverMessage.Contains("END GAME")){
							closeConn();
						}

						//Debug.Log("server message received as: " + serverMessage); 					
					} 				
				} 			
			}         
		}catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}

    private bool checkMsg(string serverMessage){
        string[] message = serverMessage.Split('/');
        if(String.Equals(message[message.Length-1], "#") && !message[0].Contains(clientID))
            return true;
        return false;
    }


	private void SendMessage(String clientMessage) {         
		if (socketConnection == null) {             
			return;         
		}  		

		try { 			
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream(); 			
			if (stream.CanWrite) { 				
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage); 				
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);           
			}         
		} 		
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}


	private void closeConn(){
		if(clientReceiveThread != null){
			clientReceiveThread.Abort();
		}
		socketConnection.Close();

		clientReceiveThread = null;
		socketConnection = null;
	}

	void OnApplicationQuit(){
		SendMessage("END GAME");
		closeConn();
	}
}
