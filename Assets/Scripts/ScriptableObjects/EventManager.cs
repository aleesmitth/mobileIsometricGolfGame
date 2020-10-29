﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EventManager", menuName = "ScriptableObjects/EventManager")]
public class EventManager : ScriptableObject {    
    public static event Action onBallHit;
    public static event Action onBallDragged;
    public static event Action onCoinGrabbed;
    public static event Action onLevelFinished;
    public static void OnBallHit() {
		onBallHit?.Invoke();
	}
	
	public static void OnBallDragged() {
		onBallDragged?.Invoke();
	}

	public static void OnCoinGrabbed() {
		onCoinGrabbed?.Invoke();
	}

	public static void OnLevelFinished() {
		onLevelFinished?.Invoke();
	}
}
