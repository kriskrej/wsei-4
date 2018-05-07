﻿using UnityEngine;

public class WitcherLogic : MonoBehaviour {
    public WitcherVisualisation ui;
    public Animator animator;

    public void Start() {
        ui.BarX = 500;
    }

    float speed = 100;

    void Update() {
        ui.PointX = ui.MouseX;
        if (IsMouseOverBar()) {
            ui.BarX+=Time.deltaTime * speed;
        }
        else {
            ui.BarX-= Time.deltaTime * speed;
        }
        ui.BarWidth = (1000-ui.BarX)/8;
        animator.SetFloat("Drunk", 1f-ui.BarX/1000f);
        if(ui.BarX<1)GameManager.ShowRespawnScreen("You have lost. Everything.");
        
    }

    bool IsMouseOverBar() {
        return Mathf.Abs(ui.BarX - ui.MouseX) < ui.BarWidth / 2;
    }


	public float GetKnobPositionInNextFrame(float currentPosition01, float mousePosition01) {
        return (currentPosition01+mousePosition01)/2;
    }
}
