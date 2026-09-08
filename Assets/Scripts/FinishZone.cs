using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public Transform player;
    public GameObject winPanel;
    public float winRadius = 1.5f;

    void Start()
    {
        winPanel.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= winRadius)
        {
            winPanel.SetActive(true);
        }
    }
}