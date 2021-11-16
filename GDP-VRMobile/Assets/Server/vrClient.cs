using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vrClient : MonoBehaviour{
    public static vrClient cl;

    //VR -> Mobile
    private int bulletCol=0, catchMobile=0, dustClean=0, isFlare=0;  //boolean
    private int vrPos=-1;  //0~3
    public GameObject lHand, rHand, flare;
    private Vector3 lPos, rPos, flarePos;  //positions (x,y,z)

    //Mobile -> VR
    public GameObject player;
    private Vector3 playerPos;
    private Vector3 playerRot;
    private int playerMat=0, prop=0, life=2, dustStorm=0, startNPCMove=0;
    private string curse="0000", NPCMat="00000";
    

    // Start is called before the first frame update
    void Start(){
        if(cl && cl != this)
            Destroy(this);
        else
            cl = this;

        playerPos = new Vector3(0,0,0);
        playerRot = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update(){
        sendMessage();
        decodeMsg();
    }

    public void sendMessage(){
        string lHandCoord = formatCoord(lHand);
        string rHandCoord = formatCoord(rHand);
        string flareCoord = formatCoord(flare);
        
        // Formatting
        string message = lHandCoord + "/" + rHandCoord + "/" + flareCoord + "/" + bulletCol.ToString() + "/" + catchMobile.ToString() + "/" + dustClean.ToString() + "/" + isFlare.ToString() + "/" + vrPos.ToString();
        
        client.tcp.sendMsg(message);
    }

    public void decodeMsg(){
        string[][] msg = client.tcp.receiveMsg();
        for(int i = 0; i < msg.Length; i++){
            if(msg[i].Length != 14)
                continue;

            player.GetComponent<Transform>().position = new Vector3(float.Parse(msg[i][1]), float.Parse(msg[i][2]), float.Parse(msg[i][3]));
            player.GetComponent<Transform>().eulerAngles = new Vector3(float.Parse(msg[i][4]), float.Parse(msg[i][5]), float.Parse(msg[i][6]));
            
            setPlayerMat(int.Parse(msg[i][7]));
            setProp(int.Parse(msg[i][8]));
            setLife(int.Parse(msg[i][9]));
            setDustStrom(int.Parse(msg[i][10]));
            setCurse(msg[i][11]);
            setstartNPCMove(int.Parse(msg[i][12]));
            setNPCMat(msg[i][13]);
        }
    }


    public string getNPCMat(){
        return NPCMat;
    }

    public void setNPCMat(string NPCMat){
        this.NPCMat = NPCMat;
    }

    public string getCurse(){
        return curse;
    }

    public void setCurse(string curse){
        this.curse = curse;
    }

    public int getstartNPCMove(){
        return startNPCMove;
    }

    public void setstartNPCMove(int startNPCMove){
        this.startNPCMove = startNPCMove;
    }

    public int getDustStrom(){
        return dustStorm;
    }

    public void setDustStrom(int storm){
        this.dustStorm = storm;
    }

    public int getLife(){
        return life;
    }

    public void setLife(int life){
        this.life = life;
    }

    public int getProp(){
        return prop;
    }

    public void setProp(int prop){
        this.prop = prop;
    }

    public int getPlayerMat(){
        return playerMat;
    }

    public void setPlayerMat(int mat){
        this.playerMat = mat;
    }





    public void setVRPos(int vrPos){
        this.vrPos = vrPos;
    }

    public int getVRPos(){
        return vrPos;
    }

    public void setIsFlare(int isFlare){
        this.isFlare = isFlare;
    }

    public int getIsFlare(){
        return isFlare;
    }

    public void setDustClean(int dustClean){
        this.dustClean = dustClean;
    }

    public int getDustClean(){
        return dustClean;
    } 

    public void setCatchEvent(int catchEvent){
        this.catchMobile = catchEvent;
    }

    public int getCatchEvent(){
        return catchMobile;
    } 

    public void setBulletCollision(int collision){
        this.bulletCol = collision;
    }

    public int getBulletCollision(){
        return bulletCol;
    }

    private string formatCoord(GameObject obj){
        Vector3 pos = obj.GetComponent<Transform>().position;
        return pos.x.ToString() + "/" + pos.y.ToString() + "/" + pos.z.ToString();
    }
}