using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public PhysicalParticle MyParticle;
    public Space MySpace;
    public float TimeDestroy;
    public Vector3 SpeedDestroyParticle;
    public int CountParticles = 30;
    public PhysicalParticle[] MyParticles;
    private bool _isDestroyed;
	// Use this for initialization
	void Start ()
    {
        _isDestroyed = false;

        MyParticles = new PhysicalParticle[CountParticles];
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_isDestroyed) return;
	    if (TimeDestroy < MySpace.MyTime)
        {
            MyParticle.Stop();
            GameObject g = Resources.Load<GameObject>("PhysicalParticle");
            for (int i = 0; i < MyParticles.Length; i++)
            {
                GameObject inst = Instantiate(g);
                PhysicalParticle p = inst.GetComponent<PhysicalParticle>();
                p.MySpace = MySpace;
                p.StartPos = MyParticle.CurPos;
                float r = Random.Range(0f, 1f);
                p.StartSpeed = Quaternion.Euler(0, 0, 360 * r) * SpeedDestroyParticle;
                MyParticles[i] = p;
            }
            for (int i = 0; i < MyParticles.Length; i++)
            {
                MyParticles[i].IsStart = true;
            }
            _isDestroyed = true;
        }
	}
}
