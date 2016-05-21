﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Reaction : MonoBehaviour {

	[SerializeField]
	private Sprite[] judgeResultSprites;
	[SerializeField]
	private GameObject jugmentResultImage;

	void Start () {
		CreateReaction (GameManager.JudgementState.PERFECT, Vector3.zero); //DBEUG
	}

	public void CreateReaction(GameManager.JudgementState judge, Vector3 judgeResultPosition) {
		// 五段階評価の表示
		GameObject judgeResult = GameObject.Instantiate (jugmentResultImage) as GameObject;
		judgeResult.transform.SetParent (this.transform);
		judgeResult.GetComponent<Image> ().sprite = judgeResultSprites [(int)judge];
		judgeResult.GetComponent<RectTransform>().localPosition = judgeResultPosition;

		// ボイスの再生
		string voiceName = "";
		switch (judge){
		case GameManager.JudgementState.MISS:
			voiceName = "SE_sample";
			break;
		case GameManager.JudgementState.BAD:
			voiceName = "SE_sample";
			break;
		case GameManager.JudgementState.POOR:
			voiceName = "SE_sample";
			break;
		case GameManager.JudgementState.GOOD:
			voiceName = "SE_sample";
			break;
		case GameManager.JudgementState.GREAT:
			voiceName = "SE_sample";
			break;
		case GameManager.JudgementState.PERFECT:
			voiceName = "SE_sample";
			break;
		}
		AudioManager.Instance.PlaySE(voiceName);

		// スコア加算
		GameManager.Instance.AddScore(judge);
	}
}