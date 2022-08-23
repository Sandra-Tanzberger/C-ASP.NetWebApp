//
// Class	:	BO_MessageBase.cs
// Author	:  	Ignyte Software © 2006 (DLG 1.5.64)
// Date		:	01/19/2012 12:30:20 PM
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
	public class BO_MessageFields
	{
		public const string MessageID                 = "MESSAGE_ID";
		public const string MessageDate               = "MESSAGE_DATE";
		public const string ApplicationID             = "APPLICATION_ID";
		public const string MessageType               = "MESSAGE_TYPE";
		public const string MessageText               = "MESSAGE_TEXT";
		public const string PopsIntID                 = "POPS_INT_ID";
		public const string MessageDirection          = "MESSAGE_DIRECTION";
		public const string MessageDeliveryStatus     = "MESSAGE_DELIVERY_STATUS";
		public const string MessageSendType           = "MESSAGE_SEND_TYPE";
		public const string ReferenceID               = "REFERENCE_ID";
		public const string ReferenceIdType           = "REFERENCE_ID_TYPE";
		public const string MessageFailureCode        = "MESSAGE_FAILURE_CODE";
		public const string MessageSubject            = "MESSAGE_SUBJECT";
		public const string MessagePrintDate          = "MESSAGE_PRINT_DATE";
	}
	
	/// <summary>
	/// Data access class for the "MESSAGES" table.
	/// </summary>
	[Serializable]
	public class BO_MessageBase
	{
		
		#region Class Level Variables
		
		//private DatabaseHelper oDatabaseHelper = new DatabaseHelper();

		private decimal?       	_messageIDNonDefault     	= null;
		private DateTime?      	_messageDateNonDefault   	= null;
		private decimal?       	_applicationIDNonDefault 	= null;
		private string         	_messageTypeNonDefault   	= null;
		private string         	_messageTextNonDefault   	= null;
		private decimal?       	_popsIntIDNonDefault     	= null;
		private string         	_messageDirectionNonDefault	= null;
		private string         	_messageDeliveryStatusNonDefault	= null;
		private string         	_messageSendTypeNonDefault	= null;
		private int?           	_referenceIDNonDefault   	= null;
		private string         	_referenceIdTypeNonDefault	= null;
		private string         	_messageFailureCodeNonDefault	= null;
		private string         	_messageSubjectNonDefault	= null;
		private DateTime?      	_messagePrintDateNonDefault	= null;
		
		#endregion
		
		#region Constants
		
		#endregion
    
		#region Constructors / Destructors

		/// <summary>
		/// Class Constructor
		///</summary>
		public BO_MessageBase() { }
					
		#endregion
		
		#region Properties

		/// <summary>
		/// Returns the identifier of the persistent object. Don't set it manually!
		/// </summary>
		public decimal? MessageID
		{
			get 
			{ 
                return _messageIDNonDefault;
			}
			set 
			{
            
                _messageIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_DATE" field.  Mandatory.
		/// </summary>
		public DateTime? MessageDate
		{
			get 
			{ 
                return _messageDateNonDefault;
			}
			set 
			{
            
                _messageDateNonDefault = value; 
			}
		}

		/// <summary>
		/// The foreign key connected with another persistent object.
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
		/// This property is mapped to the "MESSAGE_TYPE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string MessageType
		{
			get 
			{ 
                if(_messageTypeNonDefault==null)return _messageTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("MessageType length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _messageTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _messageTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_TEXT" field. Length must be between 0 and 2147483647 characters. 
		/// </summary>
		public string MessageText
		{
			get 
			{ 
                if(_messageTextNonDefault==null)return _messageTextNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageTextNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 2147483647)
					throw new ArgumentException("MessageText length must be between 0 and 2147483647 characters.");

				
                if(value ==null)
                {
                    _messageTextNonDefault =null;//null value 
                }
                else
                {		           
		            _messageTextNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
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
		/// This property is mapped to the "MESSAGE_DIRECTION" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string MessageDirection
		{
			get 
			{ 
                if(_messageDirectionNonDefault==null)return _messageDirectionNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageDirectionNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("MessageDirection length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _messageDirectionNonDefault =null;//null value 
                }
                else
                {		           
		            _messageDirectionNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_DELIVERY_STATUS" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string MessageDeliveryStatus
		{
			get 
			{ 
                if(_messageDeliveryStatusNonDefault==null)return _messageDeliveryStatusNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageDeliveryStatusNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("MessageDeliveryStatus length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _messageDeliveryStatusNonDefault =null;//null value 
                }
                else
                {		           
		            _messageDeliveryStatusNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_SEND_TYPE" field. Length must be between 0 and 5 characters. Mandatory.
		/// </summary>
		public string MessageSendType
		{
			get 
			{ 
                if(_messageSendTypeNonDefault==null)return _messageSendTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageSendTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 5)
					throw new ArgumentException("MessageSendType length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _messageSendTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _messageSendTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "REFERENCE_ID" field.  Mandatory.
		/// </summary>
		public int? ReferenceID
		{
			get 
			{ 
                return _referenceIDNonDefault;
			}
			set 
			{
            
                _referenceIDNonDefault = value; 
			}
		}

		/// <summary>
		/// This property is mapped to the "REFERENCE_ID_TYPE" field. Length must be between 0 and 10 characters. Mandatory.
		/// </summary>
		public string ReferenceIdType
		{
			get 
			{ 
                if(_referenceIdTypeNonDefault==null)return _referenceIdTypeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _referenceIdTypeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value == null)
					throw new ArgumentNullException("value", "Value is null.");
				   if (value != null && value.Length > 10)
					throw new ArgumentException("ReferenceIdType length must be between 0 and 10 characters.");

				
                if(value ==null)
                {
                    _referenceIdTypeNonDefault =null;//null value 
                }
                else
                {		           
		            _referenceIdTypeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_FAILURE_CODE" field. Length must be between 0 and 5 characters. 
		/// </summary>
		public string MessageFailureCode
		{
			get 
			{ 
                if(_messageFailureCodeNonDefault==null)return _messageFailureCodeNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageFailureCodeNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 5)
					throw new ArgumentException("MessageFailureCode length must be between 0 and 5 characters.");

				
                if(value ==null)
                {
                    _messageFailureCodeNonDefault =null;//null value 
                }
                else
                {		           
		            _messageFailureCodeNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_SUBJECT" field. Length must be between 0 and 128 characters. 
		/// </summary>
		public string MessageSubject
		{
			get 
			{ 
                if(_messageSubjectNonDefault==null)return _messageSubjectNonDefault;
				      else {
                    string retVal = "";
                    retVal = Regex.Replace( _messageSubjectNonDefault, "'{2,}", "'" );
                    return retVal;
                    }
			}
			set 
			{
                if (value != null && value.Length > 128)
					throw new ArgumentException("MessageSubject length must be between 0 and 128 characters.");

				
                if(value ==null)
                {
                    _messageSubjectNonDefault =null;//null value 
                }
                else
                {		           
		            _messageSubjectNonDefault = Regex.Replace( value, "'{2,}", "'" ); 
                }
			}
		}

		/// <summary>
		/// This property is mapped to the "MESSAGE_PRINT_DATE" field.  
		/// </summary>
		public DateTime? MessagePrintDate
		{
			get 
			{ 
                return _messagePrintDateNonDefault;
			}
			set 
			{
            
                _messagePrintDateNonDefault = value; 
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool InsertWithDefaultValues(bool getBackValues) 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_messageDate' as parameter 'MessageDate' of the stored procedure.
			if(_messageDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageDate", _messageDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageDate", DBNull.Value );
              
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
              
			// Pass the value of '_messageType' as parameter 'MessageType' of the stored procedure.
			if(_messageTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageType", _messageTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageType", DBNull.Value );
              
			// Pass the value of '_messageText' as parameter 'MessageText' of the stored procedure.
			if(_messageTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageText", _messageTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageText", DBNull.Value );
              
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
              
			// Pass the value of '_messageDirection' as parameter 'MessageDirection' of the stored procedure.
			if(_messageDirectionNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageDirection", _messageDirectionNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageDirection", DBNull.Value );
              
			// Pass the value of '_messageDeliveryStatus' as parameter 'MessageDeliveryStatus' of the stored procedure.
			if(_messageDeliveryStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageDeliveryStatus", _messageDeliveryStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageDeliveryStatus", DBNull.Value );
              
			// Pass the value of '_messageSendType' as parameter 'MessageSendType' of the stored procedure.
			if(_messageSendTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageSendType", _messageSendTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageSendType", DBNull.Value );
              
			// Pass the value of '_referenceID' as parameter 'ReferenceID' of the stored procedure.
			if(_referenceIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReferenceID", _referenceIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReferenceID", DBNull.Value );
              
			// Pass the value of '_referenceIdType' as parameter 'ReferenceIdType' of the stored procedure.
			if(_referenceIdTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReferenceIdType", _referenceIdTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReferenceIdType", DBNull.Value );
              
			// Pass the value of '_messageFailureCode' as parameter 'MessageFailureCode' of the stored procedure.
			if(_messageFailureCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageFailureCode", _messageFailureCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageFailureCode", DBNull.Value );
              
			// Pass the value of '_messageSubject' as parameter 'MessageSubject' of the stored procedure.
			if(_messageSubjectNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageSubject", _messageSubjectNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageSubject", DBNull.Value );
              
			// Pass the value of '_messagePrintDate' as parameter 'MessagePrintDate' of the stored procedure.
			if(_messagePrintDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessagePrintDate", _messagePrintDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessagePrintDate", DBNull.Value );
              
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			if(!getBackValues )
			{
				oDatabaseHelper.ExecuteScalar("GEN_MESSAGES_Insert_WithDefaultValues", ref ExecutionState);
			}
			else
			{
				IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGES_Insert_WithDefaultValues_AndReturn", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Insert() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_messageDate' as parameter 'MessageDate' of the stored procedure.
			if(_messageDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageDate", _messageDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageDate", DBNull.Value );
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			if(_applicationIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ApplicationID", DBNull.Value );
			// Pass the value of '_messageType' as parameter 'MessageType' of the stored procedure.
			if(_messageTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageType", _messageTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageType", DBNull.Value );
			// Pass the value of '_messageText' as parameter 'MessageText' of the stored procedure.
			if(_messageTextNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageText", _messageTextNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageText", DBNull.Value );
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			if(_popsIntIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@PopsIntID", DBNull.Value );
			// Pass the value of '_messageDirection' as parameter 'MessageDirection' of the stored procedure.
			if(_messageDirectionNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageDirection", _messageDirectionNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageDirection", DBNull.Value );
			// Pass the value of '_messageDeliveryStatus' as parameter 'MessageDeliveryStatus' of the stored procedure.
			if(_messageDeliveryStatusNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageDeliveryStatus", _messageDeliveryStatusNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageDeliveryStatus", DBNull.Value );
			// Pass the value of '_messageSendType' as parameter 'MessageSendType' of the stored procedure.
			if(_messageSendTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageSendType", _messageSendTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageSendType", DBNull.Value );
			// Pass the value of '_referenceID' as parameter 'ReferenceID' of the stored procedure.
			if(_referenceIDNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReferenceID", _referenceIDNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReferenceID", DBNull.Value );
			// Pass the value of '_referenceIdType' as parameter 'ReferenceIdType' of the stored procedure.
			if(_referenceIdTypeNonDefault!=null)
              oDatabaseHelper.AddParameter("@ReferenceIdType", _referenceIdTypeNonDefault);
            else
              oDatabaseHelper.AddParameter("@ReferenceIdType", DBNull.Value );
			// Pass the value of '_messageFailureCode' as parameter 'MessageFailureCode' of the stored procedure.
			if(_messageFailureCodeNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageFailureCode", _messageFailureCodeNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageFailureCode", DBNull.Value );
			// Pass the value of '_messageSubject' as parameter 'MessageSubject' of the stored procedure.
			if(_messageSubjectNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessageSubject", _messageSubjectNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessageSubject", DBNull.Value );
			// Pass the value of '_messagePrintDate' as parameter 'MessagePrintDate' of the stored procedure.
			if(_messagePrintDateNonDefault!=null)
              oDatabaseHelper.AddParameter("@MessagePrintDate", _messagePrintDateNonDefault);
            else
              oDatabaseHelper.AddParameter("@MessagePrintDate", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGES_Insert", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Update() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_messageID' as parameter 'MessageID' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageID", _messageIDNonDefault );
            
			// Pass the value of '_messageDate' as parameter 'MessageDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageDate", _messageDateNonDefault );
            
			// Pass the value of '_applicationID' as parameter 'ApplicationID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ApplicationID", _applicationIDNonDefault );
            
			// Pass the value of '_messageType' as parameter 'MessageType' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageType", _messageTypeNonDefault );
            
			// Pass the value of '_messageText' as parameter 'MessageText' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageText", _messageTextNonDefault );
            
			// Pass the value of '_popsIntID' as parameter 'PopsIntID' of the stored procedure.
			oDatabaseHelper.AddParameter("@PopsIntID", _popsIntIDNonDefault );
            
			// Pass the value of '_messageDirection' as parameter 'MessageDirection' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageDirection", _messageDirectionNonDefault );
            
			// Pass the value of '_messageDeliveryStatus' as parameter 'MessageDeliveryStatus' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageDeliveryStatus", _messageDeliveryStatusNonDefault );
            
			// Pass the value of '_messageSendType' as parameter 'MessageSendType' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageSendType", _messageSendTypeNonDefault );
            
			// Pass the value of '_referenceID' as parameter 'ReferenceID' of the stored procedure.
			oDatabaseHelper.AddParameter("@ReferenceID", _referenceIDNonDefault );
            
			// Pass the value of '_referenceIdType' as parameter 'ReferenceIdType' of the stored procedure.
			oDatabaseHelper.AddParameter("@ReferenceIdType", _referenceIdTypeNonDefault );
            
			// Pass the value of '_messageFailureCode' as parameter 'MessageFailureCode' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageFailureCode", _messageFailureCodeNonDefault );
            
			// Pass the value of '_messageSubject' as parameter 'MessageSubject' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessageSubject", _messageSubjectNonDefault );
            
			// Pass the value of '_messagePrintDate' as parameter 'MessagePrintDate' of the stored procedure.
			oDatabaseHelper.AddParameter("@MessagePrintDate", _messagePrintDateNonDefault );
            
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGES_Update", ref ExecutionState);
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
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public bool Delete() 
		{

			bool ExecutionState = false;
			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
			
			// Pass the value of '_messageID' as parameter 'MessageID' of the stored procedure.
			if(_messageIDNonDefault!=null)
                oDatabaseHelper.AddParameter("@MessageID", _messageIDNonDefault );
            else
                oDatabaseHelper.AddParameter("@MessageID", DBNull.Value );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete one row from the database using the primary key information
		/// </summary>
		///
		/// <param name="pk" type="BO_MessagePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static bool Delete(BO_MessagePrimaryKey pk) 
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGES_Delete", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will Delete row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="BO_MessageFields">Field of the class BO_Message</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>True if succeeded</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:19 PM		Created function
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
			
			oDatabaseHelper.ExecuteScalar("GEN_MESSAGES_DeleteByField", ref ExecutionState);
            oDatabaseHelper.Dispose();
			return ExecutionState;
			
		}

		/// <summary>
		/// This method will return an object representing the record matching the primary key information specified.
		/// </summary>
		///
		/// <param name="pk" type="BO_MessagePrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Message</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Message SelectOne(BO_MessagePrimaryKey pk)
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
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGES_SelectbyPrimaryKey", ref ExecutionState);
			if (dr.Read())
			{
				BO_Message obj=new BO_Message();	
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
		/// <returns>list of objects of class BO_Message in the form of object of BO_Messages </returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Messages SelectAll()
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGES_SelectAll", ref ExecutionState);
			BO_Messages BO_Messages = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Messages;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified
		/// </summary>
		///
		/// <param name="field" type="string">Field of the class BO_Message</param>
		/// <param name="fieldValue" type="object">Value for the field specified.</param>
		///
		/// <returns>List of object of class BO_Message in the form of an object of class BO_Messages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Messages SelectByField(string field, object fieldValue)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			
			
			// Pass the specified field and its value to the stored procedure.
			oDatabaseHelper.AddParameter("@Field",field);
			oDatabaseHelper.AddParameter("@Value", fieldValue );
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGES_SelectByField", ref ExecutionState);
			BO_Messages BO_Messages = PopulateObjectsFromReader(dr);
            dr.Close();
            oDatabaseHelper.Dispose();
            return BO_Messages;
			
		}

		/// <summary>
		/// This method will get row(s) from the database using the value of the field specified 
		/// along with the details of the child table.
		/// </summary>
		///
		/// <param name="pk" type="APPLICATIONSPrimaryKey">Primary Key information based on which data is to be fetched.</param>
		///
		/// <returns>object of class BO_Messages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Messages SelectAllByForeignKeyApplicationID(BO_ApplicationPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Messages obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGES_SelectAllByForeignKeyApplicationID", ref ExecutionState);
			obj = new BO_Messages();
			obj = BO_Message.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_MESSAGES_DeleteAllByForeignKeyApplicationID", ref ExecutionState);
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
		/// <returns>object of class BO_Messages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		public static BO_Messages SelectAllByForeignKeyPopsIntID(BO_ProviderPrimaryKey pk)
		{

			DatabaseHelper oDatabaseHelper = new DatabaseHelper();
            bool ExecutionState = false;
			BO_Messages obj = null;
			
			// Pass the values of all key parameters to the stored procedure.
			System.Collections.Specialized.NameValueCollection nvc = pk.GetKeysAndValues();
			foreach (string key in nvc.Keys)
			{
				oDatabaseHelper.AddParameter("@" + key,nvc[key] );
			}
			
			// The parameter '@ErrorCode' will contain the status after execution of the stored procedure.
			oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
			
			IDataReader dr=oDatabaseHelper.ExecuteReader("GEN_MESSAGES_SelectAllByForeignKeyPopsIntID", ref ExecutionState);
			obj = new BO_Messages();
			obj = BO_Message.PopulateObjectsFromReaderWithCheckingReader(dr, oDatabaseHelper);
			
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
		/// DLGenerator			01/19/2012 12:30:20 PM				Created function
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
			
			oDatabaseHelper.ExecuteNonQuery("GEN_MESSAGES_DeleteAllByForeignKeyPopsIntID", ref ExecutionState);
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
	    /// DLGenerator			01/19/2012 12:30:20 PM		Created function
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
		/// <param name="obj" type="MESSAGES">Object of MESSAGES to populate</param>
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static void PopulateObjectFromReader(BO_MessageBase obj,IDataReader rdr) 
		{

			obj.MessageID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MessageFields.MessageID)));
			obj.MessageDate = rdr.GetDateTime(rdr.GetOrdinal(BO_MessageFields.MessageDate));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageFields.ApplicationID)))
			{
				obj.ApplicationID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MessageFields.ApplicationID)));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageFields.MessageType)))
			{
				obj.MessageType = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageType));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageFields.MessageText)))
			{
				obj.MessageText = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageText));
			}
			
			obj.PopsIntID = Convert.ToDecimal(rdr.GetValue(rdr.GetOrdinal(BO_MessageFields.PopsIntID)));
			obj.MessageDirection = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageDirection));
			obj.MessageDeliveryStatus = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageDeliveryStatus));
			obj.MessageSendType = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageSendType));
			obj.ReferenceID = rdr.GetInt32(rdr.GetOrdinal(BO_MessageFields.ReferenceID));
			obj.ReferenceIdType = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.ReferenceIdType));
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageFields.MessageFailureCode)))
			{
				obj.MessageFailureCode = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageFailureCode));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageFields.MessageSubject)))
			{
				obj.MessageSubject = rdr.GetString(rdr.GetOrdinal(BO_MessageFields.MessageSubject));
			}
			
			if (!rdr.IsDBNull(rdr.GetOrdinal(BO_MessageFields.MessagePrintDate)))
			{
				obj.MessagePrintDate = rdr.GetDateTime(rdr.GetOrdinal(BO_MessageFields.MessagePrintDate));
			}
			

		}

		/// <summary>
        /// Populates the fields for multiple objects from the columns found in an open reader.
        /// </summary>
		///
        /// <param name="rdr" type="IDataReader">An object that implements the IDataReader interface</param>
		///
		/// <returns>Object of BO_Messages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Messages PopulateObjectsFromReader(IDataReader rdr) 
		{

			BO_Messages list = new BO_Messages();
			
			while (rdr.Read())
			{
				BO_Message obj = new BO_Message();
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
		/// <returns>Object of BO_Messages</returns>
		///
		/// <remarks>
		///
		/// <RevisionHistory>
		/// Author				Date			Description
		/// DLGenerator			01/19/2012 12:30:20 PM		Created function
		/// 
		/// </RevisionHistory>
		///
		/// </remarks>
		///
		internal static BO_Messages PopulateObjectsFromReaderWithCheckingReader(IDataReader rdr, DatabaseHelper oDatabaseHelper) 
		{

			BO_Messages list = new BO_Messages();
			
            if (rdr.Read())
            {
                BO_Message obj = new BO_Message();
                PopulateObjectFromReader(obj, rdr);
                list.Add(obj);
                while (rdr.Read())
                {
                    obj = new BO_Message();
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
