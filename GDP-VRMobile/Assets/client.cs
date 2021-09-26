using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class client : MonoBehaviour{
	#region private members 	

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


	void Update () {

	}

	public void reconnectServer(){
		ConnectToTcpServer();
	}

    public void sendMsg(String msg){
        SendMessage(msg); 
    }

    public string receiveMsg(){
        decodeMsg();
        return msg;
    }


    private void decodeMsg(){

    }




	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer () { 		
		try {  			
			clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();  		
		} 		
		catch (Exception e) { 			
			Debug.Log("On client connect exception " + e); 		
		} 	
	} 



	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
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
                        msg = serverMessage;

						if(msg.Contains("END GAME")){
							closeConn();
						}

						Debug.Log("server message received as: " + serverMessage); 					
					} 				
				} 			
			}         
		}         
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	}



	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
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
