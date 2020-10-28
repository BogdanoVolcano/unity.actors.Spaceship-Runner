﻿using Pixeye.Actors;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Game.Source
{
    [RequireComponent(typeof(Rigidbody))]
    public class ActorPlayerSpaceship : Actor
    {
        [FoldoutGroup("Components", true)]
        public ComponentSpaceship componentSpaceship;
        [FoldoutGroup("Components", true)]
        public ComponentRigidbody componentRigidbody;
        [FoldoutGroup("Components", true)]
        public ComponentPlayerMovementData componentPlayerMovementData;
        [FoldoutGroup("Components", true)]
        public ComponentHealth componentHealth;


        protected override void Setup()
        {
            componentRigidbody.SetRigidbody(GetComponent<Rigidbody>());

            entity.Set(componentSpaceship);
            entity.Set(componentRigidbody);
            entity.Set(componentPlayerMovementData);
            entity.Set(componentHealth);
        }


        private void OnCollisionEnter(Collision other)
        {
            var entityCollision = Entity.Create();
            
            entityCollision.Set<ComponentCollision>();
            var componentOnCollision = entityCollision.ComponentCollision();
            componentOnCollision.Collision = other;
            componentOnCollision.ReceiverEntity = entity;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            var speedX = componentPlayerMovementData.CurrentVelocityX;
            Gizmos.DrawRay(transform.position, new Vector3(speedX, 0, 0));
        }
    }
}