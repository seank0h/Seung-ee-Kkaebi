using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvManager : MonoBehaviour{
    private Vector3 pos;

    // Start is called before the first frame update
    void Start(){
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update(){
        //보내는 쪽
        //pos = this.gameObject.transform.position;
        //sendCoord(0,  pos.x,pos.y,pos.z);

        //받는 쪽
        receiveCoord();
        //float step = 1.0f * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(pos, receivedPos, step);
    }



    public void sendCoord(int code, float x, float y, float z){
        client.tcp.sendMsg(code, x, y, z);
    }


    public void receiveCoord(){
        string[][] msg = client.tcp.receiveMsg();

        //case로 code에 따라 다르게 액션
        for(int i = 0; i < msg.Length; i++){
            
            switch(int.Parse(msg[i][1])){
                case 0:
                    this.gameObject.transform.position = new Vector3(float.Parse(msg[i][2]), float.Parse(msg[i][3]), float.Parse(msg[i][4]));
                    break;
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;

                default:
                    break;
            }
        }
    }
}
