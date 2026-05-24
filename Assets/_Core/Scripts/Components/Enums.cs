namespace _Core.Scripts.Components
{
    public enum ShipSize
    {
        None,
        Shuttle,
        Frigate,
        Gunship,
        Destroyer,
        Cruiser,
        Battleship,
        Dreadnought,
    }

    public enum ShieldType
    {
        None, //нет
        Fixed, //фиксированный
        Dynamic, //поворачивается в сторонупредпологаемой атаки
    }

    public enum SlotType
    {
        Hybrid, 
        Energy,
        EnergyBeem,
        Ballistic,
    }

    public enum SlotSize
    {
        Small,
        Medium,
        Large,
    }

    public enum SkillType //набросано для примера
    {
        None,
        SpeedBoost, //условно двигается неуправляемо вперед, с удвоеной скоростью (возможность тарана?)
        ReloadSpeed, //скорость перезарядки орудий удвоена на 10 сек
        ThermalTraps, //выстреливает вокруг корабля тепловыми ловушками, взрывающими\уводящими в стороны ракеты
        HeatCooler, //на короткое время снижает генерацию перегрева и незначительно снижает тот, который уже есть
    }

    public enum ModifierType
    {
        Hp, Armour, Speed, Agility, 
        ShieldAngle, SensorPower, 
        CrewMaxExperience,
        HeatCapacity, FuelCapacity
    }
}