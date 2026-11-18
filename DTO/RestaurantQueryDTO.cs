namespace AddisEats.Api.DTOs;

public class RestaurantQueryDTO
{
    public string Area {get; set;}= "";
    public string MaxFeeEtb{get; set;} ="";
    public int Page{get; set;}
    public int Limit{get; set;}
}