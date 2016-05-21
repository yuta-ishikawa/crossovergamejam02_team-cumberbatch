﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// リザルト画面に表示するユニティちゃんの表情を変更する
public class ResultFaceChanger : MonoBehaviour {

	// ここはGameManagerクラスが確立したら消す
	private enum ScoreRank
	{
		None = -1, TooBad, Bad, Good, Great, Perfect
	};

	[SerializeField]
	private RawImage faceRawImage = null;
	[SerializeField]
	private ResultFaceImageObject images;
	[SerializeField, Tooltip("デバッグ兼確認用")]
	private ScoreRank rank = ScoreRank.None;

	private void SetFaceImage()
	{
		// 異常値チェック
		if(rank == ScoreRank.None)
		{
			Debug.LogAssertion("Rank Is Assertion!!!!");
			return;
		}
		
		// ランクに応じて表情設定
		faceRawImage.texture = images.textures[(int)rank];

		// nullチェック
		if (faceRawImage.texture != null) return;

		Debug.LogAssertion(rank + "Texture Is null!!!!");
}

	// Use this for initialization
	void Start () {
		SetFaceImage();
	}
	
}
