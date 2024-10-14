using Xunit;

namespace SpaceBaseEnhanced.tests;

public class SpaceBaseTest {
    [Fact]
    public void TestDocking_IfSpaceShipIsNull_ThenThrowArgumentNullException() {
        List<SpaceShip> spaceShipsEmpty = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShipsEmpty, 2000, 1700, "ISS");
        SpaceShip? spaceShipNull = null;
        Assert.Throws<ArgumentNullException>("spaceShip", () => spaceBase.Docking(spaceShipNull));
    }

    [Fact]
    public void TestDocking_IfShipIsAlreadyDocked_ThenThrowApplicationException() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        Assert.Throws<ApplicationException>(() => spaceBase.Docking(spaceShip));
    }

    [Fact]
    public void TestDocking_IfSpaceShipMatchesAllCriteria_ThenSpaceShipShouldReturnTrue() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        Assert.True(spaceBase.Docking(spaceShip));
    }

    [Fact]
    public void TestDocking_IfSpaceShipMatchesAllCriteria_ThenSpaceShipShouldBeAddedToList() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        Assert.Contains(spaceShip, spaceBase.ShipList);
    }

    [Fact]
    public void TestDocking_IfSpaceShipMatchesAllCriteria_ThenSpaceShipShouldSetSpaceBaseAsHomeBase() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        Assert.True(spaceShip.HomeBase == spaceBase);
    }

    [Fact]
    public void TestMoveShipTo_IfSpaceShipIsNull_ThenMoveShipToShouldReturnNull() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        SpaceBase? spaceBaseNull = null;
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        Assert.Null(spaceBase.MoveShipTo(spaceShip.Id, spaceBaseNull));
    }

    // [Fact]
    // public void TestMoveShipTo_IfNoShipWasFound_ThenMoveShipToShouldReturnNull() {
    //     List<SpaceShip> spaceShips = new List<SpaceShip>();
    //     var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
    //     SpaceBase? spaceBase1 = new SpaceBase(spaceShips, 2001, 1701, "AlfredoInternational Station");
    //     var spaceShip = new SpaceShip(2001, 1701, spaceBase);
    //     var spaceShipNotDocked = new SpaceShip(2001, 1701, spaceBase);
    //     spaceBase.Docking(spaceShip);
    //     // spaceBase.ShipList.Find(ship => ship.Id == spaceShip);
    //     Assert.Null(spaceBase.MoveShipTo(spaceShipNotDocked.Id, spaceBase1));
    // }

    [Fact]
    public void TestMoveShipTo_IfNotEnoughFuel_ThenMoveToShouldThrowException() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        SpaceBase? spaceBase1 = new SpaceBase(spaceShips, 3000, 4700, "AlfredoInternational Station");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        var spaceShipNotDocked = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        // spaceBase.ShipList.Find(ship => ship.Id == spaceShip);
        Assert.Throws<ArgumentException>(() => spaceBase.MoveShipTo(spaceShipNotDocked.Id, spaceBase1));
    }

    [Fact]
    public void TestArrangeShips_IfSortedShipListIsNull_ThenArrangeShipsShouldThrowArgumentNullException() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        spaceBase.ShipList = null;
        Assert.Throws<ArgumentNullException>(() => spaceBase.ArrangeShips());
    }
    [Fact]
public void TestArrangeShipsByFuel_IfSortedShipListIsNull_ThenArrangeShipsShouldThrowArgumentNullException() {
        List<SpaceShip> spaceShips = new List<SpaceShip>();
        var spaceBase = new SpaceBase(spaceShips, 2000, 1700, "ISS");
        var spaceShip = new SpaceShip(2001, 1701, spaceBase);
        spaceBase.Docking(spaceShip);
        spaceBase.ShipList = null;
        Assert.Throws<ArgumentNullException>(() => spaceBase.ArrangeShipsByFuel());
    }



}