using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagaraGameJam.Utilities.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
        float MoveSpeed{get;}
    }
}