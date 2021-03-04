using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDownShooter.Stat
{
    public class DamagebleObjectBase : MonoBehaviour, IDamageble
    {
        [SerializeField] private Collider _collider;
        public int InstanceId { get; private set; }
        public float Health = 100;
        private Vector3 _defaultScale;
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
        public virtual void Damage(float dmg)
        {
            Health -= dmg;
            Debug.Log("dmg: " + dmg);
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _defaultScale * (Health / 100f), Time.deltaTime);
        }
    }
}
