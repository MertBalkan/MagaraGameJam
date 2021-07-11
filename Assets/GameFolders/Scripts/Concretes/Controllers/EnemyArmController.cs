using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class EnemyArmController
    {
        public void AimToPlayer(Transform target, GameObject arm)
        {
            Vector3 aimDis = (target.transform.localPosition).normalized;

            float angle = Mathf.Atan2(aimDis.y, aimDis.x);
            float degreeAngle = angle * Mathf.Rad2Deg + 90;

            Vector3 rotationVector = new Vector3(0, 0, Mathf.Abs(degreeAngle));
            arm.transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}