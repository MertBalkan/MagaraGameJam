using MagaraGameJam.Abstracts.Movements;
using UnityEngine;

namespace MagaraGameJam.Utilities.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
        float MoveSpeed { get; }
    }
}