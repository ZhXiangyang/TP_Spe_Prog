using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool canShoot = true;
    private bool newBall = false;
    public GameObject[] prefabBubbles;
    public GameObject arrow;
    private GameObject newBubble;
    private GameObject oldBubble;
    public GameObject nextBubblePos;

    void Start()
    {
        newBubble = GameObject.Instantiate(prefabBubbles[Random.Range(0, prefabBubbles.Length - 1)]);
        newBubble.transform.position = nextBubblePos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RotateArrow();
    }

    private void RotateArrow()
    {
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = worldMouse - arrow.transform.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle <= 10 && angle > -90)
        {
            angle = 10;
        }
        else if (angle >= 170 || (angle >= -180 && angle <= -90))
        {
            angle = 170;
        }
        //Debug.Log(angle);
        arrow.transform.localRotation = Quaternion.Euler(0, 0, (angle) - 90);

        if (!newBall)
        {
            newBall = !newBall;
            oldBubble = newBubble;
            oldBubble.transform.position = arrow.transform.position;
            newBubble = GameObject.Instantiate(prefabBubbles[Random.Range(0, prefabBubbles.Length - 1)]);
            newBubble.transform.position = nextBubblePos.transform.position;
        }
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            direction.Normalize();
            oldBubble.AddComponent<Projectile>().Initialize(direction);
            Bubble bubble = oldBubble.GetComponent<Bubble>();
            bubble.state = Bubble.State.moving;
            newBall = !newBall;
        }
    }
}
