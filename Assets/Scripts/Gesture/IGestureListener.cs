using UnityEngine;

namespace RelakkumaAR.Utils.Gesture
{
    public interface IGestureListener
    {
        void OnDragging(Vector3 draggingPosition);
        void OnSingleTap();
        void OnMultiTap();
        void OnPinchInOut(float distance);
    }

}

