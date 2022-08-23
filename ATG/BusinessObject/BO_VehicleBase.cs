//
// Class	:	BO_VehicleBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	02/01/2013 2:34:40 PM
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
	public class BO_VehicleFields
	{
		public const string VehicleRecID              = "VEHICLE_REC_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string CertificateNum            = "CERTIFICATE_NUM";
		public const string MakeDescription           = "MAKE_DESCRIPTION";
		public const string MakeCode                  = "MAKE_CODE";
		public const string TypeVehicle               = "TYPE_VEHICLE";
		public const string VehicleModelYear          = "VEHICLE_MODEL_YEAR";
		public const string VehicleVin                = "VEHICLE_VIN";
		public const string VehicleUnit               = "VEHICLE_UNIT";
		public const string VehicleBase               = "VEHICLE_BASE";
		public const string VehicleBaseDescription    = "VEHICLE_BASE_DESCRIPTION";
		public const string FaaLicNum                 = "FAA_LIC_NUM";
		public const string VehicleLicensePlate       = "VEHICLE_LICENSE_PLATE";
		public const string VehicleDecal              = "VEHICLE_DECAL";
		public const string VehicleDecalExpDate       = "VEHICLE_DECAL_EXP_DATE";
		public const string TotalCapacityAmbulatory   = "TOTAL_CAPACITY_AMBULATORY";
		public const string TotalCapacityHandicap     = "TOTAL_CAPACITY_HANDICAP";
		public const string Wing                      = "WING";
	}
	
	/// <summary>
	/// Data access class for the "VEHICLE" table.
	/// </summary>
	[Serializable]
	public class BO_VehicleBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_vehicleRecIDNonDefault  	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_certificateNumNonDefault	= null;
		private string         	_makeDescriptionNonDefault	= null;
		private string         	_makeCodeNonDefault      	= null;
		private string         	_typeVehicleNonDefault   	= null;
		private string         	_vehicleModelYearNonDefault	= null;
		private string         	_vehicleVinNonDefault    	= null;
		private string         	_vehicleUnitNonDefault   	= null;
		private string         	_vehicleBaseNonDefault   	= null;
		private string         	_vehicleBaseDescriptionNonDefault	= null;
		private string         	_faaLicNumNonDefault     	= null;
		private string         	_vehicleLicensePlateNonDefault	= null;
		private string         	_vehicleDecalNonDefault  	= null;
		private DateTime?      	_vehicleDecalExpDateNonDefault	= null;
		private int?           	_totalCapacityAmbulatoryNonDefault	= null;
		private int?           	_totalCapacityHandicapNonDefault	= null;
		private string         	_wingNonDefault          	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_VehicleBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? VehicleRecID
		{
			get 
			{ 
                return _vehicleRecIDNonDefault;
			}
			set 
			{
            
                _vehicleRecIDNonDefault = value; 
			}
		}

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
		/// This property is mapped to the "CERTIFICATE_NUM" field. Length must be between 0 and 9 characters. 
		/// </summary>
		public string CertificateNum
		{
			get 
			{ 
                if(_certificateNumNonDefault==null)return _certificateNumNonDefault;
				else return _certificateNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 9)
					throw new ArgumentException("CertificateNum length must be between 0 and 9 characters.");

				
                if(value ==null)
                {
                    _certificateNumNonDefault =null;//null value 
                }
                else
                {		           
		            _certificateNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAKE_DESCRIPTION" field. Length must be between 0 and 25 characters. 
		/// </summary>
		public string MakeDescription
		{
			get 
			{ 
                if(_makeDescriptionNonDefault==null)return _makeDescriptionNonDefault;
				else return _makeDescriptionNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 25)
					throw new ArgumentException("MakeDescription length must be between 0 and 25 characters.");

				
                if(value ==null)
                {
                    _makeDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _makeDescriptionNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MAKE_CODE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string MakeCode
		{
			get 
			{ 
                if(_makeCodeNonDefault==null)return _makeCodeNonDefault;
				else return _makeCodeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("MakeCode length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _makeCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _makeCodeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "TYPE_VEHICLE" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string TypeVehicle
		{
			get 
			{ 
                if(_typeVehicleNonDefault==null)return _typeVehicleNonDefault;
				else return _typeVehicleNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("TypeVehicle length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _typeVehicleNonDefault =null;//null value 
                }
                else
                {		           
		            _typeVehicleNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_MODEL_YEAR" field. Length must be between 0 and 4 characters. 
		/// </summary>
		public string VehicleModelYear
		{
			get 
			{ 
                if(_vehicleModelYearNonDefault==null)return _vehicleModelYearNonDefault;
				else return _vehicleModelYearNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 4)
					throw new ArgumentException("VehicleModelYear length must be between 0 and 4 characters.");

				
                if(value ==null)
                {
                    _vehicleModelYearNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleModelYearNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_VIN" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string VehicleVin
		{
			get 
			{ 
                if(_vehicleVinNonDefault==null)return _vehicleVinNonDefault;
				else return _vehicleVinNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("VehicleVin length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _vehicleVinNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleVinNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_UNIT" field. Length must be between 0 and 12 characters. 
		/// </summary>
		public string VehicleUnit
		{
			get 
			{ 
                if(_vehicleUnitNonDefault==null)return _vehicleUnitNonDefault;
				else return _vehicleUnitNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 12)
					throw new ArgumentException("VehicleUnit length must be between 0 and 12 characters.");

				
                if(value ==null)
                {
                    _vehicleUnitNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleUnitNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_BASE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string VehicleBase
		{
			get 
			{ 
                if(_vehicleBaseNonDefault==null)return _vehicleBaseNonDefault;
				else return _vehicleBaseNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("VehicleBase length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _vehicleBaseNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleBaseNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_BASE_DESCRIPTION" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string VehicleBaseDescription
		{
			get 
			{ 
                if(_vehicleBaseDescriptionNonDefault==null)return _vehicleBaseDescriptionNonDefault;
				else return _vehicleBaseDescriptionNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("VehicleBaseDescription length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _vehicleBaseDescriptionNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleBaseDescriptionNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "FAA_LIC_NUM" field. Length must be between 0 and 8 characters. 
		/// </summary>
		public string FaaLicNum
		{
			get 
			{ 
                if(_faaLicNumNonDefault==null)return _faaLicNumNonDefault;
				else return _faaLicNumNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 8)
					throw new ArgumentException("FaaLicNum length must be between 0 and 8 characters.");

				
                if(value ==null)
                {
                    _faaLicNumNonDefault =null;//null value 
                }
                else
                {		           
		            _faaLicNumNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_LICENSE_PLATE" field. Length must be between 0 and 8 characters. 
		/// </summary>
		public string VehicleLicensePlate
		{
			get 
			{ 
                if(_vehicleLicensePlateNonDefault==null)return _vehicleLicensePlateNonDefault;
				else return _vehicleLicensePlateNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 8)
					throw new ArgumentException("VehicleLicensePlate length must be between 0 and 8 characters.");

				
                if(value ==null)
                {
                    _vehicleLicensePlateNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleLicensePlateNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_DECAL" field. Length must be between 0 and 10 characters. 
		/// </summary>
		public string VehicleDecal
		{
			get 
			{ 
                if(_vehicleDecalNonDefault==null)return _vehicleDecalNonDefault;
				else return _vehicleDecalNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 10)
					throw new ArgumentException("VehicleDecal length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _vehicleDecalNonDefault =null;//null value 
                }
                else
                {		           
		            _vehicleDecalNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "VEHICLE_DECAL_EXP_DATE" field.  
		/// </summary>
		public DateTime? VehicleDecalExpDate
		{
			get 
			{ 
                return _vehicleDecalExpDateNonDefault;
			}
			set 
			{
            
                _vehicleDecalExpDateNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_CAPACITY_AMBULATORY" field.  
		/// </summary>
		public int? TotalCapacityAmbulatory
		{
			get 
			{ 
                return _totalCapacityAmbulatoryNonDefault;
			}
			set 
			{
            
                _totalCapacityAmbulatoryNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "TOTAL_CAPACITY_HANDICAP" field.  
		/// </summary>
		public int? TotalCapacityHandicap
		{
			get 
			{ 
                return _totalCapacityHandicapNonDefault;
			}
			set 
			{
            
                _totalCapacityHandicapNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "WING" field. Length must be between 0 and 1 characters. 
		/// </summary>
		public string Wing
		{
			get 
			{ 
                if(_wingNonDefault==null)return _wingNonDefault;
				else return _wingNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 1)
					throw new ArgumentException("Wing length must be between 0 and 1 characters.");

				
                if(value ==null)
                {
                    _wingNonDefault =null;//null value 
                }
                else
                {		           
		            _wingNonDefault = value.Replace("'", "''"); 
                }
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
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
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
              
			// Pass the value of '_certificateNum' as parameter 'CertificateNum' of the stored procedure.
			if(_certificateNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertificateNum", _certificateNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertificateNum", DBNull.Value );
              
			// Pass the value of '_makeDescription' as parameter 'MakeDescription' of the stored procedure.
			if(_makeDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@MakeDescription", _makeDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@MakeDescription", DBNull.Value );
              
			// Pass the value of '_makeCode' as parameter 'MakeCode' of the stored procedure.
			if(_makeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MakeCode", _makeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MakeCode", DBNull.Value );
              
			// Pass the value of '_typeVehicle' as parameter 'TypeVehicle' of the stored procedure.
			if(_typeVehicleNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeVehicle", _typeVehicleNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeVehicle", DBNull.Value );
              
			// Pass the value of '_vehicleModelYear' as parameter 'VehicleModelYear' of the stored procedure.
			if(_vehicleModelYearNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleModelYear", _vehicleModelYearNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleModelYear", DBNull.Value );
              
			// Pass the value of '_vehicleVin' as parameter 'VehicleVin' of the stored procedure.
			if(_vehicleVinNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleVin", _vehicleVinNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleVin", DBNull.Value );
              
			// Pass the value of '_vehicleUnit' as parameter 'VehicleUnit' of the stored procedure.
			if(_vehicleUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleUnit", _vehicleUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleUnit", DBNull.Value );
              
			// Pass the value of '_vehicleBase' as parameter 'VehicleBase' of the stored procedure.
			if(_vehicleBaseNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleBase", _vehicleBaseNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleBase", DBNull.Value );
              
			// Pass the value of '_vehicleBaseDescription' as parameter 'VehicleBaseDescription' of the stored procedure.
			if(_vehicleBaseDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleBaseDescription", _vehicleBaseDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleBaseDescription", DBNull.Value );
              
			// Pass the value of '_faaLicNum' as parameter 'FaaLicNum' of the stored procedure.
			if(_faaLicNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaaLicNum", _faaLicNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaaLicNum", DBNull.Value );
              
			// Pass the value of '_vehicleLicensePlate' as parameter 'VehicleLicensePlate' of the stored procedure.
			if(_vehicleLicensePlateNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleLicensePlate", _vehicleLicensePlateNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleLicensePlate", DBNull.Value );
              
			// Pass the value of '_vehicleDecal' as parameter 'VehicleDecal' of the stored procedure.
			if(_vehicleDecalNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleDecal", _vehicleDecalNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleDecal", DBNull.Value );
              
			// Pass the value of '_vehicleDecalExpDate' as parameter 'VehicleDecalExpDate' of the stored procedure.
			if(_vehicleDecalExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleDecalExpDate", _vehicleDecalExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleDecalExpDate", DBNull.Value );
              
			// Pass the value of '_totalCapacityAmbulatory' as parameter 'TotalCapacityAmbulatory' of the stored procedure.
			if(_totalCapacityAmbulatoryNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalCapacityAmbulatory", _totalCapacityAmbulatoryNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalCapacityAmbulatory", DBNull.Value );
              
			// Pass the value of '_totalCapacityHandicap' as parameter 'TotalCapacityHandicap' of the stored procedure.
			if(_totalCapacityHandicapNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalCapacityHandicap", _totalCapacityHandicapNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalCapacityHandicap", DBNull.Value );
              
			// Pass the value of '_wing' as parameter 'Wing' of the stored procedure.
			if(_wingNonDefault!=null)
              oDatabaseHelper.AddParameter("@Wing", _wingNonDefault);
            else
              oDatabaseHelper.AddParameter("@Wing", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_VEHICLE_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_VEHICLE_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
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
			// Pass the value of '_certificateNum' as parameter 'CertificateNum' of the stored procedure.
			if(_certificateNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@CertificateNum", _certificateNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@CertificateNum", DBNull.Value );
			// Pass the value of '_makeDescription' as parameter 'MakeDescription' of the stored procedure.
			if(_makeDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@MakeDescription", _makeDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@MakeDescription", DBNull.Value );
			// Pass the value of '_makeCode' as parameter 'MakeCode' of the stored procedure.
			if(_makeCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MakeCode", _makeCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MakeCode", DBNull.Value );
			// Pass the value of '_typeVehicle' as parameter 'TypeVehicle' of the stored procedure.
			if(_typeVehicleNonDefault!=null)
              oDatabaseHelper.AddParameter("@TypeVehicle", _typeVehicleNonDefault);
            else
              oDatabaseHelper.AddParameter("@TypeVehicle", DBNull.Value );
			// Pass the value of '_vehicleModelYear' as parameter 'VehicleModelYear' of the stored procedure.
			if(_vehicleModelYearNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleModelYear", _vehicleModelYearNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleModelYear", DBNull.Value );
			// Pass the value of '_vehicleVin' as parameter 'VehicleVin' of the stored procedure.
			if(_vehicleVinNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleVin", _vehicleVinNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleVin", DBNull.Value );
			// Pass the value of '_vehicleUnit' as parameter 'VehicleUnit' of the stored procedure.
			if(_vehicleUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleUnit", _vehicleUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleUnit", DBNull.Value );
			// Pass the value of '_vehicleBase' as parameter 'VehicleBase' of the stored procedure.
			if(_vehicleBaseNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleBase", _vehicleBaseNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleBase", DBNull.Value );
			// Pass the value of '_vehicleBaseDescription' as parameter 'VehicleBaseDescription' of the stored procedure.
			if(_vehicleBaseDescriptionNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleBaseDescription", _vehicleBaseDescriptionNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleBaseDescription", DBNull.Value );
			// Pass the value of '_faaLicNum' as parameter 'FaaLicNum' of the stored procedure.
			if(_faaLicNumNonDefault!=null)
              oDatabaseHelper.AddParameter("@FaaLicNum", _faaLicNumNonDefault);
            else
              oDatabaseHelper.AddParameter("@FaaLicNum", DBNull.Value );
			// Pass the value of '_vehicleLicensePlate' as parameter 'VehicleLicensePlate' of the stored procedure.
			if(_vehicleLicensePlateNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleLicensePlate", _vehicleLicensePlateNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleLicensePlate", DBNull.Value );
			// Pass the value of '_vehicleDecal' as parameter 'VehicleDecal' of the stored procedure.
			if(_vehicleDecalNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleDecal", _vehicleDecalNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleDecal", DBNull.Value );
			// Pass the value of '_vehicleDecalExpDate' as parameter 'VehicleDecalExpDate' of the stored procedure.
			if(_vehicleDecalExpDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@VehicleDecalExpDate", _vehicleDecalExpDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@VehicleDecalExpDate", DBNull.Value );
			// Pass the value of '_totalCapacityAmbulatory' as parameter 'TotalCapacityAmbulatory' of the stored procedure.
			if(_totalCapacityAmbulatoryNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalCapacityAmbulatory", _totalCapacityAmbulatoryNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalCapacityAmbulatory", DBNull.Value );
			// Pass the value of '_totalCapacityHandicap' as parameter 'TotalCapacityHandicap' of the stored procedure.
			if(_totalCapacityHandicapNonDefault!=null)
              oDatabaseHelper.AddParameter("@TotalCapacityHandicap", _totalCapacityHandicapNonDefault);
            else
              oDatabaseHelper.AddParameter("@TotalCapacityHandicap", DBNull.Value );
			// Pass the value of '_wing' as parameter 'Wing' of the stored procedure.
			if(_wingNonDefault!=null)
              oDatabaseHelper.AddParameter("@Wing", _wingNonDefault);
            else
              oDatabaseHelper.AddParameter("@Wing", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_VEHICLE_Insert", ref ExecutionState);
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
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_vehicleRecID' as parameter 'VehicleRecID' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleRecID", _vehicleRecIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_certificateNum' as parameter 'CertificateNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@CertificateNum", _certificateNumNonDefault );
            
			// Pass the value of '_makeDescription' as parameter 'MakeDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@MakeDescription", _makeDescriptionNonDefault );
            
			// Pass the value of '_makeCode' as parameter 'MakeCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@MakeCode", _makeCodeNonDefault );
            
			// Pass the value of '_typeVehicle' as parameter 'TypeVehicle' of the stored procedure.
			oDatabaseHelper.AddParameter("@TypeVehicle", _typeVehicleNonDefault );
            
			// Pass the value of '_vehicleModelYear' as parameter 'VehicleModelYear' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleModelYear", _vehicleModelYearNonDefault );
            
			// Pass the value of '_vehicleVin' as parameter 'VehicleVin' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleVin", _vehicleVinNonDefault );
            
			// Pass the value of '_vehicleUnit' as parameter 'VehicleUnit' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleUnit", _vehicleUnitNonDefault );
            
			// Pass the value of '_vehicleBase' as parameter 'VehicleBase' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleBase", _vehicleBaseNonDefault );
            
			// Pass the value of '_vehicleBaseDescription' as parameter 'VehicleBaseDescription' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleBaseDescription", _vehicleBaseDescriptionNonDefault );
            
			// Pass the value of '_faaLicNum' as parameter 'FaaLicNum' of the stored procedure.
			oDatabaseHelper.AddParameter("@FaaLicNum", _faaLicNumNonDefault );
            
			// Pass the value of '_vehicleLicensePlate' as parameter 'VehicleLicensePlate' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleLicensePlate", _vehicleLicensePlateNonDefault );
            
			// Pass the value of '_vehicleDecal' as parameter 'VehicleDecal' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleDecal", _vehicleDecalNonDefault );
            
			// Pass the value of '_vehicleDecalExpDate' as parameter 'VehicleDecalExpDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@VehicleDecalExpDate", _vehicleDecalExpDateNonDefault );
            
			// Pass the value of '_totalCapacityAmbulatory' as parameter 'TotalCapacityAmbulatory' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalCapacityAmbulatory", _totalCapacityAmbulatoryNonDefault );
            
			// Pass the value of '_totalCapacityHandicap' as parameter 'TotalCapacityHandicap' of the stored procedure.
			oDatabaseHelper.AddParameter("@TotalCapacityHandicap", _totalCapacityHandicapNonDefault );
            
			// Pass the value of '_wing' as parameter 'Wing' of the stored procedure.
			oDatabaseHelper.AddParameter("@Wing", _wingNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_VEHICLE_Update", ref ExecutionState);
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
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_vehicleRecID' as parameter 'VehicleRecID' of the stored procedure.
			if(_vehicleRecIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@VehicleRecID", _vehicleRecIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@VehicleRecID", DBNull.Value );
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_VEHICLE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_VehiclePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_VehiclePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_VEHICLE_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_VehicleFields">Field of the class BO_Vehicle</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_VEHICLE_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_VehiclePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Vehicle</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Vehicle SelectOne(BO_VehiclePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_VEHICLE_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Vehicle obj=new BO_Vehicle();	
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
		/// <returns>list of objects of class BO_Vehicle in the form of object of BO_Vehicles </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Vehicles SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_VEHICLE_SelectAll", ref ExecutionState);
			BO_Vehicles BO_Vehicles = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Vehicles;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Vehicle</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Vehicle in the form of an object of class BO_Vehicles</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Vehicles SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_VEHICLE_SelectByField", ref ExecutionState);
			BO_Vehicles BO_Vehicles = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Vehicles;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="PROVIDERSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Vehicles</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Vehicles SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Vehicles obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_VEHICLE_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Vehicles();
			obj = BO_Vehicle.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			02/01/2013 2:34:40 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_VEHICLE_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			02/01/2013 2:34:40 PM		Created function
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
		/// <param name="obj" type="VEHICLE">Object of VEHICLE to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_VehicleBase obj,IDataReader rdr) 
		{

			obj.VehicleRecID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_VehicleFields.VehicleRecID)));
			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_VehicleFields.PopsIntID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.CertificateNum)))
			{
				obj.CertificateNum = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.CertificateNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.MakeDescription)))
			{
				obj.MakeDescription = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.MakeDescription));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.MakeCode)))
			{
				obj.MakeCode = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.MakeCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.TypeVehicle)))
			{
				obj.TypeVehicle = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.TypeVehicle));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleModelYear)))
			{
				obj.VehicleModelYear = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleModelYear));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleVin)))
			{
				obj.VehicleVin = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleVin));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleUnit)))
			{
				obj.VehicleUnit = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleUnit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleBase)))
			{
				obj.VehicleBase = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleBase));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleBaseDescription)))
			{
				obj.VehicleBaseDescription = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleBaseDescription));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.FaaLicNum)))
			{
				obj.FaaLicNum = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.FaaLicNum));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleLicensePlate)))
			{
				obj.VehicleLicensePlate = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleLicensePlate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleDecal)))
			{
				obj.VehicleDecal = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.VehicleDecal));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.VehicleDecalExpDate)))
			{
				obj.VehicleDecalExpDate = rdr.GetDateTime(rdr.GetOrdinal(BO_VehicleFields.VehicleDecalExpDate));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.TotalCapacityAmbulatory)))
			{
				obj.TotalCapacityAmbulatory = rdr.GetInt32(rdr.GetOrdinal(BO_VehicleFields.TotalCapacityAmbulatory));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.TotalCapacityHandicap)))
			{
				obj.TotalCapacityHandicap = rdr.GetInt32(rdr.GetOrdinal(BO_VehicleFields.TotalCapacityHandicap));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_VehicleFields.Wing)))
			{
				obj.Wing = rdr.GetString(rdr.GetOrdinal(BO_VehicleFields.Wing));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Vehicles</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Vehicles PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Vehicles list = new BO_Vehicles();
			
			while (rdr.Read())
			{
				BO_Vehicle obj = new BO_Vehicle();
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
		/// <returns>Object of BO_Vehicles</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			02/01/2013 2:34:40 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Vehicles PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Vehicles list = new BO_Vehicles();
			
            if (rdr.Read())
            {
                BO_Vehicle obj = new BO_Vehicle();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Vehicle();
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
