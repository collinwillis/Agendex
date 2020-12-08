using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendex.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public bool Aero { get; set; }
        public string ContactEmail { get; set; }
        public string ContactName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EventName { get; set; }
        public int TotalAttendeeCount { get; set; }
        public bool NonUS { get; set; }
        public string RoomSetup { get; set; }
        public string Equipment { get; set; }
        public bool Special { get; set; }
        public string OnsiteContactEmail { get; set; }
        public string OnsiteContactName { get; set; }
        public int FacilitatorCount { get; set; }
        public string LeadFacilitator { get; set; }
        public string CourseOwner { get; set; }
        public int GeneralLedger { get; set; }
        public string DepartmentCode { get; set; }
        public int CourseNumber { get; set; }
        public int OfferingNumber { get; set; }
        public DateTime DailyStartTime { get; set; }
        public DateTime DailyEndTime { get; set; }
        public DateTime EndTimeLastDay { get; set; }
        public int ParticipantCount { get; set; }
        public int ObserverCount { get; set; }
        public bool TableTents { get; set; }
        public bool NameTags { get; set; }
        public bool NoMaterials { get; set; }
        public bool FacilititatorToProvideMaterials { get; set; }
        public bool CompanyShipsMaterials { get; set; }
        public bool ContactShipsMaterials { get; set; }
        public bool MaterialsOnsite { get; set; }
        public bool StandardRoomSetup { get; set; }
        public bool PowerPointRemote { get; set; }
        public bool LaptopAdapter { get; set; }
        public bool PLCLaptop { get; set; }
        public bool Speakers { get; set; }
        public bool Microphones { get; set; }
        public bool CamcorderWithTripod { get; set; }
        public bool FlipCharts { get; set; }
        public int FlipChartCount { get; set; }
        public bool FlipChartsAtEachTable { get; set; }
        public bool CateringNeeded { get; set; }
        public bool CateringToBeDetermined { get; set; }
        public bool LunchTickets { get; set; }
        public double LunchTicketPrice { get; set; }
        public bool WillOrderCateringThroughCafe { get; set; }
        public bool CateringOffsite { get; set; }
        public string OffsiteVendor { get; set; }
        public bool BreakoutRooms { get; set; }
        public int BreakOutRoomCount { get; set; }
        public string Notes { get; set; }

        public Event(int iD, string type, bool aero, string contactEmail, string contactName, DateTime startDate, DateTime endDate, string eventName, int totalAttendeeCount, bool nonUS, string roomSetup, string equipment, bool special, string onsiteContactEmail, string onsiteContactName, int facilitatorCount, string leadFacilitator, string courseOwner, int generalLedger, string departmentCode, int courseNumber, int offeringNumber, DateTime dailyStartTime, DateTime dailyEndTime, DateTime endTimeLastDay, int participantCount, int observerCount, bool tableTents, bool nameTags, bool noMaterials, bool facilititatorToProvideMaterials, bool companyShipsMaterials, bool contactShipsMaterials, bool materialsOnsite, bool standardRoomSetup, bool powerPointRemote, bool laptopAdapter, bool pLCLaptop, bool speakers, bool microphones, bool camcorderWithTripod, bool flipCharts, int flipChartCount, bool flipChartsAtEachTable, bool cateringNeeded, bool cateringToBeDetermined, bool lunchTickets, double lunchTicketPrice, bool willOrderCateringThroughCafe, bool cateringOffsite, string offsiteVendor, bool breakoutRooms, int breakOutRoomCount, string notes)
        {
            ID = iD;
            Type = type;
            Aero = aero;
            ContactEmail = contactEmail;
            ContactName = contactName;
            StartDate = startDate;
            EndDate = endDate;
            EventName = eventName;
            TotalAttendeeCount = totalAttendeeCount;
            NonUS = nonUS;
            RoomSetup = roomSetup;
            Equipment = equipment;
            Special = special;
            OnsiteContactEmail = onsiteContactEmail;
            OnsiteContactName = onsiteContactName;
            FacilitatorCount = facilitatorCount;
            LeadFacilitator = leadFacilitator;
            CourseOwner = courseOwner;
            GeneralLedger = generalLedger;
            DepartmentCode = departmentCode;
            CourseNumber = courseNumber;
            OfferingNumber = offeringNumber;
            DailyStartTime = dailyStartTime;
            DailyEndTime = dailyEndTime;
            EndTimeLastDay = endTimeLastDay;
            ParticipantCount = participantCount;
            ObserverCount = observerCount;
            TableTents = tableTents;
            NameTags = nameTags;
            NoMaterials = noMaterials;
            FacilititatorToProvideMaterials = facilititatorToProvideMaterials;
            CompanyShipsMaterials = companyShipsMaterials;
            ContactShipsMaterials = contactShipsMaterials;
            MaterialsOnsite = materialsOnsite;
            StandardRoomSetup = standardRoomSetup;
            PowerPointRemote = powerPointRemote;
            LaptopAdapter = laptopAdapter;
            PLCLaptop = pLCLaptop;
            Speakers = speakers;
            Microphones = microphones;
            CamcorderWithTripod = camcorderWithTripod;
            FlipCharts = flipCharts;
            FlipChartCount = flipChartCount;
            FlipChartsAtEachTable = flipChartsAtEachTable;
            CateringNeeded = cateringNeeded;
            CateringToBeDetermined = cateringToBeDetermined;
            LunchTickets = lunchTickets;
            LunchTicketPrice = lunchTicketPrice;
            WillOrderCateringThroughCafe = willOrderCateringThroughCafe;
            CateringOffsite = cateringOffsite;
            OffsiteVendor = offsiteVendor;
            BreakoutRooms = breakoutRooms;
            BreakOutRoomCount = breakOutRoomCount;
            Notes = notes;
        }

        public Event()
        {
            ID = 12345678;
            Type = "Meeting";
            Aero = true;
            ContactEmail = "TheContact@gmail.com";
            ContactName = "TheContact";
            StartDate = new DateTime();
            //EndDate = endDate;
            //EventName = eventName;
            //TotalAttendeeCount = totalAttendeeCount;
            //NonUS = nonUS;
            //RoomSetup = roomSetup;
            //Equipment = equipment;
            //Special = special;
            //OnsiteContactEmail = onsiteContactEmail;
            //OnsiteContactName = onsiteContactName;
            //FacilitatorCount = facilitatorCount;
            //LeadFacilitator = leadFacilitator;
            //CourseOwner = courseOwner;
            //GeneralLedger = generalLedger;
            //DepartmentCode = departmentCode;
            //CourseNumber = courseNumber;
            //OfferingNumber = offeringNumber;
            //DailyStartTime = dailyStartTime;
            //DailyEndTime = dailyEndTime;
            //EndTimeLastDay = endTimeLastDay;
            //ParticipantCount = participantCount;
            //ObserverCount = observerCount;
            //TableTents = tableTents;
            //NameTags = nameTags;
            //NoMaterials = noMaterials;
            //FacilititatorToProvideMaterials = facilititatorToProvideMaterials;
            //CompanyShipsMaterials = companyShipsMaterials;
            //ContactShipsMaterials = contactShipsMaterials;
            //MaterialsOnsite = materialsOnsite;
            //StandardRoomSetup = standardRoomSetup;
            //PowerPointRemote = powerPointRemote;
            //LaptopAdapter = laptopAdapter;
            //PLCLaptop = pLCLaptop;
            //Speakers = speakers;
            //Microphones = microphones;
            //CamcorderWithTripod = camcorderWithTripod;
            //FlipCharts = flipCharts;
            //FlipChartCount = flipChartCount;
            //FlipChartsAtEachTable = flipChartsAtEachTable;
            //CateringNeeded = cateringNeeded;
            //CateringToBeDetermined = cateringToBeDetermined;
            //LunchTickets = lunchTickets;
            //LunchTicketPrice = lunchTicketPrice;
            //WillOrderCateringThroughCafe = willOrderCateringThroughCafe;
            //CateringOffsite = cateringOffsite;
            //OffsiteVendor = offsiteVendor;
            //BreakoutRooms = breakoutRooms;
            //BreakOutRoomCount = breakOutRoomCount;
            //Notes = notes;
        }
    }
}