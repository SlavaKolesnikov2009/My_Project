using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject coin;
    public GameObject[] platforms;
    void Start()
    {
        platforms = GameObject.FindGameObjectsWithTag("PlatformCoin");
        for (int i = 0; i<platforms.Length; i++)
        {
            Vector3 position = platforms[i].transform.position;
            position.y+= 4f;
            Quaternion orientation = Quaternion.Euler(90, 0, 0);
            Instantiate(coin, position, orientation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
