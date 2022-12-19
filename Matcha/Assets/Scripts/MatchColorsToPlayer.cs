using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchColorsToPlayer : MonoBehaviour
{

    [SerializeField] private SpriteRenderer playerSpriteRenderer;

    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private ParticleSystem dustParticleSystem;

    void Update()
    {
        Color playerSpriteColor = playerSpriteRenderer.color;

        Color newStartColor = new Color(playerSpriteColor.r, playerSpriteColor.g, playerSpriteColor.b, 170f);
        trailRenderer.startColor = newStartColor;

        Color newEndColor = new Color(playerSpriteColor.r, playerSpriteColor.g, playerSpriteColor.b, 0f);
        trailRenderer.endColor = newEndColor;

        ParticleSystem.MainModule settings = dustParticleSystem.main;
        settings.startColor = new ParticleSystem.MinMaxGradient(playerSpriteColor);
    }
}

