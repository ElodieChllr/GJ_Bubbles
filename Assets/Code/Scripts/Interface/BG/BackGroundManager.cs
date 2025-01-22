using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public Material backgroundMaterial; 
    public int oceanMaxValeur = 4000; 
    public int skyMaxValeur = 8000; 
    public Color oceanStartColor = Color.black;
    public Color oceanEndColor = Color.cyan; 
    public Color skyStartColor = new Color(0.5f, 0.8f, 1f); 
    public Color skyEndColor = Color.white; 
    public Color spaceStartColor = Color.blue; 
    public Color spaceEndColor = Color.black;
    public float maxGradientForce = 0.5f; 

    private MaterialPropertyBlock propertyBlock;
    private Renderer _renderer;
    private int currentValeur;


    public GameObject vague;
    Animator vagueAnimator;
    void Start()
    {
       
        _renderer = GetComponent<Renderer>();
        propertyBlock = new MaterialPropertyBlock();


        currentValeur = 0;
        vagueAnimator = vague.GetComponent<Animator>();


        UpdateBackground();
    }

    void Update()
    {

        currentValeur += 1;


        UpdateBackground();
    }

    private void UpdateBackground()
    {

        Color startColor = Color.black;
        Color endColor = Color.white;
        float phaseScoreMin = 0f;
        float phaseScoreMax = 1f;

        if(currentValeur == 5000)
        {
            vagueAnimator.SetBool("EndWater",true);
        }

        if (currentValeur <= oceanMaxValeur)
        {
            // Phase 1 : Océan
            startColor = oceanStartColor;
            endColor = oceanEndColor;
            phaseScoreMin = 0f;
            phaseScoreMax = oceanMaxValeur;
        }
        else if (currentValeur <= skyMaxValeur)
        {
            // Phase 2 : Ciel
            startColor = skyStartColor;
            endColor = skyEndColor;
            phaseScoreMin = oceanMaxValeur;
            phaseScoreMax = skyMaxValeur;
        }
        else
        {
            // Phase 3 : Espace
            startColor = spaceStartColor;
            endColor = spaceEndColor;
            phaseScoreMin = skyMaxValeur;
            phaseScoreMax = skyMaxValeur + 100; 
        }

        float t = Mathf.InverseLerp(phaseScoreMin, phaseScoreMax, currentValeur);
        Color currentSkyColor = Color.Lerp(startColor, endColor, t);

        float currentGradientForce = Mathf.Lerp(maxGradientForce, 0f, t);

        _renderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_SkyColor", currentSkyColor);
        propertyBlock.SetFloat("_GradientForce", currentGradientForce);
        _renderer.SetPropertyBlock(propertyBlock);
    }
}
