using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private float canShoot;
    [SerializeField] private float timeBeforeNextShoot;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > canShoot && !PauseMenu.isPause && !TutorialMenu.isHowto )
        {
            canShoot = Time.time + timeBeforeNextShoot;
            SoundManage.instance.Play(SoundManage.SoundName.DropBox);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, 10f);
            Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 projectVelocity = CalculateProjectileVelocity(shootPoint.position, targetPos, 1f);

            Rigidbody2D shoot = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            shoot.velocity = projectVelocity;

        }

        Vector2 CalculateProjectileVelocity(Vector2 startPoint, Vector2 endPoint, float time)
        {
            //find distance startpoint --> endpoint
            Vector2 distance2D = endPoint - startPoint;
            Vector2 distance = distance2D;
            distance.y = 0f;

            float distX = distance.magnitude;
            float distY = distance2D.y;

            float velocityX = distX / time;
            float velocityY = distY / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

            Vector2 result = distance.normalized;
            result *= velocityX;
            result.y = velocityY;
            return result;
        }
    }
}

