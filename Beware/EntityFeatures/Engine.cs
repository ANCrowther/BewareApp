﻿using Beware.Entities;
using Beware.ExtensionSupport;
using Microsoft.Xna.Framework;

namespace Beware.EntityFeatures {
    public class Engine : EntityFeature {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public float Orientation { get; set; }

        public float MaxSpeed { get; private set; }
        public float MinSpeed { get; private set; }
        public float CurrentSpeed { get; private set; }
        public bool IsBoosting { get; set; } = false;

        public Engine(EntityModel entity = null, float maxSpeed = 12.0f, float minSpeed = 6.0f) : base() {
            this.Entity = entity;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            CurrentSpeed = MaxSpeed;
        }

        public Engine(Vector2 position, Vector2 velocity, EntityModel entity = null, float maxSpeed = 8.0f, float minSpeed = 3.0f) : base() {
            Velocity = velocity;
            Position = position;
            Orientation = Velocity.ToAngle();
            this.Entity = entity;
            MaxSpeed = maxSpeed;
            MinSpeed = minSpeed;
            CurrentSpeed = MaxSpeed;
        }

        public void SwitchSpeed() {
            CurrentSpeed = (CurrentSpeed == MaxSpeed) ? MinSpeed : MaxSpeed;
        }

        public override void Update() {
            //throw new System.NotImplementedException();
        }

        public override void Draw() {
            //throw new System.NotImplementedException();
        }
    }
}
