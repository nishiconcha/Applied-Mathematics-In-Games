using UnityEngine;
using UnityEngine.SceneManagement;

public class NoGoZone : MonoBehaviour
{
    public Transform player;
    public Renderer zoneRenderer;

    public float warningRadius = 3f;    // cube goes shake and red
    public float dangerRadius = 1f;     // instant restart when player touches
    public float maxTimeInWarning = 3f; // restart if stays too long

    private Vector3 originalPos;
    private float timeInWarning = 0f;
    private readonly Color normalColor = Color.white;
    private readonly Color warningColor = Color.red;

    void Start()
    {
        originalPos = transform.position;
        zoneRenderer = GetComponent<Renderer>();
    }

    // Updates if player is near the no go zone and gives warning
    void Update()
    {
        float dist = Vector3.Distance(player.position, originalPos);

        if (dist <= dangerRadius)
        {
            Restart();
            return;
        }

        if (dist <= warningRadius)
        {
            zoneRenderer.material.color = warningColor;
            transform.position = originalPos + Random.insideUnitSphere * 0.1f;

            timeInWarning += Time.deltaTime;
            if (timeInWarning >= maxTimeInWarning)
            {
                Restart();
            }
        }
        else
        {
            zoneRenderer.material.color = normalColor;
            transform.position = originalPos;
            timeInWarning = 0f;
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}