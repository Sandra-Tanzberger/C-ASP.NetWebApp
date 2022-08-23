//
// Class	:	BO_CapacityBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	06/23/2016 2:17:36 PM
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
	public class BO_CapacityFields
	{
		public const string CapacityID                = "CAPACITY_ID";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string CapacityType              = "CAPACITY_TYPE";
		public const string AffiliationID             = "AFFILIATION_ID";
		public const string CapacityCount             = "CAPACITY_COUNT";
		public const string BedsUnit                  = "BEDS_UNIT";
		public const string BedsType                  = "BEDS_TYPE";
		public const string BedsFloor                 = "BEDS_FLOOR";
		public const string BedsRoomNumber            = "BEDS_ROOM_NUMBER";
		public const string BedsRoomSizeMet           = "BEDS_ROOM_SIZE_MET";
		public const string BedsCallSystemMet         = "BEDS_CALL_SYSTEM_MET";
		public const string BedsFurnitureMet          = "BEDS_FURNITURE_MET";
		public const string BedsPrivacyMet            = "BEDS_PRIVACY_MET";
		public const string BedsComment               = "BEDS_COMMENT";
		public const string CurrentNumRooms           = "CURRENT_NUM_ROOMS";
		public const string CurrentNumUnits           = "CURRENT_NUM_UNITS";
		public const string ProposedNumRooms          = "PROPOSED_NUM_ROOMS";
		public const string SubstanceAbuseType        = "SUBSTANCE_ABUSE_TYPE";
		public const string Census                    = "CENSUS";
	}
	
	/// <summary>
	/// Data access class for the "CAPACITIES" table.
	/// </summary>
	[Serializable]
	public class BO_CapacityBase
	{
		
		#region Class Level Variables
		
		private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_capacityIDNonDefault    	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private string         	_capacityTypeNonDefault  	= null;
		private decimal?       	_affiliationIDNonDefault 	= null;
		private int?           	_capacityCountNonDefault 	= null;
		private string         	_bedsUnitNonDefault      	= null;
		private string         	_bedsTypeNonDefault      	= null;
		private string         	_bedsFloorNonDefault     	= null;
		private string         	_bedsRoomNumberNonDefault	= null;
		private int?           	_bedsRoomSizeMetNonDefault	= null;
		private int?           	_bedsCallSystemMetNonDefault	= null;
		private int?           	_bedsFurnitureMetNonDefault	= null;
		private int?           	_bedsPrivacyMetNonDefault	= null;
		private string         	_bedsCommentNonDefault   	= null;
		private int?           	_currentNumRoomsNonDefault	= null;
		private int?           	_currentNumUnitsNonDefault	= null;
		private int?           	_proposedNumRoomsNonDefault	= null;
		private string         	_substanceAbuseTypeNonDefault	= null;
		private int?           	_censusNonDefault        	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
		
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_CapacityBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? CapacityID
		{
			get 
			{ 
                return _capacityIDNonDefault;
			}
			set 
			{
            
                _capacityIDNonDefault = value; 
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
		/// This property is mapped to the "CAPACITY_TYPE" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string CapacityType
		{
			get 
			{ 
                if(_capacityTypeNonDefault==null)return _capacityTypeNonDefault;
				else return _capacityTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("CapacityType length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _capacityTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _capacityTypeNonDefault = value.Replace("'", "''"); 
                }
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
		/// This property is mapped to the "CAPACITY_COUNT" field.  
		/// </summary>
		public int? CapacityCount
		{
			get 
			{ 
                return _capacityCountNonDefault;
			}
			set 
			{
            
                _capacityCountNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_UNIT" field. Length must be between 0 and 30 characters. 
		/// </summary>
		public string BedsUnit
		{
			get 
			{ 
                if(_bedsUnitNonDefault==null)return _bedsUnitNonDefault;
				else return _bedsUnitNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 30)
					throw new ArgumentException("BedsUnit length must be between 0 and 30 characters.");

				
                if(value ==null)
                {
                    _bedsUnitNonDefault =null;//null value 
                }
                else
                {		           
		            _bedsUnitNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_TYPE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string BedsType
		{
			get 
			{ 
                if(_bedsTypeNonDefault==null)return _bedsTypeNonDefault;
				else return _bedsTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("BedsType length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _bedsTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _bedsTypeNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_FLOOR" field. Length must be between 0 and 3 characters. 
		/// </summary>
		public string BedsFloor
		{
			get 
			{ 
                if(_bedsFloorNonDefault==null)return _bedsFloorNonDefault;
				else return _bedsFloorNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 3)
					throw new ArgumentException("BedsFloor length must be between 0 and 3 characters.");

				
                if(value ==null)
                {
                    _bedsFloorNonDefault =null;//null value 
                }
                else
                {		           
		            _bedsFloorNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_ROOM_NUMBER" field. Length must be between 0 and 20 characters. 
		/// </summary>
		public string BedsRoomNumber
		{
			get 
			{ 
                if(_bedsRoomNumberNonDefault==null)return _bedsRoomNumberNonDefault;
				else return _bedsRoomNumberNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 20)
					throw new ArgumentException("BedsRoomNumber length must be between 0 and 20 characters.");

				
                if(value ==null)
                {
                    _bedsRoomNumberNonDefault =null;//null value 
                }
                else
                {		           
		            _bedsRoomNumberNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_ROOM_SIZE_MET" field.  
		/// </summary>
		public int? BedsRoomSizeMet
		{
			get 
			{ 
                return _bedsRoomSizeMetNonDefault;
			}
			set 
			{
            
                _bedsRoomSizeMetNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_CALL_SYSTEM_MET" field.  
		/// </summary>
		public int? BedsCallSystemMet
		{
			get 
			{ 
                return _bedsCallSystemMetNonDefault;
			}
			set 
			{
            
                _bedsCallSystemMetNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_FURNITURE_MET" field.  
		/// </summary>
		public int? BedsFurnitureMet
		{
			get 
			{ 
                return _bedsFurnitureMetNonDefault;
			}
			set 
			{
            
                _bedsFurnitureMetNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_PRIVACY_MET" field.  
		/// </summary>
		public int? BedsPrivacyMet
		{
			get 
			{ 
                return _bedsPrivacyMetNonDefault;
			}
			set 
			{
            
                _bedsPrivacyMetNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "BEDS_COMMENT" field. Length must be between 0 and 255 characters. 
		/// </summary>
		public string BedsComment
		{
			get 
			{ 
                if(_bedsCommentNonDefault==null)return _bedsCommentNonDefault;
				else return _bedsCommentNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 255)
					throw new ArgumentException("BedsComment length must be between 0 and 255 characters.");

				
                if(value ==null)
                {
                    _bedsCommentNonDefault =null;//null value 
                }
                else
                {		           
		            _bedsCommentNonDefault = value.Replace("'", "''"); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "CURRENT_NUM_ROOMS" field.  
		/// </summary>
		public int? CurrentNumRooms
		{
			get 
			{ 
                return _currentNumRoomsNonDefault;
			}
			set 
			{
            
                _currentNumRoomsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "CURRENT_NUM_UNITS" field.  
		/// </summary>
		public int? CurrentNumUnits
		{
			get 
			{ 
                return _currentNumUnitsNonDefault;
			}
			set 
			{
            
                _currentNumUnitsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "PROPOSED_NUM_ROOMS" field.  
		/// </summary>
		public int? ProposedNumRooms
		{
			get 
			{ 
                return _proposedNumRoomsNonDefault;
			}
			set 
			{
            
                _proposedNumRoomsNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "SUBSTANCE_ABUSE_TYPE" field. Length must be between 0 and 2 characters. 
		/// </summary>
		public string SubstanceAbuseType
		{
			get 
			{ 
                if(_substanceAbuseTypeNonDefault==null)return _substanceAbuseTypeNonDefault;
				else return _substanceAbuseTypeNonDefault.Replace("''", "'"); 
			}
			set 
			{
                if (value != null && value.Length > 2)
					throw new ArgumentException("SubstanceAbuseType length must be between 0 and 2 characters.");

				
                if(value ==null)
                {
                    _substanceAbuseTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _substanceAbuseTypeNonDefault = value.Replace("'", "''"); 
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
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
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
              
			// Pass the value of '_capacityType' as parameter 'CapacityType' of the stored procedure.
			if(_capacityTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityType", _capacityTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityType", DBNull.Value );
              
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
              
			// Pass the value of '_capacityCount' as parameter 'CapacityCount' of the stored procedure.
			if(_capacityCountNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityCount", _capacityCountNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityCount", DBNull.Value );
              
			// Pass the value of '_bedsUnit' as parameter 'BedsUnit' of the stored procedure.
			if(_bedsUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsUnit", _bedsUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsUnit", DBNull.Value );
              
			// Pass the value of '_bedsType' as parameter 'BedsType' of the stored procedure.
			if(_bedsTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsType", _bedsTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsType", DBNull.Value );
              
			// Pass the value of '_bedsFloor' as parameter 'BedsFloor' of the stored procedure.
			if(_bedsFloorNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsFloor", _bedsFloorNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsFloor", DBNull.Value );
              
			// Pass the value of '_bedsRoomNumber' as parameter 'BedsRoomNumber' of the stored procedure.
			if(_bedsRoomNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsRoomNumber", _bedsRoomNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsRoomNumber", DBNull.Value );
              
			// Pass the value of '_bedsRoomSizeMet' as parameter 'BedsRoomSizeMet' of the stored procedure.
			if(_bedsRoomSizeMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsRoomSizeMet", _bedsRoomSizeMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsRoomSizeMet", DBNull.Value );
              
			// Pass the value of '_bedsCallSystemMet' as parameter 'BedsCallSystemMet' of the stored procedure.
			if(_bedsCallSystemMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsCallSystemMet", _bedsCallSystemMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsCallSystemMet", DBNull.Value );
              
			// Pass the value of '_bedsFurnitureMet' as parameter 'BedsFurnitureMet' of the stored procedure.
			if(_bedsFurnitureMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsFurnitureMet", _bedsFurnitureMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsFurnitureMet", DBNull.Value );
              
			// Pass the value of '_bedsPrivacyMet' as parameter 'BedsPrivacyMet' of the stored procedure.
			if(_bedsPrivacyMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsPrivacyMet", _bedsPrivacyMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsPrivacyMet", DBNull.Value );
              
			// Pass the value of '_bedsComment' as parameter 'BedsComment' of the stored procedure.
			if(_bedsCommentNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsComment", _bedsCommentNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsComment", DBNull.Value );
              
			// Pass the value of '_currentNumRooms' as parameter 'CurrentNumRooms' of the stored procedure.
			if(_currentNumRoomsNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentNumRooms", _currentNumRoomsNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentNumRooms", DBNull.Value );
              
			// Pass the value of '_currentNumUnits' as parameter 'CurrentNumUnits' of the stored procedure.
			if(_currentNumUnitsNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentNumUnits", _currentNumUnitsNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentNumUnits", DBNull.Value );
              
			// Pass the value of '_proposedNumRooms' as parameter 'ProposedNumRooms' of the stored procedure.
			if(_proposedNumRoomsNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProposedNumRooms", _proposedNumRoomsNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProposedNumRooms", DBNull.Value );
              
			// Pass the value of '_substanceAbuseType' as parameter 'SubstanceAbuseType' of the stored procedure.
			if(_substanceAbuseTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubstanceAbuseType", _substanceAbuseTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubstanceAbuseType", DBNull.Value );
              
			// Pass the value of '_census' as parameter 'Census' of the stored procedure.
			if(_censusNonDefault!=null)
              oDatabaseHelper.AddParameter("@Census", _censusNonDefault);
            else
              oDatabaseHelper.AddParameter("@Census", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_CAPACITIES_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
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
			// Pass the value of '_capacityType' as parameter 'CapacityType' of the stored procedure.
			if(_capacityTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityType", _capacityTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityType", DBNull.Value );
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			if(_affiliationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@AffiliationID", DBNull.Value );
			// Pass the value of '_capacityCount' as parameter 'CapacityCount' of the stored procedure.
			if(_capacityCountNonDefault!=null)
              oDatabaseHelper.AddParameter("@CapacityCount", _capacityCountNonDefault);
            else
              oDatabaseHelper.AddParameter("@CapacityCount", DBNull.Value );
			// Pass the value of '_bedsUnit' as parameter 'BedsUnit' of the stored procedure.
			if(_bedsUnitNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsUnit", _bedsUnitNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsUnit", DBNull.Value );
			// Pass the value of '_bedsType' as parameter 'BedsType' of the stored procedure.
			if(_bedsTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsType", _bedsTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsType", DBNull.Value );
			// Pass the value of '_bedsFloor' as parameter 'BedsFloor' of the stored procedure.
			if(_bedsFloorNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsFloor", _bedsFloorNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsFloor", DBNull.Value );
			// Pass the value of '_bedsRoomNumber' as parameter 'BedsRoomNumber' of the stored procedure.
			if(_bedsRoomNumberNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsRoomNumber", _bedsRoomNumberNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsRoomNumber", DBNull.Value );
			// Pass the value of '_bedsRoomSizeMet' as parameter 'BedsRoomSizeMet' of the stored procedure.
			if(_bedsRoomSizeMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsRoomSizeMet", _bedsRoomSizeMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsRoomSizeMet", DBNull.Value );
			// Pass the value of '_bedsCallSystemMet' as parameter 'BedsCallSystemMet' of the stored procedure.
			if(_bedsCallSystemMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsCallSystemMet", _bedsCallSystemMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsCallSystemMet", DBNull.Value );
			// Pass the value of '_bedsFurnitureMet' as parameter 'BedsFurnitureMet' of the stored procedure.
			if(_bedsFurnitureMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsFurnitureMet", _bedsFurnitureMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsFurnitureMet", DBNull.Value );
			// Pass the value of '_bedsPrivacyMet' as parameter 'BedsPrivacyMet' of the stored procedure.
			if(_bedsPrivacyMetNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsPrivacyMet", _bedsPrivacyMetNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsPrivacyMet", DBNull.Value );
			// Pass the value of '_bedsComment' as parameter 'BedsComment' of the stored procedure.
			if(_bedsCommentNonDefault!=null)
              oDatabaseHelper.AddParameter("@BedsComment", _bedsCommentNonDefault);
            else
              oDatabaseHelper.AddParameter("@BedsComment", DBNull.Value );
			// Pass the value of '_currentNumRooms' as parameter 'CurrentNumRooms' of the stored procedure.
			if(_currentNumRoomsNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentNumRooms", _currentNumRoomsNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentNumRooms", DBNull.Value );
			// Pass the value of '_currentNumUnits' as parameter 'CurrentNumUnits' of the stored procedure.
			if(_currentNumUnitsNonDefault!=null)
              oDatabaseHelper.AddParameter("@CurrentNumUnits", _currentNumUnitsNonDefault);
            else
              oDatabaseHelper.AddParameter("@CurrentNumUnits", DBNull.Value );
			// Pass the value of '_proposedNumRooms' as parameter 'ProposedNumRooms' of the stored procedure.
			if(_proposedNumRoomsNonDefault!=null)
              oDatabaseHelper.AddParameter("@ProposedNumRooms", _proposedNumRoomsNonDefault);
            else
              oDatabaseHelper.AddParameter("@ProposedNumRooms", DBNull.Value );
			// Pass the value of '_substanceAbuseType' as parameter 'SubstanceAbuseType' of the stored procedure.
			if(_substanceAbuseTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@SubstanceAbuseType", _substanceAbuseTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@SubstanceAbuseType", DBNull.Value );
			// Pass the value of '_census' as parameter 'Census' of the stored procedure.
			if(_censusNonDefault!=null)
              oDatabaseHelper.AddParameter("@Census", _censusNonDefault);
            else
              oDatabaseHelper.AddParameter("@Census", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CAPACITIES_Insert", ref ExecutionState);
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
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_capacityID' as parameter 'CapacityID' of the stored procedure.
			oDatabaseHelper.AddParameter("@CapacityID", _capacityIDNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_capacityType' as parameter 'CapacityType' of the stored procedure.
			oDatabaseHelper.AddParameter("@CapacityType", _capacityTypeNonDefault );
            
			// Pass the value of '_affiliationID' as parameter 'AffiliationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@AffiliationID", _affiliationIDNonDefault );
            
			// Pass the value of '_capacityCount' as parameter 'CapacityCount' of the stored procedure.
			oDatabaseHelper.AddParameter("@CapacityCount", _capacityCountNonDefault );
            
			// Pass the value of '_bedsUnit' as parameter 'BedsUnit' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsUnit", _bedsUnitNonDefault );
            
			// Pass the value of '_bedsType' as parameter 'BedsType' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsType", _bedsTypeNonDefault );
            
			// Pass the value of '_bedsFloor' as parameter 'BedsFloor' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsFloor", _bedsFloorNonDefault );
            
			// Pass the value of '_bedsRoomNumber' as parameter 'BedsRoomNumber' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsRoomNumber", _bedsRoomNumberNonDefault );
            
			// Pass the value of '_bedsRoomSizeMet' as parameter 'BedsRoomSizeMet' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsRoomSizeMet", _bedsRoomSizeMetNonDefault );
            
			// Pass the value of '_bedsCallSystemMet' as parameter 'BedsCallSystemMet' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsCallSystemMet", _bedsCallSystemMetNonDefault );
            
			// Pass the value of '_bedsFurnitureMet' as parameter 'BedsFurnitureMet' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsFurnitureMet", _bedsFurnitureMetNonDefault );
            
			// Pass the value of '_bedsPrivacyMet' as parameter 'BedsPrivacyMet' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsPrivacyMet", _bedsPrivacyMetNonDefault );
            
			// Pass the value of '_bedsComment' as parameter 'BedsComment' of the stored procedure.
			oDatabaseHelper.AddParameter("@BedsComment", _bedsCommentNonDefault );
            
			// Pass the value of '_currentNumRooms' as parameter 'CurrentNumRooms' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentNumRooms", _currentNumRoomsNonDefault );
            
			// Pass the value of '_currentNumUnits' as parameter 'CurrentNumUnits' of the stored procedure.
			oDatabaseHelper.AddParameter("@CurrentNumUnits", _currentNumUnitsNonDefault );
            
			// Pass the value of '_proposedNumRooms' as parameter 'ProposedNumRooms' of the stored procedure.
			oDatabaseHelper.AddParameter("@ProposedNumRooms", _proposedNumRoomsNonDefault );
            
			// Pass the value of '_substanceAbuseType' as parameter 'SubstanceAbuseType' of the stored procedure.
			oDatabaseHelper.AddParameter("@SubstanceAbuseType", _substanceAbuseTypeNonDefault );
            
			// Pass the value of '_census' as parameter 'Census' of the stored procedure.
			oDatabaseHelper.AddParameter("@Census", _censusNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CAPACITIES_Update", ref ExecutionState);
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
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_capacityID' as parameter 'CapacityID' of the stored procedure.
			if(_capacityIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@CapacityID", _capacityIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@CapacityID", DBNull.Value );
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_CAPACITIES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_CapacityPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_CapacityPrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_CAPACITIES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_CapacityFields">Field of the class BO_Capacity</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_CAPACITIES_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_CapacityPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Capacity</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Capacity SelectOne(BO_CapacityPrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Capacity obj=new BO_Capacity();	
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
		/// <returns>list of objects of class BO_Capacity in the form of object of BO_Capacities </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Capacities SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_SelectAll", ref ExecutionState);
			BO_Capacities BO_Capacities = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Capacities;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Capacity</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Capacity in the form of an object of class BO_Capacities</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Capacities SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_SelectByField", ref ExecutionState);
			BO_Capacities BO_Capacities = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Capacities;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Capacities</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Capacities SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Capacities obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Capacities();
			obj = BO_Capacity.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/23/2016 2:17:36 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_CAPACITIES_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_Capacities</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Capacities SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Capacities obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Capacities();
			obj = BO_Capacity.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/23/2016 2:17:36 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_CAPACITIES_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
			oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}



		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="AFFILIATIONPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Capacities</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Capacities SelectAllByForeignKeyAffiliationID(BO_AffiliationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Capacities obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_CAPACITIES_SelectAllByForeignKeyAffiliationID", ref ExecutionState);
			obj = new BO_Capacities();
			obj = BO_Capacity.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			06/23/2016 2:17:36 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_CAPACITIES_DeleteAllByForeignKeyAffiliationID", ref ExecutionState);
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
	    /// DLGenerator			06/23/2016 2:17:36 PM		Created function
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
		/// <param name="obj" type="CAPACITIES">Object of CAPACITIES to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_CapacityBase obj,IDataReader rdr) 
		{

			obj.CapacityID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CapacityFields.CapacityID)));
			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CapacityFields.PopsIntID)));
			obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CapacityFields.ApplicationID)));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.CapacityType)))
			{
				obj.CapacityType = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.CapacityType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.AffiliationID)))
			{
				obj.AffiliationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_CapacityFields.AffiliationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.CapacityCount)))
			{
				obj.CapacityCount = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.CapacityCount));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsUnit)))
			{
				obj.BedsUnit = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.BedsUnit));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsType)))
			{
				obj.BedsType = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.BedsType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsFloor)))
			{
				obj.BedsFloor = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.BedsFloor));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsRoomNumber)))
			{
				obj.BedsRoomNumber = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.BedsRoomNumber));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsRoomSizeMet)))
			{
				obj.BedsRoomSizeMet = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.BedsRoomSizeMet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsCallSystemMet)))
			{
				obj.BedsCallSystemMet = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.BedsCallSystemMet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsFurnitureMet)))
			{
				obj.BedsFurnitureMet = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.BedsFurnitureMet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsPrivacyMet)))
			{
				obj.BedsPrivacyMet = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.BedsPrivacyMet));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.BedsComment)))
			{
				obj.BedsComment = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.BedsComment));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.CurrentNumRooms)))
			{
				obj.CurrentNumRooms = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.CurrentNumRooms));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.CurrentNumUnits)))
			{
				obj.CurrentNumUnits = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.CurrentNumUnits));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.ProposedNumRooms)))
			{
				obj.ProposedNumRooms = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.ProposedNumRooms));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.SubstanceAbuseType)))
			{
				obj.SubstanceAbuseType = rdr.GetString(rdr.GetOrdinal(BO_CapacityFields.SubstanceAbuseType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_CapacityFields.Census)))
			{
				obj.Census = rdr.GetInt32(rdr.GetOrdinal(BO_CapacityFields.Census));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Capacities</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Capacities PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Capacities list = new BO_Capacities();
			
			while (rdr.Read())
			{
				BO_Capacity obj = new BO_Capacity();
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
		/// <returns>Object of BO_Capacities</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			06/23/2016 2:17:36 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Capacities PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Capacities list = new BO_Capacities();
			
            if (rdr.Read())
            {
                BO_Capacity obj = new BO_Capacity();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Capacity();
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
