﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// TitleSceneに関わる処理を管理するコンポ―ネント
public class TitleController : MonoBehaviour {

	[SerializeField]
	private FadeParam fadeParam;

	void Start()
	{
		ScreenFadeManager.Instance.FadeOut(fadeParam.time, fadeParam.color,
			delegate { Debug.Log("Fade Out OK"); });
	}

	// スタートボタンをクリック
	public void OnClickStartButton()
	{
		// フェードアウト中は反応しないように
		if (ScreenFadeManager.Instance.isFadeAction) return;

		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Main");
				// メインに遷移後すぐにFadeInを完了させる
				ScreenFadeManager.Instance.FadeIn(0.01f, new Color(1.0f, 1.0f, 1.0f), delegate { Debug.Log("OK"); });
			});
	}

}
