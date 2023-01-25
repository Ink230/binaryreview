namespace BitFlags;

public enum Conditions
{
  None = 0,
  Poisoned = 1 << 0,
  Ignited = 1 << 1,
  Frozen = 1 << 2,
  Paralyzed = 1 << 3,
  Confused = 1 << 4,
  Feared = 1 << 5,
  Envenomed = 1 << 6,
  Electrified = 1 << 7
}