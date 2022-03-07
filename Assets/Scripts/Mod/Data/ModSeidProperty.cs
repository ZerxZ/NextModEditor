﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public enum ModSeidPropertyType
{
    Int,
    IntArray,
}

public class ModSeidProperty
{
    public string ID { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public ModSeidPropertyType Type { get; set; }
    public string Desc { get; set; } = string.Empty;
    public string[] SpecialDrawer { get; set; } = Array.Empty<string>();
}