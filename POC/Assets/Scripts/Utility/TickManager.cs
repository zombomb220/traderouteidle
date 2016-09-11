using UnityEngine;
using System;


public class TickManager {

	private Action MethodToCall;
	private float _internalTime;
	private float _nextTick;
	private float _timeBetweenTicks;
	private readonly float _originalTimeBetweenTicks;

	public TickManager(float secondsBetweenTicks, Action method){

		if (secondsBetweenTicks <= 0)
			throw new UnityException ("seconds between ticks must be greater than zero!");

		_timeBetweenTicks = _originalTimeBetweenTicks = secondsBetweenTicks;
		MethodToCall = method;
		_internalTime = 0;
		_nextTick = secondsBetweenTicks;
	}


	public void Update(){

		_internalTime += Time.deltaTime;

		if (_nextTick <= _internalTime) {

			_nextTick = _internalTime + _timeBetweenTicks;
			MethodToCall.Invoke ();
		}
	}


	/// <summary>
	/// Modify the amount of time between ticks.  1 = 100% = no change.  .95 = reduces time by 5%, speeding it up.  
	/// </summary>
	/// <param name="modifier">float greater than 0.  multiplied against timeBetweenTicks</param>
	public void ModifyTime(float modifier){

		if (modifier <= 0)
			throw new UnityException ("modifier value must be greater than zero!");

		_timeBetweenTicks *= modifier;
	}


	public void ResetToOriginalTime(){
		_timeBetweenTicks = _originalTimeBetweenTicks;
	}
}
