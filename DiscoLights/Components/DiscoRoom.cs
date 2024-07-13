using Exiled.API.Extensions;
using Exiled.API.Features;
using UnityEngine;

namespace DiscoLights.Components
{
    public class DiscoRoom : MonoBehaviour
    {
        public Room room;
        private Color _lastLightColor;

        private float _deltaTime;

        private void Start ()
        {

        }

        private void Update ()
        {
            if (room == null)
                return;

            _deltaTime += Time.deltaTime;

            if (_deltaTime < 0.5f)
                return;

            room.Color = Plugin.Instance.Config.RandomColors.GetRandomValue(x => x != _lastLightColor);

            _lastLightColor = room.Color;

            _deltaTime = 0;
        }

        private void OnDestroy()
        {
            room.ResetColor();
        }
    }
}
