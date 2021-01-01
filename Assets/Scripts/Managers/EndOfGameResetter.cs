[System.Serializable]
public class EndOfGameResetter {
    
    public FloatValue levelCoinRewards;
    public FloatValue levelLightRewards;
    public FloatValue levelDarkRewards;
    public FloatValue levelShotRewards;
    public FloatValue remainingShots;
    public FloatValue currentStreak;

    public void ResetBuffers() {
        levelCoinRewards.value = 2;
        levelLightRewards.value = 0;
        levelDarkRewards.value = 0;
        levelShotRewards.value = 2;
        remainingShots.value = 20;
        currentStreak.value = 0;
    }
}