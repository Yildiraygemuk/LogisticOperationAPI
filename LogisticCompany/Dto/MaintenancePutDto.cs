﻿namespace LogisticCompany.Entity.Dto
{
    public class MaintenancePutDto
    {
        public int Id { get; set; }
        public int VehicleID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public int PictureGroupID { get; set; }
        public DateTime ExceptedTimeToFix { get; set; }
        public int ResponsibleUserID { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public int StatusID { get; set; }
    }
}
