using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {

/*
Shoots a bullet in a direction
shooting point is the point where the bullet spawns, determines direction 
*/
public void shoot(GameObject shootingPoint, GameObject bulletPrefab);

public void reload();


}


