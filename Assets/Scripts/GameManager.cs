using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] prefabBubbles;
    public GameObject arrow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateArrow();
    }

    private void InitBubbles()
    {
        //_marbleQueue = new MarbleQueue();
        //for (int i = 0; i < count; i++)
        //{
        //    GameObject prefab = prefabMarbles[Random.Range(0, prefabMarbles.Length)];
        //    GameObject go = GameObject.Instantiate(prefab, path[0].position, Quaternion.identity);
        //    Marble marble = go.GetComponent<Marble>();
        //    marble.index = i;
        //    marble.UpdateMove(path, marbleSize * (float)(count - i));
        //    _marbleQueue.Marbles.Add(marble);
        //}
    }

    private void RotateArrow()
    {
        Vector3 worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = worldMouse - arrow.transform.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x);
        arrow.transform.localRotation = Quaternion.Euler(0, 0, (angle * Mathf.Rad2Deg) - 90);
    }
}
