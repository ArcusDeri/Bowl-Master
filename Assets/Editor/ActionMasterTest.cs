using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private List<int> PinFalls;
	private ActionMaster.Action EndTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action Tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action Reset = ActionMaster.Action.Reset;
	private ActionMaster.Action EndGame = ActionMaster.Action.EndGame;

	[SetUp]
	public void SetUp(){
		PinFalls = new List<int>();
	}

	[Test]
	public void T00_PassingTest(){
		Assert.AreEqual(1,1);
	}

	[Test]
	public void T01_OneStrikeReturnsEndTurn(){
		PinFalls.Add(10);
		Assert.AreEqual(EndTurn, ActionMaster.NextAction(PinFalls));
	}

	[Test]
	public void T02_BowlEightReturnsTidy(){
		PinFalls.Add(8);
		Assert.AreEqual(Tidy, ActionMaster.NextAction(PinFalls));
	}

	[Test]
	public void T03_BowlSpareReturnsEndTurn(){
		int[] rolls = {8, 2};
		Assert.AreEqual(EndTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04_SecondBowlInLastFrameCausingSpareReturnsReset(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		Assert.AreEqual(Reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T05_SecondBowlInLastFrameNotCausingSpareReturnsEndGame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9};
		Assert.AreEqual(Reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06_ThirdBowlInLastFrameReturnsEndGame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9, 1};
		Assert.AreEqual(EndGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07_LastThreeBowlsStrikeReturnEndGame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10, 10};
		Assert.AreEqual(EndGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T08_BowlStrikeThenNothingInLastFrameReturnsReset(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0};
		Assert.AreEqual(Reset, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09_BowlTwoInLastFrameReturnsTidy(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 2};
		Assert.AreEqual(Tidy, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10_PerfectGameReturnsEndGame(){
		int[] rolls = {10,10,10,10,10,10,10,10,10,10,10,10};
		Assert.AreEqual(EndGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11_ScoreZeroThenTenNextFrameShouldReturnEndTurn(){
		int[] rolls = {0,10};
		Assert.AreEqual(EndTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T12_ScoreOnesThenThreeStrikesInLastFrameReturnsResetResetEndgame(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10};
		Assert.AreEqual(EndGame, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T13_ScoreFiveThenZeroReturnsEndTurn(){
		int[] rolls = {5,0};
		Assert.AreEqual(EndTurn, ActionMaster.NextAction(rolls.ToList()));
	}

	[Test]
	public void T14_ScoreZeroThenFiveReturnsEndTurn(){
		int[] rolls = {0,5};
		Assert.AreEqual(EndTurn, ActionMaster.NextAction(rolls.ToList()));
	}

}