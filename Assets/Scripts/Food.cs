using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D playArea;

    //Ran right when game starts
    private void Start()
    {
        RandomizePosition();
    }

    //Randomizer for food position
    private void RandomizePosition()
    {
        Bounds bounds = this.playArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    //Only available if object is 2D trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            RandomizePosition();   
        }

    }
}
