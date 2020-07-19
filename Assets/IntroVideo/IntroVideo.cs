using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour 
{
	private UnityEngine.Video.VideoPlayer videoPlayer;

	void Start () 
	{
		videoPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer> ();

	}

	private void Update ()
	{
		if(videoPlayer.time > 47f)
			SceneManager.LoadScene (1);
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene (1);
	}
}
