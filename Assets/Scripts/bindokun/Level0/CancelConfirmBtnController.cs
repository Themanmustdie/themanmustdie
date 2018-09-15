using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CancelConfirmBtnController : MonoBehaviour {

    public Button btnConfirm;
    public Button btnCancel;

	// Use this for initialization
	void Start () {
        btnConfirm.onClick.AddListener(DestoryDialog);
        btnCancel.onClick.AddListener(DestoryDialog);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void DestoryDialog()
    {
        gameObject.SetActive(false);
    }
}
