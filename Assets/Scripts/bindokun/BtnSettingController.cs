using UnityEngine;

public class BtnSettingController : MonoBehaviour {

    public GameObject scrollView;
 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        scrollView.SetActive(!scrollView.activeSelf);
    }
}
