using Common;
using DesignPattern;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShootBtnController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Button btn;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x>= Screen.width / 2)
        {
            Observer.Instance.Notify(GameKey.SHOOT);
            transform.position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) && Input.mousePosition.x>= Screen.width / 2)
        {
            transform.position = startPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localScale = transform.localScale * 2;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        transform.localScale = transform.localScale / 2;
    }
}
