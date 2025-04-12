using UnityEditor;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Level Data")]
    public TextAsset levelFile;
    public float cellSize = 1f;

    [Header("Prefab References Handmade Level")]
    public GameObject skyPrefab;
    public GameObject spikePrefab;
    public GameObject simpleFlowerPrefab;
    public GameObject treePrefab;
    public GameObject littleFlowerPrefab;
    public GameObject groundBlockPrefab;
    public GameObject goalPostPrefab;
    public GameObject ringPrefab;
    public GameObject sonicStartPrefab;
    public GameObject itemBoxPrefab;
    public GameObject boundaryPrefab;

    [Header("Prefab References Commercial Level")]
    public GameObject backgroundPrefab;
    public GameObject backgroundSpecialLeftPrefab;
    public GameObject backgroundSpecialPrefab;
    public GameObject backgroundSpecialRightPrefab;

    public GameObject blockingThingPrefab;

    public GameObject bridgePieceFromLeftPrefab;
    public GameObject bridgePieceFromRightPrefab;

    public GameObject bushPrefab;

    public GameObject cloudLeftPrefab;
    public GameObject cloudRightPrefab;

    public GameObject curvedGroundPrefab;
    public GameObject curvedSoundGroundPrefab;

    public GameObject flowerMiddlePrefab;

    public GameObject highCheckerv1Prefab;
    public GameObject highCheckerv2Prefab;
    public GameObject highCheckerv3Prefab;
    public GameObject highCheckerv4Prefab;
    public GameObject highCheckerv6Prefab;
    public GameObject highCheckerv7Prefab;
    public GameObject highCheckerv8Prefab;
    public GameObject highCheckerv10Prefab;
    public GameObject highCheckerv11Prefab;
    public GameObject highCheckerv12Prefab;
    public GameObject highCheckerv13Prefab;
    public GameObject highCheckerv14Prefab;
    public GameObject highCheckerv15Prefab;

    public GameObject highGroundTopLeftGrassv1Prefab;
    public GameObject highGroundTopLeftGrassv2Prefab;
    public GameObject highGroundTopLeftGrassv3Prefab;
    public GameObject highGroundTopLeftGrassv4Prefab;

    public GameObject highGroundTopRightGrassv1Prefab;
    public GameObject highGroundTopRightGrassv2Prefab;
    public GameObject highGroundTopRightGrassv3Prefab;
    public GameObject highGroundTopRightGrassv4Prefab;

    public GameObject highGroundv1Prefab;
    public GameObject highGroundv2Prefab;
    public GameObject highGroundv3Prefab;
    public GameObject highGroundv4Prefab;

    public GameObject highSandGroundv1Prefab;
    public GameObject highSandGroundv2Prefab;
    public GameObject highSandGroundv3Prefab;
    public GameObject highSandGroundv4Prefab;
    public GameObject highSandGroundv5Prefab;
    public GameObject highSandGroundv6Prefab;
    public GameObject highSandGroundv7Prefab;
    public GameObject highSandGroundv8Prefab;
    public GameObject highSandGroundv9Prefab;
    public GameObject highSandGroundv10Prefab;
    public GameObject highSandGroundv11Prefab;
    public GameObject highSandGroundv12Prefab;
    public GameObject highSandGroundv13Prefab;
    public GameObject highSandGroundv14Prefab;
    public GameObject highSandGroundv15Prefab;
    public GameObject highSandGroundv16Prefab;

    public GameObject inclinedGround15BottomLeftToTopRightP1Prefab;
    public GameObject inclinedGround15BottomLeftToTopRightP2Prefab;
    public GameObject inclinedGround15BottomLeftToTopRightP3Prefab;
    public GameObject inclinedGround15BottomLeftToTopRightP4Prefab;

    public GameObject inclinedGround15TopLeftToBottomRightP1Prefab;
    public GameObject inclinedGround15TopLeftToBottomRightP2Prefab;
    public GameObject inclinedGround15TopLeftToBottomRightP3Prefab;

    public GameObject inclinedGround30BottomLeftToTopRightP1Prefab;
    public GameObject inclinedGround30BottomLeftToTopRightP2Prefab;

    public GameObject inclinedGround30TopLeftToBottomRightP1Prefab;
    public GameObject inclinedGround30TopLeftToBottomRightP2Prefab;

    public GameObject inclinedGround45BottomLeftToTopRightP1Prefab;
    public GameObject inclinedGround45BottomLeftToTopRightP2Prefab;

    public GameObject inclinedSoundGround15BottomLeftToTopRightP1Prefab;
    public GameObject inclinedSoundGround15BottomLeftToTopRightP2Prefab;
    public GameObject inclinedSoundGround15BottomLeftToTopRightP3Prefab;
    public GameObject inclinedSoundGround15BottomLeftToTopRightP4Prefab;

    public GameObject inclinedSoundGround15TopLeftToBottomRightP1Prefab;
    public GameObject inclinedSoundGround15TopLeftToBottomRightP2Prefab;
    public GameObject inclinedSoundGround15TopLeftToBottomRightP3Prefab;
    public GameObject inclinedSoundGround15TopLeftToBottomRightP4Prefab;

    public GameObject inclinedSoundGround30BottomLeftToTopRightP1Prefab;
    public GameObject inclinedSoundGround30BottomLeftToTopRightP2Prefab;

    public GameObject inclinedSoundGround30TopLeftToBottomRightP1Prefab;
    public GameObject inclinedSoundGround30TopLeftToBottomRightP2Prefab;

    public GameObject inclinedSoundGround45BottomLeftToTopRightPrefab;

    public GameObject inclinedSoundGround45TopLeftToBottomRightPrefab;

    public GameObject littleFlowerMiddlePrefab;

    public GameObject loopBottomLeftPrefab;
    public GameObject loopBottomMiddleLeftPrefab;
    public GameObject loopBottomMiddleRightPrefab;
    public GameObject loopBottomRightPrefab;
    public GameObject loopLeftMiddleBottomPrefab;
    public GameObject loopLeftMiddleTopPrefab;
    public GameObject loopRightMiddleBottomPrefab;
    public GameObject loopRightMiddleTopPrefab;
    public GameObject loopTopLeftPrefab;
    public GameObject loopTopMiddleLeftPrefab;
    public GameObject loopTopMiddleRightPrefab;
    public GameObject loopTopRightPrefab;

    public GameObject lowCheckerv1Prefab;
    public GameObject lowCheckerv2Prefab;

    public GameObject lowGroundv1Prefab;
    public GameObject lowGroundv2Prefab;
    public GameObject lowGroundv3Prefab;

    public GameObject lowSandGroundv1Prefab;
    public GameObject lowSandGroundv2Prefab;

    public GameObject miniCloudPrefab;

    public GameObject palmTreeBottomLeftPrefab;
    public GameObject palmTreeBottomRightPrefab;
    public GameObject palmTreeMiddleLeftPrefab;
    public GameObject palmTreeMiddlePrefab;
    public GameObject palmTreeMiddleRightPrefab;
    public GameObject palmTreeTopLeftPrefab;
    public GameObject palmTreeTopMiddlePrefab;
    public GameObject palmTreeTopRightPrefab;

    public GameObject palmTreeTrunkClassicBackgroundPrefab;
    public GameObject palmTreeTrunkSeaBackgroundPrefab;
    public GameObject palmTreeTrunkSpecialBackgroundPrefab;

    public GameObject seaBackgroundv1Prefab;
    public GameObject seaBackgroundv2Prefab;
    public GameObject seaBackgroundv3Prefab;

    public GameObject springFromBottomLeftPrefab;
    public GameObject springFromBottomLeftUnderwaterPrefab;
    public GameObject springFromBottomMiddlePrefab;
    public GameObject springFromBottomMiddleUnderwaterPrefab;
    public GameObject springFromBottomRightPrefab;
    public GameObject springFromBottomRightUnderwaterPrefab;
    public GameObject springFromLeftMiddlePrefab;
    public GameObject springFromLeftMiddleUnderwaterPrefab;
    public GameObject springFromRightMiddlePrefab;
    public GameObject springFromRightMiddleUnderwaterPrefab;

    public GameObject triangleGroundPrefab;
    public GameObject triangleSandGroundPrefab;

    public GameObject twoFlowersBottomPrefab;
    public GameObject twoFlowersPrefab;
    public GameObject twoFlowersTopPrefab;

    public GameObject waterSurface1Prefab;
    public GameObject waterSurface2Prefab;
    public GameObject waterSurface3Prefab;
    public GameObject waterSurfaceHalfPrefab;

    public GameObject waterfallEndPrefab;
    public GameObject waterfallEndWithBackgroundPrefab;
    public GameObject waterfallMiddlePrefab;
    public GameObject waterfallMiddleWithBackgroundPrefab;
    public GameObject waterfallStartPrefab;
    public GameObject waterfallStartWithBackgroundPrefab;
    

    [Header("Enemy Prefabs")]
    public GameObject motoBugPrefab;
    public GameObject buzzBomberPrefab;
    public GameObject crabmeatPrefab;

    public int columns = 16;
    public int rows = 16;
    public string[] levelData;

    private GameObject sonicInstance;

    // Automatically generate the level when the game starts
    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        if (levelFile == null)
        {
            Debug.LogError("No level file assigned!");
            return;
        }

        string[] lines = levelFile.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        int totalRows = lines.Length;

        for (int row = 0; row < totalRows; row++)
        {
            string line = lines[totalRows - 1 - row];  // Inverting the lines

            for (int col = 0; col < line.Length; col++)
            {
                char token = line[col];
                Vector3 position = new Vector3(col * cellSize, row * cellSize, 0);
                GameObject prefabToSpawn = GetPrefabForToken(token);

                if (prefabToSpawn != null)
                {
                    Instantiate(prefabToSpawn, position, Quaternion.identity, transform);
                }

                if (token == '@')
                {
                    sonicInstance = Instantiate(sonicStartPrefab, position, Quaternion.identity, transform);
                }

                else if (token == '-' && skyPrefab != null)
                {
                    Instantiate(skyPrefab, position, Quaternion.identity, transform);
                }
            }
        }

        if (sonicInstance != null)
        {
            Camera.main.GetComponent<CameraFollow>().SetTarget(sonicInstance.transform);
        }
    }

    GameObject GetPrefabForToken(char token)
    {
        switch (token)
        {
            // For handmade level
            case '-': return skyPrefab;
            case 'M': return motoBugPrefab;
            case 'B': return buzzBomberPrefab;
            case 'R': return crabmeatPrefab;
            case '^': return spikePrefab;
            case 'O': return ringPrefab;
            case 'P': return goalPostPrefab;
            case 'I': return itemBoxPrefab;
            case '|': return treePrefab;
            case 'F': return simpleFlowerPrefab;
            case 'f': return littleFlowerPrefab;
            case '$': return boundaryPrefab;
            case 'o': case '/': case '#': return groundBlockPrefab;

            // For commercial level
            case 'Ā': return inclinedGround15BottomLeftToTopRightP1Prefab;
            case 'Ą': return inclinedGround15BottomLeftToTopRightP2Prefab;
            case 'ą': return inclinedGround15BottomLeftToTopRightP3Prefab;
            case 'Ć': return inclinedGround15BottomLeftToTopRightP4Prefab;
            case 'Ĉ': return inclinedGround30TopLeftToBottomRightP1Prefab;
            case 'ĉ': return inclinedGround30TopLeftToBottomRightP2Prefab;
            case 'Ċ': return inclinedGround15TopLeftToBottomRightP1Prefab;
            case 'ċ': return inclinedGround15TopLeftToBottomRightP2Prefab;
            case 'Č': return inclinedGround15TopLeftToBottomRightP3Prefab;
            case 'Ď': return loopBottomMiddleRightPrefab;
            case 'ď': return loopBottomRightPrefab;
            case 'Đ': return loopRightMiddleBottomPrefab;
            case 'đ': return loopLeftMiddleTopPrefab;
            case 'Ē': return loopTopRightPrefab;
            case 'ē': return loopTopMiddleRightPrefab;
            case 'Ĕ': return loopBottomMiddleLeftPrefab;
            case 'ĕ': return loopBottomLeftPrefab;
            case 'Ė': return loopLeftMiddleBottomPrefab;
            case 'ė': return loopLeftMiddleTopPrefab;
            case 'Ę': return loopTopLeftPrefab;
            case 'ę': return loopTopMiddleLeftPrefab;
            case 'Ě': return lowGroundv1Prefab;
            case 'ě': return lowGroundv2Prefab;
            case 'Ĝ': return lowGroundv3Prefab;
            case 'Ğ': return triangleGroundPrefab;
            case 'ğ': return curvedGroundPrefab;
            case 'Ġ': return highGroundv1Prefab;
            case 'ġ': return highGroundv2Prefab;
            case 'Ģ': return highGroundv3Prefab;
            case 'ģ': return highGroundv4Prefab;
            case 'Ĥ': return highGroundTopLeftGrassv1Prefab;
            case 'ĥ': return highGroundTopLeftGrassv2Prefab;
            case 'Ħ': return highGroundTopLeftGrassv3Prefab;
            case 'ħ': return highGroundTopLeftGrassv4Prefab;
            case 'Ĩ': return highGroundTopRightGrassv1Prefab;
            case 'ĩ': return highGroundTopRightGrassv2Prefab;
            case 'Ī': return highGroundTopRightGrassv3Prefab;
            case 'ī': return highGroundTopRightGrassv4Prefab;
            case 'Ĭ': return inclinedSoundGround45BottomLeftToTopRightPrefab;
            case 'ĭ': return inclinedSoundGround30BottomLeftToTopRightP1Prefab;
            case 'Į': return inclinedSoundGround30BottomLeftToTopRightP2Prefab;
            case 'į': return inclinedSoundGround15BottomLeftToTopRightP1Prefab;
            case 'İ': return inclinedSoundGround15BottomLeftToTopRightP2Prefab;
            case 'ı': return inclinedSoundGround15BottomLeftToTopRightP3Prefab;
            case 'Ĳ': return inclinedSoundGround15BottomLeftToTopRightP4Prefab;
            case 'ĳ': return inclinedSoundGround45TopLeftToBottomRightPrefab;
            case 'Ĵ': return inclinedSoundGround30BottomLeftToTopRightP1Prefab;
            case 'ĵ': return inclinedSoundGround30BottomLeftToTopRightP2Prefab;
            case 'Ķ': return inclinedSoundGround15TopLeftToBottomRightP1Prefab;
            case 'ķ': return inclinedSoundGround15TopLeftToBottomRightP2Prefab;
            case 'ĸ': return inclinedSoundGround15TopLeftToBottomRightP3Prefab;
            case 'Ĺ': return inclinedSoundGround15TopLeftToBottomRightP4Prefab;
            case 'ĺ': return lowSandGroundv1Prefab;
            case 'Ļ': return lowSandGroundv2Prefab;
            case 'ľ': return triangleSandGroundPrefab;
            case 'Ŀ': return curvedSoundGroundPrefab;
            case 'ŀ': return highSandGroundv1Prefab;
            case 'Ł': return highSandGroundv2Prefab;
            case 'ł': return highSandGroundv3Prefab;
            case 'Ń': return highSandGroundv4Prefab;
            case 'ń': return highSandGroundv5Prefab;
            case 'Ņ': return highSandGroundv6Prefab;
            case 'ņ': return highSandGroundv7Prefab;
            case 'Ň': return highSandGroundv8Prefab;
            case 'ň': return highSandGroundv9Prefab;
            case 'ŉ': return highSandGroundv10Prefab;
            case 'Ŋ': return highSandGroundv11Prefab;
            case 'ŋ': return highSandGroundv12Prefab;
            case 'Ō': return highSandGroundv13Prefab;
            case 'ō': return highSandGroundv14Prefab;
            case 'Ŏ': return highSandGroundv15Prefab;
            case 'ŏ': return highSandGroundv16Prefab;
            case 'Ő': return lowCheckerv1Prefab;
            case 'ő': return lowCheckerv2Prefab;
            case 'Œ': return highCheckerv1Prefab;
            case 'œ': return highCheckerv2Prefab;
            case 'Ŕ': return highCheckerv3Prefab;
            case 'ŕ': return highCheckerv4Prefab;
            case 'ŗ': return highCheckerv6Prefab;
            case 'Ř': return highCheckerv7Prefab;
            case 'ř': return highCheckerv8Prefab;
            case 'ś': return highCheckerv10Prefab;
            case 'Ŝ': return highCheckerv11Prefab;
            case 'ŝ': return highCheckerv12Prefab;
            case 'Ş': return highCheckerv13Prefab;
            case 'ş': return highCheckerv14Prefab;
            case 'Š': return highCheckerv15Prefab;
            case 'š': return bridgePieceFromLeftPrefab;
            case 'Ţ': return bridgePieceFromRightPrefab;
            case 'Ŧ': return palmTreeTopLeftPrefab;
            case 'ŧ': return palmTreeTopMiddlePrefab;
            case 'Ũ': return palmTreeTopRightPrefab;
            case 'ũ': return palmTreeMiddleLeftPrefab;
            case 'Ū': return palmTreeMiddlePrefab;
            case 'ū': return palmTreeMiddleRightPrefab;
            case 'Ŭ': return palmTreeBottomLeftPrefab;
            case 'ŭ': return palmTreeBottomRightPrefab;
            case 'Ů': return palmTreeTrunkClassicBackgroundPrefab;
            case 'ů': return palmTreeTrunkSpecialBackgroundPrefab;
            case 'Ű': return palmTreeTrunkSeaBackgroundPrefab;
            case 'ű': return littleFlowerMiddlePrefab;
            case 'Ų': return flowerMiddlePrefab;
            case 'ų': return twoFlowersPrefab;
            case 'Ŵ': return twoFlowersTopPrefab;
            case 'ŵ': return twoFlowersBottomPrefab;
            case 'Ŷ': return bushPrefab;
            case 'ſ': return springFromBottomMiddlePrefab;
            case 'ƀ': return springFromBottomMiddleUnderwaterPrefab;
            case 'Ɓ': return springFromLeftMiddlePrefab;
            case 'Ƃ': return springFromLeftMiddleUnderwaterPrefab;
            case 'ƃ': return springFromRightMiddlePrefab;
            case 'Ƅ': return springFromRightMiddleUnderwaterPrefab;
            case 'ƅ': return springFromBottomLeftPrefab;
            case 'Ɔ': return springFromBottomLeftUnderwaterPrefab;
            case 'Ƈ': return springFromBottomRightPrefab;
            case 'ƈ': return springFromBottomRightUnderwaterPrefab;
            case 'ƍ': return blockingThingPrefab;
            case 'Ǝ': return waterSurface1Prefab;
            case 'Ə': return waterSurface2Prefab;
            case 'Ɛ': return waterSurface3Prefab;
            case 'Ƒ': return waterSurfaceHalfPrefab;
            case 'ƒ': return waterfallStartPrefab;
            case 'Ɠ': return waterfallMiddlePrefab;
            case 'Ɣ': return waterfallEndPrefab;
            case 'ƕ': return waterfallStartWithBackgroundPrefab;
            case 'Ɩ': return waterfallMiddleWithBackgroundPrefab;
            case 'Ɨ': return waterfallEndWithBackgroundPrefab;
            case 'Ƙ': return miniCloudPrefab;
            case 'ƙ': return cloudLeftPrefab;
            case 'ƚ': return cloudRightPrefab;
            case 'ƛ': return seaBackgroundv1Prefab;
            case 'Ɯ': return seaBackgroundv2Prefab;
            case 'Ɲ': return seaBackgroundv3Prefab;
            case 'ƞ': return backgroundSpecialPrefab;
            case 'Ɵ': return backgroundSpecialLeftPrefab;
            case 'Ơ': return backgroundSpecialRightPrefab;
            case 'Ƣ': return backgroundPrefab;



            default: return null;
        }
    }
}
