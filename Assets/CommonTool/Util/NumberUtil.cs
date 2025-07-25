﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberUtil
{
    public static string DoubleToStr(double a)
    {
        return Math.Round(a, CommonConfig.RoundDigits).ToString();
    }
    public static string DoubleToStr(double a, int digits)
    {
        return Math.Round(a, digits).ToString();
    }

    public static double Round(double a)
    {
        return Math.Round(a, CommonConfig.RoundDigits);
    }

}
