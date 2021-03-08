using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooter.Inventory;

namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] private Collider _collider;
        public int InstanceId { get; private set; }
        public float Health = 100;
        public float Armor = 100;
        private Vector3 _defaultScale;
        public ReactiveCommand OnDeath = new ReactiveCommand();
        private bool isDead = false;
        protected virtual void Awake()
        {
            InstanceId = _collider.GetInstanceID();
            this.InitializeDamageble();
            _defaultScale = transform.localScale;
        }
        protected virtual void Destroy()
        {

            this.DestroyDamageble();
        }
        public virtual void Damage(IDamage dmg)
        {
            if (dmg.TimeBasedDamage > 0)
            {
                StartCoroutine(TimeBaseDamage(dmg.TimeBasedDamage, dmg.TimeBasedDamageDuration));
            }
            if (Armor > 0)
            {
                Armor -= (dmg.Damage * dmg.ArmorPenetration);
            }
            else
            {
                Health -= dmg.Damage;

                Health += Armor;
                CheckHealth();
            }
        }

        private IEnumerator TimeBaseDamage(float damage, float totalDuration)
        {
            while (totalDuration > 0)
            {
                totalDuration -= 1;
                Health -= damage;
                CheckHealth();
                yield return new WaitForSeconds(1);
            }
        }

        private void CheckHealth()
        {
            if (isDead)
            {
                return;
            }
            if (Health <= 0)
            {
                StopAllCoroutines();
                isDead = true;
                OnDeath.Execute();
                Destroy(gameObject);
            }
        }
    }
}
