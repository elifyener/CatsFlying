using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cat : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private SpringJoint2D _springJoint2D;
    public Rigidbody2D _bowRigidBody2D;
    private bool _isPressed = false;

    public float releaseTime = 0.15f;
    public float maxDragDistance = 4f;

    public GameObject nextBall;

    public ParticleSystem PlayerFlyingParticleSystem;
    public ParticleSystem.MainModule PlayerFlyingParticleSystemMainModule;

    void Start()
    {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        _springJoint2D = gameObject.GetComponent<SpringJoint2D>();

        PlayerFlyingParticleSystem.Stop();
    }

    void Update()
    {
        if (_isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, _bowRigidBody2D.position) > maxDragDistance)
            {
                _rigidBody2D.position = _bowRigidBody2D.position + (mousePos - _bowRigidBody2D.position).normalized * maxDragDistance;
            }	
			else
            {
				_rigidBody2D.position = mousePos;
            }

		}
    }

    private void OnMouseDown()
    {
        _isPressed = true;
        _rigidBody2D.isKinematic = true;
        AudioManager.Instance.PlayBowSound();
        PlayerFlyingParticleSystem.Stop();
    }

    private void OnMouseUp()
    {
        _isPressed = false;
        _rigidBody2D.isKinematic = false;
        PlayerFlyingParticleSystem.Play();
        AudioManager.Instance.PlayWhooshSound();
        StartCoroutine(Release());
        AudioManager.Instance.PlayMeowSound();
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        _springJoint2D.enabled = false;

        this.enabled = false;

		yield return new WaitForSeconds(2f);

		if (nextBall != null)
		{
			nextBall.SetActive(true);
            CatHealth._catHealth--;
            
		}
        else if(Enemy.EnemiesAlive > 0)
		{
			Enemy.EnemiesAlive = 0;
			FinishScreen.Instance.OpenLoseScreen();
		}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerFlyingParticleSystem.Stop();
    }
}
