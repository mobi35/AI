using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState {
	#region IEnemyState implementation
	private float patrolTimer;
	private Enemy enemy;
	private float patrolDuration = 5;
	public void Execute ()
	{

		Patrol ();

		enemy.Move ();

		if (enemy.Target != null && enemy.InThrowRange) 
		{
			enemy.ChangeState(new RangeState());
		}
	}

	public void Enter (Enemy enemy)
	{
		this.enemy = enemy;
	}

	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "Edge")
		{
			enemy.ChangeDirection();
		}
	}

	public void Exit ()
	{

	}



	private void Patrol ()
	{

		patrolTimer += Time.deltaTime;
		if (patrolTimer >= patrolDuration) 
		{
			enemy.ChangeState(new IdleState());
		}
	}
	#endregion



}
