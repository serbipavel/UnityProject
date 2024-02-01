using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform pointer;
    public Transform player;
    public Selectable previousSelected;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(player.transform.position, transform.forward);
        Debug.DrawRay(player.transform.position, transform.forward * 100, Color.red);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            pointer.position = hit.point;
            /* hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;*/
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (previousSelected && previousSelected != selectable)

            {
                previousSelected.Deselect();
                previousSelected = null;
            }
            if (selectable)
            {
                previousSelected = selectable;
                selectable.Select();
            }
        }
        else if (previousSelected)
        {
            previousSelected.Deselect();
            previousSelected = null;
        }
    }
}
