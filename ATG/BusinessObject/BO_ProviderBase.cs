//
// Class	:	BO_ProviderBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	08/20/2012 4:43:23 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections;
using System.Data.Common;
using System.IO;
using System.Xml;
using ATG.Database;

namespace ATG.BusinessObject
{

	/// <summary>
	/// Class for the properties of the object
	/// </summary>
	public class BO_ProviderFields
	{
		public const string StateID                   = "STATE_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string AspenIntID                = "ASPEN_INT_ID";
		public const string ProgramID                 = "PROGRAM_ID";
		public const string StateCode                 = "STATE_CODE";
		public const string ProgramStaffID            = "PROGRAM_STAFF_ID";
		public const string ParishCode                = "PARISH_CODE";
		public const string RegionCode                = "REGION_CODE";
		public const string FederalID                 = "FEDERAL_ID";
		public const string LicensureNum              = "LICENSURE_NUM";
		public const string GeographicalStreetAddr2   = "GEOGRAPHICAL_STREET_ADDR2";
		public const string SchoolID                  = "SCHOOL_ID";
		public const string FacilityName              = "FACILITY_NAME";
		public const string LegalName                 = "LEGAL_NAME";
		public const string MailStreet2               = "MAIL_STREET2";
		public const string GeographicalStreet        = "GEOGRAPHICAL_STREET";
		public const string GeographicalCity          = "GEOGRAPHICAL_CITY";
		public const string GeographicalZip           = "GEOGRAPHICAL_ZIP";
		public const string GeographicalState         = "GEOGRAPHICAL_STATE";
		public const string MailStreet                = "MAIL_STREET";
		public const string MailCity                  = "MAIL_CITY";
		public const string MailState                 = "MAIL_STATE";
		public const string MailZip                   = "MAIL_ZIP";
		public const string EmsParishCode             = "EMS_PARISH_CODE";
		public const string Parish                    = "PARISH";
		public const string RegionalOffice            = "REGIONAL_OFFICE";
		public const string ZoneNumCode               = "ZONE_NUM_CODE";
		public const string TelephoneNumber           = "TELEPHONE_NUMBER";
		public const string EmergencyPhoneNumber      = "EMERGENCY_PHONE_NUMBER";
		public const string FaxPhoneNumber            = "FAX_PHONE_NUMBER";
		public const string Administrator             = "ADMINISTRATOR";
		public const string AdministratorTitle        = "ADMINISTRATOR_TITLE";
		public const string AdministratorFirstName    = "ADMINISTRATOR_FIRST_NAME";
		public const string AdministratorMidInit      = "ADMINISTRATOR_MID_INIT";
		public const string AdministratorLastName     = "ADMINISTRATOR_LAST_NAME";
		public const string ContactName               = "CONTACT_NAME";
		public const string StateIdMds                = "STATE_ID_MDS";
		public const string StateLicNum               = "STATE_LIC_NUM";
		public const string EmailAddress              = "EMAIL_ADDRESS";
		public const string MedicaidVendorNumber      = "MEDICAID_VENDOR_NUMBER";
		public const string FieldOfficeCode           = "FIELD_OFFICE_CODE";
		public const string MedicalDirectorFullName   = "MEDICAL_DIRECTOR_FULL_NAME";
		public const string MedicalDirectorTitle      = "MEDICAL_DIRECTOR_TITLE";
		public const string MedicalDirFirstName       = "MEDICAL_DIR_FIRST_NAME";
		public const string MedicalDirMidInit         = "MEDICAL_DIR_MID_INIT";
		public const string MedicalDirLastName        = "MEDICAL_DIR_LAST_NAME";
		public const string MedicalDirectorMailAddr1  = "MEDICAL_DIRECTOR_MAIL_ADDR1";
		public const string MedicalDirectorMailAddr2  = "MEDICAL_DIRECTOR_MAIL_ADDR2";
		public const string MedicalDirectorMailCity   = "MEDICAL_DIRECTOR_MAIL_CITY";
		public const string MedicalDirectorMailState  = "MEDICAL_DIRECTOR_MAIL_STATE";
		public const string MedicalDirectorMailZip    = "MEDICAL_DIRECTOR_MAIL_ZIP";
		public const string HoursMinutes              = "HOURS_MINUTES";
		public const string Snf18beds                 = "SNF18BEDS";
		public const string AmPM                      = "AM_PM";
		public const string HoursMinutes1             = "HOURS_MINUTES_1";
		public const string AmPm1                     = "AM_PM_1";
		public const string DayOfOperationMon         = "DAY_OF_OPERATION_MON";
		public const string DayOfOperationTue         = "DAY_OF_OPERATION_TUE";
		public const string DayOfOperationWed         = "DAY_OF_OPERATION_WED";
		public const string DayOfOperationThu         = "DAY_OF_OPERATION_THU";
		public const string DayOfOperationFri         = "DAY_OF_OPERATION_FRI";
		public const string DayOfOperationSat         = "DAY_OF_OPERATION_SAT";
		public const string DayOfOperationSun         = "DAY_OF_OPERATION_SUN";
		public const string TypeLicenseCode           = "TYPE_LICENSE_CODE";
		public const string TypeOfLicense             = "TYPE_OF_LICENSE";
		public const string TypeFacilityCode          = "TYPE_FACILITY_CODE";
		public const string TypeFacility1Code         = "TYPE_FACILITY_1_CODE";
		public const string TypeFacility2Code         = "TYPE_FACILITY_2_CODE";
		public const string TypeFacility3Code         = "TYPE_FACILITY_3_CODE";
		public const string TypeFacility4Code         = "TYPE_FACILITY_4_CODE";
		public const string TypeFacility5Code         = "TYPE_FACILITY_5_CODE";
		public const string TypeFacility6Code         = "TYPE_FACILITY_6_CODE";
		public const string LicensedSnfFacility       = "LICENSED_SNF_FACILITY";
		public const string Snf1819beds               = "SNF1819BEDS";
		public const string Snf19beds                 = "SNF19BEDS";
		public const string TypeOfClients             = "TYPE_OF_CLIENTS";
		public const string PsychiatricBeds           = "PSYCHIATRIC_BEDS";
		public const string SnfBeds                   = "SNF_BEDS";
		public const string SwingBeds                 = "SWING_BEDS";
		public const string RehabilitationBeds        = "REHABILITATION_BEDS";
		public const string TotalLicBeds              = "TOTAL_LIC_BEDS";
		public const string BedsCertified             = "BEDS_CERTIFIED";
		public const string TypeOwnershipCode         = "TYPE_OWNERSHIP_CODE";
		public const string NameOfCorporation         = "NAME_OF_CORPORATION";
		public const string CorporationIdNum          = "CORPORATION_ID_NUM";
		public const string CorporationStreet         = "CORPORATION_STREET";
		public const string CorporationCity           = "CORPORATION_CITY";
		public const string CorporationState          = "CORPORATION_STATE";
		public const string CorporationZip            = "CORPORATION_ZIP";
		public const string CorporationPhone          = "CORPORATION_PHONE";
		public const string CorporationFax            = "CORPORATION_FAX";
		public const string NameOfOwner1              = "NAME_OF_OWNER_1";
		public const string NameOfOwner2              = "NAME_OF_OWNER_2";
		public const string NameOfOwner3              = "NAME_OF_OWNER_3";
		public const string NameOfOwner4              = "NAME_OF_OWNER_4";
		public const string PresidentName             = "PRESIDENT_NAME";
		public const string VicePresidentName         = "VICE_PRESIDENT_NAME";
		public const string SecretaryTreasurerName    = "SECRETARY_TREASURER_NAME";
		public const string JcahYN                    = "JCAH_YN";
		public const string ChangeOfOwnerDate         = "CHANGE_OF_OWNER_DATE";
		public const string OriginalLicensureDate     = "ORIGINAL_LICENSURE_DATE";
		public const string OriginalEnrollmentDate    = "ORIGINAL_ENROLLMENT_DATE";
		public const string CurrentLicIssueDate       = "CURRENT_LIC_ISSUE_DATE";
		public const string LicensureExpirationDate   = "LICENSURE_EXPIRATION_DATE";
		public const string LicensureAnniversaryMth   = "LICENSURE_ANNIVERSARY_MTH";
		public const string Capacity                  = "CAPACITY";
		public const string CapacityInHome            = "CAPACITY_IN_HOME";
		public const string CapacityOutOfHome         = "CAPACITY_OUT_OF_HOME";
		public const string AgeRange                  = "AGE_RANGE";
		public const string Unit                      = "UNIT";
		public const string ForYearEndingMmdd         = "FOR_YEAR_ENDING_MMDD";
		public const string HospitalBasedYN           = "HOSPITAL_BASED_YN";
		public const string ApplicationDate           = "APPLICATION_DATE";
		public const string Fee                       = "FEE";
		public const string CheckNumber               = "CHECK_NUMBER";
		public const string DateFeeReceived           = "DATE_FEE_RECEIVED";
		public const string StateFireApprovalDate     = "STATE_FIRE_APPROVAL_DATE";
		public const string HealthApprovalDate        = "HEALTH_APPROVAL_DATE";
		public const string CurSurv                   = "CUR_SURV";
		public const string UsDeaRegNum               = "US_DEA_REG_NUM";
		public const string UsDeaRegNumExpDate        = "US_DEA_REG_NUM_EXP_DATE";
		public const string LaCdsNum                  = "LA_CDS_NUM";
		public const string LaCdsNumExpDate           = "LA_CDS_NUM_EXP_DATE";
		public const string CliaIdNum                 = "CLIA_ID_NUM";
		public const string CliaExpDate               = "CLIA_EXP_DATE";
		public const string CertEffectiveDate         = "CERT_EFFECTIVE_DATE";
		public const string CertifExpirationDate      = "CERTIF_EXPIRATION_DATE";
		public const string CertificationMth          = "CERTIFICATION_MTH";
		public const string LevelCode                 = "LEVEL_CODE";
		public const string NoOfAirAmbulances         = "NO_OF_AIR_AMBULANCES";
		public const string NoOfGroundAmbulances      = "NO_OF_GROUND_AMBULANCES";
		public const string NoOfSprintVehicles        = "NO_OF_SPRINT_VEHICLES";
		public const string NoOfAmbulatoryVehicles    = "NO_OF_AMBULATORY_VEHICLES";
		public const string TotalDailyCapacityAmbulatoryVehicle = "TOTAL_DAILY_CAPACITY_AMBULATORY_VEHICLE";
		public const string NoOfHandicappedVehicles   = "NO_OF_HANDICAPPED_VEHICLES";
		public const string TotalDailyCapacityHandicappedVehicle = "TOTAL_DAILY_CAPACITY_HANDICAPPED_VEHICLE";
		public const string NumberOfBeds              = "NUMBER_OF_BEDS";
		public const string AutomobileInsuranceCoverageLimit = "AUTOMOBILE_INSURANCE_COVERAGE_LIMIT";
		public const string AutomobileInsuranceCarrierCode = "AUTOMOBILE_INSURANCE_CARRIER_CODE";
		public const string AutomobileInsurancePolicyNum = "AUTOMOBILE_INSURANCE_POLICY_NUM";
		public const string AutomobileInsuranceExpirationDate = "AUTOMOBILE_INSURANCE_EXPIRATION_DATE";
		public const string GeneralLiabilityCoverageLimit = "GENERAL_LIABILITY_COVERAGE_LIMIT";
		public const string GeneralLiabilityCarrierCode = "GENERAL_LIABILITY_CARRIER_CODE";
		public const string GeneralLiabilityPolicyNum = "GENERAL_LIABILITY_POLICY_NUM";
		public const string FacilityWithinFacilityYN  = "FACILITY_WITHIN_FACILITY_YN";
		public const string GeneralLiabilityExpirationDate = "GENERAL_LIABILITY_EXPIRATION_DATE";
		public const string OtherBeds                 = "OTHER_BEDS";
		public const string MedicalMalpracticeCoverageLimit = "MEDICAL_MALPRACTICE_COVERAGE_LIMIT";
		public const string UnitsNumTotal             = "UNITS_NUM_TOTAL";
		public const string MedicalMalpracticeCarrierCode = "MEDICAL_MALPRACTICE_CARRIER_CODE";
		public const string TotalLicBedsTotal         = "TOTAL_LIC_BEDS_TOTAL";
		public const string MedicalMalpracticePolicyNum = "MEDICAL_MALPRACTICE_POLICY_NUM";
		public const string PsychiatricBedsTotal      = "PSYCHIATRIC_BEDS_TOTAL";
		public const string MedicalMalpracticeExpirationDate = "MEDICAL_MALPRACTICE_EXPIRATION_DATE";
		public const string IsolationUnitYN           = "ISOLATION_UNIT_YN";
		public const string RehabilitationBedsTotal   = "REHABILITATION_BEDS_TOTAL";
		public const string SnfBedsTotal              = "SNF_BEDS_TOTAL";
		public const string StatusCode                = "STATUS_CODE";
		public const string UnitsNumOffsiteTotal      = "UNITS_NUM_OFFSITE_TOTAL";
		public const string StatusDate                = "STATUS_DATE";
		public const string TotalLicBedsOffsiteTotal  = "TOTAL_LIC_BEDS_OFFSITE_TOTAL";
		public const string NoOfParishesServed        = "NO_OF_PARISHES_SERVED";
		public const string PsychiatricBedsOffsiteTotal = "PSYCHIATRIC_BEDS_OFFSITE_TOTAL";
		public const string LicensureSurveyDate       = "LICENSURE_SURVEY_DATE";
		public const string RehabBedsOffsiteTotal     = "REHAB_BEDS_OFFSITE_TOTAL";
		public const string Waivers                   = "WAIVERS";
		public const string SnfBedsOffsiteTotal       = "SNF_BEDS_OFFSITE_TOTAL";
		public const string OtherBedsOffsiteTotal     = "OTHER_BEDS_OFFSITE_TOTAL";
		public const string PsychPpsFederalID         = "PSYCH_PPS_FEDERAL_ID";
		public const string RehabPpsFederalID         = "REHAB_PPS_FEDERAL_ID";
		public const string UserLastMaint             = "USER_LAST_MAINT";
		public const string PsychPpsCertEffectiveDate = "PSYCH_PPS_CERT_EFFECTIVE_DATE";
		public const string DateLastMaint             = "DATE_LAST_MAINT";
		public const string RehabPpsCertEffectiveDate = "REHAB_PPS_CERT_EFFECTIVE_DATE";
		public const string TimeLastMaint             = "TIME_LAST_MAINT";
		public const string OffsiteCampusYN           = "OFFSITE_CAMPUS_YN";
		public const string CertifiedBedOverrideYN    = "CERTIFIED_BED_OVERRIDE_YN";
		public const string MainCampusBeds            = "MAIN_CAMPUS_BEDS";
		public const string ForYearEndingDate         = "FOR_YEAR_ENDING_DATE";
		public const string NeonatalIntCode           = "NEONATAL_INT_CODE";
		public const string ServicesOffered           = "SERVICES_OFFERED";
		public const string PicuIntCode               = "PICU_INT_CODE";
		public const string HalfwayHouse              = "HALFWAY_HOUSE";
		public const string DeemedStatus              = "DEEMED_STATUS";
		public const string InPatient                 = "IN_PATIENT";
		public const string ChapAccreditionYN         = "CHAP_ACCREDITION_YN";
		public const string CrisisEmergency           = "CRISIS_EMERGENCY";
		public const string OutpatientTreatment       = "OUTPATIENT_TREATMENT";
		public const string FiscalIntermediaryNum     = "FISCAL_INTERMEDIARY_NUM";
		public const string MethadoneTreatment        = "METHADONE_TREATMENT";
		public const string AttesestationStatement    = "ATTESESTATION_STATEMENT";
		public const string PreventionEducation       = "PREVENTION_EDUCATION";
		public const string AttesestationStmtDateSigned = "ATTESESTATION_STMT_DATE_SIGNED";
		public const string ResidentialTreatment      = "RESIDENTIAL_TREATMENT";
		public const string NameChangePrevName1       = "NAME_CHANGE_PREV_NAME1";
		public const string SocialSettingDetoxification = "SOCIAL_SETTING_DETOXIFICATION";
		public const string NameChangeDate1           = "NAME_CHANGE_DATE1";
		public const string AdultHealthCare           = "ADULT_HEALTH_CARE";
		public const string NameChangePrevName2       = "NAME_CHANGE_PREV_NAME2";
		public const string NameChangeDate2           = "NAME_CHANGE_DATE2";
		public const string CnatTrainingCode          = "CNAT_TRAINING_CODE";
		public const string CnatTrainingSuspendDate   = "CNAT_TRAINING_SUSPEND_DATE";
		public const string PreviousOwner1            = "PREVIOUS_OWNER1";
		public const string PrevOwnerChangeDate1      = "PREV_OWNER_CHANGE_DATE1";
		public const string AssistDirOfNursingWaiverMonth = "ASSIST_DIR_OF_NURSING_WAIVER_MONTH";
		public const string Day7RnWaiverMonth         = "DAY7_RN_WAIVER_MONTH";
		public const string PreviousOwner2            = "PREVIOUS_OWNER2";
		public const string PrevOwnerChangeDate2      = "PREV_OWNER_CHANGE_DATE2";
		public const string CurrentSurveyMonth        = "CURRENT_SURVEY_MONTH";
		public const string FiscalIntermediaryDesc    = "FISCAL_INTERMEDIARY_DESC";
		public const string MedicareInterPrefCode     = "MEDICARE_INTER_PREF_CODE";
		public const string ProgramCode               = "PROGRAM_CODE";
		public const string NoTreatmentsPerWeek       = "NO_TREATMENTS_PER_WEEK";
		public const string NoOfStations              = "NO_OF_STATIONS";
		public const string LevelDescription          = "LEVEL_DESCRIPTION";
		public const string AutomaticCancellationDate = "AUTOMATIC_CANCELLATION_DATE";
		public const string NoOf3hrShiftsWeek         = "NO_OF_3HR_SHIFTS_WEEK";
		public const string FcertBeds                 = "FCERT_BEDS";
		public const string AverageNumPatientsShift   = "AVERAGE_NUM_PATIENTS_SHIFT";
		public const string AutomobileInsurancePrepaymentDueDate = "AUTOMOBILE_INSURANCE_PREPAYMENT_DUE_DATE";
		public const string VendorNum                 = "VENDOR_NUM";
		public const string GeneralLiabilityPrepaymentDueDate = "GENERAL_LIABILITY_PREPAYMENT_DUE_DATE";
		public const string WaiverCode                = "WAIVER_CODE";
		public const string WaiverCode2               = "WAIVER_CODE_2";
		public const string OverrideCapacity          = "OVERRIDE_CAPACITY";
		public const string RnCoordinator             = "RN_COORDINATOR";
		public const string WaiverCode3               = "WAIVER_CODE_3";
		public const string WaiverCode4               = "WAIVER_CODE_4";
		public const string DirectorName              = "DIRECTOR_NAME";
		public const string WaiverCode5               = "WAIVER_CODE_5";
		public const string Year1ReviewDateDue        = "YEAR1_REVIEW_DATE_DUE";
		public const string WaiverCode6               = "WAIVER_CODE_6";
		public const string WaiverCode7               = "WAIVER_CODE_7";
		public const string Usage                     = "USAGE";
		public const string TotalNumDialysisPatients  = "TOTAL_NUM_DIALYSIS_PATIENTS";
		public const string AccreditationExpirationDate = "ACCREDITATION_EXPIRATION_DATE";
		public const string HemodialysisNumPatients   = "HEMODIALYSIS_NUM_PATIENTS";
		public const string FacilityWithinFacility    = "FACILITY_WITHIN_FACILITY";
		public const string NumOfPeritonealDialysisPatients = "NUM_OF_PERITONEAL_DIALYSIS_PATIENTS";
		public const string FacilityTypeCode          = "FACILITY_TYPE_CODE";
		public const string HemodialysisNumOfStations = "HEMODIALYSIS_NUM_OF_STATIONS";
		public const string TransplantYN              = "TRANSPLANT_YN";
		public const string HemodialysisTrainingNumOfStation = "HEMODIALYSIS_TRAINING_NUM_OF_STATION";
		public const string ObIntCode                 = "OB_INT_CODE";
		public const string ObCurrentSurveyDate       = "OB_CURRENT_SURVEY_DATE";
		public const string TotalNumStations          = "TOTAL_NUM_STATIONS";
		public const string ReuseYN                   = "REUSE_YN";
		public const string NicuCurrentSurveyDate     = "NICU_CURRENT_SURVEY_DATE";
		public const string ManualYN                  = "MANUAL_YN";
		public const string PicuCurrentSurveyDate     = "PICU_CURRENT_SURVEY_DATE";
		public const string NumOfPatientsFollowedAtHome = "NUM_OF_PATIENTS_FOLLOWED_AT_HOME";
		public const string TraumaLevel               = "TRAUMA_LEVEL";
		public const string SemiautomatedYN           = "SEMIAUTOMATED_YN";
		public const string AutomatedYN               = "AUTOMATED_YN";
		public const string FormainGermicide          = "FORMAIN_GERMICIDE";
		public const string HeatGermicide             = "HEAT_GERMICIDE";
		public const string GluteraldetydeGermicide   = "GLUTERALDETYDE_GERMICIDE";
		public const string PeraceticAcidMixtureGerm  = "PERACETIC_ACID_MIXTURE_GERM";
		public const string OtherGermicide            = "OTHER_GERMICIDE";
		public const string EnrolledRhcOffsiteYN      = "ENROLLED_RHC_OFFSITE_YN";
		public const string TypeGermicideDescription  = "TYPE_GERMICIDE_DESCRIPTION";
		public const string HemodialysisService       = "HEMODIALYSIS_SERVICE";
		public const string DirectorOfNursingFirstName = "DIRECTOR_OF_NURSING_FIRST_NAME";
		public const string PeritonealDialysisService = "PERITONEAL_DIALYSIS_SERVICE";
		public const string DirectorOfNursingLastName = "DIRECTOR_OF_NURSING_LAST_NAME";
		public const string PresidentFirstName        = "PRESIDENT_FIRST_NAME";
		public const string TransplanationService     = "TRANSPLANATION_SERVICE";
		public const string PresidentLastName         = "PRESIDENT_LAST_NAME";
		public const string HomeTrainingService       = "HOME_TRAINING_SERVICE";
		public const string StaffingFteRN             = "STAFFING_FTE_RN";
		public const string StaffingFteLpn            = "STAFFING_FTE_LPN";
		public const string StaffingFteSW             = "STAFFING_FTE_SW";
		public const string StaffingFteTechnicians    = "STAFFING_FTE_TECHNICIANS";
		public const string StaffingFteDietian        = "STAFFING_FTE_DIETIAN";
		public const string StaffingFteOthers         = "STAFFING_FTE_OTHERS";
		public const string Initial                   = "INITIAL";
		public const string InitialDate               = "INITIAL_DATE";
		public const string ExpansionToNewLocation    = "EXPANSION_TO_NEW_LOCATION";
		public const string ExpToNewLocationDate      = "EXP_TO_NEW_LOCATION_DATE";
		public const string ChangeOfOwnership         = "CHANGE_OF_OWNERSHIP";
		public const string ChangeOfLocation          = "CHANGE_OF_LOCATION";
		public const string ChangeOfLocationDate      = "CHANGE_OF_LOCATION_DATE";
		public const string ExpansionInCurrentLocation = "EXPANSION_IN_CURRENT_LOCATION";
		public const string ExpansionInCurrentLocationDate = "EXPANSION_IN_CURRENT_LOCATION_DATE";
		public const string ChangeOfServices          = "CHANGE_OF_SERVICES";
		public const string ChangeOfServicesDate      = "CHANGE_OF_SERVICES_DATE";
		public const string TypeApplicationCode7      = "TYPE_APPLICATION_CODE7";
		public const string TypeApplicationCode7Date  = "TYPE_APPLICATION_CODE7_DATE";
		public const string TypeApplicationDescr      = "TYPE_APPLICATION_DESCR";
		public const string ProviderBasedYN           = "PROVIDER_BASED_YN";
		public const string MidLevelWaiverYN          = "MID_LEVEL_WAIVER_YN";
		public const string MidLevelWaiverMonth       = "MID_LEVEL_WAIVER_MONTH";
		public const string MidLevelWaiverDate        = "MID_LEVEL_WAIVER_DATE";
		public const string RelatedProviderLicensureNum = "RELATED_PROVIDER_LICENSURE_NUM";
		public const string EmergencyPrepReportRequired = "EMERGENCY_PREP_REPORT_REQUIRED";
		public const string AccreditedBody            = "ACCREDITED_BODY";
		public const string EnrolledInMedicaidYN      = "ENROLLED_IN_MEDICAID_YN";
		public const string TypeTreatment             = "TYPE_TREATMENT";
		public const string LicensedByOther           = "LICENSED_BY_OTHER";
		public const string LicensureEffectiveDate    = "LICENSURE_EFFECTIVE_DATE";
		public const string NumActivePatients         = "NUM_ACTIVE_PATIENTS";
		public const string NumRadiologicTechBsba     = "NUM_RADIOLOGIC_TECH_BSBA";
		public const string NumRadiologicTechAS       = "NUM_RADIOLOGIC_TECH_AS";
		public const string NumRadiologicTechCrt      = "NUM_RADIOLOGIC_TECH_CRT";
		public const string NumRadiologicTechOther    = "NUM_RADIOLOGIC_TECH_OTHER";
		public const string IsolationNumOfStations    = "ISOLATION_NUM_OF_STATIONS";
		public const string RelatedProviderName       = "RELATED_PROVIDER_NAME";
		public const string NumOperatingRooms         = "NUM_OPERATING_ROOMS";
		public const string AdmMultiFacYN             = "ADM_MULTI_FAC_YN";
		public const string AdmMultiFacOtherName      = "ADM_MULTI_FAC_OTHER_NAME";
		public const string SingleStoryYN             = "SINGLE_STORY_YN";
		public const string ClosedDate                = "CLOSED_DATE";
        public const string Year2ReviewDateDue = "YEAR2_REVIEW_DATE_DUE";
	}
	
	/// <summary>
	/// Data access class for the "PROVIDERS" table.
	/// </summary>
	[Serializable]
	public class BO_ProviderBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private string         	_stateIDNonDefault       	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private int?           	_aspenIntIDNonDefault    	= null;
		private string         	_programIDNonDefault     	= null;
		private string         	_stateCodeNonDefault     	= null;
		private int?           	_programStaffIDNonDefault	= null;
		private string         	_parishCodeNonDefault    	= null;
		private string         	_regionCodeNonDefault    	= null;
		private string         	_federalIDNonDefault     	= null;
		private string         	_licensureNumNonDefault  	= null;
		private string         	_geographicalStreetAddr2NonDefault	= null;
		private int?           	_schoolIDNonDefault      	= null;
		private string         	_facilityNameNonDefault  	= null;
		private string         	_legalNameNonDefault     	= null;
		private string         	_mailStreet2NonDefault   	= null;
		private string         	_geographicalStreetNonDefault	= null;
		private string         	_geographicalCityNonDefault	= null;
		private string         	_geographicalZipNonDefault	= null;
		private string         	_geographicalStateNonDefault	= null;
		private string         	_mailStreetNonDefault    	= null;
		private string         	_mailCityNonDefault      	= null;
		private string         	_mailStateNonDefault     	= null;
		private string         	_mailZipNonDefault       	= null;
		private string         	_emsParishCodeNonDefault 	= null;
		private string         	_parishNonDefault        	= null;
		private string         	_regionalOfficeNonDefault	= null;
		private string         	_zoneNumCodeNonDefault   	= null;
		private string         	_telephoneNumberNonDefault	= null;
		private string         	_emergencyPhoneNumberNonDefault	= null;
		private string         	_faxPhoneNumberNonDefault	= null;
		private string         	_administratorNonDefault 	= null;
		private string         	_administratorTitleNonDefault	= null;
		private string         	_administratorFirstNameNonDefault	= null;
		private string         	_administratorMidInitNonDefault	= null;
		private string         	_administratorLastNameNonDefault	= null;
		private string         	_contactNameNonDefault   	= null;
		private string         	_stateIdMdsNonDefault    	= null;
		private string         	_stateLicNumNonDefault   	= null;
		private string         	_emailAddressNonDefault  	= null;
		private string         	_medicaidVendorNumberNonDefault	= null;
		private string         	_fieldOfficeCodeNonDefault	= null;
		private string         	_medicalDirectorFullNameNonDefault	= null;
		private string         	_medicalDirectorTitleNonDefault	= null;
		private string         	_medicalDirFirstNameNonDefault	= null;
		private string         	_medicalDirMidInitNonDefault	= null;
		private string         	_medicalDirLastNameNonDefault	= null;
		private string         	_medicalDirectorMailAddr1NonDefault	= null;
		private string         	_medicalDirectorMailAddr2NonDefault	= null;
		private string         	_medicalDirectorMailCityNonDefault	= null;
		private string         	_medicalDirectorMailStateNonDefault	= null;
		private string         	_medicalDirectorMailZipNonDefault	= null;
		private string         	_hoursMinutesNonDefault  	= null;
		private int?           	_snf18bedsNonDefault     	= null;
		private string         	_amPMNonDefault          	= null;
		private string         	_hoursMinutes1NonDefault 	= null;
		private string         	_amPm1NonDefault         	= null;
		private string         	_dayOfOperationMonNonDefault	= null;
		private string         	_dayOfOperationTueNonDefault	= null;
		private string         	_dayOfOperationWedNonDefault	= null;
		private string         	_dayOfOperationThuNonDefault	= null;
		private string         	_dayOfOperationFriNonDefault	= null;
		private string         	_dayOfOperationSatNonDefault	= null;
		private string         	_dayOfOperationSunNonDefault	= null;
		private string         	_typeLicenseCodeNonDefault	= null;
		private string         	_typeOfLicenseNonDefault 	= null;
		private string         	_typeFacilityCodeNonDefault	= null;
		private string         	_typeFacility1CodeNonDefault	= null;
		private string         	_typeFacility2CodeNonDefault	= null;
		private string         	_typeFacility3CodeNonDefault	= null;
		private string         	_typeFacility4CodeNonDefault	= null;
		private string         	_typeFacility5CodeNonDefault	= null;
		private string         	_typeFacility6CodeNonDefault	= null;
		private string         	_licensedSnfFacilityNonDefault	= null;
		private int?           	_snf1819bedsNonDefault   	= null;
		private int?           	_snf19bedsNonDefault     	= null;
		private string         	_typeOfClientsNonDefault 	= null;
		private int?           	_psychiatricBedsNonDefault	= null;
		private int?           	_snfBedsNonDefault       	= null;
		private int?           	_swingBedsNonDefault     	= null;
		private int?           	_rehabilitationBedsNonDefault	= null;
		private int?           	_totalLicBedsNonDefault  	= null;
		private int?           	_bedsCertifiedNonDefault 	= null;
		private string         	_typeOwnershipCodeNonDefault	= null;
		private string         	_nameOfCorporationNonDefault	= null;
		private string         	_corporationIdNumNonDefault	= null;
		private string         	_corporationStreetNonDefault	= null;
		private string         	_corporationCityNonDefault	= null;
		private string         	_corporationStateNonDefault	= null;
		private string         	_corporationZipNonDefault	= null;
		private string         	_corporationPhoneNonDefault	= null;
		private string         	_corporationFaxNonDefault	= null;
		private string         	_nameOfOwner1NonDefault  	= null;
		private string         	_nameOfOwner2NonDefault  	= null;
		private string         	_nameOfOwner3NonDefault  	= null;
		private string         	_nameOfOwner4NonDefault  	= null;
		private string         	_presidentNameNonDefault 	= null;
		private string         	_vicePresidentNameNonDefault	= null;
		private string         	_secretaryTreasurerNameNonDefault	= null;
		private string         	_jcahYNNonDefault        	= null;
		private DateTime?      	_changeOfOwnerDateNonDefault	= null;
		private DateTime?      	_originalLicensureDateNonDefault	= null;
		private DateTime?      	_originalEnrollmentDateNonDefault	= null;
		private DateTime?      	_currentLicIssueDateNonDefault	= null;
		private DateTime?      	_licensureExpirationDateNonDefault	= null;
		private string         	_licensureAnniversaryMthNonDefault	= null;
		private int?           	_capacityNonDefault      	= null;
		private int?           	_capacityInHomeNonDefault	= null;
		private int?           	_capacityOutOfHomeNonDefault	= null;
		private string         	_ageRangeNonDefault      	= null;
		private int?           	_unitNonDefault          	= null;
		private string         	_forYearEndingMmddNonDefault	= null;
		private string         	_hospitalBasedYNNonDefault	= null;
		private DateTime?      	_applicationDateNonDefault	= null;
		private decimal?       	_feeNonDefault           	= null;
		private string         	_checkNumberNonDefault   	= null;
		private DateTime?      	_dateFeeReceivedNonDefault	= null;
		private DateTime?      	_stateFireApprovalDateNonDefault	= null;
		private DateTime?      	_healthApprovalDateNonDefault	= null;
		private DateTime?      	_curSurvNonDefault       	= null;
		private string         	_usDeaRegNumNonDefault   	= null;
		private DateTime?      	_usDeaRegNumExpDateNonDefault	= null;
		private string         	_laCdsNumNonDefault      	= null;
		private DateTime?      	_laCdsNumExpDateNonDefault	= null;
		private string         	_cliaIdNumNonDefault     	= null;
		private DateTime?      	_cliaExpDateNonDefault   	= null;
		private DateTime?      	_certEffectiveDateNonDefault	= null;
		private DateTime?      	_certifExpirationDateNonDefault	= null;
		private string         	_certificationMthNonDefault	= null;
		private string         	_levelCodeNonDefault     	= null;
		private int?           	_noOfAirAmbulancesNonDefault	= null;
		private int?           	_noOfGroundAmbulancesNonDefault	= null;
		private int?           	_noOfSprintVehiclesNonDefault	= null;
		private int?           	_noOfAmbulatoryVehiclesNonDefault	= null;
		private int?           	_totalDailyCapacityAmbulatoryVehicleNonDefault	= null;
		private int?           	_noOfHandicappedVehiclesNonDefault	= null;
		private int?           	_totalDailyCapacityHandicappedVehicleNonDefault	= null;
		private int?           	_numberOfBedsNonDefault  	= null;
		private decimal?       	_automobileInsuranceCoverageLimitNonDefault	= null;
		private string         	_automobileInsuranceCarrierCodeNonDefault	= null;
		private string         	_automobileInsurancePolicyNumNonDefault	= null;
		private DateTime?      	_automobileInsuranceExpirationDateNonDefault	= null;
		private decimal?       	_generalLiabilityCoverageLimitNonDefault	= null;
		private string         	_generalLiabilityCarrierCodeNonDefault	= null;
		private string         	_generalLiabilityPolicyNumNonDefault	= null;
		private string         	_facilityWithinFacilityYNNonDefault	= null;
		private DateTime?      	_generalLiabilityExpirationDateNonDefault	= null;
		private int?           	_otherBedsNonDefault     	= null;
		private decimal?       	_medicalMalpracticeCoverageLimitNonDefault	= null;
		private int?           	_unitsNumTotalNonDefault 	= null;
		private string         	_medicalMalpracticeCarrierCodeNonDefault	= null;
		private int?           	_totalLicBedsTotalNonDefault	= null;
		private string         	_medicalMalpracticePolicyNumNonDefault	= null;
		private int?           	_psychiatricBedsTotalNonDefault	= null;
		private DateTime?      	_medicalMalpracticeExpirationDateNonDefault	= null;
		private string         	_isolationUnitYNNonDefault	= null;
		private int?           	_rehabilitationBedsTotalNonDefault	= null;
		private int?           	_snfBedsTotalNonDefault  	= null;
		private string         	_statusCodeNonDefault    	= null;
		private int?           	_unitsNumOffsiteTotalNonDefault	= null;
		private DateTime?      	_statusDateNonDefault    	= null;
		private int?           	_totalLicBedsOffsiteTotalNonDefault	= null;
		private int?           	_noOfParishesServedNonDefault	= null;
		private int?           	_psychiatricBedsOffsiteTotalNonDefault	= null;
		private DateTime?      	_licensureSurveyDateNonDefault	= null;
		private int?           	_rehabBedsOffsiteTotalNonDefault	= null;
		private string         	_waiversNonDefault       	= null;
		private int?           	_snfBedsOffsiteTotalNonDefault	= null;
		private int?           	_otherBedsOffsiteTotalNonDefault	= null;
		private string         	_psychPpsFederalIDNonDefault	= null;
		private string         	_rehabPpsFederalIDNonDefault	= null;
		private string         	_userLastMaintNonDefault 	= null;
		private DateTime?      	_psychPpsCertEffectiveDateNonDefault	= null;
		private DateTime?      	_dateLastMaintNonDefault 	= null;
		private DateTime?      	_rehabPpsCertEffectiveDateNonDefault	= null;
		private string         	_timeLastMaintNonDefault 	= null;
		private string         	_offsiteCampusYNNonDefault	= null;
		private string         	_certifiedBedOverrideYNNonDefault	= null;
		private int?           	_mainCampusBedsNonDefault	= null;
		private DateTime?      	_forYearEndingDateNonDefault	= null;
		private string         	_neonatalIntCodeNonDefault	= null;
		private string         	_servicesOfferedNonDefault	= null;
		private string         	_picuIntCodeNonDefault   	= null;
		private string         	_halfwayHouseNonDefault  	= null;
		private string         	_deemedStatusNonDefault  	= null;
		private string         	_inPatientNonDefault     	= null;
		private string         	_chapAccreditionYNNonDefault	= null;
		private string         	_crisisEmergencyNonDefault	= null;
		private string         	_outpatientTreatmentNonDefault	= null;
		private string         	_fiscalIntermediaryNumNonDefault	= null;
		private string         	_methadoneTreatmentNonDefault	= null;
		private string         	_attesestationStatementNonDefault	= null;
		private string         	_preventionEducationNonDefault	= null;
		private DateTime?      	_attesestationStmtDateSignedNonDefault	= null;
		private string         	_residentialTreatmentNonDefault	= null;
		private string         	_nameChangePrevName1NonDefault	= null;
		private string         	_socialSettingDetoxificationNonDefault	= null;
		private DateTime?      	_nameChangeDate1NonDefault	= null;
		private string         	_adultHealthCareNonDefault	= null;
		private string         	_nameChangePrevName2NonDefault	= null;
		private DateTime?      	_nameChangeDate2NonDefault	= null;
		private string         	_cnatTrainingCodeNonDefault	= null;
		private DateTime?      	_cnatTrainingSuspendDateNonDefault	= null;
		private string         	_previousOwner1NonDefault	= null;
		private DateTime?      	_prevOwnerChangeDate1NonDefault	= null;
		private string         	_assistDirOfNursingWaiverMonthNonDefault	= null;
		private string         	_day7RnWaiverMonthNonDefault	= null;
		private string         	_previousOwner2NonDefault	= null;
		private DateTime?      	_prevOwnerChangeDate2NonDefault	= null;
		private string         	_currentSurveyMonthNonDefault	= null;
		private string         	_fiscalIntermediaryDescNonDefault	= null;
		private string         	_medicareInterPrefCodeNonDefault	= null;
		private string         	_programCodeNonDefault   	= null;
		private int?           	_noTreatmentsPerWeekNonDefault	= null;
		private int?           	_noOfStationsNonDefault  	= null;
		private string         	_levelDescriptionNonDefault	= null;
		private DateTime?      	_automaticCancellationDateNonDefault	= null;
		private int?           	_noOf3hrShiftsWeekNonDefault	= null;
		private int?           	_fcertBedsNonDefault     	= null;
		private int?           	_averageNumPatientsShiftNonDefault	= null;
		private DateTime?      	_automobileInsurancePrepaymentDueDateNonDefault	= null;
		private string         	_vendorNumNonDefault     	= null;
		private DateTime?      	_generalLiabilityPrepaymentDueDateNonDefault	= null;
		private string         	_waiverCodeNonDefault    	= null;
		private string         	_waiverCode2NonDefault   	= null;
		private int?           	_overrideCapacityNonDefault	= null;
		private string         	_rnCoordinatorNonDefault 	= null;
		private string         	_waiverCode3NonDefault   	= null;
		private string         	_waiverCode4NonDefault   	= null;
		private string         	_directorNameNonDefault  	= null;
		private string         	_waiverCode5NonDefault   	= null;
		private DateTime?      	_year1ReviewDateDueNonDefault	= null;
		private string         	_waiverCode6NonDefault   	= null;
		private string         	_waiverCode7NonDefault   	= null;
		private int?           	_usageNonDefault         	= null;
		private int?           	_totalNumDialysisPatientsNonDefault	= null;
		private DateTime?      	_accreditationExpirationDateNonDefault	= null;
		private int?           	_hemodialysisNumPatientsNonDefault	= null;
		private string         	_facilityWithinFacilityNonDefault	= null;
		private int?           	_numOfPeritonealDialysisPatientsNonDefault	= null;
		private string         	_facilityTypeCodeNonDefault	= null;
		private int?           	_hemodialysisNumOfStationsNonDefault	= null;
		private string         	_transplantYNNonDefault  	= null;
		private int?           	_hemodialysisTrainingNumOfStationNonDefault	= null;
		private string         	_obIntCodeNonDefault     	= null;
		private DateTime?      	_obCurrentSurveyDateNonDefault	= null;
		private int?           	_totalNumStationsNonDefault	= null;
		private string         	_reuseYNNonDefault       	= null;
		private DateTime?      	_nicuCurrentSurveyDateNonDefault	= null;
		private string         	_manualYNNonDefault      	= null;
		private DateTime?      	_picuCurrentSurveyDateNonDefault	= null;
		private int?           	_numOfPatientsFollowedAtHomeNonDefault	= null;
		private string         	_traumaLevelNonDefault   	= null;
		private string         	_semiautomatedYNNonDefault	= null;
		private string         	_automatedYNNonDefault   	= null;
		private string         	_formainGermicideNonDefault	= null;
		private string         	_heatGermicideNonDefault 	= null;
		private string         	_gluteraldetydeGermicideNonDefault	= null;
		private string         	_peraceticAcidMixtureGermNonDefault	= null;
		private string         	_otherGermicideNonDefault	= null;
		private string         	_enrolledRhcOffsiteYNNonDefault	= null;
		private string         	_typeGermicideDescriptionNonDefault	= null;
		private string         	_hemodialysisServiceNonDefault	= null;
		private string         	_directorOfNursingFirstNameNonDefault	= null;
		private string         	_peritonealDialysisServiceNonDefault	= null;
		private string         	_directorOfNursingLastNameNonDefault	= null;
		private string         	_presidentFirstNameNonDefault	= null;
		private string         	_transplanationServiceNonDefault	= null;
		private string         	_presidentLastNameNonDefault	= null;
		private string         	_homeTrainingServiceNonDefault	= null;
		private int?           	_staffingFteRNNonDefault 	= null;
		private int?           	_staffingFteLpnNonDefault	= null;
		private int?           	_staffingFteSWNonDefault 	= null;
		private int?           	_staffingFteTechniciansNonDefault	= null;
		private int?           	_staffingFteDietianNonDefault	= null;
		private int?           	_staffingFteOthersNonDefault	= null;
		private string         	_initialNonDefault       	= null;
		private DateTime?      	_initialDateNonDefault   	= null;
		private string         	_expansionToNewLocationNonDefault	= null;
		private DateTime?      	_expToNewLocationDateNonDefault	= null;
		private string         	_changeOfOwnershipNonDefault	= null;
		private string         	_changeOfLocationNonDefault	= null;
		private DateTime?      	_changeOfLocationDateNonDefault	= null;
		private string         	_expansionInCurrentLocationNonDefault	= null;
		private DateTime?      	_expansionInCurrentLocationDateNonDefault	= null;
		private string         	_changeOfServicesNonDefault	= null;
		private DateTime?      	_changeOfServicesDateNonDefault	= null;
		private string         	_typeApplicationCode7NonDefault	= null;
		private DateTime?      	_typeApplicationCode7DateNonDefault	= null;
		private string         	_typeApplicationDescrNonDefault	= null;
		private string         	_providerBasedYNNonDefault	= null;
		private string         	_midLevelWaiverYNNonDefault	= null;
		private string         	_midLevelWaiverMonthNonDefault	= null;
		private DateTime?      	_midLevelWaiverDateNonDefault	= null;
		private string         	_relatedProviderLicensureNumNonDefault	= null;
		private string         	_emergencyPrepReportRequiredNonDefault	= null;
		private string         	_accreditedBodyNonDefault	= null;
		private string         	_enrolledInMedicaidYNNonDefault	= null;
		private string         	_typeTreatmentNonDefault 	= null;
		private string         	_licensedByOtherNonDefault	= "0";
		private DateTime?      	_licensureEffectiveDateNonDefault	= null;
		private int?           	_numActivePatientsNonDefault	= null;
		private int?           	_numRadiologicTechBsbaNonDefault	= null;
		private int?           	_numRadiologicTechASNonDefault	= null;
		private int?           	_numRadiologicTechCrtNonDefault	= null;
		private int?           	_numRadiologicTechOtherNonDefault	= null;
		private string         	_isolationNumOfStationsNonDefault	= null;
		private string         	_relatedProviderNameNonDefault	= null;
		private int?           	_numOperatingRoomsNonDefault	= null;
		private string         	_admMultiFacYNNonDefault 	= null;
		private string         	_admMultiFacOtherNameNonDefault	= null;
		private string         	_singleStoryYNNonDefault 	= null;
		private DateTime?      	_closedDateNonDefault    	= null;
        private DateTime? _year2ReviewDateDueNonDefault = null;

		private BO_Addresses _bO_AddressesPopsIntID = null;
		private BO_Affiliations _bO_AffiliationsPopsIntID = null;
		private BO_Applications _bO_ApplicationsPopsIntID = null;
		private BO_Billings _bO_BillingsPopsIntID = null;
		private BO_Capacities _bO_CapacitiesPopsIntID = null;
		private BO_Comments _bO_CommentsPopsIntID = null;
		private BO_InsuranceCoverages _bO_InsuranceCoveragesPopsIntID = null;
		private BO_LetterOfIntents _bO_LetterOfIntentsPopsIntID = null;
		private BO_Licenses _bO_LicensesPopsIntID = null;
		private BO_Messages _bO_MessagesPopsIntID = null;
		private BO_Ownerships _bO_OwnershipsPopsIntID = null;
		private BO_ParishServeds _bO_ParishServedsPopsIntID = null;
		private BO_ProviderPeople _bO_ProviderPeoplePopsIntID = null;
		private BO_ProviderLogins _bO_ProviderLoginsPopsIntID = null;
		private BO_Services _bO_ServicesPopsIntID = null;
		private BO_SpecialtyUnits _bO_SpecialtyUnitsPopsIntID = null;
		private BO_Staffings _bO_StaffingsPopsIntID = null;
		private BO_Substations _bO_SubstationsPopsIntID = null;
		private BO_Vehicles _bO_VehiclesPopsIntID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ProviderBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// This property is mapped to the "STATE_ID" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string StateID
		{
			get 
			{ 
                if(_stateIDNonDefault==null)return _stateIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("StateID length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _stateIDNonDefault =null;//null value 
                }
                else
                {		           
		            _stateIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? PopsIntID
		{
			get 
			{ 
                return _popsIntIDNonDefault;
			}
			set 
			{
            
                _popsIntIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ASPEN_INT_ID" field.  
		/// </summary>
		public int? AspenIntID
		{
			get 
			{ 
                return _aspenIntIDNonDefault;
			}
			set 
			{
            
                _aspenIntIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string ProgramID
		{
			get 
			{ 
                if(_programIDNonDefault==null)return _programIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _programIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programIDNonDefault =null;//null value 
                }
                else
                {		           
		            _programIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_CODE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string StateCode
		{
			get 
			{ 
                if(_stateCodeNonDefault==null)return _stateCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("StateCode length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _stateCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _stateCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROGRAM_STAFF_ID" field.  
		/// </summary>
		public int? ProgramStaffID
		{
			get 
			{ 
                return _programStaffIDNonDefault;
			}
			set 
			{
            
                _programStaffIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string ParishCode
		{
			get 
			{ 
                if(_parishCodeNonDefault==null)return _parishCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _parishCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ParishCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _parishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _parishCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string RegionCode
		{
			get 
			{ 
                if(_regionCodeNonDefault==null)return _regionCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _regionCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("RegionCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _regionCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _regionCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FEDERAL_ID" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string FederalID
		{
			get 
			{ 
                if(_federalIDNonDefault==null)return _federalIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _federalIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("FederalID length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _federalIDNonDefault =null;//null value 
                }
                else
                {		           
		            _federalIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSURE_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string LicensureNum
		{
			get 
			{ 
                if(_licensureNumNonDefault==null)return _licensureNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensureNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("LicensureNum length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _licensureNumNonDefault =null;//null value 
                }
                else
                {		           
		            _licensureNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHICAL_STREET_ADDR2" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string GeographicalStreetAddr2
		{
			get 
			{ 
                if(_geographicalStreetAddr2NonDefault==null)return _geographicalStreetAddr2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _geographicalStreetAddr2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("GeographicalStreetAddr2 length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _geographicalStreetAddr2NonDefault =null;//null value 
                }
                else
                {		           
		            _geographicalStreetAddr2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SCHOOL_ID" field.  
		/// </summary>
		public int? SchoolID
		{
			get 
			{ 
                return _schoolIDNonDefault;
			}
			set 
			{
            
                _schoolIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string FacilityName
		{
			get 
			{ 
                if(_facilityNameNonDefault==null)return _facilityNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _facilityNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("FacilityName length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _facilityNameNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LEGAL_NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string LegalName
		{
			get 
			{ 
                if(_legalNameNonDefault==null)return _legalNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _legalNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("LegalName length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _legalNameNonDefault =null;//null value 
                }
                else
                {		           
		            _legalNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_STREET2" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string MailStreet2
		{
			get 
			{ 
                if(_mailStreet2NonDefault==null)return _mailStreet2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _mailStreet2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("MailStreet2 length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _mailStreet2NonDefault =null;//null value 
                }
                else
                {		           
		            _mailStreet2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHICAL_STREET" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string GeographicalStreet
		{
			get 
			{ 
                if(_geographicalStreetNonDefault==null)return _geographicalStreetNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _geographicalStreetNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("GeographicalStreet length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _geographicalStreetNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicalStreetNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHICAL_CITY" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string GeographicalCity
		{
			get 
			{ 
                if(_geographicalCityNonDefault==null)return _geographicalCityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _geographicalCityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("GeographicalCity length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _geographicalCityNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicalCityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHICAL_ZIP" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string GeographicalZip
		{
			get 
			{ 
                if(_geographicalZipNonDefault==null)return _geographicalZipNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _geographicalZipNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("GeographicalZip length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _geographicalZipNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicalZipNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GEOGRAPHICAL_STATE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string GeographicalState
		{
			get 
			{ 
                if(_geographicalStateNonDefault==null)return _geographicalStateNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _geographicalStateNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("GeographicalState length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _geographicalStateNonDefault =null;//null value 
                }
                else
                {		           
		            _geographicalStateNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_STREET" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string MailStreet
		{
			get 
			{ 
                if(_mailStreetNonDefault==null)return _mailStreetNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _mailStreetNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("MailStreet length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _mailStreetNonDefault =null;//null value 
                }
                else
                {		           
		            _mailStreetNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_CITY" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string MailCity
		{
			get 
			{ 
                if(_mailCityNonDefault==null)return _mailCityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _mailCityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("MailCity length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _mailCityNonDefault =null;//null value 
                }
                else
                {		           
		            _mailCityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_STATE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string MailState
		{
			get 
			{ 
                if(_mailStateNonDefault==null)return _mailStateNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _mailStateNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("MailState length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _mailStateNonDefault =null;//null value 
                }
                else
                {		           
		            _mailStateNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIL_ZIP" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string MailZip
		{
			get 
			{ 
                if(_mailZipNonDefault==null)return _mailZipNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _mailZipNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("MailZip length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _mailZipNonDefault =null;//null value 
                }
                else
                {		           
		            _mailZipNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMS_PARISH_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string EmsParishCode
		{
			get 
			{ 
                if(_emsParishCodeNonDefault==null)return _emsParishCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _emsParishCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("EmsParishCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _emsParishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _emsParishCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PARISH" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string Parish
		{
			get 
			{ 
                if(_parishNonDefault==null)return _parishNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _parishNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("Parish length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _parishNonDefault =null;//null value 
                }
                else
                {		           
		            _parishNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "REGIONAL_OFFICE" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string RegionalOffice
		{
			get 
			{ 
                if(_regionalOfficeNonDefault==null)return _regionalOfficeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _regionalOfficeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("RegionalOffice length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _regionalOfficeNonDefault =null;//null value 
                }
                else
                {		           
		            _regionalOfficeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ZONE_NUM_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string ZoneNumCode
		{
			get 
			{ 
                if(_zoneNumCodeNonDefault==null)return _zoneNumCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _zoneNumCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ZoneNumCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _zoneNumCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _zoneNumCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TELEPHONE_NUMBER" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string TelephoneNumber
		{
			get 
			{ 
                if(_telephoneNumberNonDefault==null)return _telephoneNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _telephoneNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("TelephoneNumber length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _telephoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _telephoneNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMERGENCY_PHONE_NUMBER" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string EmergencyPhoneNumber
		{
			get 
			{ 
                if(_emergencyPhoneNumberNonDefault==null)return _emergencyPhoneNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _emergencyPhoneNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("EmergencyPhoneNumber length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _emergencyPhoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _emergencyPhoneNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAX_PHONE_NUMBER" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string FaxPhoneNumber
		{
			get 
			{ 
                if(_faxPhoneNumberNonDefault==null)return _faxPhoneNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _faxPhoneNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("FaxPhoneNumber length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _faxPhoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _faxPhoneNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINISTRATOR" field. Length must be between 0 and 45 characters. 
		/// </summary>
		public string Administrator
		{
			get 
			{ 
                if(_administratorNonDefault==null)return _administratorNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _administratorNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 45)
					throw new ArgumentException("Administrator length must be between 0 and 45 characters.");

				
                if(value ==null)
                {
                    _administratorNonDefault =null;//null value 
                }
                else
                {		           
		            _administratorNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINISTRATOR_TITLE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string AdministratorTitle
		{
			get 
			{ 
                if(_administratorTitleNonDefault==null)return _administratorTitleNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _administratorTitleNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("AdministratorTitle length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _administratorTitleNonDefault =null;//null value 
                }
                else
                {		           
		            _administratorTitleNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINISTRATOR_FIRST_NAME" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string AdministratorFirstName
		{
			get 
			{ 
                if(_administratorFirstNameNonDefault==null)return _administratorFirstNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _administratorFirstNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("AdministratorFirstName length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _administratorFirstNameNonDefault =null;//null value 
                }
                else
                {		           
		            _administratorFirstNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINISTRATOR_MID_INIT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string AdministratorMidInit
		{
			get 
			{ 
                if(_administratorMidInitNonDefault==null)return _administratorMidInitNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _administratorMidInitNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("AdministratorMidInit length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _administratorMidInitNonDefault =null;//null value 
                }
                else
                {		           
		            _administratorMidInitNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADMINISTRATOR_LAST_NAME" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string AdministratorLastName
		{
			get 
			{ 
                if(_administratorLastNameNonDefault==null)return _administratorLastNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _administratorLastNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("AdministratorLastName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _administratorLastNameNonDefault =null;//null value 
                }
                else
                {		           
		            _administratorLastNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CONTACT_NAME" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string ContactName
		{
			get 
			{ 
                if(_contactNameNonDefault==null)return _contactNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _contactNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("ContactName length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _contactNameNonDefault =null;//null value 
                }
                else
                {		           
		            _contactNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_ID_MDS" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string StateIdMds
		{
			get 
			{ 
                if(_stateIdMdsNonDefault==null)return _stateIdMdsNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateIdMdsNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("StateIdMds length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _stateIdMdsNonDefault =null;//null value 
                }
                else
                {		           
		            _stateIdMdsNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_LIC_NUM" field. Length must be between 0 and 7 characters. 
		/// </summary>
		public string StateLicNum
		{
			get 
			{ 
                if(_stateLicNumNonDefault==null)return _stateLicNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _stateLicNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 7)
					throw new ArgumentException("StateLicNum length must be between 0 and 7 characters.");

				
                if(value ==null)
                {
                    _stateLicNumNonDefault =null;//null value 
                }
                else
                {		           
		            _stateLicNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMAIL_ADDRESS" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string EmailAddress
		{
			get 
			{ 
                if(_emailAddressNonDefault==null)return _emailAddressNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _emailAddressNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Trim().Length > 100)
					throw new ArgumentException("EmailAddress length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _emailAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _emailAddressNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAID_VENDOR_NUMBER" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string MedicaidVendorNumber
		{
			get 
			{ 
                if(_medicaidVendorNumberNonDefault==null)return _medicaidVendorNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicaidVendorNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("MedicaidVendorNumber length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _medicaidVendorNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _medicaidVendorNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FIELD_OFFICE_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string FieldOfficeCode
		{
			get 
			{ 
                if(_fieldOfficeCodeNonDefault==null)return _fieldOfficeCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _fieldOfficeCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("FieldOfficeCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _fieldOfficeCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _fieldOfficeCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_FULL_NAME" field. Length must be between 0 and 45 characters. 
		/// </summary>
		public string MedicalDirectorFullName
		{
			get 
			{ 
                if(_medicalDirectorFullNameNonDefault==null)return _medicalDirectorFullNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorFullNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 45)
					throw new ArgumentException("MedicalDirectorFullName length must be between 0 and 45 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorFullNameNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorFullNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_TITLE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string MedicalDirectorTitle
		{
			get 
			{ 
                if(_medicalDirectorTitleNonDefault==null)return _medicalDirectorTitleNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorTitleNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("MedicalDirectorTitle length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorTitleNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorTitleNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIR_FIRST_NAME" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string MedicalDirFirstName
		{
			get 
			{ 
                if(_medicalDirFirstNameNonDefault==null)return _medicalDirFirstNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirFirstNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("MedicalDirFirstName length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _medicalDirFirstNameNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirFirstNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIR_MID_INIT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string MedicalDirMidInit
		{
			get 
			{ 
                if(_medicalDirMidInitNonDefault==null)return _medicalDirMidInitNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirMidInitNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("MedicalDirMidInit length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _medicalDirMidInitNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirMidInitNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIR_LAST_NAME" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string MedicalDirLastName
		{
			get 
			{ 
                if(_medicalDirLastNameNonDefault==null)return _medicalDirLastNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirLastNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("MedicalDirLastName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _medicalDirLastNameNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirLastNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_MAIL_ADDR1" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string MedicalDirectorMailAddr1
		{
			get 
			{ 
                if(_medicalDirectorMailAddr1NonDefault==null)return _medicalDirectorMailAddr1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorMailAddr1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("MedicalDirectorMailAddr1 length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorMailAddr1NonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorMailAddr1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_MAIL_ADDR2" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string MedicalDirectorMailAddr2
		{
			get 
			{ 
                if(_medicalDirectorMailAddr2NonDefault==null)return _medicalDirectorMailAddr2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorMailAddr2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("MedicalDirectorMailAddr2 length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorMailAddr2NonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorMailAddr2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_MAIL_CITY" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string MedicalDirectorMailCity
		{
			get 
			{ 
                if(_medicalDirectorMailCityNonDefault==null)return _medicalDirectorMailCityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorMailCityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("MedicalDirectorMailCity length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorMailCityNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorMailCityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_MAIL_STATE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string MedicalDirectorMailState
		{
			get 
			{ 
                if(_medicalDirectorMailStateNonDefault==null)return _medicalDirectorMailStateNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorMailStateNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("MedicalDirectorMailState length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorMailStateNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorMailStateNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_DIRECTOR_MAIL_ZIP" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string MedicalDirectorMailZip
		{
			get 
			{ 
                if(_medicalDirectorMailZipNonDefault==null)return _medicalDirectorMailZipNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalDirectorMailZipNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("MedicalDirectorMailZip length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _medicalDirectorMailZipNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalDirectorMailZipNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HOURS_MINUTES" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string HoursMinutes
		{
			get 
			{ 
                if(_hoursMinutesNonDefault==null)return _hoursMinutesNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _hoursMinutesNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("HoursMinutes length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _hoursMinutesNonDefault =null;//null value 
                }
                else
                {		           
		            _hoursMinutesNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF18BEDS" field.  
		/// </summary>
		public int? Snf18beds
		{
			get 
			{ 
                return _snf18bedsNonDefault;
			}
			set 
			{
            
                _snf18bedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AM_PM" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string AmPM
		{
			get 
			{ 
                if(_amPMNonDefault==null)return _amPMNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _amPMNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("AmPM length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _amPMNonDefault =null;//null value 
                }
                else
                {		           
		            _amPMNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HOURS_MINUTES_1" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string HoursMinutes1
		{
			get 
			{ 
                if(_hoursMinutes1NonDefault==null)return _hoursMinutes1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _hoursMinutes1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("HoursMinutes1 length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _hoursMinutes1NonDefault =null;//null value 
                }
                else
                {		           
		            _hoursMinutes1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AM_PM_1" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string AmPm1
		{
			get 
			{ 
                if(_amPm1NonDefault==null)return _amPm1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _amPm1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("AmPm1 length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _amPm1NonDefault =null;//null value 
                }
                else
                {		           
		            _amPm1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_MON" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationMon
		{
			get 
			{ 
                if(_dayOfOperationMonNonDefault==null)return _dayOfOperationMonNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationMonNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationMon length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationMonNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationMonNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_TUE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationTue
		{
			get 
			{ 
                if(_dayOfOperationTueNonDefault==null)return _dayOfOperationTueNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationTueNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationTue length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationTueNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationTueNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_WED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationWed
		{
			get 
			{ 
                if(_dayOfOperationWedNonDefault==null)return _dayOfOperationWedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationWedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationWed length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationWedNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationWedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_THU" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationThu
		{
			get 
			{ 
                if(_dayOfOperationThuNonDefault==null)return _dayOfOperationThuNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationThuNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationThu length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationThuNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationThuNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_FRI" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationFri
		{
			get 
			{ 
                if(_dayOfOperationFriNonDefault==null)return _dayOfOperationFriNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationFriNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationFri length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationFriNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationFriNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_SAT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationSat
		{
			get 
			{ 
                if(_dayOfOperationSatNonDefault==null)return _dayOfOperationSatNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationSatNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationSat length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationSatNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationSatNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY_OF_OPERATION_SUN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DayOfOperationSun
		{
			get 
			{ 
                if(_dayOfOperationSunNonDefault==null)return _dayOfOperationSunNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _dayOfOperationSunNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DayOfOperationSun length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _dayOfOperationSunNonDefault =null;//null value 
                }
                else
                {		           
		            _dayOfOperationSunNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_LICENSE_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeLicenseCode
		{
			get 
			{ 
                if(_typeLicenseCodeNonDefault==null)return _typeLicenseCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeLicenseCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeLicenseCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeLicenseCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeLicenseCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_OF_LICENSE" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string TypeOfLicense
		{
			get 
			{ 
                if(_typeOfLicenseNonDefault==null)return _typeOfLicenseNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeOfLicenseNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("TypeOfLicense length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _typeOfLicenseNonDefault =null;//null value 
                }
                else
                {		           
		            _typeOfLicenseNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacilityCode
		{
			get 
			{ 
                if(_typeFacilityCodeNonDefault==null)return _typeFacilityCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacilityCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacilityCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacilityCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacilityCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_1_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility1Code
		{
			get 
			{ 
                if(_typeFacility1CodeNonDefault==null)return _typeFacility1CodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacility1CodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility1Code length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility1CodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility1CodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_2_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility2Code
		{
			get 
			{ 
                if(_typeFacility2CodeNonDefault==null)return _typeFacility2CodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacility2CodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility2Code length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility2CodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility2CodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_3_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility3Code
		{
			get 
			{ 
                if(_typeFacility3CodeNonDefault==null)return _typeFacility3CodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacility3CodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility3Code length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility3CodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility3CodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_4_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility4Code
		{
			get 
			{ 
                if(_typeFacility4CodeNonDefault==null)return _typeFacility4CodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacility4CodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility4Code length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility4CodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility4CodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_5_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility5Code
		{
			get 
			{ 
                if(_typeFacility5CodeNonDefault==null)return _typeFacility5CodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacility5CodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility5Code length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility5CodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility5CodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_6_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility6Code
		{
			get 
			{ 
                if(_typeFacility6CodeNonDefault==null)return _typeFacility6CodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeFacility6CodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility6Code length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility6CodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility6CodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSED_SNF_FACILITY" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string LicensedSnfFacility
		{
			get 
			{ 
                if(_licensedSnfFacilityNonDefault==null)return _licensedSnfFacilityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensedSnfFacilityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("LicensedSnfFacility length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licensedSnfFacilityNonDefault =null;//null value 
                }
                else
                {		           
		            _licensedSnfFacilityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF1819BEDS" field.  
		/// </summary>
		public int? Snf1819beds
		{
			get 
			{ 
                return _snf1819bedsNonDefault;
			}
			set 
			{
            
                _snf1819bedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF19BEDS" field.  
		/// </summary>
		public int? Snf19beds
		{
			get 
			{ 
                return _snf19bedsNonDefault;
			}
			set 
			{
            
                _snf19bedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_OF_CLIENTS" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string TypeOfClients
		{
			get 
			{ 
                if(_typeOfClientsNonDefault==null)return _typeOfClientsNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeOfClientsNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("TypeOfClients length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _typeOfClientsNonDefault =null;//null value 
                }
                else
                {		           
		            _typeOfClientsNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PSYCHIATRIC_BEDS" field.  
		/// </summary>
		public int? PsychiatricBeds
		{
			get 
			{ 
                return _psychiatricBedsNonDefault;
			}
			set 
			{
            
                _psychiatricBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF_BEDS" field.  
		/// </summary>
		public int? SnfBeds
		{
			get 
			{ 
                return _snfBedsNonDefault;
			}
			set 
			{
            
                _snfBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SWING_BEDS" field.  
		/// </summary>
		public int? SwingBeds
		{
			get 
			{ 
                return _swingBedsNonDefault;
			}
			set 
			{
            
                _swingBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REHABILITATION_BEDS" field.  
		/// </summary>
		public int? RehabilitationBeds
		{
			get 
			{ 
                return _rehabilitationBedsNonDefault;
			}
			set 
			{
            
                _rehabilitationBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_LIC_BEDS" field.  
		/// </summary>
		public int? TotalLicBeds
		{
			get 
			{ 
                return _totalLicBedsNonDefault;
			}
			set 
			{
            
                _totalLicBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_CERTIFIED" field.  
		/// </summary>
		public int? BedsCertified
		{
			get 
			{ 
                return _bedsCertifiedNonDefault;
			}
			set 
			{
            
                _bedsCertifiedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_OWNERSHIP_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeOwnershipCode
		{
			get 
			{ 
                if(_typeOwnershipCodeNonDefault==null)return _typeOwnershipCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeOwnershipCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeOwnershipCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeOwnershipCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeOwnershipCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_OF_CORPORATION" field. Length must be between 0 and 68 characters. 
		/// </summary>
		public string NameOfCorporation
		{
			get 
			{ 
                if(_nameOfCorporationNonDefault==null)return _nameOfCorporationNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameOfCorporationNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 68)
					throw new ArgumentException("NameOfCorporation length must be between 0 and 68 characters.");

				
                if(value ==null)
                {
                    _nameOfCorporationNonDefault =null;//null value 
                }
                else
                {		           
		            _nameOfCorporationNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_ID_NUM" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string CorporationIdNum
		{
			get 
			{ 
                if(_corporationIdNumNonDefault==null)return _corporationIdNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationIdNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("CorporationIdNum length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _corporationIdNumNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationIdNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_STREET" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string CorporationStreet
		{
			get 
			{ 
                if(_corporationStreetNonDefault==null)return _corporationStreetNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationStreetNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("CorporationStreet length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _corporationStreetNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationStreetNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_CITY" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string CorporationCity
		{
			get 
			{ 
                if(_corporationCityNonDefault==null)return _corporationCityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationCityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("CorporationCity length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _corporationCityNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationCityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_STATE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string CorporationState
		{
			get 
			{ 
                if(_corporationStateNonDefault==null)return _corporationStateNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationStateNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("CorporationState length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _corporationStateNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationStateNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_ZIP" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string CorporationZip
		{
			get 
			{ 
                if(_corporationZipNonDefault==null)return _corporationZipNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationZipNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("CorporationZip length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _corporationZipNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationZipNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_PHONE" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string CorporationPhone
		{
			get 
			{ 
                if(_corporationPhoneNonDefault==null)return _corporationPhoneNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationPhoneNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("CorporationPhone length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _corporationPhoneNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationPhoneNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CORPORATION_FAX" field. Length must be between 0 and 13 characters. 
		/// </summary>
		public string CorporationFax
		{
			get 
			{ 
                if(_corporationFaxNonDefault==null)return _corporationFaxNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _corporationFaxNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 13)
					throw new ArgumentException("CorporationFax length must be between 0 and 13 characters.");

				
                if(value ==null)
                {
                    _corporationFaxNonDefault =null;//null value 
                }
                else
                {		           
		            _corporationFaxNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_OF_OWNER_1" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string NameOfOwner1
		{
			get 
			{ 
                if(_nameOfOwner1NonDefault==null)return _nameOfOwner1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameOfOwner1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("NameOfOwner1 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameOfOwner1NonDefault =null;//null value 
                }
                else
                {		           
		            _nameOfOwner1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_OF_OWNER_2" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string NameOfOwner2
		{
			get 
			{ 
                if(_nameOfOwner2NonDefault==null)return _nameOfOwner2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameOfOwner2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("NameOfOwner2 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameOfOwner2NonDefault =null;//null value 
                }
                else
                {		           
		            _nameOfOwner2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_OF_OWNER_3" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string NameOfOwner3
		{
			get 
			{ 
                if(_nameOfOwner3NonDefault==null)return _nameOfOwner3NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameOfOwner3NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("NameOfOwner3 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameOfOwner3NonDefault =null;//null value 
                }
                else
                {		           
		            _nameOfOwner3NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_OF_OWNER_4" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string NameOfOwner4
		{
			get 
			{ 
                if(_nameOfOwner4NonDefault==null)return _nameOfOwner4NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameOfOwner4NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("NameOfOwner4 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameOfOwner4NonDefault =null;//null value 
                }
                else
                {		           
		            _nameOfOwner4NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PRESIDENT_NAME" field. Length must be between 0 and 32 characters. 
		/// </summary>
		public string PresidentName
		{
			get 
			{ 
                if(_presidentNameNonDefault==null)return _presidentNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _presidentNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 32)
					throw new ArgumentException("PresidentName length must be between 0 and 32 characters.");

				
                if(value ==null)
                {
                    _presidentNameNonDefault =null;//null value 
                }
                else
                {		           
		            _presidentNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VICE_PRESIDENT_NAME" field. Length must be between 0 and 32 characters. 
		/// </summary>
		public string VicePresidentName
		{
			get 
			{ 
                if(_vicePresidentNameNonDefault==null)return _vicePresidentNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _vicePresidentNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 32)
					throw new ArgumentException("VicePresidentName length must be between 0 and 32 characters.");

				
                if(value ==null)
                {
                    _vicePresidentNameNonDefault =null;//null value 
                }
                else
                {		           
		            _vicePresidentNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SECRETARY_TREASURER_NAME" field. Length must be between 0 and 32 characters. 
		/// </summary>
		public string SecretaryTreasurerName
		{
			get 
			{ 
                if(_secretaryTreasurerNameNonDefault==null)return _secretaryTreasurerNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _secretaryTreasurerNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 32)
					throw new ArgumentException("SecretaryTreasurerName length must be between 0 and 32 characters.");

				
                if(value ==null)
                {
                    _secretaryTreasurerNameNonDefault =null;//null value 
                }
                else
                {		           
		            _secretaryTreasurerNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "JCAH_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string JcahYN
		{
			get 
			{ 
                if(_jcahYNNonDefault==null)return _jcahYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _jcahYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("JcahYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _jcahYNNonDefault =null;//null value 
                }
                else
                {		           
		            _jcahYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_OF_OWNER_DATE" field.  
		/// </summary>
		public DateTime? ChangeOfOwnerDate
		{
			get 
			{ 
                return _changeOfOwnerDateNonDefault;
			}
			set 
			{
            
                _changeOfOwnerDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ORIGINAL_LICENSURE_DATE" field.  
		/// </summary>
		public DateTime? OriginalLicensureDate
		{
			get 
			{ 
                return _originalLicensureDateNonDefault;
			}
			set 
			{
            
                _originalLicensureDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ORIGINAL_ENROLLMENT_DATE" field.  
		/// </summary>
		public DateTime? OriginalEnrollmentDate
		{
			get 
			{ 
                return _originalEnrollmentDateNonDefault;
			}
			set 
			{
            
                _originalEnrollmentDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CURRENT_LIC_ISSUE_DATE" field.  
		/// </summary>
		public DateTime? CurrentLicIssueDate
		{
			get 
			{ 
                return _currentLicIssueDateNonDefault;
			}
			set 
			{
            
                _currentLicIssueDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSURE_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? LicensureExpirationDate
		{
			get 
			{ 
                return _licensureExpirationDateNonDefault;
			}
			set 
			{
            
                _licensureExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSURE_ANNIVERSARY_MTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string LicensureAnniversaryMth
		{
			get 
			{ 
                if(_licensureAnniversaryMthNonDefault==null)return _licensureAnniversaryMthNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensureAnniversaryMthNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("LicensureAnniversaryMth length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _licensureAnniversaryMthNonDefault =null;//null value 
                }
                else
                {		           
		            _licensureAnniversaryMthNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CAPACITY" field.  
		/// </summary>
		public int? Capacity
		{
			get 
			{ 
                return _capacityNonDefault;
			}
			set 
			{
            
                _capacityNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CAPACITY_IN_HOME" field.  
		/// </summary>
		public int? CapacityInHome
		{
			get 
			{ 
                return _capacityInHomeNonDefault;
			}
			set 
			{
            
                _capacityInHomeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CAPACITY_OUT_OF_HOME" field.  
		/// </summary>
		public int? CapacityOutOfHome
		{
			get 
			{ 
                return _capacityOutOfHomeNonDefault;
			}
			set 
			{
            
                _capacityOutOfHomeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AGE_RANGE" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string AgeRange
		{
			get 
			{ 
                if(_ageRangeNonDefault==null)return _ageRangeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _ageRangeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("AgeRange length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _ageRangeNonDefault =null;//null value 
                }
                else
                {		           
		            _ageRangeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "UNIT" field.  
		/// </summary>
		public int? Unit
		{
			get 
			{ 
                return _unitNonDefault;
			}
			set 
			{
            
                _unitNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FOR_YEAR_ENDING_MMDD" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string ForYearEndingMmdd
		{
			get 
			{ 
                if(_forYearEndingMmddNonDefault==null)return _forYearEndingMmddNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _forYearEndingMmddNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("ForYearEndingMmdd length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _forYearEndingMmddNonDefault =null;//null value 
                }
                else
                {		           
		            _forYearEndingMmddNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HOSPITAL_BASED_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string HospitalBasedYN
		{
			get 
			{ 
                if(_hospitalBasedYNNonDefault==null)return _hospitalBasedYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _hospitalBasedYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("HospitalBasedYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _hospitalBasedYNNonDefault =null;//null value 
                }
                else
                {		           
		            _hospitalBasedYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "APPLICATION_DATE" field.  
		/// </summary>
		public DateTime? ApplicationDate
		{
			get 
			{ 
                return _applicationDateNonDefault;
			}
			set 
			{
            
                _applicationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FEE" field.  
		/// </summary>
		public decimal? Fee
		{
			get 
			{ 
                return _feeNonDefault;
			}
			set 
			{
            
                _feeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHECK_NUMBER" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string CheckNumber
		{
			get 
			{ 
                if(_checkNumberNonDefault==null)return _checkNumberNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _checkNumberNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("CheckNumber length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _checkNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _checkNumberNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DATE_FEE_RECEIVED" field.  
		/// </summary>
		public DateTime? DateFeeReceived
		{
			get 
			{ 
                return _dateFeeReceivedNonDefault;
			}
			set 
			{
            
                _dateFeeReceivedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_FIRE_APPROVAL_DATE" field.  
		/// </summary>
		public DateTime? StateFireApprovalDate
		{
			get 
			{ 
                return _stateFireApprovalDateNonDefault;
			}
			set 
			{
            
                _stateFireApprovalDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "HEALTH_APPROVAL_DATE" field.  
		/// </summary>
		public DateTime? HealthApprovalDate
		{
			get 
			{ 
                return _healthApprovalDateNonDefault;
			}
			set 
			{
            
                _healthApprovalDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CUR_SURV" field.  
		/// </summary>
		public DateTime? CurSurv
		{
			get 
			{ 
                return _curSurvNonDefault;
			}
			set 
			{
            
                _curSurvNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "US_DEA_REG_NUM" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string UsDeaRegNum
		{
			get 
			{ 
                if(_usDeaRegNumNonDefault==null)return _usDeaRegNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _usDeaRegNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("UsDeaRegNum length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _usDeaRegNumNonDefault =null;//null value 
                }
                else
                {		           
		            _usDeaRegNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "US_DEA_REG_NUM_EXP_DATE" field.  
		/// </summary>
		public DateTime? UsDeaRegNumExpDate
		{
			get 
			{ 
                return _usDeaRegNumExpDateNonDefault;
			}
			set 
			{
            
                _usDeaRegNumExpDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LA_CDS_NUM" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string LaCdsNum
		{
			get 
			{ 
                if(_laCdsNumNonDefault==null)return _laCdsNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _laCdsNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("LaCdsNum length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _laCdsNumNonDefault =null;//null value 
                }
                else
                {		           
		            _laCdsNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LA_CDS_NUM_EXP_DATE" field.  
		/// </summary>
		public DateTime? LaCdsNumExpDate
		{
			get 
			{ 
                return _laCdsNumExpDateNonDefault;
			}
			set 
			{
            
                _laCdsNumExpDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CLIA_ID_NUM" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string CliaIdNum
		{
			get 
			{ 
                if(_cliaIdNumNonDefault==null)return _cliaIdNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _cliaIdNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("CliaIdNum length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _cliaIdNumNonDefault =null;//null value 
                }
                else
                {		           
		            _cliaIdNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CLIA_EXP_DATE" field.  
		/// </summary>
		public DateTime? CliaExpDate
		{
			get 
			{ 
                return _cliaExpDateNonDefault;
			}
			set 
			{
            
                _cliaExpDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CERT_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? CertEffectiveDate
		{
			get 
			{ 
                return _certEffectiveDateNonDefault;
			}
			set 
			{
            
                _certEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CERTIF_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? CertifExpirationDate
		{
			get 
			{ 
                return _certifExpirationDateNonDefault;
			}
			set 
			{
            
                _certifExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CERTIFICATION_MTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string CertificationMth
		{
			get 
			{ 
                if(_certificationMthNonDefault==null)return _certificationMthNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _certificationMthNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("CertificationMth length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _certificationMthNonDefault =null;//null value 
                }
                else
                {		           
		            _certificationMthNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LEVEL_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string LevelCode
		{
			get 
			{ 
                if(_levelCodeNonDefault==null)return _levelCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _levelCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("LevelCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _levelCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _levelCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_AIR_AMBULANCES" field.  
		/// </summary>
		public int? NoOfAirAmbulances
		{
			get 
			{ 
                return _noOfAirAmbulancesNonDefault;
			}
			set 
			{
            
                _noOfAirAmbulancesNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_GROUND_AMBULANCES" field.  
		/// </summary>
		public int? NoOfGroundAmbulances
		{
			get 
			{ 
                return _noOfGroundAmbulancesNonDefault;
			}
			set 
			{
            
                _noOfGroundAmbulancesNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_SPRINT_VEHICLES" field.  
		/// </summary>
		public int? NoOfSprintVehicles
		{
			get 
			{ 
                return _noOfSprintVehiclesNonDefault;
			}
			set 
			{
            
                _noOfSprintVehiclesNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_AMBULATORY_VEHICLES" field.  
		/// </summary>
		public int? NoOfAmbulatoryVehicles
		{
			get 
			{ 
                return _noOfAmbulatoryVehiclesNonDefault;
			}
			set 
			{
            
                _noOfAmbulatoryVehiclesNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_DAILY_CAPACITY_AMBULATORY_VEHICLE" field.  
		/// </summary>
		public int? TotalDailyCapacityAmbulatoryVehicle
		{
			get 
			{ 
                return _totalDailyCapacityAmbulatoryVehicleNonDefault;
			}
			set 
			{
            
                _totalDailyCapacityAmbulatoryVehicleNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_HANDICAPPED_VEHICLES" field.  
		/// </summary>
		public int? NoOfHandicappedVehicles
		{
			get 
			{ 
                return _noOfHandicappedVehiclesNonDefault;
			}
			set 
			{
            
                _noOfHandicappedVehiclesNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_DAILY_CAPACITY_HANDICAPPED_VEHICLE" field.  
		/// </summary>
		public int? TotalDailyCapacityHandicappedVehicle
		{
			get 
			{ 
                return _totalDailyCapacityHandicappedVehicleNonDefault;
			}
			set 
			{
            
                _totalDailyCapacityHandicappedVehicleNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUMBER_OF_BEDS" field.  
		/// </summary>
		public int? NumberOfBeds
		{
			get 
			{ 
                return _numberOfBedsNonDefault;
			}
			set 
			{
            
                _numberOfBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMOBILE_INSURANCE_COVERAGE_LIMIT" field.  
		/// </summary>
		public decimal? AutomobileInsuranceCoverageLimit
		{
			get 
			{ 
                return _automobileInsuranceCoverageLimitNonDefault;
			}
			set 
			{
            
                _automobileInsuranceCoverageLimitNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMOBILE_INSURANCE_CARRIER_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string AutomobileInsuranceCarrierCode
		{
			get 
			{ 
                if(_automobileInsuranceCarrierCodeNonDefault==null)return _automobileInsuranceCarrierCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _automobileInsuranceCarrierCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("AutomobileInsuranceCarrierCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _automobileInsuranceCarrierCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _automobileInsuranceCarrierCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMOBILE_INSURANCE_POLICY_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string AutomobileInsurancePolicyNum
		{
			get 
			{ 
                if(_automobileInsurancePolicyNumNonDefault==null)return _automobileInsurancePolicyNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _automobileInsurancePolicyNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("AutomobileInsurancePolicyNum length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _automobileInsurancePolicyNumNonDefault =null;//null value 
                }
                else
                {		           
		            _automobileInsurancePolicyNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMOBILE_INSURANCE_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? AutomobileInsuranceExpirationDate
		{
			get 
			{ 
                return _automobileInsuranceExpirationDateNonDefault;
			}
			set 
			{
            
                _automobileInsuranceExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "GENERAL_LIABILITY_COVERAGE_LIMIT" field.  
		/// </summary>
		public decimal? GeneralLiabilityCoverageLimit
		{
			get 
			{ 
                return _generalLiabilityCoverageLimitNonDefault;
			}
			set 
			{
            
                _generalLiabilityCoverageLimitNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "GENERAL_LIABILITY_CARRIER_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string GeneralLiabilityCarrierCode
		{
			get 
			{ 
                if(_generalLiabilityCarrierCodeNonDefault==null)return _generalLiabilityCarrierCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _generalLiabilityCarrierCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("GeneralLiabilityCarrierCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _generalLiabilityCarrierCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _generalLiabilityCarrierCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GENERAL_LIABILITY_POLICY_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string GeneralLiabilityPolicyNum
		{
			get 
			{ 
                if(_generalLiabilityPolicyNumNonDefault==null)return _generalLiabilityPolicyNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _generalLiabilityPolicyNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("GeneralLiabilityPolicyNum length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _generalLiabilityPolicyNumNonDefault =null;//null value 
                }
                else
                {		           
		            _generalLiabilityPolicyNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_WITHIN_FACILITY_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string FacilityWithinFacilityYN
		{
			get 
			{ 
                if(_facilityWithinFacilityYNNonDefault==null)return _facilityWithinFacilityYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _facilityWithinFacilityYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("FacilityWithinFacilityYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _facilityWithinFacilityYNNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityWithinFacilityYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GENERAL_LIABILITY_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? GeneralLiabilityExpirationDate
		{
			get 
			{ 
                return _generalLiabilityExpirationDateNonDefault;
			}
			set 
			{
            
                _generalLiabilityExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OTHER_BEDS" field.  
		/// </summary>
		public int? OtherBeds
		{
			get 
			{ 
                return _otherBedsNonDefault;
			}
			set 
			{
            
                _otherBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_MALPRACTICE_COVERAGE_LIMIT" field.  
		/// </summary>
		public decimal? MedicalMalpracticeCoverageLimit
		{
			get 
			{ 
                return _medicalMalpracticeCoverageLimitNonDefault;
			}
			set 
			{
            
                _medicalMalpracticeCoverageLimitNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "UNITS_NUM_TOTAL" field.  
		/// </summary>
		public int? UnitsNumTotal
		{
			get 
			{ 
                return _unitsNumTotalNonDefault;
			}
			set 
			{
            
                _unitsNumTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_MALPRACTICE_CARRIER_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string MedicalMalpracticeCarrierCode
		{
			get 
			{ 
                if(_medicalMalpracticeCarrierCodeNonDefault==null)return _medicalMalpracticeCarrierCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalMalpracticeCarrierCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("MedicalMalpracticeCarrierCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _medicalMalpracticeCarrierCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalMalpracticeCarrierCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_LIC_BEDS_TOTAL" field.  
		/// </summary>
		public int? TotalLicBedsTotal
		{
			get 
			{ 
                return _totalLicBedsTotalNonDefault;
			}
			set 
			{
            
                _totalLicBedsTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_MALPRACTICE_POLICY_NUM" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string MedicalMalpracticePolicyNum
		{
			get 
			{ 
                if(_medicalMalpracticePolicyNumNonDefault==null)return _medicalMalpracticePolicyNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicalMalpracticePolicyNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("MedicalMalpracticePolicyNum length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _medicalMalpracticePolicyNumNonDefault =null;//null value 
                }
                else
                {		           
		            _medicalMalpracticePolicyNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PSYCHIATRIC_BEDS_TOTAL" field.  
		/// </summary>
		public int? PsychiatricBedsTotal
		{
			get 
			{ 
                return _psychiatricBedsTotalNonDefault;
			}
			set 
			{
            
                _psychiatricBedsTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAL_MALPRACTICE_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? MedicalMalpracticeExpirationDate
		{
			get 
			{ 
                return _medicalMalpracticeExpirationDateNonDefault;
			}
			set 
			{
            
                _medicalMalpracticeExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ISOLATION_UNIT_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string IsolationUnitYN
		{
			get 
			{ 
                if(_isolationUnitYNNonDefault==null)return _isolationUnitYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _isolationUnitYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("IsolationUnitYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _isolationUnitYNNonDefault =null;//null value 
                }
                else
                {		           
		            _isolationUnitYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "REHABILITATION_BEDS_TOTAL" field.  
		/// </summary>
		public int? RehabilitationBedsTotal
		{
			get 
			{ 
                return _rehabilitationBedsTotalNonDefault;
			}
			set 
			{
            
                _rehabilitationBedsTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF_BEDS_TOTAL" field.  
		/// </summary>
		public int? SnfBedsTotal
		{
			get 
			{ 
                return _snfBedsTotalNonDefault;
			}
			set 
			{
            
                _snfBedsTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STATUS_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string StatusCode
		{
			get 
			{ 
                if(_statusCodeNonDefault==null)return _statusCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _statusCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("StatusCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _statusCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _statusCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "UNITS_NUM_OFFSITE_TOTAL" field.  
		/// </summary>
		public int? UnitsNumOffsiteTotal
		{
			get 
			{ 
                return _unitsNumOffsiteTotalNonDefault;
			}
			set 
			{
            
                _unitsNumOffsiteTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STATUS_DATE" field.  
		/// </summary>
		public DateTime? StatusDate
		{
			get 
			{ 
                return _statusDateNonDefault;
			}
			set 
			{
            
                _statusDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_LIC_BEDS_OFFSITE_TOTAL" field.  
		/// </summary>
		public int? TotalLicBedsOffsiteTotal
		{
			get 
			{ 
                return _totalLicBedsOffsiteTotalNonDefault;
			}
			set 
			{
            
                _totalLicBedsOffsiteTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_PARISHES_SERVED" field.  
		/// </summary>
		public int? NoOfParishesServed
		{
			get 
			{ 
                return _noOfParishesServedNonDefault;
			}
			set 
			{
            
                _noOfParishesServedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PSYCHIATRIC_BEDS_OFFSITE_TOTAL" field.  
		/// </summary>
		public int? PsychiatricBedsOffsiteTotal
		{
			get 
			{ 
                return _psychiatricBedsOffsiteTotalNonDefault;
			}
			set 
			{
            
                _psychiatricBedsOffsiteTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSURE_SURVEY_DATE" field.  
		/// </summary>
		public DateTime? LicensureSurveyDate
		{
			get 
			{ 
                return _licensureSurveyDateNonDefault;
			}
			set 
			{
            
                _licensureSurveyDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REHAB_BEDS_OFFSITE_TOTAL" field.  
		/// </summary>
		public int? RehabBedsOffsiteTotal
		{
			get 
			{ 
                return _rehabBedsOffsiteTotalNonDefault;
			}
			set 
			{
            
                _rehabBedsOffsiteTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVERS" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string Waivers
		{
			get 
			{ 
                if(_waiversNonDefault==null)return _waiversNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiversNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("Waivers length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _waiversNonDefault =null;//null value 
                }
                else
                {		           
		            _waiversNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SNF_BEDS_OFFSITE_TOTAL" field.  
		/// </summary>
		public int? SnfBedsOffsiteTotal
		{
			get 
			{ 
                return _snfBedsOffsiteTotalNonDefault;
			}
			set 
			{
            
                _snfBedsOffsiteTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OTHER_BEDS_OFFSITE_TOTAL" field.  
		/// </summary>
		public int? OtherBedsOffsiteTotal
		{
			get 
			{ 
                return _otherBedsOffsiteTotalNonDefault;
			}
			set 
			{
            
                _otherBedsOffsiteTotalNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PSYCH_PPS_FEDERAL_ID" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string PsychPpsFederalID
		{
			get 
			{ 
                if(_psychPpsFederalIDNonDefault==null)return _psychPpsFederalIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _psychPpsFederalIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("PsychPpsFederalID length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _psychPpsFederalIDNonDefault =null;//null value 
                }
                else
                {		           
		            _psychPpsFederalIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "REHAB_PPS_FEDERAL_ID" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string RehabPpsFederalID
		{
			get 
			{ 
                if(_rehabPpsFederalIDNonDefault==null)return _rehabPpsFederalIDNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _rehabPpsFederalIDNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("RehabPpsFederalID length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _rehabPpsFederalIDNonDefault =null;//null value 
                }
                else
                {		           
		            _rehabPpsFederalIDNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "USER_LAST_MAINT" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string UserLastMaint
		{
			get 
			{ 
                if(_userLastMaintNonDefault==null)return _userLastMaintNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _userLastMaintNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("UserLastMaint length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _userLastMaintNonDefault =null;//null value 
                }
                else
                {		           
		            _userLastMaintNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PSYCH_PPS_CERT_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? PsychPpsCertEffectiveDate
		{
			get 
			{ 
                return _psychPpsCertEffectiveDateNonDefault;
			}
			set 
			{
            
                _psychPpsCertEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "DATE_LAST_MAINT" field.  
		/// </summary>
		public DateTime? DateLastMaint
		{
			get 
			{ 
                return _dateLastMaintNonDefault;
			}
			set 
			{
            
                _dateLastMaintNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REHAB_PPS_CERT_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? RehabPpsCertEffectiveDate
		{
			get 
			{ 
                return _rehabPpsCertEffectiveDateNonDefault;
			}
			set 
			{
            
                _rehabPpsCertEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TIME_LAST_MAINT" field. Length must be between 0 and 9 characters. 
		/// </summary>
		public string TimeLastMaint
		{
			get 
			{ 
                if(_timeLastMaintNonDefault==null)return _timeLastMaintNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _timeLastMaintNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 9)
					throw new ArgumentException("TimeLastMaint length must be between 0 and 9 characters.");

				
                if(value ==null)
                {
                    _timeLastMaintNonDefault =null;//null value 
                }
                else
                {		           
		            _timeLastMaintNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OFFSITE_CAMPUS_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OffsiteCampusYN
		{
			get 
			{ 
                if(_offsiteCampusYNNonDefault==null)return _offsiteCampusYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _offsiteCampusYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OffsiteCampusYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _offsiteCampusYNNonDefault =null;//null value 
                }
                else
                {		           
		            _offsiteCampusYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CERTIFIED_BED_OVERRIDE_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string CertifiedBedOverrideYN
		{
			get 
			{ 
                if(_certifiedBedOverrideYNNonDefault==null)return _certifiedBedOverrideYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _certifiedBedOverrideYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("CertifiedBedOverrideYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _certifiedBedOverrideYNNonDefault =null;//null value 
                }
                else
                {		           
		            _certifiedBedOverrideYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAIN_CAMPUS_BEDS" field.  
		/// </summary>
		public int? MainCampusBeds
		{
			get 
			{ 
                return _mainCampusBedsNonDefault;
			}
			set 
			{
            
                _mainCampusBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FOR_YEAR_ENDING_DATE" field.  
		/// </summary>
		public DateTime? ForYearEndingDate
		{
			get 
			{ 
                return _forYearEndingDateNonDefault;
			}
			set 
			{
            
                _forYearEndingDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NEONATAL_INT_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string NeonatalIntCode
		{
			get 
			{ 
                if(_neonatalIntCodeNonDefault==null)return _neonatalIntCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _neonatalIntCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("NeonatalIntCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _neonatalIntCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _neonatalIntCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SERVICES_OFFERED" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string ServicesOffered
		{
			get 
			{ 
                if(_servicesOfferedNonDefault==null)return _servicesOfferedNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _servicesOfferedNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("ServicesOffered length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _servicesOfferedNonDefault =null;//null value 
                }
                else
                {		           
		            _servicesOfferedNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PICU_INT_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string PicuIntCode
		{
			get 
			{ 
                if(_picuIntCodeNonDefault==null)return _picuIntCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _picuIntCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("PicuIntCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _picuIntCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _picuIntCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HALFWAY_HOUSE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string HalfwayHouse
		{
			get 
			{ 
                if(_halfwayHouseNonDefault==null)return _halfwayHouseNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _halfwayHouseNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("HalfwayHouse length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _halfwayHouseNonDefault =null;//null value 
                }
                else
                {		           
		            _halfwayHouseNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DEEMED_STATUS" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string DeemedStatus
		{
			get 
			{ 
                if(_deemedStatusNonDefault==null)return _deemedStatusNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _deemedStatusNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("DeemedStatus length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _deemedStatusNonDefault =null;//null value 
                }
                else
                {		           
		            _deemedStatusNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "IN_PATIENT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string InPatient
		{
			get 
			{ 
                if(_inPatientNonDefault==null)return _inPatientNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _inPatientNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("InPatient length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _inPatientNonDefault =null;//null value 
                }
                else
                {		           
		            _inPatientNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHAP_ACCREDITION_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ChapAccreditionYN
		{
			get 
			{ 
                if(_chapAccreditionYNNonDefault==null)return _chapAccreditionYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _chapAccreditionYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ChapAccreditionYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _chapAccreditionYNNonDefault =null;//null value 
                }
                else
                {		           
		            _chapAccreditionYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CRISIS_EMERGENCY" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string CrisisEmergency
		{
			get 
			{ 
                if(_crisisEmergencyNonDefault==null)return _crisisEmergencyNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _crisisEmergencyNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("CrisisEmergency length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _crisisEmergencyNonDefault =null;//null value 
                }
                else
                {		           
		            _crisisEmergencyNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OUTPATIENT_TREATMENT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OutpatientTreatment
		{
			get 
			{ 
                if(_outpatientTreatmentNonDefault==null)return _outpatientTreatmentNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _outpatientTreatmentNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OutpatientTreatment length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _outpatientTreatmentNonDefault =null;//null value 
                }
                else
                {		           
		            _outpatientTreatmentNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FISCAL_INTERMEDIARY_NUM" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string FiscalIntermediaryNum
		{
			get 
			{ 
                if(_fiscalIntermediaryNumNonDefault==null)return _fiscalIntermediaryNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _fiscalIntermediaryNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("FiscalIntermediaryNum length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _fiscalIntermediaryNumNonDefault =null;//null value 
                }
                else
                {		           
		            _fiscalIntermediaryNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "METHADONE_TREATMENT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string MethadoneTreatment
		{
			get 
			{ 
                if(_methadoneTreatmentNonDefault==null)return _methadoneTreatmentNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _methadoneTreatmentNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("MethadoneTreatment length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _methadoneTreatmentNonDefault =null;//null value 
                }
                else
                {		           
		            _methadoneTreatmentNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTESESTATION_STATEMENT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string AttesestationStatement
		{
			get 
			{ 
                if(_attesestationStatementNonDefault==null)return _attesestationStatementNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _attesestationStatementNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("AttesestationStatement length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _attesestationStatementNonDefault =null;//null value 
                }
                else
                {		           
		            _attesestationStatementNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PREVENTION_EDUCATION" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string PreventionEducation
		{
			get 
			{ 
                if(_preventionEducationNonDefault==null)return _preventionEducationNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _preventionEducationNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("PreventionEducation length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _preventionEducationNonDefault =null;//null value 
                }
                else
                {		           
		            _preventionEducationNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ATTESESTATION_STMT_DATE_SIGNED" field.  
		/// </summary>
		public DateTime? AttesestationStmtDateSigned
		{
			get 
			{ 
                return _attesestationStmtDateSignedNonDefault;
			}
			set 
			{
            
                _attesestationStmtDateSignedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RESIDENTIAL_TREATMENT" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ResidentialTreatment
		{
			get 
			{ 
                if(_residentialTreatmentNonDefault==null)return _residentialTreatmentNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _residentialTreatmentNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ResidentialTreatment length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _residentialTreatmentNonDefault =null;//null value 
                }
                else
                {		           
		            _residentialTreatmentNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_CHANGE_PREV_NAME1" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string NameChangePrevName1
		{
			get 
			{ 
                if(_nameChangePrevName1NonDefault==null)return _nameChangePrevName1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameChangePrevName1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("NameChangePrevName1 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameChangePrevName1NonDefault =null;//null value 
                }
                else
                {		           
		            _nameChangePrevName1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SOCIAL_SETTING_DETOXIFICATION" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string SocialSettingDetoxification
		{
			get 
			{ 
                if(_socialSettingDetoxificationNonDefault==null)return _socialSettingDetoxificationNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _socialSettingDetoxificationNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("SocialSettingDetoxification length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _socialSettingDetoxificationNonDefault =null;//null value 
                }
                else
                {		           
		            _socialSettingDetoxificationNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_CHANGE_DATE1" field.  
		/// </summary>
		public DateTime? NameChangeDate1
		{
			get 
			{ 
                return _nameChangeDate1NonDefault;
			}
			set 
			{
            
                _nameChangeDate1NonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADULT_HEALTH_CARE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string AdultHealthCare
		{
			get 
			{ 
                if(_adultHealthCareNonDefault==null)return _adultHealthCareNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _adultHealthCareNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("AdultHealthCare length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _adultHealthCareNonDefault =null;//null value 
                }
                else
                {		           
		            _adultHealthCareNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_CHANGE_PREV_NAME2" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string NameChangePrevName2
		{
			get 
			{ 
                if(_nameChangePrevName2NonDefault==null)return _nameChangePrevName2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _nameChangePrevName2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("NameChangePrevName2 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _nameChangePrevName2NonDefault =null;//null value 
                }
                else
                {		           
		            _nameChangePrevName2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NAME_CHANGE_DATE2" field.  
		/// </summary>
		public DateTime? NameChangeDate2
		{
			get 
			{ 
                return _nameChangeDate2NonDefault;
			}
			set 
			{
            
                _nameChangeDate2NonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CNAT_TRAINING_CODE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string CnatTrainingCode
		{
			get 
			{ 
                if(_cnatTrainingCodeNonDefault==null)return _cnatTrainingCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _cnatTrainingCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("CnatTrainingCode length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _cnatTrainingCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _cnatTrainingCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CNAT_TRAINING_SUSPEND_DATE" field.  
		/// </summary>
		public DateTime? CnatTrainingSuspendDate
		{
			get 
			{ 
                return _cnatTrainingSuspendDateNonDefault;
			}
			set 
			{
            
                _cnatTrainingSuspendDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PREVIOUS_OWNER1" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string PreviousOwner1
		{
			get 
			{ 
                if(_previousOwner1NonDefault==null)return _previousOwner1NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _previousOwner1NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("PreviousOwner1 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _previousOwner1NonDefault =null;//null value 
                }
                else
                {		           
		            _previousOwner1NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PREV_OWNER_CHANGE_DATE1" field.  
		/// </summary>
		public DateTime? PrevOwnerChangeDate1
		{
			get 
			{ 
                return _prevOwnerChangeDate1NonDefault;
			}
			set 
			{
            
                _prevOwnerChangeDate1NonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ASSIST_DIR_OF_NURSING_WAIVER_MONTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string AssistDirOfNursingWaiverMonth
		{
			get 
			{ 
                if(_assistDirOfNursingWaiverMonthNonDefault==null)return _assistDirOfNursingWaiverMonthNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _assistDirOfNursingWaiverMonthNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("AssistDirOfNursingWaiverMonth length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _assistDirOfNursingWaiverMonthNonDefault =null;//null value 
                }
                else
                {		           
		            _assistDirOfNursingWaiverMonthNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DAY7_RN_WAIVER_MONTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string Day7RnWaiverMonth
		{
			get 
			{ 
                if(_day7RnWaiverMonthNonDefault==null)return _day7RnWaiverMonthNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _day7RnWaiverMonthNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("Day7RnWaiverMonth length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _day7RnWaiverMonthNonDefault =null;//null value 
                }
                else
                {		           
		            _day7RnWaiverMonthNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PREVIOUS_OWNER2" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string PreviousOwner2
		{
			get 
			{ 
                if(_previousOwner2NonDefault==null)return _previousOwner2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _previousOwner2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("PreviousOwner2 length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _previousOwner2NonDefault =null;//null value 
                }
                else
                {		           
		            _previousOwner2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PREV_OWNER_CHANGE_DATE2" field.  
		/// </summary>
		public DateTime? PrevOwnerChangeDate2
		{
			get 
			{ 
                return _prevOwnerChangeDate2NonDefault;
			}
			set 
			{
            
                _prevOwnerChangeDate2NonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CURRENT_SURVEY_MONTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string CurrentSurveyMonth
		{
			get 
			{ 
                if(_currentSurveyMonthNonDefault==null)return _currentSurveyMonthNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _currentSurveyMonthNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("CurrentSurveyMonth length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _currentSurveyMonthNonDefault =null;//null value 
                }
                else
                {		           
		            _currentSurveyMonthNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FISCAL_INTERMEDIARY_DESC" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string FiscalIntermediaryDesc
		{
			get 
			{ 
                if(_fiscalIntermediaryDescNonDefault==null)return _fiscalIntermediaryDescNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _fiscalIntermediaryDescNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("FiscalIntermediaryDesc length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _fiscalIntermediaryDescNonDefault =null;//null value 
                }
                else
                {		           
		            _fiscalIntermediaryDescNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICARE_INTER_PREF_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string MedicareInterPrefCode
		{
			get 
			{ 
                if(_medicareInterPrefCodeNonDefault==null)return _medicareInterPrefCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _medicareInterPrefCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("MedicareInterPrefCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _medicareInterPrefCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _medicareInterPrefCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROGRAM_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string ProgramCode
		{
			get 
			{ 
                if(_programCodeNonDefault==null)return _programCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _programCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _programCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_TREATMENTS_PER_WEEK" field.  
		/// </summary>
		public int? NoTreatmentsPerWeek
		{
			get 
			{ 
                return _noTreatmentsPerWeekNonDefault;
			}
			set 
			{
            
                _noTreatmentsPerWeekNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_STATIONS" field.  
		/// </summary>
		public int? NoOfStations
		{
			get 
			{ 
                return _noOfStationsNonDefault;
			}
			set 
			{
            
                _noOfStationsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "LEVEL_DESCRIPTION" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string LevelDescription
		{
			get 
			{ 
                if(_levelDescriptionNonDefault==null)return _levelDescriptionNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _levelDescriptionNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("LevelDescription length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _levelDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _levelDescriptionNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMATIC_CANCELLATION_DATE" field.  
		/// </summary>
		public DateTime? AutomaticCancellationDate
		{
			get 
			{ 
                return _automaticCancellationDateNonDefault;
			}
			set 
			{
            
                _automaticCancellationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_3HR_SHIFTS_WEEK" field.  
		/// </summary>
		public int? NoOf3hrShiftsWeek
		{
			get 
			{ 
                return _noOf3hrShiftsWeekNonDefault;
			}
			set 
			{
            
                _noOf3hrShiftsWeekNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FCERT_BEDS" field.  
		/// </summary>
		public int? FcertBeds
		{
			get 
			{ 
                return _fcertBedsNonDefault;
			}
			set 
			{
            
                _fcertBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AVERAGE_NUM_PATIENTS_SHIFT" field.  
		/// </summary>
		public int? AverageNumPatientsShift
		{
			get 
			{ 
                return _averageNumPatientsShiftNonDefault;
			}
			set 
			{
            
                _averageNumPatientsShiftNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMOBILE_INSURANCE_PREPAYMENT_DUE_DATE" field.  
		/// </summary>
		public DateTime? AutomobileInsurancePrepaymentDueDate
		{
			get 
			{ 
                return _automobileInsurancePrepaymentDueDateNonDefault;
			}
			set 
			{
            
                _automobileInsurancePrepaymentDueDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "VENDOR_NUM" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string VendorNum
		{
			get 
			{ 
                if(_vendorNumNonDefault==null)return _vendorNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _vendorNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("VendorNum length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _vendorNumNonDefault =null;//null value 
                }
                else
                {		           
		            _vendorNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GENERAL_LIABILITY_PREPAYMENT_DUE_DATE" field.  
		/// </summary>
		public DateTime? GeneralLiabilityPrepaymentDueDate
		{
			get 
			{ 
                return _generalLiabilityPrepaymentDueDateNonDefault;
			}
			set 
			{
            
                _generalLiabilityPrepaymentDueDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode
		{
			get 
			{ 
                if(_waiverCodeNonDefault==null)return _waiverCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE_2" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode2
		{
			get 
			{ 
                if(_waiverCode2NonDefault==null)return _waiverCode2NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCode2NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode2 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCode2NonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCode2NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OVERRIDE_CAPACITY" field.  
		/// </summary>
		public int? OverrideCapacity
		{
			get 
			{ 
                return _overrideCapacityNonDefault;
			}
			set 
			{
            
                _overrideCapacityNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RN_COORDINATOR" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string RnCoordinator
		{
			get 
			{ 
                if(_rnCoordinatorNonDefault==null)return _rnCoordinatorNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _rnCoordinatorNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("RnCoordinator length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _rnCoordinatorNonDefault =null;//null value 
                }
                else
                {		           
		            _rnCoordinatorNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE_3" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode3
		{
			get 
			{ 
                if(_waiverCode3NonDefault==null)return _waiverCode3NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCode3NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode3 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCode3NonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCode3NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE_4" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode4
		{
			get 
			{ 
                if(_waiverCode4NonDefault==null)return _waiverCode4NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCode4NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode4 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCode4NonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCode4NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DIRECTOR_NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string DirectorName
		{
			get 
			{ 
                if(_directorNameNonDefault==null)return _directorNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _directorNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("DirectorName length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _directorNameNonDefault =null;//null value 
                }
                else
                {		           
		            _directorNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE_5" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode5
		{
			get 
			{ 
                if(_waiverCode5NonDefault==null)return _waiverCode5NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCode5NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode5 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCode5NonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCode5NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "YEAR1_REVIEW_DATE_DUE" field.  
		/// </summary>
		public DateTime? Year1ReviewDateDue
		{
			get 
			{ 
                return _year1ReviewDateDueNonDefault;
			}
			set 
			{
            
                _year1ReviewDateDueNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE_6" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode6
		{
			get 
			{ 
                if(_waiverCode6NonDefault==null)return _waiverCode6NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCode6NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode6 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCode6NonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCode6NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "WAIVER_CODE_7" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string WaiverCode7
		{
			get 
			{ 
                if(_waiverCode7NonDefault==null)return _waiverCode7NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _waiverCode7NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("WaiverCode7 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _waiverCode7NonDefault =null;//null value 
                }
                else
                {		           
		            _waiverCode7NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "USAGE" field.  
		/// </summary>
		public int? Usage
		{
			get 
			{ 
                return _usageNonDefault;
			}
			set 
			{
            
                _usageNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_NUM_DIALYSIS_PATIENTS" field.  
		/// </summary>
		public int? TotalNumDialysisPatients
		{
			get 
			{ 
                return _totalNumDialysisPatientsNonDefault;
			}
			set 
			{
            
                _totalNumDialysisPatientsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ACCREDITATION_EXPIRATION_DATE" field.  
		/// </summary>
		public DateTime? AccreditationExpirationDate
		{
			get 
			{ 
                return _accreditationExpirationDateNonDefault;
			}
			set 
			{
            
                _accreditationExpirationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_NUM_PATIENTS" field.  
		/// </summary>
		public int? HemodialysisNumPatients
		{
			get 
			{ 
                return _hemodialysisNumPatientsNonDefault;
			}
			set 
			{
            
                _hemodialysisNumPatientsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_WITHIN_FACILITY" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string FacilityWithinFacility
		{
			get 
			{ 
                if(_facilityWithinFacilityNonDefault==null)return _facilityWithinFacilityNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _facilityWithinFacilityNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("FacilityWithinFacility length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _facilityWithinFacilityNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityWithinFacilityNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_OF_PERITONEAL_DIALYSIS_PATIENTS" field.  
		/// </summary>
		public int? NumOfPeritonealDialysisPatients
		{
			get 
			{ 
                return _numOfPeritonealDialysisPatientsNonDefault;
			}
			set 
			{
            
                _numOfPeritonealDialysisPatientsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FACILITY_TYPE_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string FacilityTypeCode
		{
			get 
			{ 
                if(_facilityTypeCodeNonDefault==null)return _facilityTypeCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _facilityTypeCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("FacilityTypeCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _facilityTypeCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityTypeCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_NUM_OF_STATIONS" field.  
		/// </summary>
		public int? HemodialysisNumOfStations
		{
			get 
			{ 
                return _hemodialysisNumOfStationsNonDefault;
			}
			set 
			{
            
                _hemodialysisNumOfStationsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TRANSPLANT_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string TransplantYN
		{
			get 
			{ 
                if(_transplantYNNonDefault==null)return _transplantYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _transplantYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("TransplantYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _transplantYNNonDefault =null;//null value 
                }
                else
                {		           
		            _transplantYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_TRAINING_NUM_OF_STATION" field.  
		/// </summary>
		public int? HemodialysisTrainingNumOfStation
		{
			get 
			{ 
                return _hemodialysisTrainingNumOfStationNonDefault;
			}
			set 
			{
            
                _hemodialysisTrainingNumOfStationNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "OB_INT_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string ObIntCode
		{
			get 
			{ 
                if(_obIntCodeNonDefault==null)return _obIntCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _obIntCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ObIntCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _obIntCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _obIntCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OB_CURRENT_SURVEY_DATE" field.  
		/// </summary>
		public DateTime? ObCurrentSurveyDate
		{
			get 
			{ 
                return _obCurrentSurveyDateNonDefault;
			}
			set 
			{
            
                _obCurrentSurveyDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_NUM_STATIONS" field.  
		/// </summary>
		public int? TotalNumStations
		{
			get 
			{ 
                return _totalNumStationsNonDefault;
			}
			set 
			{
            
                _totalNumStationsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REUSE_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ReuseYN
		{
			get 
			{ 
                if(_reuseYNNonDefault==null)return _reuseYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _reuseYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ReuseYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _reuseYNNonDefault =null;//null value 
                }
                else
                {		           
		            _reuseYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NICU_CURRENT_SURVEY_DATE" field.  
		/// </summary>
		public DateTime? NicuCurrentSurveyDate
		{
			get 
			{ 
                return _nicuCurrentSurveyDateNonDefault;
			}
			set 
			{
            
                _nicuCurrentSurveyDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MANUAL_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ManualYN
		{
			get 
			{ 
                if(_manualYNNonDefault==null)return _manualYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _manualYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ManualYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _manualYNNonDefault =null;//null value 
                }
                else
                {		           
		            _manualYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PICU_CURRENT_SURVEY_DATE" field.  
		/// </summary>
		public DateTime? PicuCurrentSurveyDate
		{
			get 
			{ 
                return _picuCurrentSurveyDateNonDefault;
			}
			set 
			{
            
                _picuCurrentSurveyDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_OF_PATIENTS_FOLLOWED_AT_HOME" field.  
		/// </summary>
		public int? NumOfPatientsFollowedAtHome
		{
			get 
			{ 
                return _numOfPatientsFollowedAtHomeNonDefault;
			}
			set 
			{
            
                _numOfPatientsFollowedAtHomeNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TRAUMA_LEVEL" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TraumaLevel
		{
			get 
			{ 
                if(_traumaLevelNonDefault==null)return _traumaLevelNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _traumaLevelNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TraumaLevel length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _traumaLevelNonDefault =null;//null value 
                }
                else
                {		           
		            _traumaLevelNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SEMIAUTOMATED_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string SemiautomatedYN
		{
			get 
			{ 
                if(_semiautomatedYNNonDefault==null)return _semiautomatedYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _semiautomatedYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("SemiautomatedYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _semiautomatedYNNonDefault =null;//null value 
                }
                else
                {		           
		            _semiautomatedYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AUTOMATED_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string AutomatedYN
		{
			get 
			{ 
                if(_automatedYNNonDefault==null)return _automatedYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _automatedYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("AutomatedYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _automatedYNNonDefault =null;//null value 
                }
                else
                {		           
		            _automatedYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FORMAIN_GERMICIDE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string FormainGermicide
		{
			get 
			{ 
                if(_formainGermicideNonDefault==null)return _formainGermicideNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _formainGermicideNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("FormainGermicide length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _formainGermicideNonDefault =null;//null value 
                }
                else
                {		           
		            _formainGermicideNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEAT_GERMICIDE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string HeatGermicide
		{
			get 
			{ 
                if(_heatGermicideNonDefault==null)return _heatGermicideNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _heatGermicideNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("HeatGermicide length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _heatGermicideNonDefault =null;//null value 
                }
                else
                {		           
		            _heatGermicideNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "GLUTERALDETYDE_GERMICIDE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string GluteraldetydeGermicide
		{
			get 
			{ 
                if(_gluteraldetydeGermicideNonDefault==null)return _gluteraldetydeGermicideNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _gluteraldetydeGermicideNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("GluteraldetydeGermicide length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _gluteraldetydeGermicideNonDefault =null;//null value 
                }
                else
                {		           
		            _gluteraldetydeGermicideNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PERACETIC_ACID_MIXTURE_GERM" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string PeraceticAcidMixtureGerm
		{
			get 
			{ 
                if(_peraceticAcidMixtureGermNonDefault==null)return _peraceticAcidMixtureGermNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _peraceticAcidMixtureGermNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("PeraceticAcidMixtureGerm length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _peraceticAcidMixtureGermNonDefault =null;//null value 
                }
                else
                {		           
		            _peraceticAcidMixtureGermNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OTHER_GERMICIDE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OtherGermicide
		{
			get 
			{ 
                if(_otherGermicideNonDefault==null)return _otherGermicideNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _otherGermicideNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OtherGermicide length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _otherGermicideNonDefault =null;//null value 
                }
                else
                {		           
		            _otherGermicideNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ENROLLED_RHC_OFFSITE_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string EnrolledRhcOffsiteYN
		{
			get 
			{ 
                if(_enrolledRhcOffsiteYNNonDefault==null)return _enrolledRhcOffsiteYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _enrolledRhcOffsiteYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("EnrolledRhcOffsiteYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _enrolledRhcOffsiteYNNonDefault =null;//null value 
                }
                else
                {		           
		            _enrolledRhcOffsiteYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_GERMICIDE_DESCRIPTION" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string TypeGermicideDescription
		{
			get 
			{ 
                if(_typeGermicideDescriptionNonDefault==null)return _typeGermicideDescriptionNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeGermicideDescriptionNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("TypeGermicideDescription length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _typeGermicideDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _typeGermicideDescriptionNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_SERVICE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string HemodialysisService
		{
			get 
			{ 
                if(_hemodialysisServiceNonDefault==null)return _hemodialysisServiceNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _hemodialysisServiceNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("HemodialysisService length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _hemodialysisServiceNonDefault =null;//null value 
                }
                else
                {		           
		            _hemodialysisServiceNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DIRECTOR_OF_NURSING_FIRST_NAME" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string DirectorOfNursingFirstName
		{
			get 
			{ 
                if(_directorOfNursingFirstNameNonDefault==null)return _directorOfNursingFirstNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _directorOfNursingFirstNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("DirectorOfNursingFirstName length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _directorOfNursingFirstNameNonDefault =null;//null value 
                }
                else
                {		           
		            _directorOfNursingFirstNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PERITONEAL_DIALYSIS_SERVICE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string PeritonealDialysisService
		{
			get 
			{ 
                if(_peritonealDialysisServiceNonDefault==null)return _peritonealDialysisServiceNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _peritonealDialysisServiceNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("PeritonealDialysisService length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _peritonealDialysisServiceNonDefault =null;//null value 
                }
                else
                {		           
		            _peritonealDialysisServiceNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DIRECTOR_OF_NURSING_LAST_NAME" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string DirectorOfNursingLastName
		{
			get 
			{ 
                if(_directorOfNursingLastNameNonDefault==null)return _directorOfNursingLastNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _directorOfNursingLastNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("DirectorOfNursingLastName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _directorOfNursingLastNameNonDefault =null;//null value 
                }
                else
                {		           
		            _directorOfNursingLastNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PRESIDENT_FIRST_NAME" field. Length must be between 0 and 15 characters. 
		/// </summary>
		public string PresidentFirstName
		{
			get 
			{ 
                if(_presidentFirstNameNonDefault==null)return _presidentFirstNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _presidentFirstNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 15)
					throw new ArgumentException("PresidentFirstName length must be between 0 and 15 characters.");

				
                if(value ==null)
                {
                    _presidentFirstNameNonDefault =null;//null value 
                }
                else
                {		           
		            _presidentFirstNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TRANSPLANATION_SERVICE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string TransplanationService
		{
			get 
			{ 
                if(_transplanationServiceNonDefault==null)return _transplanationServiceNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _transplanationServiceNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("TransplanationService length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _transplanationServiceNonDefault =null;//null value 
                }
                else
                {		           
		            _transplanationServiceNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PRESIDENT_LAST_NAME" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string PresidentLastName
		{
			get 
			{ 
                if(_presidentLastNameNonDefault==null)return _presidentLastNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _presidentLastNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("PresidentLastName length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _presidentLastNameNonDefault =null;//null value 
                }
                else
                {		           
		            _presidentLastNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HOME_TRAINING_SERVICE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string HomeTrainingService
		{
			get 
			{ 
                if(_homeTrainingServiceNonDefault==null)return _homeTrainingServiceNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _homeTrainingServiceNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("HomeTrainingService length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _homeTrainingServiceNonDefault =null;//null value 
                }
                else
                {		           
		            _homeTrainingServiceNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFFING_FTE_RN" field.  
		/// </summary>
		public int? StaffingFteRN
		{
			get 
			{ 
                return _staffingFteRNNonDefault;
			}
			set 
			{
            
                _staffingFteRNNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFFING_FTE_LPN" field.  
		/// </summary>
		public int? StaffingFteLpn
		{
			get 
			{ 
                return _staffingFteLpnNonDefault;
			}
			set 
			{
            
                _staffingFteLpnNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFFING_FTE_SW" field.  
		/// </summary>
		public int? StaffingFteSW
		{
			get 
			{ 
                return _staffingFteSWNonDefault;
			}
			set 
			{
            
                _staffingFteSWNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFFING_FTE_TECHNICIANS" field.  
		/// </summary>
		public int? StaffingFteTechnicians
		{
			get 
			{ 
                return _staffingFteTechniciansNonDefault;
			}
			set 
			{
            
                _staffingFteTechniciansNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFFING_FTE_DIETIAN" field.  
		/// </summary>
		public int? StaffingFteDietian
		{
			get 
			{ 
                return _staffingFteDietianNonDefault;
			}
			set 
			{
            
                _staffingFteDietianNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "STAFFING_FTE_OTHERS" field.  
		/// </summary>
		public int? StaffingFteOthers
		{
			get 
			{ 
                return _staffingFteOthersNonDefault;
			}
			set 
			{
            
                _staffingFteOthersNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "INITIAL" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Initial
		{
			get 
			{ 
                if(_initialNonDefault==null)return _initialNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _initialNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Initial length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _initialNonDefault =null;//null value 
                }
                else
                {		           
		            _initialNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "INITIAL_DATE" field.  
		/// </summary>
		public DateTime? InitialDate
		{
			get 
			{ 
                return _initialDateNonDefault;
			}
			set 
			{
            
                _initialDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "EXPANSION_TO_NEW_LOCATION" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ExpansionToNewLocation
		{
			get 
			{ 
                if(_expansionToNewLocationNonDefault==null)return _expansionToNewLocationNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _expansionToNewLocationNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ExpansionToNewLocation length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _expansionToNewLocationNonDefault =null;//null value 
                }
                else
                {		           
		            _expansionToNewLocationNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EXP_TO_NEW_LOCATION_DATE" field.  
		/// </summary>
		public DateTime? ExpToNewLocationDate
		{
			get 
			{ 
                return _expToNewLocationDateNonDefault;
			}
			set 
			{
            
                _expToNewLocationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_OF_OWNERSHIP" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ChangeOfOwnership
		{
			get 
			{ 
                if(_changeOfOwnershipNonDefault==null)return _changeOfOwnershipNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _changeOfOwnershipNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ChangeOfOwnership length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _changeOfOwnershipNonDefault =null;//null value 
                }
                else
                {		           
		            _changeOfOwnershipNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_OF_LOCATION" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ChangeOfLocation
		{
			get 
			{ 
                if(_changeOfLocationNonDefault==null)return _changeOfLocationNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _changeOfLocationNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ChangeOfLocation length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _changeOfLocationNonDefault =null;//null value 
                }
                else
                {		           
		            _changeOfLocationNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_OF_LOCATION_DATE" field.  
		/// </summary>
		public DateTime? ChangeOfLocationDate
		{
			get 
			{ 
                return _changeOfLocationDateNonDefault;
			}
			set 
			{
            
                _changeOfLocationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "EXPANSION_IN_CURRENT_LOCATION" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ExpansionInCurrentLocation
		{
			get 
			{ 
                if(_expansionInCurrentLocationNonDefault==null)return _expansionInCurrentLocationNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _expansionInCurrentLocationNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ExpansionInCurrentLocation length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _expansionInCurrentLocationNonDefault =null;//null value 
                }
                else
                {		           
		            _expansionInCurrentLocationNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EXPANSION_IN_CURRENT_LOCATION_DATE" field.  
		/// </summary>
		public DateTime? ExpansionInCurrentLocationDate
		{
			get 
			{ 
                return _expansionInCurrentLocationDateNonDefault;
			}
			set 
			{
            
                _expansionInCurrentLocationDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_OF_SERVICES" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ChangeOfServices
		{
			get 
			{ 
                if(_changeOfServicesNonDefault==null)return _changeOfServicesNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _changeOfServicesNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ChangeOfServices length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _changeOfServicesNonDefault =null;//null value 
                }
                else
                {		           
		            _changeOfServicesNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_OF_SERVICES_DATE" field.  
		/// </summary>
		public DateTime? ChangeOfServicesDate
		{
			get 
			{ 
                return _changeOfServicesDateNonDefault;
			}
			set 
			{
            
                _changeOfServicesDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_APPLICATION_CODE7" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeApplicationCode7
		{
			get 
			{ 
                if(_typeApplicationCode7NonDefault==null)return _typeApplicationCode7NonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeApplicationCode7NonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeApplicationCode7 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeApplicationCode7NonDefault =null;//null value 
                }
                else
                {		           
		            _typeApplicationCode7NonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_APPLICATION_CODE7_DATE" field.  
		/// </summary>
		public DateTime? TypeApplicationCode7Date
		{
			get 
			{ 
                return _typeApplicationCode7DateNonDefault;
			}
			set 
			{
            
                _typeApplicationCode7DateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_APPLICATION_DESCR" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string TypeApplicationDescr
		{
			get 
			{ 
                if(_typeApplicationDescrNonDefault==null)return _typeApplicationDescrNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeApplicationDescrNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("TypeApplicationDescr length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _typeApplicationDescrNonDefault =null;//null value 
                }
                else
                {		           
		            _typeApplicationDescrNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROVIDER_BASED_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ProviderBasedYN
		{
			get 
			{ 
                if(_providerBasedYNNonDefault==null)return _providerBasedYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _providerBasedYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ProviderBasedYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _providerBasedYNNonDefault =null;//null value 
                }
                else
                {		           
		            _providerBasedYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MID_LEVEL_WAIVER_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string MidLevelWaiverYN
		{
			get 
			{ 
                if(_midLevelWaiverYNNonDefault==null)return _midLevelWaiverYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _midLevelWaiverYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("MidLevelWaiverYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _midLevelWaiverYNNonDefault =null;//null value 
                }
                else
                {		           
		            _midLevelWaiverYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MID_LEVEL_WAIVER_MONTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string MidLevelWaiverMonth
		{
			get 
			{ 
                if(_midLevelWaiverMonthNonDefault==null)return _midLevelWaiverMonthNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _midLevelWaiverMonthNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("MidLevelWaiverMonth length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _midLevelWaiverMonthNonDefault =null;//null value 
                }
                else
                {		           
		            _midLevelWaiverMonthNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MID_LEVEL_WAIVER_DATE" field.  
		/// </summary>
		public DateTime? MidLevelWaiverDate
		{
			get 
			{ 
                return _midLevelWaiverDateNonDefault;
			}
			set 
			{
            
                _midLevelWaiverDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "RELATED_PROVIDER_LICENSURE_NUM" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string RelatedProviderLicensureNum
		{
			get 
			{ 
                if(_relatedProviderLicensureNumNonDefault==null)return _relatedProviderLicensureNumNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _relatedProviderLicensureNumNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("RelatedProviderLicensureNum length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _relatedProviderLicensureNumNonDefault =null;//null value 
                }
                else
                {		           
		            _relatedProviderLicensureNumNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMERGENCY_PREP_REPORT_REQUIRED" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string EmergencyPrepReportRequired
		{
			get 
			{ 
                if(_emergencyPrepReportRequiredNonDefault==null)return _emergencyPrepReportRequiredNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _emergencyPrepReportRequiredNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("EmergencyPrepReportRequired length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _emergencyPrepReportRequiredNonDefault =null;//null value 
                }
                else
                {		           
		            _emergencyPrepReportRequiredNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ACCREDITED_BODY" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string AccreditedBody
		{
			get 
			{ 
                if(_accreditedBodyNonDefault==null)return _accreditedBodyNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _accreditedBodyNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("AccreditedBody length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _accreditedBodyNonDefault =null;//null value 
                }
                else
                {		           
		            _accreditedBodyNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ENROLLED_IN_MEDICAID_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string EnrolledInMedicaidYN
		{
			get 
			{ 
                if(_enrolledInMedicaidYNNonDefault==null)return _enrolledInMedicaidYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _enrolledInMedicaidYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("EnrolledInMedicaidYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _enrolledInMedicaidYNNonDefault =null;//null value 
                }
                else
                {		           
		            _enrolledInMedicaidYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_TREATMENT" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string TypeTreatment
		{
			get 
			{ 
                if(_typeTreatmentNonDefault==null)return _typeTreatmentNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _typeTreatmentNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("TypeTreatment length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _typeTreatmentNonDefault =null;//null value 
                }
                else
                {		           
		            _typeTreatmentNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSED_BY_OTHER" field. Length must be between 0 and 1 characters. Mandatory.
		/// </summary>
		public string LicensedByOther
		{
			get 
			{ 
                if(_licensedByOtherNonDefault==null)return _licensedByOtherNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _licensedByOtherNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1)
					throw new ArgumentException("LicensedByOther length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licensedByOtherNonDefault =null;//null value 
                }
                else
                {		           
		            _licensedByOtherNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LICENSURE_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? LicensureEffectiveDate
		{
			get 
			{ 
                return _licensureEffectiveDateNonDefault;
			}
			set 
			{
            
                _licensureEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_ACTIVE_PATIENTS" field.  
		/// </summary>
		public int? NumActivePatients
		{
			get 
			{ 
                return _numActivePatientsNonDefault;
			}
			set 
			{
            
                _numActivePatientsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_RADIOLOGIC_TECH_BSBA" field.  
		/// </summary>
		public int? NumRadiologicTechBsba
		{
			get 
			{ 
                return _numRadiologicTechBsbaNonDefault;
			}
			set 
			{
            
                _numRadiologicTechBsbaNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_RADIOLOGIC_TECH_AS" field.  
		/// </summary>
		public int? NumRadiologicTechAS
		{
			get 
			{ 
                return _numRadiologicTechASNonDefault;
			}
			set 
			{
            
                _numRadiologicTechASNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_RADIOLOGIC_TECH_CRT" field.  
		/// </summary>
		public int? NumRadiologicTechCrt
		{
			get 
			{ 
                return _numRadiologicTechCrtNonDefault;
			}
			set 
			{
            
                _numRadiologicTechCrtNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_RADIOLOGIC_TECH_OTHER" field.  
		/// </summary>
		public int? NumRadiologicTechOther
		{
			get 
			{ 
                return _numRadiologicTechOtherNonDefault;
			}
			set 
			{
            
                _numRadiologicTechOtherNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ISOLATION_NUM_OF_STATIONS" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string IsolationNumOfStations
		{
			get 
			{ 
                if(_isolationNumOfStationsNonDefault==null)return _isolationNumOfStationsNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _isolationNumOfStationsNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("IsolationNumOfStations length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _isolationNumOfStationsNonDefault =null;//null value 
                }
                else
                {		           
		            _isolationNumOfStationsNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "RELATED_PROVIDER_NAME" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string RelatedProviderName
		{
			get 
			{ 
                if(_relatedProviderNameNonDefault==null)return _relatedProviderNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _relatedProviderNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("RelatedProviderName length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _relatedProviderNameNonDefault =null;//null value 
                }
                else
                {		           
		            _relatedProviderNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_OPERATING_ROOMS" field.  
		/// </summary>
		public int? NumOperatingRooms
		{
			get 
			{ 
                return _numOperatingRoomsNonDefault;
			}
			set 
			{
            
                _numOperatingRoomsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ADM_MULTI_FAC_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string AdmMultiFacYN
		{
			get 
			{ 
                if(_admMultiFacYNNonDefault==null)return _admMultiFacYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _admMultiFacYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("AdmMultiFacYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _admMultiFacYNNonDefault =null;//null value 
                }
                else
                {		           
		            _admMultiFacYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ADM_MULTI_FAC_OTHER_NAME" field. Length must be between 0 and 60 characters. 
		/// </summary>
		public string AdmMultiFacOtherName
		{
			get 
			{ 
                if(_admMultiFacOtherNameNonDefault==null)return _admMultiFacOtherNameNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _admMultiFacOtherNameNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 60)
					throw new ArgumentException("AdmMultiFacOtherName length must be between 0 and 60 characters.");

				
                if(value ==null)
                {
                    _admMultiFacOtherNameNonDefault =null;//null value 
                }
                else
                {		           
		            _admMultiFacOtherNameNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SINGLE_STORY_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string SingleStoryYN
		{
			get 
			{ 
                if(_singleStoryYNNonDefault==null)return _singleStoryYNNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _singleStoryYNNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("SingleStoryYN length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _singleStoryYNNonDefault =null;//null value 
                }
                else
                {		           
		            _singleStoryYNNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CLOSED_DATE" field.  
		/// </summary>
		public DateTime? ClosedDate
		{
			get 
			{ 
                return _closedDateNonDefault;
			}
			set 
			{
            
                _closedDateNonDefault = value; 
			}
		}

        /// <summary>
        /// This property is mapped to the "YEAR2_REVIEW_DATE_DUE" field.  
        /// </summary>
        public DateTime? Year2ReviewDateDue
        {
            get
            {
                return _year2ReviewDateDueNonDefault;
            }
            set
            {

                _year2ReviewDateDueNonDefault = value;
            }
        }

		/// <summary>
		/// Provides access to the related table 'ADDRESS'
		/// </summary>
		public BO_Addresses BO_AddressesPopsIntID
		{
			get 
			{
                if (_bO_AddressesPopsIntID == null)
                {
                    _bO_AddressesPopsIntID = new BO_Addresses();
                    _bO_AddressesPopsIntID = BO_Address.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_AddressesPopsIntID; 
			}
			set 
			{
				  _bO_AddressesPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'AFFILIATION'
		/// </summary>
		public BO_Affiliations BO_AffiliationsPopsIntID
		{
			get 
			{
                if (_bO_AffiliationsPopsIntID == null)
                {
                    _bO_AffiliationsPopsIntID = new BO_Affiliations();
                    _bO_AffiliationsPopsIntID = BO_Affiliation.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_AffiliationsPopsIntID; 
			}
			set 
			{
				  _bO_AffiliationsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'APPLICATIONS'
		/// </summary>
		public BO_Applications BO_ApplicationsPopsIntID
		{
			get 
			{
                if (_bO_ApplicationsPopsIntID == null)
                {
                    _bO_ApplicationsPopsIntID = new BO_Applications();
                    _bO_ApplicationsPopsIntID = BO_Application.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_ApplicationsPopsIntID; 
			}
			set 
			{
				  _bO_ApplicationsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'BILLING'
		/// </summary>
		public BO_Billings BO_BillingsPopsIntID
		{
			get 
			{
                if (_bO_BillingsPopsIntID == null)
                {
                    _bO_BillingsPopsIntID = new BO_Billings();
                    _bO_BillingsPopsIntID = BO_Billing.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_BillingsPopsIntID; 
			}
			set 
			{
				  _bO_BillingsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'CAPACITIES'
		/// </summary>
		public BO_Capacities BO_CapacitiesPopsIntID
		{
			get 
			{
                if (_bO_CapacitiesPopsIntID == null)
                {
                    _bO_CapacitiesPopsIntID = new BO_Capacities();
                    _bO_CapacitiesPopsIntID = BO_Capacity.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_CapacitiesPopsIntID; 
			}
			set 
			{
				  _bO_CapacitiesPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'COMMENTS'
		/// </summary>
		public BO_Comments BO_CommentsPopsIntID
		{
			get 
			{
                if (_bO_CommentsPopsIntID == null)
                {
                    _bO_CommentsPopsIntID = new BO_Comments();
                    _bO_CommentsPopsIntID = BO_Comment.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_CommentsPopsIntID; 
			}
			set 
			{
				  _bO_CommentsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'INSURANCE_COVERAGE'
		/// </summary>
		public BO_InsuranceCoverages BO_InsuranceCoveragesPopsIntID
		{
			get 
			{
                if (_bO_InsuranceCoveragesPopsIntID == null)
                {
                    _bO_InsuranceCoveragesPopsIntID = new BO_InsuranceCoverages();
                    _bO_InsuranceCoveragesPopsIntID = BO_InsuranceCoverage.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_InsuranceCoveragesPopsIntID; 
			}
			set 
			{
				  _bO_InsuranceCoveragesPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LETTER_OF_INTENT'
		/// </summary>
		public BO_LetterOfIntents BO_LetterOfIntentsPopsIntID
		{
			get 
			{
                if (_bO_LetterOfIntentsPopsIntID == null)
                {
                    _bO_LetterOfIntentsPopsIntID = new BO_LetterOfIntents();
                    _bO_LetterOfIntentsPopsIntID = BO_LetterOfIntent.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_LetterOfIntentsPopsIntID; 
			}
			set 
			{
				  _bO_LetterOfIntentsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LICENSE'
		/// </summary>
		public BO_Licenses BO_LicensesPopsIntID
		{
			get 
			{
                if (_bO_LicensesPopsIntID == null)
                {
                    _bO_LicensesPopsIntID = new BO_Licenses();
                    _bO_LicensesPopsIntID = BO_License.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_LicensesPopsIntID; 
			}
			set 
			{
				  _bO_LicensesPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'MESSAGES'
		/// </summary>
		public BO_Messages BO_MessagesPopsIntID
		{
			get 
			{
                if (_bO_MessagesPopsIntID == null)
                {
                    _bO_MessagesPopsIntID = new BO_Messages();
                    _bO_MessagesPopsIntID = BO_Message.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_MessagesPopsIntID; 
			}
			set 
			{
				  _bO_MessagesPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'OWNERSHIP'
		/// </summary>
		public BO_Ownerships BO_OwnershipsPopsIntID
		{
			get 
			{
                if (_bO_OwnershipsPopsIntID == null)
                {
                    _bO_OwnershipsPopsIntID = new BO_Ownerships();
                    _bO_OwnershipsPopsIntID = BO_Ownership.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_OwnershipsPopsIntID; 
			}
			set 
			{
				  _bO_OwnershipsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PARISH_SERVED'
		/// </summary>
		public BO_ParishServeds BO_ParishServedsPopsIntID
		{
			get 
			{
                if (_bO_ParishServedsPopsIntID == null)
                {
                    _bO_ParishServedsPopsIntID = new BO_ParishServeds();
                    _bO_ParishServedsPopsIntID = BO_ParishServed.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_ParishServedsPopsIntID; 
			}
			set 
			{
				  _bO_ParishServedsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROVIDER_PERSON'
		/// </summary>
		public BO_ProviderPeople BO_ProviderPeoplePopsIntID
		{
			get 
			{
                if (_bO_ProviderPeoplePopsIntID == null)
                {
                    _bO_ProviderPeoplePopsIntID = new BO_ProviderPeople();
                    _bO_ProviderPeoplePopsIntID = BO_ProviderPerson.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_ProviderPeoplePopsIntID; 
			}
			set 
			{
				  _bO_ProviderPeoplePopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROVIDER_LOGIN'
		/// </summary>
		public BO_ProviderLogins BO_ProviderLoginsPopsIntID
		{
			get 
			{
                if (_bO_ProviderLoginsPopsIntID == null)
                {
                    _bO_ProviderLoginsPopsIntID = new BO_ProviderLogins();
                    _bO_ProviderLoginsPopsIntID = BO_ProviderLogin.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_ProviderLoginsPopsIntID; 
			}
			set 
			{
				  _bO_ProviderLoginsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SERVICE'
		/// </summary>
		public BO_Services BO_ServicesPopsIntID
		{
			get 
			{
                if (_bO_ServicesPopsIntID == null)
                {
                    _bO_ServicesPopsIntID = new BO_Services();
                    _bO_ServicesPopsIntID = BO_Service.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_ServicesPopsIntID; 
			}
			set 
			{
				  _bO_ServicesPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SPECIALTY_UNIT'
		/// </summary>
		public BO_SpecialtyUnits BO_SpecialtyUnitsPopsIntID
		{
			get 
			{
                if (_bO_SpecialtyUnitsPopsIntID == null)
                {
                    _bO_SpecialtyUnitsPopsIntID = new BO_SpecialtyUnits();
                    _bO_SpecialtyUnitsPopsIntID = BO_SpecialtyUnit.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_SpecialtyUnitsPopsIntID; 
			}
			set 
			{
				  _bO_SpecialtyUnitsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'STAFFING'
		/// </summary>
		public BO_Staffings BO_StaffingsPopsIntID
		{
			get 
			{
                if (_bO_StaffingsPopsIntID == null)
                {
                    _bO_StaffingsPopsIntID = new BO_Staffings();
                    _bO_StaffingsPopsIntID = BO_Staffing.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_StaffingsPopsIntID; 
			}
			set 
			{
				  _bO_StaffingsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SUBSTATION'
		/// </summary>
		public BO_Substations BO_SubstationsPopsIntID
		{
			get 
			{
                if (_bO_SubstationsPopsIntID == null)
                {
                    _bO_SubstationsPopsIntID = new BO_Substations();
                    _bO_SubstationsPopsIntID = BO_Substation.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_SubstationsPopsIntID; 
			}
			set 
			{
				  _bO_SubstationsPopsIntID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'VEHICLE'
		/// </summary>
		public BO_Vehicles BO_VehiclesPopsIntID
		{
			get 
			{
                if (_bO_VehiclesPopsIntID == null)
                {
                    _bO_VehiclesPopsIntID = new BO_Vehicles();
                    _bO_VehiclesPopsIntID = BO_Vehicle.SelectByField("POPS_INT_ID",PopsIntID);
                }                
				return _bO_VehiclesPopsIntID; 
			}
			set 
			{
				  _bO_VehiclesPopsIntID = value;
			}
		}

		#endregion
		
		#region Methods (Public)

		/// <summary>
		/// This method will insert one new row into the database using the property Information
		/// </summary>
        /// <param name="getBackValues" type="bool">Whether to get the default values inserted, from the database</param>
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
              
			// Pass the value of '_aspenIntID' as parameter 'AspenIntID' of the stored procedure.
			if(_aspenIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AspenIntID", _aspenIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AspenIntID", DBNull.Value );
              
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
              
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
              
			// Pass the value of '_programStaffID' as parameter 'ProgramStaffID' of the stored procedure.
			if(_programStaffIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramStaffID", _programStaffIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramStaffID", DBNull.Value );
              
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
              
			// Pass the value of '_regionCode' as parameter 'RegionCode' of the stored procedure.
			if(_regionCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@RegionCode", _regionCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@RegionCode", DBNull.Value );
              
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			if(_federalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@FederalID", DBNull.Value );
              
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			if(_licensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureNum", DBNull.Value );
              
			// Pass the value of '_geographicalStreetAddr2' as parameter 'GeographicalStreetAddr2' of the stored procedure.
			if(_geographicalStreetAddr2NonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalStreetAddr2", _geographicalStreetAddr2NonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalStreetAddr2", DBNull.Value );
              
			// Pass the value of '_schoolID' as parameter 'SchoolID' of the stored procedure.
			if(_schoolIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@SchoolID", _schoolIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@SchoolID", DBNull.Value );
              
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			if(_facilityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityName", DBNull.Value );
              
			// Pass the value of '_legalName' as parameter 'LegalName' of the stored procedure.
			if(_legalNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LegalName", _legalNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LegalName", DBNull.Value );
              
			// Pass the value of '_mailStreet2' as parameter 'MailStreet2' of the stored procedure.
			if(_mailStreet2NonDefault!=null)
              oDatabaseHelper.AddParameter("@MailStreet2", _mailStreet2NonDefault);
            else
              oDatabaseHelper.AddParameter("@MailStreet2", DBNull.Value );
              
			// Pass the value of '_geographicalStreet' as parameter 'GeographicalStreet' of the stored procedure.
			if(_geographicalStreetNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalStreet", _geographicalStreetNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalStreet", DBNull.Value );
              
			// Pass the value of '_geographicalCity' as parameter 'GeographicalCity' of the stored procedure.
			if(_geographicalCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalCity", _geographicalCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalCity", DBNull.Value );
              
			// Pass the value of '_geographicalZip' as parameter 'GeographicalZip' of the stored procedure.
			if(_geographicalZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalZip", _geographicalZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalZip", DBNull.Value );
              
			// Pass the value of '_geographicalState' as parameter 'GeographicalState' of the stored procedure.
			if(_geographicalStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalState", _geographicalStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalState", DBNull.Value );
              
			// Pass the value of '_mailStreet' as parameter 'MailStreet' of the stored procedure.
			if(_mailStreetNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailStreet", _mailStreetNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailStreet", DBNull.Value );
              
			// Pass the value of '_mailCity' as parameter 'MailCity' of the stored procedure.
			if(_mailCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailCity", _mailCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailCity", DBNull.Value );
              
			// Pass the value of '_mailState' as parameter 'MailState' of the stored procedure.
			if(_mailStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailState", _mailStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailState", DBNull.Value );
              
			// Pass the value of '_mailZip' as parameter 'MailZip' of the stored procedure.
			if(_mailZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailZip", _mailZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailZip", DBNull.Value );
              
			// Pass the value of '_emsParishCode' as parameter 'EmsParishCode' of the stored procedure.
			if(_emsParishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmsParishCode", _emsParishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmsParishCode", DBNull.Value );
              
			// Pass the value of '_parish' as parameter 'Parish' of the stored procedure.
			if(_parishNonDefault!=null)
              oDatabaseHelper.AddParameter("@Parish", _parishNonDefault);
            else
              oDatabaseHelper.AddParameter("@Parish", DBNull.Value );
              
			// Pass the value of '_regionalOffice' as parameter 'RegionalOffice' of the stored procedure.
			if(_regionalOfficeNonDefault!=null)
              oDatabaseHelper.AddParameter("@RegionalOffice", _regionalOfficeNonDefault);
            else
              oDatabaseHelper.AddParameter("@RegionalOffice", DBNull.Value );
              
			// Pass the value of '_zoneNumCode' as parameter 'ZoneNumCode' of the stored procedure.
			if(_zoneNumCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZoneNumCode", _zoneNumCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZoneNumCode", DBNull.Value );
              
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			if(_telephoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@TelephoneNumber", DBNull.Value );
              
			// Pass the value of '_emergencyPhoneNumber' as parameter 'EmergencyPhoneNumber' of the stored procedure.
			if(_emergencyPhoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmergencyPhoneNumber", _emergencyPhoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmergencyPhoneNumber", DBNull.Value );
              
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			if(_faxPhoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", DBNull.Value );
              
			// Pass the value of '_administrator' as parameter 'Administrator' of the stored procedure.
			if(_administratorNonDefault!=null)
              oDatabaseHelper.AddParameter("@Administrator", _administratorNonDefault);
            else
              oDatabaseHelper.AddParameter("@Administrator", DBNull.Value );
              
			// Pass the value of '_administratorTitle' as parameter 'AdministratorTitle' of the stored procedure.
			if(_administratorTitleNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorTitle", _administratorTitleNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorTitle", DBNull.Value );
              
			// Pass the value of '_administratorFirstName' as parameter 'AdministratorFirstName' of the stored procedure.
			if(_administratorFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorFirstName", _administratorFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorFirstName", DBNull.Value );
              
			// Pass the value of '_administratorMidInit' as parameter 'AdministratorMidInit' of the stored procedure.
			if(_administratorMidInitNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorMidInit", _administratorMidInitNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorMidInit", DBNull.Value );
              
			// Pass the value of '_administratorLastName' as parameter 'AdministratorLastName' of the stored procedure.
			if(_administratorLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorLastName", _administratorLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorLastName", DBNull.Value );
              
			// Pass the value of '_contactName' as parameter 'ContactName' of the stored procedure.
			if(_contactNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ContactName", _contactNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ContactName", DBNull.Value );
              
			// Pass the value of '_stateIdMds' as parameter 'StateIdMds' of the stored procedure.
			if(_stateIdMdsNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateIdMds", _stateIdMdsNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateIdMds", DBNull.Value );
              
			// Pass the value of '_stateLicNum' as parameter 'StateLicNum' of the stored procedure.
			if(_stateLicNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateLicNum", _stateLicNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateLicNum", DBNull.Value );
              
			// Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
			if(_emailAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmailAddress", _emailAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmailAddress", DBNull.Value );
              
			// Pass the value of '_medicaidVendorNumber' as parameter 'MedicaidVendorNumber' of the stored procedure.
			if(_medicaidVendorNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", _medicaidVendorNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", DBNull.Value );
              
			// Pass the value of '_fieldOfficeCode' as parameter 'FieldOfficeCode' of the stored procedure.
			if(_fieldOfficeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FieldOfficeCode", _fieldOfficeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FieldOfficeCode", DBNull.Value );
              
			// Pass the value of '_medicalDirectorFullName' as parameter 'MedicalDirectorFullName' of the stored procedure.
			if(_medicalDirectorFullNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorFullName", _medicalDirectorFullNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorFullName", DBNull.Value );
              
			// Pass the value of '_medicalDirectorTitle' as parameter 'MedicalDirectorTitle' of the stored procedure.
			if(_medicalDirectorTitleNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorTitle", _medicalDirectorTitleNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorTitle", DBNull.Value );
              
			// Pass the value of '_medicalDirFirstName' as parameter 'MedicalDirFirstName' of the stored procedure.
			if(_medicalDirFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirFirstName", _medicalDirFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirFirstName", DBNull.Value );
              
			// Pass the value of '_medicalDirMidInit' as parameter 'MedicalDirMidInit' of the stored procedure.
			if(_medicalDirMidInitNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirMidInit", _medicalDirMidInitNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirMidInit", DBNull.Value );
              
			// Pass the value of '_medicalDirLastName' as parameter 'MedicalDirLastName' of the stored procedure.
			if(_medicalDirLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirLastName", _medicalDirLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirLastName", DBNull.Value );
              
			// Pass the value of '_medicalDirectorMailAddr1' as parameter 'MedicalDirectorMailAddr1' of the stored procedure.
			if(_medicalDirectorMailAddr1NonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr1", _medicalDirectorMailAddr1NonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr1", DBNull.Value );
              
			// Pass the value of '_medicalDirectorMailAddr2' as parameter 'MedicalDirectorMailAddr2' of the stored procedure.
			if(_medicalDirectorMailAddr2NonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr2", _medicalDirectorMailAddr2NonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr2", DBNull.Value );
              
			// Pass the value of '_medicalDirectorMailCity' as parameter 'MedicalDirectorMailCity' of the stored procedure.
			if(_medicalDirectorMailCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailCity", _medicalDirectorMailCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailCity", DBNull.Value );
              
			// Pass the value of '_medicalDirectorMailState' as parameter 'MedicalDirectorMailState' of the stored procedure.
			if(_medicalDirectorMailStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailState", _medicalDirectorMailStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailState", DBNull.Value );
              
			// Pass the value of '_medicalDirectorMailZip' as parameter 'MedicalDirectorMailZip' of the stored procedure.
			if(_medicalDirectorMailZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailZip", _medicalDirectorMailZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailZip", DBNull.Value );
              
			// Pass the value of '_hoursMinutes' as parameter 'HoursMinutes' of the stored procedure.
			if(_hoursMinutesNonDefault!=null)
              oDatabaseHelper.AddParameter("@HoursMinutes", _hoursMinutesNonDefault);
            else
              oDatabaseHelper.AddParameter("@HoursMinutes", DBNull.Value );
              
			// Pass the value of '_snf18beds' as parameter 'Snf18beds' of the stored procedure.
			if(_snf18bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf18beds", _snf18bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf18beds", DBNull.Value );
              
			// Pass the value of '_amPM' as parameter 'AmPM' of the stored procedure.
			if(_amPMNonDefault!=null)
              oDatabaseHelper.AddParameter("@AmPM", _amPMNonDefault);
            else
              oDatabaseHelper.AddParameter("@AmPM", DBNull.Value );
              
			// Pass the value of '_hoursMinutes1' as parameter 'HoursMinutes1' of the stored procedure.
			if(_hoursMinutes1NonDefault!=null)
              oDatabaseHelper.AddParameter("@HoursMinutes1", _hoursMinutes1NonDefault);
            else
              oDatabaseHelper.AddParameter("@HoursMinutes1", DBNull.Value );
              
			// Pass the value of '_amPm1' as parameter 'AmPm1' of the stored procedure.
			if(_amPm1NonDefault!=null)
              oDatabaseHelper.AddParameter("@AmPm1", _amPm1NonDefault);
            else
              oDatabaseHelper.AddParameter("@AmPm1", DBNull.Value );
              
			// Pass the value of '_dayOfOperationMon' as parameter 'DayOfOperationMon' of the stored procedure.
			if(_dayOfOperationMonNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationMon", _dayOfOperationMonNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationMon", DBNull.Value );
              
			// Pass the value of '_dayOfOperationTue' as parameter 'DayOfOperationTue' of the stored procedure.
			if(_dayOfOperationTueNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationTue", _dayOfOperationTueNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationTue", DBNull.Value );
              
			// Pass the value of '_dayOfOperationWed' as parameter 'DayOfOperationWed' of the stored procedure.
			if(_dayOfOperationWedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationWed", _dayOfOperationWedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationWed", DBNull.Value );
              
			// Pass the value of '_dayOfOperationThu' as parameter 'DayOfOperationThu' of the stored procedure.
			if(_dayOfOperationThuNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationThu", _dayOfOperationThuNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationThu", DBNull.Value );
              
			// Pass the value of '_dayOfOperationFri' as parameter 'DayOfOperationFri' of the stored procedure.
			if(_dayOfOperationFriNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationFri", _dayOfOperationFriNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationFri", DBNull.Value );
              
			// Pass the value of '_dayOfOperationSat' as parameter 'DayOfOperationSat' of the stored procedure.
			if(_dayOfOperationSatNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationSat", _dayOfOperationSatNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationSat", DBNull.Value );
              
			// Pass the value of '_dayOfOperationSun' as parameter 'DayOfOperationSun' of the stored procedure.
			if(_dayOfOperationSunNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationSun", _dayOfOperationSunNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationSun", DBNull.Value );
              
			// Pass the value of '_typeLicenseCode' as parameter 'TypeLicenseCode' of the stored procedure.
			if(_typeLicenseCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeLicenseCode", _typeLicenseCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeLicenseCode", DBNull.Value );
              
			// Pass the value of '_typeOfLicense' as parameter 'TypeOfLicense' of the stored procedure.
			if(_typeOfLicenseNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfLicense", _typeOfLicenseNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfLicense", DBNull.Value );
              
			// Pass the value of '_typeFacilityCode' as parameter 'TypeFacilityCode' of the stored procedure.
			if(_typeFacilityCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacilityCode", _typeFacilityCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacilityCode", DBNull.Value );
              
			// Pass the value of '_typeFacility1Code' as parameter 'TypeFacility1Code' of the stored procedure.
			if(_typeFacility1CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility1Code", _typeFacility1CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility1Code", DBNull.Value );
              
			// Pass the value of '_typeFacility2Code' as parameter 'TypeFacility2Code' of the stored procedure.
			if(_typeFacility2CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility2Code", _typeFacility2CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility2Code", DBNull.Value );
              
			// Pass the value of '_typeFacility3Code' as parameter 'TypeFacility3Code' of the stored procedure.
			if(_typeFacility3CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility3Code", _typeFacility3CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility3Code", DBNull.Value );
              
			// Pass the value of '_typeFacility4Code' as parameter 'TypeFacility4Code' of the stored procedure.
			if(_typeFacility4CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility4Code", _typeFacility4CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility4Code", DBNull.Value );
              
			// Pass the value of '_typeFacility5Code' as parameter 'TypeFacility5Code' of the stored procedure.
			if(_typeFacility5CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility5Code", _typeFacility5CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility5Code", DBNull.Value );
              
			// Pass the value of '_typeFacility6Code' as parameter 'TypeFacility6Code' of the stored procedure.
			if(_typeFacility6CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility6Code", _typeFacility6CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility6Code", DBNull.Value );
              
			// Pass the value of '_licensedSnfFacility' as parameter 'LicensedSnfFacility' of the stored procedure.
			if(_licensedSnfFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", _licensedSnfFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", DBNull.Value );
              
			// Pass the value of '_snf1819beds' as parameter 'Snf1819beds' of the stored procedure.
			if(_snf1819bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf1819beds", _snf1819bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf1819beds", DBNull.Value );
              
			// Pass the value of '_snf19beds' as parameter 'Snf19beds' of the stored procedure.
			if(_snf19bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf19beds", _snf19bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf19beds", DBNull.Value );
              
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			if(_typeOfClientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfClients", DBNull.Value );
              
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			if(_psychiatricBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBeds", DBNull.Value );
              
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			if(_snfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBeds", DBNull.Value );
              
			// Pass the value of '_swingBeds' as parameter 'SwingBeds' of the stored procedure.
			if(_swingBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@SwingBeds", _swingBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@SwingBeds", DBNull.Value );
              
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			if(_rehabilitationBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabilitationBeds", DBNull.Value );
              
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			if(_totalLicBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBeds", DBNull.Value );
              
			// Pass the value of '_bedsCertified' as parameter 'BedsCertified' of the stored procedure.
			if(_bedsCertifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsCertified", _bedsCertifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsCertified", DBNull.Value );
              
			// Pass the value of '_typeOwnershipCode' as parameter 'TypeOwnershipCode' of the stored procedure.
			if(_typeOwnershipCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOwnershipCode", _typeOwnershipCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOwnershipCode", DBNull.Value );
              
			// Pass the value of '_nameOfCorporation' as parameter 'NameOfCorporation' of the stored procedure.
			if(_nameOfCorporationNonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfCorporation", _nameOfCorporationNonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfCorporation", DBNull.Value );
              
			// Pass the value of '_corporationIdNum' as parameter 'CorporationIdNum' of the stored procedure.
			if(_corporationIdNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationIdNum", _corporationIdNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationIdNum", DBNull.Value );
              
			// Pass the value of '_corporationStreet' as parameter 'CorporationStreet' of the stored procedure.
			if(_corporationStreetNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationStreet", _corporationStreetNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationStreet", DBNull.Value );
              
			// Pass the value of '_corporationCity' as parameter 'CorporationCity' of the stored procedure.
			if(_corporationCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationCity", _corporationCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationCity", DBNull.Value );
              
			// Pass the value of '_corporationState' as parameter 'CorporationState' of the stored procedure.
			if(_corporationStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationState", _corporationStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationState", DBNull.Value );
              
			// Pass the value of '_corporationZip' as parameter 'CorporationZip' of the stored procedure.
			if(_corporationZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationZip", _corporationZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationZip", DBNull.Value );
              
			// Pass the value of '_corporationPhone' as parameter 'CorporationPhone' of the stored procedure.
			if(_corporationPhoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationPhone", _corporationPhoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationPhone", DBNull.Value );
              
			// Pass the value of '_corporationFax' as parameter 'CorporationFax' of the stored procedure.
			if(_corporationFaxNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationFax", _corporationFaxNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationFax", DBNull.Value );
              
			// Pass the value of '_nameOfOwner1' as parameter 'NameOfOwner1' of the stored procedure.
			if(_nameOfOwner1NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner1", _nameOfOwner1NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner1", DBNull.Value );
              
			// Pass the value of '_nameOfOwner2' as parameter 'NameOfOwner2' of the stored procedure.
			if(_nameOfOwner2NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner2", _nameOfOwner2NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner2", DBNull.Value );
              
			// Pass the value of '_nameOfOwner3' as parameter 'NameOfOwner3' of the stored procedure.
			if(_nameOfOwner3NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner3", _nameOfOwner3NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner3", DBNull.Value );
              
			// Pass the value of '_nameOfOwner4' as parameter 'NameOfOwner4' of the stored procedure.
			if(_nameOfOwner4NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner4", _nameOfOwner4NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner4", DBNull.Value );
              
			// Pass the value of '_presidentName' as parameter 'PresidentName' of the stored procedure.
			if(_presidentNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@PresidentName", _presidentNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@PresidentName", DBNull.Value );
              
			// Pass the value of '_vicePresidentName' as parameter 'VicePresidentName' of the stored procedure.
			if(_vicePresidentNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@VicePresidentName", _vicePresidentNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@VicePresidentName", DBNull.Value );
              
			// Pass the value of '_secretaryTreasurerName' as parameter 'SecretaryTreasurerName' of the stored procedure.
			if(_secretaryTreasurerNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@SecretaryTreasurerName", _secretaryTreasurerNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@SecretaryTreasurerName", DBNull.Value );
              
			// Pass the value of '_jcahYN' as parameter 'JcahYN' of the stored procedure.
			if(_jcahYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@JcahYN", _jcahYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@JcahYN", DBNull.Value );
              
			// Pass the value of '_changeOfOwnerDate' as parameter 'ChangeOfOwnerDate' of the stored procedure.
			if(_changeOfOwnerDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfOwnerDate", _changeOfOwnerDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfOwnerDate", DBNull.Value );
              
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			if(_originalLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", DBNull.Value );
              
			// Pass the value of '_originalEnrollmentDate' as parameter 'OriginalEnrollmentDate' of the stored procedure.
			if(_originalEnrollmentDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", _originalEnrollmentDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", DBNull.Value );
              
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			if(_currentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", DBNull.Value );
              
			// Pass the value of '_licensureExpirationDate' as parameter 'LicensureExpirationDate' of the stored procedure.
			if(_licensureExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", _licensureExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", DBNull.Value );
              
			// Pass the value of '_licensureAnniversaryMth' as parameter 'LicensureAnniversaryMth' of the stored procedure.
			if(_licensureAnniversaryMthNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureAnniversaryMth", _licensureAnniversaryMthNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureAnniversaryMth", DBNull.Value );
              
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
              
			// Pass the value of '_capacityInHome' as parameter 'CapacityInHome' of the stored procedure.
			if(_capacityInHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityInHome", _capacityInHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityInHome", DBNull.Value );
              
			// Pass the value of '_capacityOutOfHome' as parameter 'CapacityOutOfHome' of the stored procedure.
			if(_capacityOutOfHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityOutOfHome", _capacityOutOfHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityOutOfHome", DBNull.Value );
              
			// Pass the value of '_ageRange' as parameter 'AgeRange' of the stored procedure.
			if(_ageRangeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRange", _ageRangeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRange", DBNull.Value );
              
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			if(_unitNonDefault!=null)
              oDatabaseHelper.AddParameter("@Unit", _unitNonDefault);
            else
              oDatabaseHelper.AddParameter("@Unit", DBNull.Value );
              
			// Pass the value of '_forYearEndingMmdd' as parameter 'ForYearEndingMmdd' of the stored procedure.
			if(_forYearEndingMmddNonDefault!=null)
              oDatabaseHelper.AddParameter("@ForYearEndingMmdd", _forYearEndingMmddNonDefault);
            else
              oDatabaseHelper.AddParameter("@ForYearEndingMmdd", DBNull.Value );
              
			// Pass the value of '_hospitalBasedYN' as parameter 'HospitalBasedYN' of the stored procedure.
			if(_hospitalBasedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@HospitalBasedYN", _hospitalBasedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@HospitalBasedYN", DBNull.Value );
              
			// Pass the value of '_applicationDate' as parameter 'ApplicationDate' of the stored procedure.
			if(_applicationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationDate", _applicationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationDate", DBNull.Value );
              
			// Pass the value of '_fee' as parameter 'Fee' of the stored procedure.
			if(_feeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Fee", _feeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Fee", DBNull.Value );
              
			// Pass the value of '_checkNumber' as parameter 'CheckNumber' of the stored procedure.
			if(_checkNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@CheckNumber", _checkNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@CheckNumber", DBNull.Value );
              
			// Pass the value of '_dateFeeReceived' as parameter 'DateFeeReceived' of the stored procedure.
			if(_dateFeeReceivedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateFeeReceived", _dateFeeReceivedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateFeeReceived", DBNull.Value );
              
			// Pass the value of '_stateFireApprovalDate' as parameter 'StateFireApprovalDate' of the stored procedure.
			if(_stateFireApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", _stateFireApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", DBNull.Value );
              
			// Pass the value of '_healthApprovalDate' as parameter 'HealthApprovalDate' of the stored procedure.
			if(_healthApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@HealthApprovalDate", _healthApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@HealthApprovalDate", DBNull.Value );
              
			// Pass the value of '_curSurv' as parameter 'CurSurv' of the stored procedure.
			if(_curSurvNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurSurv", _curSurvNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurSurv", DBNull.Value );
              
			// Pass the value of '_usDeaRegNum' as parameter 'UsDeaRegNum' of the stored procedure.
			if(_usDeaRegNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@UsDeaRegNum", _usDeaRegNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@UsDeaRegNum", DBNull.Value );
              
			// Pass the value of '_usDeaRegNumExpDate' as parameter 'UsDeaRegNumExpDate' of the stored procedure.
			if(_usDeaRegNumExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@UsDeaRegNumExpDate", _usDeaRegNumExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@UsDeaRegNumExpDate", DBNull.Value );
              
			// Pass the value of '_laCdsNum' as parameter 'LaCdsNum' of the stored procedure.
			if(_laCdsNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LaCdsNum", _laCdsNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LaCdsNum", DBNull.Value );
              
			// Pass the value of '_laCdsNumExpDate' as parameter 'LaCdsNumExpDate' of the stored procedure.
			if(_laCdsNumExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LaCdsNumExpDate", _laCdsNumExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LaCdsNumExpDate", DBNull.Value );
              
			// Pass the value of '_cliaIdNum' as parameter 'CliaIdNum' of the stored procedure.
			if(_cliaIdNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@CliaIdNum", _cliaIdNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@CliaIdNum", DBNull.Value );
              
			// Pass the value of '_cliaExpDate' as parameter 'CliaExpDate' of the stored procedure.
			if(_cliaExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CliaExpDate", _cliaExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CliaExpDate", DBNull.Value );
              
			// Pass the value of '_certEffectiveDate' as parameter 'CertEffectiveDate' of the stored procedure.
			if(_certEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertEffectiveDate", _certEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertEffectiveDate", DBNull.Value );
              
			// Pass the value of '_certifExpirationDate' as parameter 'CertifExpirationDate' of the stored procedure.
			if(_certifExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertifExpirationDate", _certifExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertifExpirationDate", DBNull.Value );
              
			// Pass the value of '_certificationMth' as parameter 'CertificationMth' of the stored procedure.
			if(_certificationMthNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertificationMth", _certificationMthNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertificationMth", DBNull.Value );
              
			// Pass the value of '_levelCode' as parameter 'LevelCode' of the stored procedure.
			if(_levelCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LevelCode", _levelCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LevelCode", DBNull.Value );
              
			// Pass the value of '_noOfAirAmbulances' as parameter 'NoOfAirAmbulances' of the stored procedure.
			if(_noOfAirAmbulancesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfAirAmbulances", _noOfAirAmbulancesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfAirAmbulances", DBNull.Value );
              
			// Pass the value of '_noOfGroundAmbulances' as parameter 'NoOfGroundAmbulances' of the stored procedure.
			if(_noOfGroundAmbulancesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfGroundAmbulances", _noOfGroundAmbulancesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfGroundAmbulances", DBNull.Value );
              
			// Pass the value of '_noOfSprintVehicles' as parameter 'NoOfSprintVehicles' of the stored procedure.
			if(_noOfSprintVehiclesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfSprintVehicles", _noOfSprintVehiclesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfSprintVehicles", DBNull.Value );
              
			// Pass the value of '_noOfAmbulatoryVehicles' as parameter 'NoOfAmbulatoryVehicles' of the stored procedure.
			if(_noOfAmbulatoryVehiclesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfAmbulatoryVehicles", _noOfAmbulatoryVehiclesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfAmbulatoryVehicles", DBNull.Value );
              
			// Pass the value of '_totalDailyCapacityAmbulatoryVehicle' as parameter 'TotalDailyCapacityAmbulatoryVehicle' of the stored procedure.
			if(_totalDailyCapacityAmbulatoryVehicleNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalDailyCapacityAmbulatoryVehicle", _totalDailyCapacityAmbulatoryVehicleNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalDailyCapacityAmbulatoryVehicle", DBNull.Value );
              
			// Pass the value of '_noOfHandicappedVehicles' as parameter 'NoOfHandicappedVehicles' of the stored procedure.
			if(_noOfHandicappedVehiclesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfHandicappedVehicles", _noOfHandicappedVehiclesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfHandicappedVehicles", DBNull.Value );
              
			// Pass the value of '_totalDailyCapacityHandicappedVehicle' as parameter 'TotalDailyCapacityHandicappedVehicle' of the stored procedure.
			if(_totalDailyCapacityHandicappedVehicleNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalDailyCapacityHandicappedVehicle", _totalDailyCapacityHandicappedVehicleNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalDailyCapacityHandicappedVehicle", DBNull.Value );
              
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			if(_numberOfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberOfBeds", DBNull.Value );
              
			// Pass the value of '_automobileInsuranceCoverageLimit' as parameter 'AutomobileInsuranceCoverageLimit' of the stored procedure.
			if(_automobileInsuranceCoverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCoverageLimit", _automobileInsuranceCoverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCoverageLimit", DBNull.Value );
              
			// Pass the value of '_automobileInsuranceCarrierCode' as parameter 'AutomobileInsuranceCarrierCode' of the stored procedure.
			if(_automobileInsuranceCarrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCarrierCode", _automobileInsuranceCarrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCarrierCode", DBNull.Value );
              
			// Pass the value of '_automobileInsurancePolicyNum' as parameter 'AutomobileInsurancePolicyNum' of the stored procedure.
			if(_automobileInsurancePolicyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsurancePolicyNum", _automobileInsurancePolicyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsurancePolicyNum", DBNull.Value );
              
			// Pass the value of '_automobileInsuranceExpirationDate' as parameter 'AutomobileInsuranceExpirationDate' of the stored procedure.
			if(_automobileInsuranceExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsuranceExpirationDate", _automobileInsuranceExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsuranceExpirationDate", DBNull.Value );
              
			// Pass the value of '_generalLiabilityCoverageLimit' as parameter 'GeneralLiabilityCoverageLimit' of the stored procedure.
			if(_generalLiabilityCoverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityCoverageLimit", _generalLiabilityCoverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityCoverageLimit", DBNull.Value );
              
			// Pass the value of '_generalLiabilityCarrierCode' as parameter 'GeneralLiabilityCarrierCode' of the stored procedure.
			if(_generalLiabilityCarrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityCarrierCode", _generalLiabilityCarrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityCarrierCode", DBNull.Value );
              
			// Pass the value of '_generalLiabilityPolicyNum' as parameter 'GeneralLiabilityPolicyNum' of the stored procedure.
			if(_generalLiabilityPolicyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityPolicyNum", _generalLiabilityPolicyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityPolicyNum", DBNull.Value );
              
			// Pass the value of '_facilityWithinFacilityYN' as parameter 'FacilityWithinFacilityYN' of the stored procedure.
			if(_facilityWithinFacilityYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", _facilityWithinFacilityYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", DBNull.Value );
              
			// Pass the value of '_generalLiabilityExpirationDate' as parameter 'GeneralLiabilityExpirationDate' of the stored procedure.
			if(_generalLiabilityExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityExpirationDate", _generalLiabilityExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityExpirationDate", DBNull.Value );
              
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			if(_otherBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBeds", DBNull.Value );
              
			// Pass the value of '_medicalMalpracticeCoverageLimit' as parameter 'MedicalMalpracticeCoverageLimit' of the stored procedure.
			if(_medicalMalpracticeCoverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCoverageLimit", _medicalMalpracticeCoverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCoverageLimit", DBNull.Value );
              
			// Pass the value of '_unitsNumTotal' as parameter 'UnitsNumTotal' of the stored procedure.
			if(_unitsNumTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumTotal", _unitsNumTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumTotal", DBNull.Value );
              
			// Pass the value of '_medicalMalpracticeCarrierCode' as parameter 'MedicalMalpracticeCarrierCode' of the stored procedure.
			if(_medicalMalpracticeCarrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCarrierCode", _medicalMalpracticeCarrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCarrierCode", DBNull.Value );
              
			// Pass the value of '_totalLicBedsTotal' as parameter 'TotalLicBedsTotal' of the stored procedure.
			if(_totalLicBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", _totalLicBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", DBNull.Value );
              
			// Pass the value of '_medicalMalpracticePolicyNum' as parameter 'MedicalMalpracticePolicyNum' of the stored procedure.
			if(_medicalMalpracticePolicyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticePolicyNum", _medicalMalpracticePolicyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticePolicyNum", DBNull.Value );
              
			// Pass the value of '_psychiatricBedsTotal' as parameter 'PsychiatricBedsTotal' of the stored procedure.
			if(_psychiatricBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", _psychiatricBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", DBNull.Value );
              
			// Pass the value of '_medicalMalpracticeExpirationDate' as parameter 'MedicalMalpracticeExpirationDate' of the stored procedure.
			if(_medicalMalpracticeExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticeExpirationDate", _medicalMalpracticeExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticeExpirationDate", DBNull.Value );
              
			// Pass the value of '_isolationUnitYN' as parameter 'IsolationUnitYN' of the stored procedure.
			if(_isolationUnitYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsolationUnitYN", _isolationUnitYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsolationUnitYN", DBNull.Value );
              
			// Pass the value of '_rehabilitationBedsTotal' as parameter 'RehabilitationBedsTotal' of the stored procedure.
			if(_rehabilitationBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabilitationBedsTotal", _rehabilitationBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabilitationBedsTotal", DBNull.Value );
              
			// Pass the value of '_snfBedsTotal' as parameter 'SnfBedsTotal' of the stored procedure.
			if(_snfBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBedsTotal", _snfBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBedsTotal", DBNull.Value );
              
			// Pass the value of '_statusCode' as parameter 'StatusCode' of the stored procedure.
			if(_statusCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusCode", _statusCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusCode", DBNull.Value );
              
			// Pass the value of '_unitsNumOffsiteTotal' as parameter 'UnitsNumOffsiteTotal' of the stored procedure.
			if(_unitsNumOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", _unitsNumOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			if(_statusDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusDate", DBNull.Value );
              
			// Pass the value of '_totalLicBedsOffsiteTotal' as parameter 'TotalLicBedsOffsiteTotal' of the stored procedure.
			if(_totalLicBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", _totalLicBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_noOfParishesServed' as parameter 'NoOfParishesServed' of the stored procedure.
			if(_noOfParishesServedNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfParishesServed", _noOfParishesServedNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfParishesServed", DBNull.Value );
              
			// Pass the value of '_psychiatricBedsOffsiteTotal' as parameter 'PsychiatricBedsOffsiteTotal' of the stored procedure.
			if(_psychiatricBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", _psychiatricBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_licensureSurveyDate' as parameter 'LicensureSurveyDate' of the stored procedure.
			if(_licensureSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", _licensureSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", DBNull.Value );
              
			// Pass the value of '_rehabBedsOffsiteTotal' as parameter 'RehabBedsOffsiteTotal' of the stored procedure.
			if(_rehabBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", _rehabBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_waivers' as parameter 'Waivers' of the stored procedure.
			if(_waiversNonDefault!=null)
              oDatabaseHelper.AddParameter("@Waivers", _waiversNonDefault);
            else
              oDatabaseHelper.AddParameter("@Waivers", DBNull.Value );
              
			// Pass the value of '_snfBedsOffsiteTotal' as parameter 'SnfBedsOffsiteTotal' of the stored procedure.
			if(_snfBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBedsOffsiteTotal", _snfBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_otherBedsOffsiteTotal' as parameter 'OtherBedsOffsiteTotal' of the stored procedure.
			if(_otherBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBedsOffsiteTotal", _otherBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_psychPpsFederalID' as parameter 'PsychPpsFederalID' of the stored procedure.
			if(_psychPpsFederalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychPpsFederalID", _psychPpsFederalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychPpsFederalID", DBNull.Value );
              
			// Pass the value of '_rehabPpsFederalID' as parameter 'RehabPpsFederalID' of the stored procedure.
			if(_rehabPpsFederalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabPpsFederalID", _rehabPpsFederalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabPpsFederalID", DBNull.Value );
              
			// Pass the value of '_userLastMaint' as parameter 'UserLastMaint' of the stored procedure.
			if(_userLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@UserLastMaint", _userLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@UserLastMaint", DBNull.Value );
              
			// Pass the value of '_psychPpsCertEffectiveDate' as parameter 'PsychPpsCertEffectiveDate' of the stored procedure.
			if(_psychPpsCertEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychPpsCertEffectiveDate", _psychPpsCertEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychPpsCertEffectiveDate", DBNull.Value );
              
			// Pass the value of '_dateLastMaint' as parameter 'DateLastMaint' of the stored procedure.
			if(_dateLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateLastMaint", _dateLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateLastMaint", DBNull.Value );
              
			// Pass the value of '_rehabPpsCertEffectiveDate' as parameter 'RehabPpsCertEffectiveDate' of the stored procedure.
			if(_rehabPpsCertEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabPpsCertEffectiveDate", _rehabPpsCertEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabPpsCertEffectiveDate", DBNull.Value );
              
			// Pass the value of '_timeLastMaint' as parameter 'TimeLastMaint' of the stored procedure.
			if(_timeLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@TimeLastMaint", _timeLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@TimeLastMaint", DBNull.Value );
              
			// Pass the value of '_offsiteCampusYN' as parameter 'OffsiteCampusYN' of the stored procedure.
			if(_offsiteCampusYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteCampusYN", _offsiteCampusYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteCampusYN", DBNull.Value );
              
			// Pass the value of '_certifiedBedOverrideYN' as parameter 'CertifiedBedOverrideYN' of the stored procedure.
			if(_certifiedBedOverrideYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", _certifiedBedOverrideYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", DBNull.Value );
              
			// Pass the value of '_mainCampusBeds' as parameter 'MainCampusBeds' of the stored procedure.
			if(_mainCampusBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@MainCampusBeds", _mainCampusBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@MainCampusBeds", DBNull.Value );
              
			// Pass the value of '_forYearEndingDate' as parameter 'ForYearEndingDate' of the stored procedure.
			if(_forYearEndingDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ForYearEndingDate", _forYearEndingDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ForYearEndingDate", DBNull.Value );
              
			// Pass the value of '_neonatalIntCode' as parameter 'NeonatalIntCode' of the stored procedure.
			if(_neonatalIntCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NeonatalIntCode", _neonatalIntCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NeonatalIntCode", DBNull.Value );
              
			// Pass the value of '_servicesOffered' as parameter 'ServicesOffered' of the stored procedure.
			if(_servicesOfferedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServicesOffered", _servicesOfferedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServicesOffered", DBNull.Value );
              
			// Pass the value of '_picuIntCode' as parameter 'PicuIntCode' of the stored procedure.
			if(_picuIntCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PicuIntCode", _picuIntCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PicuIntCode", DBNull.Value );
              
			// Pass the value of '_halfwayHouse' as parameter 'HalfwayHouse' of the stored procedure.
			if(_halfwayHouseNonDefault!=null)
              oDatabaseHelper.AddParameter("@HalfwayHouse", _halfwayHouseNonDefault);
            else
              oDatabaseHelper.AddParameter("@HalfwayHouse", DBNull.Value );
              
			// Pass the value of '_deemedStatus' as parameter 'DeemedStatus' of the stored procedure.
			if(_deemedStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@DeemedStatus", _deemedStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@DeemedStatus", DBNull.Value );
              
			// Pass the value of '_inPatient' as parameter 'InPatient' of the stored procedure.
			if(_inPatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@InPatient", _inPatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@InPatient", DBNull.Value );
              
			// Pass the value of '_chapAccreditionYN' as parameter 'ChapAccreditionYN' of the stored procedure.
			if(_chapAccreditionYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", _chapAccreditionYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", DBNull.Value );
              
			// Pass the value of '_crisisEmergency' as parameter 'CrisisEmergency' of the stored procedure.
			if(_crisisEmergencyNonDefault!=null)
              oDatabaseHelper.AddParameter("@CrisisEmergency", _crisisEmergencyNonDefault);
            else
              oDatabaseHelper.AddParameter("@CrisisEmergency", DBNull.Value );
              
			// Pass the value of '_outpatientTreatment' as parameter 'OutpatientTreatment' of the stored procedure.
			if(_outpatientTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@OutpatientTreatment", _outpatientTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@OutpatientTreatment", DBNull.Value );
              
			// Pass the value of '_fiscalIntermediaryNum' as parameter 'FiscalIntermediaryNum' of the stored procedure.
			if(_fiscalIntermediaryNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", _fiscalIntermediaryNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", DBNull.Value );
              
			// Pass the value of '_methadoneTreatment' as parameter 'MethadoneTreatment' of the stored procedure.
			if(_methadoneTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@MethadoneTreatment", _methadoneTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@MethadoneTreatment", DBNull.Value );
              
			// Pass the value of '_attesestationStatement' as parameter 'AttesestationStatement' of the stored procedure.
			if(_attesestationStatementNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttesestationStatement", _attesestationStatementNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttesestationStatement", DBNull.Value );
              
			// Pass the value of '_preventionEducation' as parameter 'PreventionEducation' of the stored procedure.
			if(_preventionEducationNonDefault!=null)
              oDatabaseHelper.AddParameter("@PreventionEducation", _preventionEducationNonDefault);
            else
              oDatabaseHelper.AddParameter("@PreventionEducation", DBNull.Value );
              
			// Pass the value of '_attesestationStmtDateSigned' as parameter 'AttesestationStmtDateSigned' of the stored procedure.
			if(_attesestationStmtDateSignedNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttesestationStmtDateSigned", _attesestationStmtDateSignedNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttesestationStmtDateSigned", DBNull.Value );
              
			// Pass the value of '_residentialTreatment' as parameter 'ResidentialTreatment' of the stored procedure.
			if(_residentialTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@ResidentialTreatment", _residentialTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@ResidentialTreatment", DBNull.Value );
              
			// Pass the value of '_nameChangePrevName1' as parameter 'NameChangePrevName1' of the stored procedure.
			if(_nameChangePrevName1NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangePrevName1", _nameChangePrevName1NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangePrevName1", DBNull.Value );
              
			// Pass the value of '_socialSettingDetoxification' as parameter 'SocialSettingDetoxification' of the stored procedure.
			if(_socialSettingDetoxificationNonDefault!=null)
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", _socialSettingDetoxificationNonDefault);
            else
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", DBNull.Value );
              
			// Pass the value of '_nameChangeDate1' as parameter 'NameChangeDate1' of the stored procedure.
			if(_nameChangeDate1NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangeDate1", _nameChangeDate1NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangeDate1", DBNull.Value );
              
			// Pass the value of '_adultHealthCare' as parameter 'AdultHealthCare' of the stored procedure.
			if(_adultHealthCareNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdultHealthCare", _adultHealthCareNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdultHealthCare", DBNull.Value );
              
			// Pass the value of '_nameChangePrevName2' as parameter 'NameChangePrevName2' of the stored procedure.
			if(_nameChangePrevName2NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangePrevName2", _nameChangePrevName2NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangePrevName2", DBNull.Value );
              
			// Pass the value of '_nameChangeDate2' as parameter 'NameChangeDate2' of the stored procedure.
			if(_nameChangeDate2NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangeDate2", _nameChangeDate2NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangeDate2", DBNull.Value );
              
			// Pass the value of '_cnatTrainingCode' as parameter 'CnatTrainingCode' of the stored procedure.
			if(_cnatTrainingCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CnatTrainingCode", _cnatTrainingCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CnatTrainingCode", DBNull.Value );
              
			// Pass the value of '_cnatTrainingSuspendDate' as parameter 'CnatTrainingSuspendDate' of the stored procedure.
			if(_cnatTrainingSuspendDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CnatTrainingSuspendDate", _cnatTrainingSuspendDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CnatTrainingSuspendDate", DBNull.Value );
              
			// Pass the value of '_previousOwner1' as parameter 'PreviousOwner1' of the stored procedure.
			if(_previousOwner1NonDefault!=null)
              oDatabaseHelper.AddParameter("@PreviousOwner1", _previousOwner1NonDefault);
            else
              oDatabaseHelper.AddParameter("@PreviousOwner1", DBNull.Value );
              
			// Pass the value of '_prevOwnerChangeDate1' as parameter 'PrevOwnerChangeDate1' of the stored procedure.
			if(_prevOwnerChangeDate1NonDefault!=null)
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate1", _prevOwnerChangeDate1NonDefault);
            else
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate1", DBNull.Value );
              
			// Pass the value of '_assistDirOfNursingWaiverMonth' as parameter 'AssistDirOfNursingWaiverMonth' of the stored procedure.
			if(_assistDirOfNursingWaiverMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@AssistDirOfNursingWaiverMonth", _assistDirOfNursingWaiverMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@AssistDirOfNursingWaiverMonth", DBNull.Value );
              
			// Pass the value of '_day7RnWaiverMonth' as parameter 'Day7RnWaiverMonth' of the stored procedure.
			if(_day7RnWaiverMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@Day7RnWaiverMonth", _day7RnWaiverMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@Day7RnWaiverMonth", DBNull.Value );
              
			// Pass the value of '_previousOwner2' as parameter 'PreviousOwner2' of the stored procedure.
			if(_previousOwner2NonDefault!=null)
              oDatabaseHelper.AddParameter("@PreviousOwner2", _previousOwner2NonDefault);
            else
              oDatabaseHelper.AddParameter("@PreviousOwner2", DBNull.Value );
              
			// Pass the value of '_prevOwnerChangeDate2' as parameter 'PrevOwnerChangeDate2' of the stored procedure.
			if(_prevOwnerChangeDate2NonDefault!=null)
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate2", _prevOwnerChangeDate2NonDefault);
            else
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate2", DBNull.Value );
              
			// Pass the value of '_currentSurveyMonth' as parameter 'CurrentSurveyMonth' of the stored procedure.
			if(_currentSurveyMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", _currentSurveyMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", DBNull.Value );
              
			// Pass the value of '_fiscalIntermediaryDesc' as parameter 'FiscalIntermediaryDesc' of the stored procedure.
			if(_fiscalIntermediaryDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", _fiscalIntermediaryDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", DBNull.Value );
              
			// Pass the value of '_medicareInterPrefCode' as parameter 'MedicareInterPrefCode' of the stored procedure.
			if(_medicareInterPrefCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicareInterPrefCode", _medicareInterPrefCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicareInterPrefCode", DBNull.Value );
              
			// Pass the value of '_programCode' as parameter 'ProgramCode' of the stored procedure.
			if(_programCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramCode", _programCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramCode", DBNull.Value );
              
			// Pass the value of '_noTreatmentsPerWeek' as parameter 'NoTreatmentsPerWeek' of the stored procedure.
			if(_noTreatmentsPerWeekNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoTreatmentsPerWeek", _noTreatmentsPerWeekNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoTreatmentsPerWeek", DBNull.Value );
              
			// Pass the value of '_noOfStations' as parameter 'NoOfStations' of the stored procedure.
			if(_noOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfStations", _noOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfStations", DBNull.Value );
              
			// Pass the value of '_levelDescription' as parameter 'LevelDescription' of the stored procedure.
			if(_levelDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@LevelDescription", _levelDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@LevelDescription", DBNull.Value );
              
			// Pass the value of '_automaticCancellationDate' as parameter 'AutomaticCancellationDate' of the stored procedure.
			if(_automaticCancellationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomaticCancellationDate", _automaticCancellationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomaticCancellationDate", DBNull.Value );
              
			// Pass the value of '_noOf3hrShiftsWeek' as parameter 'NoOf3hrShiftsWeek' of the stored procedure.
			if(_noOf3hrShiftsWeekNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", _noOf3hrShiftsWeekNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", DBNull.Value );
              
			// Pass the value of '_fcertBeds' as parameter 'FcertBeds' of the stored procedure.
			if(_fcertBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@FcertBeds", _fcertBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@FcertBeds", DBNull.Value );
              
			// Pass the value of '_averageNumPatientsShift' as parameter 'AverageNumPatientsShift' of the stored procedure.
			if(_averageNumPatientsShiftNonDefault!=null)
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", _averageNumPatientsShiftNonDefault);
            else
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", DBNull.Value );
              
			// Pass the value of '_automobileInsurancePrepaymentDueDate' as parameter 'AutomobileInsurancePrepaymentDueDate' of the stored procedure.
			if(_automobileInsurancePrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", _automobileInsurancePrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", DBNull.Value );
              
			// Pass the value of '_vendorNum' as parameter 'VendorNum' of the stored procedure.
			if(_vendorNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@VendorNum", _vendorNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@VendorNum", DBNull.Value );
              
			// Pass the value of '_generalLiabilityPrepaymentDueDate' as parameter 'GeneralLiabilityPrepaymentDueDate' of the stored procedure.
			if(_generalLiabilityPrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", _generalLiabilityPrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", DBNull.Value );
              
			// Pass the value of '_waiverCode' as parameter 'WaiverCode' of the stored procedure.
			if(_waiverCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode", _waiverCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode", DBNull.Value );
              
			// Pass the value of '_waiverCode2' as parameter 'WaiverCode2' of the stored procedure.
			if(_waiverCode2NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode2", _waiverCode2NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode2", DBNull.Value );
              
			// Pass the value of '_overrideCapacity' as parameter 'OverrideCapacity' of the stored procedure.
			if(_overrideCapacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@OverrideCapacity", _overrideCapacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@OverrideCapacity", DBNull.Value );
              
			// Pass the value of '_rnCoordinator' as parameter 'RnCoordinator' of the stored procedure.
			if(_rnCoordinatorNonDefault!=null)
              oDatabaseHelper.AddParameter("@RnCoordinator", _rnCoordinatorNonDefault);
            else
              oDatabaseHelper.AddParameter("@RnCoordinator", DBNull.Value );
              
			// Pass the value of '_waiverCode3' as parameter 'WaiverCode3' of the stored procedure.
			if(_waiverCode3NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode3", _waiverCode3NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode3", DBNull.Value );
              
			// Pass the value of '_waiverCode4' as parameter 'WaiverCode4' of the stored procedure.
			if(_waiverCode4NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode4", _waiverCode4NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode4", DBNull.Value );
              
			// Pass the value of '_directorName' as parameter 'DirectorName' of the stored procedure.
			if(_directorNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorName", _directorNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorName", DBNull.Value );
              
			// Pass the value of '_waiverCode5' as parameter 'WaiverCode5' of the stored procedure.
			if(_waiverCode5NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode5", _waiverCode5NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode5", DBNull.Value );
              
			// Pass the value of '_year1ReviewDateDue' as parameter 'Year1ReviewDateDue' of the stored procedure.
			if(_year1ReviewDateDueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", _year1ReviewDateDueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", DBNull.Value );
              
			// Pass the value of '_waiverCode6' as parameter 'WaiverCode6' of the stored procedure.
			if(_waiverCode6NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode6", _waiverCode6NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode6", DBNull.Value );
              
			// Pass the value of '_waiverCode7' as parameter 'WaiverCode7' of the stored procedure.
			if(_waiverCode7NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode7", _waiverCode7NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode7", DBNull.Value );
              
			// Pass the value of '_usage' as parameter 'Usage' of the stored procedure.
			if(_usageNonDefault!=null)
              oDatabaseHelper.AddParameter("@Usage", _usageNonDefault);
            else
              oDatabaseHelper.AddParameter("@Usage", DBNull.Value );
              
			// Pass the value of '_totalNumDialysisPatients' as parameter 'TotalNumDialysisPatients' of the stored procedure.
			if(_totalNumDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", _totalNumDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", DBNull.Value );
              
			// Pass the value of '_accreditationExpirationDate' as parameter 'AccreditationExpirationDate' of the stored procedure.
			if(_accreditationExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", _accreditationExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", DBNull.Value );
              
			// Pass the value of '_hemodialysisNumPatients' as parameter 'HemodialysisNumPatients' of the stored procedure.
			if(_hemodialysisNumPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", _hemodialysisNumPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", DBNull.Value );
              
			// Pass the value of '_facilityWithinFacility' as parameter 'FacilityWithinFacility' of the stored procedure.
			if(_facilityWithinFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", _facilityWithinFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", DBNull.Value );
              
			// Pass the value of '_numOfPeritonealDialysisPatients' as parameter 'NumOfPeritonealDialysisPatients' of the stored procedure.
			if(_numOfPeritonealDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", _numOfPeritonealDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", DBNull.Value );
              
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			if(_facilityTypeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityTypeCode", DBNull.Value );
              
			// Pass the value of '_hemodialysisNumOfStations' as parameter 'HemodialysisNumOfStations' of the stored procedure.
			if(_hemodialysisNumOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", _hemodialysisNumOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", DBNull.Value );
              
			// Pass the value of '_transplantYN' as parameter 'TransplantYN' of the stored procedure.
			if(_transplantYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplantYN", _transplantYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplantYN", DBNull.Value );
              
			// Pass the value of '_hemodialysisTrainingNumOfStation' as parameter 'HemodialysisTrainingNumOfStation' of the stored procedure.
			if(_hemodialysisTrainingNumOfStationNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", _hemodialysisTrainingNumOfStationNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", DBNull.Value );
              
			// Pass the value of '_obIntCode' as parameter 'ObIntCode' of the stored procedure.
			if(_obIntCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObIntCode", _obIntCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObIntCode", DBNull.Value );
              
			// Pass the value of '_obCurrentSurveyDate' as parameter 'ObCurrentSurveyDate' of the stored procedure.
			if(_obCurrentSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObCurrentSurveyDate", _obCurrentSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObCurrentSurveyDate", DBNull.Value );
              
			// Pass the value of '_totalNumStations' as parameter 'TotalNumStations' of the stored procedure.
			if(_totalNumStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalNumStations", _totalNumStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalNumStations", DBNull.Value );
              
			// Pass the value of '_reuseYN' as parameter 'ReuseYN' of the stored procedure.
			if(_reuseYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReuseYN", _reuseYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReuseYN", DBNull.Value );
              
			// Pass the value of '_nicuCurrentSurveyDate' as parameter 'NicuCurrentSurveyDate' of the stored procedure.
			if(_nicuCurrentSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@NicuCurrentSurveyDate", _nicuCurrentSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@NicuCurrentSurveyDate", DBNull.Value );
              
			// Pass the value of '_manualYN' as parameter 'ManualYN' of the stored procedure.
			if(_manualYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ManualYN", _manualYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ManualYN", DBNull.Value );
              
			// Pass the value of '_picuCurrentSurveyDate' as parameter 'PicuCurrentSurveyDate' of the stored procedure.
			if(_picuCurrentSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PicuCurrentSurveyDate", _picuCurrentSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PicuCurrentSurveyDate", DBNull.Value );
              
			// Pass the value of '_numOfPatientsFollowedAtHome' as parameter 'NumOfPatientsFollowedAtHome' of the stored procedure.
			if(_numOfPatientsFollowedAtHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", _numOfPatientsFollowedAtHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", DBNull.Value );
              
			// Pass the value of '_traumaLevel' as parameter 'TraumaLevel' of the stored procedure.
			if(_traumaLevelNonDefault!=null)
              oDatabaseHelper.AddParameter("@TraumaLevel", _traumaLevelNonDefault);
            else
              oDatabaseHelper.AddParameter("@TraumaLevel", DBNull.Value );
              
			// Pass the value of '_semiautomatedYN' as parameter 'SemiautomatedYN' of the stored procedure.
			if(_semiautomatedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@SemiautomatedYN", _semiautomatedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@SemiautomatedYN", DBNull.Value );
              
			// Pass the value of '_automatedYN' as parameter 'AutomatedYN' of the stored procedure.
			if(_automatedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomatedYN", _automatedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomatedYN", DBNull.Value );
              
			// Pass the value of '_formainGermicide' as parameter 'FormainGermicide' of the stored procedure.
			if(_formainGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@FormainGermicide", _formainGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@FormainGermicide", DBNull.Value );
              
			// Pass the value of '_heatGermicide' as parameter 'HeatGermicide' of the stored procedure.
			if(_heatGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@HeatGermicide", _heatGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@HeatGermicide", DBNull.Value );
              
			// Pass the value of '_gluteraldetydeGermicide' as parameter 'GluteraldetydeGermicide' of the stored procedure.
			if(_gluteraldetydeGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@GluteraldetydeGermicide", _gluteraldetydeGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@GluteraldetydeGermicide", DBNull.Value );
              
			// Pass the value of '_peraceticAcidMixtureGerm' as parameter 'PeraceticAcidMixtureGerm' of the stored procedure.
			if(_peraceticAcidMixtureGermNonDefault!=null)
              oDatabaseHelper.AddParameter("@PeraceticAcidMixtureGerm", _peraceticAcidMixtureGermNonDefault);
            else
              oDatabaseHelper.AddParameter("@PeraceticAcidMixtureGerm", DBNull.Value );
              
			// Pass the value of '_otherGermicide' as parameter 'OtherGermicide' of the stored procedure.
			if(_otherGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherGermicide", _otherGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherGermicide", DBNull.Value );
              
			// Pass the value of '_enrolledRhcOffsiteYN' as parameter 'EnrolledRhcOffsiteYN' of the stored procedure.
			if(_enrolledRhcOffsiteYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", _enrolledRhcOffsiteYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", DBNull.Value );
              
			// Pass the value of '_typeGermicideDescription' as parameter 'TypeGermicideDescription' of the stored procedure.
			if(_typeGermicideDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeGermicideDescription", _typeGermicideDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeGermicideDescription", DBNull.Value );
              
			// Pass the value of '_hemodialysisService' as parameter 'HemodialysisService' of the stored procedure.
			if(_hemodialysisServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisService", _hemodialysisServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisService", DBNull.Value );
              
			// Pass the value of '_directorOfNursingFirstName' as parameter 'DirectorOfNursingFirstName' of the stored procedure.
			if(_directorOfNursingFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorOfNursingFirstName", _directorOfNursingFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorOfNursingFirstName", DBNull.Value );
              
			// Pass the value of '_peritonealDialysisService' as parameter 'PeritonealDialysisService' of the stored procedure.
			if(_peritonealDialysisServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", _peritonealDialysisServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", DBNull.Value );
              
			// Pass the value of '_directorOfNursingLastName' as parameter 'DirectorOfNursingLastName' of the stored procedure.
			if(_directorOfNursingLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorOfNursingLastName", _directorOfNursingLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorOfNursingLastName", DBNull.Value );
              
			// Pass the value of '_presidentFirstName' as parameter 'PresidentFirstName' of the stored procedure.
			if(_presidentFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@PresidentFirstName", _presidentFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@PresidentFirstName", DBNull.Value );
              
			// Pass the value of '_transplanationService' as parameter 'TransplanationService' of the stored procedure.
			if(_transplanationServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplanationService", _transplanationServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplanationService", DBNull.Value );
              
			// Pass the value of '_presidentLastName' as parameter 'PresidentLastName' of the stored procedure.
			if(_presidentLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@PresidentLastName", _presidentLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@PresidentLastName", DBNull.Value );
              
			// Pass the value of '_homeTrainingService' as parameter 'HomeTrainingService' of the stored procedure.
			if(_homeTrainingServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@HomeTrainingService", _homeTrainingServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@HomeTrainingService", DBNull.Value );
              
			// Pass the value of '_staffingFteRN' as parameter 'StaffingFteRN' of the stored procedure.
			if(_staffingFteRNNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteRN", _staffingFteRNNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteRN", DBNull.Value );
              
			// Pass the value of '_staffingFteLpn' as parameter 'StaffingFteLpn' of the stored procedure.
			if(_staffingFteLpnNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteLpn", _staffingFteLpnNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteLpn", DBNull.Value );
              
			// Pass the value of '_staffingFteSW' as parameter 'StaffingFteSW' of the stored procedure.
			if(_staffingFteSWNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteSW", _staffingFteSWNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteSW", DBNull.Value );
              
			// Pass the value of '_staffingFteTechnicians' as parameter 'StaffingFteTechnicians' of the stored procedure.
			if(_staffingFteTechniciansNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteTechnicians", _staffingFteTechniciansNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteTechnicians", DBNull.Value );
              
			// Pass the value of '_staffingFteDietian' as parameter 'StaffingFteDietian' of the stored procedure.
			if(_staffingFteDietianNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteDietian", _staffingFteDietianNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteDietian", DBNull.Value );
              
			// Pass the value of '_staffingFteOthers' as parameter 'StaffingFteOthers' of the stored procedure.
			if(_staffingFteOthersNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteOthers", _staffingFteOthersNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteOthers", DBNull.Value );
              
			// Pass the value of '_initial' as parameter 'Initial' of the stored procedure.
			if(_initialNonDefault!=null)
              oDatabaseHelper.AddParameter("@Initial", _initialNonDefault);
            else
              oDatabaseHelper.AddParameter("@Initial", DBNull.Value );
              
			// Pass the value of '_initialDate' as parameter 'InitialDate' of the stored procedure.
			if(_initialDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@InitialDate", _initialDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@InitialDate", DBNull.Value );
              
			// Pass the value of '_expansionToNewLocation' as parameter 'ExpansionToNewLocation' of the stored procedure.
			if(_expansionToNewLocationNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpansionToNewLocation", _expansionToNewLocationNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpansionToNewLocation", DBNull.Value );
              
			// Pass the value of '_expToNewLocationDate' as parameter 'ExpToNewLocationDate' of the stored procedure.
			if(_expToNewLocationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpToNewLocationDate", _expToNewLocationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpToNewLocationDate", DBNull.Value );
              
			// Pass the value of '_changeOfOwnership' as parameter 'ChangeOfOwnership' of the stored procedure.
			if(_changeOfOwnershipNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfOwnership", _changeOfOwnershipNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfOwnership", DBNull.Value );
              
			// Pass the value of '_changeOfLocation' as parameter 'ChangeOfLocation' of the stored procedure.
			if(_changeOfLocationNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfLocation", _changeOfLocationNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfLocation", DBNull.Value );
              
			// Pass the value of '_changeOfLocationDate' as parameter 'ChangeOfLocationDate' of the stored procedure.
			if(_changeOfLocationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfLocationDate", _changeOfLocationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfLocationDate", DBNull.Value );
              
			// Pass the value of '_expansionInCurrentLocation' as parameter 'ExpansionInCurrentLocation' of the stored procedure.
			if(_expansionInCurrentLocationNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocation", _expansionInCurrentLocationNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocation", DBNull.Value );
              
			// Pass the value of '_expansionInCurrentLocationDate' as parameter 'ExpansionInCurrentLocationDate' of the stored procedure.
			if(_expansionInCurrentLocationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocationDate", _expansionInCurrentLocationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocationDate", DBNull.Value );
              
			// Pass the value of '_changeOfServices' as parameter 'ChangeOfServices' of the stored procedure.
			if(_changeOfServicesNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfServices", _changeOfServicesNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfServices", DBNull.Value );
              
			// Pass the value of '_changeOfServicesDate' as parameter 'ChangeOfServicesDate' of the stored procedure.
			if(_changeOfServicesDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfServicesDate", _changeOfServicesDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfServicesDate", DBNull.Value );
              
			// Pass the value of '_typeApplicationCode7' as parameter 'TypeApplicationCode7' of the stored procedure.
			if(_typeApplicationCode7NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeApplicationCode7", _typeApplicationCode7NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeApplicationCode7", DBNull.Value );
              
			// Pass the value of '_typeApplicationCode7Date' as parameter 'TypeApplicationCode7Date' of the stored procedure.
			if(_typeApplicationCode7DateNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeApplicationCode7Date", _typeApplicationCode7DateNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeApplicationCode7Date", DBNull.Value );
              
			// Pass the value of '_typeApplicationDescr' as parameter 'TypeApplicationDescr' of the stored procedure.
			if(_typeApplicationDescrNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeApplicationDescr", _typeApplicationDescrNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeApplicationDescr", DBNull.Value );
              
			// Pass the value of '_providerBasedYN' as parameter 'ProviderBasedYN' of the stored procedure.
			if(_providerBasedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProviderBasedYN", _providerBasedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProviderBasedYN", DBNull.Value );
              
			// Pass the value of '_midLevelWaiverYN' as parameter 'MidLevelWaiverYN' of the stored procedure.
			if(_midLevelWaiverYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@MidLevelWaiverYN", _midLevelWaiverYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@MidLevelWaiverYN", DBNull.Value );
              
			// Pass the value of '_midLevelWaiverMonth' as parameter 'MidLevelWaiverMonth' of the stored procedure.
			if(_midLevelWaiverMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@MidLevelWaiverMonth", _midLevelWaiverMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@MidLevelWaiverMonth", DBNull.Value );
              
			// Pass the value of '_midLevelWaiverDate' as parameter 'MidLevelWaiverDate' of the stored procedure.
			if(_midLevelWaiverDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MidLevelWaiverDate", _midLevelWaiverDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MidLevelWaiverDate", DBNull.Value );
              
			// Pass the value of '_relatedProviderLicensureNum' as parameter 'RelatedProviderLicensureNum' of the stored procedure.
			if(_relatedProviderLicensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", _relatedProviderLicensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", DBNull.Value );
              
			// Pass the value of '_emergencyPrepReportRequired' as parameter 'EmergencyPrepReportRequired' of the stored procedure.
			if(_emergencyPrepReportRequiredNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", _emergencyPrepReportRequiredNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", DBNull.Value );
              
			// Pass the value of '_accreditedBody' as parameter 'AccreditedBody' of the stored procedure.
			if(_accreditedBodyNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditedBody", _accreditedBodyNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditedBody", DBNull.Value );
              
			// Pass the value of '_enrolledInMedicaidYN' as parameter 'EnrolledInMedicaidYN' of the stored procedure.
			if(_enrolledInMedicaidYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", _enrolledInMedicaidYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", DBNull.Value );
              
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			if(_typeTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeTreatment", DBNull.Value );
              
			// Pass the value of '_licensedByOther' as parameter 'LicensedByOther' of the stored procedure.
			if(_licensedByOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensedByOther", _licensedByOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensedByOther", DBNull.Value );
              
			// Pass the value of '_licensureEffectiveDate' as parameter 'LicensureEffectiveDate' of the stored procedure.
			if(_licensureEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", _licensureEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", DBNull.Value );
              
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			if(_numActivePatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumActivePatients", DBNull.Value );
              
			// Pass the value of '_numRadiologicTechBsba' as parameter 'NumRadiologicTechBsba' of the stored procedure.
			if(_numRadiologicTechBsbaNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechBsba", _numRadiologicTechBsbaNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechBsba", DBNull.Value );
              
			// Pass the value of '_numRadiologicTechAS' as parameter 'NumRadiologicTechAS' of the stored procedure.
			if(_numRadiologicTechASNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechAS", _numRadiologicTechASNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechAS", DBNull.Value );
              
			// Pass the value of '_numRadiologicTechCrt' as parameter 'NumRadiologicTechCrt' of the stored procedure.
			if(_numRadiologicTechCrtNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechCrt", _numRadiologicTechCrtNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechCrt", DBNull.Value );
              
			// Pass the value of '_numRadiologicTechOther' as parameter 'NumRadiologicTechOther' of the stored procedure.
			if(_numRadiologicTechOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechOther", _numRadiologicTechOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechOther", DBNull.Value );
              
			// Pass the value of '_isolationNumOfStations' as parameter 'IsolationNumOfStations' of the stored procedure.
			if(_isolationNumOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsolationNumOfStations", _isolationNumOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsolationNumOfStations", DBNull.Value );
              
			// Pass the value of '_relatedProviderName' as parameter 'RelatedProviderName' of the stored procedure.
			if(_relatedProviderNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@RelatedProviderName", _relatedProviderNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@RelatedProviderName", DBNull.Value );
              
			// Pass the value of '_numOperatingRooms' as parameter 'NumOperatingRooms' of the stored procedure.
			if(_numOperatingRoomsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOperatingRooms", _numOperatingRoomsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOperatingRooms", DBNull.Value );
              
			// Pass the value of '_admMultiFacYN' as parameter 'AdmMultiFacYN' of the stored procedure.
			if(_admMultiFacYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdmMultiFacYN", _admMultiFacYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdmMultiFacYN", DBNull.Value );
              
			// Pass the value of '_admMultiFacOtherName' as parameter 'AdmMultiFacOtherName' of the stored procedure.
			if(_admMultiFacOtherNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdmMultiFacOtherName", _admMultiFacOtherNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdmMultiFacOtherName", DBNull.Value );
              
			// Pass the value of '_singleStoryYN' as parameter 'SingleStoryYN' of the stored procedure.
			if(_singleStoryYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@SingleStoryYN", _singleStoryYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@SingleStoryYN", DBNull.Value );
              
			// Pass the value of '_closedDate' as parameter 'ClosedDate' of the stored procedure.
			if(_closedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ClosedDate", _closedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ClosedDate", DBNull.Value );

            // Pass the value of '_year2ReviewDateDue' as parameter 'Year2ReviewDateDue' of the stored procedure.
            if (_year2ReviewDateDueNonDefault != null)
                oDatabaseHelper.AddParameter("@Year2ReviewDateDue", _year2ReviewDateDueNonDefault);
            else
                oDatabaseHelper.AddParameter("@Year2ReviewDateDue", DBNull.Value);
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_PROVIDERS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
				if (dr.Read())
				{
					PopulateObjectFromReader(this,dr);
				}
				dr.Close();
			}
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will insert one new row into the database using the property Information
		/// </summary>
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
			// Pass the value of '_aspenIntID' as parameter 'AspenIntID' of the stored procedure.
			if(_aspenIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AspenIntID", _aspenIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AspenIntID", DBNull.Value );
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
			// Pass the value of '_programStaffID' as parameter 'ProgramStaffID' of the stored procedure.
			if(_programStaffIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramStaffID", _programStaffIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramStaffID", DBNull.Value );
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			if(_parishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ParishCode", DBNull.Value );
			// Pass the value of '_regionCode' as parameter 'RegionCode' of the stored procedure.
			if(_regionCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@RegionCode", _regionCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@RegionCode", DBNull.Value );
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			if(_federalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@FederalID", DBNull.Value );
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			if(_licensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureNum", DBNull.Value );
			// Pass the value of '_geographicalStreetAddr2' as parameter 'GeographicalStreetAddr2' of the stored procedure.
			if(_geographicalStreetAddr2NonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalStreetAddr2", _geographicalStreetAddr2NonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalStreetAddr2", DBNull.Value );
			// Pass the value of '_schoolID' as parameter 'SchoolID' of the stored procedure.
			if(_schoolIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@SchoolID", _schoolIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@SchoolID", DBNull.Value );
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			if(_facilityNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityName", DBNull.Value );
			// Pass the value of '_legalName' as parameter 'LegalName' of the stored procedure.
			if(_legalNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@LegalName", _legalNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@LegalName", DBNull.Value );
			// Pass the value of '_mailStreet2' as parameter 'MailStreet2' of the stored procedure.
			if(_mailStreet2NonDefault!=null)
              oDatabaseHelper.AddParameter("@MailStreet2", _mailStreet2NonDefault);
            else
              oDatabaseHelper.AddParameter("@MailStreet2", DBNull.Value );
			// Pass the value of '_geographicalStreet' as parameter 'GeographicalStreet' of the stored procedure.
			if(_geographicalStreetNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalStreet", _geographicalStreetNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalStreet", DBNull.Value );
			// Pass the value of '_geographicalCity' as parameter 'GeographicalCity' of the stored procedure.
			if(_geographicalCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalCity", _geographicalCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalCity", DBNull.Value );
			// Pass the value of '_geographicalZip' as parameter 'GeographicalZip' of the stored procedure.
			if(_geographicalZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalZip", _geographicalZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalZip", DBNull.Value );
			// Pass the value of '_geographicalState' as parameter 'GeographicalState' of the stored procedure.
			if(_geographicalStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeographicalState", _geographicalStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeographicalState", DBNull.Value );
			// Pass the value of '_mailStreet' as parameter 'MailStreet' of the stored procedure.
			if(_mailStreetNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailStreet", _mailStreetNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailStreet", DBNull.Value );
			// Pass the value of '_mailCity' as parameter 'MailCity' of the stored procedure.
			if(_mailCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailCity", _mailCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailCity", DBNull.Value );
			// Pass the value of '_mailState' as parameter 'MailState' of the stored procedure.
			if(_mailStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailState", _mailStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailState", DBNull.Value );
			// Pass the value of '_mailZip' as parameter 'MailZip' of the stored procedure.
			if(_mailZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@MailZip", _mailZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@MailZip", DBNull.Value );
			// Pass the value of '_emsParishCode' as parameter 'EmsParishCode' of the stored procedure.
			if(_emsParishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmsParishCode", _emsParishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmsParishCode", DBNull.Value );
			// Pass the value of '_parish' as parameter 'Parish' of the stored procedure.
			if(_parishNonDefault!=null)
              oDatabaseHelper.AddParameter("@Parish", _parishNonDefault);
            else
              oDatabaseHelper.AddParameter("@Parish", DBNull.Value );
			// Pass the value of '_regionalOffice' as parameter 'RegionalOffice' of the stored procedure.
			if(_regionalOfficeNonDefault!=null)
              oDatabaseHelper.AddParameter("@RegionalOffice", _regionalOfficeNonDefault);
            else
              oDatabaseHelper.AddParameter("@RegionalOffice", DBNull.Value );
			// Pass the value of '_zoneNumCode' as parameter 'ZoneNumCode' of the stored procedure.
			if(_zoneNumCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ZoneNumCode", _zoneNumCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ZoneNumCode", DBNull.Value );
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			if(_telephoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@TelephoneNumber", DBNull.Value );
			// Pass the value of '_emergencyPhoneNumber' as parameter 'EmergencyPhoneNumber' of the stored procedure.
			if(_emergencyPhoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmergencyPhoneNumber", _emergencyPhoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmergencyPhoneNumber", DBNull.Value );
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			if(_faxPhoneNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaxPhoneNumber", DBNull.Value );
			// Pass the value of '_administrator' as parameter 'Administrator' of the stored procedure.
			if(_administratorNonDefault!=null)
              oDatabaseHelper.AddParameter("@Administrator", _administratorNonDefault);
            else
              oDatabaseHelper.AddParameter("@Administrator", DBNull.Value );
			// Pass the value of '_administratorTitle' as parameter 'AdministratorTitle' of the stored procedure.
			if(_administratorTitleNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorTitle", _administratorTitleNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorTitle", DBNull.Value );
			// Pass the value of '_administratorFirstName' as parameter 'AdministratorFirstName' of the stored procedure.
			if(_administratorFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorFirstName", _administratorFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorFirstName", DBNull.Value );
			// Pass the value of '_administratorMidInit' as parameter 'AdministratorMidInit' of the stored procedure.
			if(_administratorMidInitNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorMidInit", _administratorMidInitNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorMidInit", DBNull.Value );
			// Pass the value of '_administratorLastName' as parameter 'AdministratorLastName' of the stored procedure.
			if(_administratorLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdministratorLastName", _administratorLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdministratorLastName", DBNull.Value );
			// Pass the value of '_contactName' as parameter 'ContactName' of the stored procedure.
			if(_contactNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ContactName", _contactNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ContactName", DBNull.Value );
			// Pass the value of '_stateIdMds' as parameter 'StateIdMds' of the stored procedure.
			if(_stateIdMdsNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateIdMds", _stateIdMdsNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateIdMds", DBNull.Value );
			// Pass the value of '_stateLicNum' as parameter 'StateLicNum' of the stored procedure.
			if(_stateLicNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateLicNum", _stateLicNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateLicNum", DBNull.Value );
			// Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
			if(_emailAddressNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmailAddress", _emailAddressNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmailAddress", DBNull.Value );
			// Pass the value of '_medicaidVendorNumber' as parameter 'MedicaidVendorNumber' of the stored procedure.
			if(_medicaidVendorNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", _medicaidVendorNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicaidVendorNumber", DBNull.Value );
			// Pass the value of '_fieldOfficeCode' as parameter 'FieldOfficeCode' of the stored procedure.
			if(_fieldOfficeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FieldOfficeCode", _fieldOfficeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FieldOfficeCode", DBNull.Value );
			// Pass the value of '_medicalDirectorFullName' as parameter 'MedicalDirectorFullName' of the stored procedure.
			if(_medicalDirectorFullNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorFullName", _medicalDirectorFullNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorFullName", DBNull.Value );
			// Pass the value of '_medicalDirectorTitle' as parameter 'MedicalDirectorTitle' of the stored procedure.
			if(_medicalDirectorTitleNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorTitle", _medicalDirectorTitleNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorTitle", DBNull.Value );
			// Pass the value of '_medicalDirFirstName' as parameter 'MedicalDirFirstName' of the stored procedure.
			if(_medicalDirFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirFirstName", _medicalDirFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirFirstName", DBNull.Value );
			// Pass the value of '_medicalDirMidInit' as parameter 'MedicalDirMidInit' of the stored procedure.
			if(_medicalDirMidInitNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirMidInit", _medicalDirMidInitNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirMidInit", DBNull.Value );
			// Pass the value of '_medicalDirLastName' as parameter 'MedicalDirLastName' of the stored procedure.
			if(_medicalDirLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirLastName", _medicalDirLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirLastName", DBNull.Value );
			// Pass the value of '_medicalDirectorMailAddr1' as parameter 'MedicalDirectorMailAddr1' of the stored procedure.
			if(_medicalDirectorMailAddr1NonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr1", _medicalDirectorMailAddr1NonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr1", DBNull.Value );
			// Pass the value of '_medicalDirectorMailAddr2' as parameter 'MedicalDirectorMailAddr2' of the stored procedure.
			if(_medicalDirectorMailAddr2NonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr2", _medicalDirectorMailAddr2NonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr2", DBNull.Value );
			// Pass the value of '_medicalDirectorMailCity' as parameter 'MedicalDirectorMailCity' of the stored procedure.
			if(_medicalDirectorMailCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailCity", _medicalDirectorMailCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailCity", DBNull.Value );
			// Pass the value of '_medicalDirectorMailState' as parameter 'MedicalDirectorMailState' of the stored procedure.
			if(_medicalDirectorMailStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailState", _medicalDirectorMailStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailState", DBNull.Value );
			// Pass the value of '_medicalDirectorMailZip' as parameter 'MedicalDirectorMailZip' of the stored procedure.
			if(_medicalDirectorMailZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalDirectorMailZip", _medicalDirectorMailZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalDirectorMailZip", DBNull.Value );
			// Pass the value of '_hoursMinutes' as parameter 'HoursMinutes' of the stored procedure.
			if(_hoursMinutesNonDefault!=null)
              oDatabaseHelper.AddParameter("@HoursMinutes", _hoursMinutesNonDefault);
            else
              oDatabaseHelper.AddParameter("@HoursMinutes", DBNull.Value );
			// Pass the value of '_snf18beds' as parameter 'Snf18beds' of the stored procedure.
			if(_snf18bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf18beds", _snf18bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf18beds", DBNull.Value );
			// Pass the value of '_amPM' as parameter 'AmPM' of the stored procedure.
			if(_amPMNonDefault!=null)
              oDatabaseHelper.AddParameter("@AmPM", _amPMNonDefault);
            else
              oDatabaseHelper.AddParameter("@AmPM", DBNull.Value );
			// Pass the value of '_hoursMinutes1' as parameter 'HoursMinutes1' of the stored procedure.
			if(_hoursMinutes1NonDefault!=null)
              oDatabaseHelper.AddParameter("@HoursMinutes1", _hoursMinutes1NonDefault);
            else
              oDatabaseHelper.AddParameter("@HoursMinutes1", DBNull.Value );
			// Pass the value of '_amPm1' as parameter 'AmPm1' of the stored procedure.
			if(_amPm1NonDefault!=null)
              oDatabaseHelper.AddParameter("@AmPm1", _amPm1NonDefault);
            else
              oDatabaseHelper.AddParameter("@AmPm1", DBNull.Value );
			// Pass the value of '_dayOfOperationMon' as parameter 'DayOfOperationMon' of the stored procedure.
			if(_dayOfOperationMonNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationMon", _dayOfOperationMonNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationMon", DBNull.Value );
			// Pass the value of '_dayOfOperationTue' as parameter 'DayOfOperationTue' of the stored procedure.
			if(_dayOfOperationTueNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationTue", _dayOfOperationTueNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationTue", DBNull.Value );
			// Pass the value of '_dayOfOperationWed' as parameter 'DayOfOperationWed' of the stored procedure.
			if(_dayOfOperationWedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationWed", _dayOfOperationWedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationWed", DBNull.Value );
			// Pass the value of '_dayOfOperationThu' as parameter 'DayOfOperationThu' of the stored procedure.
			if(_dayOfOperationThuNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationThu", _dayOfOperationThuNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationThu", DBNull.Value );
			// Pass the value of '_dayOfOperationFri' as parameter 'DayOfOperationFri' of the stored procedure.
			if(_dayOfOperationFriNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationFri", _dayOfOperationFriNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationFri", DBNull.Value );
			// Pass the value of '_dayOfOperationSat' as parameter 'DayOfOperationSat' of the stored procedure.
			if(_dayOfOperationSatNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationSat", _dayOfOperationSatNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationSat", DBNull.Value );
			// Pass the value of '_dayOfOperationSun' as parameter 'DayOfOperationSun' of the stored procedure.
			if(_dayOfOperationSunNonDefault!=null)
              oDatabaseHelper.AddParameter("@DayOfOperationSun", _dayOfOperationSunNonDefault);
            else
              oDatabaseHelper.AddParameter("@DayOfOperationSun", DBNull.Value );
			// Pass the value of '_typeLicenseCode' as parameter 'TypeLicenseCode' of the stored procedure.
			if(_typeLicenseCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeLicenseCode", _typeLicenseCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeLicenseCode", DBNull.Value );
			// Pass the value of '_typeOfLicense' as parameter 'TypeOfLicense' of the stored procedure.
			if(_typeOfLicenseNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfLicense", _typeOfLicenseNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfLicense", DBNull.Value );
			// Pass the value of '_typeFacilityCode' as parameter 'TypeFacilityCode' of the stored procedure.
			if(_typeFacilityCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacilityCode", _typeFacilityCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacilityCode", DBNull.Value );
			// Pass the value of '_typeFacility1Code' as parameter 'TypeFacility1Code' of the stored procedure.
			if(_typeFacility1CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility1Code", _typeFacility1CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility1Code", DBNull.Value );
			// Pass the value of '_typeFacility2Code' as parameter 'TypeFacility2Code' of the stored procedure.
			if(_typeFacility2CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility2Code", _typeFacility2CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility2Code", DBNull.Value );
			// Pass the value of '_typeFacility3Code' as parameter 'TypeFacility3Code' of the stored procedure.
			if(_typeFacility3CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility3Code", _typeFacility3CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility3Code", DBNull.Value );
			// Pass the value of '_typeFacility4Code' as parameter 'TypeFacility4Code' of the stored procedure.
			if(_typeFacility4CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility4Code", _typeFacility4CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility4Code", DBNull.Value );
			// Pass the value of '_typeFacility5Code' as parameter 'TypeFacility5Code' of the stored procedure.
			if(_typeFacility5CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility5Code", _typeFacility5CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility5Code", DBNull.Value );
			// Pass the value of '_typeFacility6Code' as parameter 'TypeFacility6Code' of the stored procedure.
			if(_typeFacility6CodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility6Code", _typeFacility6CodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility6Code", DBNull.Value );
			// Pass the value of '_licensedSnfFacility' as parameter 'LicensedSnfFacility' of the stored procedure.
			if(_licensedSnfFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", _licensedSnfFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", DBNull.Value );
			// Pass the value of '_snf1819beds' as parameter 'Snf1819beds' of the stored procedure.
			if(_snf1819bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf1819beds", _snf1819bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf1819beds", DBNull.Value );
			// Pass the value of '_snf19beds' as parameter 'Snf19beds' of the stored procedure.
			if(_snf19bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf19beds", _snf19bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf19beds", DBNull.Value );
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			if(_typeOfClientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfClients", DBNull.Value );
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			if(_psychiatricBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBeds", DBNull.Value );
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			if(_snfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBeds", DBNull.Value );
			// Pass the value of '_swingBeds' as parameter 'SwingBeds' of the stored procedure.
			if(_swingBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@SwingBeds", _swingBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@SwingBeds", DBNull.Value );
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			if(_rehabilitationBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabilitationBeds", DBNull.Value );
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			if(_totalLicBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBeds", DBNull.Value );
			// Pass the value of '_bedsCertified' as parameter 'BedsCertified' of the stored procedure.
			if(_bedsCertifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsCertified", _bedsCertifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsCertified", DBNull.Value );
			// Pass the value of '_typeOwnershipCode' as parameter 'TypeOwnershipCode' of the stored procedure.
			if(_typeOwnershipCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOwnershipCode", _typeOwnershipCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOwnershipCode", DBNull.Value );
			// Pass the value of '_nameOfCorporation' as parameter 'NameOfCorporation' of the stored procedure.
			if(_nameOfCorporationNonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfCorporation", _nameOfCorporationNonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfCorporation", DBNull.Value );
			// Pass the value of '_corporationIdNum' as parameter 'CorporationIdNum' of the stored procedure.
			if(_corporationIdNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationIdNum", _corporationIdNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationIdNum", DBNull.Value );
			// Pass the value of '_corporationStreet' as parameter 'CorporationStreet' of the stored procedure.
			if(_corporationStreetNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationStreet", _corporationStreetNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationStreet", DBNull.Value );
			// Pass the value of '_corporationCity' as parameter 'CorporationCity' of the stored procedure.
			if(_corporationCityNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationCity", _corporationCityNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationCity", DBNull.Value );
			// Pass the value of '_corporationState' as parameter 'CorporationState' of the stored procedure.
			if(_corporationStateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationState", _corporationStateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationState", DBNull.Value );
			// Pass the value of '_corporationZip' as parameter 'CorporationZip' of the stored procedure.
			if(_corporationZipNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationZip", _corporationZipNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationZip", DBNull.Value );
			// Pass the value of '_corporationPhone' as parameter 'CorporationPhone' of the stored procedure.
			if(_corporationPhoneNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationPhone", _corporationPhoneNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationPhone", DBNull.Value );
			// Pass the value of '_corporationFax' as parameter 'CorporationFax' of the stored procedure.
			if(_corporationFaxNonDefault!=null)
              oDatabaseHelper.AddParameter("@CorporationFax", _corporationFaxNonDefault);
            else
              oDatabaseHelper.AddParameter("@CorporationFax", DBNull.Value );
			// Pass the value of '_nameOfOwner1' as parameter 'NameOfOwner1' of the stored procedure.
			if(_nameOfOwner1NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner1", _nameOfOwner1NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner1", DBNull.Value );
			// Pass the value of '_nameOfOwner2' as parameter 'NameOfOwner2' of the stored procedure.
			if(_nameOfOwner2NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner2", _nameOfOwner2NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner2", DBNull.Value );
			// Pass the value of '_nameOfOwner3' as parameter 'NameOfOwner3' of the stored procedure.
			if(_nameOfOwner3NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner3", _nameOfOwner3NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner3", DBNull.Value );
			// Pass the value of '_nameOfOwner4' as parameter 'NameOfOwner4' of the stored procedure.
			if(_nameOfOwner4NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameOfOwner4", _nameOfOwner4NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameOfOwner4", DBNull.Value );
			// Pass the value of '_presidentName' as parameter 'PresidentName' of the stored procedure.
			if(_presidentNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@PresidentName", _presidentNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@PresidentName", DBNull.Value );
			// Pass the value of '_vicePresidentName' as parameter 'VicePresidentName' of the stored procedure.
			if(_vicePresidentNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@VicePresidentName", _vicePresidentNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@VicePresidentName", DBNull.Value );
			// Pass the value of '_secretaryTreasurerName' as parameter 'SecretaryTreasurerName' of the stored procedure.
			if(_secretaryTreasurerNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@SecretaryTreasurerName", _secretaryTreasurerNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@SecretaryTreasurerName", DBNull.Value );
			// Pass the value of '_jcahYN' as parameter 'JcahYN' of the stored procedure.
			if(_jcahYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@JcahYN", _jcahYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@JcahYN", DBNull.Value );
			// Pass the value of '_changeOfOwnerDate' as parameter 'ChangeOfOwnerDate' of the stored procedure.
			if(_changeOfOwnerDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfOwnerDate", _changeOfOwnerDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfOwnerDate", DBNull.Value );
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			if(_originalLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", DBNull.Value );
			// Pass the value of '_originalEnrollmentDate' as parameter 'OriginalEnrollmentDate' of the stored procedure.
			if(_originalEnrollmentDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", _originalEnrollmentDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", DBNull.Value );
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			if(_currentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", DBNull.Value );
			// Pass the value of '_licensureExpirationDate' as parameter 'LicensureExpirationDate' of the stored procedure.
			if(_licensureExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", _licensureExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", DBNull.Value );
			// Pass the value of '_licensureAnniversaryMth' as parameter 'LicensureAnniversaryMth' of the stored procedure.
			if(_licensureAnniversaryMthNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureAnniversaryMth", _licensureAnniversaryMthNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureAnniversaryMth", DBNull.Value );
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
			// Pass the value of '_capacityInHome' as parameter 'CapacityInHome' of the stored procedure.
			if(_capacityInHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityInHome", _capacityInHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityInHome", DBNull.Value );
			// Pass the value of '_capacityOutOfHome' as parameter 'CapacityOutOfHome' of the stored procedure.
			if(_capacityOutOfHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityOutOfHome", _capacityOutOfHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityOutOfHome", DBNull.Value );
			// Pass the value of '_ageRange' as parameter 'AgeRange' of the stored procedure.
			if(_ageRangeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRange", _ageRangeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRange", DBNull.Value );
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			if(_unitNonDefault!=null)
              oDatabaseHelper.AddParameter("@Unit", _unitNonDefault);
            else
              oDatabaseHelper.AddParameter("@Unit", DBNull.Value );
			// Pass the value of '_forYearEndingMmdd' as parameter 'ForYearEndingMmdd' of the stored procedure.
			if(_forYearEndingMmddNonDefault!=null)
              oDatabaseHelper.AddParameter("@ForYearEndingMmdd", _forYearEndingMmddNonDefault);
            else
              oDatabaseHelper.AddParameter("@ForYearEndingMmdd", DBNull.Value );
			// Pass the value of '_hospitalBasedYN' as parameter 'HospitalBasedYN' of the stored procedure.
			if(_hospitalBasedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@HospitalBasedYN", _hospitalBasedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@HospitalBasedYN", DBNull.Value );
			// Pass the value of '_applicationDate' as parameter 'ApplicationDate' of the stored procedure.
			if(_applicationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationDate", _applicationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationDate", DBNull.Value );
			// Pass the value of '_fee' as parameter 'Fee' of the stored procedure.
			if(_feeNonDefault!=null)
              oDatabaseHelper.AddParameter("@Fee", _feeNonDefault);
            else
              oDatabaseHelper.AddParameter("@Fee", DBNull.Value );
			// Pass the value of '_checkNumber' as parameter 'CheckNumber' of the stored procedure.
			if(_checkNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@CheckNumber", _checkNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@CheckNumber", DBNull.Value );
			// Pass the value of '_dateFeeReceived' as parameter 'DateFeeReceived' of the stored procedure.
			if(_dateFeeReceivedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateFeeReceived", _dateFeeReceivedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateFeeReceived", DBNull.Value );
			// Pass the value of '_stateFireApprovalDate' as parameter 'StateFireApprovalDate' of the stored procedure.
			if(_stateFireApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", _stateFireApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", DBNull.Value );
			// Pass the value of '_healthApprovalDate' as parameter 'HealthApprovalDate' of the stored procedure.
			if(_healthApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@HealthApprovalDate", _healthApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@HealthApprovalDate", DBNull.Value );
			// Pass the value of '_curSurv' as parameter 'CurSurv' of the stored procedure.
			if(_curSurvNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurSurv", _curSurvNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurSurv", DBNull.Value );
			// Pass the value of '_usDeaRegNum' as parameter 'UsDeaRegNum' of the stored procedure.
			if(_usDeaRegNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@UsDeaRegNum", _usDeaRegNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@UsDeaRegNum", DBNull.Value );
			// Pass the value of '_usDeaRegNumExpDate' as parameter 'UsDeaRegNumExpDate' of the stored procedure.
			if(_usDeaRegNumExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@UsDeaRegNumExpDate", _usDeaRegNumExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@UsDeaRegNumExpDate", DBNull.Value );
			// Pass the value of '_laCdsNum' as parameter 'LaCdsNum' of the stored procedure.
			if(_laCdsNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@LaCdsNum", _laCdsNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@LaCdsNum", DBNull.Value );
			// Pass the value of '_laCdsNumExpDate' as parameter 'LaCdsNumExpDate' of the stored procedure.
			if(_laCdsNumExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LaCdsNumExpDate", _laCdsNumExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LaCdsNumExpDate", DBNull.Value );
			// Pass the value of '_cliaIdNum' as parameter 'CliaIdNum' of the stored procedure.
			if(_cliaIdNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@CliaIdNum", _cliaIdNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@CliaIdNum", DBNull.Value );
			// Pass the value of '_cliaExpDate' as parameter 'CliaExpDate' of the stored procedure.
			if(_cliaExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CliaExpDate", _cliaExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CliaExpDate", DBNull.Value );
			// Pass the value of '_certEffectiveDate' as parameter 'CertEffectiveDate' of the stored procedure.
			if(_certEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertEffectiveDate", _certEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertEffectiveDate", DBNull.Value );
			// Pass the value of '_certifExpirationDate' as parameter 'CertifExpirationDate' of the stored procedure.
			if(_certifExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertifExpirationDate", _certifExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertifExpirationDate", DBNull.Value );
			// Pass the value of '_certificationMth' as parameter 'CertificationMth' of the stored procedure.
			if(_certificationMthNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertificationMth", _certificationMthNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertificationMth", DBNull.Value );
			// Pass the value of '_levelCode' as parameter 'LevelCode' of the stored procedure.
			if(_levelCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LevelCode", _levelCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LevelCode", DBNull.Value );
			// Pass the value of '_noOfAirAmbulances' as parameter 'NoOfAirAmbulances' of the stored procedure.
			if(_noOfAirAmbulancesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfAirAmbulances", _noOfAirAmbulancesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfAirAmbulances", DBNull.Value );
			// Pass the value of '_noOfGroundAmbulances' as parameter 'NoOfGroundAmbulances' of the stored procedure.
			if(_noOfGroundAmbulancesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfGroundAmbulances", _noOfGroundAmbulancesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfGroundAmbulances", DBNull.Value );
			// Pass the value of '_noOfSprintVehicles' as parameter 'NoOfSprintVehicles' of the stored procedure.
			if(_noOfSprintVehiclesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfSprintVehicles", _noOfSprintVehiclesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfSprintVehicles", DBNull.Value );
			// Pass the value of '_noOfAmbulatoryVehicles' as parameter 'NoOfAmbulatoryVehicles' of the stored procedure.
			if(_noOfAmbulatoryVehiclesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfAmbulatoryVehicles", _noOfAmbulatoryVehiclesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfAmbulatoryVehicles", DBNull.Value );
			// Pass the value of '_totalDailyCapacityAmbulatoryVehicle' as parameter 'TotalDailyCapacityAmbulatoryVehicle' of the stored procedure.
			if(_totalDailyCapacityAmbulatoryVehicleNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalDailyCapacityAmbulatoryVehicle", _totalDailyCapacityAmbulatoryVehicleNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalDailyCapacityAmbulatoryVehicle", DBNull.Value );
			// Pass the value of '_noOfHandicappedVehicles' as parameter 'NoOfHandicappedVehicles' of the stored procedure.
			if(_noOfHandicappedVehiclesNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfHandicappedVehicles", _noOfHandicappedVehiclesNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfHandicappedVehicles", DBNull.Value );
			// Pass the value of '_totalDailyCapacityHandicappedVehicle' as parameter 'TotalDailyCapacityHandicappedVehicle' of the stored procedure.
			if(_totalDailyCapacityHandicappedVehicleNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalDailyCapacityHandicappedVehicle", _totalDailyCapacityHandicappedVehicleNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalDailyCapacityHandicappedVehicle", DBNull.Value );
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			if(_numberOfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberOfBeds", DBNull.Value );
			// Pass the value of '_automobileInsuranceCoverageLimit' as parameter 'AutomobileInsuranceCoverageLimit' of the stored procedure.
			if(_automobileInsuranceCoverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCoverageLimit", _automobileInsuranceCoverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCoverageLimit", DBNull.Value );
			// Pass the value of '_automobileInsuranceCarrierCode' as parameter 'AutomobileInsuranceCarrierCode' of the stored procedure.
			if(_automobileInsuranceCarrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCarrierCode", _automobileInsuranceCarrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsuranceCarrierCode", DBNull.Value );
			// Pass the value of '_automobileInsurancePolicyNum' as parameter 'AutomobileInsurancePolicyNum' of the stored procedure.
			if(_automobileInsurancePolicyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsurancePolicyNum", _automobileInsurancePolicyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsurancePolicyNum", DBNull.Value );
			// Pass the value of '_automobileInsuranceExpirationDate' as parameter 'AutomobileInsuranceExpirationDate' of the stored procedure.
			if(_automobileInsuranceExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsuranceExpirationDate", _automobileInsuranceExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsuranceExpirationDate", DBNull.Value );
			// Pass the value of '_generalLiabilityCoverageLimit' as parameter 'GeneralLiabilityCoverageLimit' of the stored procedure.
			if(_generalLiabilityCoverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityCoverageLimit", _generalLiabilityCoverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityCoverageLimit", DBNull.Value );
			// Pass the value of '_generalLiabilityCarrierCode' as parameter 'GeneralLiabilityCarrierCode' of the stored procedure.
			if(_generalLiabilityCarrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityCarrierCode", _generalLiabilityCarrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityCarrierCode", DBNull.Value );
			// Pass the value of '_generalLiabilityPolicyNum' as parameter 'GeneralLiabilityPolicyNum' of the stored procedure.
			if(_generalLiabilityPolicyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityPolicyNum", _generalLiabilityPolicyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityPolicyNum", DBNull.Value );
			// Pass the value of '_facilityWithinFacilityYN' as parameter 'FacilityWithinFacilityYN' of the stored procedure.
			if(_facilityWithinFacilityYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", _facilityWithinFacilityYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", DBNull.Value );
			// Pass the value of '_generalLiabilityExpirationDate' as parameter 'GeneralLiabilityExpirationDate' of the stored procedure.
			if(_generalLiabilityExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityExpirationDate", _generalLiabilityExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityExpirationDate", DBNull.Value );
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			if(_otherBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBeds", DBNull.Value );
			// Pass the value of '_medicalMalpracticeCoverageLimit' as parameter 'MedicalMalpracticeCoverageLimit' of the stored procedure.
			if(_medicalMalpracticeCoverageLimitNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCoverageLimit", _medicalMalpracticeCoverageLimitNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCoverageLimit", DBNull.Value );
			// Pass the value of '_unitsNumTotal' as parameter 'UnitsNumTotal' of the stored procedure.
			if(_unitsNumTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumTotal", _unitsNumTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumTotal", DBNull.Value );
			// Pass the value of '_medicalMalpracticeCarrierCode' as parameter 'MedicalMalpracticeCarrierCode' of the stored procedure.
			if(_medicalMalpracticeCarrierCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCarrierCode", _medicalMalpracticeCarrierCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticeCarrierCode", DBNull.Value );
			// Pass the value of '_totalLicBedsTotal' as parameter 'TotalLicBedsTotal' of the stored procedure.
			if(_totalLicBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", _totalLicBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", DBNull.Value );
			// Pass the value of '_medicalMalpracticePolicyNum' as parameter 'MedicalMalpracticePolicyNum' of the stored procedure.
			if(_medicalMalpracticePolicyNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticePolicyNum", _medicalMalpracticePolicyNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticePolicyNum", DBNull.Value );
			// Pass the value of '_psychiatricBedsTotal' as parameter 'PsychiatricBedsTotal' of the stored procedure.
			if(_psychiatricBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", _psychiatricBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", DBNull.Value );
			// Pass the value of '_medicalMalpracticeExpirationDate' as parameter 'MedicalMalpracticeExpirationDate' of the stored procedure.
			if(_medicalMalpracticeExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicalMalpracticeExpirationDate", _medicalMalpracticeExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicalMalpracticeExpirationDate", DBNull.Value );
			// Pass the value of '_isolationUnitYN' as parameter 'IsolationUnitYN' of the stored procedure.
			if(_isolationUnitYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsolationUnitYN", _isolationUnitYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsolationUnitYN", DBNull.Value );
			// Pass the value of '_rehabilitationBedsTotal' as parameter 'RehabilitationBedsTotal' of the stored procedure.
			if(_rehabilitationBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabilitationBedsTotal", _rehabilitationBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabilitationBedsTotal", DBNull.Value );
			// Pass the value of '_snfBedsTotal' as parameter 'SnfBedsTotal' of the stored procedure.
			if(_snfBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBedsTotal", _snfBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBedsTotal", DBNull.Value );
			// Pass the value of '_statusCode' as parameter 'StatusCode' of the stored procedure.
			if(_statusCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusCode", _statusCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusCode", DBNull.Value );
			// Pass the value of '_unitsNumOffsiteTotal' as parameter 'UnitsNumOffsiteTotal' of the stored procedure.
			if(_unitsNumOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", _unitsNumOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", DBNull.Value );
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			if(_statusDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusDate", DBNull.Value );
			// Pass the value of '_totalLicBedsOffsiteTotal' as parameter 'TotalLicBedsOffsiteTotal' of the stored procedure.
			if(_totalLicBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", _totalLicBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_noOfParishesServed' as parameter 'NoOfParishesServed' of the stored procedure.
			if(_noOfParishesServedNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfParishesServed", _noOfParishesServedNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfParishesServed", DBNull.Value );
			// Pass the value of '_psychiatricBedsOffsiteTotal' as parameter 'PsychiatricBedsOffsiteTotal' of the stored procedure.
			if(_psychiatricBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", _psychiatricBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_licensureSurveyDate' as parameter 'LicensureSurveyDate' of the stored procedure.
			if(_licensureSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", _licensureSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", DBNull.Value );
			// Pass the value of '_rehabBedsOffsiteTotal' as parameter 'RehabBedsOffsiteTotal' of the stored procedure.
			if(_rehabBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", _rehabBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_waivers' as parameter 'Waivers' of the stored procedure.
			if(_waiversNonDefault!=null)
              oDatabaseHelper.AddParameter("@Waivers", _waiversNonDefault);
            else
              oDatabaseHelper.AddParameter("@Waivers", DBNull.Value );
			// Pass the value of '_snfBedsOffsiteTotal' as parameter 'SnfBedsOffsiteTotal' of the stored procedure.
			if(_snfBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@SnfBedsOffsiteTotal", _snfBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@SnfBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_otherBedsOffsiteTotal' as parameter 'OtherBedsOffsiteTotal' of the stored procedure.
			if(_otherBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBedsOffsiteTotal", _otherBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_psychPpsFederalID' as parameter 'PsychPpsFederalID' of the stored procedure.
			if(_psychPpsFederalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychPpsFederalID", _psychPpsFederalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychPpsFederalID", DBNull.Value );
			// Pass the value of '_rehabPpsFederalID' as parameter 'RehabPpsFederalID' of the stored procedure.
			if(_rehabPpsFederalIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabPpsFederalID", _rehabPpsFederalIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabPpsFederalID", DBNull.Value );
			// Pass the value of '_userLastMaint' as parameter 'UserLastMaint' of the stored procedure.
			if(_userLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@UserLastMaint", _userLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@UserLastMaint", DBNull.Value );
			// Pass the value of '_psychPpsCertEffectiveDate' as parameter 'PsychPpsCertEffectiveDate' of the stored procedure.
			if(_psychPpsCertEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychPpsCertEffectiveDate", _psychPpsCertEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychPpsCertEffectiveDate", DBNull.Value );
			// Pass the value of '_dateLastMaint' as parameter 'DateLastMaint' of the stored procedure.
			if(_dateLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateLastMaint", _dateLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateLastMaint", DBNull.Value );
			// Pass the value of '_rehabPpsCertEffectiveDate' as parameter 'RehabPpsCertEffectiveDate' of the stored procedure.
			if(_rehabPpsCertEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabPpsCertEffectiveDate", _rehabPpsCertEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabPpsCertEffectiveDate", DBNull.Value );
			// Pass the value of '_timeLastMaint' as parameter 'TimeLastMaint' of the stored procedure.
			if(_timeLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@TimeLastMaint", _timeLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@TimeLastMaint", DBNull.Value );
			// Pass the value of '_offsiteCampusYN' as parameter 'OffsiteCampusYN' of the stored procedure.
			if(_offsiteCampusYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@OffsiteCampusYN", _offsiteCampusYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@OffsiteCampusYN", DBNull.Value );
			// Pass the value of '_certifiedBedOverrideYN' as parameter 'CertifiedBedOverrideYN' of the stored procedure.
			if(_certifiedBedOverrideYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", _certifiedBedOverrideYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", DBNull.Value );
			// Pass the value of '_mainCampusBeds' as parameter 'MainCampusBeds' of the stored procedure.
			if(_mainCampusBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@MainCampusBeds", _mainCampusBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@MainCampusBeds", DBNull.Value );
			// Pass the value of '_forYearEndingDate' as parameter 'ForYearEndingDate' of the stored procedure.
			if(_forYearEndingDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ForYearEndingDate", _forYearEndingDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ForYearEndingDate", DBNull.Value );
			// Pass the value of '_neonatalIntCode' as parameter 'NeonatalIntCode' of the stored procedure.
			if(_neonatalIntCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NeonatalIntCode", _neonatalIntCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NeonatalIntCode", DBNull.Value );
			// Pass the value of '_servicesOffered' as parameter 'ServicesOffered' of the stored procedure.
			if(_servicesOfferedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServicesOffered", _servicesOfferedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServicesOffered", DBNull.Value );
			// Pass the value of '_picuIntCode' as parameter 'PicuIntCode' of the stored procedure.
			if(_picuIntCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@PicuIntCode", _picuIntCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@PicuIntCode", DBNull.Value );
			// Pass the value of '_halfwayHouse' as parameter 'HalfwayHouse' of the stored procedure.
			if(_halfwayHouseNonDefault!=null)
              oDatabaseHelper.AddParameter("@HalfwayHouse", _halfwayHouseNonDefault);
            else
              oDatabaseHelper.AddParameter("@HalfwayHouse", DBNull.Value );
			// Pass the value of '_deemedStatus' as parameter 'DeemedStatus' of the stored procedure.
			if(_deemedStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@DeemedStatus", _deemedStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@DeemedStatus", DBNull.Value );
			// Pass the value of '_inPatient' as parameter 'InPatient' of the stored procedure.
			if(_inPatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@InPatient", _inPatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@InPatient", DBNull.Value );
			// Pass the value of '_chapAccreditionYN' as parameter 'ChapAccreditionYN' of the stored procedure.
			if(_chapAccreditionYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", _chapAccreditionYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", DBNull.Value );
			// Pass the value of '_crisisEmergency' as parameter 'CrisisEmergency' of the stored procedure.
			if(_crisisEmergencyNonDefault!=null)
              oDatabaseHelper.AddParameter("@CrisisEmergency", _crisisEmergencyNonDefault);
            else
              oDatabaseHelper.AddParameter("@CrisisEmergency", DBNull.Value );
			// Pass the value of '_outpatientTreatment' as parameter 'OutpatientTreatment' of the stored procedure.
			if(_outpatientTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@OutpatientTreatment", _outpatientTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@OutpatientTreatment", DBNull.Value );
			// Pass the value of '_fiscalIntermediaryNum' as parameter 'FiscalIntermediaryNum' of the stored procedure.
			if(_fiscalIntermediaryNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", _fiscalIntermediaryNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", DBNull.Value );
			// Pass the value of '_methadoneTreatment' as parameter 'MethadoneTreatment' of the stored procedure.
			if(_methadoneTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@MethadoneTreatment", _methadoneTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@MethadoneTreatment", DBNull.Value );
			// Pass the value of '_attesestationStatement' as parameter 'AttesestationStatement' of the stored procedure.
			if(_attesestationStatementNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttesestationStatement", _attesestationStatementNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttesestationStatement", DBNull.Value );
			// Pass the value of '_preventionEducation' as parameter 'PreventionEducation' of the stored procedure.
			if(_preventionEducationNonDefault!=null)
              oDatabaseHelper.AddParameter("@PreventionEducation", _preventionEducationNonDefault);
            else
              oDatabaseHelper.AddParameter("@PreventionEducation", DBNull.Value );
			// Pass the value of '_attesestationStmtDateSigned' as parameter 'AttesestationStmtDateSigned' of the stored procedure.
			if(_attesestationStmtDateSignedNonDefault!=null)
              oDatabaseHelper.AddParameter("@AttesestationStmtDateSigned", _attesestationStmtDateSignedNonDefault);
            else
              oDatabaseHelper.AddParameter("@AttesestationStmtDateSigned", DBNull.Value );
			// Pass the value of '_residentialTreatment' as parameter 'ResidentialTreatment' of the stored procedure.
			if(_residentialTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@ResidentialTreatment", _residentialTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@ResidentialTreatment", DBNull.Value );
			// Pass the value of '_nameChangePrevName1' as parameter 'NameChangePrevName1' of the stored procedure.
			if(_nameChangePrevName1NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangePrevName1", _nameChangePrevName1NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangePrevName1", DBNull.Value );
			// Pass the value of '_socialSettingDetoxification' as parameter 'SocialSettingDetoxification' of the stored procedure.
			if(_socialSettingDetoxificationNonDefault!=null)
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", _socialSettingDetoxificationNonDefault);
            else
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", DBNull.Value );
			// Pass the value of '_nameChangeDate1' as parameter 'NameChangeDate1' of the stored procedure.
			if(_nameChangeDate1NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangeDate1", _nameChangeDate1NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangeDate1", DBNull.Value );
			// Pass the value of '_adultHealthCare' as parameter 'AdultHealthCare' of the stored procedure.
			if(_adultHealthCareNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdultHealthCare", _adultHealthCareNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdultHealthCare", DBNull.Value );
			// Pass the value of '_nameChangePrevName2' as parameter 'NameChangePrevName2' of the stored procedure.
			if(_nameChangePrevName2NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangePrevName2", _nameChangePrevName2NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangePrevName2", DBNull.Value );
			// Pass the value of '_nameChangeDate2' as parameter 'NameChangeDate2' of the stored procedure.
			if(_nameChangeDate2NonDefault!=null)
              oDatabaseHelper.AddParameter("@NameChangeDate2", _nameChangeDate2NonDefault);
            else
              oDatabaseHelper.AddParameter("@NameChangeDate2", DBNull.Value );
			// Pass the value of '_cnatTrainingCode' as parameter 'CnatTrainingCode' of the stored procedure.
			if(_cnatTrainingCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CnatTrainingCode", _cnatTrainingCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CnatTrainingCode", DBNull.Value );
			// Pass the value of '_cnatTrainingSuspendDate' as parameter 'CnatTrainingSuspendDate' of the stored procedure.
			if(_cnatTrainingSuspendDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CnatTrainingSuspendDate", _cnatTrainingSuspendDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CnatTrainingSuspendDate", DBNull.Value );
			// Pass the value of '_previousOwner1' as parameter 'PreviousOwner1' of the stored procedure.
			if(_previousOwner1NonDefault!=null)
              oDatabaseHelper.AddParameter("@PreviousOwner1", _previousOwner1NonDefault);
            else
              oDatabaseHelper.AddParameter("@PreviousOwner1", DBNull.Value );
			// Pass the value of '_prevOwnerChangeDate1' as parameter 'PrevOwnerChangeDate1' of the stored procedure.
			if(_prevOwnerChangeDate1NonDefault!=null)
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate1", _prevOwnerChangeDate1NonDefault);
            else
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate1", DBNull.Value );
			// Pass the value of '_assistDirOfNursingWaiverMonth' as parameter 'AssistDirOfNursingWaiverMonth' of the stored procedure.
			if(_assistDirOfNursingWaiverMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@AssistDirOfNursingWaiverMonth", _assistDirOfNursingWaiverMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@AssistDirOfNursingWaiverMonth", DBNull.Value );
			// Pass the value of '_day7RnWaiverMonth' as parameter 'Day7RnWaiverMonth' of the stored procedure.
			if(_day7RnWaiverMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@Day7RnWaiverMonth", _day7RnWaiverMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@Day7RnWaiverMonth", DBNull.Value );
			// Pass the value of '_previousOwner2' as parameter 'PreviousOwner2' of the stored procedure.
			if(_previousOwner2NonDefault!=null)
              oDatabaseHelper.AddParameter("@PreviousOwner2", _previousOwner2NonDefault);
            else
              oDatabaseHelper.AddParameter("@PreviousOwner2", DBNull.Value );
			// Pass the value of '_prevOwnerChangeDate2' as parameter 'PrevOwnerChangeDate2' of the stored procedure.
			if(_prevOwnerChangeDate2NonDefault!=null)
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate2", _prevOwnerChangeDate2NonDefault);
            else
              oDatabaseHelper.AddParameter("@PrevOwnerChangeDate2", DBNull.Value );
			// Pass the value of '_currentSurveyMonth' as parameter 'CurrentSurveyMonth' of the stored procedure.
			if(_currentSurveyMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", _currentSurveyMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", DBNull.Value );
			// Pass the value of '_fiscalIntermediaryDesc' as parameter 'FiscalIntermediaryDesc' of the stored procedure.
			if(_fiscalIntermediaryDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", _fiscalIntermediaryDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", DBNull.Value );
			// Pass the value of '_medicareInterPrefCode' as parameter 'MedicareInterPrefCode' of the stored procedure.
			if(_medicareInterPrefCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MedicareInterPrefCode", _medicareInterPrefCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MedicareInterPrefCode", DBNull.Value );
			// Pass the value of '_programCode' as parameter 'ProgramCode' of the stored procedure.
			if(_programCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramCode", _programCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramCode", DBNull.Value );
			// Pass the value of '_noTreatmentsPerWeek' as parameter 'NoTreatmentsPerWeek' of the stored procedure.
			if(_noTreatmentsPerWeekNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoTreatmentsPerWeek", _noTreatmentsPerWeekNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoTreatmentsPerWeek", DBNull.Value );
			// Pass the value of '_noOfStations' as parameter 'NoOfStations' of the stored procedure.
			if(_noOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfStations", _noOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfStations", DBNull.Value );
			// Pass the value of '_levelDescription' as parameter 'LevelDescription' of the stored procedure.
			if(_levelDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@LevelDescription", _levelDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@LevelDescription", DBNull.Value );
			// Pass the value of '_automaticCancellationDate' as parameter 'AutomaticCancellationDate' of the stored procedure.
			if(_automaticCancellationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomaticCancellationDate", _automaticCancellationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomaticCancellationDate", DBNull.Value );
			// Pass the value of '_noOf3hrShiftsWeek' as parameter 'NoOf3hrShiftsWeek' of the stored procedure.
			if(_noOf3hrShiftsWeekNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", _noOf3hrShiftsWeekNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", DBNull.Value );
			// Pass the value of '_fcertBeds' as parameter 'FcertBeds' of the stored procedure.
			if(_fcertBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@FcertBeds", _fcertBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@FcertBeds", DBNull.Value );
			// Pass the value of '_averageNumPatientsShift' as parameter 'AverageNumPatientsShift' of the stored procedure.
			if(_averageNumPatientsShiftNonDefault!=null)
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", _averageNumPatientsShiftNonDefault);
            else
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", DBNull.Value );
			// Pass the value of '_automobileInsurancePrepaymentDueDate' as parameter 'AutomobileInsurancePrepaymentDueDate' of the stored procedure.
			if(_automobileInsurancePrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", _automobileInsurancePrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", DBNull.Value );
			// Pass the value of '_vendorNum' as parameter 'VendorNum' of the stored procedure.
			if(_vendorNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@VendorNum", _vendorNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@VendorNum", DBNull.Value );
			// Pass the value of '_generalLiabilityPrepaymentDueDate' as parameter 'GeneralLiabilityPrepaymentDueDate' of the stored procedure.
			if(_generalLiabilityPrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", _generalLiabilityPrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", DBNull.Value );
			// Pass the value of '_waiverCode' as parameter 'WaiverCode' of the stored procedure.
			if(_waiverCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode", _waiverCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode", DBNull.Value );
			// Pass the value of '_waiverCode2' as parameter 'WaiverCode2' of the stored procedure.
			if(_waiverCode2NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode2", _waiverCode2NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode2", DBNull.Value );
			// Pass the value of '_overrideCapacity' as parameter 'OverrideCapacity' of the stored procedure.
			if(_overrideCapacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@OverrideCapacity", _overrideCapacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@OverrideCapacity", DBNull.Value );
			// Pass the value of '_rnCoordinator' as parameter 'RnCoordinator' of the stored procedure.
			if(_rnCoordinatorNonDefault!=null)
              oDatabaseHelper.AddParameter("@RnCoordinator", _rnCoordinatorNonDefault);
            else
              oDatabaseHelper.AddParameter("@RnCoordinator", DBNull.Value );
			// Pass the value of '_waiverCode3' as parameter 'WaiverCode3' of the stored procedure.
			if(_waiverCode3NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode3", _waiverCode3NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode3", DBNull.Value );
			// Pass the value of '_waiverCode4' as parameter 'WaiverCode4' of the stored procedure.
			if(_waiverCode4NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode4", _waiverCode4NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode4", DBNull.Value );
			// Pass the value of '_directorName' as parameter 'DirectorName' of the stored procedure.
			if(_directorNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorName", _directorNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorName", DBNull.Value );
			// Pass the value of '_waiverCode5' as parameter 'WaiverCode5' of the stored procedure.
			if(_waiverCode5NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode5", _waiverCode5NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode5", DBNull.Value );
			// Pass the value of '_year1ReviewDateDue' as parameter 'Year1ReviewDateDue' of the stored procedure.
			if(_year1ReviewDateDueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", _year1ReviewDateDueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", DBNull.Value );
			// Pass the value of '_waiverCode6' as parameter 'WaiverCode6' of the stored procedure.
			if(_waiverCode6NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode6", _waiverCode6NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode6", DBNull.Value );
			// Pass the value of '_waiverCode7' as parameter 'WaiverCode7' of the stored procedure.
			if(_waiverCode7NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode7", _waiverCode7NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode7", DBNull.Value );
			// Pass the value of '_usage' as parameter 'Usage' of the stored procedure.
			if(_usageNonDefault!=null)
              oDatabaseHelper.AddParameter("@Usage", _usageNonDefault);
            else
              oDatabaseHelper.AddParameter("@Usage", DBNull.Value );
			// Pass the value of '_totalNumDialysisPatients' as parameter 'TotalNumDialysisPatients' of the stored procedure.
			if(_totalNumDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", _totalNumDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", DBNull.Value );
			// Pass the value of '_accreditationExpirationDate' as parameter 'AccreditationExpirationDate' of the stored procedure.
			if(_accreditationExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", _accreditationExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", DBNull.Value );
			// Pass the value of '_hemodialysisNumPatients' as parameter 'HemodialysisNumPatients' of the stored procedure.
			if(_hemodialysisNumPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", _hemodialysisNumPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", DBNull.Value );
			// Pass the value of '_facilityWithinFacility' as parameter 'FacilityWithinFacility' of the stored procedure.
			if(_facilityWithinFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", _facilityWithinFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", DBNull.Value );
			// Pass the value of '_numOfPeritonealDialysisPatients' as parameter 'NumOfPeritonealDialysisPatients' of the stored procedure.
			if(_numOfPeritonealDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", _numOfPeritonealDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", DBNull.Value );
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			if(_facilityTypeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityTypeCode", DBNull.Value );
			// Pass the value of '_hemodialysisNumOfStations' as parameter 'HemodialysisNumOfStations' of the stored procedure.
			if(_hemodialysisNumOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", _hemodialysisNumOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", DBNull.Value );
			// Pass the value of '_transplantYN' as parameter 'TransplantYN' of the stored procedure.
			if(_transplantYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplantYN", _transplantYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplantYN", DBNull.Value );
			// Pass the value of '_hemodialysisTrainingNumOfStation' as parameter 'HemodialysisTrainingNumOfStation' of the stored procedure.
			if(_hemodialysisTrainingNumOfStationNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", _hemodialysisTrainingNumOfStationNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", DBNull.Value );
			// Pass the value of '_obIntCode' as parameter 'ObIntCode' of the stored procedure.
			if(_obIntCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObIntCode", _obIntCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObIntCode", DBNull.Value );
			// Pass the value of '_obCurrentSurveyDate' as parameter 'ObCurrentSurveyDate' of the stored procedure.
			if(_obCurrentSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ObCurrentSurveyDate", _obCurrentSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ObCurrentSurveyDate", DBNull.Value );
			// Pass the value of '_totalNumStations' as parameter 'TotalNumStations' of the stored procedure.
			if(_totalNumStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalNumStations", _totalNumStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalNumStations", DBNull.Value );
			// Pass the value of '_reuseYN' as parameter 'ReuseYN' of the stored procedure.
			if(_reuseYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReuseYN", _reuseYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReuseYN", DBNull.Value );
			// Pass the value of '_nicuCurrentSurveyDate' as parameter 'NicuCurrentSurveyDate' of the stored procedure.
			if(_nicuCurrentSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@NicuCurrentSurveyDate", _nicuCurrentSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@NicuCurrentSurveyDate", DBNull.Value );
			// Pass the value of '_manualYN' as parameter 'ManualYN' of the stored procedure.
			if(_manualYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ManualYN", _manualYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ManualYN", DBNull.Value );
			// Pass the value of '_picuCurrentSurveyDate' as parameter 'PicuCurrentSurveyDate' of the stored procedure.
			if(_picuCurrentSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@PicuCurrentSurveyDate", _picuCurrentSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@PicuCurrentSurveyDate", DBNull.Value );
			// Pass the value of '_numOfPatientsFollowedAtHome' as parameter 'NumOfPatientsFollowedAtHome' of the stored procedure.
			if(_numOfPatientsFollowedAtHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", _numOfPatientsFollowedAtHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", DBNull.Value );
			// Pass the value of '_traumaLevel' as parameter 'TraumaLevel' of the stored procedure.
			if(_traumaLevelNonDefault!=null)
              oDatabaseHelper.AddParameter("@TraumaLevel", _traumaLevelNonDefault);
            else
              oDatabaseHelper.AddParameter("@TraumaLevel", DBNull.Value );
			// Pass the value of '_semiautomatedYN' as parameter 'SemiautomatedYN' of the stored procedure.
			if(_semiautomatedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@SemiautomatedYN", _semiautomatedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@SemiautomatedYN", DBNull.Value );
			// Pass the value of '_automatedYN' as parameter 'AutomatedYN' of the stored procedure.
			if(_automatedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomatedYN", _automatedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomatedYN", DBNull.Value );
			// Pass the value of '_formainGermicide' as parameter 'FormainGermicide' of the stored procedure.
			if(_formainGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@FormainGermicide", _formainGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@FormainGermicide", DBNull.Value );
			// Pass the value of '_heatGermicide' as parameter 'HeatGermicide' of the stored procedure.
			if(_heatGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@HeatGermicide", _heatGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@HeatGermicide", DBNull.Value );
			// Pass the value of '_gluteraldetydeGermicide' as parameter 'GluteraldetydeGermicide' of the stored procedure.
			if(_gluteraldetydeGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@GluteraldetydeGermicide", _gluteraldetydeGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@GluteraldetydeGermicide", DBNull.Value );
			// Pass the value of '_peraceticAcidMixtureGerm' as parameter 'PeraceticAcidMixtureGerm' of the stored procedure.
			if(_peraceticAcidMixtureGermNonDefault!=null)
              oDatabaseHelper.AddParameter("@PeraceticAcidMixtureGerm", _peraceticAcidMixtureGermNonDefault);
            else
              oDatabaseHelper.AddParameter("@PeraceticAcidMixtureGerm", DBNull.Value );
			// Pass the value of '_otherGermicide' as parameter 'OtherGermicide' of the stored procedure.
			if(_otherGermicideNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherGermicide", _otherGermicideNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherGermicide", DBNull.Value );
			// Pass the value of '_enrolledRhcOffsiteYN' as parameter 'EnrolledRhcOffsiteYN' of the stored procedure.
			if(_enrolledRhcOffsiteYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", _enrolledRhcOffsiteYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", DBNull.Value );
			// Pass the value of '_typeGermicideDescription' as parameter 'TypeGermicideDescription' of the stored procedure.
			if(_typeGermicideDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeGermicideDescription", _typeGermicideDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeGermicideDescription", DBNull.Value );
			// Pass the value of '_hemodialysisService' as parameter 'HemodialysisService' of the stored procedure.
			if(_hemodialysisServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisService", _hemodialysisServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisService", DBNull.Value );
			// Pass the value of '_directorOfNursingFirstName' as parameter 'DirectorOfNursingFirstName' of the stored procedure.
			if(_directorOfNursingFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorOfNursingFirstName", _directorOfNursingFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorOfNursingFirstName", DBNull.Value );
			// Pass the value of '_peritonealDialysisService' as parameter 'PeritonealDialysisService' of the stored procedure.
			if(_peritonealDialysisServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", _peritonealDialysisServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", DBNull.Value );
			// Pass the value of '_directorOfNursingLastName' as parameter 'DirectorOfNursingLastName' of the stored procedure.
			if(_directorOfNursingLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorOfNursingLastName", _directorOfNursingLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorOfNursingLastName", DBNull.Value );
			// Pass the value of '_presidentFirstName' as parameter 'PresidentFirstName' of the stored procedure.
			if(_presidentFirstNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@PresidentFirstName", _presidentFirstNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@PresidentFirstName", DBNull.Value );
			// Pass the value of '_transplanationService' as parameter 'TransplanationService' of the stored procedure.
			if(_transplanationServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplanationService", _transplanationServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplanationService", DBNull.Value );
			// Pass the value of '_presidentLastName' as parameter 'PresidentLastName' of the stored procedure.
			if(_presidentLastNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@PresidentLastName", _presidentLastNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@PresidentLastName", DBNull.Value );
			// Pass the value of '_homeTrainingService' as parameter 'HomeTrainingService' of the stored procedure.
			if(_homeTrainingServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@HomeTrainingService", _homeTrainingServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@HomeTrainingService", DBNull.Value );
			// Pass the value of '_staffingFteRN' as parameter 'StaffingFteRN' of the stored procedure.
			if(_staffingFteRNNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteRN", _staffingFteRNNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteRN", DBNull.Value );
			// Pass the value of '_staffingFteLpn' as parameter 'StaffingFteLpn' of the stored procedure.
			if(_staffingFteLpnNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteLpn", _staffingFteLpnNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteLpn", DBNull.Value );
			// Pass the value of '_staffingFteSW' as parameter 'StaffingFteSW' of the stored procedure.
			if(_staffingFteSWNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteSW", _staffingFteSWNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteSW", DBNull.Value );
			// Pass the value of '_staffingFteTechnicians' as parameter 'StaffingFteTechnicians' of the stored procedure.
			if(_staffingFteTechniciansNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteTechnicians", _staffingFteTechniciansNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteTechnicians", DBNull.Value );
			// Pass the value of '_staffingFteDietian' as parameter 'StaffingFteDietian' of the stored procedure.
			if(_staffingFteDietianNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteDietian", _staffingFteDietianNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteDietian", DBNull.Value );
			// Pass the value of '_staffingFteOthers' as parameter 'StaffingFteOthers' of the stored procedure.
			if(_staffingFteOthersNonDefault!=null)
              oDatabaseHelper.AddParameter("@StaffingFteOthers", _staffingFteOthersNonDefault);
            else
              oDatabaseHelper.AddParameter("@StaffingFteOthers", DBNull.Value );
			// Pass the value of '_initial' as parameter 'Initial' of the stored procedure.
			if(_initialNonDefault!=null)
              oDatabaseHelper.AddParameter("@Initial", _initialNonDefault);
            else
              oDatabaseHelper.AddParameter("@Initial", DBNull.Value );
			// Pass the value of '_initialDate' as parameter 'InitialDate' of the stored procedure.
			if(_initialDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@InitialDate", _initialDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@InitialDate", DBNull.Value );
			// Pass the value of '_expansionToNewLocation' as parameter 'ExpansionToNewLocation' of the stored procedure.
			if(_expansionToNewLocationNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpansionToNewLocation", _expansionToNewLocationNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpansionToNewLocation", DBNull.Value );
			// Pass the value of '_expToNewLocationDate' as parameter 'ExpToNewLocationDate' of the stored procedure.
			if(_expToNewLocationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpToNewLocationDate", _expToNewLocationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpToNewLocationDate", DBNull.Value );
			// Pass the value of '_changeOfOwnership' as parameter 'ChangeOfOwnership' of the stored procedure.
			if(_changeOfOwnershipNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfOwnership", _changeOfOwnershipNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfOwnership", DBNull.Value );
			// Pass the value of '_changeOfLocation' as parameter 'ChangeOfLocation' of the stored procedure.
			if(_changeOfLocationNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfLocation", _changeOfLocationNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfLocation", DBNull.Value );
			// Pass the value of '_changeOfLocationDate' as parameter 'ChangeOfLocationDate' of the stored procedure.
			if(_changeOfLocationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfLocationDate", _changeOfLocationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfLocationDate", DBNull.Value );
			// Pass the value of '_expansionInCurrentLocation' as parameter 'ExpansionInCurrentLocation' of the stored procedure.
			if(_expansionInCurrentLocationNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocation", _expansionInCurrentLocationNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocation", DBNull.Value );
			// Pass the value of '_expansionInCurrentLocationDate' as parameter 'ExpansionInCurrentLocationDate' of the stored procedure.
			if(_expansionInCurrentLocationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocationDate", _expansionInCurrentLocationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ExpansionInCurrentLocationDate", DBNull.Value );
			// Pass the value of '_changeOfServices' as parameter 'ChangeOfServices' of the stored procedure.
			if(_changeOfServicesNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfServices", _changeOfServicesNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfServices", DBNull.Value );
			// Pass the value of '_changeOfServicesDate' as parameter 'ChangeOfServicesDate' of the stored procedure.
			if(_changeOfServicesDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeOfServicesDate", _changeOfServicesDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeOfServicesDate", DBNull.Value );
			// Pass the value of '_typeApplicationCode7' as parameter 'TypeApplicationCode7' of the stored procedure.
			if(_typeApplicationCode7NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeApplicationCode7", _typeApplicationCode7NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeApplicationCode7", DBNull.Value );
			// Pass the value of '_typeApplicationCode7Date' as parameter 'TypeApplicationCode7Date' of the stored procedure.
			if(_typeApplicationCode7DateNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeApplicationCode7Date", _typeApplicationCode7DateNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeApplicationCode7Date", DBNull.Value );
			// Pass the value of '_typeApplicationDescr' as parameter 'TypeApplicationDescr' of the stored procedure.
			if(_typeApplicationDescrNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeApplicationDescr", _typeApplicationDescrNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeApplicationDescr", DBNull.Value );
			// Pass the value of '_providerBasedYN' as parameter 'ProviderBasedYN' of the stored procedure.
			if(_providerBasedYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProviderBasedYN", _providerBasedYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProviderBasedYN", DBNull.Value );
			// Pass the value of '_midLevelWaiverYN' as parameter 'MidLevelWaiverYN' of the stored procedure.
			if(_midLevelWaiverYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@MidLevelWaiverYN", _midLevelWaiverYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@MidLevelWaiverYN", DBNull.Value );
			// Pass the value of '_midLevelWaiverMonth' as parameter 'MidLevelWaiverMonth' of the stored procedure.
			if(_midLevelWaiverMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@MidLevelWaiverMonth", _midLevelWaiverMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@MidLevelWaiverMonth", DBNull.Value );
			// Pass the value of '_midLevelWaiverDate' as parameter 'MidLevelWaiverDate' of the stored procedure.
			if(_midLevelWaiverDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MidLevelWaiverDate", _midLevelWaiverDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MidLevelWaiverDate", DBNull.Value );
			// Pass the value of '_relatedProviderLicensureNum' as parameter 'RelatedProviderLicensureNum' of the stored procedure.
			if(_relatedProviderLicensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", _relatedProviderLicensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", DBNull.Value );
			// Pass the value of '_emergencyPrepReportRequired' as parameter 'EmergencyPrepReportRequired' of the stored procedure.
			if(_emergencyPrepReportRequiredNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", _emergencyPrepReportRequiredNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", DBNull.Value );
			// Pass the value of '_accreditedBody' as parameter 'AccreditedBody' of the stored procedure.
			if(_accreditedBodyNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditedBody", _accreditedBodyNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditedBody", DBNull.Value );
			// Pass the value of '_enrolledInMedicaidYN' as parameter 'EnrolledInMedicaidYN' of the stored procedure.
			if(_enrolledInMedicaidYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", _enrolledInMedicaidYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", DBNull.Value );
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			if(_typeTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeTreatment", DBNull.Value );
			// Pass the value of '_licensedByOther' as parameter 'LicensedByOther' of the stored procedure.
			if(_licensedByOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensedByOther", _licensedByOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensedByOther", DBNull.Value );
			// Pass the value of '_licensureEffectiveDate' as parameter 'LicensureEffectiveDate' of the stored procedure.
			if(_licensureEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", _licensureEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", DBNull.Value );
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			if(_numActivePatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumActivePatients", DBNull.Value );
			// Pass the value of '_numRadiologicTechBsba' as parameter 'NumRadiologicTechBsba' of the stored procedure.
			if(_numRadiologicTechBsbaNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechBsba", _numRadiologicTechBsbaNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechBsba", DBNull.Value );
			// Pass the value of '_numRadiologicTechAS' as parameter 'NumRadiologicTechAS' of the stored procedure.
			if(_numRadiologicTechASNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechAS", _numRadiologicTechASNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechAS", DBNull.Value );
			// Pass the value of '_numRadiologicTechCrt' as parameter 'NumRadiologicTechCrt' of the stored procedure.
			if(_numRadiologicTechCrtNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechCrt", _numRadiologicTechCrtNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechCrt", DBNull.Value );
			// Pass the value of '_numRadiologicTechOther' as parameter 'NumRadiologicTechOther' of the stored procedure.
			if(_numRadiologicTechOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumRadiologicTechOther", _numRadiologicTechOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumRadiologicTechOther", DBNull.Value );
			// Pass the value of '_isolationNumOfStations' as parameter 'IsolationNumOfStations' of the stored procedure.
			if(_isolationNumOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsolationNumOfStations", _isolationNumOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsolationNumOfStations", DBNull.Value );
			// Pass the value of '_relatedProviderName' as parameter 'RelatedProviderName' of the stored procedure.
			if(_relatedProviderNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@RelatedProviderName", _relatedProviderNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@RelatedProviderName", DBNull.Value );
			// Pass the value of '_numOperatingRooms' as parameter 'NumOperatingRooms' of the stored procedure.
			if(_numOperatingRoomsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOperatingRooms", _numOperatingRoomsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOperatingRooms", DBNull.Value );
			// Pass the value of '_admMultiFacYN' as parameter 'AdmMultiFacYN' of the stored procedure.
			if(_admMultiFacYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdmMultiFacYN", _admMultiFacYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdmMultiFacYN", DBNull.Value );
			// Pass the value of '_admMultiFacOtherName' as parameter 'AdmMultiFacOtherName' of the stored procedure.
			if(_admMultiFacOtherNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdmMultiFacOtherName", _admMultiFacOtherNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdmMultiFacOtherName", DBNull.Value );
			// Pass the value of '_singleStoryYN' as parameter 'SingleStoryYN' of the stored procedure.
			if(_singleStoryYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@SingleStoryYN", _singleStoryYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@SingleStoryYN", DBNull.Value );
			// Pass the value of '_closedDate' as parameter 'ClosedDate' of the stored procedure.
			if(_closedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ClosedDate", _closedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ClosedDate", DBNull.Value );
            // Pass the value of '_year2ReviewDateDue' as parameter 'Year2ReviewDateDue' of the stored procedure.
            if (_year2ReviewDateDueNonDefault != null)
                oDatabaseHelper.AddParameter("@Year2ReviewDateDue", _year2ReviewDateDueNonDefault);
            else
                oDatabaseHelper.AddParameter("@Year2ReviewDateDue", DBNull.Value);
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDERS_Insert", ref ExecutionState);
			oDatabaseHelper.Dispose();	
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Update one new row into the database using the property Information
		/// </summary>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_aspenIntID' as parameter 'AspenIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AspenIntID", _aspenIntIDNonDefault );
            
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault );
            
			// Pass the value of '_programStaffID' as parameter 'ProgramStaffID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramStaffID", _programStaffIDNonDefault );
            
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault );
            
			// Pass the value of '_regionCode' as parameter 'RegionCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@RegionCode", _regionCodeNonDefault );
            
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault );
            
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault );
            
			// Pass the value of '_geographicalStreetAddr2' as parameter 'GeographicalStreetAddr2' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicalStreetAddr2", _geographicalStreetAddr2NonDefault );
            
			// Pass the value of '_schoolID' as parameter 'SchoolID' of the stored procedure.
			oDatabaseHelper.AddParameter("@SchoolID", _schoolIDNonDefault );
            
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault );
            
			// Pass the value of '_legalName' as parameter 'LegalName' of the stored procedure.
			oDatabaseHelper.AddParameter("@LegalName", _legalNameNonDefault );
            
			// Pass the value of '_mailStreet2' as parameter 'MailStreet2' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailStreet2", _mailStreet2NonDefault );
            
			// Pass the value of '_geographicalStreet' as parameter 'GeographicalStreet' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicalStreet", _geographicalStreetNonDefault );
            
			// Pass the value of '_geographicalCity' as parameter 'GeographicalCity' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicalCity", _geographicalCityNonDefault );
            
			// Pass the value of '_geographicalZip' as parameter 'GeographicalZip' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicalZip", _geographicalZipNonDefault );
            
			// Pass the value of '_geographicalState' as parameter 'GeographicalState' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeographicalState", _geographicalStateNonDefault );
            
			// Pass the value of '_mailStreet' as parameter 'MailStreet' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailStreet", _mailStreetNonDefault );
            
			// Pass the value of '_mailCity' as parameter 'MailCity' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailCity", _mailCityNonDefault );
            
			// Pass the value of '_mailState' as parameter 'MailState' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailState", _mailStateNonDefault );
            
			// Pass the value of '_mailZip' as parameter 'MailZip' of the stored procedure.
			oDatabaseHelper.AddParameter("@MailZip", _mailZipNonDefault );
            
			// Pass the value of '_emsParishCode' as parameter 'EmsParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmsParishCode", _emsParishCodeNonDefault );
            
			// Pass the value of '_parish' as parameter 'Parish' of the stored procedure.
			oDatabaseHelper.AddParameter("@Parish", _parishNonDefault );
            
			// Pass the value of '_regionalOffice' as parameter 'RegionalOffice' of the stored procedure.
			oDatabaseHelper.AddParameter("@RegionalOffice", _regionalOfficeNonDefault );
            
			// Pass the value of '_zoneNumCode' as parameter 'ZoneNumCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ZoneNumCode", _zoneNumCodeNonDefault );
            
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault );
            
			// Pass the value of '_emergencyPhoneNumber' as parameter 'EmergencyPhoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmergencyPhoneNumber", _emergencyPhoneNumberNonDefault );
            
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault );
            
			// Pass the value of '_administrator' as parameter 'Administrator' of the stored procedure.
			oDatabaseHelper.AddParameter("@Administrator", _administratorNonDefault );
            
			// Pass the value of '_administratorTitle' as parameter 'AdministratorTitle' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdministratorTitle", _administratorTitleNonDefault );
            
			// Pass the value of '_administratorFirstName' as parameter 'AdministratorFirstName' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdministratorFirstName", _administratorFirstNameNonDefault );
            
			// Pass the value of '_administratorMidInit' as parameter 'AdministratorMidInit' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdministratorMidInit", _administratorMidInitNonDefault );
            
			// Pass the value of '_administratorLastName' as parameter 'AdministratorLastName' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdministratorLastName", _administratorLastNameNonDefault );
            
			// Pass the value of '_contactName' as parameter 'ContactName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ContactName", _contactNameNonDefault );
            
			// Pass the value of '_stateIdMds' as parameter 'StateIdMds' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateIdMds", _stateIdMdsNonDefault );
            
			// Pass the value of '_stateLicNum' as parameter 'StateLicNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateLicNum", _stateLicNumNonDefault );
            
			// Pass the value of '_emailAddress' as parameter 'EmailAddress' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmailAddress", _emailAddressNonDefault );
            
			// Pass the value of '_medicaidVendorNumber' as parameter 'MedicaidVendorNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicaidVendorNumber", _medicaidVendorNumberNonDefault );
            
			// Pass the value of '_fieldOfficeCode' as parameter 'FieldOfficeCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@FieldOfficeCode", _fieldOfficeCodeNonDefault );
            
			// Pass the value of '_medicalDirectorFullName' as parameter 'MedicalDirectorFullName' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorFullName", _medicalDirectorFullNameNonDefault );
            
			// Pass the value of '_medicalDirectorTitle' as parameter 'MedicalDirectorTitle' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorTitle", _medicalDirectorTitleNonDefault );
            
			// Pass the value of '_medicalDirFirstName' as parameter 'MedicalDirFirstName' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirFirstName", _medicalDirFirstNameNonDefault );
            
			// Pass the value of '_medicalDirMidInit' as parameter 'MedicalDirMidInit' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirMidInit", _medicalDirMidInitNonDefault );
            
			// Pass the value of '_medicalDirLastName' as parameter 'MedicalDirLastName' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirLastName", _medicalDirLastNameNonDefault );
            
			// Pass the value of '_medicalDirectorMailAddr1' as parameter 'MedicalDirectorMailAddr1' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr1", _medicalDirectorMailAddr1NonDefault );
            
			// Pass the value of '_medicalDirectorMailAddr2' as parameter 'MedicalDirectorMailAddr2' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorMailAddr2", _medicalDirectorMailAddr2NonDefault );
            
			// Pass the value of '_medicalDirectorMailCity' as parameter 'MedicalDirectorMailCity' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorMailCity", _medicalDirectorMailCityNonDefault );
            
			// Pass the value of '_medicalDirectorMailState' as parameter 'MedicalDirectorMailState' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorMailState", _medicalDirectorMailStateNonDefault );
            
			// Pass the value of '_medicalDirectorMailZip' as parameter 'MedicalDirectorMailZip' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalDirectorMailZip", _medicalDirectorMailZipNonDefault );
            
			// Pass the value of '_hoursMinutes' as parameter 'HoursMinutes' of the stored procedure.
			oDatabaseHelper.AddParameter("@HoursMinutes", _hoursMinutesNonDefault );
            
			// Pass the value of '_snf18beds' as parameter 'Snf18beds' of the stored procedure.
			oDatabaseHelper.AddParameter("@Snf18beds", _snf18bedsNonDefault );
            
			// Pass the value of '_amPM' as parameter 'AmPM' of the stored procedure.
			oDatabaseHelper.AddParameter("@AmPM", _amPMNonDefault );
            
			// Pass the value of '_hoursMinutes1' as parameter 'HoursMinutes1' of the stored procedure.
			oDatabaseHelper.AddParameter("@HoursMinutes1", _hoursMinutes1NonDefault );
            
			// Pass the value of '_amPm1' as parameter 'AmPm1' of the stored procedure.
			oDatabaseHelper.AddParameter("@AmPm1", _amPm1NonDefault );
            
			// Pass the value of '_dayOfOperationMon' as parameter 'DayOfOperationMon' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationMon", _dayOfOperationMonNonDefault );
            
			// Pass the value of '_dayOfOperationTue' as parameter 'DayOfOperationTue' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationTue", _dayOfOperationTueNonDefault );
            
			// Pass the value of '_dayOfOperationWed' as parameter 'DayOfOperationWed' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationWed", _dayOfOperationWedNonDefault );
            
			// Pass the value of '_dayOfOperationThu' as parameter 'DayOfOperationThu' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationThu", _dayOfOperationThuNonDefault );
            
			// Pass the value of '_dayOfOperationFri' as parameter 'DayOfOperationFri' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationFri", _dayOfOperationFriNonDefault );
            
			// Pass the value of '_dayOfOperationSat' as parameter 'DayOfOperationSat' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationSat", _dayOfOperationSatNonDefault );
            
			// Pass the value of '_dayOfOperationSun' as parameter 'DayOfOperationSun' of the stored procedure.
			oDatabaseHelper.AddParameter("@DayOfOperationSun", _dayOfOperationSunNonDefault );
            
			// Pass the value of '_typeLicenseCode' as parameter 'TypeLicenseCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeLicenseCode", _typeLicenseCodeNonDefault );
            
			// Pass the value of '_typeOfLicense' as parameter 'TypeOfLicense' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOfLicense", _typeOfLicenseNonDefault );
            
			// Pass the value of '_typeFacilityCode' as parameter 'TypeFacilityCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacilityCode", _typeFacilityCodeNonDefault );
            
			// Pass the value of '_typeFacility1Code' as parameter 'TypeFacility1Code' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility1Code", _typeFacility1CodeNonDefault );
            
			// Pass the value of '_typeFacility2Code' as parameter 'TypeFacility2Code' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility2Code", _typeFacility2CodeNonDefault );
            
			// Pass the value of '_typeFacility3Code' as parameter 'TypeFacility3Code' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility3Code", _typeFacility3CodeNonDefault );
            
			// Pass the value of '_typeFacility4Code' as parameter 'TypeFacility4Code' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility4Code", _typeFacility4CodeNonDefault );
            
			// Pass the value of '_typeFacility5Code' as parameter 'TypeFacility5Code' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility5Code", _typeFacility5CodeNonDefault );
            
			// Pass the value of '_typeFacility6Code' as parameter 'TypeFacility6Code' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility6Code", _typeFacility6CodeNonDefault );
            
			// Pass the value of '_licensedSnfFacility' as parameter 'LicensedSnfFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensedSnfFacility", _licensedSnfFacilityNonDefault );
            
			// Pass the value of '_snf1819beds' as parameter 'Snf1819beds' of the stored procedure.
			oDatabaseHelper.AddParameter("@Snf1819beds", _snf1819bedsNonDefault );
            
			// Pass the value of '_snf19beds' as parameter 'Snf19beds' of the stored procedure.
			oDatabaseHelper.AddParameter("@Snf19beds", _snf19bedsNonDefault );
            
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault );
            
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault );
            
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault );
            
			// Pass the value of '_swingBeds' as parameter 'SwingBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@SwingBeds", _swingBedsNonDefault );
            
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault );
            
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault );
            
			// Pass the value of '_bedsCertified' as parameter 'BedsCertified' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsCertified", _bedsCertifiedNonDefault );
            
			// Pass the value of '_typeOwnershipCode' as parameter 'TypeOwnershipCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOwnershipCode", _typeOwnershipCodeNonDefault );
            
			// Pass the value of '_nameOfCorporation' as parameter 'NameOfCorporation' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameOfCorporation", _nameOfCorporationNonDefault );
            
			// Pass the value of '_corporationIdNum' as parameter 'CorporationIdNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationIdNum", _corporationIdNumNonDefault );
            
			// Pass the value of '_corporationStreet' as parameter 'CorporationStreet' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationStreet", _corporationStreetNonDefault );
            
			// Pass the value of '_corporationCity' as parameter 'CorporationCity' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationCity", _corporationCityNonDefault );
            
			// Pass the value of '_corporationState' as parameter 'CorporationState' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationState", _corporationStateNonDefault );
            
			// Pass the value of '_corporationZip' as parameter 'CorporationZip' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationZip", _corporationZipNonDefault );
            
			// Pass the value of '_corporationPhone' as parameter 'CorporationPhone' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationPhone", _corporationPhoneNonDefault );
            
			// Pass the value of '_corporationFax' as parameter 'CorporationFax' of the stored procedure.
			oDatabaseHelper.AddParameter("@CorporationFax", _corporationFaxNonDefault );
            
			// Pass the value of '_nameOfOwner1' as parameter 'NameOfOwner1' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameOfOwner1", _nameOfOwner1NonDefault );
            
			// Pass the value of '_nameOfOwner2' as parameter 'NameOfOwner2' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameOfOwner2", _nameOfOwner2NonDefault );
            
			// Pass the value of '_nameOfOwner3' as parameter 'NameOfOwner3' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameOfOwner3", _nameOfOwner3NonDefault );
            
			// Pass the value of '_nameOfOwner4' as parameter 'NameOfOwner4' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameOfOwner4", _nameOfOwner4NonDefault );
            
			// Pass the value of '_presidentName' as parameter 'PresidentName' of the stored procedure.
			oDatabaseHelper.AddParameter("@PresidentName", _presidentNameNonDefault );
            
			// Pass the value of '_vicePresidentName' as parameter 'VicePresidentName' of the stored procedure.
			oDatabaseHelper.AddParameter("@VicePresidentName", _vicePresidentNameNonDefault );
            
			// Pass the value of '_secretaryTreasurerName' as parameter 'SecretaryTreasurerName' of the stored procedure.
			oDatabaseHelper.AddParameter("@SecretaryTreasurerName", _secretaryTreasurerNameNonDefault );
            
			// Pass the value of '_jcahYN' as parameter 'JcahYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@JcahYN", _jcahYNNonDefault );
            
			// Pass the value of '_changeOfOwnerDate' as parameter 'ChangeOfOwnerDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeOfOwnerDate", _changeOfOwnerDateNonDefault );
            
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault );
            
			// Pass the value of '_originalEnrollmentDate' as parameter 'OriginalEnrollmentDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", _originalEnrollmentDateNonDefault );
            
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault );
            
			// Pass the value of '_licensureExpirationDate' as parameter 'LicensureExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureExpirationDate", _licensureExpirationDateNonDefault );
            
			// Pass the value of '_licensureAnniversaryMth' as parameter 'LicensureAnniversaryMth' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureAnniversaryMth", _licensureAnniversaryMthNonDefault );
            
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault );
            
			// Pass the value of '_capacityInHome' as parameter 'CapacityInHome' of the stored procedure.
			oDatabaseHelper.AddParameter("@CapacityInHome", _capacityInHomeNonDefault );
            
			// Pass the value of '_capacityOutOfHome' as parameter 'CapacityOutOfHome' of the stored procedure.
			oDatabaseHelper.AddParameter("@CapacityOutOfHome", _capacityOutOfHomeNonDefault );
            
			// Pass the value of '_ageRange' as parameter 'AgeRange' of the stored procedure.
			oDatabaseHelper.AddParameter("@AgeRange", _ageRangeNonDefault );
            
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			oDatabaseHelper.AddParameter("@Unit", _unitNonDefault );
            
			// Pass the value of '_forYearEndingMmdd' as parameter 'ForYearEndingMmdd' of the stored procedure.
			oDatabaseHelper.AddParameter("@ForYearEndingMmdd", _forYearEndingMmddNonDefault );
            
			// Pass the value of '_hospitalBasedYN' as parameter 'HospitalBasedYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@HospitalBasedYN", _hospitalBasedYNNonDefault );
            
			// Pass the value of '_applicationDate' as parameter 'ApplicationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationDate", _applicationDateNonDefault );
            
			// Pass the value of '_fee' as parameter 'Fee' of the stored procedure.
			oDatabaseHelper.AddParameter("@Fee", _feeNonDefault );
            
			// Pass the value of '_checkNumber' as parameter 'CheckNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@CheckNumber", _checkNumberNonDefault );
            
			// Pass the value of '_dateFeeReceived' as parameter 'DateFeeReceived' of the stored procedure.
			oDatabaseHelper.AddParameter("@DateFeeReceived", _dateFeeReceivedNonDefault );
            
			// Pass the value of '_stateFireApprovalDate' as parameter 'StateFireApprovalDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateFireApprovalDate", _stateFireApprovalDateNonDefault );
            
			// Pass the value of '_healthApprovalDate' as parameter 'HealthApprovalDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@HealthApprovalDate", _healthApprovalDateNonDefault );
            
			// Pass the value of '_curSurv' as parameter 'CurSurv' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurSurv", _curSurvNonDefault );
            
			// Pass the value of '_usDeaRegNum' as parameter 'UsDeaRegNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@UsDeaRegNum", _usDeaRegNumNonDefault );
            
			// Pass the value of '_usDeaRegNumExpDate' as parameter 'UsDeaRegNumExpDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@UsDeaRegNumExpDate", _usDeaRegNumExpDateNonDefault );
            
			// Pass the value of '_laCdsNum' as parameter 'LaCdsNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@LaCdsNum", _laCdsNumNonDefault );
            
			// Pass the value of '_laCdsNumExpDate' as parameter 'LaCdsNumExpDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LaCdsNumExpDate", _laCdsNumExpDateNonDefault );
            
			// Pass the value of '_cliaIdNum' as parameter 'CliaIdNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@CliaIdNum", _cliaIdNumNonDefault );
            
			// Pass the value of '_cliaExpDate' as parameter 'CliaExpDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CliaExpDate", _cliaExpDateNonDefault );
            
			// Pass the value of '_certEffectiveDate' as parameter 'CertEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CertEffectiveDate", _certEffectiveDateNonDefault );
            
			// Pass the value of '_certifExpirationDate' as parameter 'CertifExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CertifExpirationDate", _certifExpirationDateNonDefault );
            
			// Pass the value of '_certificationMth' as parameter 'CertificationMth' of the stored procedure.
			oDatabaseHelper.AddParameter("@CertificationMth", _certificationMthNonDefault );
            
			// Pass the value of '_levelCode' as parameter 'LevelCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@LevelCode", _levelCodeNonDefault );
            
			// Pass the value of '_noOfAirAmbulances' as parameter 'NoOfAirAmbulances' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfAirAmbulances", _noOfAirAmbulancesNonDefault );
            
			// Pass the value of '_noOfGroundAmbulances' as parameter 'NoOfGroundAmbulances' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfGroundAmbulances", _noOfGroundAmbulancesNonDefault );
            
			// Pass the value of '_noOfSprintVehicles' as parameter 'NoOfSprintVehicles' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfSprintVehicles", _noOfSprintVehiclesNonDefault );
            
			// Pass the value of '_noOfAmbulatoryVehicles' as parameter 'NoOfAmbulatoryVehicles' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfAmbulatoryVehicles", _noOfAmbulatoryVehiclesNonDefault );
            
			// Pass the value of '_totalDailyCapacityAmbulatoryVehicle' as parameter 'TotalDailyCapacityAmbulatoryVehicle' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalDailyCapacityAmbulatoryVehicle", _totalDailyCapacityAmbulatoryVehicleNonDefault );
            
			// Pass the value of '_noOfHandicappedVehicles' as parameter 'NoOfHandicappedVehicles' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfHandicappedVehicles", _noOfHandicappedVehiclesNonDefault );
            
			// Pass the value of '_totalDailyCapacityHandicappedVehicle' as parameter 'TotalDailyCapacityHandicappedVehicle' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalDailyCapacityHandicappedVehicle", _totalDailyCapacityHandicappedVehicleNonDefault );
            
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault );
            
			// Pass the value of '_automobileInsuranceCoverageLimit' as parameter 'AutomobileInsuranceCoverageLimit' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomobileInsuranceCoverageLimit", _automobileInsuranceCoverageLimitNonDefault );
            
			// Pass the value of '_automobileInsuranceCarrierCode' as parameter 'AutomobileInsuranceCarrierCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomobileInsuranceCarrierCode", _automobileInsuranceCarrierCodeNonDefault );
            
			// Pass the value of '_automobileInsurancePolicyNum' as parameter 'AutomobileInsurancePolicyNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomobileInsurancePolicyNum", _automobileInsurancePolicyNumNonDefault );
            
			// Pass the value of '_automobileInsuranceExpirationDate' as parameter 'AutomobileInsuranceExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomobileInsuranceExpirationDate", _automobileInsuranceExpirationDateNonDefault );
            
			// Pass the value of '_generalLiabilityCoverageLimit' as parameter 'GeneralLiabilityCoverageLimit' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeneralLiabilityCoverageLimit", _generalLiabilityCoverageLimitNonDefault );
            
			// Pass the value of '_generalLiabilityCarrierCode' as parameter 'GeneralLiabilityCarrierCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeneralLiabilityCarrierCode", _generalLiabilityCarrierCodeNonDefault );
            
			// Pass the value of '_generalLiabilityPolicyNum' as parameter 'GeneralLiabilityPolicyNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeneralLiabilityPolicyNum", _generalLiabilityPolicyNumNonDefault );
            
			// Pass the value of '_facilityWithinFacilityYN' as parameter 'FacilityWithinFacilityYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", _facilityWithinFacilityYNNonDefault );
            
			// Pass the value of '_generalLiabilityExpirationDate' as parameter 'GeneralLiabilityExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeneralLiabilityExpirationDate", _generalLiabilityExpirationDateNonDefault );
            
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault );
            
			// Pass the value of '_medicalMalpracticeCoverageLimit' as parameter 'MedicalMalpracticeCoverageLimit' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalMalpracticeCoverageLimit", _medicalMalpracticeCoverageLimitNonDefault );
            
			// Pass the value of '_unitsNumTotal' as parameter 'UnitsNumTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@UnitsNumTotal", _unitsNumTotalNonDefault );
            
			// Pass the value of '_medicalMalpracticeCarrierCode' as parameter 'MedicalMalpracticeCarrierCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalMalpracticeCarrierCode", _medicalMalpracticeCarrierCodeNonDefault );
            
			// Pass the value of '_totalLicBedsTotal' as parameter 'TotalLicBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBedsTotal", _totalLicBedsTotalNonDefault );
            
			// Pass the value of '_medicalMalpracticePolicyNum' as parameter 'MedicalMalpracticePolicyNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalMalpracticePolicyNum", _medicalMalpracticePolicyNumNonDefault );
            
			// Pass the value of '_psychiatricBedsTotal' as parameter 'PsychiatricBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", _psychiatricBedsTotalNonDefault );
            
			// Pass the value of '_medicalMalpracticeExpirationDate' as parameter 'MedicalMalpracticeExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicalMalpracticeExpirationDate", _medicalMalpracticeExpirationDateNonDefault );
            
			// Pass the value of '_isolationUnitYN' as parameter 'IsolationUnitYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsolationUnitYN", _isolationUnitYNNonDefault );
            
			// Pass the value of '_rehabilitationBedsTotal' as parameter 'RehabilitationBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabilitationBedsTotal", _rehabilitationBedsTotalNonDefault );
            
			// Pass the value of '_snfBedsTotal' as parameter 'SnfBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBedsTotal", _snfBedsTotalNonDefault );
            
			// Pass the value of '_statusCode' as parameter 'StatusCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusCode", _statusCodeNonDefault );
            
			// Pass the value of '_unitsNumOffsiteTotal' as parameter 'UnitsNumOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", _unitsNumOffsiteTotalNonDefault );
            
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault );
            
			// Pass the value of '_totalLicBedsOffsiteTotal' as parameter 'TotalLicBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", _totalLicBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_noOfParishesServed' as parameter 'NoOfParishesServed' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfParishesServed", _noOfParishesServedNonDefault );
            
			// Pass the value of '_psychiatricBedsOffsiteTotal' as parameter 'PsychiatricBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", _psychiatricBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_licensureSurveyDate' as parameter 'LicensureSurveyDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureSurveyDate", _licensureSurveyDateNonDefault );
            
			// Pass the value of '_rehabBedsOffsiteTotal' as parameter 'RehabBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", _rehabBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_waivers' as parameter 'Waivers' of the stored procedure.
			oDatabaseHelper.AddParameter("@Waivers", _waiversNonDefault );
            
			// Pass the value of '_snfBedsOffsiteTotal' as parameter 'SnfBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBedsOffsiteTotal", _snfBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_otherBedsOffsiteTotal' as parameter 'OtherBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherBedsOffsiteTotal", _otherBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_psychPpsFederalID' as parameter 'PsychPpsFederalID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychPpsFederalID", _psychPpsFederalIDNonDefault );
            
			// Pass the value of '_rehabPpsFederalID' as parameter 'RehabPpsFederalID' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabPpsFederalID", _rehabPpsFederalIDNonDefault );
            
			// Pass the value of '_userLastMaint' as parameter 'UserLastMaint' of the stored procedure.
			oDatabaseHelper.AddParameter("@UserLastMaint", _userLastMaintNonDefault );
            
			// Pass the value of '_psychPpsCertEffectiveDate' as parameter 'PsychPpsCertEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychPpsCertEffectiveDate", _psychPpsCertEffectiveDateNonDefault );
            
			// Pass the value of '_dateLastMaint' as parameter 'DateLastMaint' of the stored procedure.
			oDatabaseHelper.AddParameter("@DateLastMaint", _dateLastMaintNonDefault );
            
			// Pass the value of '_rehabPpsCertEffectiveDate' as parameter 'RehabPpsCertEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabPpsCertEffectiveDate", _rehabPpsCertEffectiveDateNonDefault );
            
			// Pass the value of '_timeLastMaint' as parameter 'TimeLastMaint' of the stored procedure.
			oDatabaseHelper.AddParameter("@TimeLastMaint", _timeLastMaintNonDefault );
            
			// Pass the value of '_offsiteCampusYN' as parameter 'OffsiteCampusYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@OffsiteCampusYN", _offsiteCampusYNNonDefault );
            
			// Pass the value of '_certifiedBedOverrideYN' as parameter 'CertifiedBedOverrideYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", _certifiedBedOverrideYNNonDefault );
            
			// Pass the value of '_mainCampusBeds' as parameter 'MainCampusBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@MainCampusBeds", _mainCampusBedsNonDefault );
            
			// Pass the value of '_forYearEndingDate' as parameter 'ForYearEndingDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ForYearEndingDate", _forYearEndingDateNonDefault );
            
			// Pass the value of '_neonatalIntCode' as parameter 'NeonatalIntCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@NeonatalIntCode", _neonatalIntCodeNonDefault );
            
			// Pass the value of '_servicesOffered' as parameter 'ServicesOffered' of the stored procedure.
			oDatabaseHelper.AddParameter("@ServicesOffered", _servicesOfferedNonDefault );
            
			// Pass the value of '_picuIntCode' as parameter 'PicuIntCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@PicuIntCode", _picuIntCodeNonDefault );
            
			// Pass the value of '_halfwayHouse' as parameter 'HalfwayHouse' of the stored procedure.
			oDatabaseHelper.AddParameter("@HalfwayHouse", _halfwayHouseNonDefault );
            
			// Pass the value of '_deemedStatus' as parameter 'DeemedStatus' of the stored procedure.
			oDatabaseHelper.AddParameter("@DeemedStatus", _deemedStatusNonDefault );
            
			// Pass the value of '_inPatient' as parameter 'InPatient' of the stored procedure.
			oDatabaseHelper.AddParameter("@InPatient", _inPatientNonDefault );
            
			// Pass the value of '_chapAccreditionYN' as parameter 'ChapAccreditionYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChapAccreditionYN", _chapAccreditionYNNonDefault );
            
			// Pass the value of '_crisisEmergency' as parameter 'CrisisEmergency' of the stored procedure.
			oDatabaseHelper.AddParameter("@CrisisEmergency", _crisisEmergencyNonDefault );
            
			// Pass the value of '_outpatientTreatment' as parameter 'OutpatientTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@OutpatientTreatment", _outpatientTreatmentNonDefault );
            
			// Pass the value of '_fiscalIntermediaryNum' as parameter 'FiscalIntermediaryNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", _fiscalIntermediaryNumNonDefault );
            
			// Pass the value of '_methadoneTreatment' as parameter 'MethadoneTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@MethadoneTreatment", _methadoneTreatmentNonDefault );
            
			// Pass the value of '_attesestationStatement' as parameter 'AttesestationStatement' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttesestationStatement", _attesestationStatementNonDefault );
            
			// Pass the value of '_preventionEducation' as parameter 'PreventionEducation' of the stored procedure.
			oDatabaseHelper.AddParameter("@PreventionEducation", _preventionEducationNonDefault );
            
			// Pass the value of '_attesestationStmtDateSigned' as parameter 'AttesestationStmtDateSigned' of the stored procedure.
			oDatabaseHelper.AddParameter("@AttesestationStmtDateSigned", _attesestationStmtDateSignedNonDefault );
            
			// Pass the value of '_residentialTreatment' as parameter 'ResidentialTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@ResidentialTreatment", _residentialTreatmentNonDefault );
            
			// Pass the value of '_nameChangePrevName1' as parameter 'NameChangePrevName1' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameChangePrevName1", _nameChangePrevName1NonDefault );
            
			// Pass the value of '_socialSettingDetoxification' as parameter 'SocialSettingDetoxification' of the stored procedure.
			oDatabaseHelper.AddParameter("@SocialSettingDetoxification", _socialSettingDetoxificationNonDefault );
            
			// Pass the value of '_nameChangeDate1' as parameter 'NameChangeDate1' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameChangeDate1", _nameChangeDate1NonDefault );
            
			// Pass the value of '_adultHealthCare' as parameter 'AdultHealthCare' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdultHealthCare", _adultHealthCareNonDefault );
            
			// Pass the value of '_nameChangePrevName2' as parameter 'NameChangePrevName2' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameChangePrevName2", _nameChangePrevName2NonDefault );
            
			// Pass the value of '_nameChangeDate2' as parameter 'NameChangeDate2' of the stored procedure.
			oDatabaseHelper.AddParameter("@NameChangeDate2", _nameChangeDate2NonDefault );
            
			// Pass the value of '_cnatTrainingCode' as parameter 'CnatTrainingCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@CnatTrainingCode", _cnatTrainingCodeNonDefault );
            
			// Pass the value of '_cnatTrainingSuspendDate' as parameter 'CnatTrainingSuspendDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CnatTrainingSuspendDate", _cnatTrainingSuspendDateNonDefault );
            
			// Pass the value of '_previousOwner1' as parameter 'PreviousOwner1' of the stored procedure.
			oDatabaseHelper.AddParameter("@PreviousOwner1", _previousOwner1NonDefault );
            
			// Pass the value of '_prevOwnerChangeDate1' as parameter 'PrevOwnerChangeDate1' of the stored procedure.
			oDatabaseHelper.AddParameter("@PrevOwnerChangeDate1", _prevOwnerChangeDate1NonDefault );
            
			// Pass the value of '_assistDirOfNursingWaiverMonth' as parameter 'AssistDirOfNursingWaiverMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@AssistDirOfNursingWaiverMonth", _assistDirOfNursingWaiverMonthNonDefault );
            
			// Pass the value of '_day7RnWaiverMonth' as parameter 'Day7RnWaiverMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@Day7RnWaiverMonth", _day7RnWaiverMonthNonDefault );
            
			// Pass the value of '_previousOwner2' as parameter 'PreviousOwner2' of the stored procedure.
			oDatabaseHelper.AddParameter("@PreviousOwner2", _previousOwner2NonDefault );
            
			// Pass the value of '_prevOwnerChangeDate2' as parameter 'PrevOwnerChangeDate2' of the stored procedure.
			oDatabaseHelper.AddParameter("@PrevOwnerChangeDate2", _prevOwnerChangeDate2NonDefault );
            
			// Pass the value of '_currentSurveyMonth' as parameter 'CurrentSurveyMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentSurveyMonth", _currentSurveyMonthNonDefault );
            
			// Pass the value of '_fiscalIntermediaryDesc' as parameter 'FiscalIntermediaryDesc' of the stored procedure.
			oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", _fiscalIntermediaryDescNonDefault );
            
			// Pass the value of '_medicareInterPrefCode' as parameter 'MedicareInterPrefCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicareInterPrefCode", _medicareInterPrefCodeNonDefault );
            
			// Pass the value of '_programCode' as parameter 'ProgramCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramCode", _programCodeNonDefault );
            
			// Pass the value of '_noTreatmentsPerWeek' as parameter 'NoTreatmentsPerWeek' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoTreatmentsPerWeek", _noTreatmentsPerWeekNonDefault );
            
			// Pass the value of '_noOfStations' as parameter 'NoOfStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfStations", _noOfStationsNonDefault );
            
			// Pass the value of '_levelDescription' as parameter 'LevelDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@LevelDescription", _levelDescriptionNonDefault );
            
			// Pass the value of '_automaticCancellationDate' as parameter 'AutomaticCancellationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomaticCancellationDate", _automaticCancellationDateNonDefault );
            
			// Pass the value of '_noOf3hrShiftsWeek' as parameter 'NoOf3hrShiftsWeek' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", _noOf3hrShiftsWeekNonDefault );
            
			// Pass the value of '_fcertBeds' as parameter 'FcertBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@FcertBeds", _fcertBedsNonDefault );
            
			// Pass the value of '_averageNumPatientsShift' as parameter 'AverageNumPatientsShift' of the stored procedure.
			oDatabaseHelper.AddParameter("@AverageNumPatientsShift", _averageNumPatientsShiftNonDefault );
            
			// Pass the value of '_automobileInsurancePrepaymentDueDate' as parameter 'AutomobileInsurancePrepaymentDueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", _automobileInsurancePrepaymentDueDateNonDefault );
            
			// Pass the value of '_vendorNum' as parameter 'VendorNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@VendorNum", _vendorNumNonDefault );
            
			// Pass the value of '_generalLiabilityPrepaymentDueDate' as parameter 'GeneralLiabilityPrepaymentDueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", _generalLiabilityPrepaymentDueDateNonDefault );
            
			// Pass the value of '_waiverCode' as parameter 'WaiverCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode", _waiverCodeNonDefault );
            
			// Pass the value of '_waiverCode2' as parameter 'WaiverCode2' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode2", _waiverCode2NonDefault );
            
			// Pass the value of '_overrideCapacity' as parameter 'OverrideCapacity' of the stored procedure.
			oDatabaseHelper.AddParameter("@OverrideCapacity", _overrideCapacityNonDefault );
            
			// Pass the value of '_rnCoordinator' as parameter 'RnCoordinator' of the stored procedure.
			oDatabaseHelper.AddParameter("@RnCoordinator", _rnCoordinatorNonDefault );
            
			// Pass the value of '_waiverCode3' as parameter 'WaiverCode3' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode3", _waiverCode3NonDefault );
            
			// Pass the value of '_waiverCode4' as parameter 'WaiverCode4' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode4", _waiverCode4NonDefault );
            
			// Pass the value of '_directorName' as parameter 'DirectorName' of the stored procedure.
			oDatabaseHelper.AddParameter("@DirectorName", _directorNameNonDefault );
            
			// Pass the value of '_waiverCode5' as parameter 'WaiverCode5' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode5", _waiverCode5NonDefault );
            
			// Pass the value of '_year1ReviewDateDue' as parameter 'Year1ReviewDateDue' of the stored procedure.
			oDatabaseHelper.AddParameter("@Year1ReviewDateDue", _year1ReviewDateDueNonDefault );
            
			// Pass the value of '_waiverCode6' as parameter 'WaiverCode6' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode6", _waiverCode6NonDefault );
            
			// Pass the value of '_waiverCode7' as parameter 'WaiverCode7' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode7", _waiverCode7NonDefault );
            
			// Pass the value of '_usage' as parameter 'Usage' of the stored procedure.
			oDatabaseHelper.AddParameter("@Usage", _usageNonDefault );
            
			// Pass the value of '_totalNumDialysisPatients' as parameter 'TotalNumDialysisPatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", _totalNumDialysisPatientsNonDefault );
            
			// Pass the value of '_accreditationExpirationDate' as parameter 'AccreditationExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AccreditationExpirationDate", _accreditationExpirationDateNonDefault );
            
			// Pass the value of '_hemodialysisNumPatients' as parameter 'HemodialysisNumPatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisNumPatients", _hemodialysisNumPatientsNonDefault );
            
			// Pass the value of '_facilityWithinFacility' as parameter 'FacilityWithinFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityWithinFacility", _facilityWithinFacilityNonDefault );
            
			// Pass the value of '_numOfPeritonealDialysisPatients' as parameter 'NumOfPeritonealDialysisPatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", _numOfPeritonealDialysisPatientsNonDefault );
            
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault );
            
			// Pass the value of '_hemodialysisNumOfStations' as parameter 'HemodialysisNumOfStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", _hemodialysisNumOfStationsNonDefault );
            
			// Pass the value of '_transplantYN' as parameter 'TransplantYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransplantYN", _transplantYNNonDefault );
            
			// Pass the value of '_hemodialysisTrainingNumOfStation' as parameter 'HemodialysisTrainingNumOfStation' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", _hemodialysisTrainingNumOfStationNonDefault );
            
			// Pass the value of '_obIntCode' as parameter 'ObIntCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObIntCode", _obIntCodeNonDefault );
            
			// Pass the value of '_obCurrentSurveyDate' as parameter 'ObCurrentSurveyDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ObCurrentSurveyDate", _obCurrentSurveyDateNonDefault );
            
			// Pass the value of '_totalNumStations' as parameter 'TotalNumStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalNumStations", _totalNumStationsNonDefault );
            
			// Pass the value of '_reuseYN' as parameter 'ReuseYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ReuseYN", _reuseYNNonDefault );
            
			// Pass the value of '_nicuCurrentSurveyDate' as parameter 'NicuCurrentSurveyDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@NicuCurrentSurveyDate", _nicuCurrentSurveyDateNonDefault );
            
			// Pass the value of '_manualYN' as parameter 'ManualYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ManualYN", _manualYNNonDefault );
            
			// Pass the value of '_picuCurrentSurveyDate' as parameter 'PicuCurrentSurveyDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@PicuCurrentSurveyDate", _picuCurrentSurveyDateNonDefault );
            
			// Pass the value of '_numOfPatientsFollowedAtHome' as parameter 'NumOfPatientsFollowedAtHome' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", _numOfPatientsFollowedAtHomeNonDefault );
            
			// Pass the value of '_traumaLevel' as parameter 'TraumaLevel' of the stored procedure.
			oDatabaseHelper.AddParameter("@TraumaLevel", _traumaLevelNonDefault );
            
			// Pass the value of '_semiautomatedYN' as parameter 'SemiautomatedYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@SemiautomatedYN", _semiautomatedYNNonDefault );
            
			// Pass the value of '_automatedYN' as parameter 'AutomatedYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomatedYN", _automatedYNNonDefault );
            
			// Pass the value of '_formainGermicide' as parameter 'FormainGermicide' of the stored procedure.
			oDatabaseHelper.AddParameter("@FormainGermicide", _formainGermicideNonDefault );
            
			// Pass the value of '_heatGermicide' as parameter 'HeatGermicide' of the stored procedure.
			oDatabaseHelper.AddParameter("@HeatGermicide", _heatGermicideNonDefault );
            
			// Pass the value of '_gluteraldetydeGermicide' as parameter 'GluteraldetydeGermicide' of the stored procedure.
			oDatabaseHelper.AddParameter("@GluteraldetydeGermicide", _gluteraldetydeGermicideNonDefault );
            
			// Pass the value of '_peraceticAcidMixtureGerm' as parameter 'PeraceticAcidMixtureGerm' of the stored procedure.
			oDatabaseHelper.AddParameter("@PeraceticAcidMixtureGerm", _peraceticAcidMixtureGermNonDefault );
            
			// Pass the value of '_otherGermicide' as parameter 'OtherGermicide' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherGermicide", _otherGermicideNonDefault );
            
			// Pass the value of '_enrolledRhcOffsiteYN' as parameter 'EnrolledRhcOffsiteYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", _enrolledRhcOffsiteYNNonDefault );
            
			// Pass the value of '_typeGermicideDescription' as parameter 'TypeGermicideDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeGermicideDescription", _typeGermicideDescriptionNonDefault );
            
			// Pass the value of '_hemodialysisService' as parameter 'HemodialysisService' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisService", _hemodialysisServiceNonDefault );
            
			// Pass the value of '_directorOfNursingFirstName' as parameter 'DirectorOfNursingFirstName' of the stored procedure.
			oDatabaseHelper.AddParameter("@DirectorOfNursingFirstName", _directorOfNursingFirstNameNonDefault );
            
			// Pass the value of '_peritonealDialysisService' as parameter 'PeritonealDialysisService' of the stored procedure.
			oDatabaseHelper.AddParameter("@PeritonealDialysisService", _peritonealDialysisServiceNonDefault );
            
			// Pass the value of '_directorOfNursingLastName' as parameter 'DirectorOfNursingLastName' of the stored procedure.
			oDatabaseHelper.AddParameter("@DirectorOfNursingLastName", _directorOfNursingLastNameNonDefault );
            
			// Pass the value of '_presidentFirstName' as parameter 'PresidentFirstName' of the stored procedure.
			oDatabaseHelper.AddParameter("@PresidentFirstName", _presidentFirstNameNonDefault );
            
			// Pass the value of '_transplanationService' as parameter 'TransplanationService' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransplanationService", _transplanationServiceNonDefault );
            
			// Pass the value of '_presidentLastName' as parameter 'PresidentLastName' of the stored procedure.
			oDatabaseHelper.AddParameter("@PresidentLastName", _presidentLastNameNonDefault );
            
			// Pass the value of '_homeTrainingService' as parameter 'HomeTrainingService' of the stored procedure.
			oDatabaseHelper.AddParameter("@HomeTrainingService", _homeTrainingServiceNonDefault );
            
			// Pass the value of '_staffingFteRN' as parameter 'StaffingFteRN' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffingFteRN", _staffingFteRNNonDefault );
            
			// Pass the value of '_staffingFteLpn' as parameter 'StaffingFteLpn' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffingFteLpn", _staffingFteLpnNonDefault );
            
			// Pass the value of '_staffingFteSW' as parameter 'StaffingFteSW' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffingFteSW", _staffingFteSWNonDefault );
            
			// Pass the value of '_staffingFteTechnicians' as parameter 'StaffingFteTechnicians' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffingFteTechnicians", _staffingFteTechniciansNonDefault );
            
			// Pass the value of '_staffingFteDietian' as parameter 'StaffingFteDietian' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffingFteDietian", _staffingFteDietianNonDefault );
            
			// Pass the value of '_staffingFteOthers' as parameter 'StaffingFteOthers' of the stored procedure.
			oDatabaseHelper.AddParameter("@StaffingFteOthers", _staffingFteOthersNonDefault );
            
			// Pass the value of '_initial' as parameter 'Initial' of the stored procedure.
			oDatabaseHelper.AddParameter("@Initial", _initialNonDefault );
            
			// Pass the value of '_initialDate' as parameter 'InitialDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@InitialDate", _initialDateNonDefault );
            
			// Pass the value of '_expansionToNewLocation' as parameter 'ExpansionToNewLocation' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpansionToNewLocation", _expansionToNewLocationNonDefault );
            
			// Pass the value of '_expToNewLocationDate' as parameter 'ExpToNewLocationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpToNewLocationDate", _expToNewLocationDateNonDefault );
            
			// Pass the value of '_changeOfOwnership' as parameter 'ChangeOfOwnership' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeOfOwnership", _changeOfOwnershipNonDefault );
            
			// Pass the value of '_changeOfLocation' as parameter 'ChangeOfLocation' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeOfLocation", _changeOfLocationNonDefault );
            
			// Pass the value of '_changeOfLocationDate' as parameter 'ChangeOfLocationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeOfLocationDate", _changeOfLocationDateNonDefault );
            
			// Pass the value of '_expansionInCurrentLocation' as parameter 'ExpansionInCurrentLocation' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpansionInCurrentLocation", _expansionInCurrentLocationNonDefault );
            
			// Pass the value of '_expansionInCurrentLocationDate' as parameter 'ExpansionInCurrentLocationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ExpansionInCurrentLocationDate", _expansionInCurrentLocationDateNonDefault );
            
			// Pass the value of '_changeOfServices' as parameter 'ChangeOfServices' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeOfServices", _changeOfServicesNonDefault );
            
			// Pass the value of '_changeOfServicesDate' as parameter 'ChangeOfServicesDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeOfServicesDate", _changeOfServicesDateNonDefault );
            
			// Pass the value of '_typeApplicationCode7' as parameter 'TypeApplicationCode7' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeApplicationCode7", _typeApplicationCode7NonDefault );
            
			// Pass the value of '_typeApplicationCode7Date' as parameter 'TypeApplicationCode7Date' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeApplicationCode7Date", _typeApplicationCode7DateNonDefault );
            
			// Pass the value of '_typeApplicationDescr' as parameter 'TypeApplicationDescr' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeApplicationDescr", _typeApplicationDescrNonDefault );
            
			// Pass the value of '_providerBasedYN' as parameter 'ProviderBasedYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProviderBasedYN", _providerBasedYNNonDefault );
            
			// Pass the value of '_midLevelWaiverYN' as parameter 'MidLevelWaiverYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@MidLevelWaiverYN", _midLevelWaiverYNNonDefault );
            
			// Pass the value of '_midLevelWaiverMonth' as parameter 'MidLevelWaiverMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@MidLevelWaiverMonth", _midLevelWaiverMonthNonDefault );
            
			// Pass the value of '_midLevelWaiverDate' as parameter 'MidLevelWaiverDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@MidLevelWaiverDate", _midLevelWaiverDateNonDefault );
            
			// Pass the value of '_relatedProviderLicensureNum' as parameter 'RelatedProviderLicensureNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", _relatedProviderLicensureNumNonDefault );
            
			// Pass the value of '_emergencyPrepReportRequired' as parameter 'EmergencyPrepReportRequired' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", _emergencyPrepReportRequiredNonDefault );
            
			// Pass the value of '_accreditedBody' as parameter 'AccreditedBody' of the stored procedure.
			oDatabaseHelper.AddParameter("@AccreditedBody", _accreditedBodyNonDefault );
            
			// Pass the value of '_enrolledInMedicaidYN' as parameter 'EnrolledInMedicaidYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", _enrolledInMedicaidYNNonDefault );
            
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault );
            
			// Pass the value of '_licensedByOther' as parameter 'LicensedByOther' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensedByOther", _licensedByOtherNonDefault );
            
			// Pass the value of '_licensureEffectiveDate' as parameter 'LicensureEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureEffectiveDate", _licensureEffectiveDateNonDefault );
            
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault );
            
			// Pass the value of '_numRadiologicTechBsba' as parameter 'NumRadiologicTechBsba' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumRadiologicTechBsba", _numRadiologicTechBsbaNonDefault );
            
			// Pass the value of '_numRadiologicTechAS' as parameter 'NumRadiologicTechAS' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumRadiologicTechAS", _numRadiologicTechASNonDefault );
            
			// Pass the value of '_numRadiologicTechCrt' as parameter 'NumRadiologicTechCrt' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumRadiologicTechCrt", _numRadiologicTechCrtNonDefault );
            
			// Pass the value of '_numRadiologicTechOther' as parameter 'NumRadiologicTechOther' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumRadiologicTechOther", _numRadiologicTechOtherNonDefault );
            
			// Pass the value of '_isolationNumOfStations' as parameter 'IsolationNumOfStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsolationNumOfStations", _isolationNumOfStationsNonDefault );
            
			// Pass the value of '_relatedProviderName' as parameter 'RelatedProviderName' of the stored procedure.
			oDatabaseHelper.AddParameter("@RelatedProviderName", _relatedProviderNameNonDefault );
            
			// Pass the value of '_numOperatingRooms' as parameter 'NumOperatingRooms' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumOperatingRooms", _numOperatingRoomsNonDefault );
            
			// Pass the value of '_admMultiFacYN' as parameter 'AdmMultiFacYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdmMultiFacYN", _admMultiFacYNNonDefault );
            
			// Pass the value of '_admMultiFacOtherName' as parameter 'AdmMultiFacOtherName' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdmMultiFacOtherName", _admMultiFacOtherNameNonDefault );
            
			// Pass the value of '_singleStoryYN' as parameter 'SingleStoryYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@SingleStoryYN", _singleStoryYNNonDefault );
            
			// Pass the value of '_closedDate' as parameter 'ClosedDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ClosedDate", _closedDateNonDefault );

            // Pass the value of '_year2ReviewDateDue' as parameter 'Year2ReviewDateDue' of the stored procedure.
            oDatabaseHelper.AddParameter("@Year2ReviewDateDue", _year2ReviewDateDueNonDefault);
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDERS_Update", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the property Information
		/// </summary>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDERS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ProviderPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ProviderPrimaryKey pk) 
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDERS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ProviderFields">Field of the class BO_Provider</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_PROVIDERS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ProviderPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Provider</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOne(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Provider obj=new BO_Provider();	
				PopulateObjectFromReader(obj,dr);
                dr.Close();              
				oDatabaseHelper.Dispose();
                return obj;
			}
			else
			{
                dr.Close();
                oDatabaseHelper.Dispose();
			    return null;
			}
			
		}

		/// <summary>
		/// This method will return a list of objects representing all records in the table.
		/// </summary>
		///
		/// <returns>list of objects of class BO_Provider in the form of object of BO_Providers </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Providers SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectAll", ref ExecutionState);
			BO_Providers BO_Providers = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Providers;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Provider</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Provider in the form of an object of class BO_Providers</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Providers SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectByField", ref ExecutionState);
			BO_Providers BO_Providers = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Providers;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithADDRESSUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithADDRESSUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_AddressesPopsIntID=BO_Address.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithAFFILIATIONUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithAFFILIATIONUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_AffiliationsPopsIntID=BO_Affiliation.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithAPPLICATIONSUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithAPPLICATIONSUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ApplicationsPopsIntID=BO_Application.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithBILLINGUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithBILLINGUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BillingsPopsIntID=BO_Billing.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithCAPACITIESUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithCAPACITIESUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_CapacitiesPopsIntID=BO_Capacity.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithCOMMENTSUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithCOMMENTSUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_CommentsPopsIntID=BO_Comment.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithINSURANCE_COVERAGEUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithINSURANCE_COVERAGEUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_InsuranceCoveragesPopsIntID=BO_InsuranceCoverage.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithLETTER_OF_INTENTUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithLETTER_OF_INTENTUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LetterOfIntentsPopsIntID=BO_LetterOfIntent.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithLICENSEUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithLICENSEUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LicensesPopsIntID=BO_License.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithMESSAGESUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithMESSAGESUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_MessagesPopsIntID=BO_Message.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithOWNERSHIPUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithOWNERSHIPUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_OwnershipsPopsIntID=BO_Ownership.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithPARISH_SERVEDUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithPARISH_SERVEDUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ParishServedsPopsIntID=BO_ParishServed.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithPROVIDER_PERSONUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithPROVIDER_PERSONUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProviderPeoplePopsIntID=BO_ProviderPerson.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithPROVIDER_LOGINUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithPROVIDER_LOGINUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProviderLoginsPopsIntID=BO_ProviderLogin.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithSERVICEUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithSERVICEUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ServicesPopsIntID=BO_Service.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithSPECIALTY_UNITUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithSPECIALTY_UNITUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_SpecialtyUnitsPopsIntID=BO_SpecialtyUnit.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithSTAFFINGUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithSTAFFINGUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_StaffingsPopsIntID=BO_Staffing.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithSUBSTATIONUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithSUBSTATIONUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_SubstationsPopsIntID=BO_Substation.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class PROVIDERS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Provider SelectOneWithVEHICLEUsingPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Provider obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectOneWithVEHICLEUsingPopsIntID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Provider();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_VehiclesPopsIntID=BO_Vehicle.PopulateObjectsFromReader(dr);
			}
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Providers</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Providers SelectAllByForeignKeyParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Providers obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectAllByForeignKeyParishCode", ref ExecutionState);
			obj = new BO_Providers();
			obj = BO_Provider.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PARISHESPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyParishCode(BO_ParishePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDERS_DeleteAllByForeignKeyParishCode", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Providers</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Providers SelectAllByForeignKeyProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Providers obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectAllByForeignKeyProgramID", ref ExecutionState);
			obj = new BO_Providers();
			obj = BO_Provider.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROGRAMSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDERS_DeleteAllByForeignKeyProgramID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="REGIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Providers</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Providers SelectAllByForeignKeyRegionCode(BO_RegionPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Providers obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_PROVIDERS_SelectAllByForeignKeyRegionCode", ref ExecutionState);
			obj = new BO_Providers();
			obj = BO_Provider.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="REGIONSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyRegionCode(BO_RegionPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteNonQuery("GEN_PROVIDERS_DeleteAllByForeignKeyRegionCode", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		#endregion	
		
        #region Methods (Private)

        /// <summary>
	    /// tests a string to be a well formed xml or not,
	    /// it throws ArgumentException when string text is not well formed.otherwise this 
        /// method is executed silently .
	    /// </summary>
	    /// <param name="text" type="string">xml string to validate.</param>
        /// <param name="fieldName" type="string">field Name to validate.</param>
	    /// <exception > throws ArgumentException when text is not well formed parameter.otherwise this 
        /// method is executed silently .</exception>
	    /// <remarks>
	    ///
	    /// <RevisionHistory>
	    /// Author				Date			Description
	    /// DLGenerator			08/20/2012 4:43:23 PM		Created function
	    /// 
	    /// </RevisionHistory>
	    ///
	    /// </remarks>
	    ///
	    internal static void IsValidXmlString(string text,string fieldName)
	    {
		    XmlTextReader r = new XmlTextReader(new StringReader(text));
		    try
		    {
			    while (r.Read())
			    {
                  /*do nothing ,just continue as long as xml is valid*/ 
                }
		    }
		    catch(Exception)
		    {
			    throw new ArgumentException ("Field ("+fieldName+") xml text argument isn't well formed");				
		    }
		    finally
		    {
			    r.Close();
  			
		    }
          //end silently(well formed xml)
	    }    
		/// <summary>
        /// Populates the fields of a single objects from the columns found in an open reader.
        /// </summary>
		/// <param name="obj" type="PROVIDERS">Object of PROVIDERS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ProviderBase obj,IDataReader rdr) 
		{

			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.StateID));
			}
			
			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.PopsIntID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AspenIntID)))
			{
				obj.AspenIntID = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.AspenIntID));
			}
			
			obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ProgramID));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StateCode)))
			{
				obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.StateCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ProgramStaffID)))
			{
				obj.ProgramStaffID = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.ProgramStaffID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ParishCode)))
			{
				obj.ParishCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ParishCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RegionCode)))
			{
				obj.RegionCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.RegionCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FederalID)))
			{
				obj.FederalID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FederalID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensureNum)))
			{
				obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LicensureNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeographicalStreetAddr2)))
			{
				obj.GeographicalStreetAddr2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeographicalStreetAddr2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SchoolID)))
			{
				obj.SchoolID = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.SchoolID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FacilityName)))
			{
				obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FacilityName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LegalName)))
			{
				obj.LegalName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LegalName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MailStreet2)))
			{
				obj.MailStreet2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MailStreet2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeographicalStreet)))
			{
				obj.GeographicalStreet = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeographicalStreet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeographicalCity)))
			{
				obj.GeographicalCity = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeographicalCity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeographicalZip)))
			{
				obj.GeographicalZip = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeographicalZip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeographicalState)))
			{
				obj.GeographicalState = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeographicalState));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MailStreet)))
			{
				obj.MailStreet = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MailStreet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MailCity)))
			{
				obj.MailCity = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MailCity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MailState)))
			{
				obj.MailState = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MailState));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MailZip)))
			{
				obj.MailZip = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MailZip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.EmsParishCode)))
			{
				obj.EmsParishCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.EmsParishCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Parish)))
			{
				obj.Parish = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.Parish));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RegionalOffice)))
			{
				obj.RegionalOffice = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.RegionalOffice));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ZoneNumCode)))
			{
				obj.ZoneNumCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ZoneNumCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TelephoneNumber)))
			{
				obj.TelephoneNumber = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TelephoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.EmergencyPhoneNumber)))
			{
				obj.EmergencyPhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.EmergencyPhoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FaxPhoneNumber)))
			{
				obj.FaxPhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FaxPhoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Administrator)))
			{
				obj.Administrator = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.Administrator));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdministratorTitle)))
			{
				obj.AdministratorTitle = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdministratorTitle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdministratorFirstName)))
			{
				obj.AdministratorFirstName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdministratorFirstName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdministratorMidInit)))
			{
				obj.AdministratorMidInit = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdministratorMidInit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdministratorLastName)))
			{
				obj.AdministratorLastName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdministratorLastName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ContactName)))
			{
				obj.ContactName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ContactName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StateIdMds)))
			{
				obj.StateIdMds = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.StateIdMds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StateLicNum)))
			{
				obj.StateLicNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.StateLicNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.EmailAddress)))
			{
				obj.EmailAddress = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.EmailAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicaidVendorNumber)))
			{
				obj.MedicaidVendorNumber = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicaidVendorNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FieldOfficeCode)))
			{
				obj.FieldOfficeCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FieldOfficeCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorFullName)))
			{
				obj.MedicalDirectorFullName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorFullName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorTitle)))
			{
				obj.MedicalDirectorTitle = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorTitle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirFirstName)))
			{
				obj.MedicalDirFirstName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirFirstName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirMidInit)))
			{
				obj.MedicalDirMidInit = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirMidInit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirLastName)))
			{
				obj.MedicalDirLastName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirLastName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailAddr1)))
			{
				obj.MedicalDirectorMailAddr1 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailAddr1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailAddr2)))
			{
				obj.MedicalDirectorMailAddr2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailAddr2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailCity)))
			{
				obj.MedicalDirectorMailCity = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailCity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailState)))
			{
				obj.MedicalDirectorMailState = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailState));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailZip)))
			{
				obj.MedicalDirectorMailZip = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalDirectorMailZip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HoursMinutes)))
			{
				obj.HoursMinutes = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HoursMinutes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Snf18beds)))
			{
				obj.Snf18beds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.Snf18beds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AmPM)))
			{
				obj.AmPM = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AmPM));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HoursMinutes1)))
			{
				obj.HoursMinutes1 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HoursMinutes1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AmPm1)))
			{
				obj.AmPm1 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AmPm1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationMon)))
			{
				obj.DayOfOperationMon = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationMon));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationTue)))
			{
				obj.DayOfOperationTue = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationTue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationWed)))
			{
				obj.DayOfOperationWed = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationWed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationThu)))
			{
				obj.DayOfOperationThu = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationThu));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationFri)))
			{
				obj.DayOfOperationFri = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationFri));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationSat)))
			{
				obj.DayOfOperationSat = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationSat));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationSun)))
			{
				obj.DayOfOperationSun = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DayOfOperationSun));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeLicenseCode)))
			{
				obj.TypeLicenseCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeLicenseCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeOfLicense)))
			{
				obj.TypeOfLicense = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeOfLicense));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacilityCode)))
			{
				obj.TypeFacilityCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacilityCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacility1Code)))
			{
				obj.TypeFacility1Code = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacility1Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacility2Code)))
			{
				obj.TypeFacility2Code = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacility2Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacility3Code)))
			{
				obj.TypeFacility3Code = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacility3Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacility4Code)))
			{
				obj.TypeFacility4Code = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacility4Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacility5Code)))
			{
				obj.TypeFacility5Code = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacility5Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeFacility6Code)))
			{
				obj.TypeFacility6Code = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeFacility6Code));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensedSnfFacility)))
			{
				obj.LicensedSnfFacility = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LicensedSnfFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Snf1819beds)))
			{
				obj.Snf1819beds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.Snf1819beds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Snf19beds)))
			{
				obj.Snf19beds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.Snf19beds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeOfClients)))
			{
				obj.TypeOfClients = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeOfClients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PsychiatricBeds)))
			{
				obj.PsychiatricBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.PsychiatricBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SnfBeds)))
			{
				obj.SnfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.SnfBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SwingBeds)))
			{
				obj.SwingBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.SwingBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RehabilitationBeds)))
			{
				obj.RehabilitationBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.RehabilitationBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalLicBeds)))
			{
				obj.TotalLicBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalLicBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.BedsCertified)))
			{
				obj.BedsCertified = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.BedsCertified));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeOwnershipCode)))
			{
				obj.TypeOwnershipCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeOwnershipCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameOfCorporation)))
			{
				obj.NameOfCorporation = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameOfCorporation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationIdNum)))
			{
				obj.CorporationIdNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationIdNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationStreet)))
			{
				obj.CorporationStreet = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationStreet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationCity)))
			{
				obj.CorporationCity = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationCity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationState)))
			{
				obj.CorporationState = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationState));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationZip)))
			{
				obj.CorporationZip = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationZip));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationPhone)))
			{
				obj.CorporationPhone = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationPhone));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CorporationFax)))
			{
				obj.CorporationFax = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CorporationFax));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner1)))
			{
				obj.NameOfOwner1 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner2)))
			{
				obj.NameOfOwner2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner3)))
			{
				obj.NameOfOwner3 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner3));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner4)))
			{
				obj.NameOfOwner4 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameOfOwner4));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PresidentName)))
			{
				obj.PresidentName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PresidentName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.VicePresidentName)))
			{
				obj.VicePresidentName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.VicePresidentName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SecretaryTreasurerName)))
			{
				obj.SecretaryTreasurerName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.SecretaryTreasurerName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.JcahYN)))
			{
				obj.JcahYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.JcahYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChangeOfOwnerDate)))
			{
				obj.ChangeOfOwnerDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ChangeOfOwnerDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OriginalLicensureDate)))
			{
				obj.OriginalLicensureDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.OriginalLicensureDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OriginalEnrollmentDate)))
			{
				obj.OriginalEnrollmentDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.OriginalEnrollmentDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CurrentLicIssueDate)))
			{
				obj.CurrentLicIssueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.CurrentLicIssueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensureExpirationDate)))
			{
				obj.LicensureExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.LicensureExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensureAnniversaryMth)))
			{
				obj.LicensureAnniversaryMth = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LicensureAnniversaryMth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Capacity)))
			{
				obj.Capacity = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.Capacity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CapacityInHome)))
			{
				obj.CapacityInHome = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.CapacityInHome));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CapacityOutOfHome)))
			{
				obj.CapacityOutOfHome = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.CapacityOutOfHome));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AgeRange)))
			{
				obj.AgeRange = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AgeRange));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Unit)))
			{
				obj.Unit = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.Unit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ForYearEndingMmdd)))
			{
				obj.ForYearEndingMmdd = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ForYearEndingMmdd));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HospitalBasedYN)))
			{
				obj.HospitalBasedYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HospitalBasedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ApplicationDate)))
			{
				obj.ApplicationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ApplicationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Fee)))
			{
				obj.Fee = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.Fee)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CheckNumber)))
			{
				obj.CheckNumber = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CheckNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DateFeeReceived)))
			{
				obj.DateFeeReceived = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.DateFeeReceived));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StateFireApprovalDate)))
			{
				obj.StateFireApprovalDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.StateFireApprovalDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HealthApprovalDate)))
			{
				obj.HealthApprovalDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.HealthApprovalDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CurSurv)))
			{
				obj.CurSurv = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.CurSurv));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.UsDeaRegNum)))
			{
				obj.UsDeaRegNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.UsDeaRegNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.UsDeaRegNumExpDate)))
			{
				obj.UsDeaRegNumExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.UsDeaRegNumExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LaCdsNum)))
			{
				obj.LaCdsNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LaCdsNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LaCdsNumExpDate)))
			{
				obj.LaCdsNumExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.LaCdsNumExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CliaIdNum)))
			{
				obj.CliaIdNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CliaIdNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CliaExpDate)))
			{
				obj.CliaExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.CliaExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CertEffectiveDate)))
			{
				obj.CertEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.CertEffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CertifExpirationDate)))
			{
				obj.CertifExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.CertifExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CertificationMth)))
			{
				obj.CertificationMth = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CertificationMth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LevelCode)))
			{
				obj.LevelCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LevelCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfAirAmbulances)))
			{
				obj.NoOfAirAmbulances = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfAirAmbulances));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfGroundAmbulances)))
			{
				obj.NoOfGroundAmbulances = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfGroundAmbulances));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfSprintVehicles)))
			{
				obj.NoOfSprintVehicles = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfSprintVehicles));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfAmbulatoryVehicles)))
			{
				obj.NoOfAmbulatoryVehicles = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfAmbulatoryVehicles));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalDailyCapacityAmbulatoryVehicle)))
			{
				obj.TotalDailyCapacityAmbulatoryVehicle = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalDailyCapacityAmbulatoryVehicle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfHandicappedVehicles)))
			{
				obj.NoOfHandicappedVehicles = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfHandicappedVehicles));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalDailyCapacityHandicappedVehicle)))
			{
				obj.TotalDailyCapacityHandicappedVehicle = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalDailyCapacityHandicappedVehicle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumberOfBeds)))
			{
				obj.NumberOfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumberOfBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsuranceCoverageLimit)))
			{
				obj.AutomobileInsuranceCoverageLimit = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsuranceCoverageLimit)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsuranceCarrierCode)))
			{
				obj.AutomobileInsuranceCarrierCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsuranceCarrierCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsurancePolicyNum)))
			{
				obj.AutomobileInsurancePolicyNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsurancePolicyNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsuranceExpirationDate)))
			{
				obj.AutomobileInsuranceExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsuranceExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityCoverageLimit)))
			{
				obj.GeneralLiabilityCoverageLimit = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityCoverageLimit)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityCarrierCode)))
			{
				obj.GeneralLiabilityCarrierCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityCarrierCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityPolicyNum)))
			{
				obj.GeneralLiabilityPolicyNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityPolicyNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FacilityWithinFacilityYN)))
			{
				obj.FacilityWithinFacilityYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FacilityWithinFacilityYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityExpirationDate)))
			{
				obj.GeneralLiabilityExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OtherBeds)))
			{
				obj.OtherBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.OtherBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticeCoverageLimit)))
			{
				obj.MedicalMalpracticeCoverageLimit = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticeCoverageLimit)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.UnitsNumTotal)))
			{
				obj.UnitsNumTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.UnitsNumTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticeCarrierCode)))
			{
				obj.MedicalMalpracticeCarrierCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticeCarrierCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalLicBedsTotal)))
			{
				obj.TotalLicBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalLicBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticePolicyNum)))
			{
				obj.MedicalMalpracticePolicyNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticePolicyNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PsychiatricBedsTotal)))
			{
				obj.PsychiatricBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.PsychiatricBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticeExpirationDate)))
			{
				obj.MedicalMalpracticeExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.MedicalMalpracticeExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.IsolationUnitYN)))
			{
				obj.IsolationUnitYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.IsolationUnitYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RehabilitationBedsTotal)))
			{
				obj.RehabilitationBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.RehabilitationBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SnfBedsTotal)))
			{
				obj.SnfBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.SnfBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StatusCode)))
			{
				obj.StatusCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.StatusCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.UnitsNumOffsiteTotal)))
			{
				obj.UnitsNumOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.UnitsNumOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StatusDate)))
			{
				obj.StatusDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.StatusDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalLicBedsOffsiteTotal)))
			{
				obj.TotalLicBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalLicBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfParishesServed)))
			{
				obj.NoOfParishesServed = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfParishesServed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PsychiatricBedsOffsiteTotal)))
			{
				obj.PsychiatricBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.PsychiatricBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensureSurveyDate)))
			{
				obj.LicensureSurveyDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.LicensureSurveyDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RehabBedsOffsiteTotal)))
			{
				obj.RehabBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.RehabBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Waivers)))
			{
				obj.Waivers = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.Waivers));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SnfBedsOffsiteTotal)))
			{
				obj.SnfBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.SnfBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OtherBedsOffsiteTotal)))
			{
				obj.OtherBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.OtherBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PsychPpsFederalID)))
			{
				obj.PsychPpsFederalID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PsychPpsFederalID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RehabPpsFederalID)))
			{
				obj.RehabPpsFederalID = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.RehabPpsFederalID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.UserLastMaint)))
			{
				obj.UserLastMaint = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.UserLastMaint));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PsychPpsCertEffectiveDate)))
			{
				obj.PsychPpsCertEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.PsychPpsCertEffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DateLastMaint)))
			{
				obj.DateLastMaint = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.DateLastMaint));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RehabPpsCertEffectiveDate)))
			{
				obj.RehabPpsCertEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.RehabPpsCertEffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TimeLastMaint)))
			{
				obj.TimeLastMaint = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TimeLastMaint));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OffsiteCampusYN)))
			{
				obj.OffsiteCampusYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.OffsiteCampusYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CertifiedBedOverrideYN)))
			{
				obj.CertifiedBedOverrideYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CertifiedBedOverrideYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MainCampusBeds)))
			{
				obj.MainCampusBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.MainCampusBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ForYearEndingDate)))
			{
				obj.ForYearEndingDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ForYearEndingDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NeonatalIntCode)))
			{
				obj.NeonatalIntCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NeonatalIntCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ServicesOffered)))
			{
				obj.ServicesOffered = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ServicesOffered));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PicuIntCode)))
			{
				obj.PicuIntCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PicuIntCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HalfwayHouse)))
			{
				obj.HalfwayHouse = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HalfwayHouse));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DeemedStatus)))
			{
				obj.DeemedStatus = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DeemedStatus));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.InPatient)))
			{
				obj.InPatient = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.InPatient));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChapAccreditionYN)))
			{
				obj.ChapAccreditionYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ChapAccreditionYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CrisisEmergency)))
			{
				obj.CrisisEmergency = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CrisisEmergency));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OutpatientTreatment)))
			{
				obj.OutpatientTreatment = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.OutpatientTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FiscalIntermediaryNum)))
			{
				obj.FiscalIntermediaryNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FiscalIntermediaryNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MethadoneTreatment)))
			{
				obj.MethadoneTreatment = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MethadoneTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AttesestationStatement)))
			{
				obj.AttesestationStatement = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AttesestationStatement));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PreventionEducation)))
			{
				obj.PreventionEducation = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PreventionEducation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AttesestationStmtDateSigned)))
			{
				obj.AttesestationStmtDateSigned = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.AttesestationStmtDateSigned));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ResidentialTreatment)))
			{
				obj.ResidentialTreatment = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ResidentialTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameChangePrevName1)))
			{
				obj.NameChangePrevName1 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameChangePrevName1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SocialSettingDetoxification)))
			{
				obj.SocialSettingDetoxification = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.SocialSettingDetoxification));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameChangeDate1)))
			{
				obj.NameChangeDate1 = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.NameChangeDate1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdultHealthCare)))
			{
				obj.AdultHealthCare = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdultHealthCare));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameChangePrevName2)))
			{
				obj.NameChangePrevName2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.NameChangePrevName2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NameChangeDate2)))
			{
				obj.NameChangeDate2 = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.NameChangeDate2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CnatTrainingCode)))
			{
				obj.CnatTrainingCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CnatTrainingCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CnatTrainingSuspendDate)))
			{
				obj.CnatTrainingSuspendDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.CnatTrainingSuspendDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PreviousOwner1)))
			{
				obj.PreviousOwner1 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PreviousOwner1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PrevOwnerChangeDate1)))
			{
				obj.PrevOwnerChangeDate1 = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.PrevOwnerChangeDate1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AssistDirOfNursingWaiverMonth)))
			{
				obj.AssistDirOfNursingWaiverMonth = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AssistDirOfNursingWaiverMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Day7RnWaiverMonth)))
			{
				obj.Day7RnWaiverMonth = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.Day7RnWaiverMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PreviousOwner2)))
			{
				obj.PreviousOwner2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PreviousOwner2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PrevOwnerChangeDate2)))
			{
				obj.PrevOwnerChangeDate2 = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.PrevOwnerChangeDate2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.CurrentSurveyMonth)))
			{
				obj.CurrentSurveyMonth = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.CurrentSurveyMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FiscalIntermediaryDesc)))
			{
				obj.FiscalIntermediaryDesc = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FiscalIntermediaryDesc));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MedicareInterPrefCode)))
			{
				obj.MedicareInterPrefCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MedicareInterPrefCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ProgramCode)))
			{
				obj.ProgramCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ProgramCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoTreatmentsPerWeek)))
			{
				obj.NoTreatmentsPerWeek = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoTreatmentsPerWeek));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOfStations)))
			{
				obj.NoOfStations = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOfStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LevelDescription)))
			{
				obj.LevelDescription = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LevelDescription));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomaticCancellationDate)))
			{
				obj.AutomaticCancellationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.AutomaticCancellationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NoOf3hrShiftsWeek)))
			{
				obj.NoOf3hrShiftsWeek = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NoOf3hrShiftsWeek));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FcertBeds)))
			{
				obj.FcertBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.FcertBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AverageNumPatientsShift)))
			{
				obj.AverageNumPatientsShift = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.AverageNumPatientsShift));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsurancePrepaymentDueDate)))
			{
				obj.AutomobileInsurancePrepaymentDueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.AutomobileInsurancePrepaymentDueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.VendorNum)))
			{
				obj.VendorNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.VendorNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityPrepaymentDueDate)))
			{
				obj.GeneralLiabilityPrepaymentDueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.GeneralLiabilityPrepaymentDueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode)))
			{
				obj.WaiverCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode2)))
			{
				obj.WaiverCode2 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OverrideCapacity)))
			{
				obj.OverrideCapacity = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.OverrideCapacity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RnCoordinator)))
			{
				obj.RnCoordinator = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.RnCoordinator));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode3)))
			{
				obj.WaiverCode3 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode3));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode4)))
			{
				obj.WaiverCode4 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode4));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DirectorName)))
			{
				obj.DirectorName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DirectorName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode5)))
			{
				obj.WaiverCode5 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode5));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Year1ReviewDateDue)))
			{
				obj.Year1ReviewDateDue = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.Year1ReviewDateDue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode6)))
			{
				obj.WaiverCode6 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode6));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.WaiverCode7)))
			{
				obj.WaiverCode7 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.WaiverCode7));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Usage)))
			{
				obj.Usage = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.Usage));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalNumDialysisPatients)))
			{
				obj.TotalNumDialysisPatients = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalNumDialysisPatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AccreditationExpirationDate)))
			{
				obj.AccreditationExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.AccreditationExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HemodialysisNumPatients)))
			{
				obj.HemodialysisNumPatients = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.HemodialysisNumPatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FacilityWithinFacility)))
			{
				obj.FacilityWithinFacility = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FacilityWithinFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumOfPeritonealDialysisPatients)))
			{
				obj.NumOfPeritonealDialysisPatients = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumOfPeritonealDialysisPatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FacilityTypeCode)))
			{
				obj.FacilityTypeCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FacilityTypeCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HemodialysisNumOfStations)))
			{
				obj.HemodialysisNumOfStations = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.HemodialysisNumOfStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TransplantYN)))
			{
				obj.TransplantYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TransplantYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HemodialysisTrainingNumOfStation)))
			{
				obj.HemodialysisTrainingNumOfStation = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.HemodialysisTrainingNumOfStation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ObIntCode)))
			{
				obj.ObIntCode = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ObIntCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ObCurrentSurveyDate)))
			{
				obj.ObCurrentSurveyDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ObCurrentSurveyDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TotalNumStations)))
			{
				obj.TotalNumStations = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.TotalNumStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ReuseYN)))
			{
				obj.ReuseYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ReuseYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NicuCurrentSurveyDate)))
			{
				obj.NicuCurrentSurveyDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.NicuCurrentSurveyDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ManualYN)))
			{
				obj.ManualYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ManualYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PicuCurrentSurveyDate)))
			{
				obj.PicuCurrentSurveyDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.PicuCurrentSurveyDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumOfPatientsFollowedAtHome)))
			{
				obj.NumOfPatientsFollowedAtHome = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumOfPatientsFollowedAtHome));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TraumaLevel)))
			{
				obj.TraumaLevel = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TraumaLevel));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SemiautomatedYN)))
			{
				obj.SemiautomatedYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.SemiautomatedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AutomatedYN)))
			{
				obj.AutomatedYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AutomatedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.FormainGermicide)))
			{
				obj.FormainGermicide = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.FormainGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HeatGermicide)))
			{
				obj.HeatGermicide = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HeatGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.GluteraldetydeGermicide)))
			{
				obj.GluteraldetydeGermicide = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.GluteraldetydeGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PeraceticAcidMixtureGerm)))
			{
				obj.PeraceticAcidMixtureGerm = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PeraceticAcidMixtureGerm));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.OtherGermicide)))
			{
				obj.OtherGermicide = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.OtherGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.EnrolledRhcOffsiteYN)))
			{
				obj.EnrolledRhcOffsiteYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.EnrolledRhcOffsiteYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeGermicideDescription)))
			{
				obj.TypeGermicideDescription = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeGermicideDescription));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HemodialysisService)))
			{
				obj.HemodialysisService = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HemodialysisService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DirectorOfNursingFirstName)))
			{
				obj.DirectorOfNursingFirstName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DirectorOfNursingFirstName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PeritonealDialysisService)))
			{
				obj.PeritonealDialysisService = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PeritonealDialysisService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.DirectorOfNursingLastName)))
			{
				obj.DirectorOfNursingLastName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.DirectorOfNursingLastName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PresidentFirstName)))
			{
				obj.PresidentFirstName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PresidentFirstName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TransplanationService)))
			{
				obj.TransplanationService = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TransplanationService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.PresidentLastName)))
			{
				obj.PresidentLastName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.PresidentLastName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.HomeTrainingService)))
			{
				obj.HomeTrainingService = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.HomeTrainingService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StaffingFteRN)))
			{
				obj.StaffingFteRN = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.StaffingFteRN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StaffingFteLpn)))
			{
				obj.StaffingFteLpn = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.StaffingFteLpn));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StaffingFteSW)))
			{
				obj.StaffingFteSW = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.StaffingFteSW));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StaffingFteTechnicians)))
			{
				obj.StaffingFteTechnicians = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.StaffingFteTechnicians));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StaffingFteDietian)))
			{
				obj.StaffingFteDietian = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.StaffingFteDietian));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.StaffingFteOthers)))
			{
				obj.StaffingFteOthers = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.StaffingFteOthers));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Initial)))
			{
				obj.Initial = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.Initial));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.InitialDate)))
			{
				obj.InitialDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.InitialDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ExpansionToNewLocation)))
			{
				obj.ExpansionToNewLocation = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ExpansionToNewLocation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ExpToNewLocationDate)))
			{
				obj.ExpToNewLocationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ExpToNewLocationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChangeOfOwnership)))
			{
				obj.ChangeOfOwnership = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ChangeOfOwnership));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChangeOfLocation)))
			{
				obj.ChangeOfLocation = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ChangeOfLocation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChangeOfLocationDate)))
			{
				obj.ChangeOfLocationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ChangeOfLocationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ExpansionInCurrentLocation)))
			{
				obj.ExpansionInCurrentLocation = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ExpansionInCurrentLocation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ExpansionInCurrentLocationDate)))
			{
				obj.ExpansionInCurrentLocationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ExpansionInCurrentLocationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChangeOfServices)))
			{
				obj.ChangeOfServices = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ChangeOfServices));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ChangeOfServicesDate)))
			{
				obj.ChangeOfServicesDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ChangeOfServicesDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeApplicationCode7)))
			{
				obj.TypeApplicationCode7 = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeApplicationCode7));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeApplicationCode7Date)))
			{
				obj.TypeApplicationCode7Date = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.TypeApplicationCode7Date));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeApplicationDescr)))
			{
				obj.TypeApplicationDescr = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeApplicationDescr));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ProviderBasedYN)))
			{
				obj.ProviderBasedYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.ProviderBasedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MidLevelWaiverYN)))
			{
				obj.MidLevelWaiverYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MidLevelWaiverYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MidLevelWaiverMonth)))
			{
				obj.MidLevelWaiverMonth = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.MidLevelWaiverMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.MidLevelWaiverDate)))
			{
				obj.MidLevelWaiverDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.MidLevelWaiverDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RelatedProviderLicensureNum)))
			{
				obj.RelatedProviderLicensureNum = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.RelatedProviderLicensureNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.EmergencyPrepReportRequired)))
			{
				obj.EmergencyPrepReportRequired = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.EmergencyPrepReportRequired));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AccreditedBody)))
			{
				obj.AccreditedBody = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AccreditedBody));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.EnrolledInMedicaidYN)))
			{
				obj.EnrolledInMedicaidYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.EnrolledInMedicaidYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.TypeTreatment)))
			{
				obj.TypeTreatment = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.TypeTreatment));
			}
			
			obj.LicensedByOther = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.LicensedByOther));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.LicensureEffectiveDate)))
			{
				obj.LicensureEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.LicensureEffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumActivePatients)))
			{
				obj.NumActivePatients = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumActivePatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechBsba)))
			{
				obj.NumRadiologicTechBsba = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechBsba));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechAS)))
			{
				obj.NumRadiologicTechAS = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechAS));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechCrt)))
			{
				obj.NumRadiologicTechCrt = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechCrt));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechOther)))
			{
				obj.NumRadiologicTechOther = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumRadiologicTechOther));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.IsolationNumOfStations)))
			{
				obj.IsolationNumOfStations = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.IsolationNumOfStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.RelatedProviderName)))
			{
				obj.RelatedProviderName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.RelatedProviderName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.NumOperatingRooms)))
			{
				obj.NumOperatingRooms = rdr.GetInt32(rdr.GetOrdinal(BO_ProviderFields.NumOperatingRooms));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdmMultiFacYN)))
			{
				obj.AdmMultiFacYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdmMultiFacYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.AdmMultiFacOtherName)))
			{
				obj.AdmMultiFacOtherName = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.AdmMultiFacOtherName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.SingleStoryYN)))
			{
				obj.SingleStoryYN = rdr.GetString(rdr.GetOrdinal(BO_ProviderFields.SingleStoryYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.ClosedDate)))
			{
				obj.ClosedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.ClosedDate));
			}

            if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ProviderFields.Year2ReviewDateDue)))
            {
                obj.Year2ReviewDateDue = rdr.GetDateTime(rdr.GetOrdinal(BO_ProviderFields.Year2ReviewDateDue));
            }
		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Providers</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Providers PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Providers list = new BO_Providers();
			
			while (rdr.Read())
			{
				BO_Provider obj = new BO_Provider();
				PopulateObjectFromReader(obj,rdr);
				list.Add(obj);
			}
			return list;
			
		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Providers</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			08/20/2012 4:43:23 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Providers PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Providers list = new BO_Providers();
			
            if (rdr.Read())
            {
                BO_Provider obj = new BO_Provider();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Provider();
                    PopulateObjectFromReader(obj, rdr);
                    list.Add(obj);
                }
                oDatabaseHelper.Dispose();
                return list;
            }
            else
            {
                oDatabaseHelper.Dispose();
                return null;
            }
			
		}

	
    #endregion

	}
}
