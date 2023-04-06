﻿// Decompiled with JetBrains decompiler
// Type: ImprovedPublicTransport.LineData
// Assembly: ImprovedPublicTransport, Version=1.0.6177.17409, Culture=neutral, PublicKeyToken=null
// MVID: 76F370C5-F40B-41AE-AA9D-1E3F87E934D3
// Assembly location: C:\Games\Steam\steamapps\workshop\content\255710\424106600\ImprovedPublicTransport.dll

using System.Collections.Generic;
using System.Linq;

namespace ImprovedPublicTransport2
{
  public struct LineData
  {
    public int TargetVehicleCount { get; set; }

    public float NextSpawnTime { get; set; }

    public bool BudgetControl { get; set; }

    public int DayBudget { get; set; } //deprecated

    public int NightBudget { get; set; } //deprecated

    public bool Unbunching { get; set; }

    public ushort Depot { get; set; }

    public HashSet<string> Prefabs { get; set; }

    public Queue<string> QueuedVehicles { get; set; }

    public List<VehicleInfo> VehicleTypes()
    {
      return Prefabs.Select(PrefabCollection<VehicleInfo>.FindLoaded).Where(p => p != null)
        .ToList();
    }
    
    public List<VehicleInfo> QueuedVehiclesList()
    {
      return QueuedVehicles.Select(PrefabCollection<VehicleInfo>.FindLoaded).Where(p => p != null)
        .ToList();
    }
  }
}
