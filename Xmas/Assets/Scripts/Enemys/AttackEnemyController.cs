using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask enemyLayer;
    public Transform AttackBase;

    [SerializeField] private Transform Bottle;
    [SerializeField] private Transform Shovel;
    public float damage;

    public float attackAngle;
    public float BottleAttackAngle;
    GameObject bloodEffect;
    Transform[] weapons;
    Animator animator;
    public int weaponIndex;
    string weaponName;
    private void Start() {
        bloodEffect = GameObject.FindGameObjectsWithTag("BloodEffect")[0];
        animator = GetComponentInParent<Animator>();
        weapons = GetComponentsInChildren<Transform>();
        
        switch(weaponIndex)
        {
            case 2:
                weaponName = "Bottle";
                animator.SetLayerWeight(2,1f);
                break;
            case 3:
                weaponName = "shovel0";
                animator.SetLayerWeight(3,1f);
                break;
            default:
                animator.SetLayerWeight(1,1f);
                weaponName = "Knife";
                break;

        }


        foreach (Transform t in weapons)
        {
            if(t.name != weaponName && t.name != "WeaponHolder" && t.name != "default")
                t.gameObject.SetActive(false);
        }
        
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
        RaycastHit hit;
        if(Physics.Raycast(Bottle.position, Bottle.up,out hit,1.3f) )
            rayAttack(hit);       
    }
    public void ShovelAttack()
    {
        RaycastHit hit;
        if(Physics.Raycast(Shovel.position, Shovel.up,out hit,3f,enemyLayer))
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
        Gizmos.DrawRay(Shovel.position, Shovel.up*3f);
    }
}
