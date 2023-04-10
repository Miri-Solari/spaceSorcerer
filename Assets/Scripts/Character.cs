using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    //**********************Interaction****************************//
    private PersistantProperty<IInteractable> _interactionTarget=new PersistantProperty<IInteractable>(null);
    //***********************Weapons*******************************//
    [SerializeField] private GameObject _weaponsHolder;
    private WeaponsInventory _weaponInventory=new WeaponsInventory();

    //********************Physics***************************//
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _VelMulti;
    private Vector2 _moveDirection = new Vector2(0,0);
    private Vector2 _aimPos = new Vector2(1,1);
    public Vector2 MoveDirection {
        get { return _moveDirection; }
        set 
        {
            _moveDirection = value;
        } 
    }
    public Vector2 AimPos {
        get { return _aimPos; }
        set 
        {
            _aimPos = value;
            CalculateScale(value);
            CalculateWeaponRotation(value);
        }
    }
    public void Start()
    {
        _interactionTarget.OnChanged += OnInteractionTargetChanged;
    }
    public void OnDestroy()
    {
        _interactionTarget.OnChanged -= OnInteractionTargetChanged;
    }
    public void Update()
    {
        Velocty();
        CheckInteraction();
    }
    public void OnInteractionTargetChanged(IInteractable val)
    {
        if (val == null)
            return;
        Debug.Log(val.Description);
    }
    private void Velocty()
    {
        _rb.velocity = _moveDirection * _VelMulti;
    }
    private void CalculateScale(Vector2 val)
    {
        var dir = (val.x - transform.position.x);
        if ((val.x-transform.position.x) < 0) { transform.localScale = new Vector2(-1, 1); }
        if ((val.x - transform.position.x) > 0) { transform.localScale = new Vector2(1, 1); }
    }
    private void CalculateWeaponRotation(Vector2 val)
    {
        var direction = val - new Vector2(_weaponsHolder.transform.position.x, _weaponsHolder.transform.position.y);
        var rad = Mathf.Atan(direction.y/direction.x);
        _weaponsHolder.transform.rotation= Quaternion.Euler(0,0,(180/Mathf.PI)*rad);
    }
    private void CheckInteraction()
    {
        var coll = Physics2D.OverlapCircle(transform.position, 1, LayerMask.GetMask("Interactable"));
        _interactionTarget.Value = coll!=null?coll.GetComponent<IInteractable>():null;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = new Color(1,1,0,0.2f);
        Handles.DrawSolidDisc(transform.position, Vector3.forward, 1);
    }
#endif
}
