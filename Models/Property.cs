using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class PropertyData
    {
        public string Address { get; set; }
        public int YearBuilt { get; set; }
        public decimal ListPrice { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal GrossYield { get; set; }
    }
    public class PropertyList
    {
        public IEnumerable<Property> Properties { get; set; }
    }
    public class Property
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? BuyerAccountId { get; set; }
        public int? BuyerUserId { get; set; }
        public object ExternalId { get; set; }
        public object ProgramId { get; set; }
        public bool IsDwellCertified { get; set; }
        public bool IsAllowOffer { get; set; }
        public bool IsAllowPreview { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsRentGuaranteed { get; set; }
        public bool AllowRentGuaranteedOptout { get; set; }
        public bool IsSecuritized { get; set; }
        public bool IsHot { get; set; }
        public bool IsNew { get; set; }
        public bool? IsBargain { get; set; }
        public bool IsDiligenceVaultUnlocked { get; set; }
        public bool? IsPropertyManagerOfferRetain { get; set; }
        public bool? IsHoa { get; set; }
        public bool HasAudio { get; set; }
        public bool HasDiligenceVaultDocuments { get; set; }
        public int Market { get; set; }
        public int? DaysOnMarket { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public object PropertyName { get; set; }
        public string Description { get; set; }
        public object Highlights { get; set; }
        public string MainImageUrl { get; set; }
        public object PersonalProperties { get; set; }
        public string DiligenceVaultSummary { get; set; }
        public object FeaturedReason { get; set; }
        public string Status { get; set; }
        public string AllowedFundingTypes { get; set; }
        public string AllowableSaleTypes { get; set; }
        public string Visibility { get; set; }
        public string PriceVisibility { get; set; }
        public string PropertyType { get; set; }
        public string CertificationLevel { get; set; }
        public DateTime? EscrowClosingDate { get; set; }
        public Address Address { get; set; }
        
        public Financial Financial { get; set; }
        public Financial FinancialDisplay
        {
            get
            {
                if (Financial != null)
                    return Financial;
                else
                    return new Financial();
            }
        }
        public Physical Physical { get; set; }
        public Physical PhysicalDisplay
        {
            get
            {
                if (Physical != null)
                    return Physical;
                else
                    return new Physical();
            }
        }
        public Score Score { get; set; }
        public Valuation Valuation { get; set; }
        public Resources Resources { get; set; }
        public object Manager { get; set; }
        public object Seller { get; set; }
        public object SellerBroker { get; set; }
        public object Hoa { get; set; }
        public Lease Lease { get; set; }
        public List<object> Diligences { get; set; }
        public GoogleMapOption GoogleMapOption { get; set; }
        public object InspectionType { get; set; }
    }
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public object District { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ZipPlus4 { get; set; }
    }
    public class Financial
    {
        public object CapRate { get; set; }
        public string Occupancy { get; set; }
        public bool IsSection8 { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal ListPrice { get; set; }
        public object SalePrice { get; set; }
        public object MarketValue { get; set; }
        public object MonthlyHoa { get; set; }
        public object MonthlyManagementFees { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyRent { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MonthlyRentDisplay
        {
            get
            {
                if (MonthlyRent != null)
                    return MonthlyRent;
                else
                    return 0.0M;
            }
        }
        public object NetYield { get; set; }
        public object TurnOverFee { get; set; }
        public object RehabCosts { get; set; }
        public object RehabDate { get; set; }
        public double? YearlyInsuranceCost { get; set; }
        public double YearlyPropertyTaxes { get; set; }
        public bool IsCashOnly { get; set; }

        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal? GrossYield
        {
            get
            {
                if (MonthlyRent == 0 || ListPrice == 0)
                    return 0.0M;
                else
                {
                    decimal grossAmount = (MonthlyRentDisplay * 12) / ListPrice;
                    grossAmount = decimal.Round(grossAmount, 2, MidpointRounding.AwayFromZero);
                    return grossAmount;
                }
            }
        }
    }
    public class Physical
    {
        public double BathRooms { get; set; }
        public double BedRooms { get; set; }
        public string ParcelNumber { get; set; }
        public bool IsPool { get; set; }
        public int? LotSize { get; set; }
        public int SquareFeet { get; set; }
        public object Stories { get; set; }
        public object Units { get; set; }
        public int? YearBuilt { get; set; }
        public int? YearBuiltDisplay
        {
            get
            {
                if (YearBuilt != null)
                    return YearBuilt;
                else
                    return 0;
            }
        }
        public object ZipYearBuilt { get; set; }
    }
    public class Score
    {
        public object ConditionScore { get; set; }
        public string CrimeScore { get; set; }
        public int NeighborhoodScore { get; set; }
        public object OverallScore { get; set; }
        public object QualityScore { get; set; }
        public string SchoolScore { get; set; }
        public string CharterSchoolScore { get; set; }
        public string FloodRiskScore { get; set; }
        public object WalkabilityScore { get; set; }
    }
    public class Valuation
    {
        public object AvmBpoValue { get; set; }
        public object AvmBpoAdjValue { get; set; }
        public object AvmBpoDate { get; set; }
        public double RsAvmValue { get; set; }
        public object RsAvmDate { get; set; }
        public double? RsBpoMergeValue { get; set; }
    }
    public class Resources
    {
        public List<object> Photos { get; set; }
        public List<object> FloorPlans { get; set; }
        public List<object> ThreeDRenderings { get; set; }
        public List<object> Audios { get; set; }
    }
    public class LeaseSummary
    {
        public string Occupancy { get; set; }
        public object LeasingStatus { get; set; }
        public object MarketedRent { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime LeaseStartDate { get; set; }
        public DateTime LeaseEndDate { get; set; }
        public double MonthlyRent { get; set; }
        public double? SecurityDepositAmount { get; set; }
        public object HasPet { get; set; }
        public object PetFeeAmount { get; set; }
        public bool IsPetsDeposit { get; set; }
        public double? PetsDepositAmount { get; set; }
        public bool? IsLeaseConcessions { get; set; }
        public bool IsRentersInsuranceRequired { get; set; }
        public bool IsSection8 { get; set; }
        public bool IsTenantBackgroundChecked { get; set; }
        public bool IsTenantIncomeAbove3X { get; set; }
        public object IsTenantMayTerminateEarly { get; set; }
        public object IsTenantPurchaseOption { get; set; }
    }
    public class UtilitiesOwnership
    {
        public string Electric { get; set; }
        public string Gas { get; set; }
        public string Water { get; set; }
        public string Garbage { get; set; }
        public string Pool { get; set; }
        public string Landscaping { get; set; }
        public string PestControl { get; set; }
    }
    public class ApplianceOwnership
    {
        public string Refrigerator { get; set; }
        public string Dishwasher { get; set; }
        public string Washer { get; set; }
        public string Dryer { get; set; }
        public string Microwave { get; set; }
        public string Stove { get; set; }
    }
    public class Lease
    {
        public LeaseSummary LeaseSummary { get; set; }
        public UtilitiesOwnership UtilitiesOwnership { get; set; }
        public ApplianceOwnership ApplianceOwnership { get; set; }
    }
    public class GoogleMapOption
    {
        public bool HasStreetView { get; set; }
        public int PovHeading { get; set; }
        public int PovPitch { get; set; }
        public double PovLatitude { get; set; }
        public double PovLongitude { get; set; }
    }
}
