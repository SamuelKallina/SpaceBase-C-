namespace SpaceBaseEnhanced {
    public class SpaceBase : FuelComparer {
        public string Name { get; set; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public List<SpaceShip> ShipList { get; set; }

        public SpaceBase(List<SpaceShip> shipList, int posY, int posX, string name) {
            ShipList = shipList;
            PosY = posY;
            PosX = posX;
            Name = name;
        }

        public bool Docking(SpaceShip spaceShip) {
            if (spaceShip == null)
            {
                throw new ArgumentNullException(nameof(spaceShip));
            }

            if (ShipList.Any(ship => ship.Id == spaceShip.Id))
            {
                throw new ApplicationException("Ship is already docked to this station!");
            }

            ShipList.Add(spaceShip);
            spaceShip.DockingBase = this;
            return true;
        }

        public SpaceShip MoveShipTo(long id, SpaceBase? spaceBase) {
            if (id == null)
            {
                throw new ArgumentException(
                    "How did you even do that? The parameter is not nullable! How bad can you be?");
            }

            if (spaceBase == null)
            {
                return null;
            }

            var schiff = ShipList.FirstOrDefault(ship => ship.Id == id, null);
            if (schiff == null)
            {
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
            if (sortedShipList == null)
                throw new ArgumentNullException(nameof(sortedShipList));
            sortedShipList.Sort(new FuelComparer());
            return sortedShipList;
        }
        
        public override string ToString() {
            return $"Name: {Name}, PosX: {PosX}, PosY: {PosY}, Ships Inside the Station: {ShipList}";
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