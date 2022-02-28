using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementB : MonoBehaviour
{
    // Rigidbody2D rb;
    // float horizontalMove = 0f;
    // float verticalMove = 0f;
    Vector2 snakeDirection = Vector2.right;

    // making grow process
    private List<Transform> _segments;
    public Transform segmentPrefab;

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        _segments = new List<Transform>();
        Debug.Log("before--------" + _segments);
        _segments.Add(this.transform);

        Debug.Log("after-------------" + _segments);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            snakeDirection = Vector2.right;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            snakeDirection = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            snakeDirection = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            snakeDirection = Vector2.down;
        }
        // horizontalMove = Input.GetAxisRaw("Horizontal");
        // verticalMove = Input.GetAxisRaw("Vertical");

        // Debug.Log(snakeDirection);
        // Debug.Log("horizon: " + horizontalMove);
        // Debug.Log("vertical: " + verticalMove);
    }

    void FixedUpdate()
    {
        // make the snake grow
        Debug.Log("InFixed22222----------normalSegment:" + _segments);
        Debug.Log("inFixed---------count:" + _segments.Count);

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            Debug.Log("inLoop1111---------" + _segments);
            Debug.Log("inLoopCount---------" + _segments.Count);
            Debug.Log("inLoop[i]---------: " + i);
            // Debug.Log("inLoopSegment[i]------------: " + _segments[i]); // this is a clone
            // Debug.Log("inLoopBeforeSegment[i]------------: " + _segments[i].position); // tell the current position of the object
            // 1 - 1
            _segments[i].position = _segments[i - 1].position; // actual position is here
            // 1 - 0

            Debug.Log("inLoopAfter[i]---------: " + i);
            // Debug.Log("inLoopSegment[i]------------: " + _segments[i].position); // tell the current position of the object after -1
        }
        Debug.Log("outOfLoop----------------");

        
        this.transform.position = new Vector2(
            Mathf.Round(this.transform.position.x) + snakeDirection.x,
            Mathf.Round(this.transform.position.y) + snakeDirection.y 
        );

        
        // Debug.Log(this.transform.position);
        // Debug.Log("horizon " + horizontalMove);
        // Debug.Log("vertical " + horizontalMove);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
        }
        else if(other.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
