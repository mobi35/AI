using UnityEngine;
using System.Collections;

public class RangeState : IEnemyState {
	#region IEnemyState implementation
	private Enemy enemy;

	private float throwTimer;
	private float throwCoolDown = 4;
	private bool canThrow = true;
	public void Execute ()
	{
		ThrowKnife ();
		if (enemy.InMeleeRange) 
		{
			enemy.ChangeState(new MeleeState());
		}
		else if (enemy.Target != null) {
			enemy.Move ();
		} 
		else 
		{
			enemy.ChangeState(new IdleState());
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

	private void ThrowKnife()
	{
		throwTimer += Time.deltaTime;

		if (throwTimer >= throwCoolDown) 
		{
			canThrow = true;
			throwTimer = 0;
		}

		if (canThrow)
		{
			canThrow = false;
			enemy.AN.SetTrigger("wave");
		}
	}

	#endregion



}
