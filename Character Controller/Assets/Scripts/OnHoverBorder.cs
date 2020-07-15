using UnityEngine;

public class OnHoverBorder : MonoBehaviour
{
    public Material border;
    public Material nonBorder;

    void OnMouseOver()
    {
        GetComponent<Renderer>().material = border;
        if (Input.GetKeyDown())
    }


    void OnMouseExit()
    {
        GetComponent<Renderer>().material = nonBorder;
    }
}
