using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Toys;
using System;
using UnityEngine;

using Light = Exiled.API.Features.Toys.Light;

namespace DiscoLights.Components
{
    public class DiscoPlayer : MonoBehaviour
    {
        public Player player;

        private Light _light;
        private Color _lastLightColor;

        private float _deltaTime;

        private void Start ()
        {
            _light = Light.Create();

            _light.Intensity = Plugin.Instance.Config.DiscoPlayerLightIntensity;
            _light.Range = Plugin.Instance.Config.DiscoPlayerLightRange;
        }

        private void Update ()
        {
            if (player == null)
                return;

            _light.Position = player.Position;

            _deltaTime += Time.deltaTime;

            if (_deltaTime < 0.5f)
                return;

            _light.Color = Plugin.Instance.Config.RandomColors.GetRandomValue(x => x != _lastLightColor);

            _lastLightColor = _light.Color;

            _deltaTime = 0;
        }

        private void OnDestroy()
        {
            _light.Destroy();
        }
    }
}
