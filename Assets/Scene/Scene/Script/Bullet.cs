using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;

    [SerializeField] private UnityEvent OnTouch;
    [SerializeField] private UnityEvent OnPool;

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    private Coroutine DestroyAfterTimeRoutine;

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        return this;
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }
    
    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        // Check if there is a touchable component, if true, do ; else, ignore
        if (collision.GetComponent<ITouchable>() != null)
        {
            collision.GetComponent<ITouchable>()?.Touch(Power);
            
            // reset direction (otherwise the bullet continue moving even after a hit)
            Direction = Vector3.zero;
            
            OnTouch?.Invoke();
            ReturnToPool();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;

        // Check if there is a touchable component, if true, do ; else, ignore
        if (collision.collider.GetComponent<ITouchable>() != null)
        {
            collision.collider.GetComponent<ITouchable>()?.Touch(Power);
            
            // reset direction (otherwise the bullet continue moving even after a hit)
            Direction = Vector3.zero;
            
            OnTouch?.Invoke();
            ReturnToPool();
        }
    }

    private void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }

    // Called when an object is getting out from the pool
    public void OnPooled()
    {
        OnPool?.Invoke();
        
        gameObject.SetActive(true);
        DestroyAfterTimeRoutine = StartCoroutine(DestroyAfterTime());
    }

    // Called when an object is getting back in the pool
    public void ReturnToPool()
    {
        Debug.Log("A bullet is returning to the pool");
        
        if (DestroyAfterTimeRoutine != null)
        {
            StopCoroutine(DestroyAfterTimeRoutine);
            DestroyAfterTimeRoutine = null;
        }

        StartCoroutine(DelayDestroy());
    }

    // Delay the destroy in order to let the OnTouch() event execute
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    // Destroy after x time if nothing collides
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(2.5f);
        ReturnToPool();
    }
}
