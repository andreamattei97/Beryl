namespace Beryl.Utilities
{
    //represent a tollerance used in a stopped criterion
    interface ITollerance
    {
        //returns the tollerance relative to reference value
        double GetTollerance(double refValue);
    }
}
