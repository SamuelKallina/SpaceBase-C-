namespace SpaceBaseEnhanced {
    public class SpaceShip : IComparable<SpaceShip> {
        public readonly double MaxFuel = 2000;
        private readonly double _fuelConsumptionPerAu = 3.58;
        private long _idCounter = 100;
        private readonly long _id;
        private int _posX;
        private int _posY;
        private double _fuel;
        private SpaceBase _homeBase;
        private SpaceBase _dockingBase;

        public long IdCounter {
            get => _idCounter;
            set => _idCounter = value;
        }

        public double FuelConsumptionPerAu => _fuelConsumptionPerAu;

        public long Id => _id;

        public int PosX {
            get => _posX;
            set => _posX = value;
        }

        public int PosY {
            get => _posY;
            set => _posY = value;
        }

        public double Fuel {
            get => _fuel;
            set => _fuel = value;
        }

        public SpaceBase HomeBase {
            get => _homeBase;
            set => _homeBase = value ?? throw new ArgumentException("Value shall not be null!");
        }

        public SpaceBase DockingBase {
            get => _dockingBase;
            set {
                _dockingBase = value;
                if (value == HomeBase) {
                    Refuel(MaxFuel);
                }
            }
        }

        public SpaceShip(int posX, int posY, SpaceBase homeBase) {
            _idCounter++;
            _id = _idCounter;
            PosX = posX;
            PosY = posY;
            Fuel = MaxFuel;
            HomeBase = homeBase;
        }


        public void Refuel(double fuel) {
            if (fuel < 0) {
                throw new ArgumentException("Fuel Value cannot be negative!");
            }

            _fuel = Math.Min(_fuel + fuel, MaxFuel);
        }

        public void MoveTo(int posX, int posY) {
            var distance = CalculateDistanceTo(posX, posY);
            var consumption = CalculateConsuption(distance);
            if (consumption > Fuel) {
                throw new Exception("Not enough fuel for this journey");
            }

            _posX = posX;
            _posY = posY;
            _fuel -= consumption;
        }

        private double CalculateDistanceTo(int posX, int posY) {
            var distance = Math.Sqrt(Math.Pow((PosX - posX), 2) + Math.Pow((PosY - posY), 2));
            return distance;
        }

        private double CalculateConsuption(double distanceInAu) {
            if (distanceInAu < 0) {
                return 0;
            }

            return (distanceInAu * _fuelConsumptionPerAu);
        }

        public bool IsHomeBase(SpaceBase spaceBase) {
            return HomeBase.Equals(spaceBase);
        }

        public int CompareTo(SpaceShip? other) {
            return other == null ? 1 : Id.CompareTo(other.Id);
        }

        // public override bool Equals(object obj) {
        //     return base.Equals(obj);
        // }
        //
        // public override int GetHashCode() {
        //     return base.GetHashCode();
        // }
        //
        // public override string ToString() {
        //     return base.ToString();
        // }
        // WIRD ALLES VON C#  IM HINTERGRUND SELBST GENERIERT
    }
}