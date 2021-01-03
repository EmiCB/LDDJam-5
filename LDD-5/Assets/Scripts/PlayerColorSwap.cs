using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerColorSwapIndex {
    HeadOutline = 105,
    HeadFill = 155,
    ArmOutline = 217,
    ArmFill = 215,
    LegOutline = 106,
    LegFill = 153,
}

public class PlayerColorSwap : MonoBehaviour {
    Texture2D mColorSwapTex;
    Color[] mSpriteColors;

    SpriteRenderer mSpriteRenderer;

    PlayerController player;

    void Awake() {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerController>();
        InitColorSwapTex();
        mColorSwapTex.Apply();
    }

    void Update() {
        Color headColor = ColorPicker.HeadAbilityColorPicker(player.currentHeadAbility);
        SwapColor(PlayerColorSwapIndex.HeadFill, headColor);
        SwapColor(PlayerColorSwapIndex.HeadOutline, DarkenColor(headColor));
        
        Color armColor = ColorPicker.ArmAbilityColorPicker(player.currentArmAbility);
        SwapColor(PlayerColorSwapIndex.ArmFill, armColor);
        SwapColor(PlayerColorSwapIndex.ArmOutline, DarkenColor(armColor));
        
        Color legColor = ColorPicker.LegAbilityColorPicker(player.currentLegAbility);
        SwapColor(PlayerColorSwapIndex.LegFill, legColor);
        SwapColor(PlayerColorSwapIndex.LegOutline, DarkenColor(legColor));

        mColorSwapTex.Apply();
    }
    
    private void InitColorSwapTex() {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i) {
            colorSwapTex.SetPixel(
                i, 
                0, 
                new Color(0.0f, 0.0f, 0.0f, 0.0f)
            );
        }

        colorSwapTex.Apply();

        mSpriteRenderer.material.SetTexture("_SwapTex", colorSwapTex);

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    private void SwapColor(PlayerColorSwapIndex index, Color color) {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }

    private Color DarkenColor(Color color) {
        float h, s, v;
        Color.RGBToHSV(color, out h, out s, out v);
        s = s * 0.8f;
        v = v * 0.6f;
        return Color.HSVToRGB(h, s, v);
    }
}
