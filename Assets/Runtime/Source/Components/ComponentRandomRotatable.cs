﻿using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
    [Serializable]
    public class ComponentRandomRotatable
    {
        [SerializeField] private float tumble;
        public float Tumble => tumble;
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string RandomRotatable = "Game.Source.ComponentRandomRotatable";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentRandomRotatable ComponentRandomRotatable(in this ent entity) =>
            ref Storage<ComponentRandomRotatable>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentRandomRotatable : Storage<ComponentRandomRotatable>
    {
        public override ComponentRandomRotatable Create() => new ComponentRandomRotatable();

        // Use for cleaning components that were removed at the current frame.
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
            }
        }
    }

    #endregion
}