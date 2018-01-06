using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00_PassingTest(){
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01_Bowl1(){
		int[] rolls = {1};
		string rollsString= "1";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}
}