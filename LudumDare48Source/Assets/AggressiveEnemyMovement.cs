using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemyMovement : EnemyMovement {
    private bool m_FacingRight = true;

    public override void Update() {
        // movement
        var targetPosition = GetTagetPosition();
        var direction = (targetPosition - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * speed;

        // rotation
        if (direction.x > 0 && !m_FacingRight) {
            Flip();
        } else if (direction.x < 0 && m_FacingRight) {
            Flip();
        }

        // check if it reached destination
        if (!isAggred && (base.target - transform.position).magnitude < 0.5) {
            GoToNewTarget();
        }

        // check if it got too far from player
        if ((transform.position - player.transform.position).magnitude >= maxDistanceFromPlayer) {
            Reset();
        }
    }


    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

}