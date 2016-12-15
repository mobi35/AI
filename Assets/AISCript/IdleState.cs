using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState {
	#region IEnemyState implementation
	private Enemy enemy;
	private float idleTimer;

	private float idleDuration = 5;

	public void Execute ()
	{

		Idle ();

		if (enemy.Target != null) 
		{
			enemy.ChangeState(new PatrolState());
		}
	}

	public void Enter (Enemy enemy)
	{
		this.enemy = enemy;
	}

	public void Exit ()
	{

	}

	public void OnTriggerEnter (Collider2D other)
	{

	}

	private void Idle ()
	{
		enemy.AN.SetFloat ("speed", 0);
		idleTimer += Time.deltaTime;
		if (idleTimer >= idleDuration) 
		{
			enemy.ChangeState(new PatrolState());
		}
	}
	#endregion



}
