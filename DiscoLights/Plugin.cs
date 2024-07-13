using Exiled.API.Features;
using System;

namespace DiscoLights
{
    public class Plugin : Plugin<Config, Translations>
    {
        public static Plugin Instance { get; private set; }

        public static Random Random;

        public override void OnEnabled()
        {
            Instance = this;
            Random = new Random();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            Random = null;

            base.OnDisabled();
        }
    }
}
