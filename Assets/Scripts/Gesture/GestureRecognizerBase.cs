using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.Gesture
{
    public abstract class GestureRecognizerBase : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        protected bool _isPinchInOut;
        protected float _backDistance;

        protected Vector3 _currentTouchPosition;

        protected int _tapNumber = 0;
        protected float _previousTapTime = 0f;

        float dx;
        float dy;
        Vector3 newPos;

        protected abstract void onDragging(Vector3 draggingPoint, PointerEventData eventData);
		protected abstract void onDraggingStarted(PointerEventData eventData);
		protected abstract void onEndDragging(PointerEventData eventData);


		protected void InitializeRayCaster(Camera camera)
        {
            PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
            if (physicsRaycaster == null)
            {
                camera.gameObject.AddComponent<PhysicsRaycaster>();
            }
        }

  
        private void SetCurrentPosition(PointerEventData eventData)
        {
            _currentTouchPosition = eventData.pointerCurrentRaycast.screenPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

           /* if (_isPinchInOut == true)
            {
                return;
            }*/

			// SetCurrentPosition(eventData);
			//Debug.Log("UNITY>> Start Drag - " + eventData.pointerPressRaycast.worldPosition);
			dx = eventData.pointerPressRaycast.worldPosition.x - transform.position.x;
            dy = eventData.pointerPressRaycast.worldPosition.y - transform.position.y;

			onDraggingStarted(eventData);
		}

        public void OnDrag(PointerEventData eventData)
        {
           /* if (_isPinchInOut == true)
            {
                return;
            }*/

            SetCurrentPosition(eventData);

            if (eventData.pointerCurrentRaycast.worldPosition.x == 0 || eventData.pointerCurrentRaycast.worldPosition.y == 0)
            {
            }
            else
            {
                newPos.x = eventData.pointerCurrentRaycast.worldPosition.x - dx;
                newPos.y = eventData.pointerCurrentRaycast.worldPosition.y - dy;
            }

            Debug.Log("UNITY>> On Drag: pos - " + newPos);
            onDragging(eventData.pointerCurrentRaycast.worldPosition, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
			onEndDragging(eventData);
		Debug.Log("UNITY>> End Drag - " + eventData.pointerPressRaycast.worldPosition);
		}

       
    }

}
