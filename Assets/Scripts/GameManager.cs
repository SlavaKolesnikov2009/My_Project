using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject dieScreen;
    public GameObject player;
    public Camera camera;
    public PlayerScript PlayerScript;
    public void StartScreen()
    {
        startScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void DieScreen()
    {
        PlayerScript.die = true;
        Debug.Log(PlayerScript.die);
        dieScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.transform.position = new Vector3(-143, 38, 92);
        camera.enabled = false;
    }
}
