using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float enemyWalkSpeed = 30f;
	public Rigidbody2D enemyRigidBody;

	private bool m_FacingRight = true;




	private void Flip() {
		// Switch the way the enemy is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the enemy's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
