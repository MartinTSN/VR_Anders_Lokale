using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasteraser : MonoBehaviour
{

    [System.Serializable]
    public enum colors
    {
        White
    }

    public colors ChosenColor;

    public Board PaintingTarget;

    private RaycastHit hit;


    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, 0.05f))
        {
            if (hit.collider.tag == "board")
            {
                PaintingTarget = hit.collider.gameObject.GetComponent<Board>();
                Board board = PaintingTarget;
                board.SetColorEraser(ChosenColor);
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
