using UnityEngine;

public class BtnSettingController : MonoBehaviour {

    public GameObject btnPrompt;
    public GameObject btnReplay;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        btnPrompt.SetActive(!btnPrompt.activeSelf);
        btnReplay.SetActive(!btnReplay.activeSelf);
    }
}
