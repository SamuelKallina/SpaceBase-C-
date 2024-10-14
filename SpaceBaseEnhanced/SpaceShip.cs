namespace SpaceBaseEnhanced {
    public class SpaceShip : IComparable<SpaceShip> {
        public readonly double MaxFuel = 2000;
        private readonly long _idCounter = 100;
        private SpaceBase _homeBase;
        private SpaceBase _dockingBase;

        public double FuelConsumptionPerAu { get; } = 3.58;

        public long Id { get; }

        public int PosX { get; set; }

        public int PosY { get; set; }

        public double Fuel { get; set; }

        public SpaceBase HomeBase {
            get => _homeBase;
            set => _homeBase = value ?? throw new ArgumentException("Value shall not be null!");
        }

        public SpaceBase DockingBase {
            get => _dockingBase;
            set {
                _dockingBase = value;
                if (value == HomeBase)
                {
                    Refuel(MaxFuel);
                }
            }
        }

        public SpaceShip(int posX, int posY, SpaceBase homeBase) {
            _idCounter++;
            Id = _idCounter;
            PosX = posX;
            PosY = posY;
            Fuel = MaxFuel;
            HomeBase = homeBase;
        }


        public void Refuel(double fuel) {
            if (fuel < 0)
            {
                throw new ArgumentException("Fuel Value cannot be negative!");
            }

            Fuel = Math.Min(Fuel + fuel, MaxFuel);
        }

        public void MoveTo(int posX, int posY) {
            var distance = CalculateDistanceTo(posX, posY);
            var consumption = CalculateConsuption(distance);
            if (consumption > Fuel)
            {
                throw new ApplicationException("Not enough fuel for this journey");
            }

            PosX = posX;
            PosY = posY;
            Fuel -= consumption;
        }

        private double CalculateDistanceTo(int posX, int posY) {
            var distance = Math.Sqrt(Math.Pow((PosX - posX), 2) + Math.Pow((PosY - posY), 2));
            return distance;
        }

        private double CalculateConsuption(double distanceInAu) {
            if (distanceInAu < 0)
            {
                return 0;
            }

            return (distanceInAu * FuelConsumptionPerAu);
        }

        public bool IsHomeBase(SpaceBase spaceBase) {
            return HomeBase.Equals(spaceBase);
        }

        public int CompareTo(SpaceShip? other) {
            return other == null ? 1 : Id.CompareTo(other.Id);
        }

        public override string ToString() {
            return $"Id: {Id}, PosX: {PosX}, PosY: {PosY}, Fuel: {Fuel} / {MaxFuel}";
        }
    }
}