using UnityEngine;


[CreateAssetMenu(fileName = "New Wave Data", menuName = "Data/Wave")]
public class WaveData : ScriptableObject
{
    [Tooltip("The sequence of enemy groups that make up this wave.")]
    [SerializeField] private WaveStep[] _waveSteps;

    public WaveStep[] WaveSteps => _waveSteps;
   
}