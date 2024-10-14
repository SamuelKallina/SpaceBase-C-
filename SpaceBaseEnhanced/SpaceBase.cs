namespace SpaceBaseEnhanced {
    public abstract class SpaceBase {
        public string Name { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public List<SpaceShip> ShipList { get; set; }

        public SpaceBase(List<SpaceShip> shipList, int posY, int posX, string name) {
            ShipList = shipList; //TODO find out if i need to use the field or property for assignment
            PosY = posY;
            PosX = posX;
            Name = name;
        }

        public bool Docking(SpaceShip spaceShip) {
            if (spaceShip == null) {
                throw new ArgumentException("Spaceship cannot be null!");
            }

            if (ShipList.Any(ship => ship.Id == spaceShip.Id)) {
                throw new System.ApplicationException("Ship is already docked to this station!");
            }

            spaceShip.DockingBase = this;
            return true;
        }

        public SpaceShip MoveShipTo(long id, SpaceBase spaceBase) {
            if (id == null) {
                throw new ArgumentException(
                    "How did you even do that? The parameter is not nullable! How bad can you be?");
            }

            if (spaceBase == null) {
                return null;
            }

            SpaceShip schiff = ShipList.FirstOrDefault(ship => ship.Id == id);
            if (schiff == null) {
                return null;
            }

            ShipList.Remove(schiff);
            schiff.MoveTo(spaceBase.PosX, spaceBase.PosY);
            spaceBase.Docking(schiff);
            return schiff;
        }

        public List<SpaceShip> ArrangeShips() {
            var sortedShipList = new List<SpaceShip>(ShipList);
            if (sortedShipList == null) throw new ArgumentNullException(nameof(sortedShipList));
            sortedShipList.Sort();
            return sortedShipList;
        }

        public List<SpaceShip> ArrangeShipsByFuel() {
            var sortedShipList = new List<SpaceShip>(ShipList);
            if (sortedShipList == null) throw new ArgumentNullException(nameof(sortedShipList)); //TODO assertions
            sortedShipList.Sort(new FuelComparer());
            return sortedShipList;
        }
    }

    public class FuelComparer : IComparer<SpaceShip> {
        public int Compare(SpaceShip? s1, SpaceShip? s2) {
            if (s1 == null || s2 == null)
                throw new ArgumentException("Eines oder beide Objekte sind null.");
            return s1.Fuel.CompareTo(s2.Fuel);
        }
    }
}