using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragger : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{


    public delegate void OnDraggingStarted(bool isDragging);
    public static event OnDraggingStarted OnDraggingValueChanged;

    public bool isItPlacedOnGround = false;
    public LayerMask layerMask = new LayerMask();

    private bool _isColliding = false;
    private Vector3 _initialPosition;
    private Collider2D _collider2D;
    private GameObject _lastCollidedObj;

    private void Awake()
    {
        _initialPosition = this.transform.position;
        _collider2D = this.gameObject.GetComponent<Collider2D>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDraggingValueChanged?.Invoke(true);
        transform.position = eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDraggingValueChanged?.Invoke(false);
       // _collider2D.isTrigger = false;

        if (_isColliding == true)
        {
            if (isItPlacedOnGround == true && _lastCollidedObj != null && IsThisLayerCollidable(_lastCollidedObj) == true)
            {
                Vector3 newPos = this.transform.position;
                newPos.y = _lastCollidedObj.transform.position.y;
                this.transform.position = newPos;

                GoBackToGameItemState();

                return;
            }
            else
            {
                GoBackToButtonState();
                return;
            }

        }
        else
        {
            if (isItPlacedOnGround == true)
            {
                GoBackToButtonState();
            }
            else
            {
                GoBackToGameItemState();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _collider2D.isTrigger = true;
        OnDraggingValueChanged?.Invoke(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isColliding = true;
        _lastCollidedObj = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isColliding = false;
        
    }

    public bool IsThisLayerCollidable(GameObject collidedObj)
    {
        if ((layerMask.value & 1 << collidedObj.layer) != 0)
            return true;
        return false;
    }

    private void GoBackToButtonState()
    {
        this.transform.position = _initialPosition;
        _collider2D.isTrigger = true;
        _lastCollidedObj = null;
    }

    private void GoBackToGameItemState()
    {
        _collider2D.isTrigger = false;
        _lastCollidedObj = null;
    }


}
