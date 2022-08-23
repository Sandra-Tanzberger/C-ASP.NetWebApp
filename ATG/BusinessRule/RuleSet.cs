using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ATG.Database;

namespace ATG.BusinessRule
{
    public class RuleSet
    {
        private AtgDatabase _m_ATGDB;
        private DataTable _m_RlSet;

        public RuleSet()
        {
            _m_ATGDB = new AtgDatabase();
            _m_ATGDB.InitProvider( SRC_DB.SQL_SERVER );
        }

        public DataTable getRuleSet( int inRuleSetID ){
            String RuleSetSQL;

            RuleSetSQL = "SELECT RL_SET_ID" +
                        "        , RL_SET.RL_ID " +
                        "        , RL_SET.RSLT_ACTN_TRUE " +             // 1 = Rule, 2 = Calculation
                        "        , RL_SET.RSLT_ACTN_FALSE " +            // 1 = Rule, 2 = Calculation
                        "        , RL_SET.NXT_RL_ID_TRUE  " +
                        "        , RL_SET.NXT_RL_ID_FALSE " +
                        "        , RL_SET.RL_RSLT_TYP " +                // 1 = Rule, 2 = Calculation
                        "        , LEFT_OPTR.CNSTNT_VAL +  " +
                        "          COMP_OPTR.OPRTR_VAL +  " +
                        "          CASE RIGHT_OPTR.DATA_TYP  " +
                        "               WHEN 'STRING' THEN '''' + RIGHT_OPTR.CNSTNT_VAL + '''' " +
                        "               WHEN 'NUMBER' THEN RIGHT_OPTR.CNSTNT_VAL " +
                        "               ELSE RIGHT_OPTR.CNSTNT_VAL " +
                        "          END AS RLE " +
                        " FROM RL_SET " +
                        "      , RL " +
                        "      , (SELECT A.CNSTNT_VAL, A.OBJCT_ID, A.OBJCT_DTL_ID, B.RL_ID, A.DATA_TYP " +
                        "           FROM BSNSRL_OBJCT_DTL A, " +
                        "                RL B " +
                        "          WHERE B.RL_FRM_OBJCT = A.OBJCT_ID " +
                        "            AND B.RL_FRM_OBJCT_DTL = A.OBJCT_DTL_ID " +
                        "         ) LEFT_OPTR  " +
                        "      , (SELECT  A.CNSTNT_VAL, A.OBJCT_ID, A.OBJCT_DTL_ID, B.RL_ID, A.DATA_TYP " +
                        "           FROM BSNSRL_OBJCT_DTL A, " +
                        "                RL B " +
                        "          WHERE B.RL_TO_OBJCT= A.OBJCT_ID " +
                        "            AND B.RL_TO_OBJCT_DTL = A.OBJCT_DTL_ID " +
                        "         ) RIGHT_OPTR " +
                        "      , (SELECT A.OPRTR_VAL, B.RL_ID " +
                        "           FROM OPRTR_TYP A, " +
                        "                RL B " +
                        "          WHERE B.OPRTR_TYP_ID = A.OPRTR_TYP_ID " +
                        "         ) COMP_OPTR  " +
                        " WHERE RL_SET_ID = " + inRuleSetID + 
                        "   AND RL_SET.RL_ID = RL.RL_ID " +
                        "   AND LEFT_OPTR.RL_ID = RL.RL_ID " +
                        "   AND RIGHT_OPTR.RL_ID = RL.RL_ID " +
                        "   AND COMP_OPTR.RL_ID = RL.RL_ID " +
                        " ORDER BY RL_SET_BEGIN DESC ";

            return ( _m_ATGDB.GetDataTable( RuleSetSQL, SRC_DB.SQL_SERVER ) );

        }

        public String BuildRule( int inRuleID ) 
        {
            String retRule = "";

            foreach (DataRow rowApp in _m_RlSet.Rows)
            {
                if ( rowApp["RL_ID"].ToString() == inRuleID.ToString() )
                {
                    retRule = rowApp["RLE"].ToString();
                }
            }
            
            return retRule;
        }
    }
}
