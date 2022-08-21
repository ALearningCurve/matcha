using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AWeapon : MonoBehaviour, IWeapon
{
    protected SpriteRenderer gunSprite;

    protected SpriteRenderer bulletSprite;

    [SerializeField]
    protected float bulletSpeed;

    protected Color color1 = new Color(1f, 1f, 1f, 1f);

    protected Color color2 = new Color(216f / 255f, 94f / 255f, 0f, 1f);

    protected Color
        color3 = new Color(204f / 255f, 121f / 255f, 167f / 255f, 1f);

    protected Color color4 = new Color(0f, 114f / 255f, 178f / 255f, 1f);

    protected Color
        color5 = new Color(240f / 255f, 228f / 255f, 66f / 255f, 1f);

    protected List<Color> colors;

    public abstract void shoot(GameObject shootingPoint, GameObject bulletPrefab);

    public void reload()
    {
    }
}
