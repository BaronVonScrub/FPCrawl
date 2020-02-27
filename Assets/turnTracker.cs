using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnTracker : MonoBehaviour
{
    public bool turning=false;
    private GameObject player;
    private MouseLook mouseLook;
    private float amountToTurn = 0;
    public float currentX = 0;
    public float goalX = 0;
    public float rotateSpeed = 90;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mouseLook = player.GetComponentInChildren<MouseLook>();
    }

    private void Update()
    {
        transform.Rotate(0, -(player.transform.rotation.eulerAngles.y-Mathf.Round(player.transform.rotation.eulerAngles.y)), 0);

        currentX = Mathf.Round(player.transform.rotation.eulerAngles.y);
        goalX = (goalX + 360) % 360;

        if (currentX - goalX != 0)
        {
            amountToTurn = TurnAmount(currentX, goalX);

            if (amountToTurn != 0)
            {
                transform.Rotate(0, amountToTurn, 0);
                //mouseLook.X += amountToTurn;
                turning = true;
            }
            else
                turning = false;
        }
        else
            turning = false;
}

    float TurnAmount(float current, float target)
    {
        float alpha = target - current;
        float beta = target - current + 360;
        float gamma = target - current - 360;
        float amount = 0;

        float smallestAbs = Mathf.Min(Mathf.Abs(alpha), Mathf.Abs(beta), Mathf.Abs(gamma));
        if (smallestAbs == 0)
            amount = 0;
        else if (smallestAbs == Mathf.Abs(alpha))
            amount = alpha;
        else if (smallestAbs == Mathf.Abs(beta))
            amount = beta;
        else if (smallestAbs == Mathf.Abs(gamma))
            amount = gamma;

        amount = Mathf.Clamp(amount, -Time.deltaTime * rotateSpeed, Time.deltaTime * rotateSpeed);

        return amount;
    }

}
