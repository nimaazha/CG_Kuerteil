using UnityEngine;
using UnityEngine.UI;


public class LeaveArena : MonoBehaviour
{

    Transform targetPlayer;

    public Text alertText;

    void Awake()
    {
        // Set up the references.
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void OnTriggerExit(Collider collider)
    {
        alertText.text = "You are leaving the Arena soldier... You have 15 sec or you will die!";
        StartToKill();
    }

    void OnTriggerEnter(Collider collider)
    {
        alertText.text = "";
    }

    void StartToKill()
    {

    }
}
