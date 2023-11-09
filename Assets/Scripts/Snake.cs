using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private void Update()
    {
        if(InterfaceTypeAttribute.GetKeyDown(KeyCode.W)){
            _direction = Vector2.up;
        }
    } 
}
