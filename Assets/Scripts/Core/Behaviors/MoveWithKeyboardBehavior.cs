﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Input Keys
public enum InputKeyboard{
    arrows = 0, 
    wasd = 1
}
public class MoveWithKeyboardBehavior : AgentBehaviour
{
    public GameManager gameManager;
    public InputKeyboard inputKeyboard;

    public void Start(){
        GetComponent<CelluloAgent>().SetVisualEffect(0, GameSetup.color, 0);
    }

    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linear = new Vector3(0,0,0);

        if(GameManager.isPlaying == true){
            float horizontal;
            float vertical;
            if(inputKeyboard == 0){
                horizontal = Input.GetAxis("Horizontal_Arrow");
                vertical = Input.GetAxis("Vertical_Arrow");
            }else{
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
            }
            steering.linear = new Vector3(horizontal, 0, vertical) * agent.maxAccel;
            steering.linear = this.transform.parent.TransformDirection(Vector3.ClampMagnitude(steering.linear , agent.maxAccel));
        }
        
        return steering;
    }

    public override void OnCelluloLongTouch(int key){
        gameManager.StartGame();
    }
}
