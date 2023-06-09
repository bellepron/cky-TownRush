using EZ_Pooling;
using System;
using TownRush.Enums;
using TownRush.Interfaces;
using TownRush.Managers;
using UnityEngine;

namespace TownRush.Abstracts
{
    public abstract class HealthControllerAbstract : MonoBehaviour, ITarget, IDamageable
    {
        public event Action<int> UpdateHealthEvent;

        [field: SerializeField] public OwnerTypes OwnerType { get; set; }
        [field: SerializeField] public int Health { get; set; }
        public Vector3 GetPosition() => transform.position;

        public virtual void Initialize(OwnerTypes ownerType, int health)
        {
            OwnerType = ownerType;
            Health = health;

            EventManager.Instance.TriggerAddTarget(this);
        }

        protected virtual void OnDisable()
        {
            UpdateHealthEvent = null;

            EventManager.Instance.TriggerRemoveTarget(this);
        }

        public virtual void GetDamage(OwnerTypes damageFromWho, int damage)
        {
            Health = Health - damage;

            if (Health > 0)
            {

            }
            else
            {
                Health = 0;

                Death();
            }

            TriggerUpdateHealthEvent();
        }

        public virtual void Death()
        {
            EZ_PoolManager.Despawn(transform);
        }

        protected virtual void TriggerUpdateHealthEvent()
        {
            UpdateHealthEvent?.Invoke(Health);
        }
    }
}