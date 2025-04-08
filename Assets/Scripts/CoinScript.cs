using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject coin;
    public GameObject[] platforms;
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("PlatformCoin");
        Debug.Log(platforms);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
