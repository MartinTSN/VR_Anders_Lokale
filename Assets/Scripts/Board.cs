using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    private float penX;

    private float penY;

    private bool penLifted = true;

    private bool penLiftedLastFrame = true;

    private Texture2D boardTex;

    private static int texSizeX = 1000;

    private static int texSizeY = 1000;

    private int lastPaintX;

    private int lastPaintY;

    public int penWidth = 5;

    public int penHeight = 5;

    public int eraserWidth = 5;

    public int eraserHeight = 5;

    private Color32[] red;

    private Color32[] green;

    private Color32[] blue;

    private Color32[] white;

    private bool touched;

    private Color32[] chosenColor;

    private void Start()
    {
        Renderer component = GetComponent<Renderer>();
        boardTex = new Texture2D(texSizeX, texSizeY);
        component.material.mainTexture = boardTex;
        red = Enumerable.Repeat(new Color32(byte.MaxValue, 0, 0, byte.MaxValue), penWidth * penHeight).ToArray();
        green = Enumerable.Repeat(new Color32(0, byte.MaxValue, 0, byte.MaxValue), penWidth * penHeight).ToArray();
        blue = Enumerable.Repeat(new Color32(0, 0, byte.MaxValue, byte.MaxValue), penWidth * penHeight).ToArray();
        white = Enumerable.Repeat(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue), eraserWidth * eraserHeight).ToArray();
        for (int y = 0; y < texSizeY; y++)
        {
            for (int x = 0; x < texSizeX; x++)
            {
                boardTex.SetPixel(x, y, Color.white);
            }
        }
        boardTex.Apply();
    }
    private void Update()
    {
        int num;
        int num2;
        if (chosenColor == white)
        {
            num = (int)(penX * (float)texSizeX - (float)(eraserWidth / 2));
            num2 = (int)(penY * (float)texSizeY - (float)(eraserHeight / 2));
        }
        else
        {
            num = (int)(penX * (float)texSizeX - (float)(penWidth / 2));
            num2 = (int)(penY * (float)texSizeY - (float)(penHeight / 2));
        }
        if (!penLiftedLastFrame)
        {
            if (chosenColor == white)
            {
                boardTex.SetPixels32(num, num2, eraserWidth, eraserHeight, chosenColor);
            }
            else
            {
                boardTex.SetPixels32(num, num2, penWidth, penHeight, chosenColor);
            }
        }
        if (!penLifted)
        {
            boardTex.Apply();
        }
        lastPaintX = num;
        lastPaintY = num2;
        penLiftedLastFrame = penLifted;
    }

    public void SetColorPen(Raycastpen.colors color)
    {
        switch (color)
        {
            case Raycastpen.colors.Red:
                chosenColor = red;
                break;
            case Raycastpen.colors.Green:
                chosenColor = green;
                break;
            case Raycastpen.colors.Blue:
                chosenColor = blue;
                break;
            case Raycastpen.colors.White:
                chosenColor = white;
                break;
        }
    }

    public void SetColorEraser(Raycasteraser.colors color)
    {
        switch (color)
        {
            case Raycasteraser.colors.White:
                chosenColor = white;
                break;
        }
    }

    public void setPen(float x, float y)
    {
        penX = x;
        penY = y;
    }

    public void penUp(bool up)
    {
        penLifted = up;
    }
}
