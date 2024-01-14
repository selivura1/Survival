using Selivura.Player;
using UnityEngine;

namespace Selivura
{
    public class DroneItem : Item
    {
        [SerializeField] DroneBT _droneBrefab;
        DroneBT _spawned;
        public override void OnPickup(PlayerUnit player)
        {
            base.OnPickup(player);
            _spawned = Instantiate(_droneBrefab);
            _spawned.Summoner = player;
        }
        public override void OnRemove(PlayerUnit player)
        {
            base.OnRemove(player);
            Destroy(_spawned.gameObject);
        }
    }
}