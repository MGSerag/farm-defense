using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolObject : MonoBehaviour
{
    public float timeToHide = 3f;
    // Start is called before the first frame update
    private void Start()
	{
        Invoke("Hide", timeToHide);
	}



    // Update is called once per frame
    void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
