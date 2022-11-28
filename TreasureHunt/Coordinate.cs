﻿
using Demos.TreasureHunt;

public class Coordinate
{
    public int Row { get; private set; }
    public int Column { get; private set; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        return $"{Row}x{Column}";
    }
}