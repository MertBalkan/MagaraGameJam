using System.Collections;
using System.Collections.Generic;
using MagaraGameJam.Abstracts.Combats;
using MagaraGameJam.Concretes.Combats;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class EnemyArmController
    {
        public void AimToPlayer(Transform target, GameObject arm, EnemyController enemyController)
        {
            if (target != null)
            {
                Vector3 aimDis = (enemyController.transform.position - target.transform.position).normalized;

                float angle = Mathf.Atan2(aimDis.y, aimDis.x);
                float degreeAngle = angle * Mathf.Rad2Deg - 90;

                Vector3 rotationVector = new Vector3(0, 0, degreeAngle);
                arm.transform.localRotation = Quaternion.Euler(rotationVector);
            }

        }
    }
}