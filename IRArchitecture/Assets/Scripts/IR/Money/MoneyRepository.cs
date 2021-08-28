using IRCore;
using IRCore.Save;

/// <summary>
/// Add interface ISaveable if you need save data (serialization)
/// </summary>
sealed class MoneyRepository : ValueRepository<int>, ISaveable { }