using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform rectTransform;
    float health;

    float divider;

    public PlayerMovement playerController;
    void Start()
    {
        // playerController = GetComponentInParent<PlayerMovement>();
        divider = playerController.health;
        //divider = health;
    }

    // Update is called once per frame
    void Update()
    {   
        health = playerController.health < 0 ? 0 : playerController.health;
        float Scale = health / divider;
        rectTransform.localScale = new Vector3(Scale,Scale,Scale);
    }
}
