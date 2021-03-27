using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils.Gesture;

public class TouchGestureCheckerForNonAR : GestureRecognizerBase
    {
       
        private Camera _camera = default;
		private Vector3 startDragPos;
		private bool isDragging = false;

		private void Start()
        {
			_camera = Camera.main;
            InitializeRayCaster(_camera);
        }
        private void Update()
        {
          // CheckPinchInOut(_camera);
        }

		protected override void onDraggingStarted(PointerEventData eventData)
		{
			Debug.Log("UNITY>> Start Drag - " + eventData.pointerPressRaycast.worldPosition);
			startDragPos = eventData.pointerPressRaycast.worldPosition;
			isDragging = true;
		}

		protected override void onEndDragging(PointerEventData eventData)
		{
		//	isDragging = false;
    	}

		protected override void onDragging(Vector3 draggingPoint, PointerEventData eventData)
        {
			//draggingPoint.z = 0;
		    Debug.Log("UNITY>> On  Dragging - " + draggingPoint);
		/*  if (eventData.pointerCurrentRaycast.gameObject == null || eventData.pointerCurrentRaycast.gameObject.tag != "railkummaModel")
		  {
			  return;
		  }
			 }*/
	}


		private void CalculateShootPos(Vector3 dragStartPos , PointerEventData currentDragPos)
		{
		//	Vector3 startPos = dragStartPos.pointerCurrentRaycast.worldPosition;
			Vector3 endPos = currentDragPos.pointerCurrentRaycast.worldPosition;

			Vector3 diff = endPos - dragStartPos;
		//	Debug.Log("gobj " + this.gameObject.name+"Strat " + dragStartPos + "   End Pos  " + endPos +  " dif is  " + diff);

			Vector3 negativeDiff = diff * (-1*2);
			negativeDiff.y = .2f;
			//shootPos.transform.position = negativeDiff;

		}

		
	}

