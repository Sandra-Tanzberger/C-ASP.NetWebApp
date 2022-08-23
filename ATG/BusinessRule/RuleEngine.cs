using System;
using System.Data;
using System.Data.Common;
using ATG.BusinessRule;
using ATG.BusinessObject;

namespace ATG.BusinessRule
{
    public enum RESULT_TYPE
    {
        STRING,
        BOOLEAN,
        NUMBER
    }

    public class RuleEngine
    {
        private RuleSet _m_RlSet;
        
        public String strResult;
        public Boolean boolResult;
        public int intResult;

        public RuleEngine()
        {
            _m_RlSet = new RuleSet();
        }

        public RESULT_TYPE EvaluateRuleSet( int inRuleSetID )
        {
            int iNextRuleID = 0;
        	// start the main processing loop.
	        //_m_RlSet.fillRuleSet( inRuleSetID );
            
            //String tst = _m_RlSet.BuildRule( 2 );

            //foreach ( DataRow rowApp in _m_RlSet. )
            //{        	
            //    EXEC [dbo].[EVAL_RULE]  @iRuleID, @inTmpID, @ruleResultVal output
            //    SET @iNextRuleID = NULL;
        		
            //    IF ( @iRuleResultType = 1 )
            //        BEGIN
            //            IF ( @iResultActionTrue IS NULL AND @ruleResultVal = 'T' )
            //                SET @retVal = @ruleResultVal
        				
            //            IF ( @iResultActionFalse IS NULL AND @ruleResultVal = 'F' )
            //                SET @retVal = @ruleResultVal
        				
            //            IF ( @iResultActionTrue IS NOT NULL AND @ruleResultVal = 'T' )
            //                SET @iNextRuleID = @iNextRuleIdTrue
        				
            //            IF ( @iResultActionFalse IS NOT NULL AND @ruleResultVal = 'F' )
            //                SET @iNextRuleID = @iNextRuleIdFalse
        					
            //        END
            //    ELSE IF ( @iRuleResultType = 2 ) -- Calculation Type only result action true and next rule id true are evaluated		
            //        BEGIN
            //            IF ( @iResultActionTrue IS NULL )
            //                SET @retVal = @ruleResultVal
        				
            //            IF ( @iResultActionTrue IS NOT NULL )
            //                SET @iNextRuleID = @iNextRuleIdTrue
            //        END

            //    IF ( @iNextRuleID IS NOT NULL )
            //        -- Get the next row.
            //        SELECT @iRuleSetID = RL_SET_ID
            //                , @iRuleID = RL_ID
            //                , @iResultActionTrue = RSLT_ACTN_TRUE		-- 1 = Rule, 2 = Calculation
            //                , @iResultActionFalse = RSLT_ACTN_FALSE		-- 1 = Rule, 2 = Calculation
            //                , @iNextRuleIdTrue = NXT_RL_ID_TRUE
            //                , @iNextRuleIdFalse = NXT_RL_ID_FALSE
            //                , @iRuleResultType = RL_RSLT_TYP			-- 1 = Rule, 2 = Calculation
            //           FROM RL_SET
            //          WHERE RL_SET_ID = @inRuleSetID
            //            AND RL_ID = @iNextRuleID 
            //            AND RL_SET_BEGIN = 0
            //    ELSE
            //        BREAK              
        	
            //END
           // }
            return RESULT_TYPE.STRING;
        }

        public void EvaluateRule()
        {
            String RuleString = _m_RlSet.BuildRule(1);
        }
    }
}
