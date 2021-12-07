using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask enemyLayer;
    public Transform AttackBase;

    [SerializeField] private Transform Bottle;
    public float damage;

    public float attackAngle;
    public float BottleAttackAngle;
    GameObject bloodEffect;
    private void Start() {
        bloodEffect = GameObject.FindGameObjectsWithTag("BloodEffect")[0];
    }
    public void KnifeAttack()
    {
        Vector3 scndAttack = new Vector3(Mathf.Cos(attackAngle)*AttackBase.forward.x-Mathf.Sin(attackAngle)*AttackBase.forward.z,0f,Mathf.Sin(attackAngle)*AttackBase.forward.x+Mathf.Cos(attackAngle)*AttackBase.forward.z);   
        Vector3 thrdAttack = new Vector3(Mathf.Cos(-0.6f)*AttackBase.forward.x-Mathf.Sin(-0.6f)*AttackBase.forward.z,0f,Mathf.Sin(-0.6f)*AttackBase.forward.x+Mathf.Cos(-0.6f)*AttackBase.forward.z);
        RaycastHit hit;
        
        if(Physics.Raycast(AttackBase.position, AttackBase.forward,out hit, 0.8f) )
            rayAttack(hit); 
        else if(Physics.Raycast(AttackBase.position, scndAttack,out hit, 1f) )
            rayAttack(hit);
        else if(Physics.Raycast(AttackBase.position, thrdAttack,out hit, 0.8f) )
            rayAttack(hit);    
    }
    public void BottleAttack()
    {
        Debug.Log("1");
        RaycastHit hit;
        if(Physics.Raycast(Bottle.position, Bottle.up,out hit,1.3f) )
            rayAttack(hit); 
          
    }
    private void rayAttack(RaycastHit hit)
    {
        ExtremityPlayer extremityController = hit.transform.GetComponent<ExtremityPlayer>();
        if (extremityController != null)
        {
            GameObject blood = Instantiate(bloodEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(blood,0.2f);
            extremityController.ExtremityTakeDamage(damage);
        }
    }

    private void OnDrawGizmos() 
    {   
        // Rayos del cuchillo
        // Vector3 scndAttack = new Vector3(Mathf.Cos(attackAngle)*AttackBase.forward.x-Mathf.Sin(attackAngle)*AttackBase.forward.z,0f,Mathf.Sin(attackAngle)*AttackBase.forward.x+Mathf.Cos(attackAngle)*AttackBase.forward.z);   
        // Vector3 thrdAttack = new Vector3(Mathf.Cos(-0.6f)*AttackBase.forward.x-Mathf.Sin(-0.6f)*AttackBase.forward.z,0f,Mathf.Sin(-0.6f)*AttackBase.forward.x+Mathf.Cos(-0.6f)*AttackBase.forward.z);
        // Gizmos.DrawRay(AttackBase.position, AttackBase.forward*0.8f);
        // Gizmos.DrawRay(AttackBase.position, scndAttack*1f);
        // Gizmos.DrawRay(AttackBase.position, thrdAttack*0.8f);
        //Vector3 bottleAttack = new Vector3(Mathf.Cos(BottleAttackAngle)*Bottle.forward.x-Mathf.Sin(BottleAttackAngle)*Bottle.forward.z,Bottle.forward.y,Mathf.Sin(BottleAttackAngle)*Bottle.forward.x+Mathf.Cos(BottleAttackAngle)*Bottle.forward.z);
        //Gizmos.DrawRay(Bottle.position, bottleAttack*1f);
        Gizmos.DrawRay(Bottle.position, Bottle.up*1.3f);
    }
}
