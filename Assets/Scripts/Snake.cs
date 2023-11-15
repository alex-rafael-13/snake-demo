using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //Setting the starting direction to the right
    private Vector2 _direction = Vector2.right;

    //Transform is a fundamental component in unity as it allows you to manipulate the position, rotation, and scale of a GameObject
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int InitialSize = 4;

    public Food foodInstance;

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.W)){
        //    _direction = Vector2.up;
        //} else if (Input.GetKeyDown(KeyCode.S)) {
        //    _direction = Vector2.down;
        //} else if (Input.GetKeyDown(KeyCode.D)){
        //    _direction = Vector2.right;
        //} else if (Input.GetKeyDown(KeyCode.A)){
        //    _direction = Vector2.left;
        //}

        if (_direction.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
        }

        // Check for input only if the snake is not moving vertically
        if (_direction.x == 0)
        {
            if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
        }
    }

    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }


        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }


    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetGame()
    {

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < InitialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;
        foodInstance.ResetFood();
        _direction = Vector2.right;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        if(other.tag == "Obstacle")
        {
            ResetGame();
        }


    }
}
