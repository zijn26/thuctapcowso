using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

enum BarValue
{
}
public class MonsterBar :HungMono
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected Color [] colors = {Color.gray , Color.red , Color.yellow , new Color(1.0f, 0.5f, 0.0f) ,Color.green};
    [SerializeField] protected Dictionary<float ,Color > colorBar = new Dictionary<float, Color>(
        new Dictionary<float, Color>()
        {
            {0 , Color.gray},
            {0.26f , Color.red},
            {0.60f , Color.yellow},
            {0.80f, new Color(1.0f, 0.5f, 0.0f)},
            {0.96f , Color.green}
            // tim so lon hon nhung khong nho hon cac gia tri moc
        }
    );
    [SerializeField] protected Color colorInbar;
    public void SetBar(float value)
    {
        if (spriteRenderer == null) return;
        foreach (var item in colorBar)
        {
            if(item.Key <= value)
            {
                colorInbar = item.Value;
            }
        }
        spriteRenderer.color = colorInbar;
    }
    protected override void LoadComponent()
    {
        if(spriteRenderer != null) {
           return;
        };
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
}
