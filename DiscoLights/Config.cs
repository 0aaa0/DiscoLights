using Exiled.API.Interfaces;
using System.ComponentModel;
using UnityEngine;

namespace DiscoLights
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("The intensity of the light attached to the player while disco player is enabled.")]
        public float DiscoPlayerLightIntensity { get; set; } = 10;
        [Description("The range of the light attached to the player while disco player is enabled.")]
        public float DiscoPlayerLightRange { get; set; } = 7;

        public Color[] RandomColors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta };
    }
}
