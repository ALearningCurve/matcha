using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy : ScriptableObject
{
    public float moveSpeed;
    public float fireRate;
    public Sprite sprite;
    
    public enum GunType
    {
        Pistol,
        Shotgun,
        Sniper,
        ExpandingBullet,
        BurstShot
    
    
    }

    public GunType EnemyGun;

}
