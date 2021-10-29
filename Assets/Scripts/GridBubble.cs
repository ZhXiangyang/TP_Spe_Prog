using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBubble : MonoBehaviour
{
    public GameObject origin;
    public float bubbleSize = 4.0f;
    public int rows = 12;
    public int cols = 12;
    public GameObject[] prefabBubbles;

    public int indexX;
    public int indexY;

    private float rowOffset;
    private float rowStart;
    private Vector3 pos;

    void Start()
    {
        rowOffset = Mathf.Sqrt((bubbleSize * bubbleSize) - ((bubbleSize * bubbleSize * 0.25f)));
        rowStart = origin.transform.position.x -(cols * bubbleSize / 2.0f - 0.25f * bubbleSize);
        pos = new Vector3(rowStart, rows * rowOffset / 2.0f, 0.0f);
        InstantiateBubbles();
    }

    private void Update()
    {
        Delay(20);
        AddRow();
    }

    private void InstantiateBubbles()
    {
        for (int i = 0; i < rows; i++)
        {
            if ((i % 2) == 1)
                pos.x -= bubbleSize / 2.0f;
            for (int j = 0; j < cols; j++)
            {
                GameObject go = GameObject.Instantiate(prefabBubbles[Random.Range(0, prefabBubbles.Length - 1)]);
                Bubble bubble = go.GetComponent<Bubble>();
                bubble.indexX = i;
                bubble.indexY = j;
                bubble.state = Bubble.State.merged;
                go.transform.position = pos + origin.transform.position;
                pos.x += bubbleSize;
            }
            pos.x = rowStart;
            pos.y -= rowOffset;
        }
    }

    private void AddRow()
    {

    }

    private IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
