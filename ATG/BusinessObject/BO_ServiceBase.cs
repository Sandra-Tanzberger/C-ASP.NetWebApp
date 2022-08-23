//
// Class	:	BO_ServiceBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	12/08/2015 11:47:22 AM
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
	public class BO_ServiceFields
	{
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string ServiceID                 = "SERVICE_ID";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string AffiliationID             = "AFFILIATION_ID";
		public const string ServiceType               = "SERVICE_TYPE";
		public const string TypeServiceLicNum         = "TYPE_SERVICE_LIC_NUM";
		public const string TypeServiceOther          = "TYPE_SERVICE_OTHER";
		public const string FnrApprovalDate           = "FNR_APPROVAL_DATE";
		public const string Capacity                  = "CAPACITY";
		public const string DayOfOperationMon         = "DAY_OF_OPERATION_MON";
		public const string DayOfOperationTue         = "DAY_OF_OPERATION_TUE";
		public const string DayOfOperationWed         = "DAY_OF_OPERATION_WED";
		public const string DayOfOperationThu         = "DAY_OF_OPERATION_THU";
		public const string DayOfOperationFri         = "DAY_OF_OPERATION_FRI";
		public const string DayOfOperationSat         = "DAY_OF_OPERATION_SAT";
		public const string DayOfOperationSun         = "DAY_OF_OPERATION_SUN";
		public const string OperatingHoursFromTime    = "OPERATING_HOURS_FROM_TIME";
		public const string OperatingHoursFromMeridiem = "OPERATING_HOURS_FROM_MERIDIEM";
		public const string OperatingHoursToTime      = "OPERATING_HOURS_TO_TIME";
		public const string OperatingHoursToMeridiem  = "OPERATING_HOURS_TO_MERIDIEM";
		public const string OcddApprovedDate          = "OCDD_APPROVED_DATE";
		public const string IcfddLicenseNum           = "ICFDD_LICENSE_NUM";
		public const string IcfddLicenseExpDate       = "ICFDD_LICENSE_EXP_DATE";
		public const string FileAttachID              = "FILE_ATTACH_ID";
		public const string ServiceSubtypes           = "SERVICE_SUBTYPES";
		public const string Census                    = "CENSUS";
		public const string NumberBeds                = "NUMBER_BEDS";
		public const string NumberUnits               = "NUMBER_UNITS";
	}
	
	/// <summary>
	/// Data access class for the "SERVICE" table.
	/// </summary>
	[Serializable]
	public class BO_ServiceBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_serviceIDNonDefault     	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private decimal?       	_affiliationIDNonDefault 	= null;
		private string         	_serviceTypeNonDefault   	= null;
		private string         	_typeServiceLicNumNonDefault	= null;
		private string         	_typeServiceOtherNonDefault	= null;
		private DateTime?      	_fnrApprovalDateNonDefault	= null;
		private int?           	_capacityNonDefault      	= null;
		private string         	_dayOfOperationMonNonDefault	= null;
		private string         	_dayOfOperationTueNonDefault	= null;
		private string         	_dayOfOperationWedNonDefault	= null;
		private string         	_dayOfOperationThuNonDefault	= null;
		private string         	_dayOfOperationFriNonDefault	= null;
		private string         	_dayOfOperationSatNonDefault	= null;
		private string         	_dayOfOperationSunNonDefault	= null;
		private string         	_operatingHoursFromTimeNonDefault	= null;
		private string         	_operatingHoursFromMeridiemNonDefault	= null;
		private string         	_operatingHoursToTimeNonDefault	= null;
		private string         	_operatingHoursToMeridiemNonDefault	= null;
		private DateTime?      	_ocddApprovedDateNonDefault	= null;
		private string         	_icfddLicenseNumNonDefault	= null;
		private DateTime?      	_icfddLicenseExpDateNonDefault	= null;
		private decimal?       	_fileAttachIDNonDefault  	= null;
		private string         	_serviceSubtypesNonDefault	= null;
		private int?           	_censusNonDefault        	= null;
		private int?           	_numberBedsNonDefault    	= null;
		private int?           	_numberUnitsNonDefault   	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_ServiceBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
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
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? ServiceID
		{
			get 
			{ 
                return _serviceIDNonDefault;
			}
			set 
			{
            
                _serviceIDNonDefault = value; 
			}
		}

		/// <summary>
		/// Returns the identifier of the persistent object. Mandatory.
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
		public decimal? AffiliationID
		{
			get 
			{ 
                return _affiliationIDNonDefault;
			}
			set 
			{
            
                _affiliationIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SERVICE_TYPE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string ServiceType
		{
			get 
			{ 
                if(_serviceTypeNonDefault==null)return _serviceTypeNonDefault;
				else return _serviceTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("ServiceType length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _serviceTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _serviceTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_SERVICE_LIC_NUM" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string TypeServiceLicNum
		{
			get 
			{ 
                if(_typeServiceLicNumNonDefault==null)return _typeServiceLicNumNonDefault;
				else return _typeServiceLicNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("TypeServiceLicNum length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _typeServiceLicNumNonDefault =null;//null value 
                }
                else
                {		           
		            _typeServiceLicNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_SERVICE_OTHER" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string TypeServiceOther
		{
			get 
			{ 
                if(_typeServiceOtherNonDefault==null)return _typeServiceOtherNonDefault;
				else return _typeServiceOtherNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("TypeServiceOther length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _typeServiceOtherNonDefault =null;//null value 
                }
                else
                {		           
		            _typeServiceOtherNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FNR_APPROVAL_DATE" field.  
		/// </summary>
		public DateTime? FnrApprovalDate
		{
			get 
			{ 
                return _fnrApprovalDateNonDefault;
			}
			set 
			{
            
                _fnrApprovalDateNonDefault = value; 
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
		/// This property is mapped to the "OPERATING_HOURS_FROM_TIME" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string OperatingHoursFromTime
		{
			get 
			{ 
                if(_operatingHoursFromTimeNonDefault==null)return _operatingHoursFromTimeNonDefault;
				else return _operatingHoursFromTimeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("OperatingHoursFromTime length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _operatingHoursFromTimeNonDefault =null;//null value 
                }
                else
                {		           
		            _operatingHoursFromTimeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OPERATING_HOURS_FROM_MERIDIEM" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string OperatingHoursFromMeridiem
		{
			get 
			{ 
                if(_operatingHoursFromMeridiemNonDefault==null)return _operatingHoursFromMeridiemNonDefault;
				else return _operatingHoursFromMeridiemNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("OperatingHoursFromMeridiem length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _operatingHoursFromMeridiemNonDefault =null;//null value 
                }
                else
                {		           
		            _operatingHoursFromMeridiemNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OPERATING_HOURS_TO_TIME" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string OperatingHoursToTime
		{
			get 
			{ 
                if(_operatingHoursToTimeNonDefault==null)return _operatingHoursToTimeNonDefault;
				else return _operatingHoursToTimeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("OperatingHoursToTime length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _operatingHoursToTimeNonDefault =null;//null value 
                }
                else
                {		           
		            _operatingHoursToTimeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OPERATING_HOURS_TO_MERIDIEM" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string OperatingHoursToMeridiem
		{
			get 
			{ 
                if(_operatingHoursToMeridiemNonDefault==null)return _operatingHoursToMeridiemNonDefault;
				else return _operatingHoursToMeridiemNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("OperatingHoursToMeridiem length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _operatingHoursToMeridiemNonDefault =null;//null value 
                }
                else
                {		           
		            _operatingHoursToMeridiemNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "OCDD_APPROVED_DATE" field.  
		/// </summary>
		public DateTime? OcddApprovedDate
		{
			get 
			{ 
                return _ocddApprovedDateNonDefault;
			}
			set 
			{
            
                _ocddApprovedDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "ICFDD_LICENSE_NUM" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string IcfddLicenseNum
		{
			get 
			{ 
                if(_icfddLicenseNumNonDefault==null)return _icfddLicenseNumNonDefault;
				else return _icfddLicenseNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("IcfddLicenseNum length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _icfddLicenseNumNonDefault =null;//null value 
                }
                else
                {		           
		            _icfddLicenseNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "ICFDD_LICENSE_EXP_DATE" field.  
		/// </summary>
		public DateTime? IcfddLicenseExpDate
		{
			get 
			{ 
                return _icfddLicenseExpDateNonDefault;
			}
			set 
			{
            
                _icfddLicenseExpDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "FILE_ATTACH_ID" field.  
		/// </summary>
		public decimal? FileAttachID
		{
			get 
			{ 
                return _fileAttachIDNonDefault;
			}
			set 
			{
            
                _fileAttachIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SERVICE_SUBTYPES" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string ServiceSubtypes
		{
			get 
			{ 
                if(_serviceSubtypesNonDefault==null)return _serviceSubtypesNonDefault;
				else return _serviceSubtypesNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("ServiceSubtypes length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _serviceSubtypesNonDefault =null;//null value 
                }
                else
                {		           
		            _serviceSubtypesNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CENSUS" field.  
		/// </summary>
		public int? Census
		{
			get 
			{ 
                return _censusNonDefault;
			}
			set 
			{
            
                _censusNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUMBER_BEDS" field.  
		/// </summary>
		public int? NumberBeds
		{
			get 
			{ 
                return _numberBedsNonDefault;
			}
			set 
			{
            
                _numberBedsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "NUMBER_UNITS" field.  
		/// </summary>
		public int? NumberUnits
		{
			get 
			{ 
                return _numberUnitsNonDefault;
			}
			set 
			{
            
                _numberUnitsNonDefault = value; 
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
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
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
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
              
			// Pass the value of '_serviceType' as parameter 'ServiceType' of the stored procedure.
			if(_serviceTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServiceType", _serviceTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServiceType", DBNull.Value );
              
			// Pass the value of '_typeServiceLicNum' as parameter 'TypeServiceLicNum' of the stored procedure.
			if(_typeServiceLicNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeServiceLicNum", _typeServiceLicNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeServiceLicNum", DBNull.Value );
              
			// Pass the value of '_typeServiceOther' as parameter 'TypeServiceOther' of the stored procedure.
			if(_typeServiceOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeServiceOther", _typeServiceOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeServiceOther", DBNull.Value );
              
			// Pass the value of '_fnrApprovalDate' as parameter 'FnrApprovalDate' of the stored procedure.
			if(_fnrApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@FnrApprovalDate", _fnrApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@FnrApprovalDate", DBNull.Value );
              
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
              
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
              
			// Pass the value of '_operatingHoursFromTime' as parameter 'OperatingHoursFromTime' of the stored procedure.
			if(_operatingHoursFromTimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursFromTime", _operatingHoursFromTimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursFromTime", DBNull.Value );
              
			// Pass the value of '_operatingHoursFromMeridiem' as parameter 'OperatingHoursFromMeridiem' of the stored procedure.
			if(_operatingHoursFromMeridiemNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursFromMeridiem", _operatingHoursFromMeridiemNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursFromMeridiem", DBNull.Value );
              
			// Pass the value of '_operatingHoursToTime' as parameter 'OperatingHoursToTime' of the stored procedure.
			if(_operatingHoursToTimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursToTime", _operatingHoursToTimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursToTime", DBNull.Value );
              
			// Pass the value of '_operatingHoursToMeridiem' as parameter 'OperatingHoursToMeridiem' of the stored procedure.
			if(_operatingHoursToMeridiemNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursToMeridiem", _operatingHoursToMeridiemNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursToMeridiem", DBNull.Value );
              
			// Pass the value of '_ocddApprovedDate' as parameter 'OcddApprovedDate' of the stored procedure.
			if(_ocddApprovedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OcddApprovedDate", _ocddApprovedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OcddApprovedDate", DBNull.Value );
              
			// Pass the value of '_icfddLicenseNum' as parameter 'IcfddLicenseNum' of the stored procedure.
			if(_icfddLicenseNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@IcfddLicenseNum", _icfddLicenseNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@IcfddLicenseNum", DBNull.Value );
              
			// Pass the value of '_icfddLicenseExpDate' as parameter 'IcfddLicenseExpDate' of the stored procedure.
			if(_icfddLicenseExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@IcfddLicenseExpDate", _icfddLicenseExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@IcfddLicenseExpDate", DBNull.Value );
              
			// Pass the value of '_fileAttachID' as parameter 'FileAttachID' of the stored procedure.
			if(_fileAttachIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@FileAttachID", _fileAttachIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@FileAttachID", DBNull.Value );
              
			// Pass the value of '_serviceSubtypes' as parameter 'ServiceSubtypes' of the stored procedure.
			if(_serviceSubtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServiceSubtypes", _serviceSubtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServiceSubtypes", DBNull.Value );
              
			// Pass the value of '_census' as parameter 'Census' of the stored procedure.
			if(_censusNonDefault!=null)
              oDatabaseHelper.AddParameter("@Census", _censusNonDefault);
            else
              oDatabaseHelper.AddParameter("@Census", DBNull.Value );
              
			// Pass the value of '_numberBeds' as parameter 'NumberBeds' of the stored procedure.
			if(_numberBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberBeds", _numberBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberBeds", DBNull.Value );
              
			// Pass the value of '_numberUnits' as parameter 'NumberUnits' of the stored procedure.
			if(_numberUnitsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberUnits", _numberUnitsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberUnits", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_SERVICE_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
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
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
			// Pass the value of '_serviceType' as parameter 'ServiceType' of the stored procedure.
			if(_serviceTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServiceType", _serviceTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServiceType", DBNull.Value );
			// Pass the value of '_typeServiceLicNum' as parameter 'TypeServiceLicNum' of the stored procedure.
			if(_typeServiceLicNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeServiceLicNum", _typeServiceLicNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeServiceLicNum", DBNull.Value );
			// Pass the value of '_typeServiceOther' as parameter 'TypeServiceOther' of the stored procedure.
			if(_typeServiceOtherNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeServiceOther", _typeServiceOtherNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeServiceOther", DBNull.Value );
			// Pass the value of '_fnrApprovalDate' as parameter 'FnrApprovalDate' of the stored procedure.
			if(_fnrApprovalDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@FnrApprovalDate", _fnrApprovalDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@FnrApprovalDate", DBNull.Value );
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			if(_capacityNonDefault!=null)
              oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault);
            else
              oDatabaseHelper.AddParameter("@Capacity", DBNull.Value );
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
			// Pass the value of '_operatingHoursFromTime' as parameter 'OperatingHoursFromTime' of the stored procedure.
			if(_operatingHoursFromTimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursFromTime", _operatingHoursFromTimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursFromTime", DBNull.Value );
			// Pass the value of '_operatingHoursFromMeridiem' as parameter 'OperatingHoursFromMeridiem' of the stored procedure.
			if(_operatingHoursFromMeridiemNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursFromMeridiem", _operatingHoursFromMeridiemNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursFromMeridiem", DBNull.Value );
			// Pass the value of '_operatingHoursToTime' as parameter 'OperatingHoursToTime' of the stored procedure.
			if(_operatingHoursToTimeNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursToTime", _operatingHoursToTimeNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursToTime", DBNull.Value );
			// Pass the value of '_operatingHoursToMeridiem' as parameter 'OperatingHoursToMeridiem' of the stored procedure.
			if(_operatingHoursToMeridiemNonDefault!=null)
              oDatabaseHelper.AddParameter("@OperatingHoursToMeridiem", _operatingHoursToMeridiemNonDefault);
            else
              oDatabaseHelper.AddParameter("@OperatingHoursToMeridiem", DBNull.Value );
			// Pass the value of '_ocddApprovedDate' as parameter 'OcddApprovedDate' of the stored procedure.
			if(_ocddApprovedDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@OcddApprovedDate", _ocddApprovedDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@OcddApprovedDate", DBNull.Value );
			// Pass the value of '_icfddLicenseNum' as parameter 'IcfddLicenseNum' of the stored procedure.
			if(_icfddLicenseNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@IcfddLicenseNum", _icfddLicenseNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@IcfddLicenseNum", DBNull.Value );
			// Pass the value of '_icfddLicenseExpDate' as parameter 'IcfddLicenseExpDate' of the stored procedure.
			if(_icfddLicenseExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@IcfddLicenseExpDate", _icfddLicenseExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@IcfddLicenseExpDate", DBNull.Value );
			// Pass the value of '_fileAttachID' as parameter 'FileAttachID' of the stored procedure.
			if(_fileAttachIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@FileAttachID", _fileAttachIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@FileAttachID", DBNull.Value );
			// Pass the value of '_serviceSubtypes' as parameter 'ServiceSubtypes' of the stored procedure.
			if(_serviceSubtypesNonDefault!=null)
              oDatabaseHelper.AddParameter("@ServiceSubtypes", _serviceSubtypesNonDefault);
            else
              oDatabaseHelper.AddParameter("@ServiceSubtypes", DBNull.Value );
			// Pass the value of '_census' as parameter 'Census' of the stored procedure.
			if(_censusNonDefault!=null)
              oDatabaseHelper.AddParameter("@Census", _censusNonDefault);
            else
              oDatabaseHelper.AddParameter("@Census", DBNull.Value );
			// Pass the value of '_numberBeds' as parameter 'NumberBeds' of the stored procedure.
			if(_numberBedsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberBeds", _numberBedsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberBeds", DBNull.Value );
			// Pass the value of '_numberUnits' as parameter 'NumberUnits' of the stored procedure.
			if(_numberUnitsNonDefault!=null)
              oDatabaseHelper.AddParameter("@NumberUnits", _numberUnitsNonDefault);
            else
              oDatabaseHelper.AddParameter("@NumberUnits", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SERVICE_Insert", ref ExecutionState);
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
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_serviceID' as parameter 'ServiceID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ServiceID", _serviceIDNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault );
            
			// Pass the value of '_serviceType' as parameter 'ServiceType' of the stored procedure.
			oDatabaseHelper.AddParameter("@ServiceType", _serviceTypeNonDefault );
            
			// Pass the value of '_typeServiceLicNum' as parameter 'TypeServiceLicNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeServiceLicNum", _typeServiceLicNumNonDefault );
            
			// Pass the value of '_typeServiceOther' as parameter 'TypeServiceOther' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeServiceOther", _typeServiceOtherNonDefault );
            
			// Pass the value of '_fnrApprovalDate' as parameter 'FnrApprovalDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@FnrApprovalDate", _fnrApprovalDateNonDefault );
            
			// Pass the value of '_capacity' as parameter 'Capacity' of the stored procedure.
			oDatabaseHelper.AddParameter("@Capacity", _capacityNonDefault );
            
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
            
			// Pass the value of '_operatingHoursFromTime' as parameter 'OperatingHoursFromTime' of the stored procedure.
			oDatabaseHelper.AddParameter("@OperatingHoursFromTime", _operatingHoursFromTimeNonDefault );
            
			// Pass the value of '_operatingHoursFromMeridiem' as parameter 'OperatingHoursFromMeridiem' of the stored procedure.
			oDatabaseHelper.AddParameter("@OperatingHoursFromMeridiem", _operatingHoursFromMeridiemNonDefault );
            
			// Pass the value of '_operatingHoursToTime' as parameter 'OperatingHoursToTime' of the stored procedure.
			oDatabaseHelper.AddParameter("@OperatingHoursToTime", _operatingHoursToTimeNonDefault );
            
			// Pass the value of '_operatingHoursToMeridiem' as parameter 'OperatingHoursToMeridiem' of the stored procedure.
			oDatabaseHelper.AddParameter("@OperatingHoursToMeridiem", _operatingHoursToMeridiemNonDefault );
            
			// Pass the value of '_ocddApprovedDate' as parameter 'OcddApprovedDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@OcddApprovedDate", _ocddApprovedDateNonDefault );
            
			// Pass the value of '_icfddLicenseNum' as parameter 'IcfddLicenseNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@IcfddLicenseNum", _icfddLicenseNumNonDefault );
            
			// Pass the value of '_icfddLicenseExpDate' as parameter 'IcfddLicenseExpDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@IcfddLicenseExpDate", _icfddLicenseExpDateNonDefault );
            
			// Pass the value of '_fileAttachID' as parameter 'FileAttachID' of the stored procedure.
			oDatabaseHelper.AddParameter("@FileAttachID", _fileAttachIDNonDefault );
            
			// Pass the value of '_serviceSubtypes' as parameter 'ServiceSubtypes' of the stored procedure.
			oDatabaseHelper.AddParameter("@ServiceSubtypes", _serviceSubtypesNonDefault );
            
			// Pass the value of '_census' as parameter 'Census' of the stored procedure.
			oDatabaseHelper.AddParameter("@Census", _censusNonDefault );
            
			// Pass the value of '_numberBeds' as parameter 'NumberBeds' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumberBeds", _numberBedsNonDefault );
            
			// Pass the value of '_numberUnits' as parameter 'NumberUnits' of the stored procedure.
			oDatabaseHelper.AddParameter("@NumberUnits", _numberUnitsNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SERVICE_Update", ref ExecutionState);
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
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_serviceID' as parameter 'ServiceID' of the stored procedure.
			if(_serviceIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ServiceID", _serviceIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ServiceID", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_SERVICE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_ServicePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_ServicePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_SERVICE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_ServiceFields">Field of the class BO_Service</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_SERVICE_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_ServicePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Service</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Service SelectOne(BO_ServicePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Service obj=new BO_Service();	
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
		/// <returns>list of objects of class BO_Service in the form of object of BO_Services </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Services SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_SelectAll", ref ExecutionState);
			BO_Services BO_Services = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Services;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Service</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Service in the form of an object of class BO_Services</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Services SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_SelectByField", ref ExecutionState);
			BO_Services BO_Services = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Services;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Services</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Services SelectAllByForeignKeyAffiliationID(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Services obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_SelectAllByForeignKeyAffiliationID", ref ExecutionState);
			obj = new BO_Services();
			obj = BO_Service.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyAffiliationID(BO_AffiliationPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SERVICE_DeleteAllByForeignKeyAffiliationID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Services</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Services SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Services obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Services();
			obj = BO_Service.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
            dr.Close();  
			oDatabaseHelper.Dispose();
			return obj;
			
		}

		/// <summary>
		/// This method will delete row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be deleted.</param>
		///
		/// <returns>object of boolean type as an indicator for operation success .</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool DeleteAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SERVICE_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_Services</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Services SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Services obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_SERVICE_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Services();
			obj = BO_Service.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			12/08/2015 11:47:22 AM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_SERVICE_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			12/08/2015 11:47:22 AM		Created function
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
		/// <param name="obj" type="SERVICE">Object of SERVICE to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_ServiceBase obj,IDataReader rdr) 
		{

			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ServiceFields.PopsIntID)));
			obj.ServiceID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ServiceFields.ServiceID)));
			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ServiceFields.ApplicationID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.AffiliationID)))
			{
				obj.AffiliationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ServiceFields.AffiliationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.ServiceType)))
			{
				obj.ServiceType = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.ServiceType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.TypeServiceLicNum)))
			{
				obj.TypeServiceLicNum = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.TypeServiceLicNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.TypeServiceOther)))
			{
				obj.TypeServiceOther = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.TypeServiceOther));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.FnrApprovalDate)))
			{
				obj.FnrApprovalDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ServiceFields.FnrApprovalDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.Capacity)))
			{
				obj.Capacity = rdr.GetInt32(rdr.GetOrdinal(BO_ServiceFields.Capacity));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationMon)))
			{
				obj.DayOfOperationMon = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationMon));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationTue)))
			{
				obj.DayOfOperationTue = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationTue));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationWed)))
			{
				obj.DayOfOperationWed = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationWed));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationThu)))
			{
				obj.DayOfOperationThu = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationThu));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationFri)))
			{
				obj.DayOfOperationFri = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationFri));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationSat)))
			{
				obj.DayOfOperationSat = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationSat));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationSun)))
			{
				obj.DayOfOperationSun = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.DayOfOperationSun));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursFromTime)))
			{
				obj.OperatingHoursFromTime = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursFromTime));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursFromMeridiem)))
			{
				obj.OperatingHoursFromMeridiem = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursFromMeridiem));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursToTime)))
			{
				obj.OperatingHoursToTime = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursToTime));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursToMeridiem)))
			{
				obj.OperatingHoursToMeridiem = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.OperatingHoursToMeridiem));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.OcddApprovedDate)))
			{
				obj.OcddApprovedDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ServiceFields.OcddApprovedDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.IcfddLicenseNum)))
			{
				obj.IcfddLicenseNum = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.IcfddLicenseNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.IcfddLicenseExpDate)))
			{
				obj.IcfddLicenseExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_ServiceFields.IcfddLicenseExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.FileAttachID)))
			{
				obj.FileAttachID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_ServiceFields.FileAttachID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.ServiceSubtypes)))
			{
				obj.ServiceSubtypes = rdr.GetString(rdr.GetOrdinal(BO_ServiceFields.ServiceSubtypes));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.Census)))
			{
				obj.Census = rdr.GetInt32(rdr.GetOrdinal(BO_ServiceFields.Census));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.NumberBeds)))
			{
				obj.NumberBeds = rdr.GetInt32(rdr.GetOrdinal(BO_ServiceFields.NumberBeds));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_ServiceFields.NumberUnits)))
			{
				obj.NumberUnits = rdr.GetInt32(rdr.GetOrdinal(BO_ServiceFields.NumberUnits));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Services</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Services PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Services list = new BO_Services();
			
			while (rdr.Read())
			{
				BO_Service obj = new BO_Service();
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
		/// <returns>Object of BO_Services</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			12/08/2015 11:47:22 AM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Services PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Services list = new BO_Services();
			
            if (rdr.Read())
            {
                BO_Service obj = new BO_Service();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Service();
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
