using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastpen : MonoBehaviour
{
    [System.Serializable]
    public enum colors
    {
        Red,
        Green,
        Blue,
        White
    }

    public colors ChosenColor;

    private Board PaintingTarget;

    private RaycastHit hit;
    
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward * -1, out hit, 1.4f))
        {
            if (hit.collider.tag == "board")
            {
                PaintingTarget = hit.collider.gameObject.GetComponent<Board>();
                Board board = PaintingTarget;
                board.SetColorPen(ChosenColor);
                Vector2 textureCoord = hit.textureCoord;
                float x = textureCoord.x;
                Vector2 textureCoord2 = hit.textureCoord;
                board.setPen(x, textureCoord2.y);
                PaintingTarget.penUp(false);

            }
        }
        else
        {
            PaintingTarget.penUp(true);
        }
    }
}
