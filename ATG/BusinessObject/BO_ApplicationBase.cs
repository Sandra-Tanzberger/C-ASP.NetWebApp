//
// Class	:	BO_ApplicationBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/15/2017 2:04:59 PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
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
	public class BO_ApplicationFields
	{
		public const string ApplicationID             = "APPLICATION_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string BusinessProcessID         = "BUSINESS_PROCESS_ID";
		public const string StateID                   = "STATE_ID";
		public const string ProgramID                 = "PROGRAM_ID";
		public const string DateStarted               = "DATE_STARTED";
		public const string DateCompleted             = "DATE_COMPLETED";
		public const string LicensureEffectiveDate    = "LICENSURE_EFFECTIVE_DATE";
		public const string ApplicationStatus         = "APPLICATION_STATUS";
		public const string FacilityName              = "FACILITY_NAME";
		public const string LegalName                 = "LEGAL_NAME";
		public const string StateCode                 = "STATE_CODE";
		public const string ParishCode                = "PARISH_CODE";
		public const string RegionCode                = "REGION_CODE";
		public const string FederalID                 = "FEDERAL_ID";
		public const string LicensureNum              = "LICENSURE_NUM";
		public const string SchoolID                  = "SCHOOL_ID";
		public const string EmsParishCode             = "EMS_PARISH_CODE";
		public const string RegionalOffice            = "REGIONAL_OFFICE";
		public const string ZoneNumCode               = "ZONE_NUM_CODE";
		public const string TelephoneNumber           = "TELEPHONE_NUMBER";
		public const string ContactName               = "CONTACT_NAME";
		public const string EmergencyPhoneNumber      = "EMERGENCY_PHONE_NUMBER";
		public const string FaxPhoneNumber            = "FAX_PHONE_NUMBER";
		public const string StateIdMds                = "STATE_ID_MDS";
		public const string StateLicNum               = "STATE_LIC_NUM";
		public const string EmailAddress              = "EMAIL_ADDRESS";
		public const string MedicaidVendorNumber      = "MEDICAID_VENDOR_NUMBER";
		public const string FieldOfficeCode           = "FIELD_OFFICE_CODE";
		public const string HoursMinutes              = "HOURS_MINUTES";
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
		public const string TypeFacility              = "TYPE_FACILITY";
		public const string TypeFacility1             = "TYPE_FACILITY_1";
		public const string TypeFacility2             = "TYPE_FACILITY_2";
		public const string TypeFacility3             = "TYPE_FACILITY_3";
		public const string TypeFacility4             = "TYPE_FACILITY_4";
		public const string TypeFacility5             = "TYPE_FACILITY_5";
		public const string TypeFacility6             = "TYPE_FACILITY_6";
		public const string LicensedSnfFacility       = "LICENSED_SNF_FACILITY";
		public const string TypeOfClients             = "TYPE_OF_CLIENTS";
		public const string JcahYN                    = "JCAH_YN";
		public const string StateFireApprovalDate     = "STATE_FIRE_APPROVAL_DATE";
		public const string AgeRange                  = "AGE_RANGE";
		public const string HealthApprovalDate        = "HEALTH_APPROVAL_DATE";
		public const string CurSurv                   = "CUR_SURV";
		public const string HospitalBasedYN           = "HOSPITAL_BASED_YN";
		public const string ApplicationDate           = "APPLICATION_DATE";
		public const string UsDeaRegNum               = "US_DEA_REG_NUM";
		public const string UsDeaRegNumExpDate        = "US_DEA_REG_NUM_EXP_DATE";
		public const string LaCdsNum                  = "LA_CDS_NUM";
		public const string LaCdsNumExpDate           = "LA_CDS_NUM_EXP_DATE";
		public const string CliaIdNum                 = "CLIA_ID_NUM";
		public const string CliaExpDate               = "CLIA_EXP_DATE";
		public const string NoOfAirAmbulances         = "NO_OF_AIR_AMBULANCES";
		public const string NoOfGroundAmbulances      = "NO_OF_GROUND_AMBULANCES";
		public const string NoOfSprintVehicles        = "NO_OF_SPRINT_VEHICLES";
		public const string NoOfAmbulatoryVehicles    = "NO_OF_AMBULATORY_VEHICLES";
		public const string TotalDailyCapacityAmbulatoryVehicle = "TOTAL_DAILY_CAPACITY_AMBULATORY_VEHICLE";
		public const string NoOfHandicappedVehicles   = "NO_OF_HANDICAPPED_VEHICLES";
		public const string TotalDailyCapacityHandicappedVehicle = "TOTAL_DAILY_CAPACITY_HANDICAPPED_VEHICLE";
		public const string IsolationUnitYN           = "ISOLATION_UNIT_YN";
		public const string StatusCode                = "STATUS_CODE";
		public const string StatusDate                = "STATUS_DATE";
		public const string NoOfParishesServed        = "NO_OF_PARISHES_SERVED";
		public const string LicensureSurveyDate       = "LICENSURE_SURVEY_DATE";
		public const string Waivers                   = "WAIVERS";
		public const string UserLastMaint             = "USER_LAST_MAINT";
		public const string DateLastMaint             = "DATE_LAST_MAINT";
		public const string TimeLastMaint             = "TIME_LAST_MAINT";
		public const string OffsiteCampusYN           = "OFFSITE_CAMPUS_YN";
		public const string DeemedStatus              = "DEEMED_STATUS";
		public const string ChapAccreditionYN         = "CHAP_ACCREDITION_YN";
		public const string FiscalIntermediaryNum     = "FISCAL_INTERMEDIARY_NUM";
		public const string FiscalIntermediaryDesc    = "FISCAL_INTERMEDIARY_DESC";
		public const string NoTreatmentsPerWeek       = "NO_TREATMENTS_PER_WEEK";
		public const string NoOfStations              = "NO_OF_STATIONS";
		public const string NoOf3hrShiftsWeek         = "NO_OF_3HR_SHIFTS_WEEK";
		public const string AverageNumPatientsShift   = "AVERAGE_NUM_PATIENTS_SHIFT";
		public const string VendorNum                 = "VENDOR_NUM";
		public const string WaiverCode                = "WAIVER_CODE";
		public const string WaiverCode2               = "WAIVER_CODE_2";
		public const string WaiverCode3               = "WAIVER_CODE_3";
		public const string WaiverCode4               = "WAIVER_CODE_4";
		public const string WaiverCode5               = "WAIVER_CODE_5";
		public const string WaiverCode6               = "WAIVER_CODE_6";
		public const string WaiverCode7               = "WAIVER_CODE_7";
		public const string AccreditationExpirationDate = "ACCREDITATION_EXPIRATION_DATE";
		public const string FacilityWithinFacility    = "FACILITY_WITHIN_FACILITY";
		public const string FacilityTypeCode          = "FACILITY_TYPE_CODE";
		public const string TransplantYN              = "TRANSPLANT_YN";
		public const string EnrolledRhcOffsiteYN      = "ENROLLED_RHC_OFFSITE_YN";
		public const string FacilityWithinFacilityYN  = "FACILITY_WITHIN_FACILITY_YN";
		public const string CertifiedBedOverrideYN    = "CERTIFIED_BED_OVERRIDE_YN";
		public const string ForYearEndingDate         = "FOR_YEAR_ENDING_DATE";
		public const string ServicesOffered           = "SERVICES_OFFERED";
		public const string HalfwayHouse              = "HALFWAY_HOUSE";
		public const string InPatient                 = "IN_PATIENT";
		public const string CrisisEmergency           = "CRISIS_EMERGENCY";
		public const string OutpatientTreatment       = "OUTPATIENT_TREATMENT";
		public const string MethadoneTreatment        = "METHADONE_TREATMENT";
		public const string PreventionEducation       = "PREVENTION_EDUCATION";
		public const string ResidentialTreatment      = "RESIDENTIAL_TREATMENT";
		public const string SocialSettingDetoxification = "SOCIAL_SETTING_DETOXIFICATION";
		public const string AdultHealthCare           = "ADULT_HEALTH_CARE";
		public const string CnatTrainingCode          = "CNAT_TRAINING_CODE";
		public const string CnatTrainingSuspendDate   = "CNAT_TRAINING_SUSPEND_DATE";
		public const string AssistDirOfNursingWaiverMonth = "ASSIST_DIR_OF_NURSING_WAIVER_MONTH";
		public const string Day7RnWaiverMonth         = "DAY7_RN_WAIVER_MONTH";
		public const string CurrentSurveyMonth        = "CURRENT_SURVEY_MONTH";
		public const string MedicareInterPrefCode     = "MEDICARE_INTER_PREF_CODE";
		public const string ProgramCode               = "PROGRAM_CODE";
		public const string LevelDescription          = "LEVEL_DESCRIPTION";
		public const string AutomaticCancellationDate = "AUTOMATIC_CANCELLATION_DATE";
		public const string NumOfPatientsFollowedAtHome = "NUM_OF_PATIENTS_FOLLOWED_AT_HOME";
		public const string AutomobileInsurancePrepaymentDueDate = "AUTOMOBILE_INSURANCE_PREPAYMENT_DUE_DATE";
		public const string GeneralLiabilityPrepaymentDueDate = "GENERAL_LIABILITY_PREPAYMENT_DUE_DATE";
		public const string OverrideCapacity          = "OVERRIDE_CAPACITY";
		public const string RnCoordinator             = "RN_COORDINATOR";
		public const string DirectorName              = "DIRECTOR_NAME";
		public const string Year1ReviewDateDue        = "YEAR1_REVIEW_DATE_DUE";
		public const string TotalNumDialysisPatients  = "TOTAL_NUM_DIALYSIS_PATIENTS";
		public const string HemodialysisNumPatients   = "HEMODIALYSIS_NUM_PATIENTS";
		public const string NumOfPeritonealDialysisPatients = "NUM_OF_PERITONEAL_DIALYSIS_PATIENTS";
		public const string HemodialysisNumOfStations = "HEMODIALYSIS_NUM_OF_STATIONS";
		public const string HemodialysisTrainingNumOfStation = "HEMODIALYSIS_TRAINING_NUM_OF_STATION";
		public const string TotalNumStations          = "TOTAL_NUM_STATIONS";
		public const string ReuseYN                   = "REUSE_YN";
		public const string ManualYN                  = "MANUAL_YN";
		public const string SemiautomatedYN           = "SEMIAUTOMATED_YN";
		public const string AutomatedYN               = "AUTOMATED_YN";
		public const string FormainGermicide          = "FORMAIN_GERMICIDE";
		public const string HeatGermicide             = "HEAT_GERMICIDE";
		public const string GluteraldetydeGermicide   = "GLUTERALDETYDE_GERMICIDE";
		public const string PeraceticAcidMixtureGerm  = "PERACETIC_ACID_MIXTURE_GERM";
		public const string OtherGermicide            = "OTHER_GERMICIDE";
		public const string TypeGermicideDescription  = "TYPE_GERMICIDE_DESCRIPTION";
		public const string HemodialysisService       = "HEMODIALYSIS_SERVICE";
		public const string PeritonealDialysisService = "PERITONEAL_DIALYSIS_SERVICE";
		public const string TransplanationService     = "TRANSPLANATION_SERVICE";
		public const string HomeTrainingService       = "HOME_TRAINING_SERVICE";
		public const string EmergencyPrepReportRequired = "EMERGENCY_PREP_REPORT_REQUIRED";
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
		public const string RelatedProviderLicensureNum = "RELATED_PROVIDER_LICENSURE_NUM";
		public const string AccreditedBody            = "ACCREDITED_BODY";
		public const string LicensureExpirationDate   = "LICENSURE_EXPIRATION_DATE";
		public const string EnrolledInMedicaidYN      = "ENROLLED_IN_MEDICAID_YN";
		public const string SubmissionDate            = "SUBMISSION_DATE";
		public const string TotalLicBeds              = "TOTAL_LIC_BEDS";
		public const string StatusComment             = "STATUS_COMMENT";
		public const string Unit                      = "UNIT";
		public const string TypeTreatment             = "TYPE_TREATMENT";
		public const string ChangeAddressLocType      = "CHANGE_ADDRESS_LOC_TYPE";
		public const string ChangeAddressLocID        = "CHANGE_ADDRESS_LOC_ID";
		public const string KeyPersonnelChange        = "KEY_PERSONNEL_CHANGE";
		public const string ProposedEffectiveDate     = "PROPOSED_EFFECTIVE_DATE";
		public const string ApplicationAction         = "APPLICATION_ACTION";
		public const string AgeRangeFrom              = "AGE_RANGE_FROM";
		public const string AgeRangeTO                = "AGE_RANGE_TO";
		public const string Snf18beds                 = "SNF18BEDS";
		public const string Snf1819beds               = "SNF1819BEDS";
		public const string Snf19beds                 = "SNF19BEDS";
		public const string PsychiatricBeds           = "PSYCHIATRIC_BEDS";
		public const string SnfBeds                   = "SNF_BEDS";
		public const string SwingBeds                 = "SWING_BEDS";
		public const string RehabilitationBeds        = "REHABILITATION_BEDS";
		public const string BedsCertified             = "BEDS_CERTIFIED";
		public const string NumberOfBeds              = "NUMBER_OF_BEDS";
		public const string OtherBeds                 = "OTHER_BEDS";
		public const string UnitsNumTotal             = "UNITS_NUM_TOTAL";
		public const string TotalLicBedsTotal         = "TOTAL_LIC_BEDS_TOTAL";
		public const string PsychiatricBedsTotal      = "PSYCHIATRIC_BEDS_TOTAL";
		public const string RehabilitationBedsTotal   = "REHABILITATION_BEDS_TOTAL";
		public const string SnfBedsTotal              = "SNF_BEDS_TOTAL";
		public const string UnitsNumOffsiteTotal      = "UNITS_NUM_OFFSITE_TOTAL";
		public const string TotalLicBedsOffsiteTotal  = "TOTAL_LIC_BEDS_OFFSITE_TOTAL";
		public const string PsychiatricBedsOffsiteTotal = "PSYCHIATRIC_BEDS_OFFSITE_TOTAL";
		public const string RehabBedsOffsiteTotal     = "REHAB_BEDS_OFFSITE_TOTAL";
		public const string SnfBedsOffsiteTotal       = "SNF_BEDS_OFFSITE_TOTAL";
		public const string OtherBedsOffsiteTotal     = "OTHER_BEDS_OFFSITE_TOTAL";
		public const string FcertBeds                 = "FCERT_BEDS";
		public const string OtherBedsTotal            = "OTHER_BEDS_TOTAL";
		public const string CurrentLicIssueDate       = "CURRENT_LIC_ISSUE_DATE";
		public const string OriginalLicensureDate     = "ORIGINAL_LICENSURE_DATE";
		public const string LicEffectiveDateOveride   = "LIC_EFFECTIVE_DATE_OVERIDE";
		public const string LicExpireDateOveride      = "LIC_EXPIRE_DATE_OVERIDE";
		public const string Capacity                  = "CAPACITY";
		public const string CapacityProvTotal         = "CAPACITY_PROV_TOTAL";
		public const string NumActivePatients         = "NUM_ACTIVE_PATIENTS";
		public const string OperationPrior2005        = "OPERATION_PRIOR_2005";
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
		public const string Year2ReviewDateDue        = "YEAR2_REVIEW_DATE_DUE";
		public const string LevelCode                 = "LEVEL_CODE";
		public const string OriginalEnrollmentDate    = "ORIGINAL_ENROLLMENT_DATE";
	}
	
	/// <summary>
	/// Data access class for the "APPLICATIONS" table.
	/// </summary>
	[Serializable]
	public class BO_ApplicationBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_businessProcessIDNonDefault	= null;
		private string         	_stateIDNonDefault       	= null;
		private string         	_programIDNonDefault     	= null;
		private DateTime?      	_dateStartedNonDefault   	= null;
		private DateTime?      	_dateCompletedNonDefault 	= null;
		private DateTime?      	_licensureEffectiveDateNonDefault	= null;
		private string         	_applicationStatusNonDefault	= null;
		private string         	_facilityNameNonDefault  	= null;
		private string         	_legalNameNonDefault     	= null;
		private string         	_stateCodeNonDefault     	= null;
		private string         	_parishCodeNonDefault    	= null;
		private string         	_regionCodeNonDefault    	= null;
		private string         	_federalIDNonDefault     	= null;
		private string         	_licensureNumNonDefault  	= null;
		private string         	_schoolIDNonDefault      	= null;
		private string         	_emsParishCodeNonDefault 	= null;
		private string         	_regionalOfficeNonDefault	= null;
		private string         	_zoneNumCodeNonDefault   	= null;
		private string         	_telephoneNumberNonDefault	= null;
		private string         	_contactNameNonDefault   	= null;
		private string         	_emergencyPhoneNumberNonDefault	= null;
		private string         	_faxPhoneNumberNonDefault	= null;
		private string         	_stateIdMdsNonDefault    	= null;
		private string         	_stateLicNumNonDefault   	= null;
		private string         	_emailAddressNonDefault  	= null;
		private string         	_medicaidVendorNumberNonDefault	= null;
		private string         	_fieldOfficeCodeNonDefault	= null;
		private string         	_hoursMinutesNonDefault  	= null;
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
		private string         	_typeFacilityNonDefault  	= null;
		private string         	_typeFacility1NonDefault 	= null;
		private string         	_typeFacility2NonDefault 	= null;
		private string         	_typeFacility3NonDefault 	= null;
		private string         	_typeFacility4NonDefault 	= null;
		private string         	_typeFacility5NonDefault 	= null;
		private string         	_typeFacility6NonDefault 	= null;
		private string         	_licensedSnfFacilityNonDefault	= null;
		private string         	_typeOfClientsNonDefault 	= null;
		private string         	_jcahYNNonDefault        	= null;
		private DateTime?      	_stateFireApprovalDateNonDefault	= null;
		private string         	_ageRangeNonDefault      	= null;
		private DateTime?      	_healthApprovalDateNonDefault	= null;
		private DateTime?      	_curSurvNonDefault       	= null;
		private string         	_hospitalBasedYNNonDefault	= null;
		private DateTime?      	_applicationDateNonDefault	= null;
		private string         	_usDeaRegNumNonDefault   	= null;
		private DateTime?      	_usDeaRegNumExpDateNonDefault	= null;
		private string         	_laCdsNumNonDefault      	= null;
		private DateTime?      	_laCdsNumExpDateNonDefault	= null;
		private string         	_cliaIdNumNonDefault     	= null;
		private DateTime?      	_cliaExpDateNonDefault   	= null;
		private string         	_noOfAirAmbulancesNonDefault	= null;
		private string         	_noOfGroundAmbulancesNonDefault	= null;
		private string         	_noOfSprintVehiclesNonDefault	= null;
		private string         	_noOfAmbulatoryVehiclesNonDefault	= null;
		private string         	_totalDailyCapacityAmbulatoryVehicleNonDefault	= null;
		private string         	_noOfHandicappedVehiclesNonDefault	= null;
		private string         	_totalDailyCapacityHandicappedVehicleNonDefault	= null;
		private string         	_isolationUnitYNNonDefault	= null;
		private string         	_statusCodeNonDefault    	= null;
		private DateTime?      	_statusDateNonDefault    	= null;
		private string         	_noOfParishesServedNonDefault	= null;
		private DateTime?      	_licensureSurveyDateNonDefault	= null;
		private string         	_waiversNonDefault       	= null;
		private string         	_userLastMaintNonDefault 	= null;
		private DateTime?      	_dateLastMaintNonDefault 	= null;
		private string         	_timeLastMaintNonDefault 	= null;
		private string         	_offsiteCampusYNNonDefault	= null;
		private string         	_deemedStatusNonDefault  	= null;
		private string         	_chapAccreditionYNNonDefault	= null;
		private string         	_fiscalIntermediaryNumNonDefault	= null;
		private string         	_fiscalIntermediaryDescNonDefault	= null;
		private string         	_noTreatmentsPerWeekNonDefault	= null;
		private string         	_noOfStationsNonDefault  	= null;
		private string         	_noOf3hrShiftsWeekNonDefault	= null;
		private string         	_averageNumPatientsShiftNonDefault	= null;
		private string         	_vendorNumNonDefault     	= null;
		private string         	_waiverCodeNonDefault    	= null;
		private string         	_waiverCode2NonDefault   	= null;
		private string         	_waiverCode3NonDefault   	= null;
		private string         	_waiverCode4NonDefault   	= null;
		private string         	_waiverCode5NonDefault   	= null;
		private string         	_waiverCode6NonDefault   	= null;
		private string         	_waiverCode7NonDefault   	= null;
		private DateTime?      	_accreditationExpirationDateNonDefault	= null;
		private string         	_facilityWithinFacilityNonDefault	= null;
		private string         	_facilityTypeCodeNonDefault	= null;
		private string         	_transplantYNNonDefault  	= null;
		private string         	_enrolledRhcOffsiteYNNonDefault	= null;
		private string         	_facilityWithinFacilityYNNonDefault	= null;
		private string         	_certifiedBedOverrideYNNonDefault	= null;
		private string         	_forYearEndingDateNonDefault	= null;
		private string         	_servicesOfferedNonDefault	= null;
		private string         	_halfwayHouseNonDefault  	= null;
		private string         	_inPatientNonDefault     	= null;
		private string         	_crisisEmergencyNonDefault	= null;
		private string         	_outpatientTreatmentNonDefault	= null;
		private string         	_methadoneTreatmentNonDefault	= null;
		private string         	_preventionEducationNonDefault	= null;
		private string         	_residentialTreatmentNonDefault	= null;
		private string         	_socialSettingDetoxificationNonDefault	= null;
		private string         	_adultHealthCareNonDefault	= null;
		private string         	_cnatTrainingCodeNonDefault	= null;
		private DateTime?      	_cnatTrainingSuspendDateNonDefault	= null;
		private string         	_assistDirOfNursingWaiverMonthNonDefault	= null;
		private string         	_day7RnWaiverMonthNonDefault	= null;
		private string         	_currentSurveyMonthNonDefault	= null;
		private string         	_medicareInterPrefCodeNonDefault	= null;
		private string         	_programCodeNonDefault   	= null;
		private string         	_levelDescriptionNonDefault	= null;
		private DateTime?      	_automaticCancellationDateNonDefault	= null;
		private int?           	_numOfPatientsFollowedAtHomeNonDefault	= null;
		private DateTime?      	_automobileInsurancePrepaymentDueDateNonDefault	= null;
		private DateTime?      	_generalLiabilityPrepaymentDueDateNonDefault	= null;
		private string         	_overrideCapacityNonDefault	= null;
		private string         	_rnCoordinatorNonDefault 	= null;
		private string         	_directorNameNonDefault  	= null;
		private DateTime?      	_year1ReviewDateDueNonDefault	= null;
		private string         	_totalNumDialysisPatientsNonDefault	= null;
		private string         	_hemodialysisNumPatientsNonDefault	= null;
		private string         	_numOfPeritonealDialysisPatientsNonDefault	= null;
		private string         	_hemodialysisNumOfStationsNonDefault	= null;
		private string         	_hemodialysisTrainingNumOfStationNonDefault	= null;
		private string         	_totalNumStationsNonDefault	= null;
		private string         	_reuseYNNonDefault       	= null;
		private string         	_manualYNNonDefault      	= null;
		private string         	_semiautomatedYNNonDefault	= null;
		private string         	_automatedYNNonDefault   	= null;
		private string         	_formainGermicideNonDefault	= null;
		private string         	_heatGermicideNonDefault 	= null;
		private string         	_gluteraldetydeGermicideNonDefault	= null;
		private string         	_peraceticAcidMixtureGermNonDefault	= null;
		private string         	_otherGermicideNonDefault	= null;
		private string         	_typeGermicideDescriptionNonDefault	= null;
		private string         	_hemodialysisServiceNonDefault	= null;
		private string         	_peritonealDialysisServiceNonDefault	= null;
		private string         	_transplanationServiceNonDefault	= null;
		private string         	_homeTrainingServiceNonDefault	= null;
		private string         	_emergencyPrepReportRequiredNonDefault	= null;
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
		private string         	_relatedProviderLicensureNumNonDefault	= null;
		private string         	_accreditedBodyNonDefault	= null;
		private DateTime?      	_licensureExpirationDateNonDefault	= null;
		private string         	_enrolledInMedicaidYNNonDefault	= null;
		private DateTime?      	_submissionDateNonDefault	= null;
		private int?           	_totalLicBedsNonDefault  	= null;
		private string         	_statusCommentNonDefault 	= null;
		private int?           	_unitNonDefault          	= null;
		private string         	_typeTreatmentNonDefault 	= null;
		private string         	_changeAddressLocTypeNonDefault	= null;
		private int?           	_changeAddressLocIDNonDefault	= null;
		private string         	_keyPersonnelChangeNonDefault	= null;
		private DateTime?      	_proposedEffectiveDateNonDefault	= null;
		private string         	_applicationActionNonDefault	= null;
		private int?           	_ageRangeFromNonDefault  	= null;
		private int?           	_ageRangeTONonDefault    	= null;
		private int?           	_snf18bedsNonDefault     	= null;
		private int?           	_snf1819bedsNonDefault   	= null;
		private int?           	_snf19bedsNonDefault     	= null;
		private int?           	_psychiatricBedsNonDefault	= null;
		private int?           	_snfBedsNonDefault       	= null;
		private int?           	_swingBedsNonDefault     	= null;
		private int?           	_rehabilitationBedsNonDefault	= null;
		private int?           	_bedsCertifiedNonDefault 	= null;
		private int?           	_numberOfBedsNonDefault  	= null;
		private int?           	_otherBedsNonDefault     	= null;
		private int?           	_unitsNumTotalNonDefault 	= null;
		private int?           	_totalLicBedsTotalNonDefault	= null;
		private int?           	_psychiatricBedsTotalNonDefault	= null;
		private int?           	_rehabilitationBedsTotalNonDefault	= null;
		private int?           	_snfBedsTotalNonDefault  	= null;
		private int?           	_unitsNumOffsiteTotalNonDefault	= null;
		private int?           	_totalLicBedsOffsiteTotalNonDefault	= null;
		private int?           	_psychiatricBedsOffsiteTotalNonDefault	= null;
		private int?           	_rehabBedsOffsiteTotalNonDefault	= null;
		private int?           	_snfBedsOffsiteTotalNonDefault	= null;
		private int?           	_otherBedsOffsiteTotalNonDefault	= null;
		private int?           	_fcertBedsNonDefault     	= null;
		private int?           	_otherBedsTotalNonDefault	= null;
		private DateTime?      	_currentLicIssueDateNonDefault	= null;
		private DateTime?      	_originalLicensureDateNonDefault	= null;
		private string         	_licEffectiveDateOverideNonDefault	= null;
		private string         	_licExpireDateOverideNonDefault	= null;
		private int?           	_capacityNonDefault      	= null;
		private int?           	_capacityProvTotalNonDefault	= null;
		private int?           	_numActivePatientsNonDefault	= null;
		private string         	_operationPrior2005NonDefault	= null;
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
		private DateTime?      	_year2ReviewDateDueNonDefault	= null;
		private string         	_levelCodeNonDefault     	= null;
		private DateTime?      	_originalEnrollmentDateNonDefault	= null;

		private BO_Addresses _bO_AddressesApplicationID = null;
		private BO_Affiliations _bO_AffiliationsApplicationID = null;
		private BO_ApplicationSupports _bO_ApplicationSupportsApplicationID = null;
		private BO_ApplicationItems _bO_ApplicationItemsApplicationID = null;
		private BO_Billings _bO_BillingsApplicationID = null;
		private BO_Capacities _bO_CapacitiesApplicationID = null;
		private BO_LetterOfIntents _bO_LetterOfIntentsApplicationID = null;
		private BO_Licenses _bO_LicensesApplicationID = null;
		private BO_Messages _bO_MessagesApplicationID = null;
		private BO_Ownerships _bO_OwnershipsApplicationID = null;
		private BO_ProviderPeople _bO_ProviderPeopleApplicationID = null;
		private BO_Services _bO_ServicesApplicationID = null;
		private BO_SpecialtyUnits _bO_SpecialtyUnitsApplicationID = null;
		private BO_Staffings _bO_StaffingsApplicationID = null;
		private BO_StatusHistories _bO_StatusHistoriesApplicationID = null;
		private BO_LettersQueues _bO_LettersQueuesApplicationID = null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ApplicationBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? ApplicationID
		{
			get 
			{ 
                return _applicationIDNonDefault;
			}
			set 
			{
            
                _applicationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// The foreign key connected with another persistent object.
		/// </summary>
		public string BusinessProcessID
		{
			get 
			{ 
                if(_businessProcessIDNonDefault==null)return _businessProcessIDNonDefault;
				else return _businessProcessIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 3)
					throw new ArgumentException("BusinessProcessID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _businessProcessIDNonDefault =null;//null value 
                }
                else
                {		           
		            _businessProcessIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_ID" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string StateID
		{
			get 
			{ 
                if(_stateIDNonDefault==null)return _stateIDNonDefault;
				else return _stateIDNonDefault.Replace("''", "'"); 
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
		            _stateIDNonDefault = value.Replace("'", "''"); 
                }
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
				else return _programIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("ProgramID length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _programIDNonDefault =null;//null value 
                }
                else
                {		           
		            _programIDNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "DATE_STARTED" field.  Mandatory.
		/// </summary>
		public DateTime? DateStarted
		{
			get 
			{ 
                return _dateStartedNonDefault;
			}
			set 
			{
            
                _dateStartedNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "DATE_COMPLETED" field.  
		/// </summary>
		public DateTime? DateCompleted
		{
			get 
			{ 
                return _dateCompletedNonDefault;
			}
			set 
			{
            
                _dateCompletedNonDefault = value; 
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
		/// This property is mapped to the "APPLICATION_STATUS" field. Length must be between 0 and 1 characters. Mandatory.
		/// </summary>
		public string ApplicationStatus
		{
			get 
			{ 
                if(_applicationStatusNonDefault==null)return _applicationStatusNonDefault;
				else return _applicationStatusNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 1)
					throw new ArgumentException("ApplicationStatus length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _applicationStatusNonDefault =null;//null value 
                }
                else
                {		           
		            _applicationStatusNonDefault = value.Replace("'", "''"); 
                }
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
				else return _facilityNameNonDefault.Replace("''", "'"); 
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
		            _facilityNameNonDefault = value.Replace("'", "''"); 
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
				else return _legalNameNonDefault.Replace("''", "'"); 
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
		            _legalNameNonDefault = value.Replace("'", "''"); 
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
				else return _stateCodeNonDefault.Replace("''", "'"); 
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
		            _stateCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PARISH_CODE" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string ParishCode
		{
			get 
			{ 
                if(_parishCodeNonDefault==null)return _parishCodeNonDefault;
				else return _parishCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("ParishCode length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _parishCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _parishCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "REGION_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string RegionCode
		{
			get 
			{ 
                if(_regionCodeNonDefault==null)return _regionCodeNonDefault;
				else return _regionCodeNonDefault.Replace("''", "'"); 
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
		            _regionCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FEDERAL_ID" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string FederalID
		{
			get 
			{ 
                if(_federalIDNonDefault==null)return _federalIDNonDefault;
				else return _federalIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("FederalID length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _federalIDNonDefault =null;//null value 
                }
                else
                {		           
		            _federalIDNonDefault = value.Replace("'", "''"); 
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
				else return _licensureNumNonDefault.Replace("''", "'"); 
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
		            _licensureNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SCHOOL_ID" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string SchoolID
		{
			get 
			{ 
                if(_schoolIDNonDefault==null)return _schoolIDNonDefault;
				else return _schoolIDNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("SchoolID length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _schoolIDNonDefault =null;//null value 
                }
                else
                {		           
		            _schoolIDNonDefault = value.Replace("'", "''"); 
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
				else return _emsParishCodeNonDefault.Replace("''", "'"); 
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
		            _emsParishCodeNonDefault = value.Replace("'", "''"); 
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
				else return _regionalOfficeNonDefault.Replace("''", "'"); 
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
		            _regionalOfficeNonDefault = value.Replace("'", "''"); 
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
				else return _zoneNumCodeNonDefault.Replace("''", "'"); 
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
		            _zoneNumCodeNonDefault = value.Replace("'", "''"); 
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
				else return _telephoneNumberNonDefault.Replace("''", "'"); 
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
		            _telephoneNumberNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CONTACT_NAME" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string ContactName
		{
			get 
			{ 
                if(_contactNameNonDefault==null)return _contactNameNonDefault;
				else return _contactNameNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("ContactName length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _contactNameNonDefault =null;//null value 
                }
                else
                {		           
		            _contactNameNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMERGENCY_PHONE_NUMBER" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string EmergencyPhoneNumber
		{
			get 
			{ 
                if(_emergencyPhoneNumberNonDefault==null)return _emergencyPhoneNumberNonDefault;
				else return _emergencyPhoneNumberNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("EmergencyPhoneNumber length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _emergencyPhoneNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _emergencyPhoneNumberNonDefault = value.Replace("'", "''"); 
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
				else return _faxPhoneNumberNonDefault.Replace("''", "'"); 
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
		            _faxPhoneNumberNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "STATE_ID_MDS" field. Length must be between 0 and 9 characters. 
		/// </summary>
		public string StateIdMds
		{
			get 
			{ 
                if(_stateIdMdsNonDefault==null)return _stateIdMdsNonDefault;
				else return _stateIdMdsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 9)
					throw new ArgumentException("StateIdMds length must be between 0 and 9 characters.");

				
                if(value ==null)
                {
                    _stateIdMdsNonDefault =null;//null value 
                }
                else
                {		           
		            _stateIdMdsNonDefault = value.Replace("'", "''"); 
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
				else return _stateLicNumNonDefault.Replace("''", "'"); 
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
		            _stateLicNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMAIL_ADDRESS" field. Length must be between 0 and 100 characters. 
		/// </summary>
		public string EmailAddress
		{
			get 
			{ 
                if(_emailAddressNonDefault==null)return _emailAddressNonDefault;
				else return _emailAddressNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 100)
					throw new ArgumentException("EmailAddress length must be between 0 and 100 characters.");

				
                if(value ==null)
                {
                    _emailAddressNonDefault =null;//null value 
                }
                else
                {		           
		            _emailAddressNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICAID_VENDOR_NUMBER" field. Length must be between 0 and 8 characters. 
		/// </summary>
		public string MedicaidVendorNumber
		{
			get 
			{ 
                if(_medicaidVendorNumberNonDefault==null)return _medicaidVendorNumberNonDefault;
				else return _medicaidVendorNumberNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 8)
					throw new ArgumentException("MedicaidVendorNumber length must be between 0 and 8 characters.");

				
                if(value ==null)
                {
                    _medicaidVendorNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _medicaidVendorNumberNonDefault = value.Replace("'", "''"); 
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
				else return _fieldOfficeCodeNonDefault.Replace("''", "'"); 
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
		            _fieldOfficeCodeNonDefault = value.Replace("'", "''"); 
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
				else return _hoursMinutesNonDefault.Replace("''", "'"); 
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
		            _hoursMinutesNonDefault = value.Replace("'", "''"); 
                }
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
				else return _amPMNonDefault.Replace("''", "'"); 
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
		            _amPMNonDefault = value.Replace("'", "''"); 
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
				else return _hoursMinutes1NonDefault.Replace("''", "'"); 
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
		            _hoursMinutes1NonDefault = value.Replace("'", "''"); 
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
				else return _amPm1NonDefault.Replace("''", "'"); 
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
		            _amPm1NonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationMonNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationMonNonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationTueNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationTueNonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationWedNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationWedNonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationThuNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationThuNonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationFriNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationFriNonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationSatNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationSatNonDefault = value.Replace("'", "''"); 
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
				else return _dayOfOperationSunNonDefault.Replace("''", "'"); 
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
		            _dayOfOperationSunNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_LICENSE_CODE" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string TypeLicenseCode
		{
			get 
			{ 
                if(_typeLicenseCodeNonDefault==null)return _typeLicenseCodeNonDefault;
				else return _typeLicenseCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("TypeLicenseCode length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _typeLicenseCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _typeLicenseCodeNonDefault = value.Replace("'", "''"); 
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
				else return _typeOfLicenseNonDefault.Replace("''", "'"); 
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
		            _typeOfLicenseNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility
		{
			get 
			{ 
                if(_typeFacilityNonDefault==null)return _typeFacilityNonDefault;
				else return _typeFacilityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacilityNonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacilityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_1" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility1
		{
			get 
			{ 
                if(_typeFacility1NonDefault==null)return _typeFacility1NonDefault;
				else return _typeFacility1NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility1 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility1NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility1NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_2" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility2
		{
			get 
			{ 
                if(_typeFacility2NonDefault==null)return _typeFacility2NonDefault;
				else return _typeFacility2NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility2 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility2NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility2NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_3" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility3
		{
			get 
			{ 
                if(_typeFacility3NonDefault==null)return _typeFacility3NonDefault;
				else return _typeFacility3NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility3 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility3NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility3NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_4" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility4
		{
			get 
			{ 
                if(_typeFacility4NonDefault==null)return _typeFacility4NonDefault;
				else return _typeFacility4NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility4 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility4NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility4NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_5" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility5
		{
			get 
			{ 
                if(_typeFacility5NonDefault==null)return _typeFacility5NonDefault;
				else return _typeFacility5NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility5 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility5NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility5NonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_FACILITY_6" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string TypeFacility6
		{
			get 
			{ 
                if(_typeFacility6NonDefault==null)return _typeFacility6NonDefault;
				else return _typeFacility6NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("TypeFacility6 length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _typeFacility6NonDefault =null;//null value 
                }
                else
                {		           
		            _typeFacility6NonDefault = value.Replace("'", "''"); 
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
				else return _licensedSnfFacilityNonDefault.Replace("''", "'"); 
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
		            _licensedSnfFacilityNonDefault = value.Replace("'", "''"); 
                }
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
				else return _typeOfClientsNonDefault.Replace("''", "'"); 
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
		            _typeOfClientsNonDefault = value.Replace("'", "''"); 
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
				else return _jcahYNNonDefault.Replace("''", "'"); 
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
		            _jcahYNNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "AGE_RANGE" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string AgeRange
		{
			get 
			{ 
                if(_ageRangeNonDefault==null)return _ageRangeNonDefault;
				else return _ageRangeNonDefault.Replace("''", "'"); 
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
		            _ageRangeNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "HOSPITAL_BASED_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string HospitalBasedYN
		{
			get 
			{ 
                if(_hospitalBasedYNNonDefault==null)return _hospitalBasedYNNonDefault;
				else return _hospitalBasedYNNonDefault.Replace("''", "'"); 
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
		            _hospitalBasedYNNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "US_DEA_REG_NUM" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string UsDeaRegNum
		{
			get 
			{ 
                if(_usDeaRegNumNonDefault==null)return _usDeaRegNumNonDefault;
				else return _usDeaRegNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("UsDeaRegNum length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _usDeaRegNumNonDefault =null;//null value 
                }
                else
                {		           
		            _usDeaRegNumNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "LA_CDS_NUM" field. Length must be between 0 and 11 characters. 
		/// </summary>
		public string LaCdsNum
		{
			get 
			{ 
                if(_laCdsNumNonDefault==null)return _laCdsNumNonDefault;
				else return _laCdsNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 11)
					throw new ArgumentException("LaCdsNum length must be between 0 and 11 characters.");

				
                if(value ==null)
                {
                    _laCdsNumNonDefault =null;//null value 
                }
                else
                {		           
		            _laCdsNumNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "CLIA_ID_NUM" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string CliaIdNum
		{
			get 
			{ 
                if(_cliaIdNumNonDefault==null)return _cliaIdNumNonDefault;
				else return _cliaIdNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("CliaIdNum length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _cliaIdNumNonDefault =null;//null value 
                }
                else
                {		           
		            _cliaIdNumNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "NO_OF_AIR_AMBULANCES" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string NoOfAirAmbulances
		{
			get 
			{ 
                if(_noOfAirAmbulancesNonDefault==null)return _noOfAirAmbulancesNonDefault;
				else return _noOfAirAmbulancesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("NoOfAirAmbulances length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _noOfAirAmbulancesNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfAirAmbulancesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_GROUND_AMBULANCES" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string NoOfGroundAmbulances
		{
			get 
			{ 
                if(_noOfGroundAmbulancesNonDefault==null)return _noOfGroundAmbulancesNonDefault;
				else return _noOfGroundAmbulancesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("NoOfGroundAmbulances length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _noOfGroundAmbulancesNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfGroundAmbulancesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_SPRINT_VEHICLES" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string NoOfSprintVehicles
		{
			get 
			{ 
                if(_noOfSprintVehiclesNonDefault==null)return _noOfSprintVehiclesNonDefault;
				else return _noOfSprintVehiclesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("NoOfSprintVehicles length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _noOfSprintVehiclesNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfSprintVehiclesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_AMBULATORY_VEHICLES" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string NoOfAmbulatoryVehicles
		{
			get 
			{ 
                if(_noOfAmbulatoryVehiclesNonDefault==null)return _noOfAmbulatoryVehiclesNonDefault;
				else return _noOfAmbulatoryVehiclesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("NoOfAmbulatoryVehicles length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _noOfAmbulatoryVehiclesNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfAmbulatoryVehiclesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_DAILY_CAPACITY_AMBULATORY_VEHICLE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string TotalDailyCapacityAmbulatoryVehicle
		{
			get 
			{ 
                if(_totalDailyCapacityAmbulatoryVehicleNonDefault==null)return _totalDailyCapacityAmbulatoryVehicleNonDefault;
				else return _totalDailyCapacityAmbulatoryVehicleNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("TotalDailyCapacityAmbulatoryVehicle length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _totalDailyCapacityAmbulatoryVehicleNonDefault =null;//null value 
                }
                else
                {		           
		            _totalDailyCapacityAmbulatoryVehicleNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_HANDICAPPED_VEHICLES" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string NoOfHandicappedVehicles
		{
			get 
			{ 
                if(_noOfHandicappedVehiclesNonDefault==null)return _noOfHandicappedVehiclesNonDefault;
				else return _noOfHandicappedVehiclesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("NoOfHandicappedVehicles length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _noOfHandicappedVehiclesNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfHandicappedVehiclesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_DAILY_CAPACITY_HANDICAPPED_VEHICLE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string TotalDailyCapacityHandicappedVehicle
		{
			get 
			{ 
                if(_totalDailyCapacityHandicappedVehicleNonDefault==null)return _totalDailyCapacityHandicappedVehicleNonDefault;
				else return _totalDailyCapacityHandicappedVehicleNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("TotalDailyCapacityHandicappedVehicle length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _totalDailyCapacityHandicappedVehicleNonDefault =null;//null value 
                }
                else
                {		           
		            _totalDailyCapacityHandicappedVehicleNonDefault = value.Replace("'", "''"); 
                }
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
				else return _isolationUnitYNNonDefault.Replace("''", "'"); 
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
		            _isolationUnitYNNonDefault = value.Replace("'", "''"); 
                }
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
				else return _statusCodeNonDefault.Replace("''", "'"); 
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
		            _statusCodeNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "NO_OF_PARISHES_SERVED" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string NoOfParishesServed
		{
			get 
			{ 
                if(_noOfParishesServedNonDefault==null)return _noOfParishesServedNonDefault;
				else return _noOfParishesServedNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("NoOfParishesServed length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _noOfParishesServedNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfParishesServedNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "WAIVERS" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string Waivers
		{
			get 
			{ 
                if(_waiversNonDefault==null)return _waiversNonDefault;
				else return _waiversNonDefault.Replace("''", "'"); 
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
		            _waiversNonDefault = value.Replace("'", "''"); 
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
				else return _userLastMaintNonDefault.Replace("''", "'"); 
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
		            _userLastMaintNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "TIME_LAST_MAINT" field. Length must be between 0 and 9 characters. 
		/// </summary>
		public string TimeLastMaint
		{
			get 
			{ 
                if(_timeLastMaintNonDefault==null)return _timeLastMaintNonDefault;
				else return _timeLastMaintNonDefault.Replace("''", "'"); 
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
		            _timeLastMaintNonDefault = value.Replace("'", "''"); 
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
				else return _offsiteCampusYNNonDefault.Replace("''", "'"); 
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
		            _offsiteCampusYNNonDefault = value.Replace("'", "''"); 
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
				else return _deemedStatusNonDefault.Replace("''", "'"); 
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
		            _deemedStatusNonDefault = value.Replace("'", "''"); 
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
				else return _chapAccreditionYNNonDefault.Replace("''", "'"); 
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
		            _chapAccreditionYNNonDefault = value.Replace("'", "''"); 
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
				else return _fiscalIntermediaryNumNonDefault.Replace("''", "'"); 
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
		            _fiscalIntermediaryNumNonDefault = value.Replace("'", "''"); 
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
				else return _fiscalIntermediaryDescNonDefault.Replace("''", "'"); 
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
		            _fiscalIntermediaryDescNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_TREATMENTS_PER_WEEK" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string NoTreatmentsPerWeek
		{
			get 
			{ 
                if(_noTreatmentsPerWeekNonDefault==null)return _noTreatmentsPerWeekNonDefault;
				else return _noTreatmentsPerWeekNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("NoTreatmentsPerWeek length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _noTreatmentsPerWeekNonDefault =null;//null value 
                }
                else
                {		           
		            _noTreatmentsPerWeekNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_STATIONS" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string NoOfStations
		{
			get 
			{ 
                if(_noOfStationsNonDefault==null)return _noOfStationsNonDefault;
				else return _noOfStationsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("NoOfStations length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _noOfStationsNonDefault =null;//null value 
                }
                else
                {		           
		            _noOfStationsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NO_OF_3HR_SHIFTS_WEEK" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string NoOf3hrShiftsWeek
		{
			get 
			{ 
                if(_noOf3hrShiftsWeekNonDefault==null)return _noOf3hrShiftsWeekNonDefault;
				else return _noOf3hrShiftsWeekNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("NoOf3hrShiftsWeek length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _noOf3hrShiftsWeekNonDefault =null;//null value 
                }
                else
                {		           
		            _noOf3hrShiftsWeekNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AVERAGE_NUM_PATIENTS_SHIFT" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string AverageNumPatientsShift
		{
			get 
			{ 
                if(_averageNumPatientsShiftNonDefault==null)return _averageNumPatientsShiftNonDefault;
				else return _averageNumPatientsShiftNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("AverageNumPatientsShift length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _averageNumPatientsShiftNonDefault =null;//null value 
                }
                else
                {		           
		            _averageNumPatientsShiftNonDefault = value.Replace("'", "''"); 
                }
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
				else return _vendorNumNonDefault.Replace("''", "'"); 
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
		            _vendorNumNonDefault = value.Replace("'", "''"); 
                }
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
				else return _waiverCodeNonDefault.Replace("''", "'"); 
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
		            _waiverCodeNonDefault = value.Replace("'", "''"); 
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
				else return _waiverCode2NonDefault.Replace("''", "'"); 
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
		            _waiverCode2NonDefault = value.Replace("'", "''"); 
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
				else return _waiverCode3NonDefault.Replace("''", "'"); 
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
		            _waiverCode3NonDefault = value.Replace("'", "''"); 
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
				else return _waiverCode4NonDefault.Replace("''", "'"); 
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
		            _waiverCode4NonDefault = value.Replace("'", "''"); 
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
				else return _waiverCode5NonDefault.Replace("''", "'"); 
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
		            _waiverCode5NonDefault = value.Replace("'", "''"); 
                }
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
				else return _waiverCode6NonDefault.Replace("''", "'"); 
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
		            _waiverCode6NonDefault = value.Replace("'", "''"); 
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
				else return _waiverCode7NonDefault.Replace("''", "'"); 
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
		            _waiverCode7NonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "FACILITY_WITHIN_FACILITY" field. Length must be between 0 and 50 characters. 
		/// </summary>
		public string FacilityWithinFacility
		{
			get 
			{ 
                if(_facilityWithinFacilityNonDefault==null)return _facilityWithinFacilityNonDefault;
				else return _facilityWithinFacilityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 50)
					throw new ArgumentException("FacilityWithinFacility length must be between 0 and 50 characters.");

				
                if(value ==null)
                {
                    _facilityWithinFacilityNonDefault =null;//null value 
                }
                else
                {		           
		            _facilityWithinFacilityNonDefault = value.Replace("'", "''"); 
                }
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
				else return _facilityTypeCodeNonDefault.Replace("''", "'"); 
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
		            _facilityTypeCodeNonDefault = value.Replace("'", "''"); 
                }
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
				else return _transplantYNNonDefault.Replace("''", "'"); 
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
		            _transplantYNNonDefault = value.Replace("'", "''"); 
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
				else return _enrolledRhcOffsiteYNNonDefault.Replace("''", "'"); 
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
		            _enrolledRhcOffsiteYNNonDefault = value.Replace("'", "''"); 
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
				else return _facilityWithinFacilityYNNonDefault.Replace("''", "'"); 
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
		            _facilityWithinFacilityYNNonDefault = value.Replace("'", "''"); 
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
				else return _certifiedBedOverrideYNNonDefault.Replace("''", "'"); 
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
		            _certifiedBedOverrideYNNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FOR_YEAR_ENDING_DATE" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string ForYearEndingDate
		{
			get 
			{ 
                if(_forYearEndingDateNonDefault==null)return _forYearEndingDateNonDefault;
				else return _forYearEndingDateNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("ForYearEndingDate length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _forYearEndingDateNonDefault =null;//null value 
                }
                else
                {		           
		            _forYearEndingDateNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SERVICES_OFFERED" field. Length must be between 0 and 40 characters. 
		/// </summary>
		public string ServicesOffered
		{
			get 
			{ 
                if(_servicesOfferedNonDefault==null)return _servicesOfferedNonDefault;
				else return _servicesOfferedNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 40)
					throw new ArgumentException("ServicesOffered length must be between 0 and 40 characters.");

				
                if(value ==null)
                {
                    _servicesOfferedNonDefault =null;//null value 
                }
                else
                {		           
		            _servicesOfferedNonDefault = value.Replace("'", "''"); 
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
				else return _halfwayHouseNonDefault.Replace("''", "'"); 
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
		            _halfwayHouseNonDefault = value.Replace("'", "''"); 
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
				else return _inPatientNonDefault.Replace("''", "'"); 
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
		            _inPatientNonDefault = value.Replace("'", "''"); 
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
				else return _crisisEmergencyNonDefault.Replace("''", "'"); 
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
		            _crisisEmergencyNonDefault = value.Replace("'", "''"); 
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
				else return _outpatientTreatmentNonDefault.Replace("''", "'"); 
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
		            _outpatientTreatmentNonDefault = value.Replace("'", "''"); 
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
				else return _methadoneTreatmentNonDefault.Replace("''", "'"); 
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
		            _methadoneTreatmentNonDefault = value.Replace("'", "''"); 
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
				else return _preventionEducationNonDefault.Replace("''", "'"); 
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
		            _preventionEducationNonDefault = value.Replace("'", "''"); 
                }
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
				else return _residentialTreatmentNonDefault.Replace("''", "'"); 
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
		            _residentialTreatmentNonDefault = value.Replace("'", "''"); 
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
				else return _socialSettingDetoxificationNonDefault.Replace("''", "'"); 
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
		            _socialSettingDetoxificationNonDefault = value.Replace("'", "''"); 
                }
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
				else return _adultHealthCareNonDefault.Replace("''", "'"); 
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
		            _adultHealthCareNonDefault = value.Replace("'", "''"); 
                }
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
				else return _cnatTrainingCodeNonDefault.Replace("''", "'"); 
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
		            _cnatTrainingCodeNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "ASSIST_DIR_OF_NURSING_WAIVER_MONTH" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string AssistDirOfNursingWaiverMonth
		{
			get 
			{ 
                if(_assistDirOfNursingWaiverMonthNonDefault==null)return _assistDirOfNursingWaiverMonthNonDefault;
				else return _assistDirOfNursingWaiverMonthNonDefault.Replace("''", "'"); 
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
		            _assistDirOfNursingWaiverMonthNonDefault = value.Replace("'", "''"); 
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
				else return _day7RnWaiverMonthNonDefault.Replace("''", "'"); 
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
		            _day7RnWaiverMonthNonDefault = value.Replace("'", "''"); 
                }
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
				else return _currentSurveyMonthNonDefault.Replace("''", "'"); 
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
		            _currentSurveyMonthNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MEDICARE_INTER_PREF_CODE" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string MedicareInterPrefCode
		{
			get 
			{ 
                if(_medicareInterPrefCodeNonDefault==null)return _medicareInterPrefCodeNonDefault;
				else return _medicareInterPrefCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("MedicareInterPrefCode length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _medicareInterPrefCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _medicareInterPrefCodeNonDefault = value.Replace("'", "''"); 
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
				else return _programCodeNonDefault.Replace("''", "'"); 
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
		            _programCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LEVEL_DESCRIPTION" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string LevelDescription
		{
			get 
			{ 
                if(_levelDescriptionNonDefault==null)return _levelDescriptionNonDefault;
				else return _levelDescriptionNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("LevelDescription length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _levelDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _levelDescriptionNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "OVERRIDE_CAPACITY" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string OverrideCapacity
		{
			get 
			{ 
                if(_overrideCapacityNonDefault==null)return _overrideCapacityNonDefault;
				else return _overrideCapacityNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("OverrideCapacity length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _overrideCapacityNonDefault =null;//null value 
                }
                else
                {		           
		            _overrideCapacityNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "RN_COORDINATOR" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string RnCoordinator
		{
			get 
			{ 
                if(_rnCoordinatorNonDefault==null)return _rnCoordinatorNonDefault;
				else return _rnCoordinatorNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("RnCoordinator length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _rnCoordinatorNonDefault =null;//null value 
                }
                else
                {		           
		            _rnCoordinatorNonDefault = value.Replace("'", "''"); 
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
				else return _directorNameNonDefault.Replace("''", "'"); 
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
		            _directorNameNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "TOTAL_NUM_DIALYSIS_PATIENTS" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string TotalNumDialysisPatients
		{
			get 
			{ 
                if(_totalNumDialysisPatientsNonDefault==null)return _totalNumDialysisPatientsNonDefault;
				else return _totalNumDialysisPatientsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("TotalNumDialysisPatients length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _totalNumDialysisPatientsNonDefault =null;//null value 
                }
                else
                {		           
		            _totalNumDialysisPatientsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_NUM_PATIENTS" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string HemodialysisNumPatients
		{
			get 
			{ 
                if(_hemodialysisNumPatientsNonDefault==null)return _hemodialysisNumPatientsNonDefault;
				else return _hemodialysisNumPatientsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("HemodialysisNumPatients length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _hemodialysisNumPatientsNonDefault =null;//null value 
                }
                else
                {		           
		            _hemodialysisNumPatientsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "NUM_OF_PERITONEAL_DIALYSIS_PATIENTS" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string NumOfPeritonealDialysisPatients
		{
			get 
			{ 
                if(_numOfPeritonealDialysisPatientsNonDefault==null)return _numOfPeritonealDialysisPatientsNonDefault;
				else return _numOfPeritonealDialysisPatientsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("NumOfPeritonealDialysisPatients length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _numOfPeritonealDialysisPatientsNonDefault =null;//null value 
                }
                else
                {		           
		            _numOfPeritonealDialysisPatientsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_NUM_OF_STATIONS" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string HemodialysisNumOfStations
		{
			get 
			{ 
                if(_hemodialysisNumOfStationsNonDefault==null)return _hemodialysisNumOfStationsNonDefault;
				else return _hemodialysisNumOfStationsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("HemodialysisNumOfStations length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _hemodialysisNumOfStationsNonDefault =null;//null value 
                }
                else
                {		           
		            _hemodialysisNumOfStationsNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "HEMODIALYSIS_TRAINING_NUM_OF_STATION" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string HemodialysisTrainingNumOfStation
		{
			get 
			{ 
                if(_hemodialysisTrainingNumOfStationNonDefault==null)return _hemodialysisTrainingNumOfStationNonDefault;
				else return _hemodialysisTrainingNumOfStationNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("HemodialysisTrainingNumOfStation length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _hemodialysisTrainingNumOfStationNonDefault =null;//null value 
                }
                else
                {		           
		            _hemodialysisTrainingNumOfStationNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_NUM_STATIONS" field. Length must be between 0 and 6 characters. 
		/// </summary>
		public string TotalNumStations
		{
			get 
			{ 
                if(_totalNumStationsNonDefault==null)return _totalNumStationsNonDefault;
				else return _totalNumStationsNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 6)
					throw new ArgumentException("TotalNumStations length must be between 0 and 6 characters.");

				
                if(value ==null)
                {
                    _totalNumStationsNonDefault =null;//null value 
                }
                else
                {		           
		            _totalNumStationsNonDefault = value.Replace("'", "''"); 
                }
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
				else return _reuseYNNonDefault.Replace("''", "'"); 
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
		            _reuseYNNonDefault = value.Replace("'", "''"); 
                }
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
				else return _manualYNNonDefault.Replace("''", "'"); 
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
		            _manualYNNonDefault = value.Replace("'", "''"); 
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
				else return _semiautomatedYNNonDefault.Replace("''", "'"); 
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
		            _semiautomatedYNNonDefault = value.Replace("'", "''"); 
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
				else return _automatedYNNonDefault.Replace("''", "'"); 
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
		            _automatedYNNonDefault = value.Replace("'", "''"); 
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
				else return _formainGermicideNonDefault.Replace("''", "'"); 
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
		            _formainGermicideNonDefault = value.Replace("'", "''"); 
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
				else return _heatGermicideNonDefault.Replace("''", "'"); 
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
		            _heatGermicideNonDefault = value.Replace("'", "''"); 
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
				else return _gluteraldetydeGermicideNonDefault.Replace("''", "'"); 
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
		            _gluteraldetydeGermicideNonDefault = value.Replace("'", "''"); 
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
				else return _peraceticAcidMixtureGermNonDefault.Replace("''", "'"); 
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
		            _peraceticAcidMixtureGermNonDefault = value.Replace("'", "''"); 
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
				else return _otherGermicideNonDefault.Replace("''", "'"); 
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
		            _otherGermicideNonDefault = value.Replace("'", "''"); 
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
				else return _typeGermicideDescriptionNonDefault.Replace("''", "'"); 
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
		            _typeGermicideDescriptionNonDefault = value.Replace("'", "''"); 
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
				else return _hemodialysisServiceNonDefault.Replace("''", "'"); 
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
		            _hemodialysisServiceNonDefault = value.Replace("'", "''"); 
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
				else return _peritonealDialysisServiceNonDefault.Replace("''", "'"); 
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
		            _peritonealDialysisServiceNonDefault = value.Replace("'", "''"); 
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
				else return _transplanationServiceNonDefault.Replace("''", "'"); 
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
		            _transplanationServiceNonDefault = value.Replace("'", "''"); 
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
				else return _homeTrainingServiceNonDefault.Replace("''", "'"); 
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
		            _homeTrainingServiceNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "EMERGENCY_PREP_REPORT_REQUIRED" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string EmergencyPrepReportRequired
		{
			get 
			{ 
                if(_emergencyPrepReportRequiredNonDefault==null)return _emergencyPrepReportRequiredNonDefault;
				else return _emergencyPrepReportRequiredNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("EmergencyPrepReportRequired length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _emergencyPrepReportRequiredNonDefault =null;//null value 
                }
                else
                {		           
		            _emergencyPrepReportRequiredNonDefault = value.Replace("'", "''"); 
                }
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
				else return _initialNonDefault.Replace("''", "'"); 
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
		            _initialNonDefault = value.Replace("'", "''"); 
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
				else return _expansionToNewLocationNonDefault.Replace("''", "'"); 
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
		            _expansionToNewLocationNonDefault = value.Replace("'", "''"); 
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
				else return _changeOfOwnershipNonDefault.Replace("''", "'"); 
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
		            _changeOfOwnershipNonDefault = value.Replace("'", "''"); 
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
				else return _changeOfLocationNonDefault.Replace("''", "'"); 
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
		            _changeOfLocationNonDefault = value.Replace("'", "''"); 
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
				else return _expansionInCurrentLocationNonDefault.Replace("''", "'"); 
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
		            _expansionInCurrentLocationNonDefault = value.Replace("'", "''"); 
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
				else return _changeOfServicesNonDefault.Replace("''", "'"); 
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
		            _changeOfServicesNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "TYPE_APPLICATION_CODE7" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string TypeApplicationCode7
		{
			get 
			{ 
                if(_typeApplicationCode7NonDefault==null)return _typeApplicationCode7NonDefault;
				else return _typeApplicationCode7NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("TypeApplicationCode7 length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _typeApplicationCode7NonDefault =null;//null value 
                }
                else
                {		           
		            _typeApplicationCode7NonDefault = value.Replace("'", "''"); 
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
				else return _typeApplicationDescrNonDefault.Replace("''", "'"); 
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
		            _typeApplicationDescrNonDefault = value.Replace("'", "''"); 
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
				else return _providerBasedYNNonDefault.Replace("''", "'"); 
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
		            _providerBasedYNNonDefault = value.Replace("'", "''"); 
                }
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
				else return _relatedProviderLicensureNumNonDefault.Replace("''", "'"); 
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
		            _relatedProviderLicensureNumNonDefault = value.Replace("'", "''"); 
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
				else return _accreditedBodyNonDefault.Replace("''", "'"); 
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
		            _accreditedBodyNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "ENROLLED_IN_MEDICAID_YN" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string EnrolledInMedicaidYN
		{
			get 
			{ 
                if(_enrolledInMedicaidYNNonDefault==null)return _enrolledInMedicaidYNNonDefault;
				else return _enrolledInMedicaidYNNonDefault.Replace("''", "'"); 
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
		            _enrolledInMedicaidYNNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "SUBMISSION_DATE" field.  
		/// </summary>
		public DateTime? SubmissionDate
		{
			get 
			{ 
                return _submissionDateNonDefault;
			}
			set 
			{
            
                _submissionDateNonDefault = value; 
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
		/// This property is mapped to the "STATUS_COMMENT" field. Length must be between 0 and 1024 characters. 
		/// </summary>
		public string StatusComment
		{
			get 
			{ 
                if(_statusCommentNonDefault==null)return _statusCommentNonDefault;
				else return _statusCommentNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1024)
					throw new ArgumentException("StatusComment length must be between 0 and 1024 characters.");

				
                if(value ==null)
                {
                    _statusCommentNonDefault =null;//null value 
                }
                else
                {		           
		            _statusCommentNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "TYPE_TREATMENT" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string TypeTreatment
		{
			get 
			{ 
                if(_typeTreatmentNonDefault==null)return _typeTreatmentNonDefault;
				else return _typeTreatmentNonDefault.Replace("''", "'"); 
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
		            _typeTreatmentNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_ADDRESS_LOC_TYPE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ChangeAddressLocType
		{
			get 
			{ 
                if(_changeAddressLocTypeNonDefault==null)return _changeAddressLocTypeNonDefault;
				else return _changeAddressLocTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ChangeAddressLocType length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _changeAddressLocTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _changeAddressLocTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CHANGE_ADDRESS_LOC_ID" field.  
		/// </summary>
		public int? ChangeAddressLocID
		{
			get 
			{ 
                return _changeAddressLocIDNonDefault;
			}
			set 
			{
            
                _changeAddressLocIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "KEY_PERSONNEL_CHANGE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string KeyPersonnelChange
		{
			get 
			{ 
                if(_keyPersonnelChangeNonDefault==null)return _keyPersonnelChangeNonDefault;
				else return _keyPersonnelChangeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("KeyPersonnelChange length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _keyPersonnelChangeNonDefault =null;//null value 
                }
                else
                {		           
		            _keyPersonnelChangeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "PROPOSED_EFFECTIVE_DATE" field.  
		/// </summary>
		public DateTime? ProposedEffectiveDate
		{
			get 
			{ 
                return _proposedEffectiveDateNonDefault;
			}
			set 
			{
            
                _proposedEffectiveDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "APPLICATION_ACTION" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string ApplicationAction
		{
			get 
			{ 
                if(_applicationActionNonDefault==null)return _applicationActionNonDefault;
				else return _applicationActionNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("ApplicationAction length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _applicationActionNonDefault =null;//null value 
                }
                else
                {		           
		            _applicationActionNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "AGE_RANGE_FROM" field.  
		/// </summary>
		public int? AgeRangeFrom
		{
			get 
			{ 
                return _ageRangeFromNonDefault;
			}
			set 
			{
            
                _ageRangeFromNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "AGE_RANGE_TO" field.  
		/// </summary>
		public int? AgeRangeTO
		{
			get 
			{ 
                return _ageRangeTONonDefault;
			}
			set 
			{
            
                _ageRangeTONonDefault = value; 
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
		/// This property is mapped to the "OTHER_BEDS_TOTAL" field.  
		/// </summary>
		public int? OtherBedsTotal
		{
			get 
			{ 
                return _otherBedsTotalNonDefault;
			}
			set 
			{
            
                _otherBedsTotalNonDefault = value; 
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
		/// This property is mapped to the "LIC_EFFECTIVE_DATE_OVERIDE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string LicEffectiveDateOveride
		{
			get 
			{ 
                if(_licEffectiveDateOverideNonDefault==null)return _licEffectiveDateOverideNonDefault;
				else return _licEffectiveDateOverideNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("LicEffectiveDateOveride length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licEffectiveDateOverideNonDefault =null;//null value 
                }
                else
                {		           
		            _licEffectiveDateOverideNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "LIC_EXPIRE_DATE_OVERIDE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string LicExpireDateOveride
		{
			get 
			{ 
                if(_licExpireDateOverideNonDefault==null)return _licExpireDateOverideNonDefault;
				else return _licExpireDateOverideNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("LicExpireDateOveride length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _licExpireDateOverideNonDefault =null;//null value 
                }
                else
                {		           
		            _licExpireDateOverideNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "CAPACITY_PROV_TOTAL" field.  
		/// </summary>
		public int? CapacityProvTotal
		{
			get 
			{ 
                return _capacityProvTotalNonDefault;
			}
			set 
			{
            
                _capacityProvTotalNonDefault = value; 
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
		/// This property is mapped to the "OPERATION_PRIOR_2005" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string OperationPrior2005
		{
			get 
			{ 
                if(_operationPrior2005NonDefault==null)return _operationPrior2005NonDefault;
				else return _operationPrior2005NonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("OperationPrior2005 length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _operationPrior2005NonDefault =null;//null value 
                }
                else
                {		           
		            _operationPrior2005NonDefault = value.Replace("'", "''"); 
                }
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
				else return _isolationNumOfStationsNonDefault.Replace("''", "'"); 
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
		            _isolationNumOfStationsNonDefault = value.Replace("'", "''"); 
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
				else return _relatedProviderNameNonDefault.Replace("''", "'"); 
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
		            _relatedProviderNameNonDefault = value.Replace("'", "''"); 
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
				else return _admMultiFacYNNonDefault.Replace("''", "'"); 
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
		            _admMultiFacYNNonDefault = value.Replace("'", "''"); 
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
				else return _admMultiFacOtherNameNonDefault.Replace("''", "'"); 
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
		            _admMultiFacOtherNameNonDefault = value.Replace("'", "''"); 
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
				else return _singleStoryYNNonDefault.Replace("''", "'"); 
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
		            _singleStoryYNNonDefault = value.Replace("'", "''"); 
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
		/// This property is mapped to the "LEVEL_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string LevelCode
		{
			get 
			{ 
                if(_levelCodeNonDefault==null)return _levelCodeNonDefault;
				else return _levelCodeNonDefault.Replace("''", "'"); 
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
		            _levelCodeNonDefault = value.Replace("'", "''"); 
                }
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
		/// Provides access to the related table 'ADDRESS'
		/// </summary>
		public BO_Addresses BO_AddressesApplicationID
		{
			get 
			{
                if (_bO_AddressesApplicationID == null)
                {
                    _bO_AddressesApplicationID = new BO_Addresses();
                    _bO_AddressesApplicationID = BO_Address.SelectByField("APPLICATION_ID",ApplicationID);
                }                
				return _bO_AddressesApplicationID; 
			}
			set 
			{
				  _bO_AddressesApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'AFFILIATION'
		/// </summary>
		public BO_Affiliations BO_AffiliationsApplicationID
		{
			get 
			{
                if (_bO_AffiliationsApplicationID == null)
                {
                    _bO_AffiliationsApplicationID = new BO_Affiliations();
                    _bO_AffiliationsApplicationID = BO_Affiliation.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_AffiliationsApplicationID; 
			}
			set 
			{
				  _bO_AffiliationsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'APPLICATION_SUPPORT'
		/// </summary>
		public BO_ApplicationSupports BO_ApplicationSupportsApplicationID
		{
			get 
			{
                if (_bO_ApplicationSupportsApplicationID == null)
                {
                    _bO_ApplicationSupportsApplicationID = new BO_ApplicationSupports();
                    _bO_ApplicationSupportsApplicationID = BO_ApplicationSupport.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_ApplicationSupportsApplicationID; 
			}
			set 
			{
				  _bO_ApplicationSupportsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'APPLICATION_ITEMS'
		/// </summary>
		public BO_ApplicationItems BO_ApplicationItemsApplicationID
		{
			get 
			{
                if (_bO_ApplicationItemsApplicationID == null)
                {
                    _bO_ApplicationItemsApplicationID = new BO_ApplicationItems();
                    _bO_ApplicationItemsApplicationID = BO_ApplicationItem.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_ApplicationItemsApplicationID; 
			}
			set 
			{
				  _bO_ApplicationItemsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'BILLING'
		/// </summary>
		public BO_Billings BO_BillingsApplicationID
		{
			get 
			{
                if (_bO_BillingsApplicationID == null)
                {
                    _bO_BillingsApplicationID = new BO_Billings();
                    _bO_BillingsApplicationID = BO_Billing.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_BillingsApplicationID; 
			}
			set 
			{
				  _bO_BillingsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'CAPACITIES'
		/// </summary>
		public BO_Capacities BO_CapacitiesApplicationID
		{
			get 
			{
                if (_bO_CapacitiesApplicationID == null)
                {
                    _bO_CapacitiesApplicationID = new BO_Capacities();
                    _bO_CapacitiesApplicationID = BO_Capacity.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_CapacitiesApplicationID; 
			}
			set 
			{
				  _bO_CapacitiesApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LETTER_OF_INTENT'
		/// </summary>
		public BO_LetterOfIntents BO_LetterOfIntentsApplicationID
		{
			get 
			{
                if (_bO_LetterOfIntentsApplicationID == null)
                {
                    _bO_LetterOfIntentsApplicationID = new BO_LetterOfIntents();
                    _bO_LetterOfIntentsApplicationID = BO_LetterOfIntent.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_LetterOfIntentsApplicationID; 
			}
			set 
			{
				  _bO_LetterOfIntentsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LICENSE'
		/// </summary>
		public BO_Licenses BO_LicensesApplicationID
		{
			get 
			{
                if (_bO_LicensesApplicationID == null)
                {
                    _bO_LicensesApplicationID = new BO_Licenses();
                    _bO_LicensesApplicationID = BO_License.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_LicensesApplicationID; 
			}
			set 
			{
				  _bO_LicensesApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'MESSAGES'
		/// </summary>
		public BO_Messages BO_MessagesApplicationID
		{
			get 
			{
                if (_bO_MessagesApplicationID == null)
                {
                    _bO_MessagesApplicationID = new BO_Messages();
                    _bO_MessagesApplicationID = BO_Message.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_MessagesApplicationID; 
			}
			set 
			{
				  _bO_MessagesApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'OWNERSHIP'
		/// </summary>
		public BO_Ownerships BO_OwnershipsApplicationID
		{
			get 
			{
                if (_bO_OwnershipsApplicationID == null)
                {
                    _bO_OwnershipsApplicationID = new BO_Ownerships();
                    _bO_OwnershipsApplicationID = BO_Ownership.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_OwnershipsApplicationID; 
			}
			set 
			{
				  _bO_OwnershipsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'PROVIDER_PERSON'
		/// </summary>
		public BO_ProviderPeople BO_ProviderPeopleApplicationID
		{
			get 
			{
                if (_bO_ProviderPeopleApplicationID == null)
                {
                    _bO_ProviderPeopleApplicationID = new BO_ProviderPeople();
                    _bO_ProviderPeopleApplicationID = BO_ProviderPerson.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_ProviderPeopleApplicationID; 
			}
			set 
			{
				  _bO_ProviderPeopleApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SERVICE'
		/// </summary>
		public BO_Services BO_ServicesApplicationID
		{
			get 
			{
                if (_bO_ServicesApplicationID == null)
                {
                    _bO_ServicesApplicationID = new BO_Services();
                    _bO_ServicesApplicationID = BO_Service.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_ServicesApplicationID; 
			}
			set 
			{
				  _bO_ServicesApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'SPECIALTY_UNIT'
		/// </summary>
		public BO_SpecialtyUnits BO_SpecialtyUnitsApplicationID
		{
			get 
			{
                if (_bO_SpecialtyUnitsApplicationID == null)
                {
                    _bO_SpecialtyUnitsApplicationID = new BO_SpecialtyUnits();
                    _bO_SpecialtyUnitsApplicationID = BO_SpecialtyUnit.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_SpecialtyUnitsApplicationID; 
			}
			set 
			{
				  _bO_SpecialtyUnitsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'STAFFING'
		/// </summary>
		public BO_Staffings BO_StaffingsApplicationID
		{
			get 
			{
                if (_bO_StaffingsApplicationID == null)
                {
                    _bO_StaffingsApplicationID = new BO_Staffings();
                    _bO_StaffingsApplicationID = BO_Staffing.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_StaffingsApplicationID; 
			}
			set 
			{
				  _bO_StaffingsApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'STATUS_HISTORY'
		/// </summary>
		public BO_StatusHistories BO_StatusHistoriesApplicationID
		{
			get 
			{
                if (_bO_StatusHistoriesApplicationID == null)
                {
                    _bO_StatusHistoriesApplicationID = new BO_StatusHistories();
                    _bO_StatusHistoriesApplicationID = BO_StatusHistory.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_StatusHistoriesApplicationID; 
			}
			set 
			{
				  _bO_StatusHistoriesApplicationID = value;
			}
		}

		/// <summary>
		/// Provides access to the related table 'LETTERS_QUEUE'
		/// </summary>
		public BO_LettersQueues BO_LettersQueuesApplicationID
		{
			get 
			{
                if (_bO_LettersQueuesApplicationID == null)
                {
                    _bO_LettersQueuesApplicationID = new BO_LettersQueues();
                    _bO_LettersQueuesApplicationID = BO_LettersQueue.SelectByField("APPLICATION_ID", ApplicationID);
                }                
				return _bO_LettersQueuesApplicationID; 
			}
			set 
			{
				  _bO_LettersQueuesApplicationID = value;
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
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
              
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
              
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
              
			// Pass the value of '_dateStarted' as parameter 'DateStarted' of the stored procedure.
			if(_dateStartedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateStarted", _dateStartedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateStarted", DBNull.Value );
              
			// Pass the value of '_dateCompleted' as parameter 'DateCompleted' of the stored procedure.
			if(_dateCompletedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateCompleted", _dateCompletedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateCompleted", DBNull.Value );
              
			// Pass the value of '_licensureEffectiveDate' as parameter 'LicensureEffectiveDate' of the stored procedure.
			if(_licensureEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", _licensureEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", DBNull.Value );
              
			// Pass the value of '_applicationStatus' as parameter 'ApplicationStatus' of the stored procedure.
			if(_applicationStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationStatus", _applicationStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationStatus", DBNull.Value );
              
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
              
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
              
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
              
			// Pass the value of '_schoolID' as parameter 'SchoolID' of the stored procedure.
			if(_schoolIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@SchoolID", _schoolIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@SchoolID", DBNull.Value );
              
			// Pass the value of '_emsParishCode' as parameter 'EmsParishCode' of the stored procedure.
			if(_emsParishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmsParishCode", _emsParishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmsParishCode", DBNull.Value );
              
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
              
			// Pass the value of '_contactName' as parameter 'ContactName' of the stored procedure.
			if(_contactNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ContactName", _contactNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ContactName", DBNull.Value );
              
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
              
			// Pass the value of '_hoursMinutes' as parameter 'HoursMinutes' of the stored procedure.
			if(_hoursMinutesNonDefault!=null)
              oDatabaseHelper.AddParameter("@HoursMinutes", _hoursMinutesNonDefault);
            else
              oDatabaseHelper.AddParameter("@HoursMinutes", DBNull.Value );
              
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
              
			// Pass the value of '_typeFacility' as parameter 'TypeFacility' of the stored procedure.
			if(_typeFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility", _typeFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility", DBNull.Value );
              
			// Pass the value of '_typeFacility1' as parameter 'TypeFacility1' of the stored procedure.
			if(_typeFacility1NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility1", _typeFacility1NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility1", DBNull.Value );
              
			// Pass the value of '_typeFacility2' as parameter 'TypeFacility2' of the stored procedure.
			if(_typeFacility2NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility2", _typeFacility2NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility2", DBNull.Value );
              
			// Pass the value of '_typeFacility3' as parameter 'TypeFacility3' of the stored procedure.
			if(_typeFacility3NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility3", _typeFacility3NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility3", DBNull.Value );
              
			// Pass the value of '_typeFacility4' as parameter 'TypeFacility4' of the stored procedure.
			if(_typeFacility4NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility4", _typeFacility4NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility4", DBNull.Value );
              
			// Pass the value of '_typeFacility5' as parameter 'TypeFacility5' of the stored procedure.
			if(_typeFacility5NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility5", _typeFacility5NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility5", DBNull.Value );
              
			// Pass the value of '_typeFacility6' as parameter 'TypeFacility6' of the stored procedure.
			if(_typeFacility6NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility6", _typeFacility6NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility6", DBNull.Value );
              
			// Pass the value of '_licensedSnfFacility' as parameter 'LicensedSnfFacility' of the stored procedure.
			if(_licensedSnfFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", _licensedSnfFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", DBNull.Value );
              
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			if(_typeOfClientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfClients", DBNull.Value );
              
			// Pass the value of '_jcahYN' as parameter 'JcahYN' of the stored procedure.
			if(_jcahYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@JcahYN", _jcahYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@JcahYN", DBNull.Value );
              
			// Pass the value of '_stateFireApprovalDate' as parameter 'StateFireApprovalDate' of the stored procedure.
			if(_stateFireApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", _stateFireApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", DBNull.Value );
              
			// Pass the value of '_ageRange' as parameter 'AgeRange' of the stored procedure.
			if(_ageRangeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRange", _ageRangeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRange", DBNull.Value );
              
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
              
			// Pass the value of '_isolationUnitYN' as parameter 'IsolationUnitYN' of the stored procedure.
			if(_isolationUnitYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsolationUnitYN", _isolationUnitYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsolationUnitYN", DBNull.Value );
              
			// Pass the value of '_statusCode' as parameter 'StatusCode' of the stored procedure.
			if(_statusCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusCode", _statusCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusCode", DBNull.Value );
              
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			if(_statusDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusDate", DBNull.Value );
              
			// Pass the value of '_noOfParishesServed' as parameter 'NoOfParishesServed' of the stored procedure.
			if(_noOfParishesServedNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfParishesServed", _noOfParishesServedNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfParishesServed", DBNull.Value );
              
			// Pass the value of '_licensureSurveyDate' as parameter 'LicensureSurveyDate' of the stored procedure.
			if(_licensureSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", _licensureSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", DBNull.Value );
              
			// Pass the value of '_waivers' as parameter 'Waivers' of the stored procedure.
			if(_waiversNonDefault!=null)
              oDatabaseHelper.AddParameter("@Waivers", _waiversNonDefault);
            else
              oDatabaseHelper.AddParameter("@Waivers", DBNull.Value );
              
			// Pass the value of '_userLastMaint' as parameter 'UserLastMaint' of the stored procedure.
			if(_userLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@UserLastMaint", _userLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@UserLastMaint", DBNull.Value );
              
			// Pass the value of '_dateLastMaint' as parameter 'DateLastMaint' of the stored procedure.
			if(_dateLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateLastMaint", _dateLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateLastMaint", DBNull.Value );
              
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
              
			// Pass the value of '_deemedStatus' as parameter 'DeemedStatus' of the stored procedure.
			if(_deemedStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@DeemedStatus", _deemedStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@DeemedStatus", DBNull.Value );
              
			// Pass the value of '_chapAccreditionYN' as parameter 'ChapAccreditionYN' of the stored procedure.
			if(_chapAccreditionYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", _chapAccreditionYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", DBNull.Value );
              
			// Pass the value of '_fiscalIntermediaryNum' as parameter 'FiscalIntermediaryNum' of the stored procedure.
			if(_fiscalIntermediaryNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", _fiscalIntermediaryNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", DBNull.Value );
              
			// Pass the value of '_fiscalIntermediaryDesc' as parameter 'FiscalIntermediaryDesc' of the stored procedure.
			if(_fiscalIntermediaryDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", _fiscalIntermediaryDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", DBNull.Value );
              
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
              
			// Pass the value of '_noOf3hrShiftsWeek' as parameter 'NoOf3hrShiftsWeek' of the stored procedure.
			if(_noOf3hrShiftsWeekNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", _noOf3hrShiftsWeekNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", DBNull.Value );
              
			// Pass the value of '_averageNumPatientsShift' as parameter 'AverageNumPatientsShift' of the stored procedure.
			if(_averageNumPatientsShiftNonDefault!=null)
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", _averageNumPatientsShiftNonDefault);
            else
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", DBNull.Value );
              
			// Pass the value of '_vendorNum' as parameter 'VendorNum' of the stored procedure.
			if(_vendorNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@VendorNum", _vendorNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@VendorNum", DBNull.Value );
              
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
              
			// Pass the value of '_waiverCode5' as parameter 'WaiverCode5' of the stored procedure.
			if(_waiverCode5NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode5", _waiverCode5NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode5", DBNull.Value );
              
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
              
			// Pass the value of '_accreditationExpirationDate' as parameter 'AccreditationExpirationDate' of the stored procedure.
			if(_accreditationExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", _accreditationExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", DBNull.Value );
              
			// Pass the value of '_facilityWithinFacility' as parameter 'FacilityWithinFacility' of the stored procedure.
			if(_facilityWithinFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", _facilityWithinFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", DBNull.Value );
              
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			if(_facilityTypeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityTypeCode", DBNull.Value );
              
			// Pass the value of '_transplantYN' as parameter 'TransplantYN' of the stored procedure.
			if(_transplantYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplantYN", _transplantYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplantYN", DBNull.Value );
              
			// Pass the value of '_enrolledRhcOffsiteYN' as parameter 'EnrolledRhcOffsiteYN' of the stored procedure.
			if(_enrolledRhcOffsiteYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", _enrolledRhcOffsiteYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", DBNull.Value );
              
			// Pass the value of '_facilityWithinFacilityYN' as parameter 'FacilityWithinFacilityYN' of the stored procedure.
			if(_facilityWithinFacilityYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", _facilityWithinFacilityYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", DBNull.Value );
              
			// Pass the value of '_certifiedBedOverrideYN' as parameter 'CertifiedBedOverrideYN' of the stored procedure.
			if(_certifiedBedOverrideYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", _certifiedBedOverrideYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", DBNull.Value );
              
			// Pass the value of '_forYearEndingDate' as parameter 'ForYearEndingDate' of the stored procedure.
			if(_forYearEndingDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ForYearEndingDate", _forYearEndingDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ForYearEndingDate", DBNull.Value );
              
			// Pass the value of '_servicesOffered' as parameter 'ServicesOffered' of the stored procedure.
			if(_servicesOfferedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServicesOffered", _servicesOfferedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServicesOffered", DBNull.Value );
              
			// Pass the value of '_halfwayHouse' as parameter 'HalfwayHouse' of the stored procedure.
			if(_halfwayHouseNonDefault!=null)
              oDatabaseHelper.AddParameter("@HalfwayHouse", _halfwayHouseNonDefault);
            else
              oDatabaseHelper.AddParameter("@HalfwayHouse", DBNull.Value );
              
			// Pass the value of '_inPatient' as parameter 'InPatient' of the stored procedure.
			if(_inPatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@InPatient", _inPatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@InPatient", DBNull.Value );
              
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
              
			// Pass the value of '_methadoneTreatment' as parameter 'MethadoneTreatment' of the stored procedure.
			if(_methadoneTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@MethadoneTreatment", _methadoneTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@MethadoneTreatment", DBNull.Value );
              
			// Pass the value of '_preventionEducation' as parameter 'PreventionEducation' of the stored procedure.
			if(_preventionEducationNonDefault!=null)
              oDatabaseHelper.AddParameter("@PreventionEducation", _preventionEducationNonDefault);
            else
              oDatabaseHelper.AddParameter("@PreventionEducation", DBNull.Value );
              
			// Pass the value of '_residentialTreatment' as parameter 'ResidentialTreatment' of the stored procedure.
			if(_residentialTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@ResidentialTreatment", _residentialTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@ResidentialTreatment", DBNull.Value );
              
			// Pass the value of '_socialSettingDetoxification' as parameter 'SocialSettingDetoxification' of the stored procedure.
			if(_socialSettingDetoxificationNonDefault!=null)
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", _socialSettingDetoxificationNonDefault);
            else
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", DBNull.Value );
              
			// Pass the value of '_adultHealthCare' as parameter 'AdultHealthCare' of the stored procedure.
			if(_adultHealthCareNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdultHealthCare", _adultHealthCareNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdultHealthCare", DBNull.Value );
              
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
              
			// Pass the value of '_currentSurveyMonth' as parameter 'CurrentSurveyMonth' of the stored procedure.
			if(_currentSurveyMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", _currentSurveyMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", DBNull.Value );
              
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
              
			// Pass the value of '_numOfPatientsFollowedAtHome' as parameter 'NumOfPatientsFollowedAtHome' of the stored procedure.
			if(_numOfPatientsFollowedAtHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", _numOfPatientsFollowedAtHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", DBNull.Value );
              
			// Pass the value of '_automobileInsurancePrepaymentDueDate' as parameter 'AutomobileInsurancePrepaymentDueDate' of the stored procedure.
			if(_automobileInsurancePrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", _automobileInsurancePrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", DBNull.Value );
              
			// Pass the value of '_generalLiabilityPrepaymentDueDate' as parameter 'GeneralLiabilityPrepaymentDueDate' of the stored procedure.
			if(_generalLiabilityPrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", _generalLiabilityPrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", DBNull.Value );
              
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
              
			// Pass the value of '_directorName' as parameter 'DirectorName' of the stored procedure.
			if(_directorNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorName", _directorNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorName", DBNull.Value );
              
			// Pass the value of '_year1ReviewDateDue' as parameter 'Year1ReviewDateDue' of the stored procedure.
			if(_year1ReviewDateDueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", _year1ReviewDateDueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", DBNull.Value );
              
			// Pass the value of '_totalNumDialysisPatients' as parameter 'TotalNumDialysisPatients' of the stored procedure.
			if(_totalNumDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", _totalNumDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", DBNull.Value );
              
			// Pass the value of '_hemodialysisNumPatients' as parameter 'HemodialysisNumPatients' of the stored procedure.
			if(_hemodialysisNumPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", _hemodialysisNumPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", DBNull.Value );
              
			// Pass the value of '_numOfPeritonealDialysisPatients' as parameter 'NumOfPeritonealDialysisPatients' of the stored procedure.
			if(_numOfPeritonealDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", _numOfPeritonealDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", DBNull.Value );
              
			// Pass the value of '_hemodialysisNumOfStations' as parameter 'HemodialysisNumOfStations' of the stored procedure.
			if(_hemodialysisNumOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", _hemodialysisNumOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", DBNull.Value );
              
			// Pass the value of '_hemodialysisTrainingNumOfStation' as parameter 'HemodialysisTrainingNumOfStation' of the stored procedure.
			if(_hemodialysisTrainingNumOfStationNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", _hemodialysisTrainingNumOfStationNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", DBNull.Value );
              
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
              
			// Pass the value of '_manualYN' as parameter 'ManualYN' of the stored procedure.
			if(_manualYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ManualYN", _manualYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ManualYN", DBNull.Value );
              
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
              
			// Pass the value of '_peritonealDialysisService' as parameter 'PeritonealDialysisService' of the stored procedure.
			if(_peritonealDialysisServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", _peritonealDialysisServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", DBNull.Value );
              
			// Pass the value of '_transplanationService' as parameter 'TransplanationService' of the stored procedure.
			if(_transplanationServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplanationService", _transplanationServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplanationService", DBNull.Value );
              
			// Pass the value of '_homeTrainingService' as parameter 'HomeTrainingService' of the stored procedure.
			if(_homeTrainingServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@HomeTrainingService", _homeTrainingServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@HomeTrainingService", DBNull.Value );
              
			// Pass the value of '_emergencyPrepReportRequired' as parameter 'EmergencyPrepReportRequired' of the stored procedure.
			if(_emergencyPrepReportRequiredNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", _emergencyPrepReportRequiredNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", DBNull.Value );
              
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
              
			// Pass the value of '_relatedProviderLicensureNum' as parameter 'RelatedProviderLicensureNum' of the stored procedure.
			if(_relatedProviderLicensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", _relatedProviderLicensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", DBNull.Value );
              
			// Pass the value of '_accreditedBody' as parameter 'AccreditedBody' of the stored procedure.
			if(_accreditedBodyNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditedBody", _accreditedBodyNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditedBody", DBNull.Value );
              
			// Pass the value of '_licensureExpirationDate' as parameter 'LicensureExpirationDate' of the stored procedure.
			if(_licensureExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", _licensureExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", DBNull.Value );
              
			// Pass the value of '_enrolledInMedicaidYN' as parameter 'EnrolledInMedicaidYN' of the stored procedure.
			if(_enrolledInMedicaidYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", _enrolledInMedicaidYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", DBNull.Value );
              
			// Pass the value of '_submissionDate' as parameter 'SubmissionDate' of the stored procedure.
			if(_submissionDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubmissionDate", _submissionDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubmissionDate", DBNull.Value );
              
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			if(_totalLicBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBeds", DBNull.Value );
              
			// Pass the value of '_statusComment' as parameter 'StatusComment' of the stored procedure.
			if(_statusCommentNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusComment", _statusCommentNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusComment", DBNull.Value );
              
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			if(_unitNonDefault!=null)
              oDatabaseHelper.AddParameter("@Unit", _unitNonDefault);
            else
              oDatabaseHelper.AddParameter("@Unit", DBNull.Value );
              
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			if(_typeTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeTreatment", DBNull.Value );
              
			// Pass the value of '_changeAddressLocType' as parameter 'ChangeAddressLocType' of the stored procedure.
			if(_changeAddressLocTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeAddressLocType", _changeAddressLocTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeAddressLocType", DBNull.Value );
              
			// Pass the value of '_changeAddressLocID' as parameter 'ChangeAddressLocID' of the stored procedure.
			if(_changeAddressLocIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeAddressLocID", _changeAddressLocIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeAddressLocID", DBNull.Value );
              
			// Pass the value of '_keyPersonnelChange' as parameter 'KeyPersonnelChange' of the stored procedure.
			if(_keyPersonnelChangeNonDefault!=null)
              oDatabaseHelper.AddParameter("@KeyPersonnelChange", _keyPersonnelChangeNonDefault);
            else
              oDatabaseHelper.AddParameter("@KeyPersonnelChange", DBNull.Value );
              
			// Pass the value of '_proposedEffectiveDate' as parameter 'ProposedEffectiveDate' of the stored procedure.
			if(_proposedEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProposedEffectiveDate", _proposedEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProposedEffectiveDate", DBNull.Value );
              
			// Pass the value of '_applicationAction' as parameter 'ApplicationAction' of the stored procedure.
			if(_applicationActionNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationAction", _applicationActionNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationAction", DBNull.Value );
              
			// Pass the value of '_ageRangeFrom' as parameter 'AgeRangeFrom' of the stored procedure.
			if(_ageRangeFromNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeFrom", _ageRangeFromNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeFrom", DBNull.Value );
              
			// Pass the value of '_ageRangeTO' as parameter 'AgeRangeTO' of the stored procedure.
			if(_ageRangeTONonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeTO", _ageRangeTONonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeTO", DBNull.Value );
              
			// Pass the value of '_snf18beds' as parameter 'Snf18beds' of the stored procedure.
			if(_snf18bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf18beds", _snf18bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf18beds", DBNull.Value );
              
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
              
			// Pass the value of '_bedsCertified' as parameter 'BedsCertified' of the stored procedure.
			if(_bedsCertifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsCertified", _bedsCertifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsCertified", DBNull.Value );
              
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			if(_numberOfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberOfBeds", DBNull.Value );
              
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			if(_otherBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBeds", DBNull.Value );
              
			// Pass the value of '_unitsNumTotal' as parameter 'UnitsNumTotal' of the stored procedure.
			if(_unitsNumTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumTotal", _unitsNumTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumTotal", DBNull.Value );
              
			// Pass the value of '_totalLicBedsTotal' as parameter 'TotalLicBedsTotal' of the stored procedure.
			if(_totalLicBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", _totalLicBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", DBNull.Value );
              
			// Pass the value of '_psychiatricBedsTotal' as parameter 'PsychiatricBedsTotal' of the stored procedure.
			if(_psychiatricBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", _psychiatricBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", DBNull.Value );
              
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
              
			// Pass the value of '_unitsNumOffsiteTotal' as parameter 'UnitsNumOffsiteTotal' of the stored procedure.
			if(_unitsNumOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", _unitsNumOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_totalLicBedsOffsiteTotal' as parameter 'TotalLicBedsOffsiteTotal' of the stored procedure.
			if(_totalLicBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", _totalLicBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_psychiatricBedsOffsiteTotal' as parameter 'PsychiatricBedsOffsiteTotal' of the stored procedure.
			if(_psychiatricBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", _psychiatricBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", DBNull.Value );
              
			// Pass the value of '_rehabBedsOffsiteTotal' as parameter 'RehabBedsOffsiteTotal' of the stored procedure.
			if(_rehabBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", _rehabBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", DBNull.Value );
              
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
              
			// Pass the value of '_fcertBeds' as parameter 'FcertBeds' of the stored procedure.
			if(_fcertBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@FcertBeds", _fcertBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@FcertBeds", DBNull.Value );
              
			// Pass the value of '_otherBedsTotal' as parameter 'OtherBedsTotal' of the stored procedure.
			if(_otherBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBedsTotal", _otherBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBedsTotal", DBNull.Value );
              
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			if(_currentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", DBNull.Value );
              
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			if(_originalLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", DBNull.Value );
              
			// Pass the value of '_licEffectiveDateOveride' as parameter 'LicEffectiveDateOveride' of the stored procedure.
			if(_licEffectiveDateOverideNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicEffectiveDateOveride", _licEffectiveDateOverideNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicEffectiveDateOveride", DBNull.Value );
              
			// Pass the value of '_licExpireDateOveride' as parameter 'LicExpireDateOveride' of the stored procedure.
			if(_licExpireDateOverideNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicExpireDateOveride", _licExpireDateOverideNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicExpireDateOveride", DBNull.Value );
              
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
              
			// Pass the value of '_capacityProvTotal' as parameter 'CapacityProvTotal' of the stored procedure.
			if(_capacityProvTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityProvTotal", _capacityProvTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityProvTotal", DBNull.Value );
              
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			if(_numActivePatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumActivePatients", DBNull.Value );
              
			// Pass the value of '_operationPrior2005' as parameter 'OperationPrior2005' of the stored procedure.
			if(_operationPrior2005NonDefault!=null)
              oDatabaseHelper.AddParameter("@OperationPrior2005", _operationPrior2005NonDefault);
            else
              oDatabaseHelper.AddParameter("@OperationPrior2005", DBNull.Value );
              
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
			if(_year2ReviewDateDueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Year2ReviewDateDue", _year2ReviewDateDueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Year2ReviewDateDue", DBNull.Value );
              
			// Pass the value of '_levelCode' as parameter 'LevelCode' of the stored procedure.
			if(_levelCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LevelCode", _levelCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LevelCode", DBNull.Value );
              
			// Pass the value of '_originalEnrollmentDate' as parameter 'OriginalEnrollmentDate' of the stored procedure.
			if(_originalEnrollmentDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", _originalEnrollmentDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_APPLICATIONS_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			if(_businessProcessIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@BusinessProcessID", DBNull.Value );
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			if(_stateIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateID", DBNull.Value );
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			if(_programIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProgramID", DBNull.Value );
			// Pass the value of '_dateStarted' as parameter 'DateStarted' of the stored procedure.
			if(_dateStartedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateStarted", _dateStartedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateStarted", DBNull.Value );
			// Pass the value of '_dateCompleted' as parameter 'DateCompleted' of the stored procedure.
			if(_dateCompletedNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateCompleted", _dateCompletedNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateCompleted", DBNull.Value );
			// Pass the value of '_licensureEffectiveDate' as parameter 'LicensureEffectiveDate' of the stored procedure.
			if(_licensureEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", _licensureEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureEffectiveDate", DBNull.Value );
			// Pass the value of '_applicationStatus' as parameter 'ApplicationStatus' of the stored procedure.
			if(_applicationStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationStatus", _applicationStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationStatus", DBNull.Value );
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
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			if(_stateCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateCode", DBNull.Value );
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
			// Pass the value of '_schoolID' as parameter 'SchoolID' of the stored procedure.
			if(_schoolIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@SchoolID", _schoolIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@SchoolID", DBNull.Value );
			// Pass the value of '_emsParishCode' as parameter 'EmsParishCode' of the stored procedure.
			if(_emsParishCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmsParishCode", _emsParishCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmsParishCode", DBNull.Value );
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
			// Pass the value of '_contactName' as parameter 'ContactName' of the stored procedure.
			if(_contactNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@ContactName", _contactNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@ContactName", DBNull.Value );
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
			// Pass the value of '_hoursMinutes' as parameter 'HoursMinutes' of the stored procedure.
			if(_hoursMinutesNonDefault!=null)
              oDatabaseHelper.AddParameter("@HoursMinutes", _hoursMinutesNonDefault);
            else
              oDatabaseHelper.AddParameter("@HoursMinutes", DBNull.Value );
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
			// Pass the value of '_typeFacility' as parameter 'TypeFacility' of the stored procedure.
			if(_typeFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility", _typeFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility", DBNull.Value );
			// Pass the value of '_typeFacility1' as parameter 'TypeFacility1' of the stored procedure.
			if(_typeFacility1NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility1", _typeFacility1NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility1", DBNull.Value );
			// Pass the value of '_typeFacility2' as parameter 'TypeFacility2' of the stored procedure.
			if(_typeFacility2NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility2", _typeFacility2NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility2", DBNull.Value );
			// Pass the value of '_typeFacility3' as parameter 'TypeFacility3' of the stored procedure.
			if(_typeFacility3NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility3", _typeFacility3NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility3", DBNull.Value );
			// Pass the value of '_typeFacility4' as parameter 'TypeFacility4' of the stored procedure.
			if(_typeFacility4NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility4", _typeFacility4NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility4", DBNull.Value );
			// Pass the value of '_typeFacility5' as parameter 'TypeFacility5' of the stored procedure.
			if(_typeFacility5NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility5", _typeFacility5NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility5", DBNull.Value );
			// Pass the value of '_typeFacility6' as parameter 'TypeFacility6' of the stored procedure.
			if(_typeFacility6NonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeFacility6", _typeFacility6NonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeFacility6", DBNull.Value );
			// Pass the value of '_licensedSnfFacility' as parameter 'LicensedSnfFacility' of the stored procedure.
			if(_licensedSnfFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", _licensedSnfFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensedSnfFacility", DBNull.Value );
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			if(_typeOfClientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeOfClients", DBNull.Value );
			// Pass the value of '_jcahYN' as parameter 'JcahYN' of the stored procedure.
			if(_jcahYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@JcahYN", _jcahYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@JcahYN", DBNull.Value );
			// Pass the value of '_stateFireApprovalDate' as parameter 'StateFireApprovalDate' of the stored procedure.
			if(_stateFireApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", _stateFireApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StateFireApprovalDate", DBNull.Value );
			// Pass the value of '_ageRange' as parameter 'AgeRange' of the stored procedure.
			if(_ageRangeNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRange", _ageRangeNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRange", DBNull.Value );
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
			// Pass the value of '_isolationUnitYN' as parameter 'IsolationUnitYN' of the stored procedure.
			if(_isolationUnitYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@IsolationUnitYN", _isolationUnitYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@IsolationUnitYN", DBNull.Value );
			// Pass the value of '_statusCode' as parameter 'StatusCode' of the stored procedure.
			if(_statusCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusCode", _statusCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusCode", DBNull.Value );
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			if(_statusDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusDate", DBNull.Value );
			// Pass the value of '_noOfParishesServed' as parameter 'NoOfParishesServed' of the stored procedure.
			if(_noOfParishesServedNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOfParishesServed", _noOfParishesServedNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOfParishesServed", DBNull.Value );
			// Pass the value of '_licensureSurveyDate' as parameter 'LicensureSurveyDate' of the stored procedure.
			if(_licensureSurveyDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", _licensureSurveyDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureSurveyDate", DBNull.Value );
			// Pass the value of '_waivers' as parameter 'Waivers' of the stored procedure.
			if(_waiversNonDefault!=null)
              oDatabaseHelper.AddParameter("@Waivers", _waiversNonDefault);
            else
              oDatabaseHelper.AddParameter("@Waivers", DBNull.Value );
			// Pass the value of '_userLastMaint' as parameter 'UserLastMaint' of the stored procedure.
			if(_userLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@UserLastMaint", _userLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@UserLastMaint", DBNull.Value );
			// Pass the value of '_dateLastMaint' as parameter 'DateLastMaint' of the stored procedure.
			if(_dateLastMaintNonDefault!=null)
              oDatabaseHelper.AddParameter("@DateLastMaint", _dateLastMaintNonDefault);
            else
              oDatabaseHelper.AddParameter("@DateLastMaint", DBNull.Value );
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
			// Pass the value of '_deemedStatus' as parameter 'DeemedStatus' of the stored procedure.
			if(_deemedStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@DeemedStatus", _deemedStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@DeemedStatus", DBNull.Value );
			// Pass the value of '_chapAccreditionYN' as parameter 'ChapAccreditionYN' of the stored procedure.
			if(_chapAccreditionYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", _chapAccreditionYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChapAccreditionYN", DBNull.Value );
			// Pass the value of '_fiscalIntermediaryNum' as parameter 'FiscalIntermediaryNum' of the stored procedure.
			if(_fiscalIntermediaryNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", _fiscalIntermediaryNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", DBNull.Value );
			// Pass the value of '_fiscalIntermediaryDesc' as parameter 'FiscalIntermediaryDesc' of the stored procedure.
			if(_fiscalIntermediaryDescNonDefault!=null)
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", _fiscalIntermediaryDescNonDefault);
            else
              oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", DBNull.Value );
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
			// Pass the value of '_noOf3hrShiftsWeek' as parameter 'NoOf3hrShiftsWeek' of the stored procedure.
			if(_noOf3hrShiftsWeekNonDefault!=null)
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", _noOf3hrShiftsWeekNonDefault);
            else
              oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", DBNull.Value );
			// Pass the value of '_averageNumPatientsShift' as parameter 'AverageNumPatientsShift' of the stored procedure.
			if(_averageNumPatientsShiftNonDefault!=null)
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", _averageNumPatientsShiftNonDefault);
            else
              oDatabaseHelper.AddParameter("@AverageNumPatientsShift", DBNull.Value );
			// Pass the value of '_vendorNum' as parameter 'VendorNum' of the stored procedure.
			if(_vendorNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@VendorNum", _vendorNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@VendorNum", DBNull.Value );
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
			// Pass the value of '_waiverCode5' as parameter 'WaiverCode5' of the stored procedure.
			if(_waiverCode5NonDefault!=null)
              oDatabaseHelper.AddParameter("@WaiverCode5", _waiverCode5NonDefault);
            else
              oDatabaseHelper.AddParameter("@WaiverCode5", DBNull.Value );
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
			// Pass the value of '_accreditationExpirationDate' as parameter 'AccreditationExpirationDate' of the stored procedure.
			if(_accreditationExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", _accreditationExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditationExpirationDate", DBNull.Value );
			// Pass the value of '_facilityWithinFacility' as parameter 'FacilityWithinFacility' of the stored procedure.
			if(_facilityWithinFacilityNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", _facilityWithinFacilityNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacility", DBNull.Value );
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			if(_facilityTypeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityTypeCode", DBNull.Value );
			// Pass the value of '_transplantYN' as parameter 'TransplantYN' of the stored procedure.
			if(_transplantYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplantYN", _transplantYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplantYN", DBNull.Value );
			// Pass the value of '_enrolledRhcOffsiteYN' as parameter 'EnrolledRhcOffsiteYN' of the stored procedure.
			if(_enrolledRhcOffsiteYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", _enrolledRhcOffsiteYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", DBNull.Value );
			// Pass the value of '_facilityWithinFacilityYN' as parameter 'FacilityWithinFacilityYN' of the stored procedure.
			if(_facilityWithinFacilityYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", _facilityWithinFacilityYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", DBNull.Value );
			// Pass the value of '_certifiedBedOverrideYN' as parameter 'CertifiedBedOverrideYN' of the stored procedure.
			if(_certifiedBedOverrideYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", _certifiedBedOverrideYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", DBNull.Value );
			// Pass the value of '_forYearEndingDate' as parameter 'ForYearEndingDate' of the stored procedure.
			if(_forYearEndingDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ForYearEndingDate", _forYearEndingDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ForYearEndingDate", DBNull.Value );
			// Pass the value of '_servicesOffered' as parameter 'ServicesOffered' of the stored procedure.
			if(_servicesOfferedNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServicesOffered", _servicesOfferedNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServicesOffered", DBNull.Value );
			// Pass the value of '_halfwayHouse' as parameter 'HalfwayHouse' of the stored procedure.
			if(_halfwayHouseNonDefault!=null)
              oDatabaseHelper.AddParameter("@HalfwayHouse", _halfwayHouseNonDefault);
            else
              oDatabaseHelper.AddParameter("@HalfwayHouse", DBNull.Value );
			// Pass the value of '_inPatient' as parameter 'InPatient' of the stored procedure.
			if(_inPatientNonDefault!=null)
              oDatabaseHelper.AddParameter("@InPatient", _inPatientNonDefault);
            else
              oDatabaseHelper.AddParameter("@InPatient", DBNull.Value );
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
			// Pass the value of '_methadoneTreatment' as parameter 'MethadoneTreatment' of the stored procedure.
			if(_methadoneTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@MethadoneTreatment", _methadoneTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@MethadoneTreatment", DBNull.Value );
			// Pass the value of '_preventionEducation' as parameter 'PreventionEducation' of the stored procedure.
			if(_preventionEducationNonDefault!=null)
              oDatabaseHelper.AddParameter("@PreventionEducation", _preventionEducationNonDefault);
            else
              oDatabaseHelper.AddParameter("@PreventionEducation", DBNull.Value );
			// Pass the value of '_residentialTreatment' as parameter 'ResidentialTreatment' of the stored procedure.
			if(_residentialTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@ResidentialTreatment", _residentialTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@ResidentialTreatment", DBNull.Value );
			// Pass the value of '_socialSettingDetoxification' as parameter 'SocialSettingDetoxification' of the stored procedure.
			if(_socialSettingDetoxificationNonDefault!=null)
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", _socialSettingDetoxificationNonDefault);
            else
              oDatabaseHelper.AddParameter("@SocialSettingDetoxification", DBNull.Value );
			// Pass the value of '_adultHealthCare' as parameter 'AdultHealthCare' of the stored procedure.
			if(_adultHealthCareNonDefault!=null)
              oDatabaseHelper.AddParameter("@AdultHealthCare", _adultHealthCareNonDefault);
            else
              oDatabaseHelper.AddParameter("@AdultHealthCare", DBNull.Value );
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
			// Pass the value of '_currentSurveyMonth' as parameter 'CurrentSurveyMonth' of the stored procedure.
			if(_currentSurveyMonthNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", _currentSurveyMonthNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentSurveyMonth", DBNull.Value );
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
			// Pass the value of '_numOfPatientsFollowedAtHome' as parameter 'NumOfPatientsFollowedAtHome' of the stored procedure.
			if(_numOfPatientsFollowedAtHomeNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", _numOfPatientsFollowedAtHomeNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", DBNull.Value );
			// Pass the value of '_automobileInsurancePrepaymentDueDate' as parameter 'AutomobileInsurancePrepaymentDueDate' of the stored procedure.
			if(_automobileInsurancePrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", _automobileInsurancePrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", DBNull.Value );
			// Pass the value of '_generalLiabilityPrepaymentDueDate' as parameter 'GeneralLiabilityPrepaymentDueDate' of the stored procedure.
			if(_generalLiabilityPrepaymentDueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", _generalLiabilityPrepaymentDueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", DBNull.Value );
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
			// Pass the value of '_directorName' as parameter 'DirectorName' of the stored procedure.
			if(_directorNameNonDefault!=null)
              oDatabaseHelper.AddParameter("@DirectorName", _directorNameNonDefault);
            else
              oDatabaseHelper.AddParameter("@DirectorName", DBNull.Value );
			// Pass the value of '_year1ReviewDateDue' as parameter 'Year1ReviewDateDue' of the stored procedure.
			if(_year1ReviewDateDueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", _year1ReviewDateDueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Year1ReviewDateDue", DBNull.Value );
			// Pass the value of '_totalNumDialysisPatients' as parameter 'TotalNumDialysisPatients' of the stored procedure.
			if(_totalNumDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", _totalNumDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", DBNull.Value );
			// Pass the value of '_hemodialysisNumPatients' as parameter 'HemodialysisNumPatients' of the stored procedure.
			if(_hemodialysisNumPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", _hemodialysisNumPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumPatients", DBNull.Value );
			// Pass the value of '_numOfPeritonealDialysisPatients' as parameter 'NumOfPeritonealDialysisPatients' of the stored procedure.
			if(_numOfPeritonealDialysisPatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", _numOfPeritonealDialysisPatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", DBNull.Value );
			// Pass the value of '_hemodialysisNumOfStations' as parameter 'HemodialysisNumOfStations' of the stored procedure.
			if(_hemodialysisNumOfStationsNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", _hemodialysisNumOfStationsNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", DBNull.Value );
			// Pass the value of '_hemodialysisTrainingNumOfStation' as parameter 'HemodialysisTrainingNumOfStation' of the stored procedure.
			if(_hemodialysisTrainingNumOfStationNonDefault!=null)
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", _hemodialysisTrainingNumOfStationNonDefault);
            else
              oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", DBNull.Value );
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
			// Pass the value of '_manualYN' as parameter 'ManualYN' of the stored procedure.
			if(_manualYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@ManualYN", _manualYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@ManualYN", DBNull.Value );
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
			// Pass the value of '_peritonealDialysisService' as parameter 'PeritonealDialysisService' of the stored procedure.
			if(_peritonealDialysisServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", _peritonealDialysisServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@PeritonealDialysisService", DBNull.Value );
			// Pass the value of '_transplanationService' as parameter 'TransplanationService' of the stored procedure.
			if(_transplanationServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@TransplanationService", _transplanationServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@TransplanationService", DBNull.Value );
			// Pass the value of '_homeTrainingService' as parameter 'HomeTrainingService' of the stored procedure.
			if(_homeTrainingServiceNonDefault!=null)
              oDatabaseHelper.AddParameter("@HomeTrainingService", _homeTrainingServiceNonDefault);
            else
              oDatabaseHelper.AddParameter("@HomeTrainingService", DBNull.Value );
			// Pass the value of '_emergencyPrepReportRequired' as parameter 'EmergencyPrepReportRequired' of the stored procedure.
			if(_emergencyPrepReportRequiredNonDefault!=null)
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", _emergencyPrepReportRequiredNonDefault);
            else
              oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", DBNull.Value );
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
			// Pass the value of '_relatedProviderLicensureNum' as parameter 'RelatedProviderLicensureNum' of the stored procedure.
			if(_relatedProviderLicensureNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", _relatedProviderLicensureNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", DBNull.Value );
			// Pass the value of '_accreditedBody' as parameter 'AccreditedBody' of the stored procedure.
			if(_accreditedBodyNonDefault!=null)
              oDatabaseHelper.AddParameter("@AccreditedBody", _accreditedBodyNonDefault);
            else
              oDatabaseHelper.AddParameter("@AccreditedBody", DBNull.Value );
			// Pass the value of '_licensureExpirationDate' as parameter 'LicensureExpirationDate' of the stored procedure.
			if(_licensureExpirationDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", _licensureExpirationDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicensureExpirationDate", DBNull.Value );
			// Pass the value of '_enrolledInMedicaidYN' as parameter 'EnrolledInMedicaidYN' of the stored procedure.
			if(_enrolledInMedicaidYNNonDefault!=null)
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", _enrolledInMedicaidYNNonDefault);
            else
              oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", DBNull.Value );
			// Pass the value of '_submissionDate' as parameter 'SubmissionDate' of the stored procedure.
			if(_submissionDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubmissionDate", _submissionDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubmissionDate", DBNull.Value );
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			if(_totalLicBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBeds", DBNull.Value );
			// Pass the value of '_statusComment' as parameter 'StatusComment' of the stored procedure.
			if(_statusCommentNonDefault!=null)
              oDatabaseHelper.AddParameter("@StatusComment", _statusCommentNonDefault);
            else
              oDatabaseHelper.AddParameter("@StatusComment", DBNull.Value );
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			if(_unitNonDefault!=null)
              oDatabaseHelper.AddParameter("@Unit", _unitNonDefault);
            else
              oDatabaseHelper.AddParameter("@Unit", DBNull.Value );
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			if(_typeTreatmentNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeTreatment", DBNull.Value );
			// Pass the value of '_changeAddressLocType' as parameter 'ChangeAddressLocType' of the stored procedure.
			if(_changeAddressLocTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeAddressLocType", _changeAddressLocTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeAddressLocType", DBNull.Value );
			// Pass the value of '_changeAddressLocID' as parameter 'ChangeAddressLocID' of the stored procedure.
			if(_changeAddressLocIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ChangeAddressLocID", _changeAddressLocIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ChangeAddressLocID", DBNull.Value );
			// Pass the value of '_keyPersonnelChange' as parameter 'KeyPersonnelChange' of the stored procedure.
			if(_keyPersonnelChangeNonDefault!=null)
              oDatabaseHelper.AddParameter("@KeyPersonnelChange", _keyPersonnelChangeNonDefault);
            else
              oDatabaseHelper.AddParameter("@KeyPersonnelChange", DBNull.Value );
			// Pass the value of '_proposedEffectiveDate' as parameter 'ProposedEffectiveDate' of the stored procedure.
			if(_proposedEffectiveDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProposedEffectiveDate", _proposedEffectiveDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProposedEffectiveDate", DBNull.Value );
			// Pass the value of '_applicationAction' as parameter 'ApplicationAction' of the stored procedure.
			if(_applicationActionNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationAction", _applicationActionNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationAction", DBNull.Value );
			// Pass the value of '_ageRangeFrom' as parameter 'AgeRangeFrom' of the stored procedure.
			if(_ageRangeFromNonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeFrom", _ageRangeFromNonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeFrom", DBNull.Value );
			// Pass the value of '_ageRangeTO' as parameter 'AgeRangeTO' of the stored procedure.
			if(_ageRangeTONonDefault!=null)
              oDatabaseHelper.AddParameter("@AgeRangeTO", _ageRangeTONonDefault);
            else
              oDatabaseHelper.AddParameter("@AgeRangeTO", DBNull.Value );
			// Pass the value of '_snf18beds' as parameter 'Snf18beds' of the stored procedure.
			if(_snf18bedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@Snf18beds", _snf18bedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@Snf18beds", DBNull.Value );
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
			// Pass the value of '_bedsCertified' as parameter 'BedsCertified' of the stored procedure.
			if(_bedsCertifiedNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsCertified", _bedsCertifiedNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsCertified", DBNull.Value );
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			if(_numberOfBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberOfBeds", DBNull.Value );
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			if(_otherBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBeds", DBNull.Value );
			// Pass the value of '_unitsNumTotal' as parameter 'UnitsNumTotal' of the stored procedure.
			if(_unitsNumTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumTotal", _unitsNumTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumTotal", DBNull.Value );
			// Pass the value of '_totalLicBedsTotal' as parameter 'TotalLicBedsTotal' of the stored procedure.
			if(_totalLicBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", _totalLicBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsTotal", DBNull.Value );
			// Pass the value of '_psychiatricBedsTotal' as parameter 'PsychiatricBedsTotal' of the stored procedure.
			if(_psychiatricBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", _psychiatricBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", DBNull.Value );
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
			// Pass the value of '_unitsNumOffsiteTotal' as parameter 'UnitsNumOffsiteTotal' of the stored procedure.
			if(_unitsNumOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", _unitsNumOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", DBNull.Value );
			// Pass the value of '_totalLicBedsOffsiteTotal' as parameter 'TotalLicBedsOffsiteTotal' of the stored procedure.
			if(_totalLicBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", _totalLicBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_psychiatricBedsOffsiteTotal' as parameter 'PsychiatricBedsOffsiteTotal' of the stored procedure.
			if(_psychiatricBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", _psychiatricBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", DBNull.Value );
			// Pass the value of '_rehabBedsOffsiteTotal' as parameter 'RehabBedsOffsiteTotal' of the stored procedure.
			if(_rehabBedsOffsiteTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", _rehabBedsOffsiteTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", DBNull.Value );
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
			// Pass the value of '_fcertBeds' as parameter 'FcertBeds' of the stored procedure.
			if(_fcertBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@FcertBeds", _fcertBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@FcertBeds", DBNull.Value );
			// Pass the value of '_otherBedsTotal' as parameter 'OtherBedsTotal' of the stored procedure.
			if(_otherBedsTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@OtherBedsTotal", _otherBedsTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@OtherBedsTotal", DBNull.Value );
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			if(_currentLicIssueDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentLicIssueDate", DBNull.Value );
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			if(_originalLicensureDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalLicensureDate", DBNull.Value );
			// Pass the value of '_licEffectiveDateOveride' as parameter 'LicEffectiveDateOveride' of the stored procedure.
			if(_licEffectiveDateOverideNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicEffectiveDateOveride", _licEffectiveDateOverideNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicEffectiveDateOveride", DBNull.Value );
			// Pass the value of '_licExpireDateOveride' as parameter 'LicExpireDateOveride' of the stored procedure.
			if(_licExpireDateOverideNonDefault!=null)
              oDatabaseHelper.AddParameter("@LicExpireDateOveride", _licExpireDateOverideNonDefault);
            else
              oDatabaseHelper.AddParameter("@LicExpireDateOveride", DBNull.Value );
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
			// Pass the value of '_capacityProvTotal' as parameter 'CapacityProvTotal' of the stored procedure.
			if(_capacityProvTotalNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityProvTotal", _capacityProvTotalNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityProvTotal", DBNull.Value );
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			if(_numActivePatientsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumActivePatients", DBNull.Value );
			// Pass the value of '_operationPrior2005' as parameter 'OperationPrior2005' of the stored procedure.
			if(_operationPrior2005NonDefault!=null)
              oDatabaseHelper.AddParameter("@OperationPrior2005", _operationPrior2005NonDefault);
            else
              oDatabaseHelper.AddParameter("@OperationPrior2005", DBNull.Value );
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
			if(_year2ReviewDateDueNonDefault!=null)
              oDatabaseHelper.AddParameter("@Year2ReviewDateDue", _year2ReviewDateDueNonDefault);
            else
              oDatabaseHelper.AddParameter("@Year2ReviewDateDue", DBNull.Value );
			// Pass the value of '_levelCode' as parameter 'LevelCode' of the stored procedure.
			if(_levelCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@LevelCode", _levelCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@LevelCode", DBNull.Value );
			// Pass the value of '_originalEnrollmentDate' as parameter 'OriginalEnrollmentDate' of the stored procedure.
			if(_originalEnrollmentDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", _originalEnrollmentDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATIONS_Insert", ref ExecutionState);
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
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_businessProcessID' as parameter 'BusinessProcessID' of the stored procedure.
			oDatabaseHelper.AddParameter("@BusinessProcessID", _businessProcessIDNonDefault );
            
			// Pass the value of '_stateID' as parameter 'StateID' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateID", _stateIDNonDefault );
            
			// Pass the value of '_programID' as parameter 'ProgramID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramID", _programIDNonDefault );
            
			// Pass the value of '_dateStarted' as parameter 'DateStarted' of the stored procedure.
			oDatabaseHelper.AddParameter("@DateStarted", _dateStartedNonDefault );
            
			// Pass the value of '_dateCompleted' as parameter 'DateCompleted' of the stored procedure.
			oDatabaseHelper.AddParameter("@DateCompleted", _dateCompletedNonDefault );
            
			// Pass the value of '_licensureEffectiveDate' as parameter 'LicensureEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureEffectiveDate", _licensureEffectiveDateNonDefault );
            
			// Pass the value of '_applicationStatus' as parameter 'ApplicationStatus' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationStatus", _applicationStatusNonDefault );
            
			// Pass the value of '_facilityName' as parameter 'FacilityName' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityName", _facilityNameNonDefault );
            
			// Pass the value of '_legalName' as parameter 'LegalName' of the stored procedure.
			oDatabaseHelper.AddParameter("@LegalName", _legalNameNonDefault );
            
			// Pass the value of '_stateCode' as parameter 'StateCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateCode", _stateCodeNonDefault );
            
			// Pass the value of '_parishCode' as parameter 'ParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ParishCode", _parishCodeNonDefault );
            
			// Pass the value of '_regionCode' as parameter 'RegionCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@RegionCode", _regionCodeNonDefault );
            
			// Pass the value of '_federalID' as parameter 'FederalID' of the stored procedure.
			oDatabaseHelper.AddParameter("@FederalID", _federalIDNonDefault );
            
			// Pass the value of '_licensureNum' as parameter 'LicensureNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureNum", _licensureNumNonDefault );
            
			// Pass the value of '_schoolID' as parameter 'SchoolID' of the stored procedure.
			oDatabaseHelper.AddParameter("@SchoolID", _schoolIDNonDefault );
            
			// Pass the value of '_emsParishCode' as parameter 'EmsParishCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmsParishCode", _emsParishCodeNonDefault );
            
			// Pass the value of '_regionalOffice' as parameter 'RegionalOffice' of the stored procedure.
			oDatabaseHelper.AddParameter("@RegionalOffice", _regionalOfficeNonDefault );
            
			// Pass the value of '_zoneNumCode' as parameter 'ZoneNumCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ZoneNumCode", _zoneNumCodeNonDefault );
            
			// Pass the value of '_telephoneNumber' as parameter 'TelephoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@TelephoneNumber", _telephoneNumberNonDefault );
            
			// Pass the value of '_contactName' as parameter 'ContactName' of the stored procedure.
			oDatabaseHelper.AddParameter("@ContactName", _contactNameNonDefault );
            
			// Pass the value of '_emergencyPhoneNumber' as parameter 'EmergencyPhoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmergencyPhoneNumber", _emergencyPhoneNumberNonDefault );
            
			// Pass the value of '_faxPhoneNumber' as parameter 'FaxPhoneNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@FaxPhoneNumber", _faxPhoneNumberNonDefault );
            
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
            
			// Pass the value of '_hoursMinutes' as parameter 'HoursMinutes' of the stored procedure.
			oDatabaseHelper.AddParameter("@HoursMinutes", _hoursMinutesNonDefault );
            
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
            
			// Pass the value of '_typeFacility' as parameter 'TypeFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility", _typeFacilityNonDefault );
            
			// Pass the value of '_typeFacility1' as parameter 'TypeFacility1' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility1", _typeFacility1NonDefault );
            
			// Pass the value of '_typeFacility2' as parameter 'TypeFacility2' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility2", _typeFacility2NonDefault );
            
			// Pass the value of '_typeFacility3' as parameter 'TypeFacility3' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility3", _typeFacility3NonDefault );
            
			// Pass the value of '_typeFacility4' as parameter 'TypeFacility4' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility4", _typeFacility4NonDefault );
            
			// Pass the value of '_typeFacility5' as parameter 'TypeFacility5' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility5", _typeFacility5NonDefault );
            
			// Pass the value of '_typeFacility6' as parameter 'TypeFacility6' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeFacility6", _typeFacility6NonDefault );
            
			// Pass the value of '_licensedSnfFacility' as parameter 'LicensedSnfFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensedSnfFacility", _licensedSnfFacilityNonDefault );
            
			// Pass the value of '_typeOfClients' as parameter 'TypeOfClients' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeOfClients", _typeOfClientsNonDefault );
            
			// Pass the value of '_jcahYN' as parameter 'JcahYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@JcahYN", _jcahYNNonDefault );
            
			// Pass the value of '_stateFireApprovalDate' as parameter 'StateFireApprovalDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@StateFireApprovalDate", _stateFireApprovalDateNonDefault );
            
			// Pass the value of '_ageRange' as parameter 'AgeRange' of the stored procedure.
			oDatabaseHelper.AddParameter("@AgeRange", _ageRangeNonDefault );
            
			// Pass the value of '_healthApprovalDate' as parameter 'HealthApprovalDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@HealthApprovalDate", _healthApprovalDateNonDefault );
            
			// Pass the value of '_curSurv' as parameter 'CurSurv' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurSurv", _curSurvNonDefault );
            
			// Pass the value of '_hospitalBasedYN' as parameter 'HospitalBasedYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@HospitalBasedYN", _hospitalBasedYNNonDefault );
            
			// Pass the value of '_applicationDate' as parameter 'ApplicationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationDate", _applicationDateNonDefault );
            
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
            
			// Pass the value of '_isolationUnitYN' as parameter 'IsolationUnitYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@IsolationUnitYN", _isolationUnitYNNonDefault );
            
			// Pass the value of '_statusCode' as parameter 'StatusCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusCode", _statusCodeNonDefault );
            
			// Pass the value of '_statusDate' as parameter 'StatusDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusDate", _statusDateNonDefault );
            
			// Pass the value of '_noOfParishesServed' as parameter 'NoOfParishesServed' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfParishesServed", _noOfParishesServedNonDefault );
            
			// Pass the value of '_licensureSurveyDate' as parameter 'LicensureSurveyDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureSurveyDate", _licensureSurveyDateNonDefault );
            
			// Pass the value of '_waivers' as parameter 'Waivers' of the stored procedure.
			oDatabaseHelper.AddParameter("@Waivers", _waiversNonDefault );
            
			// Pass the value of '_userLastMaint' as parameter 'UserLastMaint' of the stored procedure.
			oDatabaseHelper.AddParameter("@UserLastMaint", _userLastMaintNonDefault );
            
			// Pass the value of '_dateLastMaint' as parameter 'DateLastMaint' of the stored procedure.
			oDatabaseHelper.AddParameter("@DateLastMaint", _dateLastMaintNonDefault );
            
			// Pass the value of '_timeLastMaint' as parameter 'TimeLastMaint' of the stored procedure.
			oDatabaseHelper.AddParameter("@TimeLastMaint", _timeLastMaintNonDefault );
            
			// Pass the value of '_offsiteCampusYN' as parameter 'OffsiteCampusYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@OffsiteCampusYN", _offsiteCampusYNNonDefault );
            
			// Pass the value of '_deemedStatus' as parameter 'DeemedStatus' of the stored procedure.
			oDatabaseHelper.AddParameter("@DeemedStatus", _deemedStatusNonDefault );
            
			// Pass the value of '_chapAccreditionYN' as parameter 'ChapAccreditionYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChapAccreditionYN", _chapAccreditionYNNonDefault );
            
			// Pass the value of '_fiscalIntermediaryNum' as parameter 'FiscalIntermediaryNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@FiscalIntermediaryNum", _fiscalIntermediaryNumNonDefault );
            
			// Pass the value of '_fiscalIntermediaryDesc' as parameter 'FiscalIntermediaryDesc' of the stored procedure.
			oDatabaseHelper.AddParameter("@FiscalIntermediaryDesc", _fiscalIntermediaryDescNonDefault );
            
			// Pass the value of '_noTreatmentsPerWeek' as parameter 'NoTreatmentsPerWeek' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoTreatmentsPerWeek", _noTreatmentsPerWeekNonDefault );
            
			// Pass the value of '_noOfStations' as parameter 'NoOfStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOfStations", _noOfStationsNonDefault );
            
			// Pass the value of '_noOf3hrShiftsWeek' as parameter 'NoOf3hrShiftsWeek' of the stored procedure.
			oDatabaseHelper.AddParameter("@NoOf3hrShiftsWeek", _noOf3hrShiftsWeekNonDefault );
            
			// Pass the value of '_averageNumPatientsShift' as parameter 'AverageNumPatientsShift' of the stored procedure.
			oDatabaseHelper.AddParameter("@AverageNumPatientsShift", _averageNumPatientsShiftNonDefault );
            
			// Pass the value of '_vendorNum' as parameter 'VendorNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@VendorNum", _vendorNumNonDefault );
            
			// Pass the value of '_waiverCode' as parameter 'WaiverCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode", _waiverCodeNonDefault );
            
			// Pass the value of '_waiverCode2' as parameter 'WaiverCode2' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode2", _waiverCode2NonDefault );
            
			// Pass the value of '_waiverCode3' as parameter 'WaiverCode3' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode3", _waiverCode3NonDefault );
            
			// Pass the value of '_waiverCode4' as parameter 'WaiverCode4' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode4", _waiverCode4NonDefault );
            
			// Pass the value of '_waiverCode5' as parameter 'WaiverCode5' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode5", _waiverCode5NonDefault );
            
			// Pass the value of '_waiverCode6' as parameter 'WaiverCode6' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode6", _waiverCode6NonDefault );
            
			// Pass the value of '_waiverCode7' as parameter 'WaiverCode7' of the stored procedure.
			oDatabaseHelper.AddParameter("@WaiverCode7", _waiverCode7NonDefault );
            
			// Pass the value of '_accreditationExpirationDate' as parameter 'AccreditationExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AccreditationExpirationDate", _accreditationExpirationDateNonDefault );
            
			// Pass the value of '_facilityWithinFacility' as parameter 'FacilityWithinFacility' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityWithinFacility", _facilityWithinFacilityNonDefault );
            
			// Pass the value of '_facilityTypeCode' as parameter 'FacilityTypeCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityTypeCode", _facilityTypeCodeNonDefault );
            
			// Pass the value of '_transplantYN' as parameter 'TransplantYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransplantYN", _transplantYNNonDefault );
            
			// Pass the value of '_enrolledRhcOffsiteYN' as parameter 'EnrolledRhcOffsiteYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@EnrolledRhcOffsiteYN", _enrolledRhcOffsiteYNNonDefault );
            
			// Pass the value of '_facilityWithinFacilityYN' as parameter 'FacilityWithinFacilityYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@FacilityWithinFacilityYN", _facilityWithinFacilityYNNonDefault );
            
			// Pass the value of '_certifiedBedOverrideYN' as parameter 'CertifiedBedOverrideYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@CertifiedBedOverrideYN", _certifiedBedOverrideYNNonDefault );
            
			// Pass the value of '_forYearEndingDate' as parameter 'ForYearEndingDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ForYearEndingDate", _forYearEndingDateNonDefault );
            
			// Pass the value of '_servicesOffered' as parameter 'ServicesOffered' of the stored procedure.
			oDatabaseHelper.AddParameter("@ServicesOffered", _servicesOfferedNonDefault );
            
			// Pass the value of '_halfwayHouse' as parameter 'HalfwayHouse' of the stored procedure.
			oDatabaseHelper.AddParameter("@HalfwayHouse", _halfwayHouseNonDefault );
            
			// Pass the value of '_inPatient' as parameter 'InPatient' of the stored procedure.
			oDatabaseHelper.AddParameter("@InPatient", _inPatientNonDefault );
            
			// Pass the value of '_crisisEmergency' as parameter 'CrisisEmergency' of the stored procedure.
			oDatabaseHelper.AddParameter("@CrisisEmergency", _crisisEmergencyNonDefault );
            
			// Pass the value of '_outpatientTreatment' as parameter 'OutpatientTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@OutpatientTreatment", _outpatientTreatmentNonDefault );
            
			// Pass the value of '_methadoneTreatment' as parameter 'MethadoneTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@MethadoneTreatment", _methadoneTreatmentNonDefault );
            
			// Pass the value of '_preventionEducation' as parameter 'PreventionEducation' of the stored procedure.
			oDatabaseHelper.AddParameter("@PreventionEducation", _preventionEducationNonDefault );
            
			// Pass the value of '_residentialTreatment' as parameter 'ResidentialTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@ResidentialTreatment", _residentialTreatmentNonDefault );
            
			// Pass the value of '_socialSettingDetoxification' as parameter 'SocialSettingDetoxification' of the stored procedure.
			oDatabaseHelper.AddParameter("@SocialSettingDetoxification", _socialSettingDetoxificationNonDefault );
            
			// Pass the value of '_adultHealthCare' as parameter 'AdultHealthCare' of the stored procedure.
			oDatabaseHelper.AddParameter("@AdultHealthCare", _adultHealthCareNonDefault );
            
			// Pass the value of '_cnatTrainingCode' as parameter 'CnatTrainingCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@CnatTrainingCode", _cnatTrainingCodeNonDefault );
            
			// Pass the value of '_cnatTrainingSuspendDate' as parameter 'CnatTrainingSuspendDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CnatTrainingSuspendDate", _cnatTrainingSuspendDateNonDefault );
            
			// Pass the value of '_assistDirOfNursingWaiverMonth' as parameter 'AssistDirOfNursingWaiverMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@AssistDirOfNursingWaiverMonth", _assistDirOfNursingWaiverMonthNonDefault );
            
			// Pass the value of '_day7RnWaiverMonth' as parameter 'Day7RnWaiverMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@Day7RnWaiverMonth", _day7RnWaiverMonthNonDefault );
            
			// Pass the value of '_currentSurveyMonth' as parameter 'CurrentSurveyMonth' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentSurveyMonth", _currentSurveyMonthNonDefault );
            
			// Pass the value of '_medicareInterPrefCode' as parameter 'MedicareInterPrefCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@MedicareInterPrefCode", _medicareInterPrefCodeNonDefault );
            
			// Pass the value of '_programCode' as parameter 'ProgramCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProgramCode", _programCodeNonDefault );
            
			// Pass the value of '_levelDescription' as parameter 'LevelDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@LevelDescription", _levelDescriptionNonDefault );
            
			// Pass the value of '_automaticCancellationDate' as parameter 'AutomaticCancellationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomaticCancellationDate", _automaticCancellationDateNonDefault );
            
			// Pass the value of '_numOfPatientsFollowedAtHome' as parameter 'NumOfPatientsFollowedAtHome' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumOfPatientsFollowedAtHome", _numOfPatientsFollowedAtHomeNonDefault );
            
			// Pass the value of '_automobileInsurancePrepaymentDueDate' as parameter 'AutomobileInsurancePrepaymentDueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@AutomobileInsurancePrepaymentDueDate", _automobileInsurancePrepaymentDueDateNonDefault );
            
			// Pass the value of '_generalLiabilityPrepaymentDueDate' as parameter 'GeneralLiabilityPrepaymentDueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@GeneralLiabilityPrepaymentDueDate", _generalLiabilityPrepaymentDueDateNonDefault );
            
			// Pass the value of '_overrideCapacity' as parameter 'OverrideCapacity' of the stored procedure.
			oDatabaseHelper.AddParameter("@OverrideCapacity", _overrideCapacityNonDefault );
            
			// Pass the value of '_rnCoordinator' as parameter 'RnCoordinator' of the stored procedure.
			oDatabaseHelper.AddParameter("@RnCoordinator", _rnCoordinatorNonDefault );
            
			// Pass the value of '_directorName' as parameter 'DirectorName' of the stored procedure.
			oDatabaseHelper.AddParameter("@DirectorName", _directorNameNonDefault );
            
			// Pass the value of '_year1ReviewDateDue' as parameter 'Year1ReviewDateDue' of the stored procedure.
			oDatabaseHelper.AddParameter("@Year1ReviewDateDue", _year1ReviewDateDueNonDefault );
            
			// Pass the value of '_totalNumDialysisPatients' as parameter 'TotalNumDialysisPatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalNumDialysisPatients", _totalNumDialysisPatientsNonDefault );
            
			// Pass the value of '_hemodialysisNumPatients' as parameter 'HemodialysisNumPatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisNumPatients", _hemodialysisNumPatientsNonDefault );
            
			// Pass the value of '_numOfPeritonealDialysisPatients' as parameter 'NumOfPeritonealDialysisPatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumOfPeritonealDialysisPatients", _numOfPeritonealDialysisPatientsNonDefault );
            
			// Pass the value of '_hemodialysisNumOfStations' as parameter 'HemodialysisNumOfStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisNumOfStations", _hemodialysisNumOfStationsNonDefault );
            
			// Pass the value of '_hemodialysisTrainingNumOfStation' as parameter 'HemodialysisTrainingNumOfStation' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisTrainingNumOfStation", _hemodialysisTrainingNumOfStationNonDefault );
            
			// Pass the value of '_totalNumStations' as parameter 'TotalNumStations' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalNumStations", _totalNumStationsNonDefault );
            
			// Pass the value of '_reuseYN' as parameter 'ReuseYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ReuseYN", _reuseYNNonDefault );
            
			// Pass the value of '_manualYN' as parameter 'ManualYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@ManualYN", _manualYNNonDefault );
            
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
            
			// Pass the value of '_typeGermicideDescription' as parameter 'TypeGermicideDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeGermicideDescription", _typeGermicideDescriptionNonDefault );
            
			// Pass the value of '_hemodialysisService' as parameter 'HemodialysisService' of the stored procedure.
			oDatabaseHelper.AddParameter("@HemodialysisService", _hemodialysisServiceNonDefault );
            
			// Pass the value of '_peritonealDialysisService' as parameter 'PeritonealDialysisService' of the stored procedure.
			oDatabaseHelper.AddParameter("@PeritonealDialysisService", _peritonealDialysisServiceNonDefault );
            
			// Pass the value of '_transplanationService' as parameter 'TransplanationService' of the stored procedure.
			oDatabaseHelper.AddParameter("@TransplanationService", _transplanationServiceNonDefault );
            
			// Pass the value of '_homeTrainingService' as parameter 'HomeTrainingService' of the stored procedure.
			oDatabaseHelper.AddParameter("@HomeTrainingService", _homeTrainingServiceNonDefault );
            
			// Pass the value of '_emergencyPrepReportRequired' as parameter 'EmergencyPrepReportRequired' of the stored procedure.
			oDatabaseHelper.AddParameter("@EmergencyPrepReportRequired", _emergencyPrepReportRequiredNonDefault );
            
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
            
			// Pass the value of '_relatedProviderLicensureNum' as parameter 'RelatedProviderLicensureNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@RelatedProviderLicensureNum", _relatedProviderLicensureNumNonDefault );
            
			// Pass the value of '_accreditedBody' as parameter 'AccreditedBody' of the stored procedure.
			oDatabaseHelper.AddParameter("@AccreditedBody", _accreditedBodyNonDefault );
            
			// Pass the value of '_licensureExpirationDate' as parameter 'LicensureExpirationDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicensureExpirationDate", _licensureExpirationDateNonDefault );
            
			// Pass the value of '_enrolledInMedicaidYN' as parameter 'EnrolledInMedicaidYN' of the stored procedure.
			oDatabaseHelper.AddParameter("@EnrolledInMedicaidYN", _enrolledInMedicaidYNNonDefault );
            
			// Pass the value of '_submissionDate' as parameter 'SubmissionDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@SubmissionDate", _submissionDateNonDefault );
            
			// Pass the value of '_totalLicBeds' as parameter 'TotalLicBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBeds", _totalLicBedsNonDefault );
            
			// Pass the value of '_statusComment' as parameter 'StatusComment' of the stored procedure.
			oDatabaseHelper.AddParameter("@StatusComment", _statusCommentNonDefault );
            
			// Pass the value of '_unit' as parameter 'Unit' of the stored procedure.
			oDatabaseHelper.AddParameter("@Unit", _unitNonDefault );
            
			// Pass the value of '_typeTreatment' as parameter 'TypeTreatment' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeTreatment", _typeTreatmentNonDefault );
            
			// Pass the value of '_changeAddressLocType' as parameter 'ChangeAddressLocType' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeAddressLocType", _changeAddressLocTypeNonDefault );
            
			// Pass the value of '_changeAddressLocID' as parameter 'ChangeAddressLocID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ChangeAddressLocID", _changeAddressLocIDNonDefault );
            
			// Pass the value of '_keyPersonnelChange' as parameter 'KeyPersonnelChange' of the stored procedure.
			oDatabaseHelper.AddParameter("@KeyPersonnelChange", _keyPersonnelChangeNonDefault );
            
			// Pass the value of '_proposedEffectiveDate' as parameter 'ProposedEffectiveDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProposedEffectiveDate", _proposedEffectiveDateNonDefault );
            
			// Pass the value of '_applicationAction' as parameter 'ApplicationAction' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationAction", _applicationActionNonDefault );
            
			// Pass the value of '_ageRangeFrom' as parameter 'AgeRangeFrom' of the stored procedure.
			oDatabaseHelper.AddParameter("@AgeRangeFrom", _ageRangeFromNonDefault );
            
			// Pass the value of '_ageRangeTO' as parameter 'AgeRangeTO' of the stored procedure.
			oDatabaseHelper.AddParameter("@AgeRangeTO", _ageRangeTONonDefault );
            
			// Pass the value of '_snf18beds' as parameter 'Snf18beds' of the stored procedure.
			oDatabaseHelper.AddParameter("@Snf18beds", _snf18bedsNonDefault );
            
			// Pass the value of '_snf1819beds' as parameter 'Snf1819beds' of the stored procedure.
			oDatabaseHelper.AddParameter("@Snf1819beds", _snf1819bedsNonDefault );
            
			// Pass the value of '_snf19beds' as parameter 'Snf19beds' of the stored procedure.
			oDatabaseHelper.AddParameter("@Snf19beds", _snf19bedsNonDefault );
            
			// Pass the value of '_psychiatricBeds' as parameter 'PsychiatricBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBeds", _psychiatricBedsNonDefault );
            
			// Pass the value of '_snfBeds' as parameter 'SnfBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBeds", _snfBedsNonDefault );
            
			// Pass the value of '_swingBeds' as parameter 'SwingBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@SwingBeds", _swingBedsNonDefault );
            
			// Pass the value of '_rehabilitationBeds' as parameter 'RehabilitationBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabilitationBeds", _rehabilitationBedsNonDefault );
            
			// Pass the value of '_bedsCertified' as parameter 'BedsCertified' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsCertified", _bedsCertifiedNonDefault );
            
			// Pass the value of '_numberOfBeds' as parameter 'NumberOfBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumberOfBeds", _numberOfBedsNonDefault );
            
			// Pass the value of '_otherBeds' as parameter 'OtherBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherBeds", _otherBedsNonDefault );
            
			// Pass the value of '_unitsNumTotal' as parameter 'UnitsNumTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@UnitsNumTotal", _unitsNumTotalNonDefault );
            
			// Pass the value of '_totalLicBedsTotal' as parameter 'TotalLicBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBedsTotal", _totalLicBedsTotalNonDefault );
            
			// Pass the value of '_psychiatricBedsTotal' as parameter 'PsychiatricBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBedsTotal", _psychiatricBedsTotalNonDefault );
            
			// Pass the value of '_rehabilitationBedsTotal' as parameter 'RehabilitationBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabilitationBedsTotal", _rehabilitationBedsTotalNonDefault );
            
			// Pass the value of '_snfBedsTotal' as parameter 'SnfBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBedsTotal", _snfBedsTotalNonDefault );
            
			// Pass the value of '_unitsNumOffsiteTotal' as parameter 'UnitsNumOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@UnitsNumOffsiteTotal", _unitsNumOffsiteTotalNonDefault );
            
			// Pass the value of '_totalLicBedsOffsiteTotal' as parameter 'TotalLicBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalLicBedsOffsiteTotal", _totalLicBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_psychiatricBedsOffsiteTotal' as parameter 'PsychiatricBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@PsychiatricBedsOffsiteTotal", _psychiatricBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_rehabBedsOffsiteTotal' as parameter 'RehabBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@RehabBedsOffsiteTotal", _rehabBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_snfBedsOffsiteTotal' as parameter 'SnfBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@SnfBedsOffsiteTotal", _snfBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_otherBedsOffsiteTotal' as parameter 'OtherBedsOffsiteTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherBedsOffsiteTotal", _otherBedsOffsiteTotalNonDefault );
            
			// Pass the value of '_fcertBeds' as parameter 'FcertBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@FcertBeds", _fcertBedsNonDefault );
            
			// Pass the value of '_otherBedsTotal' as parameter 'OtherBedsTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@OtherBedsTotal", _otherBedsTotalNonDefault );
            
			// Pass the value of '_currentLicIssueDate' as parameter 'CurrentLicIssueDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentLicIssueDate", _currentLicIssueDateNonDefault );
            
			// Pass the value of '_originalLicensureDate' as parameter 'OriginalLicensureDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OriginalLicensureDate", _originalLicensureDateNonDefault );
            
			// Pass the value of '_licEffectiveDateOveride' as parameter 'LicEffectiveDateOveride' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicEffectiveDateOveride", _licEffectiveDateOverideNonDefault );
            
			// Pass the value of '_licExpireDateOveride' as parameter 'LicExpireDateOveride' of the stored procedure.
			oDatabaseHelper.AddParameter("@LicExpireDateOveride", _licExpireDateOverideNonDefault );
            
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault );
            
			// Pass the value of '_capacityProvTotal' as parameter 'CapacityProvTotal' of the stored procedure.
			oDatabaseHelper.AddParameter("@CapacityProvTotal", _capacityProvTotalNonDefault );
            
			// Pass the value of '_numActivePatients' as parameter 'NumActivePatients' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumActivePatients", _numActivePatientsNonDefault );
            
			// Pass the value of '_operationPrior2005' as parameter 'OperationPrior2005' of the stored procedure.
			oDatabaseHelper.AddParameter("@OperationPrior2005", _operationPrior2005NonDefault );
            
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
			oDatabaseHelper.AddParameter("@Year2ReviewDateDue", _year2ReviewDateDueNonDefault );
            
			// Pass the value of '_levelCode' as parameter 'LevelCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@LevelCode", _levelCodeNonDefault );
            
			// Pass the value of '_originalEnrollmentDate' as parameter 'OriginalEnrollmentDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OriginalEnrollmentDate", _originalEnrollmentDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATIONS_Update", ref ExecutionState);
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
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATIONS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ApplicationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ApplicationPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATIONS_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ApplicationFields">Field of the class BO_Application</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_APPLICATIONS_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ApplicationPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Application</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOne(BO_ApplicationPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Application obj=new BO_Application();	
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
		/// <returns>list of objects of class BO_Application in the form of object of BO_Applications </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Applications SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectAll", ref ExecutionState);
			BO_Applications BO_Applications = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Application</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Application in the form of an object of class BO_Applications</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Applications SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectByField", ref ExecutionState);
			BO_Applications BO_Applications = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Applications;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithADDRESSUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithADDRESSUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_AddressesApplicationID=BO_Address.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithAFFILIATIONUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithAFFILIATIONUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_AffiliationsApplicationID=BO_Affiliation.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithAPPLICATION_SUPPORTUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithAPPLICATION_SUPPORTUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ApplicationSupportsApplicationID=BO_ApplicationSupport.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithAPPLICATION_ITEMSUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithAPPLICATION_ITEMSUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ApplicationItemsApplicationID=BO_ApplicationItem.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithBILLINGUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithBILLINGUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_BillingsApplicationID=BO_Billing.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithCAPACITIESUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithCAPACITIESUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_CapacitiesApplicationID=BO_Capacity.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithLETTER_OF_INTENTUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithLETTER_OF_INTENTUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LetterOfIntentsApplicationID=BO_LetterOfIntent.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithLICENSEUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithLICENSEUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LicensesApplicationID=BO_License.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithMESSAGESUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithMESSAGESUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_MessagesApplicationID=BO_Message.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithOWNERSHIPUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithOWNERSHIPUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_OwnershipsApplicationID=BO_Ownership.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithPROVIDER_PERSONUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithPROVIDER_PERSONUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ProviderPeopleApplicationID=BO_ProviderPerson.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithSERVICEUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithSERVICEUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_ServicesApplicationID=BO_Service.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithSPECIALTY_UNITUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithSPECIALTY_UNITUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_SpecialtyUnitsApplicationID=BO_SpecialtyUnit.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithSTAFFINGUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithSTAFFINGUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_StaffingsApplicationID=BO_Staffing.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithSTATUS_HISTORYUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithSTATUS_HISTORYUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_StatusHistoriesApplicationID=BO_StatusHistory.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class APPLICATIONS</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Application SelectOneWithLETTERS_QUEUEUsingApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Application obj=null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectOneWithLETTERS_QUEUEUsingApplicationID", ref ExecutionState);
			if (dr.Read())
			{
				obj= new BO_Application();
				PopulateObjectFromReader(obj,dr);
				
				dr.NextResult();
				
				//Get the child records.
				obj.BO_LettersQueuesApplicationID=BO_LettersQueue.PopulateObjectsFromReader(dr);
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
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Applications</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Applications SelectAllByForeignKeyBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Applications obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectAllByForeignKeyBusinessProcessID", ref ExecutionState);
			obj = new BO_Applications();
			obj = BO_Application.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="BUSINESS_PROCESSESPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyBusinessProcessID(BO_BusinessProcessePrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_APPLICATIONS_DeleteAllByForeignKeyBusinessProcessID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Applications</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Applications SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Applications obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Applications();
			obj = BO_Application.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_APPLICATIONS_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
		/// <returns>object of class BO_Applications</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Applications SelectAllByForeignKeyProgramID(BO_ProgramPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Applications obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_APPLICATIONS_SelectAllByForeignKeyProgramID", ref ExecutionState);
			obj = new BO_Applications();
			obj = BO_Application.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/15/2017 2:04:59 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_APPLICATIONS_DeleteAllByForeignKeyProgramID", ref ExecutionState);
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
	    /// DLGenerator			06/15/2017 2:04:59 PM		Created function
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
		/// <param name="obj" type="APPLICATIONS">Object of APPLICATIONS to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ApplicationBase obj,IDataReader rdr) 
		{

			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.ApplicationID)));
			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ApplicationFields.PopsIntID)));
			obj.BusinessProcessID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.BusinessProcessID));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StateID)))
			{
				obj.StateID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StateID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ProgramID)))
			{
				obj.ProgramID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ProgramID));
			}
			
			obj.DateStarted = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.DateStarted));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DateCompleted)))
			{
				obj.DateCompleted = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.DateCompleted));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicensureEffectiveDate)))
			{
				obj.LicensureEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.LicensureEffectiveDate));
			}
			
			obj.ApplicationStatus = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ApplicationStatus));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FacilityName)))
			{
				obj.FacilityName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FacilityName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LegalName)))
			{
				obj.LegalName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LegalName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StateCode)))
			{
				obj.StateCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StateCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ParishCode)))
			{
				obj.ParishCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ParishCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RegionCode)))
			{
				obj.RegionCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.RegionCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FederalID)))
			{
				obj.FederalID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FederalID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicensureNum)))
			{
				obj.LicensureNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LicensureNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SchoolID)))
			{
				obj.SchoolID = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.SchoolID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.EmsParishCode)))
			{
				obj.EmsParishCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.EmsParishCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RegionalOffice)))
			{
				obj.RegionalOffice = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.RegionalOffice));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ZoneNumCode)))
			{
				obj.ZoneNumCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ZoneNumCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TelephoneNumber)))
			{
				obj.TelephoneNumber = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TelephoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ContactName)))
			{
				obj.ContactName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ContactName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.EmergencyPhoneNumber)))
			{
				obj.EmergencyPhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.EmergencyPhoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FaxPhoneNumber)))
			{
				obj.FaxPhoneNumber = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FaxPhoneNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StateIdMds)))
			{
				obj.StateIdMds = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StateIdMds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StateLicNum)))
			{
				obj.StateLicNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StateLicNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.EmailAddress)))
			{
				obj.EmailAddress = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.EmailAddress));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.MedicaidVendorNumber)))
			{
				obj.MedicaidVendorNumber = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.MedicaidVendorNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FieldOfficeCode)))
			{
				obj.FieldOfficeCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FieldOfficeCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HoursMinutes)))
			{
				obj.HoursMinutes = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HoursMinutes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AmPM)))
			{
				obj.AmPM = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AmPM));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HoursMinutes1)))
			{
				obj.HoursMinutes1 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HoursMinutes1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AmPm1)))
			{
				obj.AmPm1 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AmPm1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationMon)))
			{
				obj.DayOfOperationMon = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationMon));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationTue)))
			{
				obj.DayOfOperationTue = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationTue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationWed)))
			{
				obj.DayOfOperationWed = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationWed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationThu)))
			{
				obj.DayOfOperationThu = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationThu));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationFri)))
			{
				obj.DayOfOperationFri = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationFri));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationSat)))
			{
				obj.DayOfOperationSat = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationSat));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationSun)))
			{
				obj.DayOfOperationSun = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DayOfOperationSun));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeLicenseCode)))
			{
				obj.TypeLicenseCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeLicenseCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeOfLicense)))
			{
				obj.TypeOfLicense = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeOfLicense));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility)))
			{
				obj.TypeFacility = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility1)))
			{
				obj.TypeFacility1 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility1));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility2)))
			{
				obj.TypeFacility2 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility3)))
			{
				obj.TypeFacility3 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility3));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility4)))
			{
				obj.TypeFacility4 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility4));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility5)))
			{
				obj.TypeFacility5 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility5));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility6)))
			{
				obj.TypeFacility6 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeFacility6));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicensedSnfFacility)))
			{
				obj.LicensedSnfFacility = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LicensedSnfFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeOfClients)))
			{
				obj.TypeOfClients = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeOfClients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.JcahYN)))
			{
				obj.JcahYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.JcahYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StateFireApprovalDate)))
			{
				obj.StateFireApprovalDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.StateFireApprovalDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AgeRange)))
			{
				obj.AgeRange = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AgeRange));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HealthApprovalDate)))
			{
				obj.HealthApprovalDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.HealthApprovalDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CurSurv)))
			{
				obj.CurSurv = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.CurSurv));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HospitalBasedYN)))
			{
				obj.HospitalBasedYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HospitalBasedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ApplicationDate)))
			{
				obj.ApplicationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ApplicationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.UsDeaRegNum)))
			{
				obj.UsDeaRegNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.UsDeaRegNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.UsDeaRegNumExpDate)))
			{
				obj.UsDeaRegNumExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.UsDeaRegNumExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LaCdsNum)))
			{
				obj.LaCdsNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LaCdsNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LaCdsNumExpDate)))
			{
				obj.LaCdsNumExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.LaCdsNumExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CliaIdNum)))
			{
				obj.CliaIdNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.CliaIdNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CliaExpDate)))
			{
				obj.CliaExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.CliaExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfAirAmbulances)))
			{
				obj.NoOfAirAmbulances = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfAirAmbulances));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfGroundAmbulances)))
			{
				obj.NoOfGroundAmbulances = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfGroundAmbulances));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfSprintVehicles)))
			{
				obj.NoOfSprintVehicles = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfSprintVehicles));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfAmbulatoryVehicles)))
			{
				obj.NoOfAmbulatoryVehicles = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfAmbulatoryVehicles));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalDailyCapacityAmbulatoryVehicle)))
			{
				obj.TotalDailyCapacityAmbulatoryVehicle = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TotalDailyCapacityAmbulatoryVehicle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfHandicappedVehicles)))
			{
				obj.NoOfHandicappedVehicles = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfHandicappedVehicles));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalDailyCapacityHandicappedVehicle)))
			{
				obj.TotalDailyCapacityHandicappedVehicle = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TotalDailyCapacityHandicappedVehicle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.IsolationUnitYN)))
			{
				obj.IsolationUnitYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.IsolationUnitYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StatusCode)))
			{
				obj.StatusCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StatusCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StatusDate)))
			{
				obj.StatusDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.StatusDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfParishesServed)))
			{
				obj.NoOfParishesServed = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfParishesServed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicensureSurveyDate)))
			{
				obj.LicensureSurveyDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.LicensureSurveyDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Waivers)))
			{
				obj.Waivers = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.Waivers));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.UserLastMaint)))
			{
				obj.UserLastMaint = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.UserLastMaint));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DateLastMaint)))
			{
				obj.DateLastMaint = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.DateLastMaint));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TimeLastMaint)))
			{
				obj.TimeLastMaint = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TimeLastMaint));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OffsiteCampusYN)))
			{
				obj.OffsiteCampusYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.OffsiteCampusYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DeemedStatus)))
			{
				obj.DeemedStatus = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DeemedStatus));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChapAccreditionYN)))
			{
				obj.ChapAccreditionYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ChapAccreditionYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FiscalIntermediaryNum)))
			{
				obj.FiscalIntermediaryNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FiscalIntermediaryNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FiscalIntermediaryDesc)))
			{
				obj.FiscalIntermediaryDesc = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FiscalIntermediaryDesc));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoTreatmentsPerWeek)))
			{
				obj.NoTreatmentsPerWeek = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoTreatmentsPerWeek));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOfStations)))
			{
				obj.NoOfStations = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOfStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NoOf3hrShiftsWeek)))
			{
				obj.NoOf3hrShiftsWeek = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NoOf3hrShiftsWeek));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AverageNumPatientsShift)))
			{
				obj.AverageNumPatientsShift = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AverageNumPatientsShift));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.VendorNum)))
			{
				obj.VendorNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.VendorNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode)))
			{
				obj.WaiverCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode2)))
			{
				obj.WaiverCode2 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode2));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode3)))
			{
				obj.WaiverCode3 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode3));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode4)))
			{
				obj.WaiverCode4 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode4));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode5)))
			{
				obj.WaiverCode5 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode5));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode6)))
			{
				obj.WaiverCode6 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode6));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode7)))
			{
				obj.WaiverCode7 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.WaiverCode7));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AccreditationExpirationDate)))
			{
				obj.AccreditationExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.AccreditationExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FacilityWithinFacility)))
			{
				obj.FacilityWithinFacility = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FacilityWithinFacility));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FacilityTypeCode)))
			{
				obj.FacilityTypeCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FacilityTypeCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TransplantYN)))
			{
				obj.TransplantYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TransplantYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.EnrolledRhcOffsiteYN)))
			{
				obj.EnrolledRhcOffsiteYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.EnrolledRhcOffsiteYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FacilityWithinFacilityYN)))
			{
				obj.FacilityWithinFacilityYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FacilityWithinFacilityYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CertifiedBedOverrideYN)))
			{
				obj.CertifiedBedOverrideYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.CertifiedBedOverrideYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ForYearEndingDate)))
			{
				obj.ForYearEndingDate = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ForYearEndingDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ServicesOffered)))
			{
				obj.ServicesOffered = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ServicesOffered));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HalfwayHouse)))
			{
				obj.HalfwayHouse = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HalfwayHouse));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.InPatient)))
			{
				obj.InPatient = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.InPatient));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CrisisEmergency)))
			{
				obj.CrisisEmergency = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.CrisisEmergency));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OutpatientTreatment)))
			{
				obj.OutpatientTreatment = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.OutpatientTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.MethadoneTreatment)))
			{
				obj.MethadoneTreatment = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.MethadoneTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.PreventionEducation)))
			{
				obj.PreventionEducation = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.PreventionEducation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ResidentialTreatment)))
			{
				obj.ResidentialTreatment = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ResidentialTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SocialSettingDetoxification)))
			{
				obj.SocialSettingDetoxification = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.SocialSettingDetoxification));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AdultHealthCare)))
			{
				obj.AdultHealthCare = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AdultHealthCare));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CnatTrainingCode)))
			{
				obj.CnatTrainingCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.CnatTrainingCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CnatTrainingSuspendDate)))
			{
				obj.CnatTrainingSuspendDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.CnatTrainingSuspendDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AssistDirOfNursingWaiverMonth)))
			{
				obj.AssistDirOfNursingWaiverMonth = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AssistDirOfNursingWaiverMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Day7RnWaiverMonth)))
			{
				obj.Day7RnWaiverMonth = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.Day7RnWaiverMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CurrentSurveyMonth)))
			{
				obj.CurrentSurveyMonth = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.CurrentSurveyMonth));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.MedicareInterPrefCode)))
			{
				obj.MedicareInterPrefCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.MedicareInterPrefCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ProgramCode)))
			{
				obj.ProgramCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ProgramCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LevelDescription)))
			{
				obj.LevelDescription = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LevelDescription));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AutomaticCancellationDate)))
			{
				obj.AutomaticCancellationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.AutomaticCancellationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumOfPatientsFollowedAtHome)))
			{
				obj.NumOfPatientsFollowedAtHome = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumOfPatientsFollowedAtHome));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AutomobileInsurancePrepaymentDueDate)))
			{
				obj.AutomobileInsurancePrepaymentDueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.AutomobileInsurancePrepaymentDueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.GeneralLiabilityPrepaymentDueDate)))
			{
				obj.GeneralLiabilityPrepaymentDueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.GeneralLiabilityPrepaymentDueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OverrideCapacity)))
			{
				obj.OverrideCapacity = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.OverrideCapacity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RnCoordinator)))
			{
				obj.RnCoordinator = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.RnCoordinator));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.DirectorName)))
			{
				obj.DirectorName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.DirectorName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Year1ReviewDateDue)))
			{
				obj.Year1ReviewDateDue = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.Year1ReviewDateDue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalNumDialysisPatients)))
			{
				obj.TotalNumDialysisPatients = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TotalNumDialysisPatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisNumPatients)))
			{
				obj.HemodialysisNumPatients = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisNumPatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumOfPeritonealDialysisPatients)))
			{
				obj.NumOfPeritonealDialysisPatients = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.NumOfPeritonealDialysisPatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisNumOfStations)))
			{
				obj.HemodialysisNumOfStations = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisNumOfStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisTrainingNumOfStation)))
			{
				obj.HemodialysisTrainingNumOfStation = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisTrainingNumOfStation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalNumStations)))
			{
				obj.TotalNumStations = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TotalNumStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ReuseYN)))
			{
				obj.ReuseYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ReuseYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ManualYN)))
			{
				obj.ManualYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ManualYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SemiautomatedYN)))
			{
				obj.SemiautomatedYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.SemiautomatedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AutomatedYN)))
			{
				obj.AutomatedYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AutomatedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FormainGermicide)))
			{
				obj.FormainGermicide = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.FormainGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HeatGermicide)))
			{
				obj.HeatGermicide = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HeatGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.GluteraldetydeGermicide)))
			{
				obj.GluteraldetydeGermicide = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.GluteraldetydeGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.PeraceticAcidMixtureGerm)))
			{
				obj.PeraceticAcidMixtureGerm = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.PeraceticAcidMixtureGerm));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OtherGermicide)))
			{
				obj.OtherGermicide = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.OtherGermicide));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeGermicideDescription)))
			{
				obj.TypeGermicideDescription = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeGermicideDescription));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisService)))
			{
				obj.HemodialysisService = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HemodialysisService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.PeritonealDialysisService)))
			{
				obj.PeritonealDialysisService = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.PeritonealDialysisService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TransplanationService)))
			{
				obj.TransplanationService = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TransplanationService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.HomeTrainingService)))
			{
				obj.HomeTrainingService = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.HomeTrainingService));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.EmergencyPrepReportRequired)))
			{
				obj.EmergencyPrepReportRequired = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.EmergencyPrepReportRequired));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Initial)))
			{
				obj.Initial = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.Initial));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.InitialDate)))
			{
				obj.InitialDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.InitialDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ExpansionToNewLocation)))
			{
				obj.ExpansionToNewLocation = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ExpansionToNewLocation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ExpToNewLocationDate)))
			{
				obj.ExpToNewLocationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ExpToNewLocationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfOwnership)))
			{
				obj.ChangeOfOwnership = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfOwnership));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfLocation)))
			{
				obj.ChangeOfLocation = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfLocation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfLocationDate)))
			{
				obj.ChangeOfLocationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfLocationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ExpansionInCurrentLocation)))
			{
				obj.ExpansionInCurrentLocation = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ExpansionInCurrentLocation));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ExpansionInCurrentLocationDate)))
			{
				obj.ExpansionInCurrentLocationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ExpansionInCurrentLocationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfServices)))
			{
				obj.ChangeOfServices = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfServices));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfServicesDate)))
			{
				obj.ChangeOfServicesDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ChangeOfServicesDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeApplicationCode7)))
			{
				obj.TypeApplicationCode7 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeApplicationCode7));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeApplicationCode7Date)))
			{
				obj.TypeApplicationCode7Date = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.TypeApplicationCode7Date));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeApplicationDescr)))
			{
				obj.TypeApplicationDescr = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeApplicationDescr));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ProviderBasedYN)))
			{
				obj.ProviderBasedYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ProviderBasedYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RelatedProviderLicensureNum)))
			{
				obj.RelatedProviderLicensureNum = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.RelatedProviderLicensureNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AccreditedBody)))
			{
				obj.AccreditedBody = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AccreditedBody));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicensureExpirationDate)))
			{
				obj.LicensureExpirationDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.LicensureExpirationDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.EnrolledInMedicaidYN)))
			{
				obj.EnrolledInMedicaidYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.EnrolledInMedicaidYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SubmissionDate)))
			{
				obj.SubmissionDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.SubmissionDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalLicBeds)))
			{
				obj.TotalLicBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.TotalLicBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.StatusComment)))
			{
				obj.StatusComment = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.StatusComment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Unit)))
			{
				obj.Unit = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.Unit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TypeTreatment)))
			{
				obj.TypeTreatment = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.TypeTreatment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeAddressLocType)))
			{
				obj.ChangeAddressLocType = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ChangeAddressLocType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ChangeAddressLocID)))
			{
				obj.ChangeAddressLocID = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.ChangeAddressLocID));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.KeyPersonnelChange)))
			{
				obj.KeyPersonnelChange = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.KeyPersonnelChange));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ProposedEffectiveDate)))
			{
				obj.ProposedEffectiveDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ProposedEffectiveDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ApplicationAction)))
			{
				obj.ApplicationAction = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.ApplicationAction));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AgeRangeFrom)))
			{
				obj.AgeRangeFrom = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.AgeRangeFrom));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AgeRangeTO)))
			{
				obj.AgeRangeTO = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.AgeRangeTO));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Snf18beds)))
			{
				obj.Snf18beds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.Snf18beds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Snf1819beds)))
			{
				obj.Snf1819beds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.Snf1819beds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Snf19beds)))
			{
				obj.Snf19beds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.Snf19beds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.PsychiatricBeds)))
			{
				obj.PsychiatricBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.PsychiatricBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SnfBeds)))
			{
				obj.SnfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.SnfBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SwingBeds)))
			{
				obj.SwingBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.SwingBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RehabilitationBeds)))
			{
				obj.RehabilitationBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.RehabilitationBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.BedsCertified)))
			{
				obj.BedsCertified = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.BedsCertified));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumberOfBeds)))
			{
				obj.NumberOfBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumberOfBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OtherBeds)))
			{
				obj.OtherBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.OtherBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.UnitsNumTotal)))
			{
				obj.UnitsNumTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.UnitsNumTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalLicBedsTotal)))
			{
				obj.TotalLicBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.TotalLicBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.PsychiatricBedsTotal)))
			{
				obj.PsychiatricBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.PsychiatricBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RehabilitationBedsTotal)))
			{
				obj.RehabilitationBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.RehabilitationBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SnfBedsTotal)))
			{
				obj.SnfBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.SnfBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.UnitsNumOffsiteTotal)))
			{
				obj.UnitsNumOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.UnitsNumOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.TotalLicBedsOffsiteTotal)))
			{
				obj.TotalLicBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.TotalLicBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.PsychiatricBedsOffsiteTotal)))
			{
				obj.PsychiatricBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.PsychiatricBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RehabBedsOffsiteTotal)))
			{
				obj.RehabBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.RehabBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SnfBedsOffsiteTotal)))
			{
				obj.SnfBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.SnfBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OtherBedsOffsiteTotal)))
			{
				obj.OtherBedsOffsiteTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.OtherBedsOffsiteTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.FcertBeds)))
			{
				obj.FcertBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.FcertBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OtherBedsTotal)))
			{
				obj.OtherBedsTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.OtherBedsTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CurrentLicIssueDate)))
			{
				obj.CurrentLicIssueDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.CurrentLicIssueDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OriginalLicensureDate)))
			{
				obj.OriginalLicensureDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.OriginalLicensureDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicEffectiveDateOveride)))
			{
				obj.LicEffectiveDateOveride = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LicEffectiveDateOveride));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LicExpireDateOveride)))
			{
				obj.LicExpireDateOveride = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LicExpireDateOveride));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Capacity)))
			{
				obj.Capacity = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.Capacity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.CapacityProvTotal)))
			{
				obj.CapacityProvTotal = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.CapacityProvTotal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumActivePatients)))
			{
				obj.NumActivePatients = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumActivePatients));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OperationPrior2005)))
			{
				obj.OperationPrior2005 = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.OperationPrior2005));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechBsba)))
			{
				obj.NumRadiologicTechBsba = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechBsba));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechAS)))
			{
				obj.NumRadiologicTechAS = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechAS));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechCrt)))
			{
				obj.NumRadiologicTechCrt = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechCrt));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechOther)))
			{
				obj.NumRadiologicTechOther = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumRadiologicTechOther));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.IsolationNumOfStations)))
			{
				obj.IsolationNumOfStations = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.IsolationNumOfStations));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.RelatedProviderName)))
			{
				obj.RelatedProviderName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.RelatedProviderName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.NumOperatingRooms)))
			{
				obj.NumOperatingRooms = rdr.GetInt32(rdr.GetOrdinal(BO_ApplicationFields.NumOperatingRooms));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AdmMultiFacYN)))
			{
				obj.AdmMultiFacYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AdmMultiFacYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.AdmMultiFacOtherName)))
			{
				obj.AdmMultiFacOtherName = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.AdmMultiFacOtherName));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.SingleStoryYN)))
			{
				obj.SingleStoryYN = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.SingleStoryYN));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.ClosedDate)))
			{
				obj.ClosedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.ClosedDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.Year2ReviewDateDue)))
			{
				obj.Year2ReviewDateDue = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.Year2ReviewDateDue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.LevelCode)))
			{
				obj.LevelCode = rdr.GetString(rdr.GetOrdinal(BO_ApplicationFields.LevelCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ApplicationFields.OriginalEnrollmentDate)))
			{
				obj.OriginalEnrollmentDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ApplicationFields.OriginalEnrollmentDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Applications</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Applications PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Applications list = new BO_Applications();
			
			while (rdr.Read())
			{
				BO_Application obj = new BO_Application();
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
		/// <returns>Object of BO_Applications</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/15/2017 2:04:59 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Applications PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Applications list = new BO_Applications();
			
            if (rdr.Read())
            {
                BO_Application obj = new BO_Application();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Application();
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
