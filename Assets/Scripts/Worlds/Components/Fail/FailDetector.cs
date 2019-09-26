using UnityEngine;
using System.Collections;
using Game;

public class FailDetector : MonoBehaviour
{
    public Character Character { get => _Character; set => _Character = value; }

    [SerializeField] private LoaderData _Loader;
    [SerializeField] private ContactFilter2D _CollisionFilter;
    [SerializeField] private Character _Character;

    private bool isCollided;

    void Update()
    {
        if (!_Character)
            return;

        var hits = new Collider2D[6];
        int count = _Character.GetComponent<Collider2D>().OverlapCollider(_CollisionFilter, hits);
        if (count > 0 && !isCollided)
        {
            isCollided = true;
            _Loader.Instance.LoadLevel(_Loader.FailScene);
        }
    }
}
