using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster MyActionMaster;
	private ActionMaster.Action EndTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action Tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action Reset = ActionMaster.Action.Reset;

	[SetUp]
	public void SetUp(){
		MyActionMaster = new ActionMaster();
	}

	[Test]
	public void T00PassingTest(){
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01_OneStrikeReturnsEndTurn(){
		Assert.AreEqual(EndTurn, MyActionMaster.Bowl(10));
	}

	[Test]
	public void T02_BowlEightReturnsTidy(){
		Assert.AreEqual(Tidy,MyActionMaster.Bowl(8));
	}

	[Test]
	public void T03_BowlSpareReturnsEndTurn(){
		MyActionMaster.Bowl(3);
		Assert.AreEqual(EndTurn,MyActionMaster.Bowl(7));
	}

}