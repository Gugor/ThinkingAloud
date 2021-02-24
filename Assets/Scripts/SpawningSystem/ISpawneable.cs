using UnityEngine;

namespace SquareManShootTetris 
{ 
    public interface ISpawneable
    {
        Transform ITransform { get; }
        GameObject IGameObject { get; }

        int Durability { get; }


    }
}