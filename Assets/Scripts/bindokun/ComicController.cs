using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicController : MonoBehaviour {

    public GameObject[] comics = new GameObject[7];

    private int curIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnClickComic()
    {
        if (curIndex >= comics.Length)
        {
            return;
        }
        if(curIndex > 0)
        {
           // comics[curIndex - 1].
        }
       
    }

}
