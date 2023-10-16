using UnityEngine;

public class GunController : EquippedItemHandler
{
    private float speed = 2000f;

    private void Start()
    {
        GameObject lookatPoint = GameObject.Find("GunLookAt");
        transform.LookAt(lookatPoint.transform);
    }

    //
    private void Update()
    {
        FireGun();
    }

    //
    protected override void GameObjectName(string name)
    {
        name = gameObject.name;
    }

    //
    protected override void ControllingAmount(float amount)
    {
        throw new System.NotImplementedException();
    }

    //
    protected override void OnOrOff(bool isOnOrOff)
    {
        throw new System.NotImplementedException();
    }

    //
    protected override void ObjectFuncComposition(string name, float amount, bool _isOnOrOff)
    {
        throw new System.NotImplementedException();
    }

    // fire gun
    private void FireGun()
    {
        //if (base.UseItem(true))
        //{
        //    Debug.Log("PEW PEW");
        //}
        if (Input.GetMouseButtonDown(0))
        {
            GameObject _bullet = Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
            
            Vector3 bulletPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            SaltGunPS(bulletPos);

            Rigidbody _bulletRB = _bullet.GetComponent<Rigidbody>();
            _bulletRB.velocity = gameObject.transform.forward * Time.fixedDeltaTime * speed;

            _bullet.transform.localPosition = bulletPos;
        }
    }

    // Testing ps ... TODO: Add as part of visuals class ? event based maybe 
    private void SaltGunPS(Vector3 gunPos)
    {
        GameObject _ps = Instantiate(Resources.Load("Prefabs/Ps_SaltGun_Blast")) as GameObject;

        _ps.transform.position = gunPos;

        _ps.transform.forward = gameObject.transform.forward;

        ParticleSystem pSystem = _ps.GetComponent<ParticleSystem>();

        pSystem.Play();

        Destroy(_ps.gameObject, 1f);
    }
}