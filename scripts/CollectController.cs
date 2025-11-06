using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    public int myVelocity = 15;
    public int myValue = 1;

    private TextMeshProUGUI pointText;
    private int allCollectables;

    void Start()
    {
        allCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
    }
    void Update()
    {
        pointText = GameObject.Find("TxtPoints").GetComponent<TextMeshProUGUI>();
        this.transform.Rotate(new Vector3(myVelocity, myVelocity * 2, myVelocity * 3) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallPlayer"))
        {
            GetComponent<AudioSource>().Play();
            
            DMT.StaticStore.myCollecting = myValue;
            Debug.Log("Collected Amount: " + DMT.StaticStore.myCollecting);
            pointText.text = "Points: "+DMT.StaticStore.myCollecting+"/"+ allCollectables;
            
            // this.gameObject.SetActive(false);
            Destroy(gameObject, 1.0f);
        }
    }
}

