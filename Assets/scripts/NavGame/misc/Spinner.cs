using UnityEngine;

namespace NavGame.Misc
{
    public class Spinner : MonoBehaviour
    {
        public Vector3 eulerPerSecond;

        void Update()
        {
            transform.Rotate(eulerPerSecond * Time.deltaTime);
        }
    }
}
