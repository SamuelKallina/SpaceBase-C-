using Xunit;

namespace SpaceBaseEnhanced.tests;

public class SpaceShipTest {
    [Fact]
    public void TestRefuel_IfFuelLesserThanZero_ThenThrowsArgumentException() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(1000, 1000, spaceBase);
        Assert.Throws<ArgumentException>(() => spaceShip.Refuel(-2));
    }

    [Fact]
    public void TestRefuel_IfFuelIsCalled_ThenFuelShouldHaveADifferentValue() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(1000, 1000, spaceBase);
        spaceShip.Fuel = 10;
        spaceShip.Refuel(20);
        Assert.NotEqual(10, spaceShip.Fuel);
    }

    [Fact]
    public void TestRefuel_IfFuelIsCalled_ThenFuelShouldHaveANewValue() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(1000, 1000, spaceBase);
        spaceShip.Fuel = 0;
        spaceShip.Refuel(10);
        Assert.Equal(10, spaceShip.Fuel);
    }

    [Fact]
    public void TestMoveTo_IfFuelIsNotEnough_ThenThrowsApplicationException() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(1000, 1000, spaceBase);
        Assert.Throws<ApplicationException>(() => spaceShip.MoveTo(50000, 50000));
    }

    [Fact]
    public void TestMoveTo_IfCalled_ThenShipShouldHaveANewPosX() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(1000, 1000, spaceBase);
        spaceShip.Refuel(spaceShip.MaxFuel);
        spaceShip.MoveTo(1001, 1001);
        Assert.Equal(1001, spaceShip.PosX);
    }

    [Fact]
    public void TestMoveTo_IfCalled_ThenShipShouldHaveANewPosY() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(1000, 1000, spaceBase);
        spaceShip.Refuel(spaceShip.MaxFuel);
        spaceShip.MoveTo(1001, 1001);
        Assert.Equal(1001, spaceShip.PosY);
    }
    
    
    
}