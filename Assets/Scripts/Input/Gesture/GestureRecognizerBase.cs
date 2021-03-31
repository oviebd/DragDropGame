using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.Gesture
{
    public abstract class GestureRecognizerBase : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        float dx;
        float dy;
        Vector3 newPos;
		protected bool _isDragging = false;

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

        public void OnBeginDrag(PointerEventData eventData)
        {
			//Debug.Log("UNITY>> Start Drag - " + eventData.pointerPressRaycast.worldPosition);
			dx = eventData.pointerPressRaycast.worldPosition.x - transform.position.x;
            dy = eventData.pointerPressRaycast.worldPosition.y - transform.position.y;

			_isDragging = true;
			onDraggingStarted(eventData);
		}

        public void OnDrag(PointerEventData eventData)
        {
			// SetCurrentPosition(eventData);
			_isDragging = true;
            if (eventData.pointerCurrentRaycast.worldPosition.x == 0 || eventData.pointerCurrentRaycast.worldPosition.y == 0)
            {
            }
            else
            {
                newPos.x = eventData.pointerCurrentRaycast.worldPosition.x - dx;
                newPos.y = eventData.pointerCurrentRaycast.worldPosition.y - dy;
            }
			onDragging(newPos, eventData);
			//Debug.Log("UNITY>> On Drag: pos - " + newPos);
			// onDragging(eventData.pointerCurrentRaycast.worldPosition, eventData);
		}

        public void OnEndDrag(PointerEventData eventData)
        {
			_isDragging = false;
			onEndDragging(eventData);
	    	//Debug.Log("UNITY>> End Drag - " + eventData.pointerPressRaycast.worldPosition);
		}

       
    }

}
