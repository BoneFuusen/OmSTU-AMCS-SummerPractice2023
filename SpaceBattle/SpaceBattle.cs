﻿namespace SpaceBattle{
public class Ship
{
    public static double[] Calculate(double sh_x, double sh_y, double sp_x, double sp_y, bool poss, bool posit, bool speed){

        if(!poss || !posit || !speed){
            throw new System.ArgumentException();
        }
        else{
            return new double[2] { sh_x + sp_x, sh_y + sp_y};
        }
    }
}

public class Ship_fuel
{
    public static double FuelCalc(double fuel, double cost){
        if (fuel < cost){
            throw new System.ArgumentException();
        }
        else{
            return fuel - cost;
        }
    }
}

public class Ship_angle
{
    public static double AngleCalc(double angle, double angle_spd, bool Angle, bool Angle_spd, bool poss1){
        if (!Angle || !Angle_spd || !poss1){
            throw new System.ArgumentException();
        }
        return angle + angle_spd;
    }
}
}
