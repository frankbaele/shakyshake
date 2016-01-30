using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DiscManager : MonoBehaviour
{
	public GameObject discPrefab;
	public List<Disc> discs = new List<Disc>();
	void Start ()
	{
		Events.instance.AddListener<DiscFired>(fireDisc);	
	}
	
	void Update (){
		foreach (Disc disc in discs.ToList()) // Loop through List with foreach.
		{
			if(disc.destroyed){
				discs.Remove(disc);
				Destroy(disc.gameObject);
			}
		}
	}
	

	void fireDisc (DiscFired e)
	{
		var newDisc = createDisc();
		newDisc.fireDisc(e.position, e.velocity, e.time);
	}
	
	Disc createDisc()
	{
		var gameObject = (GameObject)Instantiate(discPrefab);
		var disc = gameObject.GetComponent<Disc>();
		discs.Add(disc);
		return disc;
	}
}
