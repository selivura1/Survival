using System.Collections.Generic;
using UnityEngine;

namespace Selivura
{
    public class DamageOverTimeArea : Area
    {
        public int DamagePerSecond = 5;
        Timer _damageTimer = new Timer(0, 0);
        private List<Unit> _insideUnits = new List<Unit>();
        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Unit unit))
                _insideUnits.Add(unit);
        }
        protected override void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Unit unit))
                _insideUnits.Remove(unit);
        }
        protected override void FixedUpdate()
        {
            if (_damageTimer.Expired)
            {
                List<Unit> inactive = new List<Unit>();
                for (int i = 0; i < _insideUnits.Count; i++)
                {
                    if (!_insideUnits[i].gameObject.activeSelf)
                    {
                        inactive.Add(_insideUnits[i]);
                        continue;
                    }
                    _insideUnits[i].TakeDamage(DamagePerSecond);
                    _damageTimer = new Timer(1, Time.time);
                }
                foreach (Unit unit in inactive)
                {
                    _insideUnits.Remove(unit);
                }
            }
        }
    }
}
