using UnityEngine;

public class AuroraScript : MonoBehaviour
{
    private void OnMouseDown() //Let's make Dr. Aurora blue for fun!
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDrag() 
    {
        Vector2 place = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(place.x, place.y);
    }

}
