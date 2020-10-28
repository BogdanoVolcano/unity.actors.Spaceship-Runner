﻿using Pixeye.Actors;
using System;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

namespace Game.Source
{
    [Serializable]
    public class ComponentSpaceship
    {
    }

    #region HELPERS

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    static partial class Component
    {
        public const string Spaceship = "Game.Source.ComponentSpaceship";
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref ComponentSpaceship ComponentSpaceship(in this ent entity) =>
          ref Storage<ComponentSpaceship>.components[entity.id];
    }

    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    sealed class StorageComponentSpaceship : Storage<ComponentSpaceship>
    {
        public override ComponentSpaceship Create() => new ComponentSpaceship();
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

