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
	private ActionMaster.Action EndGame = ActionMaster.Action.EndGame;

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

	[Test]
	public void T04_SecondBowlInLastFrameCausingSpareReturnsReset(){
		int iter = 1;
		while (iter < 20){
			MyActionMaster.Bowl(2);
			iter += 1;
		}
		Assert.AreEqual(Reset,MyActionMaster.Bowl(8));
	}

	[Test]
	public void T05_SecondBowlInLastFrameNotCausingSpareReturnsEndGame(){
		int iter = 1;
		while (iter < 20){
			MyActionMaster.Bowl(2);
			iter += 1;
		}

		Assert.AreEqual(EndGame,MyActionMaster.Bowl(7));
	}

	[Test]
	public void T06_ThirdBowlInLastFrameReturnsEndGame(){
		int iter = 1;
		while (iter < 20){
			MyActionMaster.Bowl(2);
			iter += 1;
		}
		MyActionMaster.Bowl(8);
		Assert.AreEqual(EndGame,MyActionMaster.Bowl(7));
	}

	[Test]
	public void T07_LastThreeBowlsStrikeReturnEndGame(){
		int iter = 1;
		while (iter < 19){
			MyActionMaster.Bowl(2);
			iter += 1;
		}
		MyActionMaster.Bowl(10);
		MyActionMaster.Bowl(10);
		Assert.AreEqual(EndGame,MyActionMaster.Bowl(10));
	}

	[Test]
	public void T08_BowlStrikeThenNothingInLastFrameReturnsReset(){
		int iter = 1;
		while (iter < 19){
			MyActionMaster.Bowl(2);
			iter += 1;
		}
		MyActionMaster.Bowl(10);
		Assert.AreEqual(Reset,MyActionMaster.Bowl(0));
	}

	[Test]
	public void T09_BowlStrikeThenTwoInLastFrameReturnsTidy(){
		int iter = 1;
		while (iter < 19){
			MyActionMaster.Bowl(2);
			iter += 1;
		}
		MyActionMaster.Bowl(10);
		Assert.AreEqual(Tidy,MyActionMaster.Bowl(2));
	}

	[Test]
	public void T10_PerfectGameReturnsEndGame(){
		int iter = 1;
		while(iter < 12){
			MyActionMaster.Bowl(10);
			iter += 1;
		}
		Assert.AreEqual(EndGame,MyActionMaster.Bowl(10));
	}

	[Test]
	public void T11_ScoreZeroThenTenNextFrameShouldReturnEndTurn(){
		MyActionMaster.Bowl(0);
		MyActionMaster.Bowl(10);
		MyActionMaster.Bowl(4);
		Assert.AreEqual(EndTurn,MyActionMaster.Bowl(2));
	}

	[Test]
	public void T12_ScoreOnesThenThreeStrikesInLastFrameReturnsResetResetEndgame(){
		int iter = 1;
		while(iter < 19){
			MyActionMaster.Bowl(1);
			iter += 1;
		}
		Assert.AreEqual(Reset,MyActionMaster.Bowl(10));
		Assert.AreEqual(Reset,MyActionMaster.Bowl(10));
		Assert.AreEqual(EndGame,MyActionMaster.Bowl(10));
	}

	[Test]
	public void T13_ScoreFiveThenZeroReturnsEndTurn(){
		MyActionMaster.Bowl(5);
		Assert.AreEqual(EndTurn,MyActionMaster.Bowl(0));
	}
}