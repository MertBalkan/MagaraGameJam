using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Concretes.Controllers
{
    public class BulletController : MonoBehaviour
    {
        private void Update()
        {
            Destroy(this.gameObject, 3.0f);
        }
    }
}