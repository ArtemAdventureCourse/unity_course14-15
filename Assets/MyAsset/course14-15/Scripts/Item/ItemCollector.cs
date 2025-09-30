using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private readonly string _throwTag = "Throw";
    private readonly string _speedTag = "Speed";
    private readonly string _healthTag = "Health";
    private readonly string _itemFullWarning = "нельзя брать больше одного предмета";
    private readonly string _itemEmpty = "нету предмета для использования ";
    private readonly float _upAngle = 0.6f;
    private readonly float _directionForLeft = 0.7f;
    private readonly float _throwForce = 12f;
    private Player _player;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Item _item;
    [SerializeField] private Effect _effect;
    [SerializeField] protected Timer _timer;
    private bool PressFKey => Input.GetKeyDown(KeyCode.F);
    private bool _IsNotInventoryFull => Collection.Count < 2;
    private bool _ItemInHand => _item != null;
    private bool _HasPressedButton => PressFKey && _ItemInHand;
    public List<Item> Collection { get; private set; }

    private void Awake()
    {
        _player = GetComponent<Player>();

        Collection = new List<Item>();
    }

    private void Update()
    {
        if (_HasPressedButton)
        {
            ChooseItem();
        }

        SetTimer();
    }

    private void SetTimer()
    {
        if (_timer.StartDestroyTime)
        {
            _timer.Tick();
        }
        if (_timer.IsFinished())
        {
            _effect.SetPosition(_item);
            _item.Delete();
            _effect.Play(_item);
        }
    }

    private void ChooseItem()
    {
        if (_item.CompareTag(_throwTag))        
            _item.Throw();     
        else if (_item.CompareTag(_speedTag))        
            UseConsumableItem();        
        else if (_item.CompareTag(_healthTag))       
            UseConsumableItem();      
        else
            Debug.LogWarning(_itemEmpty);
    }

    private void UseConsumableItem()
    {
        _item.Use(_player);
        _effect.SetPosition(_item);
        _effect.Play(_item);
        Collection.RemoveAt(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        _item = other.GetComponent<Item>();

        if (_ItemInHand && _IsNotInventoryFull)
        {
            Collection.Add(_item);
            GrabItem(_item);
        }
    }

    private void TakeInHand(Item item)
    {
        Collider collider = item.GetComponent<Collider>();
        item.transform.SetParent(_playerTransform);
        collider.isTrigger = false;
    }

    private void GrabItem(Item item)
    {
        if (_IsNotInventoryFull)
            TakeInHand(item);
        else
            Debug.LogWarning(_itemFullWarning);
    }

    public void ThrowItemWithForce()
    {
        Rigidbody rb = _item.GetComponent<Rigidbody>();
        if (rb == null)
            rb = _item.gameObject.AddComponent<Rigidbody>();

        SetForceAndDirection(rb);
    }

    private void SetForceAndDirection(Rigidbody rb)
    {
        Vector3 throwDir = transform.forward + Vector3.up * _upAngle - transform.right * _directionForLeft;
        rb.AddForce(throwDir * _throwForce, ForceMode.Impulse);
    }
}

