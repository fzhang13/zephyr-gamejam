using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    [System.Serializable]
    public class PrefabWithCount {
        public GameObject prefab;
        public int count;
    }
    [SerializeField] PrefabWithCount[] buildingPieces;
    [SerializeField] float randMinScale;
    [SerializeField] float randMaxScale;
    [SerializeField] float addMovementDelay;
    [SerializeField] GameObject worldRotater;
    [SerializeField] float avoidXMin;
    [SerializeField] float avoidXMax;

    List<GameObject> staticPieces = new List<GameObject>();
    List<GameObject> movingPieces = new List<GameObject>();
    float prevAddTime;

    void Start() {
        GenerateStaticPieces();
        prevAddTime = Time.time;
    }

    void GenerateStaticPieces() {
        for (int i = 0; i < buildingPieces.Length; ++i) {
            for (int j = 0; j < buildingPieces[i].count; ++j) {
                GameObject newBuilding = Instantiate(
                    buildingPieces[i].prefab,
                    CreateStartingPosition(),
                    CreateStartingRotation(),
                    transform);
                newBuilding.transform.localScale = CreateStartingScale();

                staticPieces.Add(newBuilding);
            }
        }
    }

    Vector3 CreateStartingPosition() {
        float xPos;
        for (; ; ) {
            xPos = Random.Range(
                GameManager.xCreationMin,
                GameManager.xCreationMax
            );

            if (xPos < avoidXMin || xPos > avoidXMax) {
                break;
            }
        }

        return new Vector3(xPos, GameManager.ySpawn, GameManager.zSpawn);
    }

    Quaternion CreateStartingRotation() {
        return Quaternion.Euler(
            GameManager.xRotationSpawn, 0f, 0f);
    }

    Vector3 CreateStartingScale() {
        return new Vector3(
            Random.Range(randMinScale, randMaxScale),
            Random.Range(randMinScale, randMaxScale),
            Random.Range(randMinScale, randMaxScale));
    }

    void Update() {
        AddMovingPiece();
    }

    void AddMovingPiece() {
        if (
            prevAddTime + addMovementDelay < Time.time
            &&
            staticPieces.Count > 0
        ) {
            int pieceToMove;
            for(; ; ) {
                bool collision = false;
                pieceToMove = Random.Range(0, staticPieces.Count);
                Bounds pieceToMoveCol = staticPieces[pieceToMove]
                    .GetComponent<Collider>().bounds;
                for (int i = 0; i < movingPieces.Count; ++i) {
                    Bounds movingPieceCol = movingPieces[i]
                        .GetComponent<Collider>().bounds;
                    if (pieceToMoveCol.Intersects(movingPieceCol)) {
                        collision = true;
                        break;
                    }
                }

                if (!collision) {
                    break;
                }
            }

            staticPieces[pieceToMove].transform.parent =
                worldRotater.transform;

            movingPieces.Add(staticPieces[pieceToMove]);
            staticPieces.RemoveAt(pieceToMove);

            prevAddTime = Time.time;
        }
    }
}
