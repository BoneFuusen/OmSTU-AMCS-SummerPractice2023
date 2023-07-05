namespace SpaceBattle{
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
}
