﻿namespace RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

public class UpdateWhoWeAreDetailsDto
{
    public int WhoWeAreDetailID { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string Description1 { get; set; }
    public string Description2 { get; set; }
}