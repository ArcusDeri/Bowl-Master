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

	[Test]
	public void T02_Bowl12(){
		int[] rolls = {1,2};
		string rollsString= "12";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03_Bowl123(){
		int[] rolls = {1,2,3};
		string rollsString= "123";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04_Bowl1234(){
		int[] rolls = {1,2,3,4};
		string rollsString= "1234";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05_Bowl12345(){
		int[] rolls = {1,2,3,4,5};
		string rollsString= "12345";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06_BowlStrike(){
		int[] rolls = {10};
		string rollsString= "X";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07_BowlStrikeThen1(){
		int[] rolls = {10,1};
		string rollsString= "X1";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T08_BowlStrikeThen12(){
		int[] rolls = {10,1,2};
		string rollsString= "X12";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}
	
	[Test]
	public void T09_BowlStrikeThen123(){
		int[] rolls = {10,1,2,3};
		string rollsString= "X123";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T10_BowlStrikeInTheMiddle(){
		int[] rolls = {1,2,10};
		string rollsString= "12X";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T11_BowlStrikeInTheMiddle2(){
		int[] rolls = {1,2,10,1};
		string rollsString= "12X1";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}
	
	[Test]
	public void T12_Bowl19(){
		int[] rolls = {1,9};
		string rollsString= "1/";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T13_SpareInLastFrame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,3};
		string rollsString= "1111111111111111111/3";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T14_StrikeInLastFrame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,1,1};
		string rollsString= "111111111111111111X11";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}
	
	[Test]
	public void T14_Zero(){
		int[] rolls = {0};
		string rollsString= "-";
		Assert.AreEqual(rollsString,Scores.FormatRolls(rolls.ToList()));
	}
}