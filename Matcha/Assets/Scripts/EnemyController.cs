using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy EnemySO;

    [SerializeField] private Transform enemyTransform;

    [SerializeField] private Transform pointA, pointB;

    [SerializeField] private SpriteRenderer ball;

    private Vector3 currentTarget;

    public IWeapon weapon;

    [SerializeField] private GameObject shootingPoint;

    [SerializeField] private GameObject bulletPrefab;

    private Color nextColor;

    [Header("Scriptable Object")]
    [SerializeField] private ColorList theColors;

    [SerializeField] private SpriteRenderer gunSprite;

    [SerializeField] private SpriteRenderer arrow;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = pointB.position;

        switch (EnemySO.EnemyGun)
        {
            case Enemy.GunType.Pistol:
                this.weapon = new Pistol();
                break;
            case Enemy.GunType.Shotgun:
                this.weapon = new Shotgun();
                break;
            case Enemy.GunType.Sniper:
                this.weapon = new Sniper();
                break;
            case Enemy.GunType.ExpandingBullet:
                this.weapon = new ExpandingBullet();
                break;
            case Enemy.GunType.BurstShot:
                this.weapon = new BurstShot();
                break;
        }

        SetGunSprite();


        int randomColor = Random.Range(0, theColors.colors.Count);


        Color color = theColors.colors[randomColor];
        this.nextColor = color;

        ball.color = color;

        InvokeRepeating("Shoot", 0f, 2f);

    }


    // Update is called once per frame
    void Update()
    {
        if(enemyTransform.position.x == pointA.position.x)
        {
            currentTarget = pointB.position;
            enemyTransform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            //StartCoroutine(Shoot());
            enemyTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if(enemyTransform.position.x == pointB.position.x)
        {
            currentTarget = pointA.position;
            enemyTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            //StartCoroutine(Shoot());
            enemyTransform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }

        currentTarget = new Vector3(currentTarget.x, enemyTransform.position.y, enemyTransform.position.z);
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, currentTarget, EnemySO.moveSpeed * Time.deltaTime);

    }




    private void Shoot()
    {
        int randomColor = Random.Range(0, theColors.colors.Count);

        this.weapon.shoot(this.shootingPoint, this.bulletPrefab, this.nextColor);

        Color color = theColors.colors[randomColor];
        this.nextColor = color;

        ball.color = color;
        arrow.color = color;
        gunSprite.color = color;
       

    }


    private void SetGunSprite()
    {
        gunSprite.sprite = EnemySO.sprite;
    }


}
